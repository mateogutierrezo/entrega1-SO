namespace Program;

public class ProductorConsumidor
{
   public void ConsumirProducir(Buffer buffer1,Buffer buffer2,Semaforo s1,Semaforo s2, Semaforo e1,Semaforo e2, Semaforo n1, Semaforo n2)
   {
       int aux = 0;
        while (true)
        {
            aux++;
            n1.P();
            s1.P();
            int dato1 = buffer1.Devolver();
            s1.V();
            e1.V();
            n1.P();
            s1.P();
            int dato2 = buffer1.Devolver();
            s1.V();
            e1.V();
            e2.P();
            s2.P();
            int valor = dato1+dato2;
            buffer2.Insert(valor);
            Console.WriteLine("se inserto en el buffer 2 {0}",aux);
            s2.V();
            n2.V();
            Thread.Sleep(1000); // Tiempo de espera para evitar saturación
        }
       
    }
}