using CarsRecognitionLibrary.Models;
using Compunet.YoloV8;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace CarsRecognitionLibrary
{
	// Класс для представления парковочного места
	public class ParkingSpace
    {
        // Поле представления вершин квадрата возможной точки
        public Point[] Vertices { get; set; }
        // Поле представления границ полигона парковочного места
        public Point[] Borders { get; set; }

        public ParkingSpace()
        {
            Vertices = [];
            Borders = [];
        }
    }

    public class CarRecognition
    {
        private string _resizedPath = string.Empty;

        private Bitmap ParkingImg { get; set; }

        private List<ParkingSpace> ParkingSpaces { get; set; }

        private readonly Data.ApplicationContext _context;

        // Конструктор с параметрами
        public CarRecognition(string imgPath)
        {
            if (!Path.Exists(imgPath))
                throw new FileNotFoundException("Файл " + imgPath + " не найден.");

            ParkingImg = new Bitmap(imgPath);
            var json = File.ReadAllText("./parkingplaces.json");

            var jObject = JObject.Parse(json);
            ParkingSpaces = jObject["ParkingSpaces"].ToObject<List<ParkingSpace>>();

            //var json = JsonConvert.SerializeObject(allSpaces);
            //File.WriteAllText("parkingplaces.json", json);

            _context = new Data.ApplicationContext();
        }

        public int Recognize()
        {
            // Проверка на непустое изображение
            if (ParkingImg == null)
                return -1;
            // Проверка на соответствие размерам модели
            if (ParkingImg.Width != 640 || ParkingImg.Height != 640)
                ResizeImage(640, 640);

            using YoloV8Predictor predictor = YoloV8Predictor.Create("./best.onnx");
            Compunet.YoloV8.Data.DetectionResult result = predictor.Detect("./cropped.jpg");

            List<int> placestaken = [];

            for (int i = 0; i < result.Boxes.Length; i++)
            {
                Point boxCenter = new(result.Boxes[i].Bounds.Left + result.Boxes[i].Bounds.Width / 2,
                    result.Boxes[i].Bounds.Top + result.Boxes[i].Bounds.Height / 2);

                int currentPlace = 1;

                foreach (var place in ParkingSpaces)
                {
                    if (place.Vertices.First().X <= boxCenter.X && boxCenter.X <= place.Vertices.Last().X &&
                        place.Vertices.First().Y <= boxCenter.Y && boxCenter.Y <= place.Vertices.Last().Y)
                        placestaken.Add(currentPlace);

                    currentPlace++;
                }
            }

            string plTakenStr = placestaken.Count.ToString();
            File.WriteAllText("C:\\temp\\plTaken.txt", plTakenStr);

            Place CurrentLoad = new();

            int pl = 1;

            for (int i = 0; i < ParkingSpaces.Count; i++)
            {
                if (_context.Places.Any())
                {
                    string prevPlState = _context.Places.OrderBy(x => x.Id).Last()["Pl" + (pl)]
                                    .ToString();
                    if (prevPlState != "0" && prevPlState != "1")
                    {
                        CurrentLoad["Pl" + (pl)] = int.Parse(prevPlState);
                    }
                    else if (placestaken.Contains(pl))
                        CurrentLoad["Pl" + (pl)] = 1;
                    else
                        CurrentLoad["Pl" + (pl)] = 0;
                }
                else if (placestaken.Contains(pl))
                    CurrentLoad["Pl" + (pl)] = 1;
                else
                    CurrentLoad["Pl" + (pl)] = 0;
                pl++;
            }

            //CurrentLoad["Time"] = SqlDateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            CurrentLoad["Time"] = DateTime.Now/*.ToString("yyyy-MM-dd HH:mm:ss")*/;

            _context.Places.Add(CurrentLoad);
            _context.SaveChanges();

            return 0;
        }

        public int DrawPlace()
        {
            if (!_context.Places.Any())
                return -1;

            Bitmap resizedImg = new Bitmap(_resizedPath);
            // Create a Graphics object to do the drawing, *with the new bitmap as the target*
            using Graphics g = Graphics.FromImage(resizedImg);

            //for (int i = 0; i < ParkingSpaces.Count; i++)
            for (int i = 0; i < ParkingSpaces.Count; i++)
            {
                string prevPlState = _context.Places.OrderBy(x => x.Id).Last()["Pl" + (i + 1)]
                                                                       .ToString();
                if (prevPlState == "0" || prevPlState == "2")
                    g.FillPolygon(new SolidBrush(Color.FromArgb(128, 51, 153, 51)), ParkingSpaces[i].Borders.ToArray());
                else
                    g.FillPolygon(new SolidBrush(Color.FromArgb(128, 255, 102, 51)), ParkingSpaces[i].Borders.ToArray());
            }
            resizedImg.Save("./parkingload.jpg");

            return 0;
        }

        private void ResizeImage(int width, int height)
        {
            Bitmap cropped = new(952, 612);

            // Create a Graphics object to do the drawing, *with the new bitmap as the target*
            using (Graphics g = Graphics.FromImage(cropped))
            {
                // Draw the desired area of the original into the graphics object
                g.DrawImage(ParkingImg, new Rectangle(0, 0, 952, 612), new Rectangle(0, 618, 952, 612), GraphicsUnit.Pixel);
            }
            ParkingImg = cropped;

            _resizedPath = "./resized" + DateTime.Now.ToString().Replace(" ", "").Replace(".", "_").Replace(":","_") + ".jpg"; 

			ParkingImg.Save(_resizedPath);

            Bitmap resizedImage = new(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.Bilinear;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(ParkingImg, 0, 0, width, height);
            }

            ParkingImg = resizedImage;
            ParkingImg.Save("./cropped.jpg");
        }
    }
}
