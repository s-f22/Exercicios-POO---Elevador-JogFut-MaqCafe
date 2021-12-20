namespace Elevador_POO.Classes
{
    public class ElevadorServico : ElevadorAbstract
    {
        public ElevadorServico()
        {
            name = "Elevador de SERVIÇO";
            pesoMedioUnidCarga = 10; // Peso de cada caixa
            painelOp_1 = "Carregar";
            painelOp_2 = "Descarregar";
            msgCarga = "CAIXA(S)";
        }
    }
}