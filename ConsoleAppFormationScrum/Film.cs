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
            f.annee = int.Parse(Console.ReadLine());
            Console.WriteLine("Nom du Réalisateur :");
            f.realisateur = Console.ReadLine();
            Console.WriteLine("Votre Note :");
            f.note = int.Parse(Console.ReadLine());
            Console.WriteLine("Votre Critique :");
            f.critique = Console.ReadLine();

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


            if (listFilm.Any())
            {
                Console.WriteLine("Quelle film voulez-vous supprimer ?");
                foreach (var Film in listFilm)
                {
                    Console.WriteLine($"{listFilm.IndexOf(Film) + 1}. {Film.titre} ");
                }

                int.TryParse(Console.ReadLine(), out int numerofilm);

                while (numerofilm <= 0 || numerofilm > listFilm.Count)
                {
                    Console.WriteLine("Quelle film voulez-vous supprimer ?");
                    int.TryParse(Console.ReadLine(), out numerofilm);
                }

                listFilm.RemoveAt(numerofilm - 1);
            }
            else
            {
                Console.WriteLine("Aucune film à supprimer");
                Console.ReadKey();
            }

        }

        
    }
}
