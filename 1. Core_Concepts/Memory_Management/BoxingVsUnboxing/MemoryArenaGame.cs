using System;
using System.Threading;

namespace MemoryArenaGame
{
    class Program
    {
        static int score = 0;

        static void Main()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==========================================================");
            Console.WriteLine("          ⚔️  WELCOME TO THE C# MEMORY ARENA  ⚔️          ");
            Console.WriteLine("    Master Boxing & Unboxing or Explode Your Heap!        ");
            Console.WriteLine("==========================================================");
            Console.ResetColor();
            Console.WriteLine("\nRules: Answer the architectural questions correctly.");
            Console.WriteLine("Get it right: +10 XP. Get it wrong: Your program crashes.");
            Console.WriteLine("Press any key to enter the arena...");
            Console.ReadKey();

            RunRoundOne();
            RunRoundTwo();
            RunRoundThree();

            // End Game
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==========================================================");
            Console.WriteLine($"🎉 CONGRATULATIONS! You survived the Memory Arena!");
            Console.WriteLine($"🏆 Final Score: {score} XP / 30 XP");
            Console.WriteLine("==========================================================");
            Console.ResetColor();
        }

        static void RunRoundOne()
        {
            Console.Clear();
            Console.WriteLine("--- ROUND 1: THE INSIDIOUS LOOP ---");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
    ArrayList list = new ArrayList();
    for (int i = 0; i < 1000; i++)
    {
        list.Add(i); // <-- Look closely here!
    }
            ");
            Console.ResetColor();
            Console.WriteLine("Question: What is happening to the variable 'i' inside this loop?");
            Console.WriteLine("1) It stays on the Stack safely as a pure primitive value type.");
            Console.WriteLine("2) It is BOXED to the Heap 1000 times because ArrayList only accepts objects.");
            Console.WriteLine("3) It triggers a compile-time error.");
            
            string choice = Console.ReadLine() ?? "";

            if (choice == "2")
            {
                CorrectAnswer("XP Gained! ArrayList stores references, forcing a Stack ──> Heap allocation migration copy loop.");
            }
            else
            {
                GameOverCrash("Your Heap overflowed with implicit boxes! ArrayList cannot hold raw primitives directly.");
            }
        }

        static void RunRoundTwo()
        {
            Console.Clear();
            Console.WriteLine("--- ROUND 2: THE UNBOXING TRAP ---");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
    int health = 100;
    object boxedHealth = health; // Boxed smoothly
    
    // Time to unbox...
    short damage = (short)boxedHealth; // <-- Look closely here!
            ");
            Console.ResetColor();
            Console.WriteLine("Question: What happens when line 5 executes at runtime?");
            Console.WriteLine("1) It works perfectly! 100 safely fits into a short integer.");
            Console.WriteLine("2) It throws a compile-time warning but converts automatically.");
            Console.WriteLine("3) It crashes with an InvalidCastException.");

            string choice = Console.ReadLine() ?? "";

            if (choice == "3")
            {
                CorrectAnswer("XP Gained! The CLR enforces strict type matching on extraction: Heap [boxed Int32] ✖─> Stack [short].");
            }
            else
            {
                GameOverCrash("System Crashed! System.InvalidCastException. You cannot unbox an int directly into a short!");
            }
        }

        static void RunRoundThree()
        {
            Console.Clear();
            Console.WriteLine("--- ROUND 3: THE MUTATION MYSTERY ---");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
    int mana = 50;
    object boxedMana = mana; // Boxed snapshot taken
    
    mana = 99; // Modifying the original local variable
            ");
            Console.ResetColor();
            Console.WriteLine("Question: What is the value stored inside 'boxedMana' now?");
            Console.WriteLine("1) 50 (The heap object is a disconnected snapshot copy)");
            Console.WriteLine("2) 99 (The reference links them interactively together)");
            Console.WriteLine("3) null");

            string choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                CorrectAnswer("XP Gained! Primitives use value semantics. Original Stack ✖── Heap Wrapper remain isolated.");
            }
            else
            {
                GameOverCrash("Wrong! You fell for the pointer illusion. Boxing duplicates data; it doesn't share references.");
            }
        }

        static void CorrectAnswer(string explanation)
        {
            score += 10;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✔️ CORRECT!");
            Console.WriteLine(explanation);
            Console.ResetColor();
            Console.WriteLine("\nPress any key to advance...");
            Console.ReadKey();
        }

        static void GameOverCrash(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n💥💥 GAME OVER / RUNTIME CRASH 💥💥");
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine("\nPress any key to exit the arena...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}