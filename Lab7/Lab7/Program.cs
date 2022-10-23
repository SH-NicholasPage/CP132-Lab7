//DO NOT MODIFY THIS FILE
using System;
using System.IO;
using System.Linq;

namespace Lab7
{
    class Program
    {
        private static byte MAX_SCORE = 10;
        private static int[] input1Nums;
        private static int[] input2Nums;

        public static void Main()
        {
            //Delete the output file if it exists
            if (File.Exists(Source.resultFile) == true)
            {
                File.Delete(Source.resultFile);
            }

            GenerateInputFiles();
            int[] expectedResult = input1Nums.Concat(input2Nums).OrderBy(x => x).ToArray();
            int[] extraCreditResult = input1Nums.Union(input2Nums).OrderBy(x => x).ToArray();
            Source.PerformMerge();

            if (File.Exists(Source.resultFile) == false)
            {
                Console.Error.WriteLine("Output file was not created.");
                EndProgram();
            }

            float score = CalculateScore(expectedResult);
            float extraCreditScore = CalculateScore(extraCreditResult);

            if(extraCreditScore == MAX_SCORE)
            {
                score = MAX_SCORE;
            }

            if (score < MAX_SCORE)
            {
                Console.WriteLine("Output file is incorrect.");
            }

            EndProgram(score, extraCreditScore);
        }

        private static void GenerateInputFiles(int numbersToGenerate = 100, int dupNumbersToGen = 3)
        {
            int[] repeatingNumbers = Enumerable.Range(0, dupNumbersToGen).Select(x => x = Random.Shared.Next(1000000, 9990001)).ToArray();
            int[] inputAInterjection = Enumerable.Range(0, repeatingNumbers.Length).Select(x => x = Random.Shared.Next(0, numbersToGenerate)).ToArray();
            int inputAOrder = Random.Shared.Next(0, dupNumbersToGen);
            int[] inputBInterjection = Enumerable.Range(0, repeatingNumbers.Length).Select(x => x = Random.Shared.Next(0, numbersToGenerate)).ToArray();
            int inputBOrder = Random.Shared.Next(0, dupNumbersToGen);
            input1Nums = new int[numbersToGenerate];
            input2Nums = new int[numbersToGenerate];

            for (int i = 0; i < numbersToGenerate; i++)
            {
                if(inputAInterjection.Contains(i) == true)
                {
                    input1Nums[i] = repeatingNumbers[inputAOrder++];
                    inputAOrder = (inputAOrder >= dupNumbersToGen) ? 0 : inputAOrder;
                }
                else
                {
                    input1Nums[i] = Random.Shared.Next(1000000, 9990001);
                }

                if (inputBInterjection.Contains(i) == true)
                {
                    input2Nums[i] = repeatingNumbers[inputBOrder++];
                    inputBOrder = (inputBOrder >= dupNumbersToGen) ? 0 : inputBOrder;
                }
                else
                {
                    input2Nums[i] = Random.Shared.Next(1000000, 9990001);
                }
            }

            File.WriteAllLines(Source.geraldinesRecordsLocation, input1Nums.Select(x => x.ToString()));
            File.WriteAllLines(Source.gerardsRecordsLocation, input2Nums.Select(x => x.ToString()));
        }

        private static float CalculateScore(int[] expectedResult)
        {
            float score = MAX_SCORE;
            int[] generatedResult = File.ReadAllLines(Source.resultFile).Select(x => Convert.ToInt32(x)).ToArray();

            for(int i = 0; i < Math.Min(expectedResult.Length, generatedResult.Length); i++)
            {
                if(generatedResult[i] != expectedResult[i])
                {
                    score -= (float)MAX_SCORE / expectedResult.Length;
                }
            }

            score -= ((float)MAX_SCORE / expectedResult.Length) * Math.Abs(expectedResult.Length - generatedResult.Length);

            return score;
        }

        private static void EndProgram(float score = 0, float extraCreditScore = 0)
        {
            Console.WriteLine("***Score: " + Math.Abs(Math.Round(score, 2)) + "/" + MAX_SCORE);

            if(extraCreditScore == MAX_SCORE)
            {
                Console.WriteLine("***Extra credit achieved: +5 points");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();//For the Mac users :)
            Environment.Exit(0);
        }
    }
}