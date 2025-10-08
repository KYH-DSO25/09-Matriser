/*
*   4.  Skriv ett program som från konsolen läser en vektor av N heltal och ett heltal K. 
*       Vektorn sorteras. Sedan används metoden Array.BinarySearch() för att hitta 
*       det största talet som är ≤ K
*/



Console.Write("Ange storleken på vektorn (N): ");
int n = int.Parse(Console.ReadLine());

Console.Write("Ange ett tal K: ");
int k = int.Parse(Console.ReadLine());

int[] numbers = new int[n];
Console.WriteLine("\nAnge {0} tal att lägga in i vektorn: ", n );
for (int i = 0; i < numbers.Length; i++)
{
    Console.Write("    {0}: ", i + 1);
    numbers[i] = int.Parse(Console.ReadLine());
}

PrintLargestNumber(numbers, k);

Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
Console.ReadKey();


// Skriver ut största talet som är <= k med hjälp av metoden Array.BinarySearch()
void PrintLargestNumber(int[] numbers, int k)
{
    Array.Sort(numbers);

    int index = Array.BinarySearch(numbers, k);
    index = index >= 0 ? index : (index == -1 ? -1 : Math.Abs(index + 2));

    if (index != -1)
    {
        Console.WriteLine("\nHittade tal <= K: {0}", k);
        Console.WriteLine("  -> Resultat: {0}\n", numbers[index]);
    }
    else
    {
        Console.WriteLine("\n - Det finns inga tal <= K, {0}, i vektorn", k);
        Console.WriteLine("index = {0}", index);
    }
}

