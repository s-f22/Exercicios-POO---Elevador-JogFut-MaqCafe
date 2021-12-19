namespace Elevador_POO.Classes
{
    public class ElevadorServico : ElevadorAbstract
    {
        public override void Inicializa(double v1, int v2)
        {
            name = "Elevador de SERVIÇO";
            capacidadeCarga = v1;
            totalAndares = v2;
            andarAtual = 0;
            qtdePresentes = 0;
            portasFechadas = true;
            pesoMedioUnidCarga = 10; // Peso de cada caixa
            painelOp_1 = "Carregar";
            painelOp_2 = "Descarregar";
            msgCarga = "CAIXA(S)";
        }
    }
}