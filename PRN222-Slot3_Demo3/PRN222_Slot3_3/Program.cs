using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    private static double DoComputation(double start)
    {
        double sum = 0;
        for (var value = start; value <= start + 10; value += 0.1)
        {
            sum += value;
        }
        return sum;
    } // end DoComputation

    public static void Main()
    {
        Task<double>[] taskArray = {
            Task<double>.Factory.StartNew(() => DoComputation(1.0)),
            Task<double>.Factory.StartNew(() => DoComputation(100.0)),
            Task<double>.Factory.StartNew(() => DoComputation(1000.0))
        };

        var results = new double[taskArray.Length];
        double sum = 0;
        for (int i = 0; i < taskArray.Length; i++)
        {
            results[i] = taskArray[i].Result;
            Console.Write("{0:N1} {1}", results[i], i == taskArray.Length - 1 ? "= " : "+ ");
            sum += results[i];
        }
        Console.WriteLine("{0:N1}", sum);
    } // end Main
} // end Program