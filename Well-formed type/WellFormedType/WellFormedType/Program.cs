namespace WellFormedType
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Sprawdzenie poprawności tworzenia obiektu ---");
            Pracownik p = new Pracownik("Kowalski", new DateTime(2010, 10, 1), 1_000);
            Console.WriteLine(p);

            Console.WriteLine("--- Sprawdzenie równości obiektów ---");
            Pracownik p1 = new Pracownik("Nowak", new DateTime(2010, 10, 1), 1_000);
            Pracownik p2 = new Pracownik("Nowak", new DateTime(2010, 10, 1), 1_000);
            Pracownik p3 = new Pracownik("Kowalski", new DateTime(2010, 10, 1), 1_000);
            Pracownik p4 = p1;
            Console.WriteLine($"p1: {p1} hashCode: {p1.GetHashCode()}");
            Console.WriteLine($"p2: {p2} hashCode: {p2.GetHashCode()}");
            Console.WriteLine($"p3: {p3} hashCode: {p3.GetHashCode()}");
            Console.WriteLine($"p4: {p4} hashCode: {p4.GetHashCode()}");
            Console.WriteLine();

            Console.WriteLine($"--- Równość dla p1 oraz p2 -");
            Console.WriteLine($"Object.ReferenceEquals(p1, p2): {Object.ReferenceEquals(p1, p2)}");
            Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
            Console.WriteLine($"p1 == p2: {p1 == p2}");
            Console.WriteLine();

            Console.WriteLine($"--- Równość dla p1 oraz p3 -");
            Console.WriteLine($"Object.ReferenceEquals(p1, p3): {Object.ReferenceEquals(p1, p3)}");
            Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}");
            Console.WriteLine($"p1 == p3: {p1 == p3}");
            Console.WriteLine();

            Console.WriteLine($"--- Równość dla p1 oraz p4 -");
            Console.WriteLine($"Object.ReferenceEquals(p1, p4): {Object.ReferenceEquals(p1, p4)}");
            Console.WriteLine($"p1.Equals(p3): {p1.Equals(p4)}");
            Console.WriteLine($"p1 == p4: {p1 == p4}");

            List<Pracownik> Pracownicy = new List<Pracownik>
            {
                new Pracownik ("Sloniak", new DateTime(2010, 10, 1), 1000),
                new Pracownik ("Jungiewicz", new DateTime(2010, 10, 1), 2500),
                new Pracownik ("Paterna", new DateTime(2017, 10, 04), 10000),
                new Pracownik ("Ramirez", new DateTime(2005, 11, 17), 500),
                new Pracownik ("Niewiedzial", new DateTime(2011, 10, 11), 4000)
            };

            foreach(var pracownik in Pracownicy) Console.WriteLine(pracownik);

            Pracownicy.Sort();
            Console.WriteLine($"----");

            foreach (var pracownik in Pracownicy) Console.WriteLine(pracownik);


            Console.WriteLine('a' < 'b');

            //List<string> Pracownicy1 = new List<string>
            //{
            //    "Sloniak",
            //    "Jungiewicz",
            //    "Paterna", 
            //    "Ramirez",
            //    "Niewiedzial"
            //};

            //foreach (var pracownik in Pracownicy1) Console.WriteLine(pracownik);

            //Pracownicy1.Sort();
            //Console.WriteLine($"----");

            //foreach (var pracownik in Pracownicy1) Console.WriteLine(pracownik);
        }
    } 
}
