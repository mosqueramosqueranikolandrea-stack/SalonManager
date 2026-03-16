using SalonManager.Modelos;
using SalonManager.Servicios;

var clienteServicio = new ClienteServicio();
var servicioServicio = new ServicioServicio();
var citaServicio = new CitaServicio();

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

        case "2":
            Console.Write("Nombre del servicio: ");
            var nombreServicio = Console.ReadLine();

            Console.Write("Precio: ");
            var precio = double.Parse(Console.ReadLine());

            var servicio = new Servicio
            {
                Nombre = nombreServicio,
                Precio = precio
            };

            servicioServicio.AgregarServicio(servicio);
            Console.WriteLine("Servicio registrado!");
            break;

        case "3":
            Console.Write("Nombre del cliente: ");
            var clienteCita = Console.ReadLine();

            Console.Write("Nombre del servicio: ");
            var servicioCita = Console.ReadLine();

            Console.Write("Fecha (YYYY-MM-DD): ");
            var fechaTexto = Console.ReadLine();

            var cita = new Cita
            {
                Cliente = clienteCita,
                Servicio = servicioCita,
                Fecha = DateTime.Parse(fechaTexto)
            };

            citaServicio.AgregarCita(cita);
            Console.WriteLine("Cita registrada!");
            break;

        case "4":
            var clientes = clienteServicio.ObtenerClientes();

            Console.WriteLine("\n--- Lista de Clientes ---");
            foreach (var c in clientes)
            {
                Console.WriteLine($"Nombre: {c.Nombre} - Telefono: {c.Telefono}");
            }
            break;

        case "5":
            var citas = citaServicio.ObtenerCitas();

            Console.WriteLine("\n--- Lista de Citas ---");
            foreach (var c in citas)
            {
                Console.WriteLine($"Cliente: {c.Cliente} | Servicio: {c.Servicio} | Fecha: {c.Fecha}");
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
