using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JeffersonEncryptionDecryption
{
    public partial class Form1 : Form
    {
        // Definimi i alfabetit shqiptar dhe digrafet në shkronja të mëdha
        static readonly List<string> alfabeti = new List<string>
        {
            "A", "B", "C", "Ç", "D", "DH", "E", "Ë", "F", "G", "GJ", "H", "I", "J", "K", "L", "LL", "M", "N", "NJ", "O", "P", "Q", "R", "RR", "S", "SH", "T", "TH", "U", "V", "X", "XH", "Y", "Z", "ZH"
        };

        // Definimi i digrafëve në shkronja të mëdha
        static readonly List<string> digrafet = new List<string>
        {
            "DH", "GJ", "LL", "NJ", "RR", "SH", "TH", "XH", "ZH"
        };

        // Alfabeti i renditur sipas frekuencës
        static string[] alphabetOrder =
        {
            "E", "Ë", "T", "I", "A", "R", "N", "U", "S", "O",
            "K", "M", "P", "D", "J", "SH", "V", "L", "B", "H",
            "Q", "G", "DH", "F", "Y", "NJ", "GJ", "Z", "TH", "LL",
            "RR", "Ç", "C", "ZH", "XH", "X"
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string ciphertext = InputText.Text; // Merr tekstin e enkriptuar
            string decryptedText = Decrypt(ciphertext); // Dekripto tekstin
            ResultText.Text = decryptedText; // Shfaq rezultatin e dekriptuar
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string plaintext = InputText.Text; // Merr tekstin e qartë
            string encryptedText = Encrypt(plaintext); // Enkriptu tekstin
            ResultText.Text = encryptedText; // Shfaq rezultatin e enkriptuar
        }

        private string Decrypt(string ciphertext)
        {
            // Hapi 1: Analizimi i frekuencës së shkronjave në tekstin e enkriptuar
            var frequency = AnalyzeFrequency(ciphertext);

            // Hapi 2: Krijimi i hartimit bazuar në frekuencën e renditur dhe alfabetin
            var mapping = CreateMapping(ciphertext);

            // Hapi 3: Dekripto tekstin e enkriptuar duke përdorur hartimin
            return PerformDecryption(ciphertext, mapping);
        }

        private string Encrypt(string plaintext)
        {
            string encryptedText = string.Empty; // Inicializimi i tekstit të enkriptuar
            plaintext = plaintext.ToUpper(); // Konverto shkrnjat ne shkronja te medha per krahasim

            // Procesimi i tekstit për digrafet fillimisht  
            for (int i = 0; i < plaintext.Length; i++)
            {
                // Kontrollo për digrafet  
                if (i < plaintext.Length - 1)
                {
                    string digraph = plaintext.Substring(i, 2); // Merr digrafin
                    if (digrafet.Contains(digraph))
                    {
                        int index = digrafet.IndexOf(digraph); // Merr indeksin e digrafit
                        // Lëvizja e indeksit të digrafit me 5 pozita  
                        int newIndex = (index + 5) % alfabeti.Count;
                        encryptedText += alfabeti[newIndex]; // Shto në tekstin e enkriptuar
                        i++; // Kalo në karakterin tjetër si është pjesë e digrafit  
                        continue;
                    }
                }

                // Enkripto karakteret e vetme  
                string singleChar = plaintext[i].ToString();
                int charIndex = alfabeti.IndexOf(singleChar); // Merr indeksin e karakterit
                if (charIndex != -1)
                {
                    // Lëvizja e indeksit me 5 pozita  
                    int newIndex = (charIndex + 5) % alfabeti.Count;
                    encryptedText += alfabeti[newIndex]; // Shto në tekstin e enkriptuar
                }
                else
                {
                    encryptedText += plaintext[i]; // Karakteret jo alfabetike mbeten të pandryshuara  
                }
            }

            return encryptedText; // Kthe tekstin e enkriptuar
        }

        private Dictionary<string, int> AnalyzeFrequency(string text)
        {
            var frequency = new Dictionary<string, int>(); // Krijo një fjalor për frekuencat
            text = text.ToUpper(); // Trajto rastësinë e shkronjave

            // Numëro rastet e shkronjave dhe digrafëve
            foreach (var letter in alfabeti)
            {
                int count = CountOccurrences(text, letter); // Numëro rastet e shkronjës
                if (count > 0)
                {
                    frequency[letter] = count; // Shto frekuencën në hartë
                }
            }

            foreach (var digraph in digrafet)
            {
                int count = CountOccurrences(text, digraph); // Numëro rastet e digrafit
                if (count > 0)
                {
                    frequency[digraph] = count; // Shto frekuencën në hartë
                }
            }

            return frequency; // Kthe frekuencat
        }

        private int CountOccurrences(string text, string item)
        {
            // Numëro sa herë ndodhet item-i në tekst
            return (text.Length - text.Replace(item, "").Length) / item.Length;
        }

        private Dictionary<string, string> CreateMapping(string ciphertext)
        {
            var mapping = new Dictionary<string, string>(); // Krijo një fjalor për hartimin

            // Krijo një fjalor për numërimin e frekuencës  
            var frequencyCount = new Dictionary<string, int>();

            // Numërues për karakteret e përpunuara  
            int i = 0;
            while (i < ciphertext.Length)
            {
                bool foundDigraph = false; // Flag për gjetjen e digrafit

                // Kontrollo për digrafet  
                foreach (var digraph in digrafet)
                {
                    // Kontrollo nëse tekstin e mbetur fillon me digrafin aktual  
                    if (i <= ciphertext.Length - digraph.Length && ciphertext.Substring(i, digraph.Length) == digraph)
                    {
                        // Numëro digrafin  
                        if (frequencyCount.ContainsKey(digraph))
                        {
                            frequencyCount[digraph]++;
                        }
                        else
                        {
                            frequencyCount[digraph] = 1; // Inicijalizo nëse nuk ekziston  
                        }

                        // Lëviz indeksin përpara me gjatësi të digrafit  
                        i += digraph.Length;
                        foundDigraph = true; // Vendos flag-un se u gjet një digraf
                        break; // Dale nga cikli foreach pasi gjetëm digrafin  
                    }
                }

                // Nëse nuk u gjet asnjë digraf, kontrollo për shkronja të vetme  
                if (!foundDigraph)
                {
                    if (i < ciphertext.Length)
                    {
                        char shkronja = ciphertext[i]; // Merr karakterin aktual
                        string letter = shkronja.ToString();

                        // Kontrollo nëse shkronja është në alfabet  
                        if (alfabeti.Contains(letter))
                        {
                            if (frequencyCount.ContainsKey(letter))
                            {
                                frequencyCount[letter]++;
                            }
                            else
                            {
                                frequencyCount[letter] = 1; // Inicijalizo me 1 nëse nuk ekziston  
                            }
                        }

                        // Lëviz indeksin në karakterin e ardhshëm  
                        i++;
                    }
                }
            }

            // Krijo një listë të renditur të çelësave sipas frekuencës  
            var sortedKeys = frequencyCount.Keys.OrderByDescending(key => frequencyCount[key]).ToList();

            // Krijo hartimin bazuar në renditjen e frekuencës  
            for (int j = 0; j < sortedKeys.Count && j < alphabetOrder.Length; j++)
            {
                mapping[sortedKeys[j]] = alphabetOrder[j]; // Krijo hartimin  
            }

            return mapping; // Kthe hartimin
        }

        private string PerformDecryption(string ciphertext, Dictionary<string, string> mapping)
        {
            string decryptedText = string.Empty; // Inicializimi i tekstit të dekriptuar
            ciphertext = ciphertext.ToUpper(); // Trajto rastësinë e shkronjave  

            int i = 0;
            while (i < ciphertext.Length)
            {
                bool foundDigraph = false; // Flag për gjetjen e digrafit

                // Kontrollo për digrafet në tekstin e enkriptuar  
                foreach (var digraph in digrafet)
                {
                    // Kontrollo nëse tekstin e mbetur fillon me digrafin aktual  
                    if (i <= ciphertext.Length - digraph.Length && ciphertext.Substring(i, digraph.Length) == digraph)
                    {
                        // Shto hartimin ose vetë digrafin në tekstin e dekriptuar  
                        decryptedText += mapping.ContainsKey(digraph) ? mapping[digraph] : digraph;

                        // Heq digrafin nga ciphertext  
                        ciphertext = ciphertext.Remove(i, digraph.Length);
                        foundDigraph = true; // Vendos flag-un se u gjet një digraf

                        // Lëviz në karakterin e ardhshëm pas digrafit  
                        break; // Dale nga cikli foreach për të vazhduar procesimin  
                    }
                }

                // Nëse u gjet një digraf, mos e rrit indeksin  
                if (foundDigraph)
                {
                    // Tani kemi rregulluar stringun e ciphertext, kështu që vazhdojme nga indeksi aktual  
                    continue;
                }

                // Nëse nuk u gjet asnjë digraf, kontrollo për shkronja të vetme  
                if (i < ciphertext.Length)
                {
                    string singleChar = ciphertext[i].ToString();
                    decryptedText += mapping.ContainsKey(singleChar) ? mapping[singleChar] : singleChar; // Harto ose mbaj origjinalin  

                    // Heq karakterin e vetëm nga ciphertext  
                    ciphertext = ciphertext.Remove(i, 1);
                }
            }

            return decryptedText; // Kthe tekstin e dekriptuar
        }
    }
}
