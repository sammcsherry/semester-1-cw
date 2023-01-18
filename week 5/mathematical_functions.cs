using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guassian_Elimination
{
    public static class mathematical_functions
    {
        public static double[] zip_scalar_array(double[] array, double Scalar)
        {
            for(int i = 0; i< array.Length; i++)
            {
                array[i] = array[i] * Scalar;
            }
            return array;
        }

        public static double[] zip_subtract_arrays(double[] array_1, double[] array_2)
        {
            for (int i = 0; i < array_1.Length; i++)
            {
                array_1[i] = array_1[i] - array_2[i];
            }
            return array_1;
        }
    }
}
