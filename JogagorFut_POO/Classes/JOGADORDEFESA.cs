namespace JogagorFut_POO.Classes
{
    public class JOGADORDEFESA : JogadorFutebol
    {
        public override int TempoAposentadoria(int anos)
        {
            return 40 - anos;
        }
    }
}