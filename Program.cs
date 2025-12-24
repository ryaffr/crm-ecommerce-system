using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            double[] h1 = { -1, 0, 0, 0 };
            double[] h2 = { -1, 0, 0, 0, 0 };
            double[] o = new double[2];
            double[] error = new double[2];
            double[]s=new double[2];
            double[]s2=new double[4];
            double[] s3 = new double[3];
            double[,] Dw1 = new double[3,3];
            double[,]Dw2=new double[4,4];
            double[,] Dw3=new double[5,2];
            double[,] newW1 = new double[3, 3];
            double[,] newW2 = new double[4, 4];
            double[,] newW3 = new double[5, 2];
            double[,] x ={{-1,-1,-1},{1.5,2.5,1.1},{2.1,1.15,1.7}};
            double[,]d={{1.5,1,1.25},{1.25,1.5,1}};
            double[,] wight1={{0.25,0.2,0.15},{0.22,0.17,0.75},{0.6,0.5,0.35}};
            double[,] wight2={{ 0.3, 0.35, 0.44, 0.67},{ 0.3, 0.32, 0.5, 0.2},{0.12, 0.25, 0.7, 0.65},{0.45,0.8,0.77,0.55}};
            double[,] wight3={{0.34,0.75},{ 0.55, 0.65},{ 0.35,0.67},{0.68,0.22},{0.35,0.15}};
            Console.WriteLine("this is value of the first hidden layer");
            for (int j = 0; j < 3; j++)
            {
                for (i = 0; i < 3; i++)
                {
                    h1[j+1] += (x[i, 0] * wight1[i, j]);
                  // Console.WriteLine(h1[j+1]);
                }
                h1[j+1] = 1 / (1 + (Math.Exp(-h1[j+1])));
                  Console.WriteLine("H1{0}={1}", j+1, h1[j+1]);
            }

              Console.WriteLine("______________________________________________________________________________");
               Console.WriteLine("this is the value of second hidden layer");
                for (i = 0; i < 4; i++)
                {
                    for(int j=0;j<4;j++)
                    {
                        h2[i+1] += h1[j] * wight2[j, i];
                    }
                    
                   h2[i+1] = 1 / (1 + (Math.Exp(-h2[i+1])));
                    Console.WriteLine("H2{0}={1}",i+1,h2[i+1]);
                }
                Console.WriteLine("_______________________________________________________________________________");
                Console.WriteLine("this is the value of output layer");
                for (i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        o[i] += h2[j] * wight3[j, i];
                    }
                    o[i] = 1 / (1 + (Math.Exp(-o[i])));
                   Console.WriteLine("O{0}={1}", i + 1, o[i]);
                }
                    Console.WriteLine("______________________________________________________________________________");
                     Console.WriteLine("this is the value of error");
                     for(i=0;i<2;i++)
                      {
                    error[i] = d[i, 0] - o[i];
                   Console.WriteLine("E{0}={1}", i + 1, error[i]);
                      }
                     Console.WriteLine("_______________________________________________________________________________");
                     Console.WriteLine("this is the back forword");
            for(i=0;i<2;i++)
            {
                s[i]=error[i]*o[i]*(1-o[i]);
                Console.WriteLine("S3{0}={1}", i, s[i]);
            }
            Console.WriteLine("________________________________________________________________________________");
            for (i = 0; i < 4; i++)
            {
                s2[i] = h2[i + 1] * (1 - h2[i+1]) * ((s[0] * wight3[i + 1, 0]) + (s[1] * wight3[i + 1, 1]));
                Console.WriteLine("S2{0}={1}", i, s2[i]);
            }
            for (i = 0; i < 3; i++)
            {
                s3[i] = h1[i + 1] * (1 - h1[i + 1]) * ((s2[0] * wight2[i + 1, 0]) + (s2[1] * wight2[i + 1, 1]) + (s2[2] * wight2[i + 1, 2]) + (s2[3] * wight2[i + 1, 3]));
                Console.WriteLine("S1{0}={1}",i,s3[i]);
            }
            Console.WriteLine("____________________________________________________________________________");
            for (i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Dw1[i, j] = 0.3 * s3[j] * x[i, 0];
                    Console.WriteLine("Dw{0}{1}={2}",i,j,Dw1[i, j]);
                }
            }
            Console.WriteLine("______________________________________________________________________________");
            for (i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Dw2[i,j] = 0.3 * s2[j] * h1[i];
                    Console.WriteLine("DW{0}{1}={2}", i, j, Dw2[i, j]);

                }
            }
            Console.WriteLine("_________________________________________________________________________");
            for (i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Dw3[i, j] = 0.3 *s[j] * h2[i];
                    Console.WriteLine("DW{0}{1}={2}", i, j, Dw3[i, j]);
                }
            }
            Console.WriteLine("______________________________________________________________________");
            for (i = 0; i < 3; i++)
            {
                for(int j=0;j<3;j++)
                {
                    newW1[i, j] = wight1[i, j] + Dw1[i, j];
                    Console.WriteLine("newW1 {0}{1}={2}", i, j, newW1[i, j]);
                }
            }
            Console.WriteLine("_________________________________________________________________");
            for (i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    newW2[i, j] = wight2[i, j] + Dw2[i, j];
                    Console.WriteLine("newW2{0}{1}={2}",i, j,newW2[i,j]);
                }
            }
            Console.WriteLine("_____________________________________________________________");
            for (i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    newW3[i, j] = wight3[i,j]+Dw3[i,j];
                    Console.WriteLine("newW3 {0}{1}={2}", i, j, newW3[i, j]);
                }
            }
             Console.ReadKey();
        
      }
    }
}
