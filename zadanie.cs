//
// Autor: Przemysław Sadowski
// Index: 82887
//

using System;

namespace Lab1
{
    class Samochod
    {
        // info na temat samochodow 
        private string marka;
        private string model;
        private int iloscDrzwi;
        private int pojemnoscSilnika;
        private double srednieSpalanie;

        // statyczne pole --> liczba obiektow
        private static int iloscSamochodow = 0;

        // wlasciwosci dostepowe
        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int IloscDrzwi
        {
            get { return iloscDrzwi; }
            set { iloscDrzwi = value; }
        }

        public int PojemnoscSilnika
        {
            get { return pojemnoscSilnika; }
            set { pojemnoscSilnika = value; }
        }

        public double SrednieSpalanie
        {
            get { return srednieSpalanie; }
            set { srednieSpalanie = value; }
        }

        // konstruktor domyslny
        public Samochod()
        {
            marka = "nieznana";
            model = "nieznany";
            iloscDrzwi = 0;
            pojemnoscSilnika = 0;
            srednieSpalanie = 0.0;
            iloscSamochodow++;
        }

        // konstruktor publiczny
        public Samochod(string marka, string model, int iloscDrzwi, int pojemnoscSilnika, double srednieSpalanie)
        {
            this.marka = marka;
            this.model = model;
            this.iloscDrzwi = iloscDrzwi;
            this.pojemnoscSilnika = pojemnoscSilnika;
            this.srednieSpalanie = srednieSpalanie;
            iloscSamochodow++;
        }

        // Prywatna metoda --> obliczenie spalania
        private double ObliczSpalanie(double dlugoscTrasy)
        {
            return (srednieSpalanie * dlugoscTrasy) / 100.0;
        }

        // Publiczna metoda --> obliczenie kosztu przejazdu
        public double ObliczKosztPrzejazdu(double dlugoscTrasy, double cenaPaliwa)
        {
            double spalanie = ObliczSpalanie(dlugoscTrasy);
            return spalanie * cenaPaliwa;
        }

        // Metodaa do wypisywania info
        public void WypiszInfo()
        {
            Console.WriteLine("Marka: " + marka);
            Console.WriteLine("Model: " + model);
            Console.WriteLine("Ilość drzwi: " + iloscDrzwi);
            Console.WriteLine("Pojemność silnika: " + pojemnoscSilnika);
            Console.WriteLine("Średnie spalanie: " + srednieSpalanie + " l/100km");
        }

        // Metoda statyczna --> wypisanie liczby samochodow
        public static void WypiszIloscSamochodow()
        {
            Console.WriteLine("Liczba samochodów: " + iloscSamochodow);
        }
    }

    class Garaz
    {
        // pola prywatne
        private string adres;
        private int pojemnosc;
        private int liczbaSamochodow = 0;
        private Samochod[] samochody;

        // wlasciwosci dostepowe
        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

        public int Pojemnosc
        {
            get { return pojemnosc; }
            set
            {
                pojemnosc = value;
                samochody = new Samochod[pojemnosc];
            }
        }

        // konstruktor domyslny
        public Garaz()
        {
            adres = "nieznany";
            pojemnosc = 0;
            samochody = null;
            // liczbaSamochodow już ustawione na 0
        }

        // konstruktor publiczny
        public Garaz(string adres, int pojemnosc)
        {
            this.adres = adres;
            this.pojemnosc = pojemnosc;
            samochody = new Samochod[pojemnosc];
        }

        // Publiczna metoda --> wprowadzenie nowego samochodu do garażu
        public void WprowadzSamochod(Samochod s)
        {
            if (liczbaSamochodow >= pojemnosc)
            {
                Console.WriteLine("Garaż jest pełny!");
                return;
            }

            samochody[liczbaSamochodow] = s;
            liczbaSamochodow++;
        }

        // Publiczna metoda --> wyprowadzenie ostatniego samochodu z garażu
        public Samochod WyprowadzSamochod()
        {
            if (liczbaSamochodow == 0)
            {
                Console.WriteLine("Garaż jest pusty!");
                return null;
            }

            liczbaSamochodow--;
            Samochod wyprowadzony = samochody[liczbaSamochodow];
            samochody[liczbaSamochodow] = null;
            return wyprowadzony;
        }

        // Publiczna metoda --> wypisywanie informacji o garażu i samochodach
        public void WypiszInfo()
        {
            Console.WriteLine("Adres garażu: " + adres);
            Console.WriteLine("Pojemność garażu: " + pojemnosc);
            Console.WriteLine("Liczba samochodów w garażu: " + liczbaSamochodow);
            Console.WriteLine("Samochody:");

            for (int i = 0; i < liczbaSamochodow; i++)
            {
                Console.WriteLine($"Samochód {i + 1}:");
                samochody[i].WypiszInfo();
                Console.WriteLine();
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            // Zadanie 1
            Samochod s1 = new Samochod("Fiat", "126p", 2, 650, 6.0);
            Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6);
            Samochod s3 = new Samochod("Ford", "Mustang", 2, 5000, 22.5);

            s1.WypiszInfo();
            Console.WriteLine();

            s2.WypiszInfo();
            Console.WriteLine();

            s3.WypiszInfo();
            Console.WriteLine();

            Console.WriteLine($"Koszt przejazdu 150 km przy cenie 6.5 zł/l dla {s1.Marka}: {s1.ObliczKosztPrzejazdu(150, 6.5):0.00} zł");
            Console.WriteLine($"Koszt przejazdu 150 km przy cenie 6.5 zł/l dla {s2.Marka}: {s2.ObliczKosztPrzejazdu(150, 6.5):0.00} zł");
            Console.WriteLine($"Koszt przejazdu 150 km przy cenie 6.5 zł/l dla {s3.Marka}: {s3.ObliczKosztPrzejazdu(150, 6.5):0.00} zł");
            Console.WriteLine();

            Samochod.WypiszIloscSamochodow();


            // Zadanie 2
            Garaz garaz = new Garaz("Warszawa, ul. Garażowa 7", 2);

            garaz.WprowadzSamochod(s1);
            garaz.WprowadzSamochod(s2);
            garaz.WprowadzSamochod(s3); // ten się nie zmieści -> komunikat o pełnym garażu

            Console.WriteLine();
            garaz.WypiszInfo();

            Console.WriteLine("\nWyprowadzanie samochodu z garażu:");
            Samochod wyjechal = garaz.WyprowadzSamochod();
            if (wyjechal != null)
            {
                Console.WriteLine("Wyprowadzono samochód:");
                wyjechal.WypiszInfo();
            }

        }
    }
}