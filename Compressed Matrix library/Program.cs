using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace sparse_matrix
{
    public class Program
    {
        static void Main(string[] args)
        {
            int Size = 3;

            init(Size);

            void init(int size)
            {
                int row_num = size;
                int col_num = size;

                Matrix matrix_A = matrix_initializer.matrix_init(row_num, col_num);
                Matrix matrix_B = matrix_initializer.matrix_init(row_num, col_num);

                //Matrix matrix_A_cust = matrix_initializer.custom_matrix(row_num, col_num);
                //Matrix matrix_B_cust = matrix_initializer.custom_matrix(row_num, col_num);


                Matrix_Compressed_Sparse_Row matrix_A_sparse_csr = matrix_A.convert_to_compressed_sparse_row_matrix();
                Matrix_Compressed_Sparse_Row matrix_B_sparse_csr = matrix_B.convert_to_compressed_sparse_row_matrix();


                Sparse_Matrix matrix_A_sparse = matrix_A.convert_to_sparse_matrix();
                Sparse_Matrix matrix_B_sparse = matrix_B.convert_to_sparse_matrix();

                Matrix_Compressed_Sparse_Row result = new Matrix_Compressed_Sparse_Row(size, size);
                Sparse_Matrix result_2 = new Sparse_Matrix(size, size);

                Console.WriteLine("csr");
                Console.WriteLine();
                matrix_A_sparse_csr.multiply_sparse_matrix_nr(matrix_B_sparse_csr, result).print();
                Console.WriteLine();
                Console.WriteLine("sparse");
                Console.WriteLine();
                matrix_A_sparse.multiply_sparse_matrix_nr(matrix_B_sparse, result_2).print_sparse_matrix();

                Console.ReadLine();
            }
        }
    }
}
