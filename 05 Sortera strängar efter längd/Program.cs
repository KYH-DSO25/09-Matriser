/*
*   5.  Du får en vektor med strängar. Skriv en metod som sorterar vektorn efter 
*       längden på de ingående elementen, med det kortaste först
*/


Console.Write("Ange storleken på vektorn (N): ");
int n = int.Parse(Console.ReadLine());

string[] elements = new string[n];
Console.WriteLine("\nAnge {0} strängar att stoppa in i vektorn: ", n);

for (int i = 0; i < elements.Length; i++)
{
    Console.Write("   {0}: ", i + 1);
    elements[i] = Console.ReadLine();
}

Console.WriteLine("\nFöre sortering: {0}", string.Join(" ", elements));

SelectionSortByLength(ref elements);

Console.WriteLine("\nEfter sortering: {0}", string.Join(" ", elements));


Console.Write("Tryck på en tangent för att stänga fönstret...");
Console.ReadKey();


void SelectionSortByLength(ref string[] elements)
{
    for (int i = 0; i < elements.Length; i++)
    {
        int index = i;

        for (int j = i + 1; j < elements.Length; j++)
        {
            if (elements[j].Length < elements[index].Length)
            {
                index = j;
            }
        }
        string swap = elements[i];
        elements[i] = elements[index];
        elements[index] = swap;
    }
}
