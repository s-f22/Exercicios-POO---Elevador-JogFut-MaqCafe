using System;
using System.Threading;

namespace Elevador_POO.Classes
{
    public abstract class ELEVADOR
    {
        public static int destino;
        public static double PesoPessoas;
        public static double PesoCaixas;

        public int AndarAtual;
        public int TotalAndares;
        public double CapacidadeElevador;
        public int QtdePresentes;

        public void Inicializa(double v1, int v2)
        {
            CapacidadeElevador = v1;
            TotalAndares = v2;

            QtdePresentes = 0;
            AndarAtual = 0;

            //dentro = false;
        }

        public virtual bool Entrar()
        {
            int sobem;
            bool operacao;
            do
            {

            Console.WriteLine("\nQuantas pessoas desejam entrar?");
            sobem = int.Parse(Console.ReadLine());

            
            if ((sobem + QtdePresentes) * 70d <= CapacidadeElevador)
            {
                QtdePresentes = QtdePresentes + sobem;
                PesoPessoas = QtdePresentes * 70d; // numero de pessoas multiplicado pelo peso medio de uma pessoa, para verificar se esta dentro da capacidade de carga

                Console.WriteLine($"Entraram {sobem} pessoa(s) no elevador.");
                Console.WriteLine($"Total atualizado de passageiros: {QtdePresentes}");
            }
            else
            {
                Console.WriteLine("Quantidade excessiva de passageiros.");
            }
            } while ((sobem + QtdePresentes) * 70d > CapacidadeElevador);


            if (PesoPessoas <= CapacidadeElevador)
            {
                do
                {

                    Console.WriteLine($@"
|----------------------------------------------------|                    
|--------------- Digite a opção desejada: -----------|
|    1 - Subir                                       |
|    2 - Descer                                      |
|----------------------------------------------------|");
                    string opt = Console.ReadLine();

                    if (opt == "1" && AndarAtual < TotalAndares)
                    {
                        Subir();
                        operacao = true;
                    }
                    else if (opt == "1" && AndarAtual >= TotalAndares)
                    {
                        if (AndarAtual == TotalAndares)
                        {
                            Console.WriteLine("Você já está no último andar.");
                            operacao = false;
                        }
                        else
                        {
                            Console.WriteLine("\nOpção inválida.");
                            Console.WriteLine($"Andar atual: {AndarAtual}\nAndar Desejado: {TotalAndares}");
                            operacao = false;
                        }
                    }
                    else if (opt == "2" && AndarAtual != 0)
                    {
                        Descer();
                        operacao = true;
                    }
                    else if (opt == "2" && AndarAtual == 0)
                    {
                        Console.WriteLine("Opção Inválida.");
                        Console.WriteLine($"Você já esta no andar térreo.");
                        operacao = false;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida.");
                        operacao = false;
                    }
                } while (operacao == false);

                return true;
            }
            else
            {
                Console.WriteLine("Reduza o numero de passageiros.");
                return false;
            }



        }







        public void Sair()
        {
            int descem;
            do
            {
            Console.WriteLine("\nQuantas pessoas desejam sair?");
            descem = int.Parse(Console.ReadLine());
            // QtdePresentes = QtdePresentes - descem;
            // PesoPessoas = QtdePresentes * 70; // numero de pessoas multiplicado pelo peso medio de uma pessoa, para verificar se esta dentro da capacidade de carga

            // Console.WriteLine($"Desceram {descem} pessoa(s) do elevador.");
            // Console.WriteLine($"Total atualizado de passageiros: {QtdePresentes}");

            if ((QtdePresentes - descem) * 70 >= 0)
            {
                QtdePresentes = QtdePresentes - descem;
                PesoPessoas = QtdePresentes * 70; // numero de pessoas multiplicado pelo peso medio de uma pessoa, para verificar se esta dentro da capacidade de carga

                Console.WriteLine($"Desceram {descem} pessoa(s) do elevador.");
                Console.WriteLine($"Total atualizado de passageiros: {QtdePresentes}");
            }
            else
            {
                Console.WriteLine("Quantidade excessiva de passageiros.");
            }
            } while ((QtdePresentes - descem) * 70 < 0);


            Console.WriteLine("Abrindo as portas...");
            Thread.Sleep(2000);
            AndarAtual = destino;
            //Console.WriteLine($"Bem vindo ao {AndarAtual}º andar.");
            //Console.WriteLine($"Até logo!");
        }



        public void Subir()
        {

            do
            {
                Console.Write("\nDigite o numero do andar desejado: ");
                destino = int.Parse(Console.ReadLine());

                if ((destino) <= TotalAndares)
                {
                    //subir = true;
                    Console.WriteLine("Fechando portas. Aguarde enquanto subimos...");
                    Thread.Sleep(4000);
                    AndarAtual = destino;
                    Console.WriteLine($"{AndarAtual}º Andar.");

                }
                else
                {
                    Console.WriteLine("\nOpção Invalida.");
                    Console.WriteLine($"\nAndar digitado: {destino} \nTotal de Andares: {TotalAndares}");
                    //subir = false;
                }
            } while (destino > TotalAndares);
        }
        public void Descer()
        {
            int destino;
            do
            {
                Console.Write("\nDigite o numero do andar desejado: ");
                destino = int.Parse(Console.ReadLine());

                if (destino <= AndarAtual && destino >= 0)
                {
                    //subir = true;
                    Console.WriteLine("Fechando portas. Aguarde enquanto descemos...");
                    Thread.Sleep(4000);
                    AndarAtual = destino;
                    Console.WriteLine($"{AndarAtual}º Andar.");

                }
                else if (destino == AndarAtual && AndarAtual == 0)
                {
                    Console.WriteLine("Você já está no térreo.");
                }
                else
                {
                    Console.WriteLine("\nOpção Invalida.");
                    Console.WriteLine($"\nAndar digitado: {destino} \nTotal de Andares: {TotalAndares}");
                    //subir = false;
                }
            } while (destino < AndarAtual && destino >= 0);

        }
    }
}