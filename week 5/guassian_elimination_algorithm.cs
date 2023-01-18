using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Guassian_Elimination
{
    public static class Guassian_Elimination_Algorithm
    {
        public static Matrix guassian_elimination_r(Matrix matrix, int current_row, int current_column)
        { 
            if (at_end(matrix.number_of_rows, current_row))
                return matrix;

            if (matrix.values[current_row][current_column] == 0)
            {
                int row_index_to_swap = find_non_empty_element(matrix, current_row + 1, current_column);
                if (row_index_to_swap == -1)
                    return guassian_elimination_r(matrix, current_row + 1, current_column);
                else
                    // optimise with pointers here??
                    matrix = Guassian_Operators.swap_rows(matrix, row_index_to_swap, current_row);
            }
            matrix.values[current_row] = make_coefficient_pivot(matrix.values[current_row], current_column);
            
            if (current_row != 0)
                matrix = eliminate_all_below(matrix, current_row, current_row - 1, current_column);
            if (current_row != matrix.length_of_row - 1)
                matrix = eliminate_all_above(matrix, current_row, current_row + 1, current_column);
            return guassian_elimination_r(matrix, current_row + 1, current_column + 1);
        }
        static bool at_end(int size, int current_row)
        {
            if (current_row == size)
                return true;
            return false;
        }
        public static double[] make_coefficient_pivot(double[] row, int current_column)
        {
            double factor = 1 / row[current_column];
            return mathematical_functions.zip_scalar_array(row, factor);
        }
        public static double[] eliminate_coefficient_from_row(double[] base_row, double[] row_to_eliminate, int coefficient_index)
        {
            double factor = row_to_eliminate[coefficient_index] / base_row[coefficient_index];
            base_row = mathematical_functions.zip_scalar_array(base_row, factor);
            row_to_eliminate = mathematical_functions.zip_subtract_arrays(row_to_eliminate, base_row);
            base_row = mathematical_functions.zip_scalar_array(base_row, 1/factor);
            return row_to_eliminate;
        }
        public static Matrix eliminate_all_above(Matrix matrix, int base_row, int row_to_eliminate_index ,int current_column)
        {
            if (row_to_eliminate_index >= matrix.number_of_rows)
                return matrix;
            if (matrix.values[row_to_eliminate_index][current_column] != 0)
                eliminate_coefficient_from_row(matrix.values[base_row], matrix.values[row_to_eliminate_index], current_column);
            return eliminate_all_above(matrix, base_row, row_to_eliminate_index + 1, current_column);
        }
        public static Matrix eliminate_all_below(Matrix matrix, int base_row, int row_to_eliminate_index, int current_column)
        {
            if (row_to_eliminate_index < 0)
                return matrix;
            if (matrix.values[row_to_eliminate_index][current_column] != 0)
                eliminate_coefficient_from_row(matrix.values[base_row], matrix.values[row_to_eliminate_index], current_column);
            return eliminate_all_below(matrix, base_row, row_to_eliminate_index - 1, current_column);
        }
        public static int find_non_empty_element(Matrix matrix, int current_row, int current_column)
        {
            if (current_row > matrix.number_of_rows-1)
                return -1;
            if (matrix.values[current_row][current_column] != 0.0)
                return current_row;
            return find_non_empty_element(matrix, current_row+1, current_column);
        }
    }
}
