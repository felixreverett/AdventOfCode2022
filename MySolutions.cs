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
        public void DayTwoPartOne()
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

        public void DayTwoPartTwo()
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

        public void DayThreePartOne()
        {
            char[] letterPriorities =
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };

            string[] input = File.ReadAllText(@"D:\Programming\C#\AdventOfCode2022\Inputs\DayThree.txt")
                .Replace("\r", "")
                .Split("\n").ToArray();

            int totalPriorityScore = 0;

            foreach (string rucksack in input)
            {
                char matchingChar = FindMeThatMatchingCharPleaseThanks(rucksack);
                
                totalPriorityScore += Array.IndexOf(letterPriorities, matchingChar) + 1;
                
            }

            char FindMeThatMatchingCharPleaseThanks(string rucksack)
            {
                int length = rucksack.Length;
                char matchingChar;
                for (int i = 0; i < length / 2; i++)
                {
                    for (int j = length / 2; j < length; j++)
                    {
                        if (rucksack[i] == rucksack[j])
                        {
                            matchingChar = rucksack[i];
                            return matchingChar;
                        }
                    }
                }
                return '_';
            }

            Console.WriteLine(totalPriorityScore);
        }

        public void DayThreePartTwo()
        {
            char[] letterPriorities =
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };

            string[] input = File.ReadAllText(@"D:\Programming\C#\AdventOfCode2022\Inputs\DayThree.txt")
                .Replace("\r", "")
                .Split("\n").ToArray();

            int totalPriorityScore = 0;
            
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 3 == 0)
                {
                    
                    char matchingChar = FindMeThatMatchingCharOneMoreTime(i);
                    
                    totalPriorityScore += Array.IndexOf(letterPriorities, matchingChar) + 1;
                }
            }

            Console.WriteLine($"The sum of the priorities of the matching badges is: {totalPriorityScore}.");

            char FindMeThatMatchingCharOneMoreTime(int index)
            {
                foreach (char a in input[index])
                {
                    foreach (char b in input[index + 1])
                    {
                        foreach (char c in input[index + 2])
                        {
                            if (a == b && b == c)
                            {
                                return a;
                            }
                        }
                    }
                }
                return '_';
            }
        }
        public void DayFourPartOne()
        {
            char[] delimiters = { ',', '-' };

            string[][] input = File.ReadAllText(@"D:\Programming\C#\AdventOfCode2022\Inputs\DayFour.txt")
                .Replace("\r", "")
                .Split("\n")
                .Select(i => i.Split(delimiters))
                .ToArray();

            int pairsToReconsider = 0;
            
            foreach (string[] line in input)
            {
                //check if first elf's assignments contain second elf's.
                if (int.Parse(line[0]) <= int.Parse(line[2]) && int.Parse(line[1]) >= int.Parse(line[3]))
                {
                    pairsToReconsider++;
                }
                //check if second elf's assignments contain first elf's.
                else if (int.Parse(line[2]) <= int.Parse(line[0]) && int.Parse(line[3]) >= int.Parse(line[1]))
                {
                    pairsToReconsider++;
                }
            }

            Console.WriteLine(pairsToReconsider);
        }

        public void DayFourPartTwo()
        {
            char[] delimiters = { ',', '-' };

            string[][] input = File.ReadAllText(@"D:\Programming\C#\AdventOfCode2022\Inputs\DayFour.txt")
                .Replace("\r", "")
                .Split("\n")
                .Select(i => i.Split(delimiters))
                .ToArray();

            int pairsToReconsider = 0;

            foreach (string[] line in input)
            {
                //check if first elf's upper >= second elf's lower or first elf's lower <= second elf's upper
                //a-b,c-d
                //if b >= c and a <= d
                if (int.Parse(line[1]) >= int.Parse(line[2]) && int.Parse(line[0]) <= int.Parse(line[3]))
                {
                    pairsToReconsider++;
                }
                //c-d,a-b
                //if d >= a and c <= b
                else if (int.Parse(line[3]) >= int.Parse(line[0]) && int.Parse(line[2]) <= int.Parse(line[1]))
                {
                    pairsToReconsider++;
                }
            }

            Console.WriteLine(pairsToReconsider);
        }

        public void DayFivePartOne()
        {
            // Load data and split into respective sections
            string[] input = File.ReadAllText(@"D:\Programming\C#\AdventOfCode2022\Inputs\DayFive.txt")
                .Replace("\r", "")
                .Split("\n")
                .ToArray();
            string[] commands = input.Where(n => n.StartsWith("move")).ToArray();
            string[] stackLines = input.Where(n => n.Contains("[")).ToArray();
            Array.Reverse(stackLines);

            // Parse the stack input into a list of Stack
            List<Objects.Stack> stacks = GenerateStacks(stackLines);

            // Reorder the stacks according to each instruction.
            stacks = RearrangeStacks(stacks, commands);

            // Print the result to the console as output
            // I would use a loop if I just wanted the last item
            Console.WriteLine("Rearranged stacks:");
            foreach (Objects.Stack stack in stacks)
            {
                Console.Write($"Stack {stack.Handle}: ");
                foreach (char l in stack.Items)
                {
                    Console.Write(l);
                }
                Console.Write("\n");
            }

            // Parse the input lines containing stack information
            List<Objects.Stack> GenerateStacks(string[] lines)
            {
                List<Objects.Stack> stacks = new();

                foreach (string line in lines)
                {
                    int currentListIndex = 0;
                    for (int i = 0; i < line.Length; i += 4 )
                    {
                        if (line[i+1] != ' ')
                        {
                            if (stacks.Count < currentListIndex + 1)
                            {
                                Objects.Stack newStack = new Objects.Stack((currentListIndex + 1).ToString());
                                stacks.Add(newStack);
                            }
                            stacks[currentListIndex].Items.Add(line[i + 1]);
                        }
                        currentListIndex++;
                    }
                }
                return stacks;
            }

            // Reorder the stacks
            List<Objects.Stack> RearrangeStacks(List<Objects.Stack> stacks, string[] commands)
            {
                foreach (string command in commands)
                {
                    string[] subcommands = command.Split(" ").ToArray();
                    int amount = int.Parse(subcommands[1]);
                    int stackFrom = int.Parse(subcommands[3]);
                    int stackTo = int.Parse(subcommands[5]);
                    for (int i = 0; i < amount; i++)
                    {
                        int topOfStack = stacks[stackFrom - 1].Items.Count;
                        char movedChar = stacks[stackFrom - 1].Items[topOfStack - 1];
                        stacks[stackFrom - 1].Items.RemoveAt(topOfStack - 1);
                        stacks[stackTo - 1].Items.Add(movedChar);
                    }
                }
                return stacks;
            }

            // This line of code doesn't do anything (my solution didn't need it), but I enjoyed writing it so I've left it
            int stackIndexLength = input.Where(n => n.Contains(" 1")).ToArray()[0].Split("   ").ToArray().Length; //"good" code
        }

        public void DayFivePartTwo()
        {
            // Load data and split into respective sections
            string[] input = File.ReadAllText(@"D:\Programming\C#\AdventOfCode2022\Inputs\DayFive.txt")
                .Replace("\r", "")
                .Split("\n")
                .ToArray();
            string[] commands = input.Where(n => n.StartsWith("move")).ToArray();
            string[] stackLines = input.Where(n => n.Contains("[")).ToArray();
            Array.Reverse(stackLines);

            // Parse the stack input into a list of Stack
            List<Objects.Stack> stacks = GenerateStacks(stackLines);

            // Reorder the stacks according to each instruction.
            stacks = RearrangeStacks2(stacks, commands);

            // Print the result to the console as output
            // I would use a loop if I just wanted the last item
            Console.WriteLine("Rearranged stacks:");
            foreach (Objects.Stack stack in stacks)
            {
                Console.Write($"Stack {stack.Handle}: ");
                foreach (char l in stack.Items)
                {
                    Console.Write(l);
                }
                Console.Write("\n");
            }

            // Parse the input lines containing stack information
            List<Objects.Stack> GenerateStacks(string[] lines)
            {
                List<Objects.Stack> stacks = new();

                foreach (string line in lines)
                {
                    int currentListIndex = 0;
                    for (int i = 0; i < line.Length; i += 4)
                    {
                        if (line[i + 1] != ' ')
                        {
                            if (stacks.Count < currentListIndex + 1)
                            {
                                Objects.Stack newStack = new Objects.Stack((currentListIndex + 1).ToString());
                                stacks.Add(newStack);
                            }
                            stacks[currentListIndex].Items.Add(line[i + 1]);
                        }
                        currentListIndex++;
                    }
                }
                return stacks;
            }

            // Reorder the stacks
            List<Objects.Stack> RearrangeStacks2(List<Objects.Stack> stacks, string[] commands)
            {
                foreach (string command in commands)
                {
                    // split the commands
                    string[] subcommands = command.Split(" ").ToArray();
                    int amount = int.Parse(subcommands[1]);
                    int stackFrom = int.Parse(subcommands[3]);
                    int stackTo = int.Parse(subcommands[5]);
                    int startIndex = stacks[stackFrom - 1].Items.Count - amount;

                    // move from one list to another using a "buffer" list
                    List<char> charsToMove = stacks[stackFrom - 1].Items.GetRange(startIndex, amount);
                    stacks[stackFrom - 1].Items.RemoveRange(startIndex, amount);
                    stacks[stackTo - 1].Items.AddRange(charsToMove);
                    
                }
                return stacks;
            }
        }
    }
}
