﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace lezer
{
    internal class JatekKezelo
    {
        public HashSet<string> set;

        List<JatekosLovese> loves;
        public static float Ykozep;
        public static float Xkozep;
        public int id = 1;
        public JatekKezelo()
        {
            loves = new();
            set = new();
            FeladatFeltolt();
            Feladatok();
        }

        private void FeladatFeltolt()
        {
            
            FileStream fs = new FileStream("lovesek.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string sor;
            
            sor = sr.ReadLine();
            string[] adatok = sor.Split(';');
            Xkozep = float.Parse(adatok[0]);
            Ykozep = float.Parse(adatok[1]);
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                adatok = sor.Split(';');
                loves.Add(new JatekosLovese(adatok[0], float.Parse(adatok[1]), float.Parse(adatok[2]), id));
                id++;
            }
        }


        public void Hanyloves()
        {
            Console.WriteLine($"Ennyi lövést adtak le: {loves.Count.ToString()}");

        }

        public void Feladatok()
        {
            feladatsorszam(5);
            Hanyloves();
            feladatsorszam(7,$"A legpontosabb lövés:{LegpontosabbLoves()}");
            feladatsorszam(10, $"A résztvevő játékosok száma (LINQ):{ResztvevoJatekosokLINQ()}");
            feladatsorszam(10, $"A résztvevő játékosok száma (SET):{ResztvevoJatekosokSet()}");
            feladatsorszam(11);
            LovesekSzama();
            feladatsorszam(12);
            AtlagPontszam();
            Console.ReadKey();
        }



        private void feladatsorszam(byte id, string szoveg="")
        {
            Console.WriteLine($"{id}. feladat: {szoveg}\n");
        }

        private string LegpontosabbLoves()
        {
            var x = (from l in loves
                     orderby l.T
                     select l).First();
            string adatf = $"ID: {x.Id}; Név: {x.Nev}; X:{x.X}; Y: {x.Y}; Távolság:{x.T}";
            return adatf;
        }

        private int ResztvevoJatekosokLINQ()
        {

            var x = (from l in loves
                     select l.Nev).Distinct<string>();


            return x.Count();            
                    
        }

        private int ResztvevoJatekosokSet()
        {
            foreach (var l in loves)
            {
                set.Add(l.Nev);
            }

           

            return set.Count();
        }

        private void AtlagPontszam()
        {
            foreach (string s in set)
            {
                int db = 0;
                float ossz = 0;
                foreach (var l in loves)
                {
                    if (l.Nev == s)
                    {
                        db++;
                        ossz += l.Pontszam;
                    }


                }
                Console.WriteLine($"{s} : {ossz / (float)db}");


            }
        }

        private void LovesekSzama()
        {
            Dictionary<string, int> stat = new();

            foreach (var l in loves)
            {
                if (stat.ContainsKey(l.Nev) == false)
                {
                    stat.Add(l.Nev, 1);
                }
                else
                {
                    stat[l.Nev]++;
                }

            }

            foreach (KeyValuePair<string,int> x in stat)
            {
                Console.WriteLine($"{x.Key} lövéseinek száma: {x.Value}");
                
            }


        }
    }


    
}
