using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebra_de_boole
{
    class Program
    {

        static void variables(int c)
        {
            switch (c)
            {
                case 2:
                    Console.WriteLine("AB\t-A-B\n");
                    Console.SetCursorPosition(55, 1);
                    Console.WriteLine("instrucciones:");
                    Console.SetCursorPosition(57, 3);
                    Console.WriteLine("A=0 | B=1 ");
                    break;
                case 3:
                    Console.WriteLine("ABC\t-A-B-C\n ");
                    Console.SetCursorPosition(55, 1);
                    Console.WriteLine("instrucciones:");
                    Console.SetCursorPosition(56, 3);
                    Console.WriteLine("A=0 | B=1 | C=2");
                    break;
                case 4:
                    Console.WriteLine("ABCD\n");
                    Console.SetCursorPosition(55, 1);
                    Console.WriteLine("instrucciones:");
                    Console.SetCursorPosition(54, 3);
                    Console.WriteLine("A=0 | B=1| C=2 | D=3");
                    break;
                case 5:
                    Console.WriteLine("ABCDE\n");
                    Console.SetCursorPosition(55, 1);
                    Console.WriteLine("instrucciones:");
                    Console.SetCursorPosition(53, 3);
                    Console.WriteLine("A=0 | B=1 | C=2 | D=3 | E=4 ");
                    break;
                case 6:
                    Console.WriteLine("ABCDEF\n");
                    Console.SetCursorPosition(51, 1);
                    Console.WriteLine("instrucciones:");
                    Console.SetCursorPosition(51, 3);
                    Console.WriteLine("A=0 | B=1 | C=2 | D=3 | E=4 | F=5");
                    break;
            }
        }
       

        static void mostrar_variab(int n,int c,ref int[,]m1, ref int[,] m2)
        {
            int a = 0, b = 0,d=n-1;

            for (int i = 0; i < n; i++)
            {
                b = i;
                for (int j = c - 1; j >= 0; j--)
                {
                    a = b % 2;
                    b = b / 2;
                    m1[i, j] = a;
                    m2[d, j] = a;
                }
                d--;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.Write(m1[i, j]);
                }
                Console.Write("\t");
                for (int j = 0; j < c; j++)
                {
                    Console.Write(+m2[i, j]);
                }
                Console.WriteLine();
            }
        }

        static string suma_multipl_mismo(string p1, int n, int c, ref int[,] m1)
        {
            string r1 = "";
            for (int i = 0; i < n; i++)
            {               
                
                    if (m1[i, Convert.ToInt32(p1)] == 1 && m1[i, Convert.ToInt32(p1)] == 1)
                    {
                        r1 = r1 + '1';
                    }
                    else
                    {
                        r1 = r1 + '0';
                    }
                
            }
            return r1;
        }
        static void busqueda(string ejercicio,int operacion,ref int[,] m1,ref int [,]m2,int n,int c)
        {
            string p1, p2,pr= (ejercicio[0]).ToString();
            string r1="", r2="", r = "";
            pr = suma_multipl_mismo(pr, n, c, ref m1);

            for (int i = 0; i < ejercicio.Length-1; i++)
            {

                p1 = pr;
                if (ejercicio[i+1] == '+')
                {
                    operacion = 1;                      
                }
                if (ejercicio[i+1] == '*')
                {
                    operacion = 2;
                }
                if (ejercicio[i + 2] == '(')
                {
                    int rango = 0;
                    rango = parentesis_ident((i + 2), ejercicio);
                    p2 = parentesis((i+2), ejercicio,n,c,ref m1,ref m2);
                    if (rango == 3)
                    {
                        i += 5;
                    }else if (rango == 5)
                    {
                        i += 7;
                    }
                    else
                    {
                        i += 9;
                    }
                    
                }
                else
                {
                    p2 = (ejercicio[i+2]).ToString();
                    p2 = suma_multipl_mismo(p2, n, c, ref m1);
                    i += 1;
                }
                Console.WriteLine(p1);
                Console.WriteLine(p2);
                pr =suma_multipl_ejer(p1, p2, operacion,n,c);                
                Console.WriteLine(pr);
            }
            Console.WriteLine("\nel resultado es :");
            for (int i = 0; i <pr.Length ; i++)
            {
                Console.WriteLine(pr[i]);
            }
        }

        static string suma_multipl_ejer(string p1, string p2, int operacion, int n, int c)
        {
            string r1 = "";
            for (int i = 0; i < n; i++)
            {
                if (operacion == 1)
                {
                    if (p1[i] == '0' && p2[i]== '0')
                    {
                        r1 = r1 + '0';
                    }
                    else
                    {
                        r1 = r1 + '1';
                    }
                }
                else
                {
                    if (p1[i] == '1' && p2[i] == '1')
                    {
                        r1 = r1 + '1';
                    }
                    else
                    {
                        r1 = r1 + '0';
                    }
                }
            }                
             return r1;
        }

        //static void  busqueda_pare(string ejercicio)
        //{
        //    int cont = 0,i;
        //    string r1 = "", r2 = "", r3 = "";

        //    for (i = 0; i < ejercicio.Length; i++)
        //    {
        //        if (ejercicio[i] == '(')
        //        {
        //            cont++;
        //            switch (cont)
        //            {
        //                case 1:
        //                    r1 = parentesis(i, ejercicio);
        //                    break;
        //                case 2:                            
        //                    r2 = parentesis(i, ejercicio);
        //                    break;
        //                case 3:
        //                    r3 = parentesis(i, ejercicio);
        //                    break;
        //            }

        //        }

        //    }
        //    Console.WriteLine(r1);
        //    Console.WriteLine(r2);
        //    Console.WriteLine(r3);
        //}


        static string parentesis(int i,string ejercicio,int n,int c,ref int [,]m1, ref int[,] m2)
        {
            string parent = "";
            for (int j = i + 1; j < ejercicio.Length; j++)
            {
                if (ejercicio[j] == ')')
                {
                    break;
                }
                else
                {
                    parent = parent + ejercicio[j];
                }
            }
            parent = suma_multipl(parent,n, c, m1);
            return parent;
        }

        static int parentesis_ident(int i, string ejercicio)
        {
            int cont = 0;
            for (int j = i + 1; j < ejercicio.Length; j++)
            {
                if (ejercicio[j] == ')')
                {
                    break;
                }
                else
                {
                    cont += 1;
                }
            }
           
            return cont;
        }
        static string suma_multipl( string parent,int n,int c,int [,]m1)
        {
            string r1="";
                int cont = 0,operacion=0;
                for (int k = 0; k < parent.Length; k++)
                {
                    if (parent[k] == '+')
                    {
                        operacion = 1;
                        cont++;
                    }
                    if (parent[k] == '*')
                    {
                        operacion = 2;
                        cont++;
                    }
                }
            

            string p1 = (parent[0]).ToString();
            string p2 = (parent[2]).ToString();
            string p3 = (parent[0]).ToString();
            string p4= (parent[2]).ToString();
            switch (cont)
            {
                case 1:
                    p1 = (parent[0]).ToString();
                    p2 = (parent[2]).ToString();
                    for (int i = 0; i < n; i++)
                    {
                        if (operacion == 1)
                        {
                            if (m1[i, Convert.ToInt32(p1)] == 0 && m1[i, Convert.ToInt32(p2)] == 0)
                            {
                                r1 = r1 + '0';
                            }
                            else
                            {
                                r1 = r1 + '1';
                            }
                        }
                        else
                             if (m1[i, Convert.ToInt32(p1)] == 1 && m1[i, Convert.ToInt32(p2)] == 1)
                        {
                            r1 = r1 + '1';
                        }
                        else
                        {
                            r1 = r1 + '0';
                        }
                    }
                    break;
                case 2:
                     p1 = (parent[0]).ToString();
                     p2 = (parent[2]).ToString();
                     p3 = (parent[4]).ToString();
                    for (int i = 0; i < n; i++)
                    {
                        if (operacion == 1)
                        {
                            if (m1[i, Convert.ToInt32(p1)] == 0 && m1[i, Convert.ToInt32(p2)] == 0 && m1[i, Convert.ToInt32(p3)]==0)
                            {
                                r1 = r1 + '0';
                            }
                            else
                            {
                                r1 = r1 + '1';
                            }
                        }
                        else
                             if (m1[i, Convert.ToInt32(p1)] == 1 && m1[i, Convert.ToInt32(p2)] == 1 && m1[i, Convert.ToInt32(p3)] == 1)
                        {
                            r1 = r1 + '1';
                        }
                        else
                        {
                            r1 = r1 + '0';
                        }
                    }
                    break;
                case 3:
                    p1 = (parent[0]).ToString();
                    p2 = (parent[2]).ToString();
                    p3 = (parent[4]).ToString();
                    p4 = (parent[6]).ToString();
                    for (int i = 0; i < n; i++)
                    {
                        if (operacion == 1)
                        {
                            if (m1[i, Convert.ToInt32(p1)] == 0 && m1[i, Convert.ToInt32(p2)] == 0 && m1[i, Convert.ToInt32(p3)] == 0 && m1[i, Convert.ToInt32(p4)] == 0)
                            {
                                r1 = r1 + '0';
                            }
                            else
                            {
                                r1 = r1 + '1';
                            }
                        }
                        else
                             if (m1[i, Convert.ToInt32(p1)] == 1 && m1[i, Convert.ToInt32(p2)] == 1 && m1[i, Convert.ToInt32(p3)] == 1 && m1[i, Convert.ToInt32(p4)] == 1)
                        {
                            r1 = r1 + '1';
                        }
                        else
                        {
                            r1 = r1 + '0';
                        }
                    }
                    break;
            }
           
            return r1;
        }


       
        static void Main(string[] args)
        {
            int a = 49, b = 48, c = 0, d = 2,n;
            int operacion = 0;
            string ejercicio = "";            
           

            Console.WriteLine("cuantas variables ingresara");
            c = Convert.ToInt32(Console.ReadLine());
            n = Convert.ToInt32(Math.Pow(2, c));
            Console.WriteLine("-------------------------------");
            int[,] m1 = new int[n, c];
            int[,] m2 = new int[n, c];

            variables(c);
            mostrar_variab(n, c, ref m1, ref m2);

            Console.WriteLine("\ningrese el ejercicio de acuerdo a las instrucciones");
            ejercicio = Console.ReadLine();
            Console.WriteLine("\n");
            busqueda(ejercicio,operacion,ref m1,ref m2,n,c);
            //Console.WriteLine(parent);

            //r1 = suma_multipl(r1,parent, operacion, n, c, m1);
            //Console.WriteLine(r1);
            Console.ReadKey();
        }
    }
}
