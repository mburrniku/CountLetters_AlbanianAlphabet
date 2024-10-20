using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    // Definohet alfabeti shqiptar dhe digrafet me shkronja të mëdha (uppercase)
    static readonly List<string> alfabeti = new List<string>
    {
        "A", "B", "C", "Ç", "D", "DH", "E", "Ë", "F", "G", "GJ", "H", "I", "J", "K", "L", "LL", "M", "N", "NJ", "O", "P", "Q", "R", "RR", "S", "SH", "T", "TH", "U", "V", "X", "XH", "Y", "Z", "ZH"
    };

    // Definohen digrafet me shkronja të mëdha (uppercase)
    static readonly List<string> digrafet = new List<string>
    {
        "DH", "GJ", "LL", "NJ", "RR", "SH", "TH", "XH", "ZH"
    };

    static void Main(string[] args)
    {
        // Merr pathin e file nga inputi i përdoruesit
        Console.Write("Sheno pathin e file: ");
        string filePath = Console.ReadLine();

        // Numëro shkronjat nga file
        var letterCounts = NumroShkronjatNgaFile(filePath);

        // Nëse numërimi është kryer me sukses
        if (letterCounts != null)
        {
            // Gjej totalin e të gjitha shkronjave
            int totalLetters = letterCounts.Values.Sum(); // Llogarit totalin e shkronjave

            // Shfaq rezultatet e renditura nga më e larta në më të ulët
            var sortedResults = letterCounts.OrderByDescending(t => t.Value); // Rendit sipas vlerës

            Console.WriteLine("Numri i shkronjave në tekstin e ngarkuar (renditur sipas numrit):");
            foreach (var pair in sortedResults)
            {
                string letter = pair.Key;
                int count = pair.Value;
                double percentage = totalLetters > 0 ? (double)count / totalLetters * 100 : 0; // Llogarit përqindjen
                Console.WriteLine($"{letter}: {count} ({percentage:F2}%)"); // Shfaq shkronjën, numrin dhe përqindjen
            }

            // Shfaq numrin total të shkronjave
            Console.WriteLine($"\nTotali i shkronjave: {totalLetters}");

        }
    }

    // Funksion për të lexuar një tekst nga file dhe për të numëruar shkronjat
    static Dictionary<string, int> NumroShkronjatNgaFile(string filePath)
    {
        try
        {
            string text = File.ReadAllText(filePath); // Lexo përmbajtjen e file
            return NumroShkronjat(text); // Numëro shkronjat në tekstin e file
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File {filePath} nuk u gjet.");
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ndodhi një gabim: {e.Message}");
            return null;
        }
    }

    // Funksion për të numëruar të gjitha shkronjat
    static Dictionary<string, int> NumroShkronjat(string text)
    {
        // Krijo një fjalor për të ruajtur numërimin e të gjitha shkronjave
        Dictionary<string, int> letterCount = new Dictionary<string, int>();

        // Inicializo fjalorin me të gjitha shkronjat e alfabetit shqiptar, me vlerë fillestare 0
        foreach (var letter in alfabeti)
        {
            letterCount[letter] = 0; // Vendos vlerën fillestare për secilën shkronjë në 0
        }

        // Shndërro tekstin në shkronja të vogla për të trajtuar rastet me/pa shkronja të mëdha
        string lowerCaseText = text.ToLower();

        // Numëro digrafet
        foreach (var shkronja in digrafet)
        {
            int count = Regex.Matches(lowerCaseText, shkronja.ToLower()).Count; // Numëron digrafet
            if (count > 0)
            {
                // Këtu po ruajmë digrafët me shkronja të mëdha
                letterCount[shkronja] += count; // Shtoni numrin në fjalor
            }
            lowerCaseText = Regex.Replace(lowerCaseText, shkronja.ToLower(), ""); // Hiqi digrafet nga teksti
        }

        // Numëro shkronjat e vetme
        foreach (char shkronja in lowerCaseText)
        {
            string letter = Char.ToUpper(shkronja).ToString(); // Shndërro shkronjën në shkronjë të madhe
            // Kontrollo nëse shkronja është e pranishme në fjalor dhe numëro
            if (letterCount.ContainsKey(letter))
            {
                letterCount[letter]++; // Shto numrin për shkronjën
            }
        }

        // Kthe fjalorin me numërimet e shkronjave
        return letterCount;
    }
}
