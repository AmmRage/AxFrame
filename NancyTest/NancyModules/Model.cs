using System.Linq;


namespace NancyTest
{
    public class User
    {
        public string Name;
    }

    public class MyModel
    {
        public string Title;
        public string Line1;
        public string Line2;

        public User[] Users;

        public static MyModel Query(string para = "")
        {
            var users = Enumerable.Range(0, 10)
                .Select(i => new User() { Name = "username" + i }).ToArray();

            return new MyModel()
            {
                Title = "a test title",
                Line1 = "test first line",
                Line2 = "test second line",
                Users = new User[0],
            };
        }
    }

    
}