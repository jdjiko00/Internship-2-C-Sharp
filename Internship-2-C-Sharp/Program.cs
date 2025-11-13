using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Win32;

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
                    Console.WriteLine("Neispravan unos. Trebate unijeti broj.");
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
                            deleteUser(users);
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

                Console.WriteLine($"ID unosenog elementa prije foreach {userID}");
                foreach (var user in referenceUsers)
                {
                    if (userID == user.Key)
                        userID++;
                }
                Console.WriteLine($"ID unosenog elementa {userID}");

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

            void deleteUser(Dictionary<int, Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>> referenceUsers)
            {
                Console.Write("Unesite ID ili ime korisnika kojeg zelite izbrisati: ");
                string nameOrID = Console.ReadLine().ToUpper();

                if (int.TryParse(nameOrID, out int ID))
                {
                    if (referenceUsers.ContainsKey(ID))
                    {
                        var user = referenceUsers[ID];
                        string name = user.Item1;
                        string surname = user.Item2;

                        users.Remove(ID);

                        Console.WriteLine($"Izbrisan je korisnik {ID} - {name} - {surname}");
                    }
                    else Console.WriteLine("Korisnik ne postoji s tom vrijednosti ID-a!");
                }

                else if (double.TryParse(nameOrID, out double decimalID))
                    Console.WriteLine("Korisnik ne postoji s tom vrijednosti ID-a!");
                    
                else
                {
                    List<int> matchingUser = new List<int>();
                    int deletedUserID = 0;
                    bool nameMatches = false;

                    foreach (var user in referenceUsers)
                    {
                        string upperName = user.Value.Item1.ToUpper();
                        string upperSurname = user.Value.Item2.ToUpper();

                        string name = user.Value.Item1;
                        string surname = user.Value.Item2;

                        if (upperName + ' ' + upperSurname == nameOrID)
                        {
                            nameMatches = true;
                            deletedUserID = user.Key;
                        }

                        else if (upperName.Contains(nameOrID) || upperSurname.Contains(nameOrID))
                        {
                            deletedUserID = user.Key;
                            matchingUser.Add(deletedUserID);
                        }
                    }

                    if (nameMatches)
                    {
                        var deletedUser = referenceUsers[deletedUserID];
                        referenceUsers.Remove(deletedUserID);
                        string nameOfDeletedUser = deletedUser.Item1;
                        string surnameOfDeletedUser = deletedUser.Item2;
                        Console.WriteLine($"Izbrisan je korisnik {deletedUserID} - {nameOfDeletedUser} - {surnameOfDeletedUser}");

                        return;
                    }

                    if (matchingUser.Count == 0)
                    {
                        Console.WriteLine("Ne postoji korisnik koji ima to ime!");
                    }

                    else if (matchingUser.Count == 1)
                    {
                        int userID = matchingUser[0];
                        var user = referenceUsers[userID];
                        string name = user.Item1;
                        string surname = user.Item2;
                        Console.WriteLine($"{userID} - {name} - {surname}");
                        Console.WriteLine("Jeste li mislili na ovog korisnika? Ako da, upisite njegov ID");

                        string inputID = Console.ReadLine();
                        if (int.TryParse(inputID, out int userIDToDelete))
                        {
                            if (userIDToDelete == userID)
                            {
                                referenceUsers.Remove(userID);
                                Console.WriteLine($"Izbrisan je korisnik {userID} - {name} - {surname}");
                            }
                            else Console.WriteLine("To nije ID od korisnika!");
                        }
                        else Console.WriteLine("To nije ID od korisnika!");
                    }

                    else
                    {
                        foreach (int userID in matchingUser)
                        {
                            var user = referenceUsers[userID];
                            string name = user.Item1;
                            string surname = user.Item2;
                            Console.WriteLine($"{userID} - {name} - {surname}");
                        }
                        Console.WriteLine("Jeste li mislili na jednog od ovih korisnika? Ako da, upisite njegov ID");

                        string inputID = Console.ReadLine();
                        if (int.TryParse(inputID, out int userIDToDelete))
                        {
                            foreach (int userID in matchingUser)
                            {
                                if (userIDToDelete == userID)
                                {
                                    var user = referenceUsers[userID];
                                    string name = user.Item1;
                                    string surname = user.Item2;
                                    referenceUsers.Remove(userID);
                                    Console.WriteLine($"Izbrisan je korisnik {userID} - {name} - {surname}");
                                }
                                else Console.WriteLine("To nije ID od korisnika!");
                            }
                        }
                        else Console.WriteLine("To nije ID od korisnika!");
                    }
                }
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
