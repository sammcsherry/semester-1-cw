using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sparse_matrix
{

    public class Sparse_Matrix
    { 
        public List<int> rows;
        public List<int> columns;
        public List<double> values;
        public bool is_sparse;

        public Sparse_Matrix(int row_size, int column_size)
        {
            rows = new List<int>();
            columns = new List<int>();
            values = new List<double>();

        }
        public void print_sparse_matrix()
        {
            for (int i = 0; i < rows.Count; i++)
            {
                Console.WriteLine(rows[i] + " " + columns[i] + " " + values[i] + " ");
            }
        }
        public void get_transpose()
        {
            List<int> temp = rows;
            rows = columns;
            columns = temp;
        }
        public Sparse_Matrix multiply_sparse_matrix_nr(Sparse_Matrix other_matrix,
                                             Sparse_Matrix result_matrix)
        {
            for (int A_index = 0; A_index < other_matrix.columns.Count; A_index++)
            {
                for (int B_index = 0; B_index < this.rows.Count; B_index++)
                {
                    if (other_matrix.columns[A_index] == this.rows[B_index])
                    {
                        //checks if row, column position already exists in the result matrix
                        if (is_full(result_matrix, other_matrix.rows[A_index], this.columns[B_index], 0) == -1)
                        {
                            // if pos doesnt exist
                            result_matrix.values.Add(other_matrix.values[A_index] * this.values[B_index]);
                            result_matrix.rows.Add(other_matrix.rows[A_index]);
                            result_matrix.columns.Add(this.columns[B_index]);
                        }
                        else
                        {
                            int position_to_add_to = is_full(result_matrix, other_matrix.rows[A_index], this.columns[B_index], 0);
                            result_matrix.values[position_to_add_to] += other_matrix.values[A_index] * this.values[B_index];
                        }
                    }
                }
               
            }
            result_matrix.get_transpose();

            return result_matrix; 
        }

        //checks if position already exists
        //better search algorithm?
        public int is_full(Sparse_Matrix result, int row, int column, int index)
        {
            if (result.values.Count == index)
                return -1;

            if (result.rows[index] == row && result.columns[index] == column)
                return index;
            return is_full(result, row, column, index + 1);
        }
    }
}
