using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sparse_matrix
{
    public static class matrix_initializer
    {
        public static Matrix matrix_init(int row_size, int column_size)
        {

            Matrix matrix = new Matrix(row_size, column_size);
            Random rnd = new Random();
            for (int index = 0; index < matrix.values.Length; index++)
            {
                if (rnd.Next(100) < 20)
                    matrix.values[index] = 0;
                
                else
                    matrix.values[index] = rnd.Next(1000);
            }

            return matrix;
        }

        public static Matrix custom_matrix(int row_size, int column_size)
        {
            Matrix matrix = new Matrix(row_size, column_size);
            for (int index = 0; index < matrix.values.Length; index++)
            {
                matrix.values[index] = Convert.ToInt32(Console.ReadLine());
            }
            return matrix;
        }

    }
}
