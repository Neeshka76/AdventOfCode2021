using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			string input;
			char letterIndex;
			bool end = false;
			// Put the console on max size
			Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
			Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
			Console.SetWindowPosition(0, 0);
			// Menu to select the day
			do
			{
				Console.WriteLine("******************************* Advent of Code 2021 *******************************");
				for(int i = 1; i <= 25; i++)
				{
					for(int j = 1; j <= 2; j++)
					{
						if(j == 1)
						{
							letterIndex = 'a';
						}
						else
						{
							letterIndex = 'b';
						}
						Console.WriteLine("- Day {0}, Puzzle {1} : {0}{1}", i, letterIndex);
					}
				}
				Console.WriteLine("To quit the program : exit");
				Console.WriteLine("Please select a day typing the correct value");
				// Wait for the selection
				input = Console.ReadLine();
				// Read the input and send the name file containing the data
				switch (input)
				{
					case "1a":
						Day1PuzzleA(input);
						break;
					case "1b":
						Day1PuzzleB(input);
						break;
					case "2a":
						Day2PuzzleA(input);
						break;
					case "2b":
						Day2PuzzleB(input);
						break;
					case "3a":
						Day3PuzzleA(input);
						break;
					case "3b":
						Day3PuzzleB(input);
						break;
					case "4a":

						break;
					case "4b":

						break;
					case "5a":

						break;
					case "5b":

						break;
					case "6a":

						break;
					case "6b":

						break;
					case "7a":

						break;

					case "7b":

						break;
					case "8a":

						break;
					case "8b":

						break;
					case "9a":

						break;
					case "9b":

						break;
					case "10a":

						break;
					case "10b":

						break;
					case "11a":

						break;
					case "11b":

						break;
					case "12a":

						break;
					case "12b":

						break;
					case "13a":

						break;
					case "13b":

						break;
					case "14a":

						break;
					case "14b":

						break;
					case "15a":

						break;
					case "15b":

						break;
					case "16a":

						break;
					case "16b":

						break;
					case "17a":

						break;
					case "17b":

						break;
					case "18a":

						break;
					case "18b":

						break;
					case "19a":

						break;
					case "19b":

						break;
					case "20a":

						break;
					case "20b":

						break;
					case "21a":

						break;
					case "21b":

						break;
					case "22a":

						break;
					case "22b":

						break;
					case "23a":

						break;
					case "23b":

						break;
					case "24a":

						break;
					case "24b":

						break;
					case "25a":

						break;
					case "25b":

						break;
					case "exit":
						// Could have put the exit here but I find it cleaner
						end = true;
						break;
					default:
						//Clear the screen and display an error
						
						Console.WriteLine("Error, wrong input");
						break;
				}
			} while (!end);
			Environment.Exit(0);
		}
		private static void Day1PuzzleA(string namefile)
		{
			// Get the file
			string[] linesRead = ReturnTextLines(namefile);
			int nbIncrement = 0;
			int nbMinus = 0;
			int nbActual = 0;
			bool allowIncrement;
			int nbLine = 0;
			// For each lines
			foreach (string line in linesRead)
			{
				// compare only when at the 2rd line
				if (nbLine != 0)
				{
					// Read the line and store the value
					int.TryParse(line, out nbActual);
					// Compare with the previous value and if the value is greater than the previous one then allow to add 1 to the number of increment
					allowIncrement = CompareNum(nbActual, nbMinus);
					if (allowIncrement)
					{
						nbIncrement++;
					}
				}
				nbMinus = nbActual;
				nbLine++;
			}
			// Display the result
			Console.WriteLine(nbIncrement);
			Console.ReadKey();
		}

		private static void Day1PuzzleB(string namefile)
		{
			string[] linesRead = ReturnTextLines(namefile);
			int nbIncrement = 0;
			int nbMinus = 0;
			int nbActual = 0;
			bool allowIncrement;
			int nbLine = 0;
			List<int> lineStacks = new List<int>();
			int nbIndice = 0;
			int result = 0;
			int total3Lines = 0;
			// treat the line 1, 2, 3 then the 2, 3, 4 etc...
			while (nbIndice < linesRead.Length - 2)
			{
				//For each stack of 3 add the total value to a list on int
				for (int i = nbIndice; i <= nbIndice + 2; i++)
				{
					if (int.TryParse(linesRead[i], out result))
					{
						total3Lines += result;
						// At the third value added, add the result to a list
						if (i == nbIndice + 2)
						{
							lineStacks.Add(total3Lines);
							total3Lines = 0;
						}
					}
				}
				nbIndice++;
			}
			// For each stack, compare if the previous value is greater or not then add one if it's true
			foreach (int lineStack in lineStacks)
			{
				// Same as Day 1 Puzzle A
				if (nbLine != 0)
				{
					nbActual = lineStack;
					allowIncrement = CompareNum(nbActual, nbMinus);
					if (allowIncrement)
					{
						nbIncrement++;
					}
				}
				nbMinus = nbActual;
				nbLine++;
			}
			Console.WriteLine(nbIncrement);
			Console.ReadKey();
		}

		private static void Day2PuzzleA(string namefile)
		{
			string[] linesRead = ReturnTextLines(namefile);
			int depth = 0;
			int horizontal = 0;
			int h;
			int d;
			int result;
			string[] splitLine;
			foreach (string line in linesRead)
			{
				// Split the value in 2 string if found a space
				splitLine = line.Split((char)32);
				// If the left part before the space is 
				switch (splitLine[0])
				{
					// If forward, add the right value to horizontal
					case "forward":
						if (int.TryParse(splitLine[1], out h))
						{
							horizontal += h;
						}
						break;
					// If down, add the right value to depth
					case "down":
						if (int.TryParse(splitLine[1], out d))
						{
							depth += d;
						}
						break;
					// If down, remove the right value to depth
					case "up":
						if (int.TryParse(splitLine[1], out d))
						{
							depth -= d;
						}
						break;
				}
			}
			// Multiply the total depth and total horizontal to get the value
			result = depth * horizontal;
			Console.WriteLine(result);
			Console.ReadKey();
		}

		private static void Day2PuzzleB(string namefile)
		{
			// Exactly the same procedure than Day 2 Puzzle A except add aim value
			string[] linesRead = ReturnTextLines(namefile);
			int depth = 0;
			int horizontal = 0;
			int aim = 0;
			int h;
			int a;
			int result;
			string[] splitLine;
			foreach (string line in linesRead)
			{
				splitLine = line.Split((char)32);
				switch (splitLine[0])
				{
					// if forward, add value to horizontal and to depth add the 
					case "forward":
						if (int.TryParse(splitLine[1], out h))
						{
							horizontal += h;
							depth += aim * h;
						}
						break;
					// if down add the value to aim
					case "down":
						if (int.TryParse(splitLine[1], out a))
						{
							aim += a;
						}
						break;
					// if up remove the value to aim
					case "up":
						if (int.TryParse(splitLine[1], out a))
						{
							aim -= a;
						}
						break;
				}
			}
			result = depth * horizontal;
			Console.WriteLine(result);
			Console.ReadKey();
		}
		private static void Day3PuzzleA(string namefile)
        {
			string[] linesRead = ReturnTextLines(namefile);
			
			int[] arrayTotal12Column = new int[12];
			int sizeOfFileDivideBy2 = linesRead.GetLength(0) / 2;
			string gammaBinary;
			string epsilonBinary;
			int gamma = 0;
			int epsilon = 0;
			int result = 0;
			//Get an array of the number of 1 by index (11 = right, 0 = left)
			arrayTotal12Column = SplitStringAndAddValue(linesRead);
			gammaBinary = CalculateGamma(arrayTotal12Column, sizeOfFileDivideBy2);
			epsilonBinary = CalculateEpsilon(gammaBinary);
			gamma = Convert.ToInt32(gammaBinary, 2);
			epsilon = Convert.ToInt32(epsilonBinary, 2);
			result = epsilon * gamma;
			Console.WriteLine(result);
		}

		private static void Day3PuzzleB(string namefile)
        {
			string[] linesRead = ReturnTextLines(namefile);
			List<string> newList = new List<string>();
			List<string> ListWith0 = new List<string>();
			List<string> ListWith1 = new List<string>();
			char[] fileListChar;
			string gammaBinary;
			string epsilonBinary;
			int gamma = 0;
			int epsilon = 0;
			int result = 0;
			int maxLength = 0;
			bool gammaDone = false;
			bool epsilonDone = false;
			do
			{
				newList.Clear();
				newList = linesRead.ToList();
				maxLength = newList[0].Length;
				for (int i = 0; i < maxLength; i++)
				{
					foreach (string fileList in newList)
					{
						fileListChar = fileList.ToCharArray();
						if (fileListChar[i] == '1')
						{
							ListWith1.Add(fileList);
						}
						else
						{
							ListWith0.Add(fileList);
						}
					}
					if (ListWith1.Count() >= ListWith0.Count())
					{
						newList.Clear();
						newList = gammaDone ? ListWith0.ToList() : ListWith1.ToList();
					}
					else
					{
						newList.Clear();
						newList = gammaDone ? ListWith1.ToList() : ListWith0.ToList();
					}
					ListWith1.Clear();
					ListWith0.Clear();
					if (newList.Count() == 1)
					{
						i = maxLength + 1;
					}
					//Console.WriteLine("Size : " + newList.Count().ToString());
				}
				if (!gammaDone)
				{
					gammaBinary = newList[0].ToString();
					gamma = Convert.ToInt32(gammaBinary, 2);
					gammaDone = true;
				}
				else
				{
					epsilonBinary = newList[0].ToString();
					epsilon = Convert.ToInt32(epsilonBinary, 2);
					epsilonDone = true;
				}
			} while (!gammaDone || !epsilonDone);
			result = epsilon * gamma;
			Console.WriteLine(result);
		}
		// This method read the file name.txt at the place where the .exe is executed and returns all the lines value
		private static string[] ReturnTextLines(string name)
		{
			string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + name + ".txt";
			string[] lines = File.ReadAllLines(path);
			return lines;
		}
		// Compare the n line to the n-1 line
		private static bool CompareNum(int n, int nMinusOne)
		{
			if (n > nMinusOne)
				return true;
			else
				return false;
		}

		private static int[] SplitStringAndAddValue(string[] lines)
        {
			char[] array12Column;
			int num = 0;
			int[] arrayTotal = new int[12];
			foreach (string line in lines)
			{
				array12Column = line.ToCharArray();

				for (int i = 0; i < array12Column.GetLength(0); i++)
				{
					int.TryParse(array12Column[i].ToString(), out num);
					arrayTotal[i] += num;
				}
			}
			return arrayTotal;
		}

		private static string CalculateGamma(int[] values, int sizeOfFileDivideBy2)
        {
			string gamma;
			int[] indexGamma = new int[12];

			for(int i = 0; i < values.GetLength(0); i++)
            {

				indexGamma[i] = values[i] > sizeOfFileDivideBy2 ? 1 : 0;
            }

			gamma = string.Join("", indexGamma);

			return gamma;
        }
		private static string CalculateEpsilon(string gamma)
        {
			string epsilon;
			char[] gammaChar = gamma.ToCharArray();
			char[] epsilonChar = new char[gammaChar.GetLength(0)];
			for(int i = 0; i < gammaChar.GetLength(0); i++)
            {
				epsilonChar[i] = gammaChar[i] == '1' ? '0' : '1';
            }
			epsilon = string.Join("", epsilonChar);
			return epsilon;
        }
	}
}
