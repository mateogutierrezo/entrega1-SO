namespace Program;

public class Productor
{
    public void Producir(Buffer buffer, Semaforo s, Semaforo e, Semaforo n)
    {
        while (true)
        {
            e.P();
            s.P();
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
                s.V();
                n.V();
                Thread.Sleep(1000); // Tiempo de espera para evitar saturación
            }
        }
    }
}