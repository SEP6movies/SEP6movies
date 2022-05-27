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
            Console.WriteLine("frima");
           
        }

        private async Task test()
        {
            
            Console.WriteLine("her");
            Actor actor = new Actor();
            Credits credits = new Credits();
            PopularActors popularActors = new PopularActors();
            popularActors = await getPopularActors();
            Console.WriteLine(popularActors.results[0].name);
            _movie = await getMovieFromApi(15724);
            actor = await getActorFromApi(108);
            credits = await getCreditsFromApi(1024);

            Console.WriteLine(_movie.original_title + " Movie");
            Console.WriteLine(actor.name);
            Console.WriteLine(credits.cast.Count);
            

            TopRated moviesz = new TopRated();
            moviesz = await getMovieBasedOnGenreFromApi(28);
            
            Console.WriteLine(moviesz.results[0].poster_path + " this");
            
            
            List<Movie> movies = new List<Movie>();
            movies = await getAllMovies();
            Console.WriteLine(movies[0].id + "asdsasajfa");
            Console.WriteLine("tasda");
            

        }


        public bool checkForUser(string first,string pass)
        {
            bool exits = false;
            try
            {
               
                rds = new SqlConnection(connectionString);
              
                rds.Open();

                string sql = "select * from dbo.users where (username=@user or email=@email) and password=@pass";
                

                command = new SqlCommand(sql, rds);
                command.Parameters.AddWithValue("@user", first);
                command.Parameters.AddWithValue("@email",first);
                command.Parameters.AddWithValue("@pass", pass);

                dataReader = command.ExecuteReader();


                
                while (dataReader.Read())
                {
                    exits = true;
                }
        
                dataReader.Close();

                rds.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }


            return exits;
        }

        public async Task<Movie> getMovieFromApi(int movieID)
        {
            Movie movie = new Movie();
            try
            {
             
                string trueMovieID = "";
                trueMovieID = calculateTrueID(movieID);
                HttpResponseMessage responseMessage = await client.GetAsync(
                    "https://api.themoviedb.org/3/movie/tt"+trueMovieID+"?api_key=088cf42d74dfbb21a6c0d01269bd904a&language=en-US");
                if (responseMessage.IsSuccessStatusCode)
                {
                    movie = await responseMessage.Content.ReadAsAsync<Movie>();
                    movie.poster_path = "https://image.tmdb.org/t/p/original" + movie.poster_path;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            


            return movie;
        }

        public async Task<Movie> getMovieFromApiWithApiIds(int ids)
        {
            //Api has their own id system different from imdb id system
            Movie movie = new Movie();
            try
            {
             
              
                HttpResponseMessage responseMessage = await client.GetAsync(
                    "https://api.themoviedb.org/3/movie/"+ids+"?api_key=088cf42d74dfbb21a6c0d01269bd904a&language=en-US");
                if (responseMessage.IsSuccessStatusCode)
                {
                    movie = await responseMessage.Content.ReadAsAsync<Movie>();
                    movie.poster_path = "https://image.tmdb.org/t/p/original" + movie.poster_path;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            


            return movie;
        }

        public async Task<List<Movie>> getAllMovies()
        {
            List<Movie> movies = new List<Movie>();
            List<int> movieIds = new List<int>();
            movieIds = getAllMoviesFromDB();
            for (int i = 0; i < movieIds.Count; i++)
            {
                movies.Add(await getMovieFromApi(movieIds[i]));
                Console.WriteLine(i);
            }

            return movies;
        }
        
        public async Task<Actor> getActorFromApiWithImdbID(int actorID)
        {
            FindActorByID personResult = new FindActorByID();
            string trueActorID = calculateTrueID(actorID);
            
            HttpResponseMessage responseMessage1 = await client.GetAsync(
                "https://api.themoviedb.org/3/find/nm"+trueActorID+"?api_key=088cf42d74dfbb21a6c0d01269bd904a&language=en-US&external_source=imdb_id");
            if (responseMessage1.IsSuccessStatusCode)
            {
                personResult = await responseMessage1.Content.ReadAsAsync<FindActorByID>();
            }
            
            Actor actor = new Actor();
            HttpResponseMessage responseMessage = await client.GetAsync(
                "https://api.themoviedb.org/3/person/"+personResult.person_results[0].id+"?api_key=088cf42d74dfbb21a6c0d01269bd904a&language=en-US");
            if (responseMessage.IsSuccessStatusCode)
            {
                actor = await responseMessage.Content.ReadAsAsync<Actor>();
            }


            return actor;
        }
        public async Task<Actor> getActorFromApi(int actorID)
        {
           //The ID that tmdb uses is different from imdb so therefore this method should only be used if the actorID
           //comes from one of the other methods such as getCredits
            Actor actor = new Actor();
            HttpResponseMessage responseMessage = await client.GetAsync(
                "https://api.themoviedb.org/3/person/"+actorID+"?api_key=088cf42d74dfbb21a6c0d01269bd904a&language=en-US");
            if (responseMessage.IsSuccessStatusCode)
            {
                actor = await responseMessage.Content.ReadAsAsync<Actor>();
                actor.profile_path = "https://image.tmdb.org/t/p/original" + actor.profile_path;
            }


            return actor;
        }

        private string calculateTrueID(int ID)
        {
            string trueID = "";
            string temp = ID.ToString();
            bool digits = true;
            while (digits)
            {
                if (temp.Length >= 7)
                {
                    digits = false;
                }

                if (temp.Length < 7)
                {
                    temp = "0" + temp;
                }

            }

            trueID = temp;

            return trueID;
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

            for (int i = 0; i < credits.cast.Count; i++)
            {
                credits.cast[i].profile_path = "https://image.tmdb.org/t/p/original" + credits.cast[i].profile_path;
            }

            for (int i = 0; i < credits.crew.Count; i++)
            {
                credits.crew[i].profile_path = "https://image.tmdb.org/t/p/original" + credits.crew[i].profile_path;
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
                

                dataReader = command.ExecuteReader();


                
                while (dataReader.Read())
                {
                 movieIds.Add(dataReader.GetInt32(0));
                }
        
                dataReader.Close();

                rds.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return movieIds;
        }

        public List<int> getFavorites(int userID)
        {
            List<int> movieFavoritesIDs = new List<int>();
            try
            {
               
                rds = new SqlConnection(connectionString);
              
                rds.Open();

                string sql = "select MovieId from dbo.Favorites where UserId=@user";
                

                command = new SqlCommand(sql, rds);
                command.Parameters.AddWithValue("@user",userID);
                

                dataReader = command.ExecuteReader();


                
                while (dataReader.Read())
                {
                    movieFavoritesIDs.Add(dataReader.GetInt32(0));
                }
        
                dataReader.Close();

                rds.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }



            return movieFavoritesIDs;
        }

        public async Task<PopularActors> getPopularActors()
        {
            PopularActors popularActors = new PopularActors();
            HttpResponseMessage responseMessage = await client.GetAsync(
                "https://api.themoviedb.org/3/person/popular?api_key=088cf42d74dfbb21a6c0d01269bd904a&language=en-US&page=1");
            if (responseMessage.IsSuccessStatusCode)
            {
               popularActors = await responseMessage.Content.ReadAsAsync<PopularActors>();
            }

            for (int i = 0; i < popularActors.results.Count; i++)
            {
                popularActors.results[i].profile_path =
                    "https://image.tmdb.org/t/p/original" + popularActors.results[i].profile_path;
            }

            return popularActors;
        }

        public void addMovieToFavorites(int userId,int movieId)
        {
            try
            {

                rds = new SqlConnection(connectionString);

                rds.Open();

                string sql = "insert into dbo.Favorites values(@user,@movie)";


                command = new SqlCommand(sql, rds);
                command.Parameters.AddWithValue("@user", userId);
                command.Parameters.AddWithValue("@movie", movieId);


                command.ExecuteNonQuery();




                rds.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void addUserToDB(User user)
        {
            try
            {

                rds = new SqlConnection(connectionString);

                rds.Open();

                string sql = "insert into dbo.Users(username,password,email) values(@user,@pass,@email)";


                command = new SqlCommand(sql, rds);
                command.Parameters.AddWithValue("@user", user.username);
                command.Parameters.AddWithValue("@pass", user.password);
                command.Parameters.AddWithValue("@email", user.email);


                command.ExecuteNonQuery();




                rds.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public async Task<TopRated> getTopRatedMoviesFromApi()
        {
            TopRated movies = new TopRated();
            
            HttpResponseMessage responseMessage = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/top_rated?api_key=088cf42d74dfbb21a6c0d01269bd904a&language=en-US&page=1");
            if (responseMessage.IsSuccessStatusCode)
            {
                movies = await responseMessage.Content.ReadAsAsync<TopRated>();
                
            }

            for (int i = 0; i < movies.results.Count; i++)
            {
                movies.results[i].poster_path = "https://image.tmdb.org/t/p/original" + movies.results[i].poster_path;
            }
           
            return movies;
        }

        public async Task<TopRated> getMovieBasedOnGenreFromApi(int genreID)
        {
            TopRated movies = new TopRated();
            
            HttpResponseMessage responseMessage = await client.GetAsync(
                "https://api.themoviedb.org/3/discover/movie?api_key=088cf42d74dfbb21a6c0d01269bd904a&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&with_genres="+genreID+"&with_watch_monetization_types=flatrate");
            if (responseMessage.IsSuccessStatusCode)
            {
                movies = await responseMessage.Content.ReadAsAsync<TopRated>();
                
            }

            for (int i = 0; i < movies.results.Count; i++)
            {
                movies.results[i].poster_path = "https://image.tmdb.org/t/p/original" + movies.results[i].poster_path;
            }
           
            return movies;
        }

        public void addMovieToDB(Movie movie)
        {
            try
            {

                rds = new SqlConnection(connectionString);

                rds.Open();

                string sql = "insert into dbo.movies values(@id,@title,@year)";

                int year = int.Parse(movie.release_date.Substring(0, 4));
                command = new SqlCommand(sql, rds);
                command.Parameters.AddWithValue("@id", movie.id);
                command.Parameters.AddWithValue("@title", movie.original_title);
                command.Parameters.AddWithValue("@year", year);


                command.ExecuteNonQuery();




                rds.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        
    }
}