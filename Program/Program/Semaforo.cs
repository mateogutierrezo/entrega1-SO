namespace Program;

public class Semaforo
{
    private int bloqueado;
    public int Capacidad { get; private set; }

    public Semaforo(int capacidad)
    {
        this.bloqueado = 0;
        this.Capacidad = capacidad;
    }

    public void P() // Usa el servicio o queda en espera bloqueado
    {
        if (this.Capacidad == 0)
        {
            // Si no hay capacidad, esperar
            bloqueado++;
        }
        else
        {
            this.Capacidad--;
        }
    }

    public void V() // Libera espacio en el semáforo
    {
        if (this.bloqueado > 0)
        {
            // Desbloquear un proceso detenido
            bloqueado--;
        }
        else
        {
            this.Capacidad++;
        }
    }
}