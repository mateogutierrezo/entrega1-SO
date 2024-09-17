namespace Program;

public class ProductorCuadratico
{
    private int dato;
    public void ElevarAlCuadrado(Buffer buffer, Semaforo s, Semaforo e, Semaforo n)
    {
        while (true)
        {
            n.P();
            s.P();
            this.dato= buffer.Devolver();
            s.V();
            e.V();
            e.P();
            s.P();
            dato = dato * dato;
            buffer.Insert(dato);
            Console.WriteLine("se elevo al cuadrado");
            s.V();
            n.V();
            Thread.Sleep(1000); // Tiempo de espera para evitar saturation
        }
        
    }
    
}