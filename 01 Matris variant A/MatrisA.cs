/*
* 1a.   Skriv ett program som fyller och skriver ut en matris av storleken (n, n) enligt nedan:
*       (exempel för n = 4)
* 
*        1  5   9  13
*        2  6  10  14
*        3  7  11  15
*        4  8  12  16
* 
*/

Console.Write("Ange storleken på matrisen: ");
int n = int.Parse(Console.ReadLine());

int[,] matrix = new int[n, n];

for (int row = 0, count = 1; row < n; row++)
{
    for (int col = 0; col < n; col++)
    {
        matrix[col, row] = count++;
    }
}

// Skriv ut matrisen
for (int row = 0; row < n; row++)
{
    for(int col = 0; col < n; col++)
    {
        Console.Write("{0, 4}", matrix[row, col]);
    }
    Console.WriteLine("\n");
}


Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
Console.ReadKey();