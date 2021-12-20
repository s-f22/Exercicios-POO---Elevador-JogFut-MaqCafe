using System;
using System.Threading;

namespace Elevador_POO.Classes
{
    public abstract class ElevadorAbstract
    {

        //VARIAVEIS INDIVIDUAIS PARA CADA EÇEVADOR, POREM PRESENTES TANTO EM SOCIAL/SERVICO
        public int totalAndares { get; set; }
        public double capacidadeCarga { get; set; }
        public int andarAtual { get; set; }
        public int qtdePresentes { get; set; }
        public bool portasFechadas { get; set; }


        //VARIAVEIS ESPECIFICAS SOCIAL/SERVIÇO
        public string name { get; set; }
        public int pesoMedioUnidCarga { get; set; }
        public int qtdeMaxUnidCarga { get; set; }


        //VARIAVEIS PARA PAINEL DE COMANDO
        public string painelOp_1 { get; set; }
        public string painelOp_2 { get; set; }
        public string msgCarga { get; set; }



        public bool Inicializa(double v1, int v2)
        {
            capacidadeCarga = v1;
            totalAndares = v2;
            andarAtual = 0;
            qtdePresentes = 0;
            portasFechadas = true;
            
            //LIMITES DE CARGA DOS ELEVADORES E MAX QTDE DE ANDARES DO PREDIO:
            int maxCARGAkg = 1000;
            int maxAndares = 30;

            if (capacidadeCarga <= maxCARGAkg && totalAndares <= maxAndares)
            {
                this.qtdeMaxUnidCarga = (int)this.capacidadeCarga / this.pesoMedioUnidCarga;

                Console.WriteLine($"\nCAPACIDADE MAXIMA DE {this.msgCarga} do {this.name}: {this.qtdeMaxUnidCarga} ({this.pesoMedioUnidCarga}kgs / unid)");

                return true;
            }
            else
                return false;
        }


       

        public void MenuComando()
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
|-- {this.name}
|-- Portas: {portas} 
|-- {this.qtdePresentes} {this.msgCarga} no elevador / {this.qtdeMaxUnidCarga} (Capac.Max)
|-- Andar Atual: {this.andarAtual}º/{this.totalAndares} andares
|
|    Digite a opção desejada:
|
|    1 - {this.painelOp_1};
|    2 - {this.painelOp_2};
|    3 - Subir;
|    4 - Descer;
|      
|    5 - Voltar ao menu anterior;
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




        public void Embarque(int entradaSaida)
        {
            if (portasFechadas == true)
            {
                Console.WriteLine("\nAbrindo portas...");
                Thread.Sleep(3000);
                portasFechadas = false;

                Console.WriteLine("Portas Abertas.");
                Console.WriteLine($"{entradaSaida} {this.msgCarga} em transito.Aguarde...");
                Thread.Sleep(5000);

                Console.WriteLine("Fechando portas...");
                Thread.Sleep(3000);
                portasFechadas = true;
                Console.WriteLine("Portas Fechadas.\n");
            }
            else
            {
                Console.WriteLine("Portas Abertas.");
                Console.WriteLine($"{entradaSaida} {this.msgCarga} entraram.");

                Console.WriteLine("Fechando portas...");
                Thread.Sleep(2000);
                portasFechadas = true;
                Console.WriteLine("Portas Fechadas.");
            }
        }





        public void Entrar()
        {
            int entrando;

            if (qtdePresentes >= this.qtdeMaxUnidCarga)
                Console.WriteLine("Elevador Lotado.");
            else
            {
                Console.WriteLine($"Quantas {this.msgCarga} deseja(m) {this.painelOp_1}?");
                entrando = int.Parse(Console.ReadLine());

                if ((qtdePresentes + entrando) <= this.qtdeMaxUnidCarga)
                {
                    qtdePresentes += entrando;
                    Embarque(entrando);
                }
                else
                    Console.WriteLine($"Limite de carga excedido. Reduza a quantidade de {this.msgCarga} entrando");
            }
        }




        public void Sair()
        {
            int saindo;

            if (qtdePresentes == 0)
                Console.WriteLine("Elevador Vazio.");
            else
            {
                Console.WriteLine($"Quantas {this.msgCarga} a {this.painelOp_2}?");
                saindo = int.Parse(Console.ReadLine());

                if ((qtdePresentes - saindo) >= 0)
                {
                    qtdePresentes -= saindo;
                    Embarque(saindo);
                }
                else
                    Console.WriteLine($"Há somente {qtdePresentes} {this.msgCarga} no elevador.");
            }
        }




        public void Subir()
        {
            int qtdeSubir;

            if (andarAtual == totalAndares)
                Console.WriteLine("O elevador já está no último andar.");
            else if (qtdePresentes == 0)
                Console.WriteLine("O elevador está vazio.");
            else
            {
                Console.WriteLine("Subir quantos andares? ");
                qtdeSubir = int.Parse(Console.ReadLine());


                if (andarAtual + qtdeSubir > totalAndares)
                    Console.WriteLine("Destino inválido. Tente outro andar");
                else
                {
                    Console.WriteLine("Subindo...");
                    Thread.Sleep(2000);

                    int destino = andarAtual + qtdeSubir;
                    for (var i = andarAtual; i < destino; i++)
                    {
                        Console.WriteLine($"{i + 1}º andar");
                        Thread.Sleep(1000);
                    }

                    andarAtual += qtdeSubir;
                    Console.WriteLine($"\nBem vindo ao {andarAtual}º andar.");
                }
            }
        }





        public void Descer()
        {
            int qtdeDescer;

            if (andarAtual == 0)
                Console.WriteLine("O elevador já está no térreo.");
            else if (qtdePresentes == 0)
                Console.WriteLine("O elevador está vazio.");
            else
            {
                Console.WriteLine("Descer quantos andares? ");
                qtdeDescer = int.Parse(Console.ReadLine());

                if (andarAtual - qtdeDescer < 0)
                    Console.WriteLine("Destino inválido. Tente outro andar");
                else
                {
                    Console.WriteLine("Descendo...");
                    Thread.Sleep(2000);

                    int destino = andarAtual - qtdeDescer;
                    for (var i = andarAtual; i > destino; i--)
                    {
                        Console.WriteLine($"{i}º andar");
                        Thread.Sleep(1000);
                    }

                    andarAtual -= qtdeDescer;
                    if (andarAtual == 0)
                        Console.WriteLine($"Bem vindo ao térreo.");
                    else
                        Console.WriteLine($"Bem vindo ao {andarAtual}º andar.");
                }
            }
        }
    }
}