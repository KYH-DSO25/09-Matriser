/*
 * 2.   Skriv ett program som läser in en rektangulär matris av storleken N x M och i den 
 *      hittar en kvadrat 3 x 3 som har den största summan av sina element
 */

// ENKLARE ANVÄNDNING: Programmet har en testmetod som visar hur programmet fungerar med
// olika indata.
// Metoden som testar programmet heter "TestRunner"


int bestSum = 0, bestRow = 0, bestCol = 0;

// Exempeldata:
int[,] matrix =
{
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 2, 2, 2, 1 },
            { 1, 2, 2, 2, 1 },
            { 1, 2, 2, 2, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 }
        };

FindBestSquare3x3(matrix, ref bestRow, ref bestCol, ref bestSum);
PrintMatrix (matrix);
PrintBestSquare3x3(matrix, bestRow, bestCol, bestSum);

TestRunner();


Console.Write("Tryck på en tangent för att stänga fönstret...");
Console.ReadKey();





void FindBestSquare3x3(int[,] matrix, ref int bestRow, ref int bestCol, ref int bestSum)
{
    for (int row = 0; row < matrix.GetLength(0) - 2; row++)
    {
        for (int col = 0; col < matrix.GetLength(1) - 2; col++)
        {
            int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                             matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                             matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

            if ( currentSum > bestSum)
            {
                bestSum = currentSum;
                bestRow = row;
                bestCol = col;
            }
        }
    }
}

void PrintMatrix(int[,] matrix)
{
    Console.WriteLine("Matris:\n");

    for (int row = 0; row < matrix.GetLongLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLongLength(1); col++)
            Console.Write("{0,4}", matrix[row, col]);
        Console.WriteLine();
    }
}

void PrintBestSquare3x3(int[,] matrix, int bestRow, int bestCol, int bestSum)
{
    Console.WriteLine("\nBästa kvadraten med summan {0}: \n", bestSum);

    for (int i = bestRow; i < bestRow + 3; i++)
    {
        for (int j = bestCol; j < bestCol + 3; j++)
            Console.Write("{0,4}", matrix[i, j]);
        Console.WriteLine();
    }
    Console.WriteLine();
}

void TestRunner()
{
    Console.WriteLine(new string('-', 40));

    int bestSum = 0, bestRow = 0, bestCol = 0;

    int[,] matrix =
    {
            { 1, 1, 1, 1, 1, 3, 3, 3 },
            { 1, 1, 1, 1, 1, 3, 3, 3 },
            { 1, 1, 1, 1, 1, 3, 3, 3 },
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1 }
        };

    FindBestSquare3x3(matrix, ref bestRow, ref bestCol, ref bestSum);
    PrintMatrix(matrix);
    PrintBestSquare3x3(matrix, bestRow, bestCol, bestSum);

    Console.WriteLine(new string('-', 40));

    bestSum = bestCol = bestRow = 0;

    matrix = new int[,]
    {
            { 2, 2, 1, 1, 1, 1, 1 },
            { 2, 2, 1, 1, 1, 1, 1 },
            { 2, 2, 1, 1, 4, 4, 4 },
            { 2, 2, 1, 1, 4, 4, 4 },
            { 2, 2, 1, 1, 4, 4, 4 }
    };

    FindBestSquare3x3(matrix, ref bestRow, ref bestCol, ref bestSum);
    PrintMatrix(matrix);
    PrintBestSquare3x3(matrix, bestRow, bestCol, bestSum);

    Console.WriteLine(new string('-', 40));

    bestSum = bestCol = bestRow = 0;

    matrix = new int[,]
    {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 5, 5, 5, 4, 4, 4, 3, 3, 3 },
            { 5, 5, 5, 4, 4, 4, 3, 3, 3 },
            { 5, 5, 5, 4, 4, 4, 3, 3, 3 },
            { 2, 2, 2, 2, 2, 2, 2, 2, 2 }
    };

    FindBestSquare3x3(matrix, ref bestRow, ref bestCol, ref bestSum);
    PrintMatrix(matrix);
    PrintBestSquare3x3(matrix, bestRow, bestCol, bestSum);

    Console.WriteLine(new string('-', 40));
}

