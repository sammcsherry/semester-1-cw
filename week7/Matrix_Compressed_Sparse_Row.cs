using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sparse_matrix
{
    public class Matrix_Compressed_Sparse_Row
    {
        public int row_size;
        public int column_size;
        public List<int> rows;
        public List<int> columns;
        public List<double> values;
        public Matrix_Compressed_Sparse_Row(int row_size, int column_size)
        {
            this.row_size = row_size;
            this.column_size = column_size;
            this.rows = new List<int>();
            this.columns = new List<int>();
            this.values = new List<double>();
        }
        public void print_array<T>(List<T> array)
        {
            foreach (T element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
        public void print()
        {
            Console.Write("col: ");
            print_array(columns);
            Console.Write("val: ");
            print_array(values);
            Console.Write("row: ");
            print_array(rows);
        }
        public Matrix_Compressed_Sparse_Row multiply_sparse_matrix_nr(Matrix_Compressed_Sparse_Row other_matrix,
                                            Matrix_Compressed_Sparse_Row result_matrix)
        {
            int B_current_row = 0;
            int A_current_row = 0;
            bool first_in_row = true;

            for (int A_value_index = 0; A_value_index < other_matrix.values.Count; A_value_index++)
            {
                A_current_row = update_row(A_current_row, A_value_index);
                first_in_row = true;

                for (int B_value_index = 0; B_value_index < this.values.Count; B_value_index++)
                {
                    B_current_row = update_row(B_current_row, B_value_index);

                    if (other_matrix.columns[A_value_index] == B_current_row)
                    {
                        //checks if row, column position already exists in the result matrix
                        if (result_matrix.is_full(A_current_row, this.columns[B_value_index]) == -1)
                        {
                            // if pos doesnt exist
                            result_matrix.values.Add(other_matrix.values[A_value_index] * this.values[B_value_index]);
                            result_matrix.columns.Add(this.columns[B_value_index]);
                            
                            if(first_in_row)
                            {
                                result_matrix.rows.Add(result_matrix.values.Count-1);
                                first_in_row = false;
                            }
                        }
                        else
                        {
                            int position_to_add_to = result_matrix.is_full(A_current_row, this.columns[B_value_index]);
                            result_matrix.values[position_to_add_to] += other_matrix.values[A_value_index] * this.values[B_value_index];
                        }
                      
                    }
                }
                B_current_row = 0;
            }
            return result_matrix;
        }

        public void add_new_value()
        {

        }

        public int update_row(int current_row, int value_index)
        {
            do
            {
                if (current_row < rows.Count - 1 && value_index >= rows[current_row+1])
                {
                    current_row++;
                }
            } while(rows[current_row] == -1);
            return current_row;
        }
     
        //checks if position already exists
        //better search algorithm?
        public int is_full(int row, int column)
        {
            int current_row = 0;
            for (int i = 0; i < values.Count; i++)
            {
                current_row = update_row(current_row, i);
                if (current_row == row && columns[i] == column)
                {
                    return i;
                }
            }
            return -1;
            
        }

        public void get_transpose()
        {
            List<int> temp = rows;
            rows = columns;
            columns = temp;
        }
    }

}
