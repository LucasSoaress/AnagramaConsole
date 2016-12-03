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
        public static int numeroAnagramas;
        public static List<string> palavrasAnagramas = new List<string>(); 

        /// <summary>
        /// Método incicial
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            numeroAnagramas = 0;
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite uma palavra para fazer o anagrama \n");
            palavra = Console.ReadLine();

            if (palavra != String.Empty && palavra.Length <= 9)
            {
                List<char> lettersUsed = new List<char>();
                List<char> lettersLeft = new List<char>(palavra);
                Console.Clear();
                Console.WriteLine("Lista de novas palavras - palavra digitada: " + palavra + "\n");
                lettersLeft.Sort();
                RecursiveCount(lettersUsed, lettersLeft);  
                Console.WriteLine(" \n \n Numero de anagramas gerados = " + numeroAnagramas.ToString());
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
                    numeroAnagramas++;
                    palavrasAnagramas.Add(new string(lettersUsed.ToArray()));
                    Console.WriteLine( "  " + numeroAnagramas.ToString() +"  " + new string(lettersUsed.ToArray()));
                   //Console.Write(new string(lettersUsed.ToArray()) + "\t");
                }
            }

            if (lettersLeft.Count() > 0)
            {
                for (int i = 0; i < lettersLeft.Count(); i++)
                {
                    List<char> newLettersUsed = new List<char>(lettersUsed);
                    newLettersUsed.Add(lettersLeft[i]);
                    List<char> newLettersLeft = new List<char>(lettersLeft);
                    newLettersLeft.RemoveAt(i);
                    RecursiveCount(newLettersUsed, newLettersLeft);
                }
            }
        }
    }
}   