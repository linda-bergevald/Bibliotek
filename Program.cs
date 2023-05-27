using System;

namespace Bibliotek
{
    public class Files
    {
        public static string[] förnamnDb = System.IO.File.ReadAllLines(@"C:\Users\linda.bergevald\source\repos\Bibliotek\Bibliotek\Textfiler\Users\förnamn.txt");
        public static string[] efternamnDb = System.IO.File.ReadAllLines(@"C:\Users\linda.bergevald\source\repos\Bibliotek\Bibliotek\Textfiler\Users\efternamn.txt");
        public static string[] personnummerDb = System.IO.File.ReadAllLines(@"C:\Users\linda.bergevald\source\repos\Bibliotek\Bibliotek\Textfiler\Users\personnummer.txt");
        public static string[] lösenordDb = System.IO.File.ReadAllLines(@"C:\Users\linda.bergevald\source\repos\Bibliotek\Bibliotek\Textfiler\Users\lösenord.txt");
        public static string förnamnInput;
        public static string efternamnInput;
        public static string personnummerInput;
        public static string lösenordInput;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till [bibliotek]! \nOm du inte är registrerad skriv \"Skapa konto\", annars tryck valfri tangent för att fortsätta");
            string input = Console.ReadLine().ToLower();
            if (input == "skapa konto")
            {
                CreateAcc();
            }
            else
            {
                LogIn();
            }

            Console.WriteLine("Vill du (1)söka bil, (2)se dina bilar eller (3)se dina uppgifter");
            input = Console.ReadLine().ToLower();
            if (input == "1" || input == "söka bil")
            {
                Console.WriteLine("ska implementeras");
            }
            else if (input == "2" || input == "se dina bilar")
            {
                Console.WriteLine("ska implementeras");
            }
            else if (input == "3" || input == "se dina uppgifter")
            {
                Console.WriteLine("ska implementeras");
            }
        }

        static void CreateAcc()
        {
            Console.WriteLine("Ange dina uppgifter för att skapa konto\nFörnamn:");
            Files.förnamnInput = Console.ReadLine() + "\n";
            Console.WriteLine("Efternamn:");
            Files.efternamnInput = Console.ReadLine() + "\n";
            Console.WriteLine("Personnummer:");
            Files.personnummerInput = Console.ReadLine() + "\n";
            Console.WriteLine("Lösenord:");
            Files.lösenordInput = Console.ReadLine() + "\n";

            System.IO.File.AppendAllText(@"C:\Users\linda.bergevald\source\repos\Bibliotek\Bibliotek\Textfiler\Users\förnamn.txt", Files.förnamnInput);
            System.IO.File.AppendAllText(@"C:\Users\linda.bergevald\source\repos\Bibliotek\Bibliotek\Textfiler\Users\efternamn.txt", Files.efternamnInput);
            System.IO.File.AppendAllText(@"C:\Users\linda.bergevald\source\repos\Bibliotek\Bibliotek\Textfiler\Users\personnummer.txt", Files.personnummerInput);
            System.IO.File.AppendAllText(@"C:\Users\linda.bergevald\source\repos\Bibliotek\Bibliotek\Textfiler\Users\lösenord.txt", Files.lösenordInput);
        }

        static void LogIn()
        {
            bool correctLogIn = false;
            
            while (!correctLogIn)
            {
                Console.WriteLine("Ange dina uppgifter för att logga in\nPersonnummer:");
                Files.personnummerInput = Console.ReadLine();
                Console.WriteLine("Lösenord:");
                Files.lösenordInput = Console.ReadLine();

                if (CheckLogIn(Files.personnummerInput, Files.lösenordInput))
                {
                    Console.WriteLine("Du är inne");
                    correctLogIn = true;
                }
                else
                {
                    Console.WriteLine("Fel personnummer eller lösenord");
                }
            }
        }

        static bool CheckLogIn(string personnummerInput, string lösenordInput)
        {
            for (int i = 0; i < Files.personnummerDb.Length; i++)
            {
                if (Files.personnummerInput == Files.personnummerDb[i] && Files.lösenordInput == Files.lösenordDb[i])
                {
                    return true;
                }
                else if (i + 1 == Files.personnummerDb.Length)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
