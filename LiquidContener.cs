using System;
namespace cwiczenia3
{
	public class LiquidContener : Contener, IHazardNotifier
	{
		public bool isDangerous { get; set; }

		public LiquidContener(double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc, bool isDangerous)
			: base(wysokosc, wagaWlasna, glebokosc, "L", maksymalnaLadownosc)
		{
			this.isDangerous = isDangerous;
		}

		public override void Zaladuj(double masa)
		{
            if (isDangerous)
			{
				if (masaLadunku + masa > maksymalnaLadownosc * 0.5)
				{
					Notify($"Proba wykonania niebezpiecznej operacji");
					throw new OverfillException($"Nie mozna zaladowac {masaLadunku} kg. Przekroczenie limitu!");

				}
			}
			else
			{
                if (masaLadunku + masa > maksymalnaLadownosc * 0.9)
                {
                    Notify($"Proba wykonania niebezpiecznej operacji");
                    throw new OverfillException($"Nie mozna zaladowac {masaLadunku} kg. Przekroczenie limitu!");

                }
            }
            masaLadunku += masa;
        }

		public void Notify(string message)
		{
			Console.WriteLine($"Dangerous! {numerSeryjny} - {message}");
		}
	}
}

