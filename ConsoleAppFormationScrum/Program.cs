using ConsoleAppFormationScrum;
using System;
using System.Text.RegularExpressions;

namespace Sprint0
{
    class Program
    {
        static void Main(string[] args)
        {

            bool finProgram = false;

            do
            {
                Console.Clear();

                Console.WriteLine("1. Encoder un film");
                Console.WriteLine("2. Visualiser/Supprimer un film");
                Console.WriteLine("3. Consulter la météo");
                Console.WriteLine("4. Accéder à la calculatrice");
                Console.WriteLine("5. Se connecter en tant qu'Admin");
                Console.WriteLine("6. Quitter le programme");

                Console.Write("Votre choix : ");
                string menuFilm = Console.ReadLine();

                switch (menuFilm)
                {
                    case "1":
                        Film.encodageFilm();
                        break;
                    case "2":
                        Film.afficherFilm();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":

                        Connection();
                        break;
                    case "6":
                        finProgram = true;
                        break;
                }

            } while (!finProgram);
        }

        static void Connection()
        {
            string login, password;

            try
            {
                Console.WriteLine("--------------Connection admin------------------\n");


                Console.WriteLine("Entrer votre login");
                login = Console.ReadLine();

                bool end = false;

                do
                {
                    Console.WriteLine("Entrer votre password");
                    password = Console.ReadLine();


                    var hasNumber = new Regex(@"[0-9]+");
                    var hasUpperChar = new Regex(@"[A-Z]+");
                    var hasMiniMaxChars = new Regex(@".{16,}");
                    var hasLowerChar = new Regex(@"[a-z]+");
                    var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                    if (!hasLowerChar.IsMatch(password))
                    {
                        Console.WriteLine("Password doit contenir au moins une minuscule");

                    }
                    else if (!hasUpperChar.IsMatch(password))
                    {
                        Console.WriteLine("Password doit contenir au moins une majuscule");

                    }
                    else if (!hasMiniMaxChars.IsMatch(password))
                    {
                        Console.WriteLine("Password doit contenir au moins 16 characters");

                    }
                    else if (!hasNumber.IsMatch(password))
                    {
                        Console.WriteLine("Password doit contenir au moins un chiffre");

                    }

                    else if (!hasSymbols.IsMatch(password))
                    {
                        Console.WriteLine("Password doit contenir au moins un caractère spécial");

                    }
                    else
                    {
                        Console.WriteLine("Confirmez votre mot de passe");

                        string passwordConfirm = Console.ReadLine();

                        if (password != passwordConfirm)
                        {
                            Console.WriteLine("Désoler vous allez devoir recommencer");
                        }
                        else
                        {
                            Console.WriteLine("Bravo vous êtes connecté");
                            end = true;
                        }
                    }
                } while (!end);



            }
            catch (FormatException e)
            {
                Console.WriteLine("Erreur : ", e);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Erreur : ", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : ", e);
            }


        }
    }
}












