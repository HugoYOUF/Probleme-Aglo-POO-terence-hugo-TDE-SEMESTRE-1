using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme_Hugo_Youf_Terence_Roumilhac_TD_E
{
    internal class Dé
    {
        public char[] face;
        public char lettre_tiree;

        public Dé(string cheminFichier, Random r)
        {
            // Lire le contenu du fichier
            string contenu = File.ReadAllText(cheminFichier).Trim();
            char[] toutesLesLettres = contenu.Where(char.IsLetter).Distinct().ToArray();// on filtre le fichier texte pour qu'il ne prenne aléatoirement que les lettres et non les ; ou le nombre et le poids de chaque lettre

            // Tirer 6 lettres aléatoires
            face = new char[6];
            for (int i = 0; i < 6; i++)
            {
                char lettre = ' ';
                while (Array.Exists(face, l => l == lettre));
                {
                    lettre = toutesLesLettres[r.Next(toutesLesLettres.Length)];
                }
                face[i] = lettre;
            }
        }

        public void Lance(Random r)
        {
            lettre_tiree = face[r.Next(face.Length)];
            
        }

        public string toString()
        {
            string faces = " ";
            for(int i = 0; i< face.Length; i++)
            {
                faces += face[i] + ", ";
            }
            return ("Lettres inscrites sur le dé : " + faces + "\n" + "Lettre tirée au sort : " + this.lettre_tiree);
        }



        //main temporaire pour voir si la classe marche bien 
        public static void Main(string[] args)
        {
            Random r = new Random();
            Dé de = new Dé("Lettres.txt", r);
            Random random = new Random();
            de.Lance(random);
            for(int i = 1; i <= de.face.Length; i++)
            {
                Console.WriteLine("face numéro " + i + " : " + de.face[i]);
            }
            
        }
    }
}
