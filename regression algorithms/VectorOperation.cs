using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace regression_algorithms
{
    internal class VectorOperation
    {
        // class to handle perform vector operations on C# arrays.

        public static double DotProduct(double[] firstArray, double[] secondArray)
        {
            // returns a scalar, the result of a dot product.


            double resultArray = 0;

            // check if both arrays have the same length
            if (firstArray.Length != secondArray.Length)
            {
                throw new ArgumentException("Length of Arrays do not much");
            }
            else
            {
                // perform the dot operation
                for (int i = 0; i < firstArray.Length; i++)
                {
                    resultArray += (firstArray[i] * secondArray[i]);
                }
            }
            return resultArray;
        }
    }
}
