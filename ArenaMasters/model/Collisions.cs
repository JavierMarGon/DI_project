using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using static ArenaMasters.Collisions;

namespace ArenaMasters
{
    internal class Collisions
    {
        private MapasContainer mapasContainer;

        public List<ColisionMapa> ObtenerMapa(int map)
        {
            switch (map)
            {
                case 1:
                    return mapasContainer.Mapa1;
                case 2:
                    return mapasContainer.Mapa2;
                case 3:
                    return mapasContainer.Mapa3;
                case 4:
                    return mapasContainer.Mapa4;
                case 5:
                    return mapasContainer.Mapa5;
                case 6:
                    return mapasContainer.Mapa6;
                default:
                    throw new ArgumentException("Nombre de mapa no válido");
            }
        }

        public Collisions()
        {
            mapasContainer = JsonConvert.DeserializeObject<MapasContainer>(json);
        }

        public class MapasContainer
        {
            [JsonProperty("Mapa1")]
            public List<ColisionMapa> Mapa1 { get; set; }

            [JsonProperty("Mapa2")]
            public List<ColisionMapa> Mapa2 { get; set; }

            [JsonProperty("Mapa3")]
            public List<ColisionMapa> Mapa3 { get; set; }

            [JsonProperty("Mapa4")]
            public List<ColisionMapa> Mapa4 { get; set; }

            [JsonProperty("Mapa5")]
            public List<ColisionMapa> Mapa5 { get; set; }

            [JsonProperty("Mapa6")]
            public List<ColisionMapa> Mapa6 { get; set; }
        }

        // Clase para representar cada elemento del array en el JSON
        public class ColisionMapa
        {
            public string Name { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
            public int Left { get; set; }
            public int Top { get; set; }
            public int Rotation { get; set; }
            public string Path { get; set; }
        }

