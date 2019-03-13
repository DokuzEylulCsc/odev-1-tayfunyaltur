using System.IO;

namespace Odev_1
{
    class Takim
    {
        private Asker[] boluk=new Asker[7];
        public Asker[] Boluk
        {
            get
            {
                return boluk;
            }
        }//Get methodu
        public Takim(int takim,Meydan area,StreamWriter sw)
        {
            if (takim == 1) { 
            for (int i = 0; i < 4; i++)
            {
                boluk[i] = new Er(takim,area.Point[i,0]);
            }
            boluk[4] = new Tegmen(takim, area.Point[4, 0]);
            boluk[5] = new Tegmen(takim, area.Point[5, 0]);
            boluk[6] = new Yuzbasi(takim, area.Point[6, 0]);
            for (int i = 0; i <boluk.Length; i++)
            {
                boluk[i].Area = area;
                boluk[i].Sw = sw;
            }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    boluk[i] = new Er(takim, area.Point[i, 15]);
                }
                boluk[4] = new Tegmen(takim, area.Point[4, 15]);
                boluk[5] = new Tegmen(takim, area.Point[5, 15]);
                boluk[6] = new Yuzbasi(takim, area.Point[6, 15]);
                for (int i = 0; i < boluk.Length; i++)
                {
                    boluk[i].Area = area;
                    boluk[i].Sw = sw;
                }
            }
        }
    }//birlik olusturulur
       
}
