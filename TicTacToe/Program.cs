//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

#region Test
// string[] cellBoard = new string[19];
// byte cell = 1;
//for (byte i = 0; i < cellBoard.Length; i++)
//{

//    if(i%2 == 0 && i != 0 || i == 18)
//    {
//        cellBoard[i] = "|";
//    }
//    else if(i == 0)
//    {

//        Console.Clear();
//        Console.WindowHeight = 10;
//        Console.WindowWidth = 60;
//        Console.ForegroundColor = ConsoleColor.Yellow;
//        cellBoard[i] = Convert.ToString(cell);

//        continue;
//    }
//    else
//    {
//        cellBoard[i] = Convert.ToString(cell);
//        cell++;
//    }
//    Console.Write(cellBoard[i]);
//    if(i%6 == 0)
//    {
//        Console.WriteLine();

//    }
//}

//for (int i = 0; i < cellBoard.Length; i++)
//{
//    Console.Write("{0}", cellBoard);
//}
#endregion

// Programm

namespace TicTacToe
{
    class Program
    {
        static char[] board;
        static char currentPlayer;
        static bool isGameFinished;

        static void Main(string[] args)
        {
            InitializeGame();

            while (!isGameFinished)
            {
                DrawBoard();
                MakeMove();
                CheckGameStatus();
                ChangePlayer();
            }
        }

        static void InitializeGame()
        {
            board = new char[9];
            currentPlayer = 'X';
            isGameFinished = false;

            // Заполняем игровую доску пустыми клетками
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
        }

        static void MakeMove()
        {
            bool isValidMove = false;
            int position;

            do
            {
                Console.WriteLine("Ход игрока " + currentPlayer);
                Console.Write("Введите номер клетки (1-9): ");
                int.TryParse(Console.ReadLine(), out position);

                // Проверяем введенную позицию на корректность
                if (position >= 1 && position <= 9 && board[position - 1] == ' ')
                {
                    board[position - 1] = currentPlayer;
                    isValidMove = true;
                }
                else
                {
                    Console.WriteLine("Некорректный ход. Повторите попытку.");
                }
            } while (!isValidMove);
        }

        static void CheckGameStatus()
        {
            // Проверяем наличие выигрышной комбинации
            if (board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer ||
                board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer ||
                board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer ||
                board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer ||
                board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer ||
                board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer ||
                board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer ||
                board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer)
            {
                DrawBoard();
                Console.WriteLine("Игрок " + currentPlayer + " победил!");
                isGameFinished = true;
            }
            // Проверяем наличие ничьей
            else if (IsBoardFull())
            {
                DrawBoard();
                Console.WriteLine("Ничья!");
                isGameFinished = true;
            }
        }

        static bool IsBoardFull()
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == ' ')
                {
                    return false;
                }
            }
            return true;
        }

        static void ChangePlayer()
        {
            if (currentPlayer == 'X')
            {
                currentPlayer = 'O';
            }
            else
            {
                currentPlayer = 'X';
            }
        }
    }
}
