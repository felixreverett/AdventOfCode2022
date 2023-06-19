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
            int rock = 1; int paper = 2; int scissors = 3;
            int loss = 0; int draw = 3; int win = 6;
            // A is rock | B is paper | C is scissors
            // X is rock | Y is paper | Z is scissors
            foreach (string[] game in input)
            {
                switch (game[1])
                {
                    case "X": //need to lose
                        switch (game[0])
                        {
                            case "A": //play scissors
                                totalScore += loss + scissors;
                                break;
                            case "B": //play rock
                                totalScore += loss + rock;
                                break;
                            case "C": //play paper
                                totalScore += loss + paper;
                                break;
                        }
                        break;
                    case "Y": //need to draw
                        switch (game[0])
                        {
                            case "A": //play rock
                                totalScore += draw + rock;
                                break;
                            case "B": //play paper
                                totalScore += draw + paper;
                                break;
                            case "C": //play scissors
                                totalScore += draw + scissors;
                                break;
                        }
                        break;
                    case "Z": //need to win
                        switch (game[0])
                        {
                            case "A": //play paper
                                totalScore += win + paper;
                                break;
                            case "B": //play scissors
                                totalScore += win + scissors;
                                break;
                            case "C": //play rock
                                totalScore += win + rock;
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine(totalScore);
        }
    }
}
