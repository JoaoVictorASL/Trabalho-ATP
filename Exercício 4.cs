using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int  numX, numY;


            while (true)
            {
                Console.WriteLine("Informe um valor de X:");
                numX = int.Parse(Console.ReadLine());

                Console.WriteLine("Informe um valor de Y:");
                numY = int.Parse(Console.ReadLine());

                if (numX == 0 && numY ==0) 
                    break;

                else if (numX > 0 && numY > 0)
                    Console.WriteLine($"{numX} {numY}: Primeiro quadrante");

                else if (numX < 0 && numY > 0)
                    Console.WriteLine($"{numX} {numY}: Segundo quadrante");

                else if (numX < 0 && numY < 0)
                    Console.WriteLine($"{numX} {numY}: Terceiro quadrante");

                else if (numX > 0 && numY < 0)
                    Console.WriteLine($"{numX} {numY}: Quarto quadrante");
            }
            Console.ReadLine();
        }
    }
}
