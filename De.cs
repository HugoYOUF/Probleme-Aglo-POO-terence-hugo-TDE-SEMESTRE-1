using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme_Hugo_Youf_Terence_Roumilhac_TD_E
{
    internal class Dé
    {
        //Déclaration des attributs de la classe D
        public char[] face;
        public char lettre_tiree;
        public Dé(Random r)
        {
            // Initialiser le tableau face avec la taille de 6
            face = new char[6];

            // Récupérer les lettres possibles
            char[] lettres_possibles = Lettre.Obtenir_tableau_toutes_les_lettres_possibles();

            // Remplir face avec des lettres aléatoires
            for (int i = 0; i < 6; i++)
            {
                face[i] = lettres_possibles[r.Next(lettres_possibles.Length)];
            }
        }

        //Fonction Lance qui permet de choisir au hasard une face du dé qui sera affichée sur le plateau

        public void Lance(Random r)
        {
            lettre_tiree = face[r.Next(face.Length)];
            
        }

        //Fonction toString qui affiche 
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
        //public static void Main(string[] args)
        //{
        //Random r = new Random();
        //Dé de = new Dé( r);
        //Random random = new Random();
        //de.Lance(random);
        //  for(int i = 1; i <= de.face.Length; i++)
        //{
        //Console.WriteLine("face numéro " + i + " : " + de.face[i]);
        //}

        //}
    }
}
