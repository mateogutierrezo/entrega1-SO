namespace Program
{
    class Program
    {
        public static void Main()
        {
            int capacidad = 50;
            // Crear semáforos para los buffers
            Buffer buffer1 = new Buffer(capacidad);
            Buffer buffer2 = new Buffer(capacidad);
            Semaphore s1 = new Semaphore(1, 1);
            Semaphore e1 = new Semaphore(capacidad, capacidad);
            Semaphore n1 = new Semaphore(0, capacidad);
            Semaphore s2 = new Semaphore(1, 1);
            Semaphore e2 = new Semaphore(capacidad, capacidad);
            Semaphore n2 = new Semaphore(0, capacidad);
            
          // Crear instancias de productores y consumidores
            Productor productor1 = new Productor();
            ProductorCuadratico productor2 = new ProductorCuadratico();
            Consumidor consumidor1 = new Consumidor();
            ProductorConsumidor consumidor2 = new ProductorConsumidor();

            // Crear y empezar hilos para productores y consumidores
            Thread t1 = new Thread(() => productor1.Producir(buffer1, s1, e1, n1));
            Thread t2 = new Thread(() => productor2.ElevarAlCuadrado(buffer1, s1, e1, n1));
            Thread t3 = new Thread(() => consumidor2.ConsumirProducir(buffer1, buffer2, s1, s2, e1, e2, n1, n2));
            Thread t4 = new Thread(() => consumidor1.Consumir(buffer2, s2, e2, n2));

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
        }

    
      
    }
}
