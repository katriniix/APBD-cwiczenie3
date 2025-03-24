using System;
namespace cwiczenia3
{
	public class RefrigeretedContener : Contener, IHazardNotifier
    {
        public string typProduktu;
        public double temperatura;
        public Dictionary<string, double> lista = new Dictionary<string, double>
        {
            { "Bananas", 13.3 },
            { "Chocolate", 18 },
            { "Fish", 2 },
            { "Meat", -12 },
            { "Ice Cream", -18 },
            { "Frozen pizza", -30 },
            { "Cheese", 7.5 },
            { "Sausages", 5 },
            { "Butter", 20.5 },
            { "Eggs", 19 }
        };

		public RefrigeretedContener(double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc, string typProduktu, double temperatura)
			: base(wysokosc, wagaWlasna, glebokosc, "C", maksymalnaLadownosc)
		{
            this.typProduktu = typProduktu;
            this.temperatura = temperatura;

            if (lista.ContainsKey(typProduktu))
            {
                double wymaganaTemperatura = lista[typProduktu];
                if (temperatura < wymaganaTemperatura)
                {
                    Notify($"Temperatura kontenera jest zbyt niska dla produktu! Wymagana temperatura : {wymaganaTemperatura}C");
                }
            }
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

        public void Notify(string message)
        {
            Console.WriteLine($"Dangerous! {numerSeryjny} - {message}");
        }
    }
}

