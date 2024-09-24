namespace Program;

public class Productor
{
    public void Producir(Buffer buffer,  Semaphore s,  Semaphore e,  Semaphore n)
    {
        while (true)
        {
            e.WaitOne();
            s.WaitOne();
            try
            {
                // Pide al usuario que introduzca un valor
                Console.Write("Introduce un valor: ");
                string numeroString = Console.ReadLine();
                int numero = int.Parse(numeroString);

                // Inserta el valor en el buffer
                buffer.Insert(numero);
            }
            finally
            {
                s.Release();
                n.Release();
                Thread.Sleep(1000); // Tiempo de espera para evitar saturación
            }
        }
    }
}