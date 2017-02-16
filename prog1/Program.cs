/************************************************************************
 * CS212: Prog1 - Calculate floor(lg(lg(n)))
 * Professor Plantinga
 * Author: Zach Wibbenmeyer
 * Date: September 23, 2016
 ************************************************************************/

using System;

namespace prog1
{
    class Program
    {
        // global variable equal to ln(2)
        public static double ln2 = (double) 0.693147180559945309417232121458176568075500134360255254120;

        // Main code
        static void Main(string[] args)
        {
            Console.WriteLine("Introducing the Amazing floor(lg(lg(n))) Calculator!");
            Console.WriteLine("\nPlease enter a positive value for n: ");
            double n = double.Parse(Console.ReadLine());
            while (n >= 2)
            {
                var log = log2(log2(n));
                Console.WriteLine("lg(lg({0})) = {1}", n, log);
                // Allows the console window to stay open
                Console.ReadLine();
                break;
            }
        }

        /* log2() - Calculates log base 2
         * @param: value, a double
         * @return: the result of log2(value), a double
         */
        static double log2(double value)
        {
            // store the result of log2()
            var result = ln(value)/ln2;
            // format the result to two decimal places
            var formattedResult = String.Format("{0:0.##}", result);
            // parse the formatted result
            var convertedResult = double.Parse(formattedResult);
            // store the two decimal places
            var decimalPlace = (( double.Parse(formattedResult) % 1));

            // if the result is not a whole number, subtract the two decimal places from the result
            if (decimalPlace != 0)
            {
                return convertedResult - decimalPlace;
            }
            // otherwise just return the result
            return convertedResult;
        }

        /* ln() - Computes the natural log without any math libraries
         * @param: value, a double
         * @return: sum, a double
         */
        static double ln(double value)
        {
            // set up doubles for calculating ln(value)
            double oldSum = (double) 0.0;
            double xmlxpl = (value - 1)/(value + 1);
            double xmlxpl2 = xmlxpl*xmlxpl;
            double denominator = (double) 1.0;
            double fraction = xmlxpl;
            double term = fraction;
            double sum = term;

            while (sum != oldSum)
            {
                // main math behind calculating ln(value)
                oldSum = sum;
                denominator += (double)2.0;
                fraction *= xmlxpl2;
                sum += fraction/denominator;
            }
            return (double) 2.0 *sum;
        }
    }
}
