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
        }
    }
}
