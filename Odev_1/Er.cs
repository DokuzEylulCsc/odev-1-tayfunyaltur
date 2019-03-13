using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Er : Asker 
    {
        
        public Er(int takim,Bolge bolge):base(1,takim)   // constructor method 
        {
            this.Health = 100;
            this.IsAlive = true;
            this.Coor = bolge;
           
        }
        public override void HareketEt()// Er in hareketlerini rastgelelestiricek ve hareket etmesini saglicak olan metod 
        {
            Random r = new Random();
            int rand = r.Next(1, 4); // 1 ile 3 arasinda rastgele sayi ureteci 
            switch (rand)
            {
                case 1:
                    if (Area.isValidPosForDown(this))
                    {
                        if(Area.isFreePos(Area.Point[this.Coor.X, this.Coor.Y + 1]))
                        {
                            this.Coor = Area.Point[this.Coor.X, this.Coor.Y + 1];// yukarisi bos ise yukari gider
                            Sw.WriteLine("-----------------------------");
                            Sw.WriteLine(Team+ ". Takimin (" + Coor.X+","+Coor.Y+ ") Konumundaki ER'i :");
                            Sw.WriteLine("("+Coor.X+","+(Coor.Y+1)+") Karesine gitti .");
                            Sw.Flush();
                        }
                    }
                    else if (Area.isValidPosForRight(this))
                    {
                        this.Coor = Area.Point[this.Coor.X + 1, this.Coor.Y]; // yukarisi dolu ise saga gider
                        Sw.WriteLine("-----------------------------");
                        Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki ER'i :");
                        Sw.WriteLine("(" + (Coor.X+1) + "," + (Coor.Y) + ") Karesine gitti .");
                        Sw.Flush();
                    }
                    break;
                case 2:
                    if (Area.isValidPosForUp(this))
                    {
                        if (Area.isFreePos(Area.Point[this.Coor.X, this.Coor.Y - 1]))
                        {
                            this.Coor = Area.Point[this.Coor.X, this.Coor.Y - 1];// asagisi bos ise asagi gider
                            Sw.WriteLine("-----------------------------");
                            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki ER'i :");
                            Sw.WriteLine("(" + (Coor.X) + "," + (Coor.Y-1) + ") Karesine gitti .");
                            Sw.Flush();
                        }
                    }
                    else if (Area.isValidPosForLeft(this))
                    {
                        this.Coor = Area.Point[this.Coor.X - 1, this.Coor.Y];//asagisi dolu ise sola gider
                        Sw.WriteLine("-----------------------------");
                        Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki ER'i :");
                        Sw.WriteLine("(" + (Coor.X - 1) + "," + (Coor.Y) + ") Karesine gitti .");
                        Sw.Flush();
                    }
                    break;
                case 3:
                    Sw.WriteLine("-----------------------------");
                    Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki ER'i :");
                    Sw.WriteLine("BEKLEDI");
                    Sw.Flush();
                    break;

            }
        }
        public override void AtesEt()  // Er in ates etmesini saglicak olan metod 
        {
            Console.WriteLine(Team + " . Takimin Eri Ates Etti ! ");
            Sw.WriteLine("-----------------------------");
            Sw.WriteLine(Team + ". Takimin (" + Coor.X + "," + Coor.Y + ") Konumundaki ER'i :");
            Sw.WriteLine("Ates Etti.");
            Sw.Flush();
            Random r = new Random();
            int rand = r.Next(1, 11); // 1 ile 10 arasinda rastgele sayi ureteci 
            if (rand <= 5) //%50 sans kontrolu
            {
                Area.isShot(this, 5); // hasarlari yoneten meydan metdou 
                
            }
            else if (rand <= 8) // %30 sans kontrolu 
            {
                Area.isShot(this, 10);
                
            }
            else // % 20 sans kontrolu
            {
                Area.isShot(this, 15);
                
            }
        }
    }
}
