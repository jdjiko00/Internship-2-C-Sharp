using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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

            /*void newUser(Dictionary<int, Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>> users)
            {
                int numberOfUsers = users.Count;
                int userID = numberOfUsers + 1;

                Console.Write("Unesite ime: ");
                string name = Console.ReadLine();

                Console.Write("Unesite prezime: ");
                string surname = Console.ReadLine();

                DateTime birthDate;
                while (true)
                {
                    Console.Write("Unesite datum rodenja (YYYY-MM-DD): ");
                    string date = Console.ReadLine();
                    if (DateTime.TryParseExact(date, "yyyy-MM-dd", null, DateTimeStyles.None, out birthDate))
                        break;
                    else
                        Console.WriteLine("Neispravan format!");
                }

                Console.Write("Zelite li unijeti putovanje (Y/N): ");
                char addingTravel = char.Parse(Console.ReadLine());
                var travel = new Dictionary<int, Tuple<DateTime, double, double, double, double>>();

                if (addingTravel == 'Y')
                {
                    int numberOfTravles = 0;
                    foreach (var user in users)
                    {
                        numberOfTravles += user.Value.Item4.Count;
                    }
                    int travelID = numberOfTravles + 1;

                    DateTime travelDate;
                    while (true)
                    {
                        Console.Write("Unesite datum rodenja (YYYY-MM-DD): ");
                        string entryDate = Console.ReadLine();
                        if (DateTime.TryParseExact(entryDate, "yyyy-MM-dd", null, DateTimeStyles.None, out travelDate))
                            break;
                        else
                            Console.WriteLine("Neispravan format!");
                    }

                    Console.Write("Unesite kilometrazu: ");
                    double travelLength = double.Parse(Console.ReadLine());

                    Console.Write("Unesite potroseno gorivo (L): ");
                    double fuelConsumed = double.Parse(Console.ReadLine());

                    Console.Write("Unesite cijenu po litri: ");
                    double pricePerLiter = double.Parse(Console.ReadLine());

                    double totalCost = fuelConsumed * pricePerLiter;

                    travel.Add(travelID, new Tuple<DateTime, double, double, double, double>(travelDate, travelLength, fuelConsumed, pricePerLiter, totalCost));

                    users.Add(userID, new Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>(
                        name, surname, birthDate, travel
                    ));
                }
                else if (addingTravel == 'N')
                {
                    users.Add(userID, new Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>(
                        name, surname, birthDate, travel
                    ));
                }
            }*/

            /*void deleteUser()
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
            }*/

            /*void userApp(Dictionary<int, Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>> users)
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
                                newUser(users);
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
            }*/

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
                            userApp(users);
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

        static DateTime entryAndCheckDate(string message)
        {
            DateTime date;
            while (true)
            {
                Console.Write(message);
                string entryDate = Console.ReadLine();
                if (DateTime.TryParseExact(entryDate, "yyyy-MM-dd", null, DateTimeStyles.None, out date))
                    break;
                else
                    Console.WriteLine("Neispravan format datuma!");
            }

            return date;
        }

        static double entryAndCheckValue(string message)
        {
            double value;
            while (true)
            {
                Console.Write(message);
                string entryValue = Console.ReadLine();
                if (double.TryParse(entryValue, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                    break;
                else
                    Console.WriteLine("Neispravan unos. Molim unesite broj.");
            }

            return value;
        }

        static bool checkForAddingTravel(string message)
        {
            string addingTravel;
            bool travelCheck;

            while (true)
            {
                Console.Write(message);
                addingTravel = Console.ReadLine().Trim().ToUpper();

                if (addingTravel == "NE" || addingTravel == "N")
                {
                    travelCheck = false;
                    break;
                }
                else if (addingTravel == "DA" || addingTravel == "D")
                {
                    travelCheck = true;
                    break;
                }
                else Console.WriteLine("Morate upisati DA ili NE!");
            }

            return travelCheck;
        }

        static void userApp(Dictionary<int, Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>> users)
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
                            newUser(users);
                            break;
                        case 2:
                            deleteUser();
                            break;
                        case 3:
                            editUser();
                            break;
                        case 4:
                            showUsers(users);
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

            void newUser(Dictionary<int, Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>> referenceUsers)
            {
                int numberOfUsers = referenceUsers.Count;
                int userID = numberOfUsers + 1;

                Console.Write("Unesite ime: ");
                string name = Console.ReadLine();

                Console.Write("Unesite prezime: ");
                string surname = Console.ReadLine();

                DateTime birthDate = entryAndCheckDate("Unesite datum rodenja (YYYY-MM-DD): ");

                bool travelCheck = checkForAddingTravel("Zelite li unijeti putovanje (DA/NE): ");

                var travel = new Dictionary<int, Tuple<DateTime, double, double, double, double>>();
                int numberOfTravles = 0;
                foreach (var user in referenceUsers)
                {
                    numberOfTravles += user.Value.Item4.Count;
                }

                while (travelCheck)
                {
                    int travelID = numberOfTravles + 1;

                    DateTime travelDate = entryAndCheckDate("Unesite datum putovanja (YYYY-MM-DD): ");

                    double travelLength = entryAndCheckValue("Unesite kilometrazu: ");

                    double fuelConsumed = entryAndCheckValue("Unesite potroseno gorivo (L): ");

                    double pricePerLiter = entryAndCheckValue("Unesite cijenu po litri: ");

                    double totalCost = fuelConsumed * pricePerLiter;

                    travel.Add(travelID, new Tuple<DateTime, double, double, double, double>(travelDate, travelLength, fuelConsumed, pricePerLiter, totalCost));

                    travelCheck = checkForAddingTravel("Zelite li unijeti jos jedno putovanje (DA/NE): ");
                }

                Console.WriteLine("");

                referenceUsers.Add(userID, new Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>(
                        name, surname, birthDate, travel
                    ));
            }

            void deleteUser()
            {
                Console.WriteLine("Brisanje korisnika");
            }

            void editUser()
            {
                Console.WriteLine("Uredivanje korisnika");
            }

            void showUsers(Dictionary<int, Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>> referenceUsers)
            {
                Console.WriteLine("");
                var tempUsers = referenceUsers
                    .OrderBy(surname => surname.Value.Item2)
                    .ThenBy(name => name.Value.Item1)
                    .ToList();

                foreach ( var user in tempUsers )
                {
                    Console.WriteLine($"{user.Key} - {user.Value.Item1} - {user.Value.Item2} - {user.Value.Item3.ToString("yyyy-MM-dd")}");
                }

                Console.WriteLine("");
            }
        }
    }
}
