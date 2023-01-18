using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fft_week4
{
    class Program
    {
        static void Main(string[] args)
        {
            void four1(double[] data, int nn, int isign)
            {

                int n, mmax, m, j, istep = 0, i;
                double wtemp, wr, wpr = 0, wpi, wi, theta = 0;
                double tempr, tempi;
                n = nn << 1;
                j = 1;
                for (i = 1; i < n; i += 2)
                {
                    if (j > i)
                    {
                        data = SWAP(data, j, i);
                        data = SWAP(data, j + 1, i + 1);
                    }
                    m = nn;
                    while (m >= 2 && j > m)
                    {
                        j -= m;
                        m >>= 1;
                    }
                    j += m;
                }

                mmax = 2;
                while (n > mmax)
                {
                    istep = mmax << 1; // halves matrix size?
                    theta = isign * (6.28318530717959 / mmax); // 2 pi/max
                    wtemp = Math.Sin(0.5 * theta);
                    wpr = -2.0 * wtemp * wtemp;
                    wpi = Math.Sin(theta);
                    wr = 1.0; //real?
                    wi = 0.0; // imaginary??
                    for (m = 1; m < mmax; m += 2)
                    {
                        for (i = m; i <= n; i += istep)
                        {
                            j = i + mmax;

                            tempr = wr * data[j] - wi * data[j + 1];
                            tempi = wr * data[j + 1] + wi * data[j];
                            data[j] = data[i] - tempr;
                            data[j + 1] = data[i + 1] - tempi;
                            data[i] += tempr;
                            data[i + 1] += tempi;
                        }
                        wr = (wtemp = wr) * wpr - wi * wpi + wr;
                        wi = wi * wpr + wtemp * wpi + wi;
                    }
                    mmax = istep;
                }
            }

                double[] SWAP(double[] data, int index_1, int index_2)
                {
                    double temp = data[index_1];
                    data[index_1] = data[index_2];
                    data[index_2] = temp;
                    return data;
                }
            

        }
    }
}
