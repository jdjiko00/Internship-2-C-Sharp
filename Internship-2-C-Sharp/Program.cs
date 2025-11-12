using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_2_C_Sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<int, Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>>
            {
                { 1,
                  new Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>
                  (
                      "Mate", "Matic", new DateTime(1997, 8, 13),
                      new Dictionary<int, Tuple<DateTime, double, double, double, double>>
                      {
                          { 1,
                            new Tuple<DateTime, double, double, double, double>
                            (
                                new DateTime(2025, 3, 25), 220, 18, 1.49, 26.82
                            )
                          }
                      }
                  )
                },

                { 2,
                  new Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>
                  (
                      "Ivo", "Ivic", new DateTime(1999, 4, 19),
                      new Dictionary<int, Tuple<DateTime, double, double, double, double>>
                      {
                          { 2,
                            new Tuple<DateTime, double, double, double, double>
                            (
                                new DateTime(2019, 7, 14), 350, 28, 1.54, 43.12
                            )
                          },
                          { 3,
                            new Tuple<DateTime, double, double, double, double>
                            (
                                new DateTime(2022, 1, 10), 300, 25, 1.33, 33.25
                            )
                          }
                      }
                  )
                },

                { 3,
                  new Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>
                  (
                      "Jozo", "Jozic", new DateTime(2001, 2, 28),
                      new Dictionary<int, Tuple<DateTime, double, double, double, double>>
                      {
                          { 4,
                            new Tuple<DateTime, double, double, double, double>
                            (
                                new DateTime(2023, 11, 11), 170, 14, 1.52, 21.28
                            )
                          },
                          { 5,
                            new Tuple<DateTime, double, double, double, double>
                            (
                                new DateTime(2025, 3, 13), 200, 17, 1.38, 23.46
                            )
                          }
                      }
                  )
                }
            };

            void newUser()
            {
                Console.WriteLine("Dodavanje novog korisnika");
            }

            void deleteUser()
            {
                Console.WriteLine("Brisanje korisnika");
            }

            void editUser()
            {
                Console.WriteLine("Uredivanje korisnika");
            }

            void showUsers()
            {
                Console.WriteLine("Pregled korisnika");
            }

            void userApp()
            {
                Console.WriteLine("");
                bool userAppFinished = false;
                do
                {
                    Console.WriteLine("1 - Unos novog korisnika");
                    Console.WriteLine("2 - Brisanje korisnika");
                    Console.WriteLine("3 - Uređivanje korisnika");
                    Console.WriteLine("4 - Pregled svih korisnika");
                    Console.WriteLine("0 - Povratak na glavni izbornik");
                    Console.Write("\nOdabir: ");
                    if (int.TryParse(Console.ReadLine(), out int userChoice))
                    {
                        switch (userChoice)
                        {
                            case 1:
                                newUser();
                                break;
                            case 2:
                                deleteUser();
                                break;
                            case 3:
                                editUser();
                                break;
                            case 4:
                                showUsers();
                                break;
                            case 0:
                                Console.WriteLine("Izlazak iz korisnicke aplikacije...");
                                userAppFinished = true;
                                break;
                            default:
                                Console.WriteLine("Krivi odabir!");
                                break;
                        }
                    }
                }
                while (!userAppFinished);
            }

            void travelApp()
            {
                Console.WriteLine("");
                //do
                //{
                    Console.WriteLine("1 - Unos novog putovanja");
                    Console.WriteLine("2 - Brisanje putovanja");
                    Console.WriteLine("3 - Uređivanje postojećeg putovanja");
                    Console.WriteLine("4 - Pregled svih putovanja");
                    Console.WriteLine("5 - Izvještaji i analize");
                    Console.WriteLine("0 - Povratak na glavni izbornik");
                //}
                //while (true);
            }


            Console.WriteLine("APLIKACIJA ZA EVIDENCIJU GORIVA");
            bool appFinished = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("1 - Korisnici");
                Console.WriteLine("2 - Putovanja");
                Console.WriteLine("0 - Izlaz iz aplikacije");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int appChoice))
                {
                    switch (appChoice)
                    {
                        case 1:
                            userApp();
                            break;
                        case 2:
                            travelApp();
                            break;
                        case 0:
                            Console.WriteLine("Izlazak iz aplikacije...");
                            appFinished = true;
                            break;
                        default:
                            Console.WriteLine("Krivi odabir!");
                            break;
                    }
                }
            }
            while (!appFinished);
        }
    }
}
