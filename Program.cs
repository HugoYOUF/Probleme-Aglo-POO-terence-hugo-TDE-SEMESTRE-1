using Probleme_Hugo_Youf_Terence_Roumilhac_TD_E;
using System;
using System.Reflection.Metadata;

public class Joueur
{
    //déclaration des attributs du joueurs
    public string nom;
    public int score;
    public List<string> mots_trouves;

    public Joueur(string nom,  List<string> mots_trouves)
    {
        this.nom = nom;
        this.mots_trouves = mots_trouves;

    }

    //déclaration des propriétés qu'on pourrait utiliser plus tard
    public string Nom           
    {
        get { return nom; }
    }
    public int Score
    {
        get { return score;}
        set { score = value; }
    }
    public List<string> Mots_trouves
    {
        get { return mots_trouves; }
        set { mots_trouves = value;}
    }

    //fonction qui vérifie si le mot trouvé par le joueur a déjà été trouvé par ce joueur avant
    public bool Contain(string mot)
    {
        bool a = false;
        for(int i = 0; i<mots_trouves.Count; i++)
        {
            if (mot == mots_trouves[i])
            {
                a = true;
            }
        }
        return a;
    }

    //fonction qui ajoute le mot trouvé à la liste des mots trouvés par le joueur
    public void Add_mot(string mot)
    {
        if (Contain(mot) == false)
        {
            mots_trouves.Add(mot);
        }
    }

    public string toString()
    {
        string mots = " ";
        for (int i = 0; i < mots_trouves.Count; i++)
        {
            mots += mots_trouves + ", ";
        }
        return ("Nom : " + this.nom + "\n" + "Score : " + this.score + "\n" + "Mots trouvés : " + mots);
    }


    //main temporaire pour voir la classe marche bien
    public static void Main(string[] args)
    {
        Joueur Joueur1 = new Joueur("Paul",);

    }
}