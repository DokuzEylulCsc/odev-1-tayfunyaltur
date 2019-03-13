using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Bolge
    {
        private int x;
        private int y;
        public int X // bolgelerin x ve y konumlari olusturulduktan sonra bir daha set edilemicek sadece get edilebilicektir
        {
            get
            {
                return x;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
        }
        public Bolge(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
