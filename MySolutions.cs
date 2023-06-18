using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class MySolutions
    {
        public void DayOne()
        {
            //load .txt document from path
            //turn data into jagged array to make it usable
            //get total calories per elf and save to new array
            //find highest total calories, and find the elf who has those calories

            string[][] caloriesByElf = File.ReadAllText(@"D:\Programming\C#\AdventOfCode2022\Inputs\Elfnumbers.txt")
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
            Console.WriteLine(totalCaloriesArray[totalCaloriesArray.Length - 1] + totalCaloriesArray[totalCaloriesArray.Length - 2] + totalCaloriesArray[totalCaloriesArray.Length - 3]);
        }
        public void DayTwo()
        {
            string[][] input = File.ReadAllText(@"D:\Programming\C#\AdventOfCode2022\Inputs\DayTwo.txt")
                .Replace("\r", "")
                .Split("\n").Select(i => i.Split(" ")).ToArray();

            int totalScore = 0;
            int valX = 1; int valY = 2; int valZ = 3;
            int loss = 0; int draw = 3; int win = 6;
            // A is rock | B is paper | C is scissors
            // X is rock | Y is paper | Z is scissors
            foreach (string[] game in input)
            {
                switch (game[0])
                {
                    case "A":
                        switch (game[1])
                        {
                            case "X":
                                totalScore += valX + draw;
                                break;
                            case "Y":
                                totalScore += valY + win;
                                break;
                            case "Z":
                                totalScore += valZ + loss;
                                break;
                        }
                        break;
                    case "B":
                        switch (game[1])
                        {
                            case "X":
                                totalScore += valX + loss;
                                break;
                            case "Y":
                                totalScore += valY + draw;
                                break;
                            case "Z":
                                totalScore += valZ + win;
                                break;
                        }
                        break;
                    case "C":
                        switch (game[1])
                        {
                            case "X":
                                totalScore += valX + win;
                                break;
                            case "Y":
                                totalScore += valY + loss;
                                break;
                            case "Z":
                                totalScore += valZ + draw;
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine(totalScore);
        }
    }
}
