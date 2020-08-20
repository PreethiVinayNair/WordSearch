using System;
using System.Data;
namespace WordSearch
{
    class Program
    {
        static char[,] Grid = new char[,] {
            {'C', 'P', 'K', 'X', 'O', 'I', 'G', 'H', 'S', 'F', 'C', 'H'},
            {'Y', 'G', 'W', 'R', 'I', 'A', 'H', 'C', 'Q', 'R', 'X', 'K'},
            {'M', 'A', 'X', 'I', 'M', 'I', 'Z', 'A', 'T', 'I', 'O', 'N'},
            {'E', 'T', 'W', 'Z', 'N', 'L', 'W', 'G', 'E', 'D', 'Y', 'W'},
            {'M', 'C', 'L', 'E', 'L', 'D', 'N', 'V', 'L', 'G', 'P', 'T'},
            {'O', 'J', 'A', 'A', 'V', 'I', 'O', 'T', 'E', 'E', 'P', 'X'},
            {'C', 'D', 'B', 'P', 'H', 'I', 'A', 'W', 'V', 'X', 'U', 'I'},
            {'L', 'G', 'O', 'S', 'S', 'B', 'R', 'Q', 'I', 'A', 'P', 'K'},
            {'E', 'O', 'I', 'G', 'L', 'P', 'S', 'D', 'S', 'F', 'W', 'P'},
            {'W', 'F', 'K', 'E', 'G', 'O', 'L', 'F', 'I', 'F', 'R', 'S'},
            {'O', 'T', 'R', 'U', 'O', 'C', 'D', 'O', 'O', 'F', 'T', 'P'},
            {'C', 'A', 'R', 'P', 'E', 'T', 'R', 'W', 'N', 'G', 'V', 'Z'}
        };

        static string[] Words = new string[]
        {
            "CARPET",
            "CHAIR",
            "DOG",
            "BALL",
            "DRIVEWAY",
            "FISHING",
            "FOODCOURT",
            "FRIDGE",
            "GOLF",
            "MAXIMIZATION",
            "PUPPY",
            "SPACE",
            "TABLE",
            "TELEVISION",
            "WELCOME",
            "WINDOW"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Word Search");

            for (int y = 0; y < 12; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    Console.Write(Grid[y, x]);
                    Console.Write(' ');
                }
                Console.WriteLine("");

            }

            Console.WriteLine("");
            Console.WriteLine("Found Words");
            Console.WriteLine("------------------------------");

     
            //Modified to send in the rowNum and ColNum
            FindWords();

            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }

        private static void FindWords()
        {
            //Find each of the words in the grid, outputting the start and end location of
            //each word, e.g.
            //PUPPY found at (10,7) to (10, 3) 


            //First get the row nd column length from the Grid.GridLength

            int rowLength = Grid.GetLength(0);
            int columnLength= Grid.GetLength(1);


            //Array Coordinates:Take (0,0) as the first offset
            //(-1,-1) North West (-1,0) West (-1,1) South West (0,-1) North (0,1) South (1,-1) North East (1,0) East (1,1) South East

            // Searching in all 8 direction
            int[] rowDirection = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] columnDirection = { -1, 0, 1, -1, 1, -1, 0, 1 };

            int rowStart, columnStart, rowEnd= 0, columnEnd =0;

            //Take each word in the Words and start checking 
            for (int eachWord = 0; eachWord <= Words.Length; eachWord++)
            {
                // Get each word in a string
                String word = Words[eachWord];
                int wordlength = word.Length;

                // Start with offset (0,0) to (ColNum,rowNum)
                for (int row = 0; row < rowLength; row++)
                {
                   for (int column = 0;column < columnLength; column++)
                        {
                        // the check starts here
                        if (Grid[row,column] == word[0])
                        {
                            rowStart = row;
                            columnStart = column;

                            // starting from (row, column) 
                            for (int offset = 0; offset < 8; offset++)
                            {
                                //for each co-ordinate, add the direction
                                //
                                int rowOffset = row + rowDirection[offset];
                                int columnOffset = column + columnDirection[offset];

                                int wordChar;

                                //Start checking each letter in the grid
                                for (wordChar = 1; wordChar < wordlength; wordChar++)
                                {
                                    //Check for out of bound, gave error for index out of bound exception
                                    if (rowOffset < 0 || columnOffset < 0 || rowOffset >= rowLength || columnOffset >= columnLength)
                                    {
                                        break;
                                    }

                                    //If the character in the grid does not match to the character in the Word, move on to next one
                                    if (Grid[rowOffset,columnOffset] != word[wordChar])
                                    {
                                        break;
                                    }                               

                                    //Get the values and save it to find the end row and column
                                    rowEnd = rowOffset;
                                    columnEnd =columnOffset;

                                    // Next target
                                    rowOffset += rowDirection[offset];
                                    columnOffset += columnDirection[offset];
                                }

                                //Check for WordLength and Word Char Length are equal to print
                                if (wordChar == wordlength)
                                {
                                    Console.WriteLine(word + " found at (" + columnStart + "," + rowStart + ") to (" + columnEnd + "," + rowEnd + ")");
                                    break;
                                }
                            }


                        }
                    }
                }
            }
        }
    }

}
