using System;
using System.Threading;
using Elevador_POO.Classes;

namespace Elevador_POO
{
    class Program
    {

        static bool encerrar;
        static string opcao;
        public static bool dentro;


        static void Main(string[] args)
        {
            Console.WriteLine("\nInicializando sistema...\n");

            ELEVADORSOCIAL elv_1 = new ELEVADORSOCIAL();
            ELEVADORSERVICO elv_2 = new ELEVADORSERVICO();
            Thread.Sleep(3000);

            Console.WriteLine("Informe a capacidade do elevador: (em kg)");
            double cap_kg = double.Parse(Console.ReadLine());

            Console.WriteLine("\nInforme o total de andares do prédio: ");
            int andares = (int.Parse(Console.ReadLine()));

            elv_1.Inicializa(cap_kg, andares);
            elv_2.Inicializa(cap_kg, andares);

            Console.WriteLine("\nPor favor aguarde...");
            Thread.Sleep(4000);
            Console.WriteLine("\nSistema inicializado!\n");
            Console.WriteLine($"Capacidade de carga: {cap_kg}kg ({cap_kg / 70} pessoas)");
            Console.WriteLine($"Numero de andares do predio: {andares}");
            Console.WriteLine("Andar atual: 0 \nElevadores vazios e prontos para uso.");
            Console.WriteLine("OBS: Peso considerado para uma pessoa: 70kg");

            encerrar = false;
            dentro = false;

            do
            {
                Console.WriteLine($@"
|--------------------------------------------|            
|------------- PAINEL DE CONTROLE -----------|
|    1 - Entrar                              |
|    2 - Sair                                |
|                                            |
|    3 - Finalizar Programa                  |
|--------------------------------------------|");

                opcao = Console.ReadLine();

                if (opcao == "1" && dentro == false)
                {
                    Console.WriteLine("\nQual elevador deseja utilizar? \n\n1 - Social; \n2 - Serviço;");
                    string tipo = Console.ReadLine();

                    if (tipo == "1") dentro = elv_1.Entrar();
                    else if (tipo == "2") dentro = elv_2.Entrar();
                    else Console.WriteLine("Opção Inválida");

                    //dentro = true;
                    encerrar = false;
                }
                else if (opcao == "2" && dentro == false)
                {
                    Console.WriteLine("Você já está fora do elevador.");
                    encerrar = false;
                }
                else if (opcao == "1" && dentro == true)
                {
                    Console.WriteLine("Você já está dentro do elevador.");
                    encerrar = false;
                }
                else if(opcao == "2" && dentro == true)
                {
                    elv_1.Sair();

                    dentro = false;
                    encerrar = false;
                }else if (opcao == "3")
                {
                    Console.WriteLine("Encerrando sistema...");
                    Thread.Sleep(3000);
                    Console.WriteLine("Programa Finalizado.");
                    encerrar = true;
                }


            } while (encerrar == false);
        }
    }
}
