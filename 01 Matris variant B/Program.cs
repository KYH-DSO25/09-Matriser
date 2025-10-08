/*
* 1b.   Skriv ett program som fyller och skriver ut en matris av storleken (n, n) enligt nedan:
*       (exempel för n = 4)
* 
*        1  8   9  16
*        2  7  10  15
*        3  6  11  14
*        4  5  12  13
* 
*/

Console.Write("Ange storleken på matrisen: ");
int n = int.Parse(Console.ReadLine());

int[,] matrix = new int[n, n];
bool isDirsDown = true;

for (int col = 0, row = 0, count = 1; col < n; col++)
{
    while (row >= 0 && row < n)
    {
        matrix[row, col] = count++;
        row += isDirsDown ? +1 : -1;    // Justera värdet för radnummer
    }
    // Byt riktning och ändra radnummer
    isDirsDown = !isDirsDown;           // Byt riktning
    row += (isDirsDown) ? +1 : -1;
}

// Skriv ut matrisen
for (int row = 0; row < n; row++)
{
    for (int col = 0; col < n; col++)
    {
        Console.Write("{0, 4}", matrix[row, col]);
    }
    Console.WriteLine("\n");
}

Console.Write("Tryck på en tangent för att stänga fönstret...");
Console.ReadKey();