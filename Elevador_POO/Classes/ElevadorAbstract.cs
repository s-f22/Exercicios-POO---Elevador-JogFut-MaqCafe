using System;
using System.Threading;

namespace Elevador_POO.Classes
{
    public abstract class ElevadorAbstract
    {
        public int totalAndares { get; set; }
        public double capacidadeCarga { get; set; }

        public int andarAtual { get; set; }
        public int qtdePresentes { get; set; }

        public bool portasFechadas { get; set; }

        public string name { get; set; }



        public virtual void Embarque(int qtdeEntrada)
        {

        }


        public virtual void MenuComando()
        {


        }


        public virtual bool Inicializa(double v1, int v2)
        {
            return false;
        }

        public virtual void Entrar()
        {



        }


        public virtual void Sair()
        {

        }


        public void Subir()
        {
            int qtdeSubir;

            if (andarAtual == totalAndares)
            {
                Console.WriteLine("O elevador já está no último andar.");
            }
            else if (qtdePresentes == 0)
            {
                Console.WriteLine("O elevador está vazio.");
            }
            else
            {
                Console.WriteLine("Subir quantos andares? ");
                qtdeSubir = int.Parse(Console.ReadLine());


                if (andarAtual + qtdeSubir > totalAndares)
                {
                    Console.WriteLine("Destino inválido. Tente outro andar");
                }
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
                    Console.WriteLine($"Bem vindo ao {andarAtual}º andar.");
                }
            }

        }



        public void Descer()
        {
            int qtdeDescer;

            if (andarAtual == 0)
            {
                Console.WriteLine("O elevador já está no térreo.");
            }
            else if (qtdePresentes == 0)
            {
                Console.WriteLine("O elevador está vazio.");
            }
            else
            {
                Console.WriteLine("Descer quantos andares? ");
                qtdeDescer = int.Parse(Console.ReadLine());


                if (andarAtual - qtdeDescer < 0)
                {
                    Console.WriteLine("Destino inválido. Tente outro andar");
                }
                else
                {
                    Console.WriteLine("Descendo...");
                    Thread.Sleep(2000);

                    int destino = andarAtual - qtdeDescer;
                    for (var i = andarAtual; i > 0; i--)
                    {
                        Console.WriteLine($"{i}º andar");
                        Thread.Sleep(1000);
                    }

                    andarAtual -= qtdeDescer;
                    if (andarAtual == 0)
                    {
                        Console.WriteLine($"Bem vindo ao térreo.");
                    }
                    else
                        Console.WriteLine($"Bem vindo ao {andarAtual}º andar.");
                }
            }


        }
    }
}