namespace Program;

public class ProductorCuadratico
{
    private int dato;
    public void ElevarAlCuadrado(Buffer buffer,  Semaphore s,  Semaphore e,  Semaphore n)
    {
        while (true)
        {
            n.WaitOne();
            s.WaitOne();
            this.dato= buffer.Devolver();
            s.Release();
            e.Release();
            e.WaitOne();
            s.WaitOne();
            dato = dato * dato;
            buffer.Insert(dato);
            Console.WriteLine("se elevo al cuadrado");
            s.Release();
            n.Release();
            Thread.Sleep(1000); // Tiempo de espera para evitar saturation
        }
        
    }
    
}