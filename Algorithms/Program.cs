using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //---------------This code is for creating a triangle with staric---------------

            //int n=0;
            //n = Convert.ToInt32( Console.ReadLine());
            //for(int i=1;i<=n;i++)
            //{
            //    Console.WriteLine();
            //    for(int j=i;j<n;j++)
            //    {
                 
            //        Console.Write(" ");
                        
                    
            //    }
            //    for (int l = 0; l <= 2 * (i - 1); l++)
            //    {
            //        Console.Write("*");
            //    }

            //}

            // ==================This is a naive approach to rotten oranges problem======================
            //init an array containing 3 col and 5 rows you can change the value accordingly. i hard coded it so that it look pretty simple.
            int[,] rot=new int[3,5] {{2,1,0,2,1},{0,0,1,2,1},{1,0,0,2,1}};
            // this array is to check whether index is visited or not
            int[,] visited=new int[3,5] {{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0}};
            // this array is to maintain check and balance if any array contains an unrotted orange left after all checks.
            int[,] count = new int[3, 5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
            // this varaible is to count number of steps taken to rot all oranges
            int coun = 0;
            // this variable is the condition of while loop is it gets false while loop stops working and program displays number of steps taken. 
            bool con = true;
            
            while (con==true)//while loop starts
            {
                int n = 0;
                for (int i = 0; i <= 1; i++)//1st for loop starts
                {
                    for (int j = 0; j <= 3; j++)//2st for loop starts
                    {
                        if (rot[i, j] == 2)
                        {
                            if (visited[i, j] == 0)
                            {
                                if (rot[i, j + 1] == 1)
                                {
                                    rot[i, j + 1] = 2;
                                    visited[i, j + 1] = 1;
                                }

                                if (rot[i + 1, j] == 1)
                                {
                                    rot[i + 1, j] = 2;
                                    visited[i + 1, j] = 1;
                                }
                                if(rot[i+1,j+1]==1)
                                {
                                    rot[i + 1, j + 1] = 2;
                                    visited[i + 1, j + 1] = 1;
                                }
                                if (i > 0 && rot[i - 1, j] == 1)
                                {
                                    rot[i - 1, j] = 2;
                                    visited[i - 1, j] = 1;
                                }
                                if(j>1&&rot[i,j-1]==1)
                                {
                                    rot[i, j - 1] = 2;
                                    visited[i, j - 1] = 1;
                                }
                                visited[i, j] = 1;

                            }

                        }
                    }//2nd for loop ends
                }// 1st for loop ends
                Console.WriteLine();
                for (int i = 0; i <= 2; i++)//2nd nested for loop starts to print array accordingly in every step
                {
                    
                    for (int j = 0; j <= 4; j++)//
                    {
                        Console.Write(rot[i, j]);
                    }
                    Console.WriteLine();
                }//2nd nested for loop ends
                coun++;
                for(int i=0;i<=2;i++)//3rd nested for loop starts
                {
                    for(int j=0;j<=4;j++)
                    {
                        visited[i, j] = 0;
                        if(rot[i, j] == 1)
                        {
                            con = true;
                            n++;
                            count[i, j] += 1;
                            if (count[i, j] > 1)
                            {
                                con = false;
                                Console.WriteLine("This 1 on index [" + i + "]" + "[" + j + "] is never rotten.");
                            }
                            
                        }
                        if(n==0)
                        {
                            con = false;
                        }
                      
                    }
                }//3rd nested for loop ends
            }//while loop ends
            

            Console.WriteLine(coun);
                Console.ReadLine();
        }
    }
}
