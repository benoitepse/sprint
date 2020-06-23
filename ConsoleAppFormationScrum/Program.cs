using ConsoleAppFormationScrum;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;




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

        // --------------------US 7--------------------------
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
                        Console.Clear();
                        Console.WriteLine("Confirmez votre mot de passe");

                        string passwordConfirm = Console.ReadLine();

                        if (password != passwordConfirm)
                        {
                            Console.WriteLine("Désoler vous allez devoir recommencer");
                        }
                        else
                        {
                            Console.WriteLine("Bravo vous êtes connecté");
                            string hashedData = ComputeSha256Hash(password);
                            Console.WriteLine("Votre mot de passe hashé : {0}", hashedData);
                            Console.ReadKey();


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

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // -------------------- End US 7--------------------------


    }
}












