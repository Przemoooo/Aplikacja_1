User user1 = new User("Adam", "324324fdgfdg"); ///obiekty 1 konstruktor
User user2 = new User("Przemo","324324324fh"); //2  parametry
User user3 = new User("Damian", "324324fdsd");  //2 parametry
User user4 = new User("Zuzia","324324fdrgfd");  //parametry

//user1.Login = "Przemo"; //-propercja
var name = user1.Login; //odczytywanie zmiennych

//user2.login = "Michal";
//user3.login = "Patryk";

//parametry klasy ponizej
class User

{
   // private string login;    //public zeby dostać się do user1.login na zewnatrz
    private string password; //privte sposoby ustawienia danych w klasie
    //private string name;



    //konstruktor dodatkowe miejsce jest wywoływany gdy tworzysz obiekt
    //automatycznie wywołany

    public User(string login, string password)     //2 para konstruktor

    {
        this.Login = login;
        this.Password = password;
        // this.name = "_";

    }
    //mechanizm property
    public string Login { get; private set; } //set wpisywanie get odczytywanie

    public string Password { get; private set; }
}

