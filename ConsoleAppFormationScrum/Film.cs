using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleAppFormationScrum
{
    [Serializable]
    public class Film
    {
        [XmlAttribute()]
        public string titre { get; set; }

        [XmlAttribute()]
        public int annee { get; set; }

        [XmlAttribute()]
        public string realisateur { get; set; }

        [XmlAttribute()]
        public int note { get; set; }

        [XmlAttribute()]
        public string critique { get; set; }



        public static void encodageFilm()
        {

            if (!File.Exists("films.xml"))
            {
                StreamWriter sw = File.CreateText("films.xml");
                sw.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
                sw.WriteLine(@"<films>");
                sw.WriteLine(@"</films>");
                sw.Close();
            }

            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "films";


            XmlSerializer serializer = new XmlSerializer(typeof(List<Film>), xRoot);
            StreamReader reader = new StreamReader("films.xml");
            List<Film> listFilm = (List<Film>)serializer.Deserialize(reader);
            reader.Close();

            Film f = new Film();

            Console.WriteLine("Titre du Film :");
            f.titre = Console.ReadLine();

            Console.WriteLine("Année de Production :");
            int annee;
            while (!int.TryParse(Console.ReadLine(), out annee))
            {
                Console.WriteLine("-> Entrez un nombre ");
            }
            f.annee = annee;



            Console.WriteLine("Nom du Réalisateur :");
            f.realisateur = Console.ReadLine();

            
            Console.WriteLine("Votre Note  : ");
            int note;
            while (!int.TryParse(Console.ReadLine(), out note))
            {
                Console.WriteLine("-> Entrez un chiffre entier ");
            }
            f.note = note;
            
            

            do 
            {
                Console.WriteLine("Votre Critique :  (entre 100 et 1000 caractères)");
                f.critique = Console.ReadLine(); 
            }  
            while (f.critique.Length > 1000 || f.critique.Length < 100);

            listFilm.Add(f);


            var writer = new StreamWriter("films.xml", false);

            serializer.Serialize(writer, listFilm);

            writer.Close();
        }







        public static void afficherFilm()
        {
            if (!File.Exists("films.xml"))
            {
                StreamWriter sw = File.CreateText("films.xml");
                sw.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
                sw.WriteLine(@"<films>");
                sw.WriteLine(@"</films>");
                sw.Close();
            }

            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "films";

            XmlSerializer serializer = new XmlSerializer(typeof(List<Film>), xRoot);
            StreamReader reader = new StreamReader("films.xml");
            List<Film> listFilm = (List<Film>)serializer.Deserialize(reader);
            reader.Close();

            int numerofilm = -1;
            do
            {
                if (listFilm.Any())
                {
                    Console.Clear();

                    Console.WriteLine(" ----- Liste des Films ----- ");
                    foreach (var Film in listFilm)
                    {
                        Console.WriteLine($"{listFilm.IndexOf(Film) + 1}. {Film.titre} ( {Film.annee} ) ");
                    }
                    

                    while (numerofilm < 0 || numerofilm > listFilm.Count)
                    {
                        Console.WriteLine(" -> Quelle film voulez-vous visualiser ?");
                        Console.WriteLine(" -> tapez 0 pour quitter ");
                        int.TryParse(Console.ReadLine(), out numerofilm);
                    }
                    
                    if (numerofilm < 0 || numerofilm > listFilm.Count) { 
                        Console.Clear();
                        Console.WriteLine(" ----- " + listFilm[numerofilm - 1].titre + " ----- ");
                        Console.WriteLine(" Année:       " + listFilm[numerofilm - 1].annee);
                        Console.WriteLine(" Réalisateur: " + listFilm[numerofilm - 1].realisateur);
                        Console.WriteLine(" Note:        " + listFilm[numerofilm - 1].note);
                        Console.WriteLine(" Critique:    " + listFilm[numerofilm - 1].critique);

                        int numero = -1;
                        while (numero < 0 || numero > listFilm.Count)
                        {
                            Console.WriteLine(" -> Que Voulez-vous faire ? 0 pour quitter et 1 pour supprimer le film ");
                            int.TryParse(Console.ReadLine(), out numero);

                            if (numero == 1) 
                            {
                                listFilm.RemoveAt(numerofilm - 1);
                        
                                var writer = new StreamWriter("films.xml", false);

                                serializer.Serialize(writer, listFilm);

                                writer.Close();
                            } 
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Aucune film à supprimer");
                    Console.ReadKey();
                }
            } while (numerofilm != 0);
        }

        
    }
}
