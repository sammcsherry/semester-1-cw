using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guassian_Elimination
{
    class inverse_of_matrix
    {
        public void get_inverse_of_matrix()
        {
            Matrix matrix = new Matrix(3,3);
            matrix.fill_matrix_random();
            Guassian_Elimination_Algorithm.guassian_elimination_r(matrix,0,0);
        }
    }
}
