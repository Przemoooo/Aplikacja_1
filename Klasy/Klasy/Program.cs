//Klasy to takie struktury z danymi
//Obiekty instancje 'new' User z klasą struktur danych
//user 1,2,3 korzystają z klasy User
//protectoion level - indentyfikatory

User user1 = new User(); ///obiekty 1 konstruktor
User user2 = new User("Przemo"); //2 konstruktor 1 parametr
User user3 = new User("Damian","");  //3 konstruktor
User user4 = new User("Zuzia");

//user1.login = "Przemo";
//user2.login = "Michal";
//user3.login = "Patryk";

//parametry klasy ponizej
class User

{
    private string login;    //public zeby dostać się do user1.login na zewnatrz
    private string password; //privte sposoby ustawienia danych w klasie
    private string name;



    //konstruktor dodatkowe miejsce jest wywoływany gdy tworzysz obiekt
    //automatycznie wywołany

    public User()     //1 konstruktor

    {
        this.login = "_";
        this.password = "_";
        this.name = "_";

    }

    public User(string login)  // 2 komnstruktor parametr
    {
        this.login = login;    // co przychodzi z konstruktora zapisujesz do zmiennej private login, dzieki this
                               // this.login = password;
        this.password = "_";
        this.name = "_";
    }

    public User(string login, string password)  //3 konstruktor 2 parametry
    {
        this.login = login;    // co przychodzi z konstruktora zapisujesz do zmiennej private login, dzieki this
                               // this.login = password;
        this.password = password;
        //this.name = "_";
    }

}
