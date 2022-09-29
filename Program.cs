using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace Part_7___Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string menuPick = "";
            int value;
            List<int> numbers = makeList();
            while (true)
            {
                Console.WriteLine("Press enter to open the menu");
                Console.ReadLine();
                Console.Clear();
                string listDisplay = "[";
                foreach (int i in numbers) listDisplay = listDisplay + $"{i}, ";
                listDisplay = listDisplay.Trim();
                listDisplay = listDisplay.TrimEnd(',');
                listDisplay = listDisplay + "]";
                Console.WriteLine($"Your list:\n{listDisplay}");
                Console.WriteLine("Menu");
                Console.WriteLine("-sort");
                Console.WriteLine("-newList");
                Console.WriteLine("-removeNumber");
                Console.WriteLine("-addNumber");
                Console.WriteLine("-occurrences");
                Console.WriteLine("-largest");
                Console.WriteLine("-smallest");
                Console.WriteLine("-sumAndAverage");
                Console.WriteLine("-mostOccurring");
                Console.WriteLine("-close");
                menuPick = Console.ReadLine();

                if (menuPick.ToLower().Contains("sort")) numbers.Sort();

                else if (menuPick.ToLower().Contains("newlist")) numbers = makeList();

                else if (menuPick.ToLower().Contains("removenumber"))
                {
                    Console.WriteLine("What number do you want to remove?");
                    bool isInt = Int32.TryParse(Console.ReadLine(), out int numberToRemove);
                    if (isInt) while (numbers.Remove(numberToRemove)) numbers.Remove(numberToRemove);
                    else Console.WriteLine("You did not pick a whole number.");
                }

                else if (menuPick.ToLower().Contains("addnumber"))
                {
                    Console.WriteLine("What number do you want to add?");
                    bool isInt = Int32.TryParse(Console.ReadLine(), out int numberToAdd);
                    if (isInt) numbers.Add(numberToAdd);
                    else Console.WriteLine("You did not pick a whole number.");
                }

                else if (menuPick.ToLower().Contains("occurrences"))
                {
                    var g = numbers.GroupBy(i => i);
                    foreach (var group in g) Console.WriteLine($"{group.Key} was found {group.Count()} time(s).");
                }

                else if (menuPick.ToLower().Contains("largest")) Console.WriteLine($"{numbers.Max()}");

                else if (menuPick.ToLower().Contains("smallest")) Console.WriteLine($"{numbers.Min()}");

                else if (menuPick.ToLower().Contains("sumandaverage"))
                {
                    double sumOfNumbers = 0;
                    double count = 0;
                    foreach (int number in numbers)
                    {
                        sumOfNumbers = sumOfNumbers + number;
                        count++;
                    }
                    Console.WriteLine($"Sum: {sumOfNumbers}\nAverage: {Math.Round(sumOfNumbers/count,3)}");
                }
                else if (menuPick.ToLower().Contains("mostoccurring"))
                {
                    int mostOccurring = 0;
                    int howManyOccurring = 0;
                    var g = numbers.GroupBy(i => i);
                    foreach (var group in g)
                    {
                        if(group.Count() > howManyOccurring)
                        {
                            howManyOccurring = group.Count();
                            mostOccurring = group.Key;
                        }
                    }
                    Console.WriteLine($"The most occurring number(s) were found {howManyOccurring} times. They are:");
                    foreach (var group in g)
                    {
                        if(group.Count() == howManyOccurring)
                        {
                            Console.WriteLine($"{group.Key}");
                        }
                    }
                }
                else if (menuPick.ToLower().Contains("close")) break;

                else Console.WriteLine("That is not a choice.");
            }
            while(true)
            {
                Console.WriteLine("Press enter to open the menu.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("-removeVegetableIndex");
                Console.WriteLine("-removeVegetableValue");
                Console.WriteLine("-searchForVegetable");
                Console.WriteLine("-addVegetable");
                Console.WriteLine("-sortList");
                Console.WriteLine("-clearList");
            }
        }
        static public List<int> makeList()
        {
            Random randomGen = new Random();
            List<int> numbers = new List<int>();
            for (int i = 0; i < 20; i++) numbers.Add(randomGen.Next(10, 21));
            return numbers;
        }
    }
}