using System.Collections;

// Question 1: The Legacy Collection Loop
// This snippet demonstrates implicit boxing within loops when using non-generic data structures.
// Snippet execution block

ArrayList list = new ArrayList();

for (int i = 0; i < 1000; i++)
{
    // 🛠️ PLAYGROUND CHALLENGE 1: Inspect the primitive Type before it enters the list.
    // Uncomment the line below to see what 'i' is on the Stack:
    // Console.WriteLine($"Before Add: 'i' is Type = {i.GetType().FullName}");

    // 📦 THE ACTION:
    // ArrayList.Add() accepts an 'object'. Passing 'i' (Int32) forces the CLR 
    // to allocate a box on the Heap, copy 0, 1, 2... into it, and store the pointer.

    // 🛠️ PLAYGROUND CHALLENGE 2: Check the type inside the ArrayList collection.
    // Notice that list[i] returns an 'object', but its underlying instance metadata 
    // still remembers it was originally an Int32.
    // Console.WriteLine($"After Add : Element inside list is Type = {list[i]!.GetType().FullName}");

    // 🛠️ PLAYGROUND CHALLENGE 3: Prove Heap allocation using Memory Identities.
    // Every time an object is boxed, it gets a unique memory envelope identity hash.
    // If you uncomment the line below, you will see completely unique hashes for every single index, 
    // proving 5 distinct dynamic chunks of memory were claimed on the Heap:

    // The Add method expects 'object' values
    list.Add(i); 
}