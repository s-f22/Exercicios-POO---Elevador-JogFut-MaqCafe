using System;
using System.Threading;

namespace MaquinaCafe_POO.Classes
{
    public class MaquinaCafe
    {
        public double AcucarDisponivel = 200;
        public virtual void FazerCafe()
        {
            Console.WriteLine("É pra já!");
            AcucarDisponivel -= 10;
            Thread.Sleep(1000);
            Console.WriteLine("\nRetire seu café =P");

            if (AcucarDisponivel <= 0)
            {
                AcucarDisponivel = 0;
                Console.WriteLine("\n(Reabastecer açucar).");
            }
        }

        public virtual void FazerCafe(double quantidade)
        {
            if (AcucarDisponivel <= 0)
            {
                AcucarDisponivel = 0;
                Console.WriteLine("\nReabastecer açucar.");
            }
            else
            {
                Console.WriteLine("Café saindo!");
                AcucarDisponivel -= quantidade;
                Thread.Sleep(2000);
                Console.WriteLine("\nRetire seu café =P");
            }


        }
    }
}