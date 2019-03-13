using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Tegmen : Asker
    {
        public Tegmen(int takim,Bolge bolge):base(1,takim)// constructor method 
        {
            this.Health = 100;
            this.IsAlive = true;
            this.Coor = bolge;

        }
        public override void HareketEt() //hareketi sagliyacak olan metod 
        {
            Random r = new Random();
            int rand = r.Next(1, 6); // 1 ile 5 arasinda rastgele sayi uretip hareketi rassallastiran degisken 
            switch (rand)
            {
                case 1:
                    if (Area.isValidPosForDown(this)) //bos kutu ve tahta ucu kontrolu
                    {
                        if(Area.isFreePos(Area.Point[this.Coor.X,this.Coor.Y+1]))
                        {
                            this.Coor = Area.Point[this.Coor.X, this.Coor.Y + 1];//asagi yurur
                            Sw.WriteLine("-----------------------------");
                            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki TEGMEN'i :");
                            Sw.WriteLine("(" + (Coor.X) + "," + (Coor.Y+1) + ") Karesine gitti .");
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
                            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki TEGMEN'i :");
                            Sw.WriteLine("(" + (Coor.X+1) + "," + (Coor.Y) + ") Karesine gitti .");
                            Sw.Flush();
                        } 
                    }
                    break;
                case 3:
                    if (Area.isValidPosForLeft(this))
                    {
                        if(Area.isFreePos(Area.Point[this.Coor.X-1, this.Coor.Y]))
                        {
                            this.Coor = Area.Point[this.Coor.X - 1, this.Coor.Y]; // sola yurur
                            Sw.WriteLine("-----------------------------");
                            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki TEGMEN'i :");
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
                            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki TEGMEN'i :");
                            Sw.WriteLine("(" + (Coor.X) + "," + (Coor.Y - 1) + ") Karesine gitti .");
                            Sw.Flush();
                        }
                    }
                    break;
                case 5:
                    Sw.WriteLine("-----------------------------");
                    Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki TEGMEN'i :");
                    Sw.WriteLine("BEKLEDI .");
                    Sw.Flush();
                    break;
            }
        }
        public override void AtesEt() //Ates ettiren metod 
        {
            Console.WriteLine(Team + " . Takimin Tegmeni Ates Etti !");
            Sw.WriteLine("-----------------------------");
            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki TEGMEN'i :");
            Sw.WriteLine("Ates Etti.");
            Sw.Flush();
            Random r = new Random();
            int rand = r.Next(1, 11); // 1 ile 10 arasinda rastgele sayi uretip  vuruslari rassallastiran degisken 
            if (rand <= 5) //%50 sans kontrolu
            {
                Area.isShot(this, 10); // hasarlari yoneten meydan metdou 

            }
            else if (rand <= 8) // %30 sans kontrolu 
            {
                Area.isShot(this, 20);

            }
            else // % 20 sans kontrolu
            {
                Area.isShot(this, 25);

            }
        }
    }
}
