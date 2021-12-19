using System;
using System.Threading;

namespace Elevador_POO.Classes
{
    public class ElevadorServico : ElevadorAbstract
    {
        int pesoMedioCaixa = 10;
        int maxCaixas { get; set; }


        public override void MenuComando()
        {
            int opcao;
            string portas;
            bool encerrar;

            if (portasFechadas)
                portas = "fechadas";
            else
                portas = "abertas";

            do
            {
                Console.WriteLine($@"
|--------------------------------------------|            
|------------- PAINEL DE CONTROLE -----------|
|                                            |
|-- {this.name} ----------------------|
|-- Portas: {portas} ------------------------|
|-- {this.qtdePresentes} caixas no elevador / {maxCaixas} (Capac.Max)----|
|-- Andar Atual: {this.andarAtual}º/{this.totalAndares} andares --------------|
|                                            |
|    Digite a opção desejada:                |
|                                            |
|    1 - Carregar;                           |
|    2 - Descarregar;                        |
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



        public override void Embarque(int qtdeCaixasEntrando)
        {
            int maisCaixas = qtdeCaixasEntrando;

            if (portasFechadas == true)
            {
                Console.WriteLine("Abrindo portas...");
                Thread.Sleep(2000);
                portasFechadas = false;

                Console.WriteLine("Portas Abertas.");
                Console.WriteLine($"{maisCaixas} caixas em transito.");

                Console.WriteLine("Fechando portas...");
                Thread.Sleep(2000);
                portasFechadas = true;
                Console.WriteLine("Portas Fechadas.");
            }
            else
            {
                Console.WriteLine("Portas Abertas.");
                Console.WriteLine($"{maisCaixas} caixas entraram.");

                Console.WriteLine("Fechando portas...");
                Thread.Sleep(2000);
                portasFechadas = true;
                Console.WriteLine("Portas Fechadas.");
            }
        }



        public override bool Inicializa(double v1, int v2)
        {
            name = "Elevador de SERVIÇO";
            capacidadeCarga = v1;
            totalAndares = v2;
            andarAtual = 0;
            qtdePresentes = 0;
            portasFechadas = true;

            if (capacidadeCarga <= 1000 && totalAndares <= 30)
            {
                maxCaixas = (int)this.capacidadeCarga / pesoMedioCaixa;
                Console.WriteLine($"CAPACIDADE MAXIMA DE CAIXAS do elevador de serviço: {maxCaixas} ({pesoMedioCaixa}kgs / caixa)");
                return true;
            }
            else
                return false;
        }



        public override void Entrar()
        {
            int entrando;

            if (qtdePresentes >= maxCaixas)
            {
                Console.WriteLine("Elevador Lotado.");
            }
            else
            {
                Console.WriteLine("Quantas caixas deseja carregar?");
                entrando = int.Parse(Console.ReadLine());

                if ((qtdePresentes + entrando) <= maxCaixas)
                {
                    qtdePresentes += entrando;

                    Embarque(entrando);
                }
                else
                    Console.WriteLine("Limite de carga excedido. Reduza a quantidade de caixas");

            }
        }




        public override void Sair()
        {
            int saindo;

            if (qtdePresentes == 0)
                Console.WriteLine("Elevador Vazio.");
            else
            {
                Console.WriteLine("Quantas caixas deseja retirar?");
                saindo = int.Parse(Console.ReadLine());

                if ((qtdePresentes - saindo) >= 0)
                {
                    qtdePresentes -= saindo;
                    Embarque(saindo);
                }
                else
                    Console.WriteLine($"Há somente {qtdePresentes} caixas no elevador.");
            }
        }
    }
}