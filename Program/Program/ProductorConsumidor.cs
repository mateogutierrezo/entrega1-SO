namespace Program;

public class ProductorConsumidor
{
   public void ConsumirProducir(Buffer buffer1, Buffer buffer2, Semaphore s1, Semaphore s2,  Semaphore e1, Semaphore e2,  Semaphore n1, Semaphore n2)
   {
      
        while (true)
        {
            n1.WaitOne();
            s1.WaitOne();
            int dato1 = buffer1.Extraer();
            s1.Release();
            e1.Release();
            n1.WaitOne();
            s1.WaitOne();
            int dato2 = buffer1.Extraer();
            s1.Release();
            e1.Release();
            
            int elemento = dato1+dato2; // Produce (asíncrono)
            
            e2.WaitOne();
            s2.WaitOne();
            buffer2.Insert(elemento);
            s2.Release();
            n2.Release();
            
            //Console.WriteLine("Se inserto en el buffer 2 el numero " + dato1 + " + " + dato2 + " = " + elemento);
            Thread.Sleep(500); // Tiempo de espera para evitar saturación
        }
   }
}