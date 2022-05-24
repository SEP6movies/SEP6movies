namespace test_shit.Data
{
    public class User
    {
        public int id { get; set; }
        
        public string email { get; set; }
        public string username { get; set; }
        
        public string password { get; set; }

        public User()
        {
            
        }
        public User(string username,string password)
        {
            username = username;
            password = password;
        }
    }
}