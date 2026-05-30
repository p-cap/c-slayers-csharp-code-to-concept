// Question 3: The Value Type Snapshot Mutation
// This snippet verifies the structural isolation between values on the Stack and reference envelopes on the Heap.
// Snippet execution block

int mana = 50;

// 📦 THE ACTION:
// Capture a snapshot copy of the primitive onto the Managed Heap inside a reference wrapper.
object boxedMana = mana; 

// 🛠️ PLAYGROUND CHALLENGE 1: Mutate the original variable on the Stack frame.
// Uncomment the line below to change the local stack value.
// mana = 99; 

// 🛠️ PLAYGROUND CHALLENGE 2: Inspect the value state separation.
// Uncomment the lines below to print both values after the change.
// Notice that the data inside 'boxedMana' does not update automatically!
// Console.WriteLine($"Stack Variable (mana): {mana}");
// Console.WriteLine($"Heap Box Wrapper (boxedMana): {boxedMana}");

// 🛠️ PLAYGROUND CHALLENGE 3: Check Memory Identities to prove total isolation.
// Uncomment the lines below to verify that boxing created a completely separate data instance.
// Modifying 'mana' on the Stack will generate a brand new runtime tracking hash, 
// proving it shares no shared address intersection with the static 'boxedMana' object on the Heap.
// Console.WriteLine($"Original Stack Identity: #{RuntimeHelpers.GetHashCode(mana)}");
// Console.WriteLine($"Isolated Heap Identity:  #{RuntimeHelpers.GetHashCode(boxedMana)}");

