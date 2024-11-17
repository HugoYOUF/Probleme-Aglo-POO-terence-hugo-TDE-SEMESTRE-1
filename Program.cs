using Probleme_Hugo_Youf_Terence_Roumilhac_TD_E;
using System;

class Jeu
{
    public static void Main(string[] args)
    {
        //On affiche les règles et d'un plateau exemple pour les joueurs.
        Plateau plateau1 = new Plateau(16);
        plateau1.toString();
        Console.WriteLine("Bienvenue sur le jeu Boogle\n\n" +
            "Règles : Un plateau composé de 16 lettres va s'afficher. Chaque joueur aura alors 1 minutes pour tenter de reconnaitre un maximum de mot en allant lettre par lettre et de manière horizontale, verticale, et diagonale, composer votre mot.\n\n" +
            "Voici un exemple de plateau du jeu :\n"+ plateau1.toString());

        Console.WriteLine("Combien de joueurs êtes vous ? (2 minimum)");

        //On définit le nombre de joueurs qui vont jouer au jeu.
        int nombre_joueurs = Convert.ToInt32(Console.ReadLine());
        while (nombre_joueurs < 2)
        {
            Console.WriteLine("Il n'y a pas assez de joueur pour commencer la partie.");
            nombre_joueurs = Convert.ToInt32(Console.ReadLine());
        }
        //On créer un tableau de joueurs pour pouvoir ajouter chaque joueurs à la partie.
        Joueur[] joueurs = new Joueur[nombre_joueurs];
        Console.WriteLine("Veuillez maintenant renseigner le nom de chaque joueur : ");

        //on ajoute chaque joueurs au tableau précedemment créer.
        for(int i = 0; i < nombre_joueurs; i++)
        {
            Joueur Joueur= new Joueur(Convert.ToString(Console.ReadLine()), new List<string>());
            joueurs[i] = Joueur;
        }

        //On demande et définit la durée de la partie.
        Console.WriteLine("Vous allez donc pouvoir commencer votre partien, mais avant vous devez définir le temps de votre partie en minutes : ");
        int durée_partie = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("La partie va donc durer " + durée_partie + " minutes.\n\nDès que vous appuierai sur ENTRER un plateau va s'afficher, la première manche jouée par " + joueurs[0].Nom+" va commencer et le compte à rebours va se lancer");
        
        //On créer la date de et de début et des qu'elle sont égales la partie s'arrête. Donc tout le code du jeu va se trouver dans cette boucle.
        DateTime début = DateTime.Now;
        DateTime fin = début.AddMinutes(durée_partie);
        Console.WriteLine(début);
        Console.WriteLine(fin);

        int k = 0;
        while (DateTime.Now<=fin)    
        {
            Console.WriteLine(k);
            Thread.Sleep(1000);
            k++;
        }
        Console.WriteLine("Fin du jeu");











    }


}
