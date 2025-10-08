/*
* 1c.   Skriv ett program som fyller och skriver ut en matris av storleken (n, n) enligt nedan:
*       (exempel för n = 4)
* 
*        1 12 11 10
*        2 13 16  9
*        3 14 15  8
*        4  5  6  7
* 
*/


Console.Write("Ange storleken på matrisen: ");
int n = int.Parse(Console.ReadLine());

int[,] matrix = new int[n, n];
string direction = "down";
int row = -1, col = 0;

for (int count = 1; count <= n * n; count++)
{
    if (direction == "down")
    {
        if (matrix[++row, col] == 0) matrix[row, col] = count;
        if (!IsTraversable(row + 1, col)) direction = "right";
    }
    else if (direction == "right")
    {
        if (matrix[row, ++col] == 0) matrix[row, col] = count;
        if (!IsTraversable(row, col + 1)) direction = "up";
    }
    else if (direction == "up")
    {
        if (matrix[--row, col] == 0) matrix[row, col] = count;
        if (!IsTraversable(row - 1, col)) direction = "left";
    }
    else if (direction == "left")
    {
        if (matrix[row, --col] == 0) matrix[row, col] = count;
        if (!IsTraversable(row, col - 1)) direction = "down";
    }
}

// Skriv ut matrisen
for (row = 0; row < n; row++)
{
    for (col = 0; col < n; col++)
    {
        Console.Write("{0, 4}", matrix[row, col]);
    }
    Console.WriteLine("\n");
}





Console.Write("Tryck på en tangent för att stänga fönstret...");
Console.ReadKey();



bool IsTraversable(int row, int col)
{
    return row >= 0 && row < matrix.GetLength(0) &&
            col >= 0 && col < matrix.GetLength(1) && matrix[row, col] == 0;
}
