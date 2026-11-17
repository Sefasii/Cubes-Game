using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,,] board = new int[,,]
            {
                { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } }, // Ön Yüz
                { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } }, // İkinci Yüz
                { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 5, 0, 0, 0, 6 }, { 5, 5, 0, 0, 6 } }, // Üçüncü Yüz
                { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 5, 0, 0, 0, 7 }, { 1, 0, 0, 6, 6 } }, // Dördüncü Yüz
                { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 1, 2, 0, 7, 7 }, { 1, 2, 2, 2, 7 } } // Arka Yüz
            };
            int[,,] cursor = new int[,,]
            {
                { { 0, 0, 0 }, { 0, 0, 0 }, {0, 4, 4 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, {4, 4, 0 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, {0, 0, 0 } }
            };
            int[,,] piece1 = new int[,,]
            {
                { { 0, 0, 0 }, { 1, 0, 0 }, { 1, 1, 0 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }
            };
            int[,,] piece2 = new int[,,]
            {
                { { 0, 0, 0 }, { 2, 0, 0 }, { 2, 2, 2 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }
            };
            int[,,] piece3 = new int[,,]
            {
                { { 0, 0, 0 }, { 0, 3, 0 }, { 3, 3, 3 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }
            };
            int[,,] piece4 = new int[,,]
            {
                { { 0, 0, 0 }, { 0, 4, 4 }, { 4, 4, 0 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }
            };
            int[,,] piece5 = new int[,,]
            {
                { { 0, 0, 0 }, { 5, 0, 0 }, { 5, 0, 0 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 5, 5, 0 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }
            };
            int[,,] piece6 = new int[,,]
            {
                { { 0, 0, 0 }, { 0, 0, 0 }, { 6, 6, 0 } },
                { { 0, 0, 0 }, { 6, 0, 0 }, { 6, 0, 0 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }
            };
            int[,,] piece7 = new int[,,]
            {
                { { 0, 0, 0 }, { 7, 0, 0 }, { 7, 7, 0 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 7, 0, 0 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }
            };
            int[,,] puzzle = new int[,,]
            {
                { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 1, 1, 1, 0, 0 }, { 1, 1, 1, 0, 0 } }, // Ön Yüz
                { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 1, 0, 0, 0, 0 }, { 1, 0, 0, 0, 0 }, { 1, 1, 1, 0, 0 } }, // İkinci Yüz
                { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 1, 0, 0, 0, 0 }, { 1, 0, 0, 0, 0 }, { 1, 1, 1, 0, 0 } }, // Üçüncü Yüz
                { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 1, 0, 0, 0, 0 }, { 1, 0, 0, 0, 0 }, { 1, 1, 1, 0, 0 } }, // Dördüncü Yüz
                { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 1, 1, 1, 0, 0 }, { 1, 1, 1, 0, 0 } } // Arka Yüz
            };
            //Console.Write("Enter the piece that you want to place: ");
            int number = 0; //= Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                default:
                    {
                        //Console.WriteLine("Please enter a valid input!");
                        break;
                    }
                case 1:
                    {
                        for (int i = 0; i < piece1.GetLength(0); i++)
                        {
                            for (int j = 0; j < piece1.GetLength(1); j++)
                            {
                                for (int k = 0; k < piece1.GetLength(2); k++)
                                {
                                    cursor[i, j, k] = piece1[i, j, k];
                                    if (cursor[i, j, k] == 0)
                                        Console.Write(".");
                                    else
                                        Console.Write(cursor[i, j, k]);
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < piece2.GetLength(0); i++)
                        {
                            for (int j = 0; j < piece2.GetLength(1); j++)
                            {
                                for (int k = 0; k < piece2.GetLength(2); k++)
                                {
                                    cursor[i, j, k] = piece2[i, j, k];
                                    if (cursor[i, j, k] == 0)
                                        Console.Write(".");
                                    else
                                        Console.Write(cursor[i, j, k]);
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < piece3.GetLength(0); i++)
                        {
                            for (int j = 0; j < piece3.GetLength(1); j++)
                            {
                                for (int k = 0; k < piece3.GetLength(2); k++)
                                {
                                    cursor[i, j, k] = piece3[i, j, k];
                                    if (cursor[i, j, k] == 0)
                                        Console.Write(".");
                                    else
                                        Console.Write(cursor[i, j, k]);
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < piece4.GetLength(0); i++)
                        {
                            for (int j = 0; j < piece4.GetLength(1); j++)
                            {
                                for (int k = 0; k < piece4.GetLength(2); k++)
                                {
                                    cursor[i, j, k] = piece4[i, j, k];
                                    if (cursor[i, j, k] == 0)
                                        Console.Write(".");
                                    else
                                        Console.Write(cursor[i, j, k]);
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
                case 5:
                    {
                        for (int i = 0; i < piece5.GetLength(0); i++)
                        {
                            for (int j = 0; j < piece5.GetLength(1); j++)
                            {
                                for (int k = 0; k < piece5.GetLength(2); k++)
                                {
                                    cursor[i, j, k] = piece5[i, j, k];
                                    if (cursor[i, j, k] == 0)
                                        Console.Write(".");
                                    else
                                        Console.Write(cursor[i, j, k]);
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
                case 6:
                    {
                        for (int i = 0; i < piece6.GetLength(0); i++)
                        {
                            for (int j = 0; j < piece6.GetLength(1); j++)
                            {
                                for (int k = 0; k < piece6.GetLength(2); k++)
                                {
                                    cursor[i, j, k] = piece6[i, j, k];
                                    if (cursor[i, j, k] == 0)
                                        Console.Write(".");
                                    else
                                        Console.Write(cursor[i, j, k]);
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
                case 7:
                    {
                        for (int i = 0; i < piece7.GetLength(0); i++)
                        {
                            for (int j = 0; j < piece7.GetLength(1); j++)
                            {
                                for (int k = 0; k < piece7.GetLength(2); k++)
                                {
                                    cursor[i, j, k] = piece7[i, j, k];
                                    if (cursor[i, j, k] == 0)
                                        Console.Write(".");
                                    else
                                        Console.Write(cursor[i, j, k]);
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
            }
            Console.SetCursorPosition(10, 0);
            Console.Write(".");
            Console.SetCursorPosition(40, 0);
            Console.Write(".");
            Console.SetCursorPosition(0, 10);
            Console.Write(".");
            Console.SetCursorPosition(30, 10);
            Console.Write(".");
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(10 + i * 6, 15);
                Console.Write(".");
            }
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(8 + i * 6, 17);
                Console.Write(".");
            }
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(6 + i * 6, 19);
                Console.Write(".");
            }
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(4 + i * 6, 21);
                Console.Write(".");
            }
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(2 + i * 6, 23);
                Console.Write(".");
            }
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(i * 6, 25);
                Console.Write(".");
            }
            for (int i = 0; i < board.GetLength(1); i++) // Satır Döngüsü
            {
                for (int j = 0; j < board.GetLength(0); j++) // Yüz Döngüsü
                {
                    for (int k = 0; k < board.GetLength(2); k++) // Sütun Döngüsü
                    {
                        if (board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] != 0)
                        {
                            Console.SetCursorPosition(2 + (board.GetLength(1) - 1 - i) * 2 + k * 6 - j * 2 + 2 * i, (board.GetLength(0) - 1 + j) * 3 - i * 3 - j);
                            Console.Write("+-----+");
                            Console.SetCursorPosition(1 + (board.GetLength(1) - 1 - i) * 2 + k * 6 - j * 2 + 2 * i, 1 + (board.GetLength(0) - 1 + j) * 3 - i * 3 - j);
                            Console.Write("/     /|");
                            Console.SetCursorPosition((board.GetLength(1) - 1 - i) * 2 + k * 6 - j * 2 + 2 * i, 2 + (board.GetLength(0) - 1 + j) * 3 - i * 3 - j);
                            Console.Write("+-----+ |");
                            Console.SetCursorPosition((board.GetLength(1) - 1 - i) * 2 + k * 6 - j * 2 + 2 * i, 3 + (board.GetLength(0) - 1 + j) * 3 - i * 3 - j);
                            Console.Write("| " + board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] + " " + board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] + " | +");
                            Console.SetCursorPosition((board.GetLength(1) - 1 - i) * 2 + k * 6 - j * 2 + 2 * i, 4 + (board.GetLength(0) - 1 + j) * 3 - i * 3 - j);
                            Console.Write("| " + board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] + " " + board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] + " |/");
                            Console.SetCursorPosition((board.GetLength(1) - 1 - i) * 2 + k * 6 - j * 2 + 2 * i, 5 + (board.GetLength(0) - 1 + j) * 3 - i * 3 - j);
                            Console.Write("+-----+");
                        }
                    }
                }
            }
            for (int i = 0; i < board.GetLength(0); i++) // Yüz Döngüsü
            {
                Console.SetCursorPosition(44 + i * 7, 0);
                for (int j = 0; j < board.GetLength(1); j++) // Satır Döngüsü
                {
                    for (int k = 0; k < board.GetLength(2); k++) // Sütun Döngüsü
                    {
                        if (board[i, j, k] == 0)
                            Console.Write(".");
                        else
                            Console.Write(board[i, j, k]);
                    }
                    Console.SetCursorPosition(44 + i * 7, j + 1);
                }
            }
            Console.SetCursorPosition(0, 26);
            Console.Write("------------------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(10, 27);
            Console.Write(".");
            Console.SetCursorPosition(40, 27);
            Console.Write(".");
            Console.SetCursorPosition(0, 37);
            Console.Write(".");
            Console.SetCursorPosition(30, 37);
            Console.Write(".");
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(10 + i * 6, 42);
                Console.Write(".");
            }
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(8 + i * 6, 44);
                Console.Write(".");
            }
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(6 + i * 6, 46);
                Console.Write(".");
            }
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(4 + i * 6, 48);
                Console.Write(".");
            }
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(2 + i * 6, 50);
                Console.Write(".");
            }
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(i * 6, 52);
                Console.Write(".");
            }
            for (int i = 0; i < puzzle.GetLength(1); i++) // Satır Döngüsü
            {
                for (int j = 0; j < puzzle.GetLength(0); j++) // Yüz Döngüsü
                {
                    for (int k = 0; k < puzzle.GetLength(2); k++) // Sütun Döngüsü
                    {
                        if (puzzle[puzzle.GetLength(0) - 1 - j, puzzle.GetLength(1) - 1 - i, k] != 0)
                        {
                            Console.SetCursorPosition(2 + (puzzle.GetLength(1) - 1 + 3 * k - j) * 2, 27 + (puzzle.GetLength(0) - 1 + j - i) * 3 - j);
                            Console.Write("+-----+");
                            Console.SetCursorPosition(1 + (puzzle.GetLength(1) - 1 + 3 * k - j) * 2, 28 + (puzzle.GetLength(0) - 1 + j - i) * 3 - j);
                            Console.Write("/     /|");
                            Console.SetCursorPosition((puzzle.GetLength(1) - 1 + 3 * k - j) * 2, 29 + (puzzle.GetLength(0) - 1 + j - i) * 3 - j);
                            Console.Write("+-----+ |");
                            Console.SetCursorPosition((puzzle.GetLength(1) - 1 + 3 * k - j) * 2, 30 + (puzzle.GetLength(0) - 1 + j - i) * 3 - j);
                            Console.Write("| " + puzzle[puzzle.GetLength(0) - 1 - j, puzzle.GetLength(1) - 1 - i, k] + " " + puzzle[puzzle.GetLength(0) - 1 - j, puzzle.GetLength(1) - 1 - i, k] + " | +");
                            Console.SetCursorPosition((puzzle.GetLength(1) - 1 + 3 * k - j) * 2, 31 + (puzzle.GetLength(0) - 1 + j - i) * 3 - j);
                            Console.Write("| " + puzzle[puzzle.GetLength(0) - 1 - j, puzzle.GetLength(1) - 1 - i, k] + " " + puzzle[puzzle.GetLength(0) - 1 - j, puzzle.GetLength(1) - 1 - i, k] + " |/");
                            Console.SetCursorPosition((puzzle.GetLength(1) - 1 + 3 * k - j) * 2, 32 + (puzzle.GetLength(0) - 1 + j - i) * 3 - j);
                            Console.Write("+-----+");
                        }
                    }
                }
            }
            for (int i = 0; i < puzzle.GetLength(0); i++) // Yüz Döngüsü
            {
                Console.SetCursorPosition(44 + i * 7, 27);
                for (int j = 0; j < puzzle.GetLength(1); j++) // Satır Döngüsü
                {
                    for (int k = 0; k < puzzle.GetLength(2); k++) // Sütun Döngüsü
                    {
                        if (puzzle[i, j, k] == 0)
                            Console.Write(".");
                        else
                            Console.Write(puzzle[i, j, k]);
                    }
                    Console.SetCursorPosition(44 + i * 7, j + 28);
                }
            }
            Console.SetCursorPosition(61, 10);
            Console.Write(".");
            Console.SetCursorPosition(79, 10);
            Console.Write(".");
            Console.SetCursorPosition(55, 16);
            Console.Write(".");
            Console.SetCursorPosition(73, 16);
            Console.Write(".");
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(61 + i * 6, 19);
                Console.Write(".");
            }
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(59 + i * 6, 21);
                Console.Write(".");
            }
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(57 + i * 6, 23);
                Console.Write(".");
            }
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(55 + i * 6, 25);
                Console.Write(".");
            }
            for (int i = 0; i < cursor.GetLength(1); i++) // Satır Döngüsü
            {
                for (int j = 0; j < cursor.GetLength(0); j++) // Yüz Döngüsü
                {
                    for (int k = 0; k < cursor.GetLength(2); k++) // Sütun Döngüsü
                    {
                        if (cursor[cursor.GetLength(0) - 1 - j, cursor.GetLength(1) - 1 - i, k] != 0)
                        {
                            Console.SetCursorPosition(57 + (cursor.GetLength(1) - 1 + 3 * k - j) * 2, 10 + (cursor.GetLength(0) - 1 + j - i) * 3 - j);
                            Console.Write("+-----+");
                            Console.SetCursorPosition(56 + (cursor.GetLength(1) - 1 + 3 * k - j) * 2, 11 + (cursor.GetLength(0) - 1 + j - i) * 3 - j);
                            Console.Write("/     /|");
                            Console.SetCursorPosition(55 + (cursor.GetLength(1) - 1 + 3 * k - j) * 2, 12 + (cursor.GetLength(0) - 1 + j - i) * 3 - j);
                            Console.Write("+-----+ |");
                            Console.SetCursorPosition(55 + (cursor.GetLength(1) - 1 + 3 * k - j) * 2, 13 + (cursor.GetLength(0) - 1 + j - i) * 3 - j);
                            Console.Write("| " + cursor[cursor.GetLength(0) - 1 - j, cursor.GetLength(1) - 1 - i, k] + " " + cursor[cursor.GetLength(0) - 1 - j, cursor.GetLength(1) - 1 - i, k] + " | +");
                            Console.SetCursorPosition(55 + (cursor.GetLength(1) - 1 + 3 * k - j) * 2, 14 + (cursor.GetLength(0) - 1 + j - i) * 3 - j);
                            Console.Write("| " + cursor[cursor.GetLength(0) - 1 - j, cursor.GetLength(1) - 1 - i, k] + " " + cursor[cursor.GetLength(0) - 1 - j, cursor.GetLength(1) - 1 - i, k] + " |/");
                            Console.SetCursorPosition(55 + (cursor.GetLength(1) - 1 + 3 * k - j) * 2, 15 + (cursor.GetLength(0) - 1 + j - i) * 3 - j);
                            Console.Write("+-----+");
                        }
                    }
                }
            }
            for (int i = 0; i < cursor.GetLength(0); i++) // Yüz Döngüsü
            {
                Console.SetCursorPosition(83 + i * 5, 10);
                for (int j = 0; j < cursor.GetLength(1); j++) // Satır Döngüsü
                {
                    for (int k = 0; k < cursor.GetLength(2); k++) // Sütun Döngüsü
                    {
                        if (cursor[i, j, k] == 0)
                            Console.Write(".");
                        else
                            Console.Write(cursor[i, j, k]);
                    }
                    Console.SetCursorPosition(83 + i * 5, j + 11);
                }
            }
            Console.ReadLine();
        }
    }
}
