/*
 * 3.   Vi har en matris av strängar av storleken N x M. 
 *      Vi definierar sekvenser i matrisen som grupper av grannelement på 
 *      samma rad, kolumn eller diagonal. 
 *      Skriv ett program som hittar den längsta sekvensen av identiska strängar i matrisen. 
 *      
 *      :
 *        Exempel:         |        Exempel:
 *   ------------------    |    ----------------
 *   | ha  fi  ho  hi |    |    |   ss qq ss   |
 *   | fo  ha  hi  xx |    |    |   pp pp ss   |
 *   | xx  ho  ha  xx |    |    |   pp qq ss   |
 *   ------------------    |    ----------------
 *   Resultat: ha, ha, ha  |   Resultat: ss, ss, ss
 *                         |
 */

// ENKLARE ANVÄNDNING: Programmet har en testmetod som visar hur programmet fungerar med
// olika indata.
// Metoden som testar programmet heter "TestRunner"

//      4                        LOWER      UPPER
//  DIRECTIONS:        RIGHT    DIAGONAL   DIAGONAL    DOWN

int[,] directions = { { 0, 1 }, { 1, 1 }, { -1, 1 }, { 1, 0 } };

int bestLength = 0;
string bestElement = string.Empty;

string[,] matrix =
{
            { "ha", "fi", "ho", "hi" },
            { "fo", "ha", "hi", "xx" },
            { "xx", "ho", "ha", "xx" }
        };

PrintMatrix(matrix);
FindLongestSequence(matrix, ref bestElement, ref bestLength);
PrintResult(bestElement, bestLength);

TestRunner();



Console.Write("Tryck på en tangent för att stänga fönstret...");
Console.ReadKey();


void FindLongestSequence(string[,] matrix, ref string bestElement, ref int bestLength)
{
    for(int row = 0; row < matrix.GetLength(0); row++)
    {
        for(int col = 0; col < matrix.GetLength(1); col++)
        {
            int direction = -1;
            while (++direction < 4)
            {
                int _row = row + directions[direction, 0];
                int _col = col + directions[direction, 1];
                int currentLength = 1;

                while (IsTraversable(matrix, row, col, _row, _col))
                {
                    currentLength++;

                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                        bestElement = matrix[row, col];
                    }

                    _row += directions[direction, 0];
                    _col += directions[direction, 1];
                }
            }
        }
    }
}



void PrintMatrix(string[,] matrix)
{
    Console.WriteLine("Matrix:\n");
    for (int row = 0; row < matrix.GetLongLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLongLength(1); col++)
            Console.Write("{0,4}", matrix[row, col]);
        Console.WriteLine();
    }
}

bool IsTraversable(string[,] matrix, int row, int col, int _row, int _col)
{
    return _row >= 0 && _row < matrix.GetLongLength(0) &&
            _col >= 0 && _col < matrix.GetLongLength(1) &&
            matrix[_row, _col] == matrix[row, col];
}

void PrintResult(string bestElement, int bestLength)
{
    Console.WriteLine("\nResultat -> {0} ({1} gånger)\n",
        String.Concat(Enumerable.Repeat(bestElement + " ", bestLength)), bestLength);
}

void TestRunner()
{
    Console.WriteLine(new string('-', 40) + "\n");

    int bestLength = 0; string bestElement = string.Empty;

    string[,] test0 =
    {
            { "ss", "qq", "ss" },
            { "pp", "pp", "ss" },
            { "pp", "qq", "ss" }
        };

    PrintMatrix(test0);
    FindLongestSequence(test0, ref bestElement, ref bestLength);
    PrintResult(bestElement, bestLength);

    Console.WriteLine(new string('-', 40) + "\n");

    bestLength = 0; bestElement = string.Empty;

    string[,] test1 =
    {
            { "a", "a", "a", "a", "H" },
            { "a", "a", "a", "H", "a" },
            { "a", "a", "H", "a", "a" },
            { "a", "H", "a", "a", "a" },
            { "H", "a", "a", "a", "a" }
        };

    PrintMatrix(test1);
    FindLongestSequence(test1, ref bestElement, ref bestLength);
    PrintResult(bestElement, bestLength);

    Console.WriteLine(new string('-', 40) + "\n");

    bestLength = 0; bestElement = string.Empty;

    string[,] test2 =
    {
            { "H", "H", "H", "H", "H" },
            { "b", "c", "a", "a", "b" },
            { "b", "d", "c", "d", "b" },
            { "b", "a", "a", "c", "b" },
            { "b", "d", "d", "d", "b" },
            { "b", "a", "a", "a", "b" }
        };

    PrintMatrix(test2);
    FindLongestSequence(test2, ref bestElement, ref bestLength);
    PrintResult(bestElement, bestLength);

    Console.WriteLine(new string('-', 40));

    bestLength = 0; bestElement = string.Empty;

    string[,] test3 =
    {
            { "H", "b", "d", "d", "d", "b" },
            { "b", "H", "a", "a", "a", "b" },
            { "b", "d", "H", "d", "d", "b" },
            { "b", "a", "a", "H", "a", "b" },
            { "b", "d", "d", "d", "H", "b" },
            { "b", "a", "a", "a", "a", "H" }
        };

    PrintMatrix(test3);
    FindLongestSequence(test3, ref bestElement, ref bestLength);
    PrintResult(bestElement, bestLength);

    Console.WriteLine(new string('-', 40) + "\n");
}
