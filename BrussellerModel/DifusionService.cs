using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BrussellerModel
{
    public class DifusionService
    {
        private static decimal tStep = StepData.tStep;
        private static decimal xStep = StepData.xStep;
        private int N { get; set; }
        private int M { get; set; }

        public List<List<decimal>> T { get; set; }
        public List<List<decimal>> P { get; set; }

        private List<decimal> initialConditionsU { get; set; }
        private List<decimal> initialConditionsV { get; set; }

        public DifusionService(decimal Xmax,decimal Tmax)
        {
            N = (int) (Tmax / tStep);
            M = (int) (Xmax / xStep);
            Initialize();
            InitArray(initialConditionsU, M, (x) => 0.5M);
            InitArray(initialConditionsV, M, (x) => 1M + 5M * x);
            InitMatrix(P, N, M, x => 0.0M);
            InitMatrix(T, N, M, x => 0.0M);
            InitMatrixByInitialConditions(T, initialConditionsU);
            InitMatrixByInitialConditions(P, initialConditionsV);

            CalculateResult();
        }

        private void Initialize()
        {
            initialConditionsU = new List<decimal>();
            initialConditionsV = new List<decimal>();
            P = new List<List<decimal>>();
            T = new List<List<decimal>>();
        }

        private void InitMatrixByInitialConditions(List<List<decimal>> matrix, List<decimal> array)
        {
            int i = 0;
            for (int j = 0; j <= M; j++)
            {
                matrix[i][j] = array[j];
            }
        }

        private void InitArray(List<decimal> array,int n, Func<decimal,decimal> func)
        {
            for (int i = 0; i <= n; i++)
            {
                array.Add(func(i*xStep));
            }
        }

        private void InitMatrix(List<List<decimal>> matrix, int n,int m, Func<decimal, decimal> func)
        {
            for (int i = 0; i <= n; i++)
            {
                var array = new List<decimal>();
                for (int j = 0; j <= m; j++)
                {
                    array.Add(func(i * xStep));
                }
                matrix.Add(array);
            }
        }

        public void CalculateResult()
        {
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= M; j++)
                {
                    if (j == M)
                    {
                        T[i][j] = T[i][j-1];
                        P[i][j] = P[i][j-1];
                    }
                    else
                    {
                        T[i][j] = Eq1(i, j);
                        P[i][j] = Eq2(i, j);
                    }
                }

                T[i][0] = T[i][1];
                P[i][0] = P[i][1];
            }
        }

        private decimal A = 1;
        private decimal B = 3.4M;
        private static decimal D1 = 0.002M;
        private static decimal D2 = 0.002M;

        private decimal S1 = (D1 * tStep) / (xStep * xStep);
        private decimal S2 = (D2 * tStep) / (xStep * xStep);


        private decimal Eq1( int i, int j)
        {
            i -= i;
            var f1 = A;
            var f2 = T[i][j] * T[i][j] * P[i][j];
            var f3 = -(B + 1M) * T[i][j];
            var f = (f1 + f2 + f3) * tStep;
            var add1 = (T[i][j - 1] + T[i][j + 1]) * S1;
            var add2 = (1M - 2M * S1) * T[i][j];
            return (add1 + add2 + f);
        }

        private decimal Eq2(int i, int j)
        {
            i -= i;
            var f1 = B * T[i][j];
            var f2 = -T[i][j] * T[i][j] * P[i][j];
            var f = (f1 + f2) * tStep;
            var add1 = (P[i][j - 1] + P[i][j + 1]) * S2;
            var add2 = (1M - 2M * S2) * P[i][j];
            return (add1 + add2 + f);
        }
    }
}