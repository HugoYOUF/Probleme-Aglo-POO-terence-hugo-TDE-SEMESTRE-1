using SkiaSharp;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Exemple de données : mots avec leur fréquence
        var mots = new Dictionary<string, int>
        {
            {"Csharp", 5},
            {"Nuage", 3},
            {"IA", 8},
            {"Graphique", 2},
            {"Programmation", 6}
        };

        // Générer le nuage de mots
        GenererNuageDeMots(mots, "nuage_de_mots.png");

        Console.WriteLine("Nuage de mots généré dans le fichier : nuage_de_mots.png");
    }

    static void GenererNuageDeMots(Dictionary<string, int> mots, string cheminFichier)
    {
        int largeur = 800;
        int hauteur = 600;

        using var surface = SKSurface.Create(new SKImageInfo(largeur, hauteur));
        var canvas = surface.Canvas;

        // Fond blanc
        canvas.Clear(SKColors.White);

        var random = new Random();

        foreach (var mot in mots)
        {
            // Taille du texte selon la fréquence du mot
            int tailleTexte = 10 + mot.Value * 5;
            float x = random.Next(50, largeur - 150);
            float y = random.Next(50, hauteur - 50);

            using var paint = new SKPaint
            {
                TextSize = tailleTexte,
                IsAntialias = true,
                Color = new SKColor(
                    (byte)random.Next(50, 255),
                    (byte)random.Next(50, 255),
                    (byte)random.Next(50, 255)),
                Typeface = SKTypeface.FromFamilyName("Arial")
            };

            // Dessiner le mot
            canvas.DrawText(mot.Key, x, y, paint);
        }

        // Sauvegarder l'image en PNG
        using var image = surface.Snapshot();
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        using var stream = System.IO.File.OpenWrite(cheminFichier);
        data.SaveTo(stream);
    }
}
