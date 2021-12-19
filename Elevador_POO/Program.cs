using System;
using System.Threading;
using Elevador_POO.Classes;

namespace Elevador_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            double cap;
            int totAnd;
            bool inicializado;
            bool encerrar = false;
            int opcao;

            Console.WriteLine("\nInicializando sistema...\n");

            ElevadorSocial e1 = new ElevadorSocial();
            ElevadorServico e2 = new ElevadorServico();

            Thread.Sleep(3000);

            do
            {
                Console.WriteLine("Informe a capacidade de carga do elevador: (em kgs)");
                cap = double.Parse(Console.ReadLine());

                Console.WriteLine("Informe o total de andares do prédio: ");
                totAnd = int.Parse(Console.ReadLine());

                e1.Inicializa(cap, totAnd);
                e2.Inicializa(cap, totAnd);

                if (e1.SetterElevador() == false)
                {
                    Console.WriteLine("\nValores invalidos. Capacidade Max: 1000kg; Andares: max 30;\nPor favor, tente novamente.\n");
                    inicializado = false;
                }
                else if (e2.SetterElevador() == false)
                {
                    Console.WriteLine("\nValores invalidos. Capacidade Max: 1000kg; Andares: max 30;\nPor favor, tente novamente.\n");
                    inicializado = false;
                }
                else
                    inicializado = true;

            } while (inicializado == false);

            Console.WriteLine("\nPor favor aguarde...");
            Thread.Sleep(4000);
            Console.WriteLine("Sistema inicializado com sucesso.");

            do
            {
                Console.WriteLine($@"
|--------------------------------------------|            
|------------- PAINEL DE CONTROLE -----------|
|                                            |
|    Digite a opção desejada:                |
|                                            |
|    1 - Elevador Social;                    |
|    2 - Elevador de Serviço;                |
|                                            |
|    3 - Finalizar Programa                  |
|--------------------------------------------|");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        e1.MenuComando();
                        encerrar = false;
                        break;
                    case 2:
                        e2.MenuComando();
                        encerrar = false;
                        break;
                    case 3:
                        encerrar = true;
                        break;
                    default:
                        Console.WriteLine("Opção Inválida.");
                        break;
                }


            } while (encerrar == false);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sistema Finalizado.");
        }
    }
}
