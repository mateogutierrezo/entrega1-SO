namespace Program;

public class ProductorConsumidor
{
    /*
     * Lee números aleatorios y los inserta en el buffer B1 (productor puro).
     */
    public void ProductorPuro(int value, Buffer buffer, Semaforo s, Semaforo e, Semaforo n)
    {
        Random objetoRandom = new Random();
        while (true)
        {
            int numProducido = objetoRandom.next(1, 50);
        }
        e.P();
        s.P();
        buffer.Insert(value);
        Console.WriteLine("Producido: " + value);
        s.V();
        n.V();
    }
    
    /*
     * Extrae de B1, eleva al cuadrado e inserta en B1.
     */
    public void ConsumeEleva(int value, Buffer buffer, Semaforo s, Semaforo e, Semaforo n) {
        e.P();
        s.P();
        buffer.Insert(value);
        Console.WriteLine("Producido: " + value);
        s.V();
        n.V();
    }
    
    /*
     * Extrae x e y de B1, los suma y luego inserta en B2.
     */
    public void ConsumeSuma(int value, Buffer buffer, Semaforo s, Semaforo e, Semaforo n) {
        e.P();
        s.P();
        buffer.Insert(value);
        Console.WriteLine("Producido: " + value);
        s.V();
        n.V();
    }
    
    /*
     * Extrae de B2 e imprime en pantalla.
     */
    public void ConsumidorPuro(int value, Buffer buffer, Semaforo s, Semaforo e, Semaforo n) {
        e.P();
        s.P();
        buffer.Insert(value);
        Console.WriteLine("Producido: " + value);
        s.V();
        n.V();
    }
}