        public string json = @"{
                                    ""Mapa1"": [
                                        {
                                            ""Name"": ""colisionmapa1"",
                                            ""Height"": 85,
                                            ""Width"": 448,
                                            ""Left"": 81,
                                            ""Top"": 233
                                        },
                                        {
                                            ""Name"": ""colisionmapa2"",
                                            ""Height"": 218,
                                            ""Width"": 152,
                                            ""Left"": 153,
                                            ""Top"": 10
                                        },
                                        {
                                            ""Name"": ""colisionmapa3"",
                                            ""Height"": 140,
                                            ""Width"": 67,
                                            ""Left"": 10,
                                            ""Top"": 317
                                        },
                                        {
                                            ""Name"": ""colisionmapa4"",
                                            ""Height"": 105,
                                            ""Width"": 350,
                                            ""Left"": 44,
                                            ""Top"": 462
                                        },
                                        {
                                            ""Name"": ""colisionmapa5"",
                                            ""Height"": 105,
                                            ""Width"": 153,
                                            ""Left"": 44,
                                            ""Top"": 572
                                        },
                                        {
                                            ""Name"": ""colisionmapa6"",
                                            ""Height"": 77,
                                            ""Width"": 511,
                                            ""Left"": 197,
                                            ""Top"": 682
                                        },
                                        {
                                            ""Name"": ""colisionmapa7"",
                                            ""Height"": 105,
                                            ""Width"": 292,
                                            ""Left"": 534,
                                            ""Top"": 462
                                        },
                                        {
                                            ""Name"": ""colisionmapa8"",
                                            ""Height"": 192,
                                            ""Width"": 105,
                                            ""Left"": 721,
                                            ""Top"": 572
                                        },
                                        {
                                            ""Name"": ""colisionmapa9"",
                                            ""Height"": 48,
                                            ""Width"": 337,
                                            ""Left"": 826,
                                            ""Top"": 701
                                        },
                                        {
                                            ""Name"": ""colisionmapa10"",
                                            ""Height"": 148,
                                            ""Width"": 161,
                                            ""Left"": 1163,
                                            ""Top"": 572
                                        },
                                        {
                                            ""Name"": ""colisionmapa11"",
                                            ""Height"": 105,
                                            ""Width"": 329,
                                            ""Left"": 967,
                                            ""Top"": 462
                                        },
                                        {
                                            ""Name"": ""colisionmapa12"",
                                            ""Height"": 261,
                                            ""Width"": 228,
                                            ""Left"": 1096,
                                            ""Top"": 196
                                        },
                                        {
                                            ""Name"": ""colisionmapa13"",
                                            ""Height"": 261,
                                            ""Width"": 261,
                                            ""Left"": 688,
                                            ""Top"": 57
                                        },
                                        {
                                            ""Name"": ""colisionmapa14"",
                                            ""Height"": 121,
                                            ""Width"": 371,
                                            ""Left"": 309,
                                            ""Top"": -28
                                        },
                                        {
                                            ""Name"": ""colisionmapa15"",
                                            ""Height"": 126,
                                            ""Width"": 375,
                                            ""Left"": 949,
                                            ""Top"": -65
                                        },
                                        {
                                            ""Name"": ""colisionmapa16"",
                                            ""Height"": 131,
                                            ""Width"": 88,
                                            ""Left"": 1324,
                                            ""Top"": 66
                                        },
                                        {
                                            ""Name"": ""enemigoImg1"",
                                            ""Height"": 45,
                                            ""Width"": 50,
                                            ""Left"": 688,
                                            ""Top"": 365 ,
                                            ""Path"": ""/images/dragon.png""
                                        },
                                        {
                                            ""Name"": ""enemigoColl1"",
                                            ""Height"": 45,
                                            ""Width"": 50,
                                            ""Left"": 688,
                                            ""Top"": 365 
                                        },
                                        {
                                            ""Name"": ""bedImg1"",
                                            ""Height"": 93,
                                            ""Width"": 109,
                                            ""Left"": 330,
                                            ""Top"": 200,
                                            ""Rotation"": -90
                                        },
                                        {
                                            ""Name"": ""bedCollision1"",
                                            ""Height"": 93,
                                            ""Width"": 109,
                                            ""Left"": 330,
                                            ""Top"": 120
                                        },
                                        {
                                            ""Name"": ""bedCollision2"",
                                            ""Height"": 100,
                                            ""Width"": 102,
                                            ""Left"": 1018,
                                            ""Top"": 580
                                        },
                                        {
                                            ""Name"": ""bedImg2"",
                                            ""Height"": 100,
                                            ""Width"": 102,
                                            ""Left"": 1095,
                                            ""Top"": 580,
                                            ""Rotation"": 90
                                        },
                                        {
                                            ""Name"": ""finallyLvl"",
                                            ""Height"": 100,
                                            ""Width"": 102,
                                            ""Left"": 1108,
                                            ""Top"": 76
                                        }
                                    ],
                                    ""Mapa2"": [
                                        {
                                            ""Name"": ""colisionmapa1"",
                                            ""Height"": 163,
                                            ""Width"": 358,
                                            ""Left"": 308,
                                            ""Top"": 47
                                        },
                                        {
                                            ""Name"": ""colisionmapa2"",
                                            ""Height"": 60,
                                            ""Width"": 318,
                                            ""Left"": 40,
                                            ""Top"": 10
                                        },
                                        {
                                            ""Name"": ""colisionmapa3"",
                                            ""Height"": 60,
                                            ""Width"": 616,
                                            ""Left"": 666,
                                            ""Top"": 10
                                        },
                                        {
                                            ""Name"": ""colisionmapa4"",
                                            ""Height"": 163,
                                            ""Width"": 88,
                                            ""Left"": 1287,
                                            ""Top"": 47
                                        },
                                        {
                                            ""Name"": ""colisionmapa5"",
                                            ""Height"": 133,
                                            ""Width"": 499,
                                            ""Left"": 866,
                                            ""Top"": 190
                                        },
                                        {
                                            ""Name"": ""colisionmapa6"",
                                            ""Height"": 50,
                                            ""Width"": 365,
                                            ""Left"": 917,
                                            ""Top"": 443
                                        },
                                        {
                                            ""Name"": ""colisionmapa7"",
                                            ""Height"": 138,
                                            ""Width"": 365,
                                            ""Left"": 1193,
                                            ""Top"": 498
                                        },
                                        {
                                            ""Name"": ""colisionmapa8"",
                                            ""Height"": 100,
                                            ""Width"": 276,
                                            ""Left"": 917,
                                            ""Top"": 611
                                        },
                                        {
                                            ""Name"": ""colisionmapa9"",
                                            ""Height"": 118,
                                            ""Width"": 78,
                                            ""Left"": 588,
                                            ""Top"": 330
                                        },
                                        {
                                            ""Name"": ""colisionmapa10"",
                                            ""Height"": 268,
                                            ""Width"": 163,
                                            ""Left"": 588,
                                            ""Top"": 443
                                        },
                                        {
                                            ""Name"": ""colisionmapa11"",
                                            ""Height"": 247,
                                            ""Width"": 80,
                                            ""Left"": 324,
                                            ""Top"": 330
                                        },
                                        {
                                            ""Name"": ""colisionmapa12"",
                                            ""Height"": 97,
                                            ""Width"": 250,
                                            ""Left"": 79,
                                            ""Top"": 330
                                        },
                                        {
                                            ""Name"": ""colisionmapa13"",
                                            ""Height"": 125,
                                            ""Width"": 78,
                                            ""Left"": 1287,
                                            ""Top"": 323
                                        },
                                        {
                                            ""Name"": ""colisionmapa14"",
                                            ""Height"": 66,
                                            ""Width"": 473,
                                            ""Left"": 118,
                                            ""Top"": 683
                                        },
                                        {
                                            ""Name"": ""colisionmapa15"",
                                            ""Height"": 113,
                                            ""Width"": 80,
                                            ""Left"": 38,
                                            ""Top"": 577
                                        },
                                        {
                                            ""Name"": ""colisionmapa16"",
                                            ""Height"": 140,
                                            ""Width"": 80,
                                            ""Left"": 118,
                                            ""Top"": 427
                                        },
                                        {
                                            ""Name"": ""colisionmapa17"",
                                            ""Height"": 276,
                                            ""Width"": 64,
                                            ""Left"": 14,
                                            ""Top"": 47
                                        },
                                        {
                                            ""Name"": ""colisionmapa18"",
                                            ""Height"": 76,
                                            ""Width"": 161,
                                            ""Left"": 756,
                                            ""Top"": 693
                                        },
                                        {
                                            ""Name"": ""bedImg1"",
                                            ""Height"": 93,
                                            ""Width"": 109,
                                            ""Left"": 1100,
                                            ""Top"": 420,
                                            ""Rotation"": -90
                                        },
                                        {
                                            ""Name"": ""bedCollision1"",
                                            ""Height"": 100,
                                            ""Width"": 102,
                                            ""Left"": 1157,
                                            ""Top"": 330
                                        },
                                        {
                                            ""Name"": ""bedImg2"",
                                            ""Height"": 93,
                                            ""Width"": 109,
                                            ""Left"": 214,
                                            ""Top"": 444,
                                            ""Rotation"": 0
                                        },
                                        {
                                            ""Name"": ""bedCollision2"",
                                            ""Height"": 100,
                                            ""Width"": 102,
                                            ""Left"": 204,
                                            ""Top"": 447
                                        },
                                        {
                                            ""Name"": ""finallyLvl"",
                                            ""Height"": 100,
                                            ""Width"": 102,
                                            ""Left"": 145,
                                            ""Top"": 81
                                        }
                                    ],
                                    ""Mapa3"": [
                                       {
                                           ""Name"": ""colisionmapa19"",
                                           ""Height"": 60,
                                           ""Width"": 220,
                                           ""Left"": 85,
                                           ""Top"": 10
                                       },
                                       {
                                           ""Name"": ""colisionmapa20"",
                                           ""Height"": 93,
                                           ""Width"": 466,
                                           ""Left"": 303,
                                           ""Top"": 70
                                       },
                                       {
                                           ""Name"": ""colisionmapa21"",
                                           ""Height"": 93,
                                           ""Width"": 118,
                                           ""Left"": 767,
                                           ""Top"": -28
                                       },
                                       {
                                           ""Name"": ""colisionmapa22"",
                                           ""Height"": 93,
                                           ""Width"": 409,
                                           ""Left"": 882,
                                           ""Top"": 70
                                       },
                                       {
                                           ""Name"": ""colisionmapa23"",
                                           ""Height"": 116,
                                           ""Width"": 93,
                                           ""Left"": 1281,
                                           ""Top"": 168
                                       },
                                       {
                                           ""Name"": ""colisionmapa24"",
                                           ""Height"": 131,
                                           ""Width"": 297,
                                           ""Left"": 994,
                                           ""Top"": 286
                                       },
                                       {
                                           ""Name"": ""colisionmapa25"",
                                           ""Height"": 139,
                                           ""Width"": 84,
                                           ""Left"": 1291,
                                           ""Top"": 422
                                       },
                                       {
                                           ""Name"": ""colisionmapa26"",
                                           ""Height"": 139,
                                           ""Width"": 334,
                                           ""Left"": 994,
                                           ""Top"": 547
                                       },
                                       {
                                           ""Name"": ""colisionmapa27"",
                                           ""Height"": 54,
                                           ""Width"": 168,
                                           ""Left"": 826,
                                           ""Top"": 675
                                       },
                                       {
                                           ""Name"": ""colisionmapa28"",
                                           ""Height"": 195,
                                           ""Width"": 290,
                                           ""Left"": 536,
                                           ""Top"": 280
                                       },
                                       {
                                           ""Name"": ""colisionmapa29"",
                                           ""Height"": 225,
                                           ""Width"": 65,
                                           ""Left"": 760,
                                           ""Top"": 475
                                       },
                                       {
                                           ""Name"": ""colisionmapa30"",
                                           ""Height"": 69,
                                           ""Width"": 224,
                                           ""Left"": 536,
                                           ""Top"": 610
                                       },
                                       {
                                           ""Name"": ""colisionmapa31"",
                                           ""Height"": 69,
                                           ""Width"": 131,
                                           ""Left"": 405,
                                           ""Top"": 650
                                       },
                                       {
                                           ""Name"": ""colisionmapa32"",
                                           ""Height"": 106,
                                           ""Width"": 337,
                                           ""Left"": 71,
                                           ""Top"": 575
                                       },
                                       {
                                           ""Name"": ""colisionmapa33"",
                                           ""Height"": 151,
                                           ""Width"": 91,
                                           ""Left"": 3,
                                           ""Top"": 447
                                       },
                                       {
                                           ""Name"": ""colisionmapa34"",
                                           ""Height"": 165,
                                           ""Width"": 105,
                                           ""Left"": 300,
                                           ""Top"": 280
                                       },
                                       {
                                           ""Name"": ""colisionmapa35"",
                                           ""Height"": 130,
                                           ""Width"": 252,
                                           ""Left"": 48,
                                           ""Top"": 315
                                       },
                                       {
                                           ""Name"": ""colisionmapa36"",
                                           ""Height"": 245,
                                           ""Width"": 76,
                                           ""Left"": 18,
                                           ""Top"": 70
                                       },
                                       {
                                           ""Name"": ""bedImg1"",
                                           ""Height"": 93,
                                           ""Width"": 109,
                                           ""Left"": 1257,
                                           ""Top"": 183,
                                           ""Rotation"": 90
                                       },
                                       {
                                           ""Name"": ""bedCollision1"",
                                           ""Height"": 100,
                                           ""Width"": 102,
                                           ""Left"": 1177,
                                           ""Top"": 175
                                       },
                                       {
                                           ""Name"": ""bedImg2"",
                                           ""Height"": 93,
                                           ""Width"": 109,
                                           ""Left"": 115,
                                           ""Top"": 550,
                                           ""Rotation"": -90
                                       },
                                       {
                                           ""Name"": ""bedCollision2"",
                                           ""Height"": 100,
                                           ""Width"": 102,
                                           ""Left"": 133,
                                           ""Top"": 466
                                       },
                                       {
                                           ""Name"": ""finallyLvl"",
                                           ""Height"": 100,
                                           ""Width"": 102,
                                           ""Left"": 1192,
                                           ""Top"": 439
                                       }
                                    ], 
                                    ""Mapa4"": [
                                       {
                                           ""Name"": ""colisionmapa63"",
                                           ""Height"": 210,
                                           ""Width"": 416,
                                           ""Left"": 65,
                                           ""Top"": 20
                                       },
                                       {
                                           ""Name"": ""colisionmapa64"",
                                           ""Height"": 140,
                                           ""Width"": 466,
                                           ""Left"": 40,
                                           ""Top"": 414
                                       },
                                       {
                                           ""Name"": ""colisionmapa65"",
                                           ""Height"": 184,
                                           ""Width"": 100,
                                           ""Left"": -18,
                                           ""Top"": 230
                                       },
                                       {
                                           ""Name"": ""colisionmapa66"",
                                           ""Height"": 184,
                                           ""Width"": 69,
                                           ""Left"": 18,
                                           ""Top"": 521
                                       },
                                       {
                                           ""Name"": ""colisionmapa67"",
                                           ""Height"": 70,
                                           ""Width"": 601,
                                           ""Left"": 87,
                                           ""Top"": 660
                                       },
                                       {
                                           ""Name"": ""colisionmapa68"",
                                           ""Height"": 308,
                                           ""Width"": 148,
                                           ""Left"": 680,
                                           ""Top"": 429
                                       },
                                       {
                                           ""Name"": ""colisionmapa69"",
                                           ""Height"": 140,
                                           ""Width"": 476,
                                           ""Left"": 833,
                                           ""Top"": 550
                                       },
                                       {
                                           ""Name"": ""colisionmapa70"",
                                           ""Height"": 150,
                                           ""Width"": 69,
                                           ""Left"": 1290,
                                           ""Top"": 414
                                       },
                                       {
                                           ""Name"": ""colisionmapa71"",
                                           ""Height"": 184,
                                           ""Width"": 328,
                                           ""Left"": 990,
                                           ""Top"": 230
                                       },
                                       {
                                           ""Name"": ""colisionmapa72"",
                                           ""Height"": 184,
                                           ""Width"": 100,
                                           ""Left"": 1275,
                                           ""Top"": 46
                                       },
                                       {
                                           ""Name"": ""colisionmapa73"",
                                           ""Height"": 70,
                                           ""Width"": 448,
                                           ""Left"": 833,
                                           ""Top"": 0
                                       },
                                       {
                                           ""Name"": ""colisionmapa74"",
                                           ""Height"": 225,
                                           ""Width"": 190,
                                           ""Left"": 643,
                                           ""Top"": 10
                                       },
                                       {
                                           ""Name"": ""colisionmapa75"",
                                           ""Height"": 50,
                                           ""Width"": 152,
                                           ""Left"": 486,
                                           ""Top"": 10
                                       },
                                       {
                                           ""Name"": ""bedCollision1"",
                                           ""Height"": 134,
                                           ""Width"": 102,
                                           ""Left"": 1108,
                                           ""Top"": 84
                                       },
                                       {
                                           ""Name"": ""bedImg1"",
                                           ""Height"": 93,
                                           ""Width"": 109,
                                           ""Left"": 1200,
                                           ""Top"":119,
                                           ""Rotation"": 90
                                       },
                                       {
                                           ""Name"": ""finallyLvl"",
                                           ""Height"": 104,
                                           ""Width"": 102,
                                           ""Left"": 101,
                                           ""Top"": 566
                                       }
                                    ],""Mapa5"": [
                                          {
                                             ""Name"": ""colisionmapa63"",
                                             ""Height"": 119,
                                             ""Width"": 1268,
                                             ""Left"": 45,
                                             ""Top"": 71
                                          },
                                          {
                                             ""Name"": ""colisionmapa64"",
                                             ""Height"": 268,
                                             ""Width"": 304,
                                             ""Left"": 522,
                                             ""Top"": 304
                                          },
                                          {
                                             ""Name"": ""colisionmapa65"",
                                             ""Height"": 268,
                                             ""Width"": 110,
                                             ""Left"": 294,
                                             ""Top"": 304
                                          },
                                          {
                                             ""Name"": ""colisionmapa66"",
                                             ""Height"": 141,
                                             ""Width"": 211,
                                             ""Left"": 78,
                                             ""Top"": 438
                                          },
                                          {
                                             ""Name"": ""colisionmapa67"",
                                             ""Height"": 141,
                                             ""Width"": 191,
                                             ""Left"": 45,
                                             ""Top"": 557
                                          },
                                          {
                                             ""Name"": ""colisionmapa68"",
                                             ""Height"": 51,
                                             ""Width"": 1268,
                                             ""Left"": 40,
                                             ""Top"": 698
                                          },
                                          {
                                             ""Name"": ""colisionmapa69"",
                                             ""Height"": 141,
                                             ""Width"": 68,
                                             ""Left"": 10,
                                             ""Top"": 292
                                          },
                                          {
                                             ""Name"": ""colisionmapa70"",
                                             ""Height"": 141,
                                             ""Width"": 112,
                                             ""Left"": 72,
                                             ""Top"": 151
                                          },
                                          {
                                             ""Name"": ""colisionmapa71"",
                                             ""Height"": 244,
                                             ""Width"": 86,
                                             ""Left"": 972,
                                             ""Top"": 316
                                          },
                                          {
                                             ""Name"": ""colisionmapa72"",
                                             ""Height"": 99,
                                             ""Width"": 289,
                                             ""Left"": 1063,
                                             ""Top"": 316
                                          },
                                          {
                                             ""Name"": ""colisionmapa73"",
                                             ""Height"": 159,
                                             ""Width"": 86,
                                             ""Left"": 1289,
                                             ""Top"": 420
                                          },
                                          {
                                             ""Name"": ""colisionmapa74"",
                                             ""Height"": 159,
                                             ""Width"": 86,
                                             ""Left"": 1289,
                                             ""Top"": 157
                                          },
                                          {
                                             ""Name"": ""colisionmapa75"",
                                             ""Height"": 160,
                                             ""Width"": 110,
                                             ""Left"": 1203,
                                             ""Top"": 564
                                          },
                                          {
                                             ""Name"": ""bedCollision1"",
                                             ""Height"": 134,
                                             ""Width"": 102,
                                             ""Left"": 1108,
                                             ""Top"": 84
                                          },
                                          {
                                             ""Name"": ""bedImg1"",
                                             ""Height"": 93,
                                             ""Width"": 109,
                                             ""Left"": 1200,
                                             ""Top"": 119,
                                             ""Rotation"": 90
                                          },
                                          {
                                             ""Name"": ""finallyLvl"",
                                             ""Height"": 69,
                                             ""Width"": 71,
                                             ""Left"": 112,
                                             ""Top"": 336
                                          }
                                       ],
                                        ""Mapa6"": [
                                        {
                                            ""Name"": ""colisionmapa63"",
                                            ""Height"": 215,
                                            ""Width"": 661,
                                            ""Left"": 69,
                                            ""Top"": 84
                                        },
                                        {
                                            ""Name"": ""colisionmapa64"",
                                            ""Height"": 165,
                                            ""Width"": 660,
                                            ""Left"": 688,
                                            ""Top"": 65
                                        },
                                        {
                                            ""Name"": ""colisionmapa65"",
                                            ""Height"": 165,
                                            ""Width"": 660,
                                            ""Left"": 688,
                                            ""Top"": 535
                                        },
                                        {
                                            ""Name"": ""colisionmapa66"",
                                            ""Height"": 166,
                                            ""Width"": 660,
                                            ""Left"": 70,
                                            ""Top"": 452
                                        },
                                        {
                                            ""Name"": ""colisionmapa67"",
                                            ""Height"": 410,
                                            ""Width"": 55,
                                            ""Left"": 1295,
                                            ""Top"": 192
                                        },
                                        {
                                            ""Name"": ""colisionmapa68"",
                                            ""Height"": 410,
                                            ""Width"": 55,
                                            ""Left"": 33,
                                            ""Top"": 175
                                        }
                                    ]


                                }";
    }
}