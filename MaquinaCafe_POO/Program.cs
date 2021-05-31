using System;
using MaquinaCafe_POO.Classes;

namespace MaquinaCafe_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            MaquinaCafe maq1 = new MaquinaCafe();

            string start;
            Console.WriteLine("\n-----  SUPER CAFETEIRA TABAJARA++ -----");

            do
            {
            
            Console.WriteLine($"\nNivel de açucar da máquina: {(maq1.AcucarDisponivel / 200) * 100:0}%\n");
            Console.WriteLine("Aperte 1 para receber seu Café; \nAperte 2 se desejar escolher um café ++ docinho");
            start = Console.ReadLine();

            if (start == "1") maq1.FazerCafe();
            else if(start == "2")
            {
                Console.WriteLine("\nQuantas gramas de açucar deseja? (de 0g a 50g)");
                double qtde = double.Parse(Console.ReadLine());
                if (qtde >= 0 && qtde <= 50)
                {
                    maq1.FazerCafe(qtde);
                }
                else
                {
                    Console.WriteLine("\nEsta quantidade não é permitida.");
                }
            }
            else Console.WriteLine("\nNão entendi o que vc quer. Tente outra vez.");

            } while (start != "1" || start != "2");


        }
    }
}
