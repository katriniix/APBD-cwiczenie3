using System;
namespace cwiczenia3
{
	public abstract class Contener
	{
		public double masaLadunku;
		public double wysokosc;
		public double wagaWlasna;
		public double glebokosc;
		public string numerSeryjny;
		public double maksymalnaLadownosc;
		private static int id = 1;

		public Contener(double wysokosc, double wagaWlasna, double glebokosc, string kod, double maksymalnaLadownosc)
		{
			masaLadunku = 0;
			this.wysokosc = wysokosc;
			this.wagaWlasna = wagaWlasna;
			this.glebokosc = glebokosc;
			numerSeryjny = $"KON-{kod}-{id++}";
			this.maksymalnaLadownosc = maksymalnaLadownosc;
		}

		public abstract void Zaladuj(double masa);

		public virtual void Rozladuj()
		{
			masaLadunku = 0;
		}

        public override string ToString()
        {
            return $"{numerSeryjny} ({GetType().Name}) | Wysokosc: {wysokosc}, Glebokosc: {glebokosc}, Masa wlasna: {wagaWlasna}, Ladunek: {masaLadunku}/{maksymalnaLadownosc}";
        }

    }
}

