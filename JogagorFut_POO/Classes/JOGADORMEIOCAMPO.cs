namespace JogagorFut_POO.Classes
{
    public class JOGADORMEIOCAMPO : JogadorFutebol
    {
        public override int TempoAposentadoria(int anos)
        {
            return 38 - anos;
        }
    }
}