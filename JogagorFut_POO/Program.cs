using System;
using JogagorFut_POO.Classes;

namespace JogagorFut_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            JOGADORATAQUE j1 = new JOGADORATAQUE();

            j1.Nome = "Romario";
            j1.DataNascimento = "15/02/2002";
            j1.Nacionalidade = "Brasileiro";
            j1.Altura = 1.7;
            j1.Peso = 75.4;


            JOGADORDEFESA j2 = new JOGADORDEFESA();

            j2.Nome = "Ronaldinho";
            j2.DataNascimento = "22/09/1999";
            j2.Nacionalidade = "Brasileiro";
            j2.Altura = 1.85;
            j2.Peso = 70.9;


            JOGADORMEIOCAMPO j3 = new JOGADORMEIOCAMPO();

            j3.Nome = "Neymar";
            j3.DataNascimento = "15/02/1988";
            j3.Nacionalidade = "Brasileiro";
            j3.Altura = 1.8;
            j3.Peso = 68.4;

            j1.Imprimir(j1.Nome, j1.DataNascimento, j1.Nacionalidade, j1.Altura, j1.Peso);
            j2.Imprimir(j2.Nome, j2.DataNascimento, j2.Nacionalidade, j2.Altura, j2.Peso);
            j3.Imprimir(j3.Nome, j3.DataNascimento, j3.Nacionalidade, j3.Altura, j3.Peso);

            Console.WriteLine($"{j1.Nome} possui {j1.CalcularIdade(j1.DataNascimento)} anos de idade.");
            Console.WriteLine($"{j2.Nome} possui {j2.CalcularIdade(j2.DataNascimento)} anos de idade.");
            Console.WriteLine($"{j3.Nome} possui {j3.CalcularIdade(j3.DataNascimento)} anos de idade.\n");
            
            Console.WriteLine($"Faltam {j1.TempoAposentadoria(j1.CalcularIdade(j1.DataNascimento))} anos para {j1.Nome} se aposentar."); // TempoAposentadoria passa como argumento int a função CalcularIdade(), que ao ser executada tras como retorno a idade, utilizada em TempoAposentadoria para calcular quantos anos faltam para o jogador de deterinada posiçao se aposentar; cada sub classe possui um metodo em override, com valores diferentes de idade para aposentadoria. Dependendo da subclasse da qual o jogador fizer parte, (j1, j2, j3 são respectivamente ataque, meiocampo e defesa), os metodos serão diferentes, sobrescritos;
            Console.WriteLine($"Faltam {j2.TempoAposentadoria(j2.CalcularIdade(j2.DataNascimento))} anos para {j2.Nome} se aposentar."); // TempoAposentadoria passa como argumento int a função CalcularIdade(), que ao ser executada tras como retorno a idade, utilizada em TempoAposentadoria para calcular quantos anos faltam para o jogador de deterinada posiçao se aposentar; cada sub classe possui um metodo em override, com valores diferentes de idade para aposentadoria. Dependendo da subclasse da qual o jogador fizer parte, (j1, j2, j3 são respectivamente ataque, meiocampo e defesa), os metodos serão diferentes, sobrescritos;
            Console.WriteLine($"Faltam {j3.TempoAposentadoria(j3.CalcularIdade(j3.DataNascimento))} anos para {j3.Nome} se aposentar."); // TempoAposentadoria passa como argumento int a função CalcularIdade(), que ao ser executada tras como retorno a idade, utilizada em TempoAposentadoria para calcular quantos anos faltam para o jogador de deterinada posiçao se aposentar; cada sub classe possui um metodo em override, com valores diferentes de idade para aposentadoria. Dependendo da subclasse da qual o jogador fizer parte, (j1, j2, j3 são respectivamente ataque, meiocampo e defesa), os metodos serão diferentes, sobrescritos;
            //j1.TempoAposentadoria(j1.CalcularIdade(j1.DataNascimento));
        }
    }
}
