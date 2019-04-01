using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrussellerModel
{
    class FileService
    {
        private static decimal tStep = StepData.tStep;
        private static decimal xStep = StepData.xStep;
        public static void WriteResult(string fileNme,List<List<decimal>> matrix, decimal Xmax, decimal Tmax)
        {
            var N = (int)(Tmax / tStep);
            var M = (int)(Xmax / xStep);

            var points = new List<string>();
            for (int i = 0; i <= N; i++)
            {
                string s = "";
                for (int j = 0; j <= M; j++)
                {
                    s += $"{matrix[i][j]} ";
                }
                points.Add($"{s}\r\n");
            }

            System.IO.File.WriteAllLines(fileNme, points);
        }
    }
}
