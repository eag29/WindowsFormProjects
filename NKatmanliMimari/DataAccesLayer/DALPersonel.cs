using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccesLayer
{
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();

            SqlCommand komut = new SqlCommand("Select * from TBLBILGI", Baglanti.bgl);

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();

                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Name = dr["AD"].ToString();
                ent.Surname = dr["SOYAD"].ToString();
                ent.Country = dr["SEHIR"].ToString();
                ent.Job = dr["GOREV"].ToString();
                ent.Maas = short.Parse(dr["MAAS"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }
        public static int PersonelEkle(EntityPersonel ep)
        {
            SqlCommand komut = new SqlCommand("insert into TBLBILGI (AD,SOYAD,SEHIR,GOREV,MAAS) VALUES (@P1,@P2,@P3,@P4,@P5)", Baglanti.bgl);

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            komut.Parameters.AddWithValue("@P1", ep.Name);
            komut.Parameters.AddWithValue("@P2", ep.Surname);
            komut.Parameters.AddWithValue("@P3", ep.Country);
            komut.Parameters.AddWithValue("@P4", ep.Job);
            komut.Parameters.AddWithValue("@P5", ep.Maas);
            return komut.ExecuteNonQuery();
        }
        public static bool PersonelSil(int p)
        {
            SqlCommand komut = new SqlCommand("Delete from TBLBILGI where ID=@p1", Baglanti.bgl);

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            komut.Parameters.AddWithValue("@p1", p);

            return komut.ExecuteNonQuery() > 0;
        }
        public static bool PersonelGuncelle(EntityPersonel ep)
        {
            SqlCommand komut = new SqlCommand("Update TBLBILGI set AD=@P1, SOYAD=@P2, MAAS=@P3, SEHIR=@P4, GOREV=@P5 WHERE ID=@P6", Baglanti.bgl);

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            komut.Parameters.AddWithValue("@P1", ep.Name);
            komut.Parameters.AddWithValue("@P2", ep.Surname);
            komut.Parameters.AddWithValue("@P3", ep.Country);
            komut.Parameters.AddWithValue("@P4", ep.Job);
            komut.Parameters.AddWithValue("@P5", ep.Maas);
            return komut.ExecuteNonQuery() > 0;
        }
    }
}
