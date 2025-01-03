﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    struct Szemely
    {
        // Láthatóságok
        // private int id == int id (alapértelmezett)
        // private => korlátozott láthatóság
        // public => bárki hozzáfér

        // Mezők
        public int id;
        public string nev;
        public DateTime szulido;
        public string varos;

        // Konstruktor : kezdő értékadás
        // public Struktúranév(paraméterek) {...}
        public Szemely(int id, string nev, 
            DateTime szulido, string varos)
        {
            // Mezők feltöltése a paraméterlistából
            this.id = id;
            this.nev = nev;
            this.szulido = szulido;
            this.varos = varos;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Szemely> adatok = new List<Szemely>();
            // Fájlbeolvasás
            string fajlNev = "szemelyek.txt";
            StreamReader beolvas = new StreamReader(fajlNev);
            string fejlec = beolvas.ReadLine(); // fejléc kiolvasás
            while(!beolvas.EndOfStream)
            {
                string sor = beolvas.ReadLine(); // egy sor beolvasása
                // Sor tördelése/felbontása ; karakterrel
                string[] db = sor.Split(';');
                // 1.sor: 1;Kovács Dominik;2000-04-15;Budapest
                // Feldarabolt sor tömböm indexen lévő elemei
                // db[0] = 1
                // db[1] = Kovács Dominik
                // db[2] = 2000-04-15
                // db[3] = Budapest

                // adatok átalakítása
                int id = int.Parse(db[0]);
                string nev = db[1];
                DateTime szulido = DateTime.Parse(db[2]);
                string varos = db[3];

                // Új személy létrehozása - konstruktor segítségével
                Szemely sz = new Szemely(id, nev, szulido, varos);

                // Személy tárolása
                adatok.Add(sz);
            }
            beolvas.Close(); // Fájl bezárása


            // 3. feladat
            // Hány adatsort tartalmaz => lista elemszáma
            Console.WriteLine($"3. feladat: Az állomány {adatok.Count} db" +
                $" adatsort tartalmaz");

            // 4. feladat
            // Minimum keresés
            int min = adatok[0].szulido.Year; // első elem évszáma
            int j = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                // minimum nagyobb, mint az aktuális évszám
                if(min > adatok[i].szulido.Year)
                {
                    // Új minimum érték
                    min = adatok[i].szulido.Year;
                    j = i; // index mentése, későbbi hivatkozás miatt
                }
            }
            Console.WriteLine("4. feladat: A legidősebb személy adatai:");
            Console.WriteLine($"\tNév: {adatok[j].nev}\n" +
                $"\tSzületési dátum: {adatok[j].szulido:yyyy-MM-dd}\n" +
                $"\tVáros: {adatok[j].varos}");

            // 5. feladat
            // Minimum keresés
            min = adatok[0].szulido.Year; // első elem évszáma
            j = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                // minimum nagyobb, mint az aktuális évszám
                if (min < adatok[i].szulido.Year)
                {
                    // Új minimum érték
                    min = adatok[i].szulido.Year;
                    j = i; // index mentése, későbbi hivatkozás miatt
                }
            }
            Console.WriteLine("5. feladat: A legfitalabb személy adatai:");
            Console.WriteLine($"\tNév: {adatok[j].nev}\n" +
                $"\tSzületési dátum: {adatok[j].szulido:yyyy-MM-dd}\n" +
                $"\tVáros: {adatok[j].varos}");


            // 6. feladat
            // Keresés tétel
            bool talalt = false;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].varos == "Pécs")
                {
                    talalt = true;
                    break;
                }
            }
            if(talalt == true)
            {
                Console.WriteLine($"6. feladat: Van Pécsről érkező illető!");
            }
            else
            {
                Console.WriteLine($"6. feladat: Nincs Pécsről érkező illető!");
            }
            // feltétel ? igaz : hamis
            Console.WriteLine($"6. feladat: {(talalt ? "Van" : "Nincs")} Pécsről érkező illető!");

            // 7. feladat
            // Statisztika
            // Szótár - Kulcs;Érték
            // <kulcs, érték>
            Dictionary<string, int> stat = new Dictionary<string, int>();
            foreach(Szemely sz in adatok)
            {
                // Leválogatás
                // Kulcsokat keresem - Városok
                if(!stat.Keys.Contains(sz.varos)) // Még nem tartalmazza a várost
                {
                    // pl: Budapest;1
                    stat.Add(sz.varos, 1); // Város, érték
                }
                else
                {
                    // pl: ["Budapest"] +1
                    // Budapest;2
                    stat[sz.varos]++;
                }
            }
            // Kiír
            Console.WriteLine("7. feladat: Városok szerinti csoportosítás:");
            foreach(var e in stat)
            {
                // Key, Value
                Console.WriteLine($"\t{e.Key} - {e.Value} személy");
            }

            // 8. feladat: HÁZI


            Console.ReadKey();
        }
    }
}
