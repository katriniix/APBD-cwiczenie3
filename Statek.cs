using System;
namespace cwiczenia3
{
	public class Statek
	{
		public List<Contener> kontenery;
		public double maksymalnaPredkosc;
		public int maksymalnaLiczbaKontenerow;
		public double maksymalnaWagaKontenerow;
		public string nazwa;
		private static int liczba = 1;

		public Statek(double maksymalnaPredkosc, int maksymalnaLiczbaKontenerow, double maksymalnaWagaKontenerow)
		{
			this.nazwa = $"Statek-{liczba++}";
			this.maksymalnaPredkosc = maksymalnaPredkosc;
			this.maksymalnaLiczbaKontenerow = maksymalnaLiczbaKontenerow;
			this.maksymalnaWagaKontenerow = maksymalnaWagaKontenerow;
			kontenery = new List<Contener>();
		}

		public double WagaCalkowita()
		{
			double total = 0;
			foreach (var x in kontenery)
			{
				total += x.wagaWlasna + x.masaLadunku;
			}
			return total;
		}

		public void DodajKontener(Contener kontener)
		{
			if (kontenery.Count >= maksymalnaLiczbaKontenerow)
			{
				throw new InvalidOperationException("Przekroczona maksymalna liczba kontenerow!");
			}

			if (WagaCalkowita() + kontener.wagaWlasna + kontener.masaLadunku > maksymalnaWagaKontenerow * 1000)
			{
				throw new InvalidOperationException("Przekroczona maksymalna waga kontenerow!");
			}

			kontenery.Add(kontener);
		}

		public void ZaladujKontenery(List<Contener> lista)
		{
			foreach (var kontener in lista)
			{
				DodajKontener(kontener);
			}

		}

		public void UsunKontener(Contener kontener)
		{
			if (!kontenery.Contains(kontener))
			{
				throw new InvalidOperationException("Kontener nie znajduje sie na statku");
			}
			kontenery.Remove(kontener);
		}

		public void RozladujKontener(string numerSeryjny)
		{
			bool znaleziono = false;
			foreach (var kontener in kontenery)
			{
				if (kontener.numerSeryjny == numerSeryjny)
				{
					kontener.Rozladuj();
					znaleziono = true;
					break;
				}
			}

			if (!znaleziono)
			{
				throw new InvalidOperationException("Kontener o podanym numerze nie istnieje");
			}

		}

		public void ZaptapKontener(string kontenerDoZastapienia, Contener nowyKontener)
		{
			bool znaleziono = false;
			for (int i = 0; i < kontenery.Count; i++)
			{
				if (kontenery[i].numerSeryjny == kontenerDoZastapienia)
				{
					double staraWaga = kontenery[i].wagaWlasna + kontenery[i].masaLadunku;
					double nowaWaga = nowyKontener.wagaWlasna + nowyKontener.masaLadunku;
					double nowaCalkowitaWaga = WagaCalkowita() - staraWaga + nowaWaga;

					if (nowaCalkowitaWaga > maksymalnaWagaKontenerow * 1000)
					{
						throw new InvalidOperationException("Przekroczona maksymalna waga kontenerow");
					}

					kontenery[i] = nowyKontener;
					znaleziono = true;
					break;
				}
			}

			if (!znaleziono)
			{
				throw new InvalidOperationException("Kontener do zastopienia nie zostal znaleziony");
			}
		}

		public void PrzeniesKontener(Statek innyStatek, string numerSeryjny)
		{
			Contener kontener = null;
			foreach (var x in kontenery)
			{
				if (x.numerSeryjny == numerSeryjny)
				{
					kontener = x;
					break;
				}
			}

			if (kontener == null)
			{
				throw new InvalidOperationException("Kontener o podanym numerze nie istnieje");
			}

			innyStatek.DodajKontener(kontener);
			kontenery.Remove(kontener);
		}

        public override string ToString()
        {
			return $"{nazwa}: Predkosc = {maksymalnaPredkosc} wezlow, Maks. liczba kontenerow = {maksymalnaLiczbaKontenerow}, Maks. waga kontenerow = {maksymalnaWagaKontenerow} ton, " +
				$"Aktualnie zaladowanych kontenerow: {kontenery.Count}, Laczna waga: {WagaCalkowita()} kg";

        }

    }
}

