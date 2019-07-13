using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITYLAYER;
using FACADELAYER;

namespace BUSINESSLOGICLAYER
{
    public class BLLOGRENCI
    {
        public static int EKLE(ENTITYOGRENCI deger)
        {
            if (deger.AD != null && deger.SOYAD != null && deger.KULUPID != null && deger.FOTOGRAF != null && deger.FOTOGRAF.Length > 0 && deger.KULUPID > 0)
                return FACADEOGRENCI.EKLE(deger);
            else
                return -1;
        }

        public static bool GUNCELLE(ENTITYOGRENCI deger)
        {
            if (deger.AD != null && deger.SOYAD != null && deger.KULUPID != null && deger.FOTOGRAF != null && deger.FOTOGRAF.Length > 0 && deger.KULUPID > 0)
                return FACADEOGRENCI.GUNCELLE(deger);
            else
                return false;
        }

        public static bool SIL(int deger)
        {
            if (deger != null && deger > 0)
                return FACADEOGRENCI.SIL(deger);
            return false;
        }

        public static List<ENTITYOGRENCI> LISTELE()
        {
            return FACADEOGRENCI.OGRENCILISTESI();
        }
    }
}
