using System;
using System.Threading;
using Elevador_POO.Classes;

namespace Elevador_.Classes
{
    public class ElevadorSocial : ElevadorAbstract
    {
        int pesoMedioPessoa = 70;
        int maxPassageiros { get; set; }




        public override void MenuComando()
        {

            int opcao;
            string portas;
            bool encerrar;

            if (portasFechadas)
            {
                portas = "fechadas";
            }
            else
            {
                portas = "abertas";
            }

            do
            {
                Console.WriteLine($@"
|--------------------------------------------|            
|------------- PAINEL DE CONTROLE -----------|
|                                            |
|-- {this.name} -------------------------|
|-- Portas: {portas} ------------------------|
|-- {this.qtdePresentes} pessoas no elevador / {maxPassageiros} (Capac.Max)----|
|-- Andar Atual: {this.andarAtual}º/{this.totalAndares} andares --------------|
|                                            |
|    Digite a opção desejada:                |
|                                            |
|    1 - Entrar;                             |
|    2 - Sair;                               |
|    3 - Subir;                              |
|    4 - Descer;                             |
|                                            |
|    5 - Voltar ao menu anterior;            |
|--------------------------------------------|");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        this.Entrar();
                        encerrar = false;
                        break;
                    case 2:
                        this.Sair();
                        encerrar = false;
                        break;
                    case 3:
                        this.Subir();
                        encerrar = false;
                        break;
                    case 4:
                        this.Descer();
                        encerrar = false;
                        break;
                    case 5:
                        encerrar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        encerrar = false;
                        break;
                }


            } while (encerrar == false);
        }



        public override void Embarque(int qtdePessoasEntrando)
        {
            int maisPessoas = qtdePessoasEntrando;

            if (portasFechadas == true)
            {
                Console.WriteLine("Abrindo portas...");
                Thread.Sleep(2000);
                portasFechadas = false;

                Console.WriteLine("Portas Abertas.");
                Console.WriteLine($"{maisPessoas} pessoas em transito.");

                Console.WriteLine("Fechando portas...");
                Thread.Sleep(2000);
                portasFechadas = true;
                Console.WriteLine("Portas Fechadas.");
            }
            else
            {
                Console.WriteLine("Portas Abertas.");
                Console.WriteLine($"{maisPessoas} pessoas entraram.");

                Console.WriteLine("Fechando portas...");
                Thread.Sleep(2000);
                portasFechadas = true;
                Console.WriteLine("Portas Fechadas.");
            }
        }


        public override bool Inicializa(double v1, int v2)
        {
            name = "Elevador SOCIAL";
            capacidadeCarga = v1;
            totalAndares = v2;
            andarAtual = 0;
            qtdePresentes = 0;
            portasFechadas = true;

            if (capacidadeCarga <= 1000 && totalAndares <= 30)
            {
                maxPassageiros = (int)this.capacidadeCarga / pesoMedioPessoa;
                Console.WriteLine($"\nCAPACIDADE MAXIMA DE PESSOAS do elevador social: {maxPassageiros} ({pesoMedioPessoa}kgs / pessoa)");
                return true;
            }
            else
                return false;
        }

        public override void Entrar()
        {
            int entrando;

            if (qtdePresentes >= maxPassageiros)
            {
                Console.WriteLine("Elevador Lotado.");
            }
            else
            {
                    Console.WriteLine("Quantas pessoas desejam entrar?");
                    entrando = int.Parse(Console.ReadLine());

                    if ((qtdePresentes + entrando) <= maxPassageiros)
                    {
                        qtdePresentes += entrando;

                        Embarque(entrando);
                    }
                    else
                    {
                        Console.WriteLine("Limite de carga excedido. Reduza a quantidade de passageiros");
                    }

            }
        }




        public override void Sair()
        {
            int saindo;

            if (qtdePresentes == 0)
            {
                Console.WriteLine("Elevador Vazio.");
            }
            else
            {
                    Console.WriteLine("Quantas pessoas desejam sair?");
                    saindo = int.Parse(Console.ReadLine());

                    if ((qtdePresentes - saindo) >= 0)
                    {
                        qtdePresentes -= saindo;

                        Embarque(saindo);
                    }
                    else
                    {
                        Console.WriteLine($"Há somente {qtdePresentes} pessoas no elevador.");
                    }

            }
        }



    }
}