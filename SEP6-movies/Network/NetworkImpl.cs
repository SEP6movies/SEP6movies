using System;
using Microsoft.Data.SqlClient;
using test_shit.Data;

namespace test_shit.Network
{
    public class NetworkImpl
    {
        private SqlConnection rds;
        private SqlCommand command;
        private SqlDataReader dataReader;

        private string connectionString;


        public NetworkImpl()
        {
            connectionString = @"Data Source=35.195.143.0;Initial Catalog=SEP6Movies;User ID=sqlserver;Password=c`H0nsr2DAss|#q4;TrustServerCertificate=True";
        }


        public User getUser()
        {
            User user = new User();
            try
            {
               
                rds = new SqlConnection(connectionString);
              
                rds.Open();

                string sql = "insert into dbo.TestTable values(@date,@kage)";
                

                command = new SqlCommand(sql, rds);
                command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@kage", "test1223");

                command.ExecuteNonQuery();


                /*
                while (dataReader.Read())
                {
                    woocommerce = new Woocommerce();
                    woocommerce.email = dataReader.GetString(0);
                    woocommerce.category = dataReader.GetString(1);
                    woocommerce.orderNo = dataReader.GetString(2);
                    woocommerce.leanOrderIdent = dataReader.GetString(3);
                    woocommerce.orderText = dataReader.GetString(4);
                    woocommerce.name = dataReader.GetString(5);
                    woocommerce.status = "Offer";
                    woocommerces.Add(woocommerce);
                }*/
        
                //dataReader.Close();

                rds.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }


            return user;
        }
    }
}