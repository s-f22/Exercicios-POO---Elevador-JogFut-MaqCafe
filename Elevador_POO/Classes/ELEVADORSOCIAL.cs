namespace Elevador_POO.Classes
{
    public class ElevadorSocial : ElevadorAbstract
    {
        public ElevadorSocial()
        {
            name = "Elevador SOCIAL";
            pesoMedioUnidCarga = 70; // Peso de uma pessoa;
            painelOp_1 = "Entrar";
            painelOp_2 = "Sair";
            msgCarga = "PESSOA(S)";
        }
    }
}