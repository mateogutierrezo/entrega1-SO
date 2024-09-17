namespace Program;
using System;
using System.Threading;

public class Semaforo
{
    private char nombre;
    private int capacidad; // Capacidad actual del semáforo
    private int maxCapacidad; // Capacidad máxima del semáforo
    private object lockObject = new object(); // Para sincronización manual,

    // Constructor que inicializa la capacidad del semáforo
    public Semaforo(int capacidadInicial, char unNombre)
    {
        this.nombre = unNombre;
        this.capacidad = capacidadInicial;
        this.maxCapacidad = capacidadInicial;
    }

    // Método P que consume un recurso (disminuye capacidad)
    public void P()
    {
        lock (lockObject)//  se usa en el código para garantizar que solo un hilo pueda acceder a una porción de código
                         // (sección crítica) a la vez, mientras los otros hilos deben esperar su turno.
        {
            while (capacidad == 0)
            {
                Console.WriteLine("Proceso {0}: Esperando por recurso...", Thread.CurrentThread.ManagedThreadId);
                Monitor.Wait(lockObject); // Espera hasta que haya capacidad disponible
            }
            capacidad--; // Disminuye la capacidad
            Console.WriteLine("Proceso {0}: Entró al semáforo {2}. Capacidad restante: {1}", Thread.CurrentThread.ManagedThreadId, capacidad,nombre);
        }
    }

    // Método V que libera un recurso (aumenta capacidad)
    public void V()
    {
        lock (lockObject)
        {
            if (nombre == 'n' && capacidad < 50) // este semaforo hay que diferenciarlo porque
                // arranca con capacidad 0 por ende capacidad<maxCapacidad 
                // en la primera nunca va poder entrar
            {
                capacidad++; // Aumenta la capacidad
                Console.WriteLine("Proceso {0}: Liberó recurso. Capacidad actual de {2} es: {1}",
                    Thread.CurrentThread.ManagedThreadId, capacidad, nombre);
                Monitor.Pulse(lockObject); // Despierta un hilo que esté esperando
            }

            if (nombre == 'e' || nombre == 's')
                if (capacidad < maxCapacidad)
                {
                    capacidad++; // Aumenta la capacidad
                    Console.WriteLine("Proceso {0}: Liberó recurso. Capacidad actual de {2} es: {1}", 
                    Thread.CurrentThread.ManagedThreadId, capacidad, nombre);
                    Monitor.Pulse(lockObject); // Despierta un hilo que esté esperando
                }
        }
    }
}