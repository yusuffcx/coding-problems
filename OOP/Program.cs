using System;
using System.Numerics;

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

            int total = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (sumRows[i] == sumCols[j] && sumRows[i] != 15)
                    {
                        s[i, j] = s[i, j] + (15 - sumRows[i]);
                        sumRows[i] += total;
                        sumCols[j] += total;
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
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(s[i, j] + " ");
                }
                Console.WriteLine();
            }

            return 0;
        }


        static int[] climbingLeaderboard(int[] leaderboard, int[] player)
        {
            int[] tempLeaderboard = new int[leaderboard.Length +1];


            for(int i = 0; i < leaderboard.Length;i++)
            {
                if(i != 0 && leaderboard[i] == leaderboard[i-1])
                {
                    tempLeaderboard[i] = tempLeaderboard[i-1];
                }
                else if( i == 0 )
                {
                    tempLeaderboard[i] = i+1;
                }
                else
                {
                    tempLeaderboard[i] = tempLeaderboard[i - 1] + 1;
                }
            }
            // temp =  1 2 2 3 4 5 ; 

            int[] ints = new int[player.Length];
            //50 65 77 90 102 player[]
            for (int j = 0; j < player.Length; j++)
            {
                for (int i = 0; i < leaderboard.Length; i++)
                {
                    if (player[j] > leaderboard[i])
                    {
                        
                        if (i != 0)
                        {
                           // tempLeaderboard[]
                            tempLeaderboard[tempLeaderboard.Length - 1] = tempLeaderboard[i];
                            ints[j] = tempLeaderboard[tempLeaderboard.Length - 1];
                            break;
                        }
                        else if(i == 0)
                        {
                            tempLeaderboard[tempLeaderboard.Length - 1] = i+1;
                            ints[j] = tempLeaderboard[tempLeaderboard.Length - 1];
                            break;
                        }
                        else if (tempLeaderboard[j] == 1)
                        {
                            tempLeaderboard[tempLeaderboard.Length - 1] = 1;
                            ints[j] = tempLeaderboard[tempLeaderboard.Length - 1];
                            break;
                        }
                    }

                    else if (player[j] == leaderboard[i])
                    {
                        tempLeaderboard[tempLeaderboard.Length - 1] = tempLeaderboard[i];
                        ints[j] = tempLeaderboard[tempLeaderboard.Length - 1];
                        break;
                    }
                    else if(player[j] < leaderboard[i] &&  i == leaderboard.Length - 1)
                    {
                        tempLeaderboard[tempLeaderboard.Length - 1] = tempLeaderboard[i] +1 ;
                        ints[j] = tempLeaderboard[tempLeaderboard.Length - 1];
                        break;
                    }
                }
            }
            return ints;
        }

        


        static BigInteger extraLongFactorials(BigInteger n)
        {

            if (n == 0 || n == 1) { return 1; }
            else
            {
                return extraLongFactorials(n - 1) * n;
            }
        }

        static int nonDivisibleSubset(int k, int[]s)
        {
            int[] tempMod = new int[k]; // 0, 1, 2, 3, ....k //7
            int ans = 0;
            foreach (int i in tempMod) { tempMod[i] = 0; }
            for(int i = 0;i<s.Length;i++)
            {
                tempMod[s[i] % k]++; 
            }

            for(int i = 0;i<=k/2;i++)
            {
                if(tempMod[i]>0 && i == 0)
                {
                    ans++;
                }
                else if (k%2 == 0 && !(i == k/2))
                {
                    if (tempMod[i] > tempMod[k-i] || tempMod[i] == tempMod[k - i])
                    {
                        ans = ans + tempMod[i];
                    }
                    else if (tempMod[k-i] > tempMod[i] || tempMod[i] == tempMod[k - i])
                    {
                        ans += tempMod[k - i];
                    }
                }
                else if(k%2 == 0 && (i == k/2))
                {
                    ans++;
                }
            }

            return ans;
        }
        //            Console.WriteLine(cupSwapping(["CA", "BC", "CA"]));

        static char cupSwapping(string [] swapping)
        {
            char ball = 'B';
            for(int i = 0; i<swapping.Length;i++)
            {
                if (swapping[i][0] == ball)
                {
                    ball = swapping[i][1];
                }

                else if(swapping[i][1] == ball)
                {
                    ball = swapping[i][0];
                }
            }

            return ball;
        }

        static string encryption(string s)
        {
            var col = Math.Ceiling(Math.Sqrt(s.Length));
            var row = Math.Round(Math.Sqrt(s.Length));

            string[] temp = new string[(int)row];
            //string temp2 = "";

            for (int i = 0; i< row;i++)
            {
                temp[i] = s.Substring(i * (int)col,(int)col );
                
            }
            
            return "temp2";
           // return $"col {col} , row {row}";
        }

        static void countLetter(string s)
        {
            // ddmmmk , 2d3m1k 5
            string rtrn = ""; 
            int j = 0;
            int count = 0;
            char temp = ' ';

            for (int i = 1;i< s.Length;i++)
            {
                if(j ==0 && i ==1 && s[i] != s[j])
                {
                    temp = s[j];
                    count++;
                    rtrn = rtrn + count.ToString() + temp;
                    count = 0;
                    j++;
                }

                else if (i == s.Length-1)
                {
                    if (s[i] != s[j])
                    {
                        j++;
;                        rtrn = rtrn + count.ToString() + temp;
                        count = 0;
                    }

                    if (s[j] == s[i])
                    {
                        count++;
                    }
                    else
                    {
                        count = 1;
                    }
                    temp = s[i];
                    rtrn = rtrn + count.ToString() + temp;
                }
                else if (s[i] == s[j])
                {
                    temp = s[i]; 
                    count++;
                    if(s[i] == s[i-1] && s[i] == temp && count < 3)
                    {
                        count++;
                    }
                    j++;
                }

                else if(s[i] != s[j] && i!=1)
                {
                    if (s[j] != s[j - 1] && s[j] != s[j + 1])
                    {
                        count++;
                        temp = s[j];
                    }
                    j++;
                    rtrn = rtrn + count.ToString() + temp;
                    count = 0;
                }

        
            }
            Console.WriteLine(rtrn);
        }



        static void Main(string[] args)
        {
            /* // for Magic square problem 
            int[,] S = { {2,7,6 }, {9,5,1 }, {4,3,8 } };
            formingMagicSquare(S); 
            int[,] S = { { 5, 3, 4 }, { 1, 5, 8 }, { 6, 4, 2 } };
            formingMagicSquare(S);
            int[,] S2 = { { 4, 8, 2 }, { 4, 5, 7 }, { 6, 1, 6 } };
            */


            //int lengthLeader = int.Parse(Console.ReadLine());
            //int[] leaderBoard = new int[lengthLeader];
            //Console.WriteLine(lengthLeader);

            //for(int i = 0; i < lengthLeader; i++)
            //{ leaderBoard[i] = int.Parse(Console.ReadLine()); }

            //int playerLength = int.Parse(Console.ReadLine());
            //int[] playerTable = new int[playerLength];

            //for (int i = 0; i < playerTable.Length; i++)
            //{ playerTable[i] = int.Parse(Console.ReadLine()); }

            //for (int i = 0; i < playerTable.Length; i++)
            //{ Console.WriteLine(playerTable[i]); }

            //for(int i = 0; i < climbingLeaderboard(leaderBoard, playerTable).Length; i++)
            //{
            //    Console.WriteLine(climbingLeaderboard(leaderBoard, playerTable)[i]);
            //}
            //Console.WriteLine("Sayi giriniz:");
            //BigInteger n = BigInteger.Parse(Console.ReadLine());
            //Console.WriteLine(extraLongFactorials(n));

            /*
            string input = Console.ReadLine();
            string[] intlist = input.Split(' ');
            int[] s = new int[int.Parse(intlist[0])];
            int k = int.Parse(intlist[1]);

            input = Console.ReadLine();
            intlist = input.Split(' ');

            foreach (var b in intlist.Select((value, i) => (value, i)))
            {
                s[b.i] = int.Parse(b.value);
            }
            Console.WriteLine(nonDivisibleSubset(k, s));*/

            //            Console.WriteLine(cupSwapping(["AB", "CA"]));
            //          Console.WriteLine(cupSwapping(["AC", "CA", "CA", "AC"]));
            //        Console.WriteLine(cupSwapping(["BA", "AC", "CA", "BC"]));

            //Console.WriteLine(encryption("haveaniceday"));
            countLetter("dlmmmmmkkko");
        }

    }
}


