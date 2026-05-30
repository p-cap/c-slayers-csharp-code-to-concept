using System;

namespace StackVsHeap
{
    public class Program
    {
        private static int xpScore = 0;

        public static void Main()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==========================================================");
            Console.WriteLine("          ⚔️  WELCOME TO THE C# MEMORY ARENA  ⚔️          ");
            Console.WriteLine("          MISSION: MASTER THE STACK & THE HEAP            ");
            Console.WriteLine("==========================================================");
            Console.ResetColor();
            Console.WriteLine("\nRules: Decipher the hardware pointer pathways.");
            Console.WriteLine("Get it right: +10 XP. Get it wrong: Runtime Crash (Exit).");
            Console.WriteLine("Press any key to enter the execution thread...");
            Console.ReadKey();

            RunRoundOne();
            RunRoundTwo();
            RunRoundThree();

            // End Game Boundary
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==========================================================");
            Console.WriteLine($"🎉 CONGRATULATIONS! Your Stack Frames remained thread-safe!");
            Console.WriteLine($"🏆 Final Score: {xpScore} XP / 30 XP");
            Console.WriteLine("==========================================================");
            Console.ResetColor();
        }

        private static void RunRoundOne()
        {
            Console.Clear();
            Console.WriteLine("--- ROUND 1: THE POINTER DUPLICATION ILLUSION ---");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
    // Given the following definitions:
    public class Car { public string Model { get; set; } }

    // Execution Block:
    Car carA = new Car() { Model = ""Tesla"" };
    Car carB = carA; // <-- Look closely at this assignment!
    carB.Model = ""Ford"";
            ");
            Console.ResetColor();
            Console.WriteLine("Question: What is the value of 'carA.Model' at this point?");
            Console.WriteLine("1) \"Tesla\" (carB is an isolated data snapshot on the Stack)");
            Console.WriteLine("2) \"Ford\"  (carB copied the Heap reference address pointer)");
            Console.WriteLine("3) Throws a System.NullReferenceException");
            
            Console.Write("\nChoose your allocation path (1-3): ");
            string choice = Console.ReadLine() ?? "";

            if (choice == "2")
            {
                CorrectAnswer(@"XP Gained! Classes are Reference Types.
 [Stack Slot: carA] ──(Address: 0x01)──┐
                                      ├──> [Heap Object: Car (Model: ""Ford"")]
 [Stack Slot: carB] ──(Address: 0x01)──┘
 The variable 'carB' copied the 64-bit reference address pointer, NOT the data payload object.");
            }
            else
            {
                GameOverCrash("Wrong allocation mental model! Modifying carB modified carA because they point to the exact same Heap object slot.");
            }
        }

        private static void RunRoundTwo()
        {
            Console.Clear();
            Console.WriteLine("--- ROUND 2: STRUCT STACK FRAME LIFECYCLE ---");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
    public struct Point { public int X; public int Y; }

    public void Calculate()
    {
        Point p = new Point() { X = 10, Y = 20 };
        // Execution occurs inline...
    } // <-- Look closely right here at the closing brace!
            ");
            Console.ResetColor();
            Console.WriteLine("Question: What happens to the memory occupied by 'p' when 'Calculate()' hits its closing brace?");
            Console.WriteLine("1) It is immediately reclaimed as the Stack Frame pops off (LIFO layout zero GC tracking overhead).");
            Console.WriteLine("2) It stays in Gen 0 memory waiting for the next Garbage Collection sweep.");
            Console.WriteLine("3) It is migrated into the Large Object Heap (LOH).");

            Console.Write("\nChoose your allocation path (1-3): ");
            string choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                CorrectAnswer(@"XP Gained! Structs are Value Types.
 Value types are allocated entirely inline inside the current execution method's Stack Frame.
 When the method scope exits, the Stack pointer moves up, freeing that memory instantly with zero GC tracking overhead.");
            }
            else
            {
                GameOverCrash("Memory Leak in your understanding! Value types on the stack do not touch the Garbage Collector; they disappear instantly when the stack frame pops.");
            }
        }

        private static void RunRoundThree()
        {
            Console.Clear();
            Console.WriteLine("--- ROUND 3: THE REFERENCE TYPE ARRAY TRAP ---");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
    // An array of references:
    Customer[] items = new Customer[100]; 
    
    // Memory allocation checkpoint checked...
            ");
            Console.ResetColor();
            Console.WriteLine("Question: What was just allocated on the Managed Heap immediately after line 2 executes?");
            Console.WriteLine("1) 100 fully instantiated Customer objects containing concrete properties.");
            Console.WriteLine("2) An array memory block containing 100 null pointers (0x0 addresses), but no Customer instances yet.");
            Console.WriteLine("3) Nothing. The array stays stored on the Stack entirely until items are assigned values.");

            Console.Write("\nChoose your allocation path (1-3): ");
            string choice = Console.ReadLine() ?? "";

            if (choice == "2")
            {
                CorrectAnswer(@"XP Gained! 
 The instruction 'new Customer[100]' allocates an array container on the Heap to hold reference pointers.
 Each element defaults to 'null'. You must still explicitly loop and call 'new Customer()' to allocate each concrete object payload!");
            }
            else
            {
                GameOverCrash("NullReferenceException imminent! Instantiating a reference type array allocates slot addresses, not the actual object payloads.");
            }
        }

        private static void CorrectAnswer(string explanation)
        {
            xpScore += 10;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✔️ CORRECT!");
            Console.WriteLine(explanation);
            Console.ResetColor();
            Console.WriteLine("\nPress any key to advance to the next execution thread...");
            Console.ReadKey();
        }

        private static void GameOverCrash(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n💥💥 FATAL CRASH: MEMORY CORRUPTION / GAME OVER 💥💥");
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine("\nPress any key to drop the call stack thread...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}