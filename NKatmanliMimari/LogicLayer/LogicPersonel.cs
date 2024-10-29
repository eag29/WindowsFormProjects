using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccesLayer;

namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> LLPersonelListesi()
        {
            return DALPersonel.PersonelListesi();
        }
        public static int LLPersonelAdd(EntityPersonel ep)
        {
            if (ep.Name != "" & ep.Surname != "" & ep.Name.Length >= 3)
            {
                return DALPersonel.PersonelEkle(ep);
            }
            else
            {
                return -1;
            }
        }
        public static bool LLPersonelSil(int per)
        {
            if (per >= 1)
            {
                return DALPersonel.PersonelSil(per);
            }
            else
            {
                return false;
            }
        }
        public static bool LLPersonelGuncelle(EntityPersonel ep)
        {
            if (ep.Name.Length >= 3 & ep.Name!= "")
            {
                return DALPersonel.PersonelGuncelle(ep);
            }
            else
            {
                return false;
            }
        }
    }
}
