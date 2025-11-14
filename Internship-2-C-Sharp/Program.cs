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
                      "Ivo", "Ivic", new DateTime(1999, 12, 19),
                      new Dictionary<int, Tuple<DateTime, double, double, double, double>>
                      {
                          { 1,
                            new Tuple<DateTime, double, double, double, double>
                            (
                                new DateTime(2019, 7, 14), 350, 28, 1.54, 43.12
                            )
                          },
                          { 2,
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
                          { 1,
                            new Tuple<DateTime, double, double, double, double>
                            (
                                new DateTime(2023, 11, 11), 170, 14, 1.52, 21.28
                            )
                          },
                          { 2,
                            new Tuple<DateTime, double, double, double, double>
                            (
                                new DateTime(2025, 3, 13), 200, 17, 1.38, 23.46
                            )
                          }
                      }
                  )
                }
            };

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
                            travelApp(users);
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

        static DateTime entryAndCheckDate(string message, DateTime currentDate = default)
        {
            DateTime date;

            while (true)
            {
                Console.Write(message);
                string entryDate = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entryDate))
                    return currentDate;

                if (DateTime.TryParseExact(entryDate, "yyyy-MM-dd", null, DateTimeStyles.None, out date))
                    return date;

                else
                {
                    Console.WriteLine("Neispravan format datuma!");
                    return currentDate;
                }
            }
        }

        static double entryAndCheckValue(string message, double currentValue = 0)
        {
            double value;

            while (true)
            {
                Console.Write(message);
                string entryValue = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entryValue))
                    return currentValue;

                if (double.TryParse(entryValue, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                    return value;

                else
                {
                    Console.WriteLine("Neispravan format datuma!");
                    return currentValue;
                }
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
                    return travelCheck;
                }

                else if (addingTravel == "DA" || addingTravel == "D")
                {
                    travelCheck = true;
                    return travelCheck;
                }

                else
                {
                    Console.WriteLine("Morate upisati DA ili NE!");
                    return false;
                }
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
                            editUser(users);
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

                foreach (var user in referenceUsers)
                {
                    if (userID == user.Key)
                        userID++;
                }

                Console.Write("Unesite ime: ");
                string name = Console.ReadLine();

                Console.Write("Unesite prezime: ");
                string surname = Console.ReadLine();

                DateTime birthDate = entryAndCheckDate("Unesite datum rodenja (YYYY-MM-DD): ");

                bool travelCheck = checkForAddingTravel("Zelite li unijeti putovanje (DA/NE): ");

                var travel = new Dictionary<int, Tuple<DateTime, double, double, double, double>>();
                int travelID = 0;

                while (travelCheck)
                {
                    travelID++;

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

            void editUser(Dictionary<int, Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>> referenceUsers)
            {
                Console.Write("Unesite ID korisnika kojeg zelite urediti: ");
                string nameOrID = Console.ReadLine();

                if (int.TryParse(nameOrID, out int ID))
                {
                    if (referenceUsers.ContainsKey(ID))
                    {
                        var user = referenceUsers[ID];
                        string name = user.Item1;
                        string surname = user.Item2;
                        DateTime birthDate = user.Item3;

                        Console.WriteLine($"Ureduje se korisnik {ID} - {name} - {surname}");

                        Console.Write($"Unesite novo ime (ENTER za zadržati '{name}'): ");
                        string newName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newName))
                            newName = name;

                        Console.Write($"Unesite novo ime (ENTER za zadržati '{surname}'): ");
                        string newSurname = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newSurname))
                            newSurname = surname;

                        DateTime newBirthDate = entryAndCheckDate($"Unesite novi datum rodenja (YYYY-MM-DD) (ENTER za zadržati '{birthDate.ToString("yyyy-MM-dd")}'): ", birthDate);

                        referenceUsers[ID] = new Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>(
                            newName, newSurname, newBirthDate, user.Item4
                            );
                    }
                    else Console.WriteLine("Korisnik ne postoji s tom vrijednosti ID-a!");
                }

                else Console.WriteLine("Korisnik ne postoji s tom vrijednosti ID-a!");
            }

            void showUsers(Dictionary<int, Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>> referenceUsers)
            {
                Console.WriteLine("");
                var tempUsers = referenceUsers
                    .OrderBy(surname => surname.Value.Item2)
                    .ThenBy(name => name.Value.Item1)
                    .ToList();

                foreach (var user in tempUsers)
                {
                    Console.WriteLine($"{user.Key} - {user.Value.Item1} - {user.Value.Item2} - {user.Value.Item3.ToString("yyyy-MM-dd")}");
                }

                Console.WriteLine("");

                Console.WriteLine("Ispis korisnika s 2 ili vise putovanja");
                int numberOfTravels = 0;

                foreach (var user in referenceUsers)
                {
                    numberOfTravels = user.Value.Item4.Count;

                    if (numberOfTravels >= 2)
                        Console.WriteLine($"{user.Key} - {user.Value.Item1} - {user.Value.Item2} - {user.Value.Item3.ToString("yyyy-MM-dd")}");
                }

                Console.WriteLine("");

                Console.WriteLine("Ispis korisnika koji imaju preko 20 godina");
                int years = 0;

                foreach (var user in referenceUsers)
                {
                    DateTime userBirthDate = user.Value.Item3;
                    years = DateTime.Now.Year - userBirthDate.Year;

                    if (DateTime.Now.Month < userBirthDate.Month ||
                        (DateTime.Now.Month == userBirthDate.Month && DateTime.Now.Day < userBirthDate.Day))
                        years--;

                    if (years > 20)
                        Console.WriteLine($"{user.Key} - {user.Value.Item1} - {user.Value.Item2} - {userBirthDate.ToString("yyyy-MM-dd")}");
                }

                Console.WriteLine("");
            }
        }

        static void travelApp(Dictionary<int, Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>> users)
        {
            Console.WriteLine("");
            bool travelAppFinished = false;
            do
            {
                Console.WriteLine("1 - Unos novog putovanja");
                Console.WriteLine("2 - Brisanje putovanja");
                Console.WriteLine("3 - Uređivanje postojećeg putovanja");
                Console.WriteLine("4 - Pregled svih putovanja");
                Console.WriteLine("5 - Izvještaji i analize");
                Console.WriteLine("0 - Povratak na glavni izbornik");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            newTravel(users);
                            break;
                        case 2:
                            deleteTravel(users);
                            break;
                        case 3:
                            editTravel(users);
                            break;
                        case 4:
                            showTravels(users);
                            break;
                        case 5:
                            //reportsAndAnalyses();
                            break;
                        case 0:
                            Console.WriteLine("Izlazak iz aplkacije za putovanja...");
                            travelAppFinished = true;
                            break;
                        default:
                            Console.WriteLine("Krivi odabir!");
                            break;
                    }
                }
            }
            while (!travelAppFinished);

            void newTravel(Dictionary<int, Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>> referenceUsers)
            {
                Console.WriteLine("Odaberite ID korisnika kojem zelite dodati putovanje");

                Console.WriteLine("KORISNICI:");
                foreach (var user in referenceUsers)
                {
                    Console.WriteLine($"{user.Key} - {user.Value.Item1} - {user.Value.Item2} - {user.Value.Item3.ToString("yyyy-MM-dd")}");
                }
                Console.WriteLine("");

                string userID = Console.ReadLine();

                if (int.TryParse(userID, out int ID))
                {
                    if (referenceUsers.ContainsKey(ID))
                    {
                        var user = referenceUsers[ID];
                        string name = user.Item1;
                        string surname = user.Item2;
                        DateTime birthDate = user.Item3;

                        bool travelCheck = checkForAddingTravel("Zelite li unijeti putovanje (DA/NE): ");
                        if (!travelCheck)
                        {
                            return;
                        }

                        Console.WriteLine($"Dodaje se putovanje korisniku {ID} - {name} - {surname}");

                        var travels = user.Item4;
                        int numberOfTravles = travels.Count;
                        int travelID = numberOfTravles + 1;
                        foreach (var travel in travels)
                        {
                            if (travelID == travel.Key)
                                travelID++;
                        }

                        while (travelCheck)
                        {
                            DateTime travelDate = entryAndCheckDate("Unesite datum putovanja (YYYY-MM-DD): ");

                            double travelLength = entryAndCheckValue("Unesite kilometrazu: ");

                            double fuelConsumed = entryAndCheckValue("Unesite potroseno gorivo (L): ");

                            double pricePerLiter = entryAndCheckValue("Unesite cijenu po litri: ");

                            double totalCost = fuelConsumed * pricePerLiter;

                            travels.Add(travelID, new Tuple<DateTime, double, double, double, double>(travelDate, travelLength, fuelConsumed, pricePerLiter, totalCost));

                            travelCheck = checkForAddingTravel("Zelite li unijeti jos jedno putovanje (DA/NE): ");

                            if (travelCheck)
                                travelID++;
                        }

                        referenceUsers[ID] = new Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>(
                            name, surname, birthDate, travels
                            );
                    }
                    else Console.WriteLine("Korisnik ne postoji s tom vrijednosti ID-a!");
                }
            }

            void deleteTravel(Dictionary<int, Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>> referenceUsers)
            {
                Console.WriteLine("Odaberite ID korisnika kojem zelite izbrisati putovanje");

                Console.WriteLine("KORISNICI:");
                foreach (var user in referenceUsers)
                {
                    Console.WriteLine($"{user.Key} - {user.Value.Item1} - {user.Value.Item2} - {user.Value.Item3.ToString("yyyy-MM-dd")}");
                }
                Console.WriteLine("");

                string userID = Console.ReadLine();

                if (int.TryParse(userID, out int ID))
                {
                    if (referenceUsers.ContainsKey(ID))
                    {
                        var user = referenceUsers[ID];

                        Console.WriteLine("Odaberite broj putovanja koje zelite izbrisati");

                        var travels = user.Item4;
                        foreach (var travel in travels)
                        {
                            Console.WriteLine($"Putovanje #{travel.Key}");
                            Console.WriteLine($"Datum: {travel.Value.Item1.ToString("yyyy-MM-dd")}");
                            Console.WriteLine($"Kilometri: {travel.Value.Item2}");
                            Console.WriteLine($"Gorivo: {travel.Value.Item3} L");
                            Console.WriteLine($"Cijena po litri: {travel.Value.Item4} EUR");
                            Console.WriteLine($"Ukupno: {travel.Value.Item5} EUR");
                            Console.WriteLine("");
                        }

                        Console.WriteLine("");

                        string entryTravelID = Console.ReadLine();
                        if (int.TryParse(entryTravelID, out int travelID))
                        {
                            if (travels.ContainsKey(travelID))
                            {
                                var travel = travels[travelID];

                                Console.WriteLine("Brise se sljedece putovanje!");
                                Console.WriteLine("");
                                Console.WriteLine($"Putovanje #{travelID}");
                                Console.WriteLine($"Datum: {travel.Item1.ToString("yyyy-MM-dd")}");
                                Console.WriteLine($"Kilometri: {travel.Item2}");
                                Console.WriteLine($"Gorivo: {travel.Item3} L");
                                Console.WriteLine($"Cijena po litri: {travel.Item4} EUR");
                                Console.WriteLine($"Ukupno: {travel.Item5} EUR");
                                Console.WriteLine("");

                                user.Item4.Remove(travelID);
                            }
                            else Console.WriteLine("Ne postoji putovanje s tim brojem!");
                        }
                        else Console.WriteLine("Neispravan unos!");
                    }
                    else Console.WriteLine("Korisnik ne postoji s tom vrijednosti ID-a!");
                }
                else Console.WriteLine("Neispravan unos!");
            }

            void editTravel(Dictionary<int, Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>> referenceUsers)
            {
                Console.WriteLine("Odaberite ID korisnika kojem zelite urediti putovanje");

                Console.WriteLine("KORISNICI:");
                foreach (var user in referenceUsers)
                {
                    Console.WriteLine($"{user.Key} - {user.Value.Item1} - {user.Value.Item2} - {user.Value.Item3.ToString("yyyy-MM-dd")}");
                }
                Console.WriteLine("");

                string userID = Console.ReadLine();

                if (int.TryParse(userID, out int ID))
                {
                    if (referenceUsers.ContainsKey(ID))
                    {
                        var user = referenceUsers[ID];

                        Console.WriteLine("Odaberite broj putovanja koje zelite urediti");

                        var travels = user.Item4;
                        foreach (var travel in travels)
                        {
                            Console.WriteLine($"Putovanje #{travel.Key}");
                            Console.WriteLine($"Datum: {travel.Value.Item1.ToString("yyyy-MM-dd")}");
                            Console.WriteLine($"Kilometri: {travel.Value.Item2}");
                            Console.WriteLine($"Gorivo: {travel.Value.Item3} L");
                            Console.WriteLine($"Cijena po litri: {travel.Value.Item4} EUR");
                            Console.WriteLine($"Ukupno: {travel.Value.Item5} EUR");
                            Console.WriteLine("");
                        }

                        Console.WriteLine("");

                        string entryTravelID = Console.ReadLine();
                        if (int.TryParse(entryTravelID, out int travelID))
                        {
                            if (travels.ContainsKey(travelID))
                            {
                                var travel = travels[travelID];

                                DateTime travelDate = travel.Item1;
                                double travelLength = travel.Item2;
                                double fuelConsumed = travel.Item3;
                                double pricePerLiter = travel.Item4;
                                double totalCost = travel.Item5;

                                DateTime newTravelDate = entryAndCheckDate($"Unesite novi datum putovanja (YYYY-MM-DD) (ENTER za zadržati '{travelDate.ToString("yyyy-MM-dd")}'): ", travelDate);
                                double newTravelLength = entryAndCheckValue($"Unesite novu kilometrazu (ENTER za zadržati '{travelLength}'): ", travelLength);
                                double newFuelConsumed = entryAndCheckValue($"Unesite novo potroseno gorivo (L) (ENTER za zadržati '{fuelConsumed}'): ", fuelConsumed);
                                double newPricePerLiter = entryAndCheckValue($"Unesite novu cijenu po litri (ENTER za zadržati '{pricePerLiter}'): ", pricePerLiter);
                                double newTotalCost = totalCost;

                                if (newFuelConsumed != fuelConsumed || newPricePerLiter != pricePerLiter)
                                    newTotalCost = newFuelConsumed * newPricePerLiter;

                                travels[travelID] = new Tuple<DateTime, double, double, double, double>(
                                    newTravelDate, newTravelLength, newFuelConsumed, newPricePerLiter, newTotalCost
                                    );
                            }
                            else Console.WriteLine("Ne postoji putovanje s tim brojem!");
                        }
                        else Console.WriteLine("Neispravan unos!");
                    }
                    else Console.WriteLine("Korisnik ne postoji s tom vrijednosti ID-a!");
                }
                else Console.WriteLine("Neispravan unos!");
            }

            void showTravels(Dictionary<int, Tuple<string, string, DateTime, Dictionary<int, Tuple<DateTime, double, double, double, double>>>> referenceUsers)
            {
                Console.WriteLine("");
                Console.WriteLine("Ispis svih putovanja svih korisnika");
                Console.WriteLine("");

                foreach (var user in referenceUsers)
                {
                    Console.WriteLine($"{user.Key} - {user.Value.Item1} - {user.Value.Item2} - {user.Value.Item3.ToString("yyyy-MM-dd")}");
                    Console.WriteLine("");

                    var travels = user.Value.Item4;
                    foreach (var travel in travels)
                    {
                        Console.WriteLine($"Putovanje #{travel.Key}");
                        Console.WriteLine($"Datum: {travel.Value.Item1.ToString("yyyy-MM-dd")}");
                        Console.WriteLine($"Kilometri: {travel.Value.Item2}");
                        Console.WriteLine($"Gorivo: {travel.Value.Item3} L");
                        Console.WriteLine($"Cijena po litri: {travel.Value.Item4} EUR");
                        Console.WriteLine($"Ukupno: {travel.Value.Item5} EUR");
                        Console.WriteLine("");
                    }

                    Console.WriteLine("");
                }
            }
        }
    }
}
