using SalonManager.Modelos;
using SalonManager.Servicio;
using SalonManager.Servicios;

var clienteServicio = new ClienteServicio();
var servicioServicio = new ServicioServicio();
var citaServicio = new SalonManager.Servicio.CitaServicio();

bool continuar = true;

while (continuar)
{
    Console.WriteLine("\n=== SISTEMA DE GESTION DEL SALON ===");
    Console.WriteLine("1. Registrar cliente");
    Console.WriteLine("2. Registrar servicio");
    Console.WriteLine("3. Registrar cita");
    Console.WriteLine("4. Ver clientes");
    Console.WriteLine("5. Ver citas");
    Console.WriteLine("6. Salir");

    Console.Write("Seleccione una opcion: ");
    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("Nombre del cliente: ");
            var nombre = Console.ReadLine();

            Console.Write("Telefono: ");
            var telefono = Console.ReadLine();

            var cliente = new Cliente
            {
                Nombre = nombre,
                Telefono = telefono
            };

            clienteServicio.AgregarCliente(cliente);
            Console.WriteLine("Cliente registrado!");
            break;

        case "4":
            var clientes = clienteServicio.ObtenerClientes();

            Console.WriteLine("\n--- Lista de Clientes ---");
            foreach (var c in clientes)
            {
                Console.WriteLine($"Nombre: {c.Nombre} - Telefono: {c.Telefono}");
            }
            break;

        case "6":
            continuar = false;
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opcion no valida");
            break;
    }
}
