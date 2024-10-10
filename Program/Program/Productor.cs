namespace Program;

public class Productor
{
    public void Producir(Buffer buffer,  Semaphore s,  Semaphore e,  Semaphore n)
    {
        while (true)
        {
            Random rnd = new Random();
            int elemento = rnd.Next(1, 30); 
            e.WaitOne();
            s.WaitOne();
            buffer.Insert(elemento);
            s.Release();
            n.Release();
            Thread.Sleep(1000); // Tiempo de espera para evitar saturación
        }
    }
}