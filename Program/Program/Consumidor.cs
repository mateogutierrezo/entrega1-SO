namespace Program;

public class Consumidor
{
    public void Consumir(Buffer buffer,  Semaphore s,  Semaphore e,  Semaphore n)
    {
        while (true)
        {
            n.WaitOne();
            s.WaitOne();
            int elemento = buffer.Extraer();
            s.Release();
            e.Release();
            
            Console.WriteLine("Se extrajo " + elemento);
            Thread.Sleep(500); // Tiempo de espera para evitar saturación
        }
    }
}

