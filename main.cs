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
                                Console.Write(cursor[i, j, k]);
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
                Console.Write("Piece: ");
                Console.SetCursorPosition(98, 11);
                Console.Write("x:");
                Console.SetCursorPosition(98, 12);
                Console.Write("y:");
                Console.SetCursorPosition(98, 13);
                Console.Write("z:");
                Console.SetCursorPosition(98, 14);
                Console.Write("coll:");
                Console.SetCursorPosition(98, 15);
                Console.Write("cube:");

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
                        break;
                }
                Console.Clear();
            }
            Console.ReadLine();
        }
    }
} 
