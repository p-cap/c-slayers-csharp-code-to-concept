using System;

// Question 3: The Reference Type Array Trap
// This snippet tests the difference between initializing a collection container and initializing its nested payload contents.
// Snippet execution block

public class Customer 
{ 
    public string Name { get; set; } = "Guest";
}

// 📦 THE ACTION:
// Allocating space for an array on the Heap. This instruction creates an array structure 
// sized for 100 memory addresses—it does NOT instantiate 100 individual Customer instances.
Customer[] items = new Customer[100];

// 🛠️ PLAYGROUND CHALLENGE 1: Expose the Null Reference Trap.
// Uncomment the try/catch block below to run a simulation check.
// Attempting to access an index property right now will immediately throw a NullReferenceException
// because every item index inside the newly allocated array defaults to a null pointer (0x0).
/*
try
{
    Console.WriteLine($"Customer [0] Name: {items[0].Name}");
}
catch (NullReferenceException)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("💥 CRASH! Array slots are allocated, but individual object payloads are null!");
    Console.ResetColor();
}
*/

// 🛠️ PLAYGROUND CHALLENGE 2: Correctly populate the Heap array memory block.
// Uncomment the loop below to see how to properly map the pointers out.
// You must explicitly iterate and initialize each object element slot to avoid pointer initialization failure.
/*
for (int i = 0; i < items.Length; i++)
{
    items[i] = new Customer() { Name = $"Customer_{i}" };
}
Console.WriteLine($"Populated! Customer [0] Name: {items[0].Name}");
*/