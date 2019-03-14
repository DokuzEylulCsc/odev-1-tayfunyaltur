using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Meydan
    {
        private Bolge[,] bolge = new Bolge[16, 16];
        private Takim t1, t2;
        private StreamWriter sw;
        public StreamWriter Sw // vurulma islemlerinin dosyaya yazilabilmesi icin streamWriter tanimlandi daha sonra Main methoddan atanicak
        {
            get
            {
                return sw;//get ve set edilebilicek 
            }
            set
            {
                sw = value;
            }
        }
        public Bolge[,] Point{
            get
            {
                return bolge;
            }

            } //Get methodu
        public Takim Team1
        {
            get
            {
                return t1;
            }
            set
            {
                t1 = value;
            }
        } // get set
        public Takim Team2
        {
            get
            {
                return t2;
            }
            set
            {
                t2 = value;
            }
        } // get  set
        /*takim 1 ve takim 2 meydan icerisine de aktarildi ki daha sonra butun ates etme hareket etme kontrolleri
         * meydan objesi ile kontrol edilicek
         */
        public Meydan()
        {       //bolge isimli Bolge matrisinin [i,j] elemani icin x=i , y=j olucak sekilde ayarlanmistir
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    bolge[i, j] = new Bolge(i, j); // matrise 16x16 tane bolge atar 
                }
            }
        } // Constructor Method 

        public bool isFreePos(Bolge bolge)
        {
            /*askerin gidecegi hedef bolgeyi parametre olarak alip o bolgede baska asker
             * olup olmadigina bakilacak olan fonksiyon , bool bir deger dondurup Askerin
             * haraket et methodunun icerisinde dogrudan if in conditioni olarak kullanilacak
             */
            foreach (Asker a in Team1.Boluk)
            {
                if(a.Coor==bolge && a.IsAlive)
                {
                    return false;
                }
            }
            foreach (Asker a in Team2.Boluk)
            {
                if (a.Coor == bolge && a.IsAlive)
                {
                    return false;
                }
            }
            /*her iki takiminda bolgelerine bakar
             *eger hedef bolgede asker varsa false
             *yoksa true donururu
             */
            return true;
        }
        public bool isValidPosForUp(Asker a)
        {
            /*haraket edicek olan askeri parametre olarak alir ve askerin yukari
         * kose sinirlarda olup olmadigina bakar 
         */
            if (a.Coor.Y <= 0)
            {
                return false;
            }
            /*askerin konumuna bakar eger:
             * tahtanin ust ucunda ise false dondurur
             */
            return true;
        }
        public bool isValidPosForDown(Asker a)
        {
            /*haraket edicek olan askeri parametre olarak alir ve askerin asagi
            * kose sinirlarda olup olmadigina bakar 
            */
            if (a.Coor.Y >= 15)
            {
                return false;
            }
            /*askerin konumuna bakar eger:
             * tahtanin alt ucunda ise false dondurur
             */
            return true;
        }
        public bool isValidPosForLeft(Asker a)
        {
            /*haraket edicek olan askeri parametre olarak alir ve askerin sol
            * kose sinirlarda olup olmadigina bakar 
            */
            if (a.Coor.X <= 0) return false;
            /*askerin konumuna bakar eger:
             * tahtanin sol ucunda ise false dondurur
             */
            return true;
        }
        public bool isValidPosForRight(Asker a)
        {
            /*haraket edicek olan askeri parametre olarak alir ve askerin sag
            * kose sinirlarda olup olmadigina bakar 
            */
            if (a.Coor.X >= 15) return false;
            /*askerin konumuna bakar eger:
             * tahtanin sag ucunda ise false dondurur
             */
            return true;
        }
        public void isShot(Asker a,int Hit)
        {
            /*askeri ve verdigi hasar puanini parametre olarak alir ve o askerin konumuna belirli mesafede
             * olan diger rakip askerlerin canlarini o askerin vericegi hitpoint oraninda azaltir
             * ayni zamanda cani 0in altina veya 0 a dusen asker olursa canini 0a esitler ve 
             * isAlive boolunu flase yapar
             */
            switch (a.Team)
            {
                case 1:
                    foreach(Asker e in Team2.Boluk)
                    {
                        if((Math.Abs(e.Coor.X - a.Coor.X)<=a.Power && Math.Abs(e.Coor.Y - a.Coor.Y) <= a.Power)&&e.IsAlive)
                        {
                            e.Health -= Hit;
                            if (e.Health <= 0)
                            {
                                e.IsAlive = false;
                                e.Health = 0;
                                Console.WriteLine(e.Team + ". Takimdaki (" + e.Coor.X + "," + e.Coor.Y + ") Bolgesindeki Asker "
                                + Hit + "Hasar Aldi ve Cani Kalmadi ,Sizlere Omur");
                                sw.WriteLine(e.Team + ". Takimdaki (" + e.Coor.X + "," + e.Coor.Y + ") Bolgesindeki Asker "
                                + Hit + "Hasar Aldi ve Cani Kalmadi ,Sizlere Omur");
                                sw.Flush();
                            }
                            else
                            {
                                Console.WriteLine(e.Team + ". Takimdaki (" + e.Coor.X + "," + e.Coor.Y + ") Bolgesindeki Asker "
                                + Hit + "Hasar Aldi ve Cani " + e.Health + " KALDI");
                                sw.WriteLine(e.Team + ". Takimdaki (" + e.Coor.X + "," + e.Coor.Y + ") Bolgesindeki Asker "
                                + Hit + "Hasar Aldi ve Cani " + e.Health + " KALDI");
                                sw.Flush();

                            }
                        }
                       
                    }
                    break;
                case 2:
                    foreach (Asker e in Team1.Boluk)
                    {
                        if ((Math.Abs(e.Coor.X - a.Coor.X) <= a.Power && Math.Abs(e.Coor.Y - a.Coor.Y) <= a.Power)&&e.IsAlive)
                        {
                            e.Health -= Hit;
                            if (e.Health <= 0)
                            {
                                e.IsAlive = false;
                                e.Health = 0;
                                Console.WriteLine(e.Team + ". Takimdaki (" + e.Coor.X + "," + e.Coor.Y + ") Bolgesindeki Asker "
                                + Hit + "Hasar Aldi ve Cani Kalmadi ,Sizlere Omur");
                                sw.WriteLine(e.Team + "-------************************************-----");
                                sw.WriteLine(e.Team + ". Takimdaki (" + e.Coor.X + "," + e.Coor.Y + ") Bolgesindeki Asker "
                                + Hit + "Hasar Aldi ve Cani Kalmadi ,Sizlere Omur");
                                sw.WriteLine(e.Team + "-------************************************-----");
                                sw.Flush();
                            }
                            else
                            {
                                Console.WriteLine(e.Team + ". Takimdaki (" + e.Coor.X + "," + e.Coor.Y + ") Bolgesindeki Asker "
                                + Hit + "Hasar Aldi ve Cani " + e.Health + " KALDI");
                                sw.WriteLine(e.Team + "-------************************************-----");
                                sw.WriteLine(e.Team + ". Takimdaki (" + e.Coor.X + "," + e.Coor.Y + ") Bolgesindeki Asker "
                                + Hit + "Hasar Aldi ve Cani " + e.Health + " KALDI");
                                sw.WriteLine(e.Team + "-------************************************-----");
                                sw.Flush();
                            }
                        }
                       
                    }
                    break;
            }
        }
        public bool Continue()
        {
            /*savasin devam edip etmedigini kontrol edicek olan method dogrudan bool donduru ve 
             * main methodunun icerisindeki while in conditioni olarak atanicak 
             * eger herhangi bir takimin butun askerlerinin canlari toplami 
             * 0 a esit olursa false dondurucek ve kaybeden tarafi ilan edicektir
             */
            int teamHealt = 0;
            foreach(Asker a in t1.Boluk)
            {
                teamHealt += a.Health;                
            }
            if (teamHealt == 0)
            {
                Console.WriteLine("Team 1 KAYBETTI");
                sw.WriteLine("Team 1 KAYBETTI");
                sw.Flush();
                return false;
            }
            teamHealt = 0;
            foreach (Asker a in t2.Boluk)
            {
                teamHealt += a.Health;              
            }
            if (teamHealt == 0)
            {
                Console.WriteLine("Team 2 KAYBETTI");
                sw.WriteLine("Team 2 KAYBETTI");
                sw.Flush();
                return false;
            }
            teamHealt = 0;
            return true;
        }
    }
}
