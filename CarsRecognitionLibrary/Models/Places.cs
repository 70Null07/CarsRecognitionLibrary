﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsRecognitionLibrary.Models
{
    public class Place
    {
        public int Id { get; set; }
        public DateTime? Time { get; set; }
        public int Pl1 { get; set; }
        public int Pl2 { get; set; }
        public int Pl3 { get; set; }
        public int Pl4 { get; set; }
        public int Pl5 { get; set; }
        public int Pl6 { get; set; }
        public int Pl7 { get; set; }
        public int Pl8 { get; set; }
        public int Pl9 { get; set; }
        public int Pl10 { get; set; }
        public int Pl11 { get; set; }
        public int Pl12 { get; set; }
        public int Pl13 { get; set; }
        public int Pl14 { get; set; }
        public int Pl15 { get; set; }
        public int Pl16 { get; set; }
        public int Pl17 { get; set; }
        public int Pl18 { get; set; }
        public int Pl19 { get; set; }
        public int Pl20 { get; set; }
        public int Pl21 { get; set; }
        public int Pl22 { get; set; }
        public int Pl23 { get; set; }
        public int Pl24 { get; set; }
        public int Pl25 { get; set; }
        public int Pl26 { get; set; }
        public int Pl27 { get; set; }
        public int Pl28 { get; set; }
        public int Pl29 { get; set; }
        public int Pl30 { get; set; }
        public int Pl31 { get; set; }
        public int Pl32 { get; set; }
        public int Pl33 { get; set; }
        public int Pl34 { get; set; }
        public int Pl35 { get; set; }
        public int Pl36 { get; set; }
        public int Pl37 { get; set; }
        public int Pl38 { get; set; }
        public int Pl39 { get; set; }
        public int Pl40 { get; set; }
        public int Pl41 { get; set; }
        public int Pl42 { get; set; }
        public int Pl43 { get; set; }
        public int Pl44 { get; set; }
        public int Pl45 { get; set; }
        public int Pl46 { get; set; }
        public int Pl47 { get; set; }
        public int Pl48 { get; set; }
        public int Pl49 { get; set; }
        public int Pl50 { get; set; }
        public int Pl51 { get; set; }
        public int Pl52 { get; set; }
        public int Pl53 { get; set; }
        public int Pl54 { get; set; }
        public int Pl55 { get; set; }
        public int Pl56 { get; set; }
        public int Pl57 { get; set; }
        public int Pl58 { get; set; }
        public int Pl59 { get; set; }
        public int Pl60 { get; set; }
        public int Pl61 { get; set; }
        public int Pl62 { get; set; }
        public int Pl63 { get; set; }
        public int Pl64 { get; set; }
        public int Pl65 { get; set; }
        public int Pl66 { get; set; }
        public int Pl67 { get; set; }
        public int Pl68 { get; set; }
        public int Pl69 { get; set; }
        public int Pl70 { get; set; }
        public int Pl71 { get; set; }
        public int Pl72 { get; set; }
        public int Pl73 { get; set; }
        public int Pl74 { get; set; }
        public int Pl75 { get; set; }
        public int Pl76 { get; set; }
        public int Pl77 { get; set; }
        public int Pl78 { get; set; }
        public int Pl79 { get; set; }
        public int Pl80 { get; set; }
        public int Pl81 { get; set; }
        public int Pl82 { get; set; }
        public int Pl83 { get; set; }
        public int Pl84 { get; set; }
        public int Pl85 { get; set; }
        public int Pl86 { get; set; }
        public int Pl87 { get; set; }
        public int Pl88 { get; set; }
        public int Pl89 { get; set; }
        public int Pl90 { get; set; }
        public int Pl91 { get; set; }
        public int Pl92 { get; set; }
        public int Pl93 { get; set; }
        public int Pl94 { get; set; }
        public int Pl95 { get; set; }
        public int Pl96 { get; set; }
        public int Pl97 { get; set; }
        public int Pl98 { get; set; }
        public int Pl99 { get; set; }
        public int Pl100 { get; set; }
        public int Pl101 { get; set; }
        public int Pl102 { get; set; }
        public int Pl103 { get; set; }
        public int Pl104 { get; set; }
        public int Pl105 { get; set; }
        public int Pl106 { get; set; }
        public int Pl107 { get; set; }
        public int Pl108 { get; set; }
        public int Pl109 { get; set; }
        public int Pl110 { get; set; }
        public int Pl111 { get; set; }
        public int Pl112 { get; set; }
        public int Pl113 { get; set; }
        public int Pl114 { get; set; }
        public int Pl115 { get; set; }

        // Поле класса по имени
        public object? this[string key]
        {
            get
            {
                var prop = GetType().GetProperties();
                var p = prop.FirstOrDefault(x => x.Name == key);
                if (p == null)
                    return null;
                return p.GetValue(this, null);
            }
            set
            {
                var prop = GetType().GetProperties();
                var p = prop.FirstOrDefault(x => key == x.Name);
                if (p == null)
                    return;
                p.SetValue(this, value, null);
            }
        }
    }
}
