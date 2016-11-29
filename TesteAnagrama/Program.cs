using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAnagrama
{
    class Program
    {
        public static string palavra;
        public static List<string> palavrasAnagramas = new List<string>(); 

        /// <summary>
        /// Método incicial
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Console.SetWindowSize(Console.LargestWindowWidth,Console.LargestWindowHeight);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite uma palavra para fazer o anagrama");
            palavra = Console.ReadLine();

            if (palavra != String.Empty && palavra.Length <= 9)
            {
                List<char> lettersUsed = new List<char>();
                List<char> lettersLeft = new List<char>(palavra);
                Console.Clear();
                Console.WriteLine("Lista de novas palavras - palavra digitada: " + palavra);
                Console.WriteLine("");
                RecursiveCount(lettersUsed, lettersLeft);

                palavrasAnagramas.Sort();
                
                for(int i = 0; i < palavrasAnagramas.Count; i++)
                {
                    Console.Write(palavrasAnagramas[i] + " ");
                }  
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ocorreu um erro");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Método que faz a instancia de novas palavras
        /// </summary>
        /// <param name="lettersUsed">Recebe os caracteres que serão usados anteriormente</param>
        /// <param name="lettersLeft">Recebe as proximas letras</param>
        private static void RecursiveCount(List<char> lettersUsed, List<char> lettersLeft)
        {
            if (lettersUsed.Count == palavra.Length)
            {
                if(!palavrasAnagramas.Contains(new string(lettersUsed.ToArray())))
                {
                    //Console.WriteLine(new string(lettersUsed.ToArray()));
                    palavrasAnagramas.Add(new string(lettersUsed.ToArray()));
                }
            }
            if (lettersLeft.Count() > 0)
            {
                for (int index = 0; index < lettersLeft.Count(); index++)
                {
                    List<char> newLettersUsed = new List<char>(lettersUsed);
                    newLettersUsed.Add(lettersLeft[index]);
                    List<char> newLettersLeft = new List<char>(lettersLeft);
                    newLettersLeft.RemoveAt(index);
                    RecursiveCount(newLettersUsed, newLettersLeft);
                }
            }
        }
    }
}   