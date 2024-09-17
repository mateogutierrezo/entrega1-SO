namespace Program;

public class Buffer
{
    public int[] array; // Array de N valores
    public int pIn; // Índice de entrada
    public int pOut; // Índice de salida
    public int cant; // Cantidad de datos insertados
    private int capacity; // Capacidad del array

    public Buffer(int capacity)
    {
        this.array = new int[capacity]; // Inicializa el array con el tamaño dado
        this.cant = 0; // Inicialmente no hay elementos insertados
        this.capacity = capacity; // Guarda la capacidad del array
        this.pIn = 0; // Inicializa el índice de entrada
        this.pOut = 0; // Inicializa el índice de salida
    }

    public void Insert(int value)
    {
        if (cant < capacity)
        {
            array[pIn] = value;
            pIn = (pIn + 1) % capacity;
            this.cant++;
        }
        else
        {
            Console.WriteLine("El buffer está lleno");
        }
    }

    public int Devolver()
    {
        if (cant > 0)
        {
            int value = array[pOut];
            pOut = (pOut + 1) % capacity;
            cant--;
            return value;
        }
        else
        {
            Console.WriteLine("Buffer vacío. No hay elementos para remover.");
            return -1;
        }
    }

    public int getCant()
    {
        return this.cant;
    }
}