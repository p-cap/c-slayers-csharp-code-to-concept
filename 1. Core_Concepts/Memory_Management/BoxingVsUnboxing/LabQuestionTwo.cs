// Question 2: The Direct Unboxing Attempt
// This snippet evaluates the structural type-matching rules enforced by the runtime engine during pointer extraction.
// Snippet execution block

int health = 100;

// 📦 THE ACTION:
// Explicitly box the Int32 value type to a Heap reference object.
object boxedHealth = health; 

// 🛠️ PLAYGROUND CHALLENGE 1: Observe the Direct Type-Mismatch Crash.
// Uncomment the line below to test a direct extraction into a different size primitive.
// Even though 100 fits in a short, this will immediately throw a System.InvalidCastException
// because the CLR unboxing engine demands an exact data structure match.
// short damage = (short)boxedHealth; 

// 🛠️ PLAYGROUND CHALLENGE 2: Inspect the underlying Type Descriptor hidden on the Heap.
// Uncomment the line below to prove the Heap object explicitly tracks its origin type,
// which is why the execution engine blocks the direct short (Int16) extraction layout mapping.
// Console.WriteLine($"Actual Heap Object Type: {boxedHealth.GetType().FullName}");

// 🛠️ PLAYGROUND CHALLENGE 3: Implement the Safe Two-Step Extraction Bypass.
// Uncomment the two lines below to see how to satisfy the runtime. 
// You must unbox to the exact primitive type on the Stack first, then cast it normally.
// short safeDamage = (short)(int)boxedHealth; 
// Console.WriteLine($"Successfully extracted via explicit bypass: {safeDamage}");