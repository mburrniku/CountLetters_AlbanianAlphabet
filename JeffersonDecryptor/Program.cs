using System;
using System.Collections.Generic;
using System.Linq;

class JeffersonDecryption
{
    static string[] alphabetOrder =
    {
        "E", "Ë", "T", "I", "A", "R", "N", "U", "S", "O",
        "K", "M", "P", "D", "J", "Sh", "V", "L", "B", "H",
        "Q", "G", "DH", "F", "Y", "Nj", "Gj", "Z", "TH", "Ll",
        "Rr", "Ç", "C", "Zh", "Xh", "X"
    };

    public static string DecryptText(string encryptedText)
    {
        encryptedText = encryptedText.ToUpper(); // Konverto të gjitha shkronjat në të mëdha
        var frequencyTable = GetFrequencyTable(encryptedText);
        var mapping = CreateMapping(frequencyTable);

        // Zëvendësimi sipas tabelës së krijuar
        foreach (var pair in mapping)
        {
            encryptedText = encryptedText.Replace(pair.Key, pair.Value);
        }

        return encryptedText;
    }

    private static Dictionary<string, int> GetFrequencyTable(string text)
    {
        var frequency = new Dictionary<string, int>();

        for (int i = 0; i < text.Length; i++)
        {
            string digraph = i < text.Length - 1 ? text.Substring(i, 2).ToUpper() : null;
            string monograph = text[i].ToString().ToUpper();

            if (digraph != null && alphabetOrder.Contains(digraph))
            {
                AddFrequency(frequency, digraph);
                i++; // Kalon te shkronja tjetër pas një digrafi
            }
            else if (alphabetOrder.Contains(monograph))
            {
                AddFrequency(frequency, monograph);
            }
        }

        return frequency.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    }

    private static void AddFrequency(Dictionary<string, int> frequency, string key)
    {
        if (frequency.ContainsKey(key))
            frequency[key]++;
        else
            frequency[key] = 1;
    }

    private static Dictionary<string, string> CreateMapping(Dictionary<string, int> frequencyTable)
    {
        var mapping = new Dictionary<string, string>();
        int index = 0;

        foreach (var symbol in frequencyTable.Keys)
        {
            if (index < alphabetOrder.Length)
                mapping[symbol] = alphabetOrder[index++];
            else
                break;
        }

        return mapping;
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Shkruani tekstin e koduar (ose shkruani 'exit' për të dalë):");
            string encryptedText = Console.ReadLine();

            if (encryptedText.ToLower() == "exit")
                break;

            string decryptedText = DecryptText(encryptedText);
            Console.WriteLine("Teksti i dekriptuar: " + decryptedText);
            Console.WriteLine();
        }
    }
}
