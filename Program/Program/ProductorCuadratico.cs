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
            dato = buffer.Extraer();
            s.Release();
            e.Release();
            
            int cuadrado = dato * dato; // Produce (asíncrono)
            
            e.WaitOne();
            s.WaitOne();
            buffer.Insert(cuadrado);
            s.Release();
            n.Release();
            
            Console.WriteLine("Se elevo " + dato + " al cuadrado y se inserto " + cuadrado);
            Thread.Sleep(500); // Tiempo de espera para evitar saturation
        }
        
    }
    
}