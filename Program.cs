using System;

enum KlasaRzadkosci
{
    Powszechny,
    Rzadki,
    Unikalny,
    Epicki
}

enum TypPrzedmiotu
{
    Bron,
    Zbroja,
    Amulet,
    Pierscien,
    Helm,
    Tarcza,
    Buty
}

struct Przedmiot
{
    public float waga;
    public int wartosc;
    public KlasaRzadkosci rzadkosc;
    public TypPrzedmiotu typ;
    public string nazwaWlasna;

    public void WypelnijPrzedmiot(float waga, int wartosc, KlasaRzadkosci rzadkosc, TypPrzedmiotu typ, string nazwaWlasna)
    {
        this.waga = waga;
        this.wartosc = wartosc;
        this.rzadkosc = rzadkosc;
        this.typ = typ;
        this.nazwaWlasna = nazwaWlasna;
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine("Przedmiot: " + nazwaWlasna);
        Console.WriteLine("Typ: " + typ);
        Console.WriteLine("Rzadkosc: " + rzadkosc);
        Console.WriteLine("Waga: " + waga);
        Console.WriteLine("Wartosc: " + wartosc);
        Console.WriteLine("-------------------------");
    }
}

class Program
{
    static Random random = new Random();

    static Przedmiot WylosujPrzedmiot(Przedmiot[] przedmioty)
    {
        int index = random.Next(przedmioty.Length);
        return przedmioty[index];
    }

    static Przedmiot WylosujPrzedmiotZRzadkoscia(Przedmiot[] przedmioty)
    {
        // Określanie sumy prawdopodobieństw dla poszczególnych klas rzadkości
        int[] prawdopodobienstwa = new int[przedmioty.Length];
        for (int i = 0; i < przedmioty.Length; i++)
        {
            prawdopodobienstwa[i] = (int)przedmioty[i].rzadkosc + 1;
        }

        // Losowanie klasy rzadkości
        int sumaPrawdopodobienstw = prawdopodobienstwa.Sum();
        int losowaLiczba = random.Next(sumaPrawdopodobienstw);

        // Wybór przedmiotu z odpowiednią klasą rzadkości
        int akumulator = 0;
        for (int i = 0; i < przedmioty.Length; i++)
        {
            akumulator += prawdopodobienstwa[i];
            if (losowaLiczba < akumulator)
            {
                return przedmioty[i];
            }
        }

        // W przypadku niepowodzenia zwróć losowy przedmiot
        return WylosujPrzedmiot(przedmioty);
    }

    static void Main()
    {
        // Przykładowa tablica przedmiotów
        Przedmiot[] przedmioty = new Przedmiot[5];

        przedmioty[0].WypelnijPrzedmiot(2.5f, 10, KlasaRzadkosci.Powszechny, TypPrzedmiotu.Bron, "Miecz");
        przedmioty[1].WypelnijPrzedmiot(5.0f, 50, KlasaRzadkosci.Rzadki, TypPrzedmiotu.Zbroja, "Pancerz");
        przedmioty[2].WypelnijPrzedmiot(0.5f, 100, KlasaRzadkosci.Epicki, TypPrzedmiotu.Pierscien, "Pierscien Mocy");
        przedmioty[3].WypelnijPrzedmiot(1.0f, 20, KlasaRzadkosci.Powszechny, TypPrzedmiotu.Amulet, "Amulet Zdrowia");
        przedmioty[4].WypelnijPrzedmiot(1.2f, 30, KlasaRzadkosci.Rzadki, TypPrzedmiotu.Helm, "Helm Oblężnika");

        // Wylosowanie i wyświetlenie losowego przedmiotu
        Console.WriteLine("Wylosowany przedmiot:");
        Przedmiot losowyPrzedmiot = WylosujPrzedmiotZRzadkoscia(przedmioty);
        losowyPrzedmiot.WyswietlInformacje();

        Console.ReadLine();
    }
}
