using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solutions
{
    public class DaySix
    {
        // My first solution checks every sequence of N characters
        // For each sequence it runs a check and returns true if unique
        // However, this check doesn't need to be rerun for characters 2-N after the initial setup
        // I may go back later and optimise this

        public void DaySixPartOne()
        {
            string input = File.ReadAllText(@"..\..\..\Inputs\Day6.txt").Replace("\r", "");
            int length = 14; //set this to the length of your sequence to check
            int result = GetStartOfDataStream(input, length);
            if (result == -1)
            {
                Console.WriteLine($"Error. No sequence of {length} characters in the data stream are unique.");
            }
            else
            {
                Console.WriteLine($"Found start of data stream at location: {result}");
            }
            
        }
        public int GetStartOfDataStream(string input, int length)
        {
            for (int i = 0;  i < input.Length; i++)
            {
                string substring = input.Substring(i, length);
                if (AreCharactersInSequenceUnique(substring))
                {
                    return i+length;
                }
            }
            return -1;
        }

        public bool AreCharactersInSequenceUnique(string sequence)
        {
            //Console.WriteLine($"Checking substring: {sequence}");
            for (int i = 0; i < sequence.Length - 1; i++)
            {
                for (int j = i + 1; j < sequence.Length; j++)
                {
                    //Console.WriteLine($"Comparing {sequence[i]} to {sequence[j]}");
                    if (sequence[i] == sequence[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
