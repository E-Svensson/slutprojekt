using System;

// Om du läser detta Tim ska du veta att jag bara gjorde något kort och gott för jag hade inte tid att lägga ner på detta

class Metoder{
    public string OgiltigtInput(){
        Console.Clear();
        Console.WriteLine("\nOgiltigt input, försök igen");
        Thread.Sleep(1000);
        return "";
    }
}
class Person{
    public Person(string n, int å){
        namn = n;
        ålder = å;
    }
    private string namn;
    private int ålder;
    public string Namn{
        get{return namn;}
        set{namn = value;}
    }
        public int Ålder{
        get{return ålder;}
        set{ålder = value;}
    }
}
class Program{
    static void Main(string[] args){
        List<Person> list = new();
        bool avslut = false;
        Metoder metoder = new();
        while (!avslut){
            Console.Clear();
            Console.Write(
                "Personregister\n" + 
                "\n" + 
                "1. Se vilka som är med i registret\n" + 
                "2. Lägg till en person i registret\n" + 
                "3. Ta bort en från registret\n" + 
                "4. Avsluta\n" +
                "\n" +
                "Skriv här: "
            );
            string? input = Console.ReadLine();
            int intVal = 0;
            if (int.TryParse(input, out _))
                intVal = int.Parse(input);
            else
                metoder.OgiltigtInput();
            switch (intVal){
                case 1:
                    int x = 1;
                    Console.Clear();
                    foreach (Person p in list){
                        Console.Write($"\n{x}. " + p.Namn.ToString() + ", " + p.Ålder.ToString());
                        x++;
                    }
                    Console.Write("\n\nTryck på valfri knapp när du är klar");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.Write(
                        "Vem vill du lägga till i registret? (Namn, ålder)\n" +
                        "\n" +
                        "Skriv här: " 
                    );
                    string[] person = Console.ReadLine().Split(',');
                    if (int.TryParse(person[0], out _) == false && int.TryParse(person[1], out _) == true){
                        Person p = new Person(person[0], int.Parse(person[1])); 
                        list.Add(p);
                    } else {metoder.OgiltigtInput();}
                    break;
                case 3:
                    int y = 1;
                    Console.Clear();
                    Console.Write("Vem vill du ta bort från registret?\n");
                    foreach (Person p in list){
                        Console.Write($"\n{y}. " + p.Namn.ToString() + ", " + p.Ålder.ToString());
                        y++;
                    }
                    Console.Write("\n\nSkriv personsns nummer här: ");
                    string? input2 = Console.ReadLine();
                    int intVal2 = 0;
                    if (int.TryParse(input2, out _)){
                        intVal2 = int.Parse(input2);
                        list.Remove(list[intVal2 - 1]);
                    }
                    else
                        metoder.OgiltigtInput();
                    break;
                case 4:
                    avslut = true;
                    break;
                default:
                    break;
            }
        }
    }
}