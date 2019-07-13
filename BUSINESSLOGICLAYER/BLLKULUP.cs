using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ENTITYLAYER;
using FACADELAYER;

namespace BUSINESSLOGICLAYER
{
    public class BLLKULUP
    {
        public static int EKLE(ENTITYOGRENCIKULUP deger)
        {
            if (deger.KULUPAD != null)
                return FACADEKULUP.EKLE(deger);
            else
                return -1;
        }

        public static bool GUNCELLE(ENTITYOGRENCIKULUP deger)
        {
            if (deger.KULUPAD != null && deger.KULUPID != null)
                return FACADEKULUP.GUNCELLE(deger);
            else
                return false;
        }

        public static bool SIL(int deger)
        {
            if (deger != null)
                return FACADEKULUP.SIL(deger);
            else
                return false;
        }

        public static List<ENTITYOGRENCIKULUP> LISTELE()
        {
            return FACADEKULUP.KULUPLISTESI();
        }
    }
}
