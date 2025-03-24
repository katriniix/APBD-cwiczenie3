using System;
namespace cwiczenia3
{
	public class GasContener : Contener, IHazardNotifier
    {
		public double cisnienie;

		public GasContener(double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc, double cisnienie)
			: base(wysokosc, wagaWlasna, glebokosc, "G", maksymalnaLadownosc)
		{
			this.cisnienie = cisnienie;
		}

        public override void Zaladuj(double masa)
        {
            if (masaLadunku + masa > maksymalnaLadownosc)
            {
                Notify($"Przekroczono ladownosc kontenera {numerSeryjny}!");
                throw new OverfillException($"Nie mozna zaladowac {masaLadunku} kg. Przekroczenie limitu!");
            }
            masaLadunku += masa;
        }

        public override void Rozladuj()
        {
            masaLadunku *= 0.05;
        }

        public void Notify(string message)
        {
            Console.WriteLine($"Dangerous! {numerSeryjny} - {message}");
        }
    }
}

