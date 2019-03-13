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
        public StreamWriter Sw
        {
            get
            {
                return sw;
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
        }
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
        }
        public Meydan()
        {
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
            foreach(Asker a in Team1.Boluk)
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
            if(a.Coor.Y <= 0)
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
            if (a.Coor.X <= 0) return false;
            /*askerin konumuna bakar eger:
             * tahtanin sol ucunda ise false dondurur
             */
            return true;
        }
        public bool isValidPosForRight(Asker a)
        {
            if (a.Coor.X >= 15) return false;
            /*askerin konumuna bakar eger:
             * tahtanin sag ucunda ise false dondurur
             */
            return true;
        }
        public void isShot(Asker a,int Hit)
        {
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
            }
        }
        public bool Continue()
        {
            int teamHealt = 0;
            foreach(Asker a in t1.Boluk)
            {
                teamHealt += a.Health;
                if (teamHealt == 0)
                {
                    Console.WriteLine("Team 1 KAYBETTI");
                    sw.WriteLine("Team 1 KAYBETTI");
                    sw.Flush();
                    return false;
                    
                }
            }
            teamHealt = 0;
            foreach (Asker a in t2.Boluk)
            {
                teamHealt += a.Health;
                if (teamHealt == 0)
                {
                    Console.WriteLine("Team 2 KAYBETTI");
                    sw.WriteLine("Team 2 KAYBETTI");
                    sw.Flush();
                    return false;
                }
            }
            teamHealt = 0;
            return true;
        }
    }
}
