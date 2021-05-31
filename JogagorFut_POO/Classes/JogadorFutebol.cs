using System;

namespace JogagorFut_POO.Classes
{
    public abstract class JogadorFutebol
    {
        public string Nome;
        public string DataNascimento;
        public string Nacionalidade;
        public double Altura;
        public double Peso;

        public void Imprimir(string nome, string data, string nac, double alt, double peso)
        {
            Console.WriteLine($"Nome do Jogador: {nome}");
            Console.WriteLine($"Data de nascimento: {data}");
            Console.WriteLine($"Nacionalidade: {nac}");
            Console.WriteLine($"Altura: {alt}");
            Console.WriteLine($"Peso: {peso}\n");
        }

        public int CalcularIdade(string data) //recebe a data de nascimento
        {
            var dataN = DateTime.Parse(data); //converte a data de string para formato data
            return DateTime.Now.Year - dataN.Year; // faz o calculo somente entre os anos, chegando na idade
        }

        public virtual int TempoAposentadoria(int anos)
        {
           return 0; //este metodo só é usado de acordo com a subclasse de jogadores. Como TempoAposentadoria depende do tipo de jogador, não podendo ser generico, então não retorna 0 simplesmente para atender a exigencia de retorno. Não pode ser void pq os metodos em override irão retornar valores especificos.
        }

    }
}