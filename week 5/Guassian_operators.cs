using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guassian_Elimination
{
    public static class Guassian_Operators
    {
  
        public static double[] multiply_row(double[] row, double scalar)
        {
            return mathematical_functions.zip_scalar_array(row, scalar);
        }

        public static double[] subtract_arrays(double[] row_1, double[] row_2)
        {
            return mathematical_functions.zip_subtract_arrays(row_1, row_2);
        }

        public static Matrix swap_rows(Matrix matrix, int row_1, int row_2)
        {
            double[] temp = matrix.values[row_1];
            matrix.values[row_1] = matrix.values[row_2];
            matrix.values[row_2] = temp;
            return matrix;
        }
    }
}
