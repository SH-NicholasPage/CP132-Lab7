/*
* Name: [YOUR NAME HERE]
* South Hills Username: [YOUR SOUTH HILLS USERNAME HERE]
*/
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab7
{
    class Source
    {
        //The below three variables are the file paths to the files needed.
        public static readonly String geraldinesRecordsLocation = "input1.txt";
        public static readonly String gerardsRecordsLocation = "input2.txt";
        public static readonly String resultFile = "output.txt";

        public static void PerformMerge()
        {
            if(File.Exists(gerardsRecordsLocation) == false)
            {
                Console.Error.WriteLine(geraldinesRecordsLocation + " was not generated! Let the instructor know about this ASAP.");
            }
            else if(File.Exists(gerardsRecordsLocation) == false)
            {
                Console.Error.WriteLine(gerardsRecordsLocation + " was not generated! Let the instructor know about this ASAP.");
            }
            else if(File.Exists(resultFile) == true)
            {
                Console.Error.WriteLine(resultFile + " still exists! Let the instructor know about this ASAP.");
            }

            //TODO: Write your code here, after the file checks
        }

        //The start of a sort method has been provided here for you.
        //  You can change it however you like or delete it.
        public static int[] Sort(String[] numbers)
        {
            int[] nums = new int[numbers.Length];

            return nums;
        }
    }
}
