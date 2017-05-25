using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA2
{
    class mobil
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }

        public static List<mobil> GetStudenysFromDatabases()
        {
            List<mobil> resul = new List<mobil>();
            using (SqlConnection cn = new SqlConnection("Server=DESKTOP-9JO2CCN\\SQLEXPRESS;Database=PhoneBases;Trusted_Connection=True"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM mobil", cn);
                var mobilReader = cmd.ExecuteReader();
                while (mobilReader.Read())
                {
                    mobil s = new mobil();
                    s.ID = (int)mobilReader["ID"];
                    s.Name = (String)mobilReader["Name"];
                    s.Price = (int)mobilReader["Price"];
                    s.Number = (int)mobilReader["Number"];

                    resul.Add(s);
                }
            }
            return resul;
        }
    }
}
