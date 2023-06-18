// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Timers;

internal class Program
{
    private static void Main(string[] args)
    {
        //load .txt document from path
        //turn data into jagged array to make it usable
        //get total calories per elf and save to new array
        //find highest total calories, and find the elf who has those calories

        string[][] caloriesByElf = File.ReadAllText(@"D:\Programming\C#\AdventOfCode2022\Elfnumbers.txt")
            .Replace("\r", "")
            .Split("\n\n").Select(i => i.Split("\n").ToArray()).ToArray();

        int[] totalCaloriesArray = new int[caloriesByElf.Count()];
        int currentElf = 0;
        foreach (string[] elf in caloriesByElf)
        {
            int calorieTotal = 0;
            foreach (string foodItem in elf)
            {
                calorieTotal += Int32.Parse(foodItem);
            }
            totalCaloriesArray[currentElf] = calorieTotal;
            currentElf++;
        }

        Array.Sort(totalCaloriesArray);
        Console.WriteLine(totalCaloriesArray[totalCaloriesArray.Length-1]+ totalCaloriesArray[totalCaloriesArray.Length - 2]+ totalCaloriesArray[totalCaloriesArray.Length - 3]);

    }
}