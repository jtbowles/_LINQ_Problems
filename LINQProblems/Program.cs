using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQProblems
{
    public class Program
    {
        static void Main(string[] args)
        {
            // LINQ problem 1
            DisplayProblem(1);
            RemoveWordsContaining();
            ContinueThrough();

            // LINQ problem 2
            DisplayProblem(2);
            NoDuplicates();
            ContinueThrough();

            // LINQ problem 3
            DisplayProblem(3);
            ClassAverages();
            ContinueThrough();

            // LINQ problem 4
            DisplayProblem(4);
            CharacterOccurances();
            ContinueThrough();
        }

        static void DisplayProblem(int problem)
        {
            Console.Clear();
            Console.WriteLine("  -----------------------");
            Console.WriteLine("   Solution to LINQ #{0}",problem);
            Console.WriteLine("  -----------------------");
        }

        static void ContinueThrough()
        {
            Console.WriteLine("  -----------------------");
            Console.WriteLine("      press [enter] ");
            Console.ReadLine();
        }

        static void RemoveWordsContaining()
        {
            var words = new List<string>() { "the", "bike", "this", "it", "tenth", "mathematics" };
            var wordsWithTH = words.Where(w => w.Contains("th"));
            foreach (var word in wordsWithTH)
            {
                Console.WriteLine(word);
            }
        }

        static void NoDuplicates()
        {
            var names = new List<string>() { "Mike", "Brad", "Nevin", "Ian", "Mike" };
            var namesWithoutDuplicates = names.Select(n => n).Distinct();
            foreach (var name in namesWithoutDuplicates)
            {
                Console.WriteLine(name);
            }
        }

        static void ClassAverages()
        {
            var classGrades = new List<string>() { "80,100,92,89,65", "93,81,78,84,69", "73,88,83,99,64", "98,100,66,74,55" };
            var studentGrade = new List<int>();
            double classAverage = 0;

            foreach (var grade in classGrades)
            {
                studentGrade = grade.Split(',').Select(g => int.Parse(g)).ToList();
                var gradeValue = studentGrade.Where(s => s != studentGrade.Min()).Average();
                classAverage += gradeValue;
            }

            Console.WriteLine(classAverage / classGrades.Count);
        }

        static void CharacterOccurances()
        {
            string str = "Terrill";
            char[] characterArray = str.ToUpper().ToArray();
            Array.Sort(characterArray);

            str = new string(characterArray);
            var frequencyOfCharacters =
                from x in str
                group x by x into y
                select y;

            var result = "";

            foreach (var character in frequencyOfCharacters)
            {
                result += character.Key + "" + character.Count();
            }

            Console.WriteLine(result);

        }
    }
}
