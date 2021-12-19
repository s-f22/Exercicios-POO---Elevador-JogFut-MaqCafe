namespace Elevador_POO.Classes
{
    public class ElevadorSocial : ElevadorAbstract
    {
        public override void Inicializa(double v1, int v2)
        {
            name = "Elevador SOCIAL";
            capacidadeCarga = v1;
            totalAndares = v2;
            andarAtual = 0;
            qtdePresentes = 0;
            portasFechadas = true;
            pesoMedioUnidCarga = 70; // Peso de uma pessoa;
            painelOp_1 = "Entrar";
            painelOp_2 = "Sair";
            msgCarga = "PESSOA(S)";
        }
    }
}