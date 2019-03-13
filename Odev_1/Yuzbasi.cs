using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Yuzbasi : Asker
    {
        public Yuzbasi(int takim,Bolge bolge):base(3,takim)
        {
            this.Health = 100;
            this.IsAlive = true;
            this.Coor = bolge;

        }//constructor method

        public override void HareketEt()
        {
            Random r = new Random();
            int rand = r.Next(1, 10);
            switch (rand) 
                /*Meydandaki isValidPoslari ve isFreePointleri kullanarak yap ! zorda kalirsan Tegmen ve Er kodlarina tekrar bak 
                 * ve gerekli commentleri yaz ayrica meydan classina takimlarda herhangi birinin canlari 0 oldu mu kontrolu de koy !! 
                 */
            {
                case 1:
                    if (Area.isValidPosForDown(this))
                    {
                        if (Area.isFreePos(Area.Point[Coor.X,Coor.Y+1]))
                        {
                            this.Coor = Area.Point[Coor.X, Coor.Y + 1]; //asagi yurur
                            Sw.WriteLine("-----------------------------");
                            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki YUZBASI'si :");
                            Sw.WriteLine("(" + (Coor.X) + "," + (Coor.Y + 1) + ") Karesine gitti .");
                            Sw.Flush();
                        }
                    }
                    break;
                case 2:
                    if (Area.isValidPosForRight(this))
                    {
                        if (Area.isFreePos(Area.Point[this.Coor.X + 1, this.Coor.Y]))
                        {
                            this.Coor = Area.Point[this.Coor.X + 1, this.Coor.Y]; // saga yurur
                            Sw.WriteLine("-----------------------------");
                            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki YUZBASI'si :");
                            Sw.WriteLine("(" + (Coor.X+1) + "," + (Coor.Y) + ") Karesine gitti .");
                            Sw.Flush();
                        }
                    }
                    break;
                case 3:
                    if (Area.isValidPosForLeft(this))
                    {
                        if (Area.isFreePos(Area.Point[this.Coor.X - 1, this.Coor.Y]))
                        {
                            this.Coor = Area.Point[this.Coor.X - 1, this.Coor.Y]; // sola yurur
                            Sw.WriteLine("-----------------------------");
                            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki YUZBASI'si :");
                            Sw.WriteLine("(" + (Coor.X-1) + "," + (Coor.Y) + ") Karesine gitti .");
                            Sw.Flush();
                        }
                    }
                    break;
                case 4:
                    if (Area.isValidPosForUp(this)) //bos kutu ve tahta ucu kontrolu
                    {
                        if (Area.isFreePos(Area.Point[this.Coor.X, this.Coor.Y - 1]))
                        {
                            this.Coor = Area.Point[this.Coor.X, this.Coor.Y - 1];//yukari yurur
                            Sw.WriteLine("-----------------------------");
                            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki YUZBASI'si :");
                            Sw.WriteLine("(" + (Coor.X) + "," + (Coor.Y - 1) + ") Karesine gitti .");
                            Sw.Flush();
                        }
                    }
                    break;
                case 5:
                    if(Area.isValidPosForUp(this) && Area.isValidPosForLeft(this))
                    {
                        if (Area.isFreePos(Area.Point[Coor.X - 1, Coor.Y - 1]))
                        {
                            Coor = Area.Point[Coor.X - 1, Coor.Y - 1];// sol uste yurur
                            Sw.WriteLine("-----------------------------");
                            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki YUZBASI'si :");
                            Sw.WriteLine("(" + (Coor.X -1) + "," + (Coor.Y -1 ) + ") Karesine gitti .");
                            Sw.Flush();
                        }
                    }
                    break;
                case 6:
                    if (Area.isValidPosForUp(this) && Area.isValidPosForRight(this))
                    {
                        if (Area.isFreePos(Area.Point[Coor.X + 1, Coor.Y - 1]))
                        {
                            Coor = Area.Point[Coor.X + 1, Coor.Y - 1];// sag uste yurur
                            Sw.WriteLine("-----------------------------");
                            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki YUZBASI'si :");
                            Sw.WriteLine("(" + (Coor.X + 1) + "," + (Coor.Y - 1) + ") Karesine gitti .");
                            Sw.Flush();
                        }
                    }
                    break;
                case 7:
                    if (Area.isValidPosForDown(this) && Area.isValidPosForRight(this))
                    {
                        if (Area.isFreePos(Area.Point[Coor.X + 1, Coor.Y + 1]))
                        {
                            Coor = Area.Point[Coor.X + 1, Coor.Y + 1];// sag alta yurur
                            Sw.WriteLine("-----------------------------");
                            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki YUZBASI'si :");
                            Sw.WriteLine("(" + (Coor.X + 1) + "," + (Coor.Y + 1) + ") Karesine gitti .");
                            Sw.Flush();
                        }
                    }
                    break;
                case 8:
                    if (Area.isValidPosForDown(this) && Area.isValidPosForLeft(this))
                    {
                        if (Area.isFreePos(Area.Point[Coor.X - 1, Coor.Y + 1]))
                        {
                            Coor = Area.Point[Coor.X - 1, Coor.Y + 1];// sol alt yurur
                            Sw.WriteLine("-----------------------------");
                            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki YUZBASI'si :");
                            Sw.WriteLine("(" + (Coor.X - 1) + "," + (Coor.Y + 1) + ") Karesine gitti .");
                            Sw.Flush();
                        }
                    }
                    break;
                case 9:
                    Sw.WriteLine("-----------------------------");
                    Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki YUZBASI'si :");
                    Sw.WriteLine("BEKLEDI.");
                    Sw.Flush();
                    break;


            }

        }// hareket methodu
        public override void AtesEt()
        {
            Console.WriteLine(Team + " . Takimin Yuzbasi Ates Etti ! ");
            Sw.WriteLine("-----------------------------");
            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki YUZBASI'si :");
            Sw.WriteLine("Ates Etti.");
            Sw.Flush();
            Random r = new Random();
            int rand = r.Next(1, 11);
            if (rand <= 5) //%50 sans kontrolu
            {
                Area.isShot(this, 15); // hasarlari yoneten meydan metdou 

            }
            else if (rand <= 8) // %30 sans kontrolu 
            {
                Area.isShot(this, 25);

            }
            else // % 20 sans kontrolu
            {
                Area.isShot(this, 40);

            }
        }// ates etme methodu
    }
}
