using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guassian_Elimination
{
	public class Matrix
	{
		public double[][] values;
		public int number_of_rows;
		public int length_of_row;
		public Matrix(int number_of_rows, int length_of_row)
		{
			this.number_of_rows = number_of_rows;
			this.length_of_row = length_of_row;
			values = new double[number_of_rows][];
			matrix_init();
		}

		public void matrix_init()
		{
			for (int i = 0; i < number_of_rows; i++)
			{
				values[i] = new double[length_of_row+1];
			}
		}

		public void loop_through_matrix(Action<int,int> action)
        {
			for (int row = 0; row < number_of_rows; row++)
			{
				for (int column = 0; column < length_of_row +1; column++)
				{
					action(row, column);
				}
			}
		}
		public void print_matrix()
        {
			loop_through_matrix((row, column) => Console.WriteLine(values[row][column]));
        }

		public void fill_matrix_random()
        {
			Random rand = new Random();
			loop_through_matrix((row, column) => values[row][column] = rand.Next(1,1000000000));
		}

		public void fill_custom_matrix()
		{
			values[0] = new double[] {2,0,4,1,0,0};
			values[1] = new double[] {1,2,3,0,1,0};
			values[2] = new double[] {0,0,2,0,0,1};
		}

		public class Identity_Matrix : Matrix
		{
			public Identity_Matrix(int number_of_rows, int length_of_row)
				: base(number_of_rows, length_of_row)
            {

				identity_matrix_init();
            }

			public void fill_with_zeros()
            {
				loop_through_matrix((row, column) => values[row][column] = 0);
			}

			public void identity_matrix_init()
            {
                for (int i = 0; i < values.Length; i++)
                {
					values[i][i] = 1;
                }
            }
		}
	}
}
