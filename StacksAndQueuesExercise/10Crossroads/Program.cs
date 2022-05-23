using System;
using System.Collections.Generic;

namespace _10Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> traficQueue = new Queue<string>();
            string command = string.Empty;
            bool isSafe = true;
            string currenCar = string.Empty;
            string hitLetter = string.Empty;
            int totalCarsPassed = 0;
            while ((command = Console.ReadLine()) != "END")
            {
                bool isUseFreeWindowDuration = false;
                if (command != "green")
                {
                    traficQueue.Enqueue(command);
                }
                else
                {
                    int greenCounter = greenLightDuration;
                    int traficCount = traficQueue.Count;
                    for (int i = 0; i < traficCount; i++)
                    {
                        if (isUseFreeWindowDuration)
                        {
                            break;
                        }
                        currenCar = traficQueue.Dequeue();
                        int currntCarLenght = currenCar.Length;
                        if (currntCarLenght < greenCounter)
                        {
                            greenCounter -= currntCarLenght;
                            totalCarsPassed++;
                            continue;
                        }
                        else if (currntCarLenght <= freeWindowDuration + greenCounter)
                        {
                            totalCarsPassed++;
                            isUseFreeWindowDuration = true;
                            continue;
                        }
                        else
                        {
                            hitLetter = currenCar.Substring(greenCounter + freeWindowDuration, 1);
                            isSafe = false;
                            break;
                        }
                    }
                    if (!isSafe)
                    {
                        break;
                    }
                }
            }
            if (isSafe)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
            }
            else
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{currenCar} was hit at {hitLetter}.");
            }
        }
    }
}
