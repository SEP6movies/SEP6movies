using System.Collections.Generic;

namespace test_shit.Data
{
    public class FindActorByID
    {
        public List<MovieResult> movie_results { get; set; }
        public List<PersonResult> person_results { get; set; }
        public List<TvResult> tv_results { get; set; }
        public List<TvEpisodeResult> tv_episode_results { get; set; }
        public List<TvSeasonResult> tv_season_results { get; set; }
        public class PersonResult
        {
            public List<KnownFor> known_for { get; set; }
            public int gender { get; set; }
            public string profile_path { get; set; }
            public bool adult { get; set; }
            public string name { get; set; }
            public string known_for_department { get; set; }
            public int id { get; set; }
            public double popularity { get; set; }
        }
        public class KnownFor
        {
            public string backdrop_path { get; set; }
            public string media_type = "movie";
            public List<double> genre_ids { get; set; }
            public string original_language { get; set; }
            public string original_title { get; set; }
            public string poster_path { get; set; }
            public double id { get; set; }
            public bool video { get; set; }
            public double vote_average { get; set; }
            public double popularity { get; set; }
            public double vote_count { get; set; }
            public string release_date { get; set; }
            public string overview { get; set; }
            public string title { get; set; }
            public bool adult { get; set; }
        }
        public class MovieResult
        {
            public int id { get; set; }
            public bool video { get; set; }
            public int vote_count { get; set; }
            public double vote_average { get; set; }
            public string title { get; set; }
            public string release_date { get; set; }
            public string original_language { get; set; }
            public string original_title { get; set; }
            public List<object> genre_ids { get; set; }
            public object backdrop_path { get; set; }
            public bool adult { get; set; }
            public string overview { get; set; }
            public object poster_path { get; set; }
            public double popularity { get; set; }
        }
        public class TvResult
        {
            public int id { get; set; }
            public string overview { get; set; }
            public string original_name { get; set; }
            public string first_air_date { get; set; }
            public string backdrop_path { get; set; }
            public List<int> genre_ids { get; set; }
            public string original_language { get; set; }
            public int vote_count { get; set; }
            public string name { get; set; }
            public List<string> origin_country { get; set; }
            public string poster_path { get; set; }
            public double vote_average { get; set; }
            public double popularity { get; set; }
        }
        public class TvEpisodeResult
        {
            public string air_date { get; set; }
            public int episode_number { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string overview { get; set; }
            public string production_code { get; set; }
            public int season_number { get; set; }
            public int show_id { get; set; }
            public string still_path { get; set; }
            public double vote_average { get; set; }
            public int vote_count { get; set; }
        }

        public class TvSeasonResult
        {
            
        }
    }
}