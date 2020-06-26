using System;
using System.Collections.Generic;

namespace ParkingKattis
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parking
            // https://open.kattis.com/problems/parking2
            // (ideal distance = max place - min place)

            int myTestCount = EnterNumberOfTestCases();

            var myDifferences = DifferencesCalculations(myTestCount);

            PrintList(myDifferences);
        }
        private static void PrintList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        private static List<int> DifferencesCalculations(int yourTestCount)
        {
            int myStoresCount;
            int[] myStores;
            var results = new List<int>();
            for (int i = 0; i < yourTestCount; i++)
            {
                myStoresCount = EnterNumberOfStores();
                myStores = EnterStoresOneLine(myStoresCount);
                results.Add(MaxMinDifference(myStores));
            }
            return results;
        }

        private static int MaxMinDifference(int[] array)
        {
            int minVal = int.MaxValue;
            int maxVal = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (minVal > array[i])
                    minVal = array[i]; 
                if (maxVal < array[i])
                    maxVal = array[i];
            }
            return 2 * (maxVal - minVal);
        }

        private static int[] EnterStoresOneLine(int storesCount)
        {
            string[] arr = new string[storesCount];
            int[] res = new int[storesCount];
            try
            {
                arr = Console.ReadLine().Split(' ', storesCount);
                for (int i = 0; i < arr.Length; i++)
                {
                    res[i] = int.Parse(arr[i]);
                    if (res[i] < 0 || res[i] > 99)
                        throw new ArgumentException();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                EnterStoresOneLine(storesCount);
            }
            return res;
        }
        private static int EnterNumberOfStores()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 20)
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterNumberOfTestCases();
            }
            return a;
        }
        private static int EnterNumberOfTestCases()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 100)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterNumberOfTestCases();
            }
            return a;
        }
    }
}
