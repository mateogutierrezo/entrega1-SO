using System;
namespace Program;
class Program
{
    static void Main()
    {
        int bufferCapacity = 2;
        Buffer buffer = new Buffer(bufferCapacity);

        Semaforo s = new Semaforo(1);
        Semaforo e = new Semaforo(bufferCapacity);
        Semaforo n = new Semaforo(0);

        Productor productor = new Productor();
        Consumidor consumidor = new Consumidor();

        consumidor.Consumir(buffer, s, e, n);
        consumidor.Consumir(buffer, s, e, n);
        
        productor.Producir(42, buffer, s, e, n);
        productor.Producir(84, buffer, s, e, n);       
    }
}

