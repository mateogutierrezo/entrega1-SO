namespace Program;

public class Consumidor
{
    public void Consumir(Buffer buffer, Semaforo s, Semaforo e, Semaforo n)
    {
        n.P();
        s.P();
        int value = buffer.Devolver();
        Console.WriteLine("Consumido: " + value);
        s.V();
        e.V();
    }
}

