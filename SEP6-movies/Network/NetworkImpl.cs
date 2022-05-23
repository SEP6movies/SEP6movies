using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
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

        private HttpClient client = new HttpClient();
        private Movie _movie = new Movie();
        

        public NetworkImpl()
        {
            connectionString = @"Data Source=35.195.143.0;Initial Catalog=SEP6Movies;User ID=sqlserver;Password=c`H0nsr2DAss|#q4;TrustServerCertificate=True";
            test();
        }

        private async Task test()
        {
            /*
            Actor actor = new Actor();
            Credits credits = new Credits();
            _movie = await getMovieFromApi(1024);
            actor = await getActorFromApi(1017);
            credits = await getCreditsFromApi(1024);

            Console.WriteLine(_movie.original_title);
            Console.WriteLine(actor.name);
            Console.WriteLine(credits.cast.Count);
            */
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

        public async Task<Movie> getMovieFromApi(int movieID)
        {
            Movie movie = new Movie();

            HttpResponseMessage responseMessage = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/"+movieID+"?api_key=088cf42d74dfbb21a6c0d01269bd904a&language=en-US");
            if (responseMessage.IsSuccessStatusCode)
            {
                movie = await responseMessage.Content.ReadAsAsync<Movie>();
            }


            return movie;
        }

        public async Task<Actor> getActorFromApi(int actorID)
        {
            Actor actor = new Actor();
            HttpResponseMessage responseMessage = await client.GetAsync(
                "https://api.themoviedb.org/3/person/"+actorID+"?api_key=088cf42d74dfbb21a6c0d01269bd904a&language=en-US");
            if (responseMessage.IsSuccessStatusCode)
            {
                actor = await responseMessage.Content.ReadAsAsync<Actor>();
            }


            return actor;
        }

        public async Task<Credits> getCreditsFromApi(int movieID)
        {
            Credits credits = new Credits();

            HttpResponseMessage responseMessage = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/"+movieID+"/credits?api_key=088cf42d74dfbb21a6c0d01269bd904a&language=en-US");
            if (responseMessage.IsSuccessStatusCode)
            {
                credits = await responseMessage.Content.ReadAsAsync<Credits>();
            }

            return credits;
        }

        public List<int> getAllMoviesFromDB()
        {
            List<int> movieIds = new List<int>();
            try
            {
               
                rds = new SqlConnection(connectionString);
              
                rds.Open();

                string sql = "select * from dbo.movies";
                

                command = new SqlCommand(sql, rds);
                command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@kage", "test1223");

                command.ExecuteNonQuery();


                /*
                while (dataReader.Read())
                {
                 
                }*/
        
                //dataReader.Close();

                rds.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return movieIds;
        }

        public void apiTest()
        {
            
        }
    }
}