namespace JogagorFut_POO.Classes
{
    public class JOGADORATAQUE : JogadorFutebol
    {
        public override int TempoAposentadoria(int anos)
        {
            return 35 - anos;
        }
    }
}