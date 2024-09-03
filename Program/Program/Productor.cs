namespace Program;

public class Productor
{
    public void Producir(int value, Buffer buffer, Semaforo s, Semaforo e, Semaforo n)
    {
        e.P();
        s.P();
        buffer.Insert(value);
        Console.WriteLine("Producido: " + value);
        s.V();
        n.V();
    }
}
