using System;
using System.Collections.Generic;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {

            int pintries = 4;
            bool loginBool = true;
            while (loginBool == true)
            {
                Console.WriteLine("Välkommen till Swedbank! Var god skriv in ditt användarnamn följt av pinkod för att logga in");
                string username = Console.ReadLine();
                string password = Console.ReadLine();
                //Kollar om användarnamn och lösen stämmer
                if (!CheckLogin(username, password))
                {

                    Console.WriteLine("Misslyckad inloggning, försök igen");
                    Console.WriteLine();



                    pintries--;
                    if (pintries == 1)
                    {
                        Console.Write("Du är bannad från Swedbank");
                        Console.ReadLine();
                        loginBool = false;
                        Console.Clear();
                    }
                }
                else if (CheckLogin(username, password))
                {
                    Console.WriteLine("Du är inloggad");
                    loginBool = false;
                }
            }



            while (loginBool == false)
            {

                decimal[] balance = new decimal[2];
                balance[1] = 20000; //Sparkonto
                balance[0] = 10000; //Lönekonto               
                Console.WriteLine("Välkommen!");
                Console.WriteLine("[1]. Se dina konton och saldo");
                Console.WriteLine("[2]. Överföring mellan konton");
                Console.WriteLine("[3]. Ta ut pengar");
                Console.WriteLine("[4]. Logga ut");


                int menu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Sparkonto : " + balance[1]);
                        Console.WriteLine("Lönekonto : " + balance[0]);
                        Console.ReadLine();
                        break;

                    case 2:
                        Transfer();

                        break;
                    case 3:
                        Withdraw();
                        break;
                    case 4:
                        logout();


                        break;
                    default:
                        Console.WriteLine("Ogiltigt val");
                        break;
                }
            }


        }
        static void logout()
        {
            string[] dump = new string[1];

            Main(dump);
        }


        //Metod för att kolla användare och lösenord
        static bool CheckLogin(string username, string password)
        {

            string[,] users = new string[5, 2];
            //First user
            users[0, 0] = "Admin"; //set Username
            users[0, 1] = "1234"; //set Password

            //Second user
            users[1, 0] = "Tobias";
            users[1, 1] = "1235";

            //Third user
            users[2, 0] = "Anas";
            users[2, 1] = "1236";

            //Fourth user
            users[3, 0] = "Edwin";
            users[3, 1] = "1237";

            //Fifth user
            users[4, 0] = "Carl Gustaf";
            users[4, 1] = "1337";

            //Check username and password, returning true if successful
            if (username == users[0, 0] && password == users[0, 1])
            {
                return true;
            }
            else if (username == users[1, 0] && password == users[1, 1])
            {
                return true;
            }
            else if (username == users[2, 0] && password == users[2, 1])
            {
                return true;
            }
            else if (username == users[3, 0] && password == users[3, 1])
            {
                return true;
            }
            else if (username == users[4, 0] && password == users[4, 1])
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        //Metod för uttag
        static void Withdraw()
        {
            decimal[] balance = new decimal[2];
            balance[1] = 20000; //Sparkonto
            balance[0] = 10000; //Lönekonto 
            int[] pins = new int[5];
            pins[0] = 1234;
            pins[1] = 1235;
            pins[2] = 1236;
            pins[3] = 1237;
            pins[4] = 1337;

            Console.WriteLine("Skriv in din pinkod för att göra ett uttag");
            int checkpin = Convert.ToInt32(Console.ReadLine());
            if (checkpin == pins[0] || checkpin == pins[1] || checkpin == pins[2] || checkpin == pins[3] || checkpin == pins[4])
            {
                Console.WriteLine("Vilket konto vill du ta ut pengar ifrån?");
                Console.WriteLine("Sparkonto : " + balance[1]);
                Console.WriteLine("Lönekonto : " + balance[0]);
                int chooseAccount = Convert.ToInt32(Console.ReadLine());


                if (chooseAccount == 1)
                {
                    Console.WriteLine("Hur mycket vill du ta ut?");
                    int withdrawSpendings = Convert.ToInt32(Console.ReadLine());
                    if (withdrawSpendings > balance[1])
                    {

                        Console.WriteLine("Du kan inte ta ut så mycket pengar");
                    }
                    else if (withdrawSpendings <= balance[1])
                    {
                        balance[1] = balance[1] - withdrawSpendings;
                        Console.WriteLine("Sparkonto : " + balance[1]);
                        Console.WriteLine("Lönekonto :" + balance[0]);

                    }

                }
                else if (chooseAccount == 2)
                {
                    Console.WriteLine("Hur mycket vill du ta ut?");
                    int withdrawSavings = Convert.ToInt32(Console.ReadLine());
                    if (withdrawSavings > balance[0])
                    {

                        Console.WriteLine("Du kan inte ta ut så mycket pengar");
                    }
                    else if (withdrawSavings <= balance[0])
                    {
                        balance[0] = balance[0] - withdrawSavings;
                        Console.WriteLine("Sparkonto : " + balance[1]);
                        Console.WriteLine("Lönekonto :" + balance[0]);

                    }


                }

                else
                {
                    Console.WriteLine("Fel pinkod");
                    Console.ReadLine();
                }
            }



        }

        //Metod för överföring mellan konton
        static void Transfer()
        {
            decimal[] balance = new decimal[2];
            balance[1] = 20000; //Sparkonto
            balance[0] = 10000; //Lönekonto
            Console.WriteLine("Från vilket konto vill du föra över pengar?");
            Console.WriteLine("[1] Sparkonto : " + balance[1]);
            Console.WriteLine("[2] Lönekonto : " + balance[0]);
            int transferchoise = Convert.ToInt32(Console.ReadLine());
            if (transferchoise == 1)
            {
                Console.WriteLine("Hur mycket pengar vill du föra över?");
                int transferBalance = Convert.ToInt32(Console.ReadLine());
                Console.Clear();



                if (transferBalance <= balance[1])
                {
                    balance[1] = balance[1] - transferBalance;
                    balance[0] = balance[0] + transferBalance;
                    Console.WriteLine("Lyckad överföring");
                    Console.WriteLine();
                    Console.WriteLine("Sparkonto : " + balance[1]);
                    Console.WriteLine("Lönekonto : " + balance[0]);
                    Console.ReadLine();

                }
                else if (transferBalance > balance[1])
                {
                    Console.WriteLine("Du har inte tillräckligt med pengar");
                    Console.ReadLine();
                }

            }
            else if (transferchoise == 2)
            {
                Console.WriteLine("Hur mycket pengar vill du föra över?");
                int transferBalance = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (transferBalance <= balance[0])
                {
                    balance[0] = balance[0] - transferBalance;
                    balance[1] = balance[1] + transferBalance;
                    Console.WriteLine("Lyckad överföring");
                    Console.WriteLine();
                    Console.WriteLine("Sparkonto : " + balance[1]);
                    Console.WriteLine("Lönekonto : " + balance[0]);
                    Console.ReadLine();
                }
                else if (transferBalance > balance[0])
                {
                    Console.WriteLine("Du har inte tillräckligt med pengar");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Gör ett val mellan 1 och 2");
            }

        }

    }

}


