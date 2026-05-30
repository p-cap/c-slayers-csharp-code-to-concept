using System;

// Question 1: The Pointer Duplication Illusion
// This snippet evaluates how assignments copy variables depending on whether they are reference or value types.
// Snippet execution block

public class Car 
{ 
    public string Model { get; set; } = "Unknown";
}

Car carA = new Car() { Model = "Tesla" };

// 📦 THE ACTION:
// Copying carA into carB. Because Car is a class (Reference Type), this copies 
// the 64-bit reference pointer address sitting on the Stack, NOT the actual object data.
Car carB = carA; 

// 🛠️ PLAYGROUND CHALLENGE 1: Mutate the shared instance state.
// Uncomment the line below to change the Model property using the carB reference.
// carB.Model = "Ford";

// 🛠️ PLAYGROUND CHALLENGE 2: Check the mutation leak.
// Uncomment the lines below to see how modifying 'carB' directly alters 'carA'.
// They point to the exact same dynamic slot on the Managed Heap!
// Console.WriteLine($"carA.Model: {carA.Model}");
// Console.WriteLine($"carB.Model: {carB.Model}");

// 🛠️ PLAYGROUND CHALLENGE 3: Prove Shared Reference Identity.
// Uncomment the lines below to check their runtime tracking identity hashes.
// Because they share a memory intersection on the Heap, their hashes are completely identical.
// Console.WriteLine($"carA Memory ID: #{System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(carA)}");
// Console.WriteLine($"carB Memory ID: #{System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(carB)}");