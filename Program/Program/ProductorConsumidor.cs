namespace Program;

public class ProductorConsumidor
{
   public void ConsumirProducir(Buffer buffer1,Buffer buffer2, Semaphore s1, Semaphore s2,  Semaphore e1, Semaphore e2,  Semaphore n1, Semaphore n2)
   {
      
        while (true)
        {
            
            n1.WaitOne();
            s1.WaitOne();
            int dato1 = buffer1.Devolver();
            s1.Release();
            e1.Release();
            n1.WaitOne();
            s1.WaitOne();
            int dato2 = buffer1.Devolver();
            s1.Release();
            e1.Release();
            e2.WaitOne();
            s2.WaitOne();
            int valor = dato1+dato2;
            buffer2.Insert(valor);
            Console.WriteLine("se inserto en el buffer 2 el numero {0}",valor);
            s2.Release();
            n2.Release();
            Thread.Sleep(1000); // Tiempo de espera para evitar saturación
        }
       
    }
}