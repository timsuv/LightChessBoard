using System.ComponentModel.Design;

//Timofey Suvorov, NET2024
namespace ChessBoard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 0;
            //making char empty to get the value later
            char black = '\0';
            char white = '\0';
            char piece = '\0';
            string position = null;


            //unicode to show the squares, and setting a unicode standard output
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("Mata in storleken på schackbrädet!");

            //bool to check if the input is correct
            bool validSize = false;
            //while loop that check for an int and not another value
            while (!validSize)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out size) && size > 0)
                {
                    validSize = true;
                }
                else
                {
                    Console.WriteLine("Ange ett tal och inte nåt annat");
                }
            }


            Console.WriteLine("Hur ska svarta rutor ser ut?");
            bool validBlackChar = false;
            while (!validBlackChar)
            {
                string input = Console.ReadLine();
                if (char.TryParse(input, out black))
                {
                    validBlackChar = true;
                }
                else
                {
                    Console.WriteLine("Ange endast ett tecken!");
                }
            }

            Console.WriteLine("Hur ska vita rutor ser ut?");
            bool validWhiteChar = false;
            while (!validWhiteChar)
            {
                string input = Console.ReadLine();
                if (char.TryParse(input, out white))
                {
                    validWhiteChar = true;
                }
                else
                {
                    Console.WriteLine("Ange endast ett tecken!");
                }
            }

            Console.WriteLine("Hur ska pjäsen se ut?");
            bool validPieceChar = false;
            while (!validPieceChar)
            {
                string input = Console.ReadLine();
                if (char.TryParse(input, out piece))
                {
                    validPieceChar = true;
                }
                else
                {
                    Console.WriteLine("Ange endast ett tecken!");
                }
            }

            Console.WriteLine("Var ska pjäsen stå? (EX. E4)");

            //converting the input to the grid
            bool validPosition = false;
            int column = -1;
            int row = -1;

            while (!validPosition)
            {
                string input = Console.ReadLine().ToUpper().Trim();
                if (input.Length == 2 && char.IsLetter(input[0]) && char.IsDigit(input[1]))
                {
                    //convert the first char to a column and the int to the row
                    column = input[0] - 'A';
                    row = size - (input[1] - '0');
                    //check if the coordinates are suitable for the size of the chessboard
                    if (column < size && row >= 0 && row < size)
                    {
                        validPosition = true;
                        position = input;
                    }
                    else
                    {
                        Console.WriteLine("Placering är utanför shackbrädda, ange korrekt palcering");
                    }


                }
                else
                {
                    Console.WriteLine("Ange endast två tecken som i exemplet");
                }
            }


            //for loop to alternare between the whites and blacs
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == row && j == column)
                    {
                        Console.Write(piece);
                    }

                    else
                    {
                        //if statement with a modulus to calculate the color of the position

                        if ((i + j) % 2 == 0)
                        {

                            Console.Write(black);
                        }
                        else
                        {
                            Console.Write(white);
                        }
                    }

                }
                Console.WriteLine();
            }

        }
    }
}

