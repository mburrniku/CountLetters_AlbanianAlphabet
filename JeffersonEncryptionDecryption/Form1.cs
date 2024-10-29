using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JeffersonEncryptionDecryption
{
    public partial class Form1 : Form
    {
        // Definimi i alfabetit shqiptar dhe digrafet n� shkronja t� m�dha
        static readonly List<string> alfabeti = new List<string>
        {
            "A", "B", "C", "�", "D", "DH", "E", "�", "F", "G", "GJ", "H", "I", "J", "K", "L", "LL", "M", "N", "NJ", "O", "P", "Q", "R", "RR", "S", "SH", "T", "TH", "U", "V", "X", "XH", "Y", "Z", "ZH"
        };

        // Definimi i digraf�ve n� shkronja t� m�dha
        static readonly List<string> digrafet = new List<string>
        {
            "DH", "GJ", "LL", "NJ", "RR", "SH", "TH", "XH", "ZH"
        };

        // Alfabeti i renditur sipas frekuenc�s
        static string[] alphabetOrder =
        {
            "E", "�", "T", "I", "A", "R", "N", "U", "S", "O",
            "K", "M", "P", "D", "J", "SH", "V", "L", "B", "H",
            "Q", "G", "DH", "F", "Y", "NJ", "GJ", "Z", "TH", "LL",
            "RR", "�", "C", "ZH", "XH", "X"
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
            string plaintext = InputText.Text; // Merr tekstin e qart�
            string encryptedText = Encrypt(plaintext); // Enkriptu tekstin
            ResultText.Text = encryptedText; // Shfaq rezultatin e enkriptuar
        }

        private string Decrypt(string ciphertext)
        {
            // Hapi 1: Analizimi i frekuenc�s s� shkronjave n� tekstin e enkriptuar
            var frequency = AnalyzeFrequency(ciphertext);

            // Hapi 2: Krijimi i hartimit bazuar n� frekuenc�n e renditur dhe alfabetin
            var mapping = CreateMapping(ciphertext);

            // Hapi 3: Dekripto tekstin e enkriptuar duke p�rdorur hartimin
            return PerformDecryption(ciphertext, mapping);
        }

        private string Encrypt(string plaintext)
        {
            string encryptedText = string.Empty; // Inicializimi i tekstit t� enkriptuar
            plaintext = plaintext.ToUpper(); // Konverto shkrnjat ne shkronja te medha per krahasim

            // Procesimi i tekstit p�r digrafet fillimisht  
            for (int i = 0; i < plaintext.Length; i++)
            {
                // Kontrollo p�r digrafet  
                if (i < plaintext.Length - 1)
                {
                    string digraph = plaintext.Substring(i, 2); // Merr digrafin
                    if (digrafet.Contains(digraph))
                    {
                        int index = digrafet.IndexOf(digraph); // Merr indeksin e digrafit
                        // L�vizja e indeksit t� digrafit me 5 pozita  
                        int newIndex = (index + 5) % alfabeti.Count;
                        encryptedText += alfabeti[newIndex]; // Shto n� tekstin e enkriptuar
                        i++; // Kalo n� karakterin tjet�r si �sht� pjes� e digrafit  
                        continue;
                    }
                }

                // Enkripto karakteret e vetme  
                string singleChar = plaintext[i].ToString();
                int charIndex = alfabeti.IndexOf(singleChar); // Merr indeksin e karakterit
                if (charIndex != -1)
                {
                    // L�vizja e indeksit me 5 pozita  
                    int newIndex = (charIndex + 5) % alfabeti.Count;
                    encryptedText += alfabeti[newIndex]; // Shto n� tekstin e enkriptuar
                }
                else
                {
                    encryptedText += plaintext[i]; // Karakteret jo alfabetike mbeten t� pandryshuara  
                }
            }

            return encryptedText; // Kthe tekstin e enkriptuar
        }

        private Dictionary<string, int> AnalyzeFrequency(string text)
        {
            var frequency = new Dictionary<string, int>(); // Krijo nj� fjalor p�r frekuencat
            text = text.ToUpper(); // Trajto rast�sin� e shkronjave

            // Num�ro rastet e shkronjave dhe digraf�ve
            foreach (var letter in alfabeti)
            {
                int count = CountOccurrences(text, letter); // Num�ro rastet e shkronj�s
                if (count > 0)
                {
                    frequency[letter] = count; // Shto frekuenc�n n� hart�
                }
            }

            foreach (var digraph in digrafet)
            {
                int count = CountOccurrences(text, digraph); // Num�ro rastet e digrafit
                if (count > 0)
                {
                    frequency[digraph] = count; // Shto frekuenc�n n� hart�
                }
            }

            return frequency; // Kthe frekuencat
        }

        private int CountOccurrences(string text, string item)
        {
            // Num�ro sa her� ndodhet item-i n� tekst
            return (text.Length - text.Replace(item, "").Length) / item.Length;
        }

        private Dictionary<string, string> CreateMapping(string ciphertext)
        {
            var mapping = new Dictionary<string, string>(); // Krijo nj� fjalor p�r hartimin

            // Krijo nj� fjalor p�r num�rimin e frekuenc�s  
            var frequencyCount = new Dictionary<string, int>();

            // Num�rues p�r karakteret e p�rpunuara  
            int i = 0;
            while (i < ciphertext.Length)
            {
                bool foundDigraph = false; // Flag p�r gjetjen e digrafit

                // Kontrollo p�r digrafet  
                foreach (var digraph in digrafet)
                {
                    // Kontrollo n�se tekstin e mbetur fillon me digrafin aktual  
                    if (i <= ciphertext.Length - digraph.Length && ciphertext.Substring(i, digraph.Length) == digraph)
                    {
                        // Num�ro digrafin  
                        if (frequencyCount.ContainsKey(digraph))
                        {
                            frequencyCount[digraph]++;
                        }
                        else
                        {
                            frequencyCount[digraph] = 1; // Inicijalizo n�se nuk ekziston  
                        }

                        // L�viz indeksin p�rpara me gjat�si t� digrafit  
                        i += digraph.Length;
                        foundDigraph = true; // Vendos flag-un se u gjet nj� digraf
                        break; // Dale nga cikli foreach pasi gjet�m digrafin  
                    }
                }

                // N�se nuk u gjet asnj� digraf, kontrollo p�r shkronja t� vetme  
                if (!foundDigraph)
                {
                    if (i < ciphertext.Length)
                    {
                        char shkronja = ciphertext[i]; // Merr karakterin aktual
                        string letter = shkronja.ToString();

                        // Kontrollo n�se shkronja �sht� n� alfabet  
                        if (alfabeti.Contains(letter))
                        {
                            if (frequencyCount.ContainsKey(letter))
                            {
                                frequencyCount[letter]++;
                            }
                            else
                            {
                                frequencyCount[letter] = 1; // Inicijalizo me 1 n�se nuk ekziston  
                            }
                        }

                        // L�viz indeksin n� karakterin e ardhsh�m  
                        i++;
                    }
                }
            }

            // Krijo nj� list� t� renditur t� �el�save sipas frekuenc�s  
            var sortedKeys = frequencyCount.Keys.OrderByDescending(key => frequencyCount[key]).ToList();

            // Krijo hartimin bazuar n� renditjen e frekuenc�s  
            for (int j = 0; j < sortedKeys.Count && j < alphabetOrder.Length; j++)
            {
                mapping[sortedKeys[j]] = alphabetOrder[j]; // Krijo hartimin  
            }

            return mapping; // Kthe hartimin
        }

        private string PerformDecryption(string ciphertext, Dictionary<string, string> mapping)
        {
            string decryptedText = string.Empty; // Inicializimi i tekstit t� dekriptuar
            ciphertext = ciphertext.ToUpper(); // Trajto rast�sin� e shkronjave  

            int i = 0;
            while (i < ciphertext.Length)
            {
                bool foundDigraph = false; // Flag p�r gjetjen e digrafit

                // Kontrollo p�r digrafet n� tekstin e enkriptuar  
                foreach (var digraph in digrafet)
                {
                    // Kontrollo n�se tekstin e mbetur fillon me digrafin aktual  
                    if (i <= ciphertext.Length - digraph.Length && ciphertext.Substring(i, digraph.Length) == digraph)
                    {
                        // Shto hartimin ose vet� digrafin n� tekstin e dekriptuar  
                        decryptedText += mapping.ContainsKey(digraph) ? mapping[digraph] : digraph;

                        // Heq digrafin nga ciphertext  
                        ciphertext = ciphertext.Remove(i, digraph.Length);
                        foundDigraph = true; // Vendos flag-un se u gjet nj� digraf

                        // L�viz n� karakterin e ardhsh�m pas digrafit  
                        break; // Dale nga cikli foreach p�r t� vazhduar procesimin  
                    }
                }

                // N�se u gjet nj� digraf, mos e rrit indeksin  
                if (foundDigraph)
                {
                    // Tani kemi rregulluar stringun e ciphertext, k�shtu q� vazhdojme nga indeksi aktual  
                    continue;
                }

                // N�se nuk u gjet asnj� digraf, kontrollo p�r shkronja t� vetme  
                if (i < ciphertext.Length)
                {
                    string singleChar = ciphertext[i].ToString();
                    decryptedText += mapping.ContainsKey(singleChar) ? mapping[singleChar] : singleChar; // Harto ose mbaj origjinalin  

                    // Heq karakterin e vet�m nga ciphertext  
                    ciphertext = ciphertext.Remove(i, 1);
                }
            }

            return decryptedText; // Kthe tekstin e dekriptuar
        }
    }
}
