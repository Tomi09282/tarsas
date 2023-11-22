List<string> osvenyek = new List<string>();
List<int> dobasok;
Dictionary<char, int> dict = new Dictionary<char, int>();
using (StreamReader beosvenyek = new StreamReader("osvenyek.txt"))
{
    string sor;
    while ((sor = beosvenyek.ReadLine()) != null)
    {
        osvenyek.Add(sor.Trim());
    }
}
using (StreamReader bedobasok = new StreamReader("dobasok.txt"))
{
    string sor = bedobasok.ReadLine();
    dobasok = sor.Trim().Split().Select(int.Parse).ToList();
}


Console.WriteLine(new string('-',40));

    Console.WriteLine("2. feladat");
    Console.WriteLine($"A dobasok száma: {dobasok.Count}");
    Console.WriteLine($"Az osvenyek száma: {osvenyek.Count}");

Console.WriteLine("\n3. feladat");
int max = 0;
for (int i = 1; i < osvenyek.Count; i++)
{
    if (osvenyek[i].Length > osvenyek[max].Length)
    {
        max = i;
    }
}

    Console.WriteLine($"Az egyik leghosszabb a(z) {max + 1}. osveny, hossza: {osvenyek[max].Length}");

    Console.WriteLine("\n4. feladat");
    Console.Write("Adja meg egy osveny sorszamat! ");
    int sorszam = int.Parse(Console.ReadLine());
    Console.Write("Adja meg a jatekosok szamat! ");
    int jatekos = int.Parse(Console.ReadLine());
    string path = osvenyek[sorszam - 1];

Console.WriteLine("\n5. feladat");
foreach (char betu in path)
{
    if (!dict.ContainsKey(betu))
    {
        dict[betu] = 0;
    }
    dict[betu]++;
}

foreach (var d in dict)
{
    Console.WriteLine($"{d.Key}: {d.Value} darab");
}

Console.WriteLine("\n6. feladat");
using (StreamWriter kimenet = new StreamWriter("kulonleges.txt"))
{
    int db = 0;
    foreach (char mezo in path)
    {
        db++;
        if (mezo != 'M')
        {
            kimenet.WriteLine($"{db}\t{mezo}");
        }
    }
    Console.WriteLine("Sikeres kiiras (kulonleges.txt)");
}