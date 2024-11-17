using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Probleme_Hugo_Youf_Terence_Roumilhac_TD_E
{
    internal class Plateau
    {

        private Dé[] tab_de_dé;
        private int taille; 

        public Plateau(int taille = 16)
        {
            this.taille = taille;
            tab_de_dé = new Dé[taille];
            InitialiserPlateau();
        }

        // Méthode pour initialiser le plateau avec des dés
        private void InitialiserPlateau()
        {
            Random r = new Random();
            for (int i = 0; i < taille; i++)
            {
                tab_de_dé[i] = new Dé(r); 
                tab_de_dé[i].Lance(r); 
                
            }
        }


        //fonction toString qui affiche le plateau proprement
        public string toString()
        {
            string affichage = "";
            for (int i = 0; i < taille; i++)
            {
                if(i==3 || i==7 || i==11)
                {
                    affichage += tab_de_dé[i].Lettre_tiree + "\n";
                }
                else
                {
                    affichage += tab_de_dé[i].Lettre_tiree + " ";
                }
            }
            return affichage;
        }

        //Main temporaire pour voir si la fonction marche correctement
        /*
        public static void Main(string[] args)
        {
            Plateau plateau1 = new Plateau(16);
            plateau1.toString();
            Console.WriteLine(plateau1.toString());
        }
        */


    }
}
