using SalonManager.Modelos;
using SalonManager.Servicios;

var clienteServicio = new ClienteServicio();
var servicioServicio = new ServicioServicio();
var citaServicio = new CitaServicio();

Console.WriteLine("=== Sistema de Gestion del Salon ===");

bool continuar = true;

while (continuar)
{
    Console.WriteLine("1. Registrar cliente");
    Console.WriteLine("2. Registrar servicio");
    Console.WriteLine("3. Registrar cita");
    Console.WriteLine("4. Ver clientes");
    Console.WriteLine("5. Ver citas");
    Console.WriteLine("6. Salir");

    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "6":
            continuar = false;
            break;
    }
}
