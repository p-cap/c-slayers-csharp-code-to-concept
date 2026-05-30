using System;

// Question 2: Struct Stack Frame Lifecycle
// This snippet evaluates memory allocation, physical storage scopes, and runtime reclamation rules for value types.
// Snippet execution block

public struct Point 
{ 
    public int X; 
    public int Y; 
}

// 📦 THE ACTION:
// Initializing a struct inside a method layout. The memory is carved out inline 
// directly on the current execution Stack Frame, completely bypassing the Managed Heap.
Point p = new Point() { X = 10, Y = 20 };

// 🛠️ PLAYGROUND CHALLENGE 1: Trace the bitwise snapshot behavior.
// Structs pass and assign copies by value. Uncomment the lines below to see how 'p2' 
// acts as a detached instance right on the Stack.
// Point p2 = p;
// p2.X = 999;
// Console.WriteLine($"Original p.X: {p.X} | Copied p2.X: {p2.X}");

// 🛠️ PLAYGROUND CHALLENGE 2: Witness Stack Identity Isolation.
// Uncomment the lines below to check the memory tracking hashes.
// Unlike classes, copying a struct generates two unique identity tokens instantly, proving no pointer overlap.
// Console.WriteLine($"p Identity ID : #{System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(p)}");
// Console.WriteLine($"p2 Identity ID: #{System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(p2)}");

// 🛠️ PLAYGROUND CHALLENGE 3: Internalize the closing brace constraint.
// When the containing method context hits its final closing brace '}', the entire local Stack Frame 
// pops off the execution pipeline. The space occupied by 'p' vanishes instantly without ever alerting the Garbage Collector.