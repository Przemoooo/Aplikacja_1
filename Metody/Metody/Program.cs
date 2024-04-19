using Metody;

User user1 = new User("Adam", "324324fdgfdg"); ///obiekty 1 konstruktor
User user2 = new User("Przemo", "324324324fh"); //2  parametry
User user3 = new User("Damian", "324324fdsd");  //2 parametry

user1.AddScore(5);
user1.AddScore(2);
user1.AddScore(9);

user2.AddScore(5);
user2.AddScore(2);
user2.AddScore(2);

user3.AddScore(5);
user3.AddScore(2);
user3.AddScore(3);

//var result = user1.Result;
//Console.WriteLine(result);
//var name = User.GameName;
//var pi = Math.PI;

List<User> users = new List<User>()
{
    user1, user2, user3
};

int maxResault = -1;
User userWithMaxResault = null;

foreach (var user in users)

{
    if (user.Result > maxResault)
    {
        maxResault = user.Result;
        userWithMaxResault = user;

    }
}

if (userWithMaxResault != null)
{

    Console.WriteLine(userWithMaxResault.Login);
    Console.WriteLine(maxResault); 
   

}