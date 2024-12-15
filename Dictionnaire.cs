using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Dictionnaire
{
private string Langue;
private List<string> mots;
public Dictionniare(string fichier, string langue) 
{
    this.Langue = langue;
    mots = new List<string>();

    if(File.Exists(fichier))
    {
        Console.WriteLine("Ficher : " + fichier );
     
    }

    else
    {
        Console.WriteLine("Ficher : " + fichier + " introuvable");
        return;
    }

    string lecture =File.ReadAllText(fichier);

    string[] separemot = lecture.Split(new[] { ' ', '\n', '\r', '\t' });
    //Fonctionne aussi sans \n, \r, \t

    foreach(var mot in separemot) 
    {
        if(!string.IsNullOrEmpty(mot))
        {
            mots.Add(mot);
        }
    }
    mots.Sort();
}

public string ToString()
{
    Dictionary<int,int> motsLongueur = mots.GroupBy(m => m.Length).ToDictionary(grp=>grp.Key, grp=>grp.Count());
    Dictionary<char,int> motsPremierelettre = mots.GroupBy(m => m[0]).ToDictionary(grp => grp.Key, grp => grp.Count());
    //Dictionary<Key,Value> => Key : clé qui permet le tri, Value : la valeur de chaque tri
    string sol;
    sol = ("Langue : "+Langue+" \nNombre de mots par longueur: \n");

    foreach (KeyValuePair < int,int> i in motsLongueur ) 
    {
        sol += ("Mots à " +i.Key+" lettres : "+i.Value+" \n");
    }   

    sol += ("\nNombre de mots qui commencent par la lettre :\n");

    foreach(KeyValuePair<char,int> j in motsPremierelettre )
    {
        sol+=j.Key+" : "+j.Value +"\n";
    }

    return sol ;

}

public bool RechDichoRecursif(string mot, int debut =0, int fin=-1 )
{
    if(fin==-1)
    {
        fin = mots.Count-1;
    }

    if(debut>fin)
    {
        return false;
    }

    string motMinuscule = mot.ToLower();
    string motMilieuMinuscule = mots[(debut + fin) / 2].ToLower();
    //Fonctionne aussi sans les ToLower()

    int milieu = (debut+fin)/2;
    int compare = string.Compare(motMilieuMinuscule, motMinuscule);

    if(compare==0)
    {
        return true;
    }

    if(compare<0)
    {
        return RechDichoRecursif(mot, milieu + 1, fin);
    }

    return RechDichoRecursif(mot, debut, milieu -1);
}
}
