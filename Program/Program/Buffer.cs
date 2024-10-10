namespace Program;

public class Buffer
{
    private int[] array; // Array de N valores
    private int pIn; // Índice del próximo a insertar
    private int pOut; // Índice del próximo a extraer
    private int cant; // Cantidad de datos insertados
    private int capacidad; // Capacidad del array

    public Buffer(int capacidad)
    {
        this.array = new int[capacidad]; // Inicializa el array con el tamaño dado
        this.cant = 0; // Inicialmente no hay elementos insertados
        this.capacidad = capacidad; // Guarda la capacidad del array
        this.pIn = 0; // Inicializa el índice de entrada
        this.pOut = 0; // Inicializa el índice de salida
    }

    // Precondición: el buffer no está lleno.
    public void Insert(int valor)
    {
        array[pIn] = valor;
        pIn = (pIn + 1) % capacidad;
        this.cant++;
    }

    // Precondición: el buffer no está vacío.
    public int Extraer()
    {
        int value = array[pOut];
        pOut = (pOut + 1) % capacidad;
        this.cant--;
        return value;
    }

    public int getCant()
    {
        return this.cant;
    }
}