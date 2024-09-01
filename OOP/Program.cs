using System;

namespace OOP
{
    internal class Program
    {

        static int formingMagicSquare(int[,] s)
        {

            Console.WriteLine("Ilk durum:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(s[i, j] + " ");
                }
                Console.WriteLine();
            }


            int[] sumRows = new int[3];
            int[] sumCols = new int[3];
            int[] tempSumsRows = { 0, 0, 0 };
            int[] tempSumsCols = { 0, 0, 0 };


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tempSumsRows[i] = tempSumsRows[i] + s[i, j];
                    tempSumsCols[i] = tempSumsCols[i] + s[j, i];

                }
                sumRows[i] = tempSumsRows[i];
                sumCols[i] = tempSumsCols[i];
                //Console.WriteLine(i + 1 + ". satırın toplamı: " + sumRows[i]);
                //Console.WriteLine(i + 1 + ". sutunun toplamı: " + sumCols[i]);
            }
            int cost = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (sumRows[i] == sumCols[j] && sumRows[i] != 15)
                    {
                        cost = 15 - sumRows[i];
                        s[i, j] = s[i, j] + (15 - sumRows[i]);
                        sumRows[i] += cost;
                        sumCols[j] += cost;
                    }

                    else if (Math.Abs(sumRows[i] - 15) == Math.Abs(sumCols[j] - 15))
                    {
                        if (sumRows[i] - 15 > 0 && sumCols[j] - 15 < 0)
                        {
                            for (int k = i + 1; k < 3; k++)
                            {
                                if (sumRows[k] < 15)
                                {
                                    s[i, j] = s[i, j] - Math.Abs(sumRows[i] - 15);
                                    s[k, j] = s[k, j] + Math.Abs(sumRows[i] - 15);
                                }
                            }
                        }

                        else if (sumCols[j] - 15 > 0 && sumRows[i] - 15 < 0)
                        {
                            for (int k = j + 1; k < 3; k++)
                            {
                                if (sumCols[k] < 15)
                                {
                                    s[i, j] = s[i, j] - Math.Abs(sumRows[i] - 15);
                                    s[k, j] = s[k, j] + Math.Abs(sumRows[i] - 15);
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Son durum:");
            for(int i = 0;i<3;i++)
            {
                for(int j = 0;j<3;j++)
                {
                    Console.Write(s[i,j] + " ");
                }
                Console.WriteLine();
            }

            return 0;
        }



        static void Main(string[] args)
        {
            int[,] S = { {2,7,6 }, {9,5,1 }, {4,3,8 } };
            formingMagicSquare(S); 

            /*
            int[,] S = { { 5, 3, 4 }, { 1, 5, 8 }, { 6, 4, 2 } };
            formingMagicSquare(S);*/

            /*
            int[,] S2 = { { 4, 8, 2 }, { 4, 5, 7 }, { 6, 1, 6 } };
            formingMagicSquare(S2);*/

        }
    }
}
