using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sparse_matrix
{
    public class Matrix
    {
        public int row_size;
        public int column_size;
        public double[] values;

        public Matrix(int row_size, int column_size)
        {
            this.row_size = row_size;
            this.column_size = column_size;
            this.values = new double[row_size * column_size];
        }

        public Sparse_Matrix convert_to_sparse_matrix()
        { 
            int row = 0;
            int column = 0;
            int sparse_matrix_index = 0;
            Sparse_Matrix sparse_matrix = new Sparse_Matrix(row_size, column_size);
            for (int index = 0; index < values.Length; index++)
            {
                if (values[index] != 0)
                {
                    sparse_matrix.rows.Add(column);
                    sparse_matrix.columns.Add(row);
                    sparse_matrix.values.Add(values[index]);
                    sparse_matrix_index++;
                }
                column++;
                if(column >= column_size)
                {
                    row++;
                    column = 0;
                }
            }
            return sparse_matrix;
        }

        public Matrix_Compressed_Sparse_Row convert_to_compressed_sparse_row_matrix()
        {
            int row = 0;
            int column = 0;
            int sparse_matrix_index = 0;
            bool first_in_row = true;
            Matrix_Compressed_Sparse_Row sparse_matrix_csr = new Matrix_Compressed_Sparse_Row(row_size, column_size);

            for (int index = 0; index < values.Length; index++)
            {
                if (values[index] != 0)
                {
                    if(first_in_row)
                    {
                        sparse_matrix_csr.rows.Add(sparse_matrix_index);
                        first_in_row = false;
                    }

                    sparse_matrix_csr.columns.Add(column);
                    sparse_matrix_csr.values.Add(values[index]);
                    sparse_matrix_index++;
                }
                column++;
                if (column >= column_size)
                {
                    if(first_in_row)
                        sparse_matrix_csr.rows.Add(-1);

                    row++;
                    first_in_row = true;
                    column = 0;
                }
            }
            return sparse_matrix_csr;
        }
    }
}
