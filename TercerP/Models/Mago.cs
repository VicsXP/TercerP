namespace TercerP.Models
{
    public class Mago : Personaje
    {
        public string EscuelaMagia { get; set; } = string.Empty;

        public int Mana { get; set; }
    }
}
