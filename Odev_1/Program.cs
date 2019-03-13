using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string filePath = @"..\logs.txt";
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Savas Loglari");
            Meydan arena = new Meydan();
            Takim team1 = new Takim(1, arena,sw);
            Takim team2 = new Takim(2, arena,sw);
            arena.Sw = sw;
            arena.Team1 = team1;
            arena.Team2 = team2;
            sw.Flush();

            Random rand = new Random(); // ileride rastgele sayi olusturmak icin kullanilicak
            int karar, sira = 0, tas;//hangi askerin ne yapicagina ve siranin hangi takimda olduguna karar vericek olan degiskenler


            while (arena.Continue())//kaybeden takim( butun askerlerinin cani 0 olan takim) olmadigi surece islemleri devam ettiricek olan while
            {

                karar = rand.Next(1, 3);// askerin ates mi edecegini yoksa haraket mi edecegine karar veren rastgele sayi atanan degisken
                tas = rand.Next(0, 7);// hangi askerin eylemde bulunacagini belirleyen degisken
                if (sira % 2 == 0) // sira kontrolu
                {
                    if (team1.Boluk[tas].IsAlive)// eger karar verilen tas canli ise eylem yapilicak yoksa sira kaybi olmayacak
                    {
                        if (karar == 1)// haraket etme karari 
                        {
                            team1.Boluk[tas].HareketEt();
                        }
                        else // ates etme karari
                        {
                            team1.Boluk[tas].AtesEt();
                        }
                        sira++;// siranin degismesi icin arttiriliyor
                    }
                    else
                    {
                        if (!arena.Continue()) break;
                    }
                }
                else
                {
                    if (team2.Boluk[tas].IsAlive)
                    {
                        if (karar == 1)
                        {
                            team2.Boluk[tas].HareketEt();
                        }
                        else
                        {
                            team2.Boluk[tas].AtesEt();
                        }
                        sira++;
                    }
                    else
                    {
                        if (!arena.Continue()) break;
                    }
                }
            }
            sw.Close();
            fs.Close();

            Console.ReadKey(); // Konsol ekrani islem biter bitmez kapanmasin diye

        }
    }
}
