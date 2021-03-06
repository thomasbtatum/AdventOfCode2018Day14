﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay14
{
    class Program
    {
        static void Main(string[] args)
        {
            var startRecipe = 633601;

            //var input = "37";
            while (true)
            {
                var scores = new List<int>();
                scores.Add(3);
                scores.Add(7);

                var firstScore = scores[0];
                var secondScore = scores[1];
                var firstPos = 0;
                var secondPos = 1;
                var totalRecipes = 2;
                for (int i = 0; i < 100000000; i++)
                {
                    totalRecipes += AddScore(firstScore, secondScore, scores);
                    firstPos = newPos(firstPos, firstScore, scores.Count());
                    secondPos = newPos(secondPos, secondScore, scores.Count());
                    firstScore = scores[firstPos];
                    secondScore = scores[secondPos];
                    //printScore(firstPos, secondPos, scores);

                    //if (totalRecipes > startRecipe + 10)
                    //{
                    //    break;
                    //}
                }

                var theList = ListToString(scores);
                //printLastTen(scores, startRecipe);
                while (true)
                {
                    Console.WriteLine("Enter the sequence:");

                    var sequence = Console.ReadLine();

                    var index = theList.IndexOf(sequence);
                    if(index > -1)
                    {
                        Console.WriteLine(string.Format("{0}", index));
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                    }
                }
            }

        }

        private static string ListToString(List<int> scores)
        {
            var s = new StringBuilder();
            foreach (int t in scores)
            {
                s.Append(t);
            }
            return s.ToString();
        }

        private static void printLastTen(List<int> scores, int startCount)
        {
            var sb = new StringBuilder();
            for (int i = startCount; i < startCount+10; i++)
            {
                    sb.Append(scores[i]);
            }
            Console.WriteLine(sb.ToString());
        }

        private static void printScore(int firstPos, int secondPos, List<int> scores)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < scores.Count(); i++)
            {
                if (firstPos == i)
                {
                    sb.Append("(" + scores[i] + ")");
                }
                else
                if (secondPos == i)
                {
                    sb.Append("[" + scores[i] + "]");
                }
                else
                    sb.Append(scores[i]);

                sb.Append(" ");

            }
            Console.WriteLine(sb.ToString());
        }

        private static int AddScore(int firstScore, int secondScore, List<int> scores)
        {
            var result = firstScore + secondScore;
            var textResult = result.ToString();
            int recipeCount = 0;
            for (int i = 0; i < textResult.Length; i++)
            {
                scores.Add(textResult[i] - '0');
                recipeCount++;
            }
            return recipeCount;
        }

        private static int newPos(int currentPos, int currentScore, int sizeScores)
        {
            return (currentPos + 1 + currentScore) % sizeScores; 
        }
    }
}
