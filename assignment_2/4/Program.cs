using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        public bool isToeplitzMatrix(int[][] matrix)
        {
            int row = matrix.GetLength(1) - 1, column = matrix[0].GetLength(0) - 1;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    //当前元素和右下角比较，如果不一样直接返回false
                    if (matrix[i][j] != matrix[i + 1][j + 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            
        }
    }
}
