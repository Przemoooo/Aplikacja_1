using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metody
{
     public class User
    {
       // public static string GameName = "Diablo";   //zmienne statyczne

        private List<int> score = new List<int>();
        public User(string login, string password)     //2 para konstruktor

        {
            this.Login = login;
            this.Password = password;
            //this.score = 0;

        }
        //mechanizm property
        public string Login { get; private set; } //set wpisywanie get odczytywanie

        public string Password { get; private set; }

        public int Result
        {
            get
            {
                //return 0;
                return this.score.Sum();
            }
        }

        //metoda publiczna
        public void AddScore(int number)
        {

            //this.score = this.score + number;
            //this.score += number;              // to samo
            this.score.Add(number);
           // number += number; 


        }

       
    }
}
