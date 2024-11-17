using System;
using System.Text;

public class Dictionnaire
{
    private SortedSet<string> mots;
    public string Langue { get; private set; }

    public Dictionnaire(string Fichier, string langue)
    {
        this.Langue = langue;
        mots = new SortedSet<string>(File.ReadAllLines(Fichier));
    }

    public string toString()
    {
        //nombre de mots par longueur 
        var motLongueur = mots.GroupBy(mot => mot.Length).OrderBy(g=>g.Key).ToDictionary(g=>g.Key, g=>g.Count());

        //nombre de mots qui commencent par chaque lettre de l'alphabet
        var motLettre = mots.GroupBy(mot => mot[0].ToString().ToUpper()).OrderBy(g=>g.Key).ToDictionary(g=>g.Key, g=>g.Count());

        var strB = new StringBuilder();

        strB.AppendLine($"Langue : {Langue}.");
        strB.AppendLine("Mots par longueur :");
        foreach (var l in motLongueur)
        {
            strB.AppendLine($"Longueur {l.Key} = {l.Value} mots.");
        }

        strB.AppendLine("Mots par première lettre :");
        foreach(var p in motLettre)
        {
            strB.AppendLine($" {p.Key} = {p.Value}");
        }
        return strB.ToString();
    }

    public bool RDR(string mot)
    {
        return RechDichoRecursif(mot, mots.ToList(), 0, mots.Count-1);
    }

    public bool RechDichoRecursif(string mot, List<string> liste,int debut,int fin)
    {
        if(fin < debut)
        {
            return false ;
        }

        int milieu = ((fin + debut)/2) ;
        int comparer = string.Compare(mot, liste[milieu], StringComparison.OrdinalIgnoreCase) ;

        if(comparer == 0)
        {
            return true ;   
        }

        else if(comparer <0)
        {
            return RechDichoRecursif(mot, liste, debut, milieu-1) ;
        }

        return RechDichoRecursif(mot, liste, milieu-1, fin) ;   
    }
}
