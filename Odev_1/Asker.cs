using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Odev_1
{
   
    abstract class Asker  // er , tegmen ve yuzbasinin uretilicegi ust sinif 
    {
        private bool isAlive; // canli olup olmadiklarini tutacak olan degisken  
        private int hp; // canlarini tutucak olan degisken
        private int guc; // guclerini tutucak olan degisken er = 1 tegmen = 2 yuzbasi = 3
        private int takim; // hangi takimda olduklarini tutucak olan degisken 1 ya da 2 
        private StreamWriter sw;
        private Bolge bolge;
        private Meydan meydan;
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
        public Asker(int guc , int takim)
        {
            this.guc = guc;
            this.takim = takim;
        }//Constructor 
        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
            set
            {
                isAlive = value;

            }
        }//get set 
        public int Health
        {
            get{
                return hp;
            }
            set
            {
                hp = value;
            }
        }//get set
        public int Power
        {
            get
            {
                return guc;
            }
        }//get
        public int Team
        {
            get
            {
                return takim;

            }
        }//get
        public Bolge Coor
        {
            get
            {
                return bolge;
            }
            set
            {
                bolge = value;
            }
        }//get set
        public Meydan Area
        {
            set
            {
                meydan = value;
            }
            get
            {
                return meydan;
            }
        }//get set

        abstract public void HareketEt(); // haraket etmelerini saglicak olan metod
        abstract public void AtesEt(); // ates etmelerini saglicak olan metod 
    }
}
