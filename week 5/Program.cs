using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Threading;



namespace Guassian_Elimination
{
    class Program
    {
        static void Main(string[] args)
        {

            void init(int matrix_size)
            {
                Matrix matrix = new Matrix(matrix_size, matrix_size);
                matrix.fill_matrix_random();
                //matrix.fill_custom_matrix();
                //matrix.print_matrix();
                Guassian_Elimination_Algorithm.guassian_elimination_r(matrix, 0, 0);
            }
          
            init(matrix_size);
            
            Console.ReadLine();
        }
    }
}
