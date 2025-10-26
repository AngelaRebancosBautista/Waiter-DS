using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'waiter' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY number
     *  2. INTEGER q
     */

    public static List<int> waiter(List<int> number, int q)
    {
        List<int> result = new List<int>();
        List<int> primes = GeneratePrimes(q);

        Stack<int> currentStack = new Stack<int>(number);
        
        var tempList = new List<int>(currentStack);
        tempList.Reverse();
        currentStack = new Stack<int>(tempList);

        for (int i = 0; i < q; i++)
        {
            Stack<int> A = new Stack<int>();
            Stack<int> B = new Stack<int>();

            int prime = primes[i];

            while (currentStack.Count > 0)
            {
                int plate = currentStack.Pop();
                if (plate % prime == 0)
                    A.Push(plate);
                else
                    B.Push(plate);
            }

            while (A.Count > 0)
                result.Add(A.Pop());

            currentStack = B;
        }

        while (currentStack.Count > 0)
            result.Add(currentStack.Pop());

        return result;
    }
 private static List<int> GeneratePrimes(int count)
    {
        List<int> primes = new List<int>();
        int num = 2;

        while (primes.Count < count)
        {
            if (IsPrime(num))
                primes.Add(num);
            num++;
        }

        return primes;
    }

    private static bool IsPrime(int n)
    {
        if (n < 2)
            return false;
        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }
}
    
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int q = Convert.ToInt32(firstMultipleInput[1]);

        List<int> number = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(numberTemp => Convert.ToInt32(numberTemp)).ToList();

        List<int> result = Result.waiter(number, q);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
