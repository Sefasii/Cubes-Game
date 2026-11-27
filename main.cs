using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proje_2_Deneme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool gamemode = true;
            Console.CursorVisible = false; // Konsol üzerinde gözüken imleci kapatmak.
            int currentcursor = 1, cursorcounter = 0;
            int board_x_pos = 11, board_y_pos = 12, board_z_pos = 13;
            int puzzle_x_pos = 11, puzzle_y_pos = 12, puzzle_z_pos = 13;
            int cursor_x_pos = 11, cursor_y_pos = 12, cursor_z_pos = 13;
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
                { { 0, 0, 0 }, { 1, 0, 0 }, { 1, 1, 0 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }
            };
            int[,,] cursor_in_board = new int[5, 5, 5];
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
            int[,,] board_rotate = new int[5, 5, 5];
            int[,,] puzzle_rotate = new int[5, 5, 5];
            int[,,] cursor_rotate = new int[3, 3, 3];

            //-------------------------------------------------
            // Oyunu Oynatma
            //-------------------------------------------------

            while (gamemode == true)
            {
                //-------------------------------------------------
                // Oyun Sonu Kontrolü
                //-------------------------------------------------

                bool control = true;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (board[i, j, k] != puzzle[i, j, k])
                                control = false;
                        }
                    }
                }
                if (control == true)
                    gamemode = false;
                if (gamemode == false)
                    break;

                //-------------------------------------------------
                // Board Yazdırma
                //-------------------------------------------------

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
                                if (board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] == 1)
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                else if (board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] == 2)
                                    Console.ForegroundColor = ConsoleColor.Green;
                                else if (board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] == 3)
                                    Console.ForegroundColor = ConsoleColor.Red;
                                else if (board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] == 4)
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                else if (board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] == 5)
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                else if (board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] == 6)
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                else
                                    Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(2 + (board.GetLength(1) - 1 + 3 * k - j) * 2, (board.GetLength(0) - 1 + j - i) * 3 - j);
                                Console.Write("+-----+");
                                Console.SetCursorPosition(1 + (board.GetLength(1) - 1 + 3 * k - j) * 2, 1 + (board.GetLength(0) - 1 + j - i) * 3 - j);
                                Console.Write("/     /|");
                                Console.SetCursorPosition((board.GetLength(1) - 1 + 3 * k - j) * 2, 2 + (board.GetLength(0) - 1 + j - i) * 3 - j);
                                Console.Write("+-----+ |");
                                Console.SetCursorPosition((board.GetLength(1) - 1 + 3 * k - j) * 2, 3 + (board.GetLength(0) - 1 + j - i) * 3 - j);
                                Console.Write("| " + board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] + " " + board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] + " | +");
                                Console.SetCursorPosition((board.GetLength(1) - 1 + 3 * k - j) * 2, 4 + (board.GetLength(0) - 1 + j - i) * 3 - j);
                                Console.Write("| " + board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] + " " + board[board.GetLength(0) - 1 - j, board.GetLength(1) - 1 - i, k] + " |/");
                                Console.SetCursorPosition((board.GetLength(1) - 1 + 3 * k - j) * 2, 5 + (board.GetLength(0) - 1 + j - i) * 3 - j);
                                Console.Write("+-----+");
                            }
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
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

                //-------------------------------------------------
                // Puzzle Yazdırma
                //-------------------------------------------------

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
                                if (puzzle[puzzle.GetLength(0) - 1 - j, puzzle.GetLength(1) - 1 - i, k] == 1)
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                else if (puzzle[puzzle.GetLength(0) - 1 - j, puzzle.GetLength(1) - 1 - i, k] == 2)
                                    Console.ForegroundColor = ConsoleColor.Green;
                                else if (puzzle[puzzle.GetLength(0) - 1 - j, puzzle.GetLength(1) - 1 - i, k] == 3)
                                    Console.ForegroundColor = ConsoleColor.Red;
                                else if (puzzle[puzzle.GetLength(0) - 1 - j, puzzle.GetLength(1) - 1 - i, k] == 4)
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                else if (puzzle[puzzle.GetLength(0) - 1 - j, puzzle.GetLength(1) - 1 - i, k] == 5)
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                else if (puzzle[puzzle.GetLength(0) - 1 - j, puzzle.GetLength(1) - 1 - i, k] == 6)
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                else
                                    Console.ForegroundColor = ConsoleColor.White;
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
                Console.ForegroundColor = ConsoleColor.White;
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

                //-------------------------------------------------
                // Cursor Yazdırma
                //-------------------------------------------------

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
                                if (cursor[cursor.GetLength(0) - 1 - j, cursor.GetLength(1) - 1 - i, k] == 1)
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                else if (cursor[cursor.GetLength(0) - 1 - j, cursor.GetLength(1) - 1 - i, k] == 2)
                                    Console.ForegroundColor = ConsoleColor.Green;
                                else if (cursor[cursor.GetLength(0) - 1 - j, cursor.GetLength(1) - 1 - i, k] == 3)
                                    Console.ForegroundColor = ConsoleColor.Red;
                                else if (cursor[cursor.GetLength(0) - 1 - j, cursor.GetLength(1) - 1 - i, k] == 4)
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                else if (cursor[cursor.GetLength(0) - 1 - j, cursor.GetLength(1) - 1 - i, k] == 5)
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                else if (cursor[cursor.GetLength(0) - 1 - j, cursor.GetLength(1) - 1 - i, k] == 6)
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                else
                                    Console.ForegroundColor = ConsoleColor.White;
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
                Console.ForegroundColor = ConsoleColor.White;
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
                            {
                                cursorcounter++;
                                Console.Write(cursor[i, j, k]);
                            }
                        }
                        Console.SetCursorPosition(83 + i * 5, j + 11);
                    }
                }
                Console.SetCursorPosition(83, 14);
                Console.Write("x:");
                Console.SetCursorPosition(83, 15);
                Console.Write("y:");
                Console.SetCursorPosition(83, 16);
                Console.Write("z:");
                Console.SetCursorPosition(98, 10);
                Console.Write("Piece:");
                Console.SetCursorPosition(98, 11);
                Console.Write("x:");
                if (cursor_x_pos / 10 == 1)
                    Console.Write("+");
                else
                    Console.Write("-");
                if (cursor_x_pos % 10 == 1)
                    Console.Write("x");
                else if (cursor_x_pos % 10 == 2)
                    Console.Write("y");
                else
                    Console.Write("z");
                Console.SetCursorPosition(98, 12);
                Console.Write("y:");
                if (cursor_y_pos / 10 == 1)
                    Console.Write("+");
                else
                    Console.Write("-");
                if (cursor_y_pos % 10 == 1)
                    Console.Write("x");
                else if (cursor_y_pos % 10 == 2)
                    Console.Write("y");
                else
                    Console.Write("z");
                Console.SetCursorPosition(98, 13);
                Console.Write("z:");
                if (cursor_z_pos / 10 == 1)
                    Console.Write("+");
                else
                    Console.Write("-");
                if (cursor_z_pos % 10 == 1)
                    Console.Write("x");
                else if (cursor_z_pos % 10 == 2)
                    Console.Write("y");
                else
                    Console.Write("z");
                Console.SetCursorPosition(98, 14);
                Console.Write("coll:");
                Console.SetCursorPosition(98, 15);
                Console.Write("cube:0/" + cursorcounter);
                cursorcounter = 0;
                Console.SetCursorPosition(111, 10);
                Console.Write("Pieces:");
                Console.SetCursorPosition(112, 11);
                Console.Write("1:0");
                Console.SetCursorPosition(112, 12);
                Console.Write("2:0");
                Console.SetCursorPosition(112, 13);
                Console.Write("3:0");
                Console.SetCursorPosition(112, 14);
                Console.Write("4:0");
                Console.SetCursorPosition(112, 15);
                Console.Write("5:0");
                Console.SetCursorPosition(112, 16);
                Console.Write("6:0");
                Console.SetCursorPosition(112, 17);
                Console.Write("7:0");
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        for (int k = 0; k < board.GetLength(2); k++)
                        {
                            if (board[i, j, k] != 0)
                            {
                                Console.SetCursorPosition(114, 10 + board[i, j, k]);
                                Console.Write("1");
                            }
                        }
                    }
                }
                Console.SetCursorPosition(116, 10 + currentcursor);
                Console.Write("<-");

                //-------------------------------------------------
                // Board'ı Yedekleme
                //-------------------------------------------------

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        for (int k = 0; k < board.GetLength(2); k++)
                        {
                            board_rotate[i, j, k] = board[i, j, k];
                        }
                    }
                }

                //-------------------------------------------------
                // Puzzle'ı Yedekleme
                //-------------------------------------------------

                for (int i = 0; i < puzzle.GetLength(0); i++)
                {
                    for (int j = 0; j < puzzle.GetLength(1); j++)
                    {
                        for (int k = 0; k < puzzle.GetLength(2); k++)
                        {
                            puzzle_rotate[i, j, k] = puzzle[i, j, k];
                        }
                    }
                }

                //-------------------------------------------------
                // Cursor'u Yedekleme
                //-------------------------------------------------

                for (int i = 0; i < cursor.GetLength(0); i++)
                {
                    for (int j = 0; j < cursor.GetLength(1); j++)
                    {
                        for (int k = 0; k < cursor.GetLength(2); k++)
                        {
                            cursor_rotate[i, j, k] = cursor[i, j, k];
                        }
                    }
                }

                //-------------------------------------------------
                // Rotasyonlar
                //-------------------------------------------------

                ConsoleKeyInfo tus = Console.ReadKey();
                switch (tus.Key)
                {
                    //-------------------------------------------------
                    // Board Rotasyonları
                    //-------------------------------------------------

                    case ConsoleKey.Y: // Board'ın ön yüzünü sola döndürme
                        for (int i = 0; i < board.GetLength(0); i++)
                        {
                            for (int j = 0; j < board.GetLength(1); j++)
                            {
                                for (int k = 0; k < board.GetLength(2); k++)
                                {
                                    board[4 - k, j, i] = board_rotate[i, j, k];
                                }
                            }
                        }
                        break;
                    case ConsoleKey.R: // Board'ın ön yüzünü sağa döndürme
                        for (int i = 0; i < board.GetLength(0); i++)
                        {
                            for (int j = 0; j < board.GetLength(1); j++)
                            {
                                for (int k = 0; k < board.GetLength(2); k++)
                                {
                                    board[k, j, 4 - i] = board_rotate[i, j, k];
                                }
                            }
                        }
                        break;
                    case ConsoleKey.T: // Board'ın ön yüzünü yukarıya döndürme
                        for (int i = 0; i < board.GetLength(0); i++)
                        {
                            for (int j = 0; j < board.GetLength(1); j++)
                            {
                                for (int k = 0; k < board.GetLength(2); k++)
                                {
                                    board[4 - j, i, k] = board_rotate[i, j, k];
                                }
                            }
                        }
                        break;
                    case ConsoleKey.G: // Board'ın ön yüzünü aşağıya döndürme
                        for (int i = 0; i < board.GetLength(0); i++)
                        {
                            for (int j = 0; j < board.GetLength(1); j++)
                            {
                                for (int k = 0; k < board.GetLength(2); k++)
                                {
                                    board[j, 4 - i, k] = board_rotate[i, j, k];
                                }
                            }
                        }
                        break;
                    case ConsoleKey.F: // Board'ın ön yüzünü saat yönünün tersine döndürme
                        for (int i = 0; i < board.GetLength(0); i++)
                        {
                            for (int j = 0; j < board.GetLength(1); j++)
                            {
                                for (int k = 0; k < board.GetLength(2); k++)
                                {
                                    board[i, 4 - k, j] = board_rotate[i, j, k];
                                }
                            }
                        }
                        break;
                    case ConsoleKey.H: // Board'ın ön yüzünü saat yönünde döndürme
                        for (int i = 0; i < board.GetLength(0); i++)
                        {
                            for (int j = 0; j < board.GetLength(1); j++)
                            {
                                for (int k = 0; k < board.GetLength(2); k++)
                                {
                                    board[i, k, 4 - j] = board_rotate[i, j, k];
                                }
                            }
                        }
                        break;

                    //-------------------------------------------------
                    // Puzzle Rotasyonları
                    //-------------------------------------------------

                    case ConsoleKey.E: // Puzzle'ın ön yüzünü sola döndürme
                        for (int i = 0; i < puzzle.GetLength(0); i++)
                        {
                            for (int j = 0; j < puzzle.GetLength(1); j++)
                            {
                                for (int k = 0; k < puzzle.GetLength(2); k++)
                                {
                                    puzzle[4 - k, j, i] = puzzle_rotate[i, j, k];
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Q: // Puzzle'ın ön yüzünü sağa döndürme
                        for (int i = 0; i < puzzle.GetLength(0); i++)
                        {
                            for (int j = 0; j < puzzle.GetLength(1); j++)
                            {
                                for (int k = 0; k < puzzle.GetLength(2); k++)
                                {
                                    puzzle[k, j, 4 - i] = puzzle_rotate[i, j, k];
                                }
                            }
                        }
                        break;
                    case ConsoleKey.W: // Puzzle'ın ön yüzünü yukarıya döndürme
                        for (int i = 0; i < puzzle.GetLength(0); i++)
                        {
                            for (int j = 0; j < puzzle.GetLength(1); j++)
                            {
                                for (int k = 0; k < puzzle.GetLength(2); k++)
                                {
                                    puzzle[4 - j, i, k] = puzzle_rotate[i, j, k];
                                }
                            }
                        }
                        break;
                    case ConsoleKey.S: // Puzzle'ın ön yüzünü aşağıya döndürme
                        for (int i = 0; i < puzzle.GetLength(0); i++)
                        {
                            for (int j = 0; j < puzzle.GetLength(1); j++)
                            {
                                for (int k = 0; k < puzzle.GetLength(2); k++)
                                {
                                    puzzle[j, 4 - i, k] = puzzle_rotate[i, j, k];
                                }
                            }
                        }
                        break;
                    case ConsoleKey.A: // Puzzle'ın ön yüzünü saat yönünün tersine döndürme
                        for (int i = 0; i < puzzle.GetLength(0); i++)
                        {
                            for (int j = 0; j < puzzle.GetLength(1); j++)
                            {
                                for (int k = 0; k < puzzle.GetLength(2); k++)
                                {
                                    puzzle[i, 4 - k, j] = puzzle_rotate[i, j, k];
                                }
                            }
                        }
                        break;
                    case ConsoleKey.D: // Puzzle'ın ön yüzünü saat yönünde döndürme
                        for (int i = 0; i < puzzle.GetLength(0); i++)
                        {
                            for (int j = 0; j < puzzle.GetLength(1); j++)
                            {
                                for (int k = 0; k < puzzle.GetLength(2); k++)
                                {
                                    puzzle[i, k, 4 - j] = puzzle_rotate[i, j, k];
                                }
                            }
                        }
                        break;

                    //-------------------------------------------------
                    // Cursor Rotasyonları
                    //-------------------------------------------------

                    case ConsoleKey.C: // Cursor'ın ön yüzünü sola döndürme
                        for (int i = 0; i < cursor.GetLength(0); i++)
                        {
                            for (int j = 0; j < cursor.GetLength(1); j++)
                            {
                                for (int k = 0; k < cursor.GetLength(2); k++)
                                {
                                    cursor[2 - k, j, i] = cursor_rotate[i, j, k];
                                }
                            }
                        }
                        if (cursor_x_pos % 10 == 2)
                            cursorleftmove(ref cursor_y_pos, ref cursor_z_pos);
                        else if (cursor_y_pos % 10 == 2)
                            cursorleftmove(ref cursor_x_pos, ref cursor_z_pos);
                        else
                            cursorleftmove(ref cursor_x_pos, ref cursor_y_pos);
                        break;
                    case ConsoleKey.Z: // Cursor'ın ön yüzünü sağa döndürme
                        for (int i = 0; i < cursor.GetLength(0); i++)
                        {
                            for (int j = 0; j < cursor.GetLength(1); j++)
                            {
                                for (int k = 0; k < cursor.GetLength(2); k++)
                                {
                                    cursor[k, j, 2 - i] = cursor_rotate[i, j, k];
                                }
                            }
                        }
                        if (cursor_x_pos % 10 == 2)
                            cursorrightmove(ref cursor_y_pos, ref cursor_z_pos);
                        else if (cursor_y_pos % 10 == 2)
                            cursorrightmove(ref cursor_x_pos, ref cursor_z_pos);
                        else
                            cursorrightmove(ref cursor_x_pos, ref cursor_y_pos);
                        break;
                    case ConsoleKey.X: // Cursor'ın ön yüzünü yukarıya döndürme
                        for (int i = 0; i < cursor.GetLength(0); i++)
                        {
                            for (int j = 0; j < cursor.GetLength(1); j++)
                            {
                                for (int k = 0; k < cursor.GetLength(2); k++)
                                {
                                    cursor[2 - j, i, k] = cursor_rotate[i, j, k];
                                }
                            }
                        }
                        if (cursor_x_pos % 10 == 1)
                            cursorupmove(ref cursor_y_pos, ref cursor_z_pos);
                        else if (cursor_y_pos % 10 == 1)
                            cursorupmove(ref cursor_x_pos, ref cursor_z_pos);
                        else
                            cursorupmove(ref cursor_x_pos, ref cursor_y_pos);
                        break;
                    case ConsoleKey.B: // Cursor'ın ön yüzünü aşağıya döndürme
                        for (int i = 0; i < cursor.GetLength(0); i++)
                        {
                            for (int j = 0; j < cursor.GetLength(1); j++)
                            {
                                for (int k = 0; k < cursor.GetLength(2); k++)
                                {
                                    cursor[j, 2 - i, k] = cursor_rotate[i, j, k];
                                }
                            }
                        }
                        if (cursor_x_pos % 10 == 1)
                            cursordownmove(ref cursor_y_pos, ref cursor_z_pos);
                        else if (cursor_y_pos % 10 == 1)
                            cursordownmove(ref cursor_x_pos, ref cursor_z_pos);
                        else
                            cursordownmove(ref cursor_x_pos, ref cursor_y_pos);
                        break;
                    case ConsoleKey.V: // Cursor'ın ön yüzünü saat yönünün tersine döndürme
                        for (int i = 0; i < cursor.GetLength(0); i++)
                        {
                            for (int j = 0; j < cursor.GetLength(1); j++)
                            {
                                for (int k = 0; k < cursor.GetLength(2); k++)
                                {
                                    cursor[i, 2 - k, j] = cursor_rotate[i, j, k];
                                }
                            }
                        }
                        if (cursor_x_pos % 10 == 3)
                            cursorcountermove(ref cursor_y_pos, ref cursor_z_pos);
                        else if (cursor_y_pos % 10 == 3)
                            cursorcountermove(ref cursor_x_pos, ref cursor_z_pos);
                        else
                            cursorcountermove(ref cursor_x_pos, ref cursor_y_pos);
                        break;
                    case ConsoleKey.N: // Cursor'ın ön yüzünü saat yönünde döndürme
                        for (int i = 0; i < cursor.GetLength(0); i++)
                        {
                            for (int j = 0; j < cursor.GetLength(1); j++)
                            {
                                for (int k = 0; k < cursor.GetLength(2); k++)
                                {
                                    cursor[i, k, 2 - j] = cursor_rotate[i, j, k];
                                }
                            }
                        }
                        if (cursor_x_pos % 10 == 3)
                            cursorclockmove(ref cursor_y_pos, ref cursor_z_pos);
                        else if (cursor_y_pos % 10 == 3)
                            cursorclockmove(ref cursor_x_pos, ref cursor_z_pos);
                        else
                            cursorclockmove(ref cursor_x_pos, ref cursor_y_pos);
                        break;

                    //-------------------------------------------------
                    // Cursor Değiştirme
                    //-------------------------------------------------

                    case ConsoleKey.O:
                        currentcursor--;
                        if (currentcursor == 0)
                            currentcursor = 7;
                        switch (currentcursor)
                        {
                            case 1:
                                for (int i = 0; i < cursor.GetLength(0); i++)
                                {
                                    for (int j = 0; j < cursor.GetLength(1); j++)
                                    {
                                        for (int k = 0; k < cursor.GetLength(2); k++)
                                        {
                                            cursor[i, j, k] = piece1[i, j, k];
                                        }
                                    }
                                }
                                break;
                            case 2:
                                for (int i = 0; i < cursor.GetLength(0); i++)
                                {
                                    for (int j = 0; j < cursor.GetLength(1); j++)
                                    {
                                        for (int k = 0; k < cursor.GetLength(2); k++)
                                        {
                                            cursor[i, j, k] = piece2[i, j, k];
                                        }
                                    }
                                }
                                break;
                            case 3:
                                for (int i = 0; i < cursor.GetLength(0); i++)
                                {
                                    for (int j = 0; j < cursor.GetLength(1); j++)
                                    {
                                        for (int k = 0; k < cursor.GetLength(2); k++)
                                        {
                                            cursor[i, j, k] = piece3[i, j, k];
                                        }
                                    }
                                }
                                break;
                            case 4:
                                for (int i = 0; i < cursor.GetLength(0); i++)
                                {
                                    for (int j = 0; j < cursor.GetLength(1); j++)
                                    {
                                        for (int k = 0; k < cursor.GetLength(2); k++)
                                        {
                                            cursor[i, j, k] = piece4[i, j, k];
                                        }
                                    }
                                }
                                break;
                            case 5:
                                for (int i = 0; i < cursor.GetLength(0); i++)
                                {
                                    for (int j = 0; j < cursor.GetLength(1); j++)
                                    {
                                        for (int k = 0; k < cursor.GetLength(2); k++)
                                        {
                                            cursor[i, j, k] = piece5[i, j, k];
                                        }
                                    }
                                }
                                break;
                            case 6:
                                for (int i = 0; i < cursor.GetLength(0); i++)
                                {
                                    for (int j = 0; j < cursor.GetLength(1); j++)
                                    {
                                        for (int k = 0; k < cursor.GetLength(2); k++)
                                        {
                                            cursor[i, j, k] = piece6[i, j, k];
                                        }
                                    }
                                }
                                break;
                            case 7:
                                for (int i = 0; i < cursor.GetLength(0); i++)
                                {
                                    for (int j = 0; j < cursor.GetLength(1); j++)
                                    {
                                        for (int k = 0; k < cursor.GetLength(2); k++)
                                        {
                                            cursor[i, j, k] = piece7[i, j, k];
                                        }
                                    }
                                }
                                break;
                        }
                        break;
                    case ConsoleKey.K:
                        currentcursor++;
                        if (currentcursor == 8)
                            currentcursor = 1;
                        switch (currentcursor)
                        {
                            case 1:
                                for (int i = 0; i < cursor.GetLength(0); i++)
                                {
                                    for (int j = 0; j < cursor.GetLength(1); j++)
                                    {
                                        for (int k = 0; k < cursor.GetLength(2); k++)
                                        {
                                            cursor[i, j, k] = piece1[i, j, k];
                                        }
                                    }
                                }
                                break;
                            case 2:
                                for (int i = 0; i < cursor.GetLength(0); i++)
                                {
                                    for (int j = 0; j < cursor.GetLength(1); j++)
                                    {
                                        for (int k = 0; k < cursor.GetLength(2); k++)
                                        {
                                            cursor[i, j, k] = piece2[i, j, k];
                                        }
                                    }
                                }
                                break;
                            case 3:
                                for (int i = 0; i < cursor.GetLength(0); i++)
                                {
                                    for (int j = 0; j < cursor.GetLength(1); j++)
                                    {
                                        for (int k = 0; k < cursor.GetLength(2); k++)
                                        {
                                            cursor[i, j, k] = piece3[i, j, k];
                                        }
                                    }
                                }
                                break;
                            case 4:
                                for (int i = 0; i < cursor.GetLength(0); i++)
                                {
                                    for (int j = 0; j < cursor.GetLength(1); j++)
                                    {
                                        for (int k = 0; k < cursor.GetLength(2); k++)
                                        {
                                            cursor[i, j, k] = piece4[i, j, k];
                                        }
                                    }
                                }
                                break;
                            case 5:
                                for (int i = 0; i < cursor.GetLength(0); i++)
                                {
                                    for (int j = 0; j < cursor.GetLength(1); j++)
                                    {
                                        for (int k = 0; k < cursor.GetLength(2); k++)
                                        {
                                            cursor[i, j, k] = piece5[i, j, k];
                                        }
                                    }
                                }
                                break;
                            case 6:
                                for (int i = 0; i < cursor.GetLength(0); i++)
                                {
                                    for (int j = 0; j < cursor.GetLength(1); j++)
                                    {
                                        for (int k = 0; k < cursor.GetLength(2); k++)
                                        {
                                            cursor[i, j, k] = piece6[i, j, k];
                                        }
                                    }
                                }
                                break;
                            case 7:
                                for (int i = 0; i < cursor.GetLength(0); i++)
                                {
                                    for (int j = 0; j < cursor.GetLength(1); j++)
                                    {
                                        for (int k = 0; k < cursor.GetLength(2); k++)
                                        {
                                            cursor[i, j, k] = piece7[i, j, k];
                                        }
                                    }
                                }
                                break;
                        }
                        break;
                }
                Console.Clear();
            }
            Console.ReadLine();
        }
        static void cursorupmove(ref int a, ref int b)
        {
            if (a % 10 == 2)
            {
                a++;
                b--;
                if (b > 10)
                    b = b - 10;
                else
                    b = b + 10;
            }
            else
            {
                a--;
                b++;
                if (a > 10)
                    a = a - 10;
                else
                    a = a + 10;
            }
        }
        static void cursordownmove(ref int a, ref int b)
        {
            if (a % 10 == 2)
            {
                a++;
                b--;
                if (a > 10)
                    a = a - 10;
                else
                    a = a + 10;
            }
            else
            {
                a--;
                b++;
                if (b > 10)
                    b = b - 10;
                else
                    b = b + 10;
            }
        }
        static void cursorleftmove(ref int a, ref int b)
        {
            if (a % 10 == 1)
            {
                a = a + 2;
                b = b - 2;
                if (a > 10)
                    a = a - 10;
                else
                    a = a + 10;
            }
            else
            {
                a = a - 2;
                b = b + 2;
                if (b > 10)
                    b = b - 10;
                else
                    b = b + 10;
            }
        }
        static void cursorrightmove(ref int a, ref int b)
        {
            if (a % 10 == 1)
            {
                a = a + 2;
                b = b - 2;
                if (b > 10)
                    b = b - 10;
                else
                    b = b + 10;
            }
            else
            {
                a = a - 2;
                b = b + 2;
                if (a > 10)
                    a = a - 10;
                else
                    a = a + 10;
            }
        }
        static void cursorclockmove(ref int a, ref int b)
        {
            if (a % 10 == 1)
            {
                a++;
                b--;
                if (a > 10)
                    a = a - 10;
                else
                    a = a + 10;
            }
            else
            {
                a--;
                b++;
                if (b > 10)
                    b = b - 10;
                else
                    b = b + 10;
            }
        }
        static void cursorcountermove(ref int a, ref int b)
        {
            if (a % 10 == 1)
            {
                a++;
                b--;
                if (b > 10)
                    b = b - 10;
                else
                    b = b + 10;
            }
            else
            {
                a--;
                b++;
                if (a > 10)
                    a = a - 10;
                else
                    a = a + 10;
            }
        }
    }
}
