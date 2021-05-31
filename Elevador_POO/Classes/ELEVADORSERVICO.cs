using System;

namespace Elevador_POO.Classes
{
    public class ELEVADORSERVICO : ELEVADOR
    {
        public override bool Entrar()
        {
            bool operacao;

            Console.WriteLine("\nQuantas caixas deseja transportar?");
            int numCaixas = int.Parse(Console.ReadLine());
            
            Console.WriteLine("\nQual o peso de uma caixa?");
            PesoCaixas = (float.Parse(Console.ReadLine())) * numCaixas;

            Console.WriteLine($"Peso das caixas: {PesoCaixas}kg; \nCapacidade do Elevador: {CapacidadeElevador}kg; \nOperação Permitida.");
            if (PesoCaixas <= CapacidadeElevador)
            {
                do
                {

                    Console.WriteLine($@"
                Digite a opção desejada:
    1 - Subir  
    2 - Descer");

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
                Console.WriteLine("\nOperação Inválida. \n1Reduza o numero de caixas.");
                Console.WriteLine($"Peso das caixas: {PesoCaixas}kg > Capacidade do Elevador: {CapacidadeElevador}kg");

                return false;
            }



        }
    }
}