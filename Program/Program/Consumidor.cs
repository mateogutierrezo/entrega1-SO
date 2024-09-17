namespace Program;

public class Consumidor
{
    public void Consumir(Buffer buffer, Semaforo s, Semaforo e, Semaforo n)
    {
        while (true)
        {
            n.P();
            s.P();
            int value = buffer.Devolver();
            s.V();
            e.V();
            Thread.Sleep(1000); // Tiempo de espera para evitar saturación
        }
    }
}

