using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace Part_7___Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Note: after you close the number menu the string one will open.");
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
            List<string> vegetables = new List<string>() { "CARROT", "BEET", "CELERY", "RADISH", "CABBAGE" };
            while (true)
            {
                Console.WriteLine("Press enter to open the menu.");
                Console.ReadLine();
                Console.Clear();
                int count = 1;
                foreach (string veg in vegetables) { Console.WriteLine($"{count} - {veg}"); count++; }
                Console.WriteLine("Menu");
                Console.WriteLine("-removeVegetableIndex");
                Console.WriteLine("-removeVegetableValue");
                Console.WriteLine("-searchForVegetable");
                Console.WriteLine("-addVegetable");
                Console.WriteLine("-sortList");
                Console.WriteLine("-clearList");
                Console.WriteLine("-close");
                menuPick = Console.ReadLine();
                if (menuPick.ToLower().Contains("removevegetableindex"))
                {
                    Console.WriteLine("What index do you want to remove?");
                    bool isInt = Int32.TryParse(Console.ReadLine(), out int indexToRemove);
                    if (isInt) try
                        {
                            vegetables.RemoveAt(indexToRemove - 1);
                        }
                        catch
                        {
                            Console.WriteLine("You did not pick a valid value.");
                        }
                }
                else if (menuPick.ToLower().Contains("removevegetablevalue"))
                {
                    string valueToRemove;
                    Console.WriteLine("Enter the value you want to remove");
                    valueToRemove = Console.ReadLine();
                    valueToRemove = valueToRemove.ToUpper();
                    vegetables.Remove(valueToRemove);
                }
                else if (menuPick.ToLower().Contains("searchforvegetable"))
                {
                    Console.WriteLine("Enter the value you want to look for?");
                    string valueTofind = Console.ReadLine();
                    count = 0;
                    foreach (var ve in vegetables)
                    {
                        count++;
                        if (ve == valueTofind.ToUpper()) Console.WriteLine($"Found {ve}, index is {count}");
                    }
                }
                else if (menuPick.ToLower().Contains("addvegetable"))
                {
                    Console.WriteLine("Type the name of the vegetable you want to add");
                    string newVeg = Console.ReadLine().ToUpper();
                    bool inList = false;
                    foreach (var ve in vegetables) if (ve == newVeg) inList = true;
                    if (!inList) vegetables.Add(newVeg);
                    else Console.WriteLine("In list already.");
                }
                else if (menuPick.ToLower().Contains("sortlist")) vegetables.Sort();
                else if (menuPick.ToLower().Contains("clearlist")) vegetables.Clear();
                else if (menuPick.ToLower().Contains("close")) break;
                else Console.WriteLine("Invalid choice.");
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