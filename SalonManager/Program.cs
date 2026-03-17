using SalonManager.Modelos;
using SalonManager.Servicios;

var clienteServicio = new ClienteServicio();
var servicioServicio = new ServicioServicio();
var citaServicio = new CitaServicio();

bool continuar = true;

servicioServicio.AgregarServicio(new Servicio { Nombre = "Corte", Precio = 15000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Manicure", Precio = 20000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Peinado", Precio = 18000 });

while (continuar)
{

    Console.WriteLine("\n=== SERVICIOS DISPONIBLES ===");

    var listaServicios = servicioServicio.ObtenerServicios();
    int i = 1;

    foreach (var s in listaServicios)
    {
        Console.WriteLine($"{i}. {s.Nombre} - {s.Precio}");
        i++;
    }
    Console.WriteLine("\n=== SISTEMA DE GESTION DEL SALON ===");
    Console.WriteLine("1. Registrar cliente");
Console.WriteLine("2. Registrar cita");
Console.WriteLine("3. Ver clientes");
Console.WriteLine("4. Ver citas");
Console.WriteLine("5. Actualizar cliente");
Console.WriteLine("6. Eliminar cliente");
Console.WriteLine("7. Salir");

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

            var clientesDisponibles = clienteServicio.ObtenerClientes();

            if (clientesDisponibles.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados");
                break;
            }

            Console.WriteLine("\nSeleccione un cliente:");

            for (int k = 0; k < clientesDisponibles.Count; k++)
            {
                Console.WriteLine($"{k + 1}. {clientesDisponibles[k].Nombre}");
            }

            Console.Write("Opcion: ");
            if (!int.TryParse(Console.ReadLine(), out int opcionCliente) ||
                opcionCliente < 1 || opcionCliente > clientesDisponibles.Count)
            {
                Console.WriteLine("Opcion invalida");
                break;
            }

            var clienteSeleccionado = clientesDisponibles[opcionCliente - 1].Nombre;

            var listaServiciosCita = servicioServicio.ObtenerServicios();

            if (listaServiciosCita.Count == 0)
            {
                Console.WriteLine("No hay servicios disponibles");
                break;
            }

            Console.WriteLine("\nSeleccione un servicio:");

            for (int j = 0; j < listaServiciosCita.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {listaServiciosCita[j].Nombre} - {listaServiciosCita[j].Precio}");
            }

            Console.Write("Opcion: ");
            if (!int.TryParse(Console.ReadLine(), out int opcionServicio) ||
                opcionServicio < 1 || opcionServicio > listaServiciosCita.Count)
            {
                Console.WriteLine("Opcion invalida");
                break;
            }

            var servicioSeleccionado = listaServiciosCita[opcionServicio - 1].Nombre;

            Console.Write("Fecha (YYYY-MM-DD): ");
            var fechaTexto = Console.ReadLine();

            if (!DateTime.TryParse(fechaTexto, out DateTime fecha))
            {
                Console.WriteLine("Fecha inválida");
                break;
            }

            var cita = new Cita
            {
                Cliente = clienteSeleccionado,
                Servicio = servicioSeleccionado,
                Fecha = fecha
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

            var clientesAct = clienteServicio.ObtenerClientes();

            if (clientesAct.Count == 0)
            {
                Console.WriteLine("No hay clientes");
                break;
            }

            Console.WriteLine("\nSeleccione cliente a actualizar:");

            for (int i = 0; i < clientesAct.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {clientesAct[i].Nombre}");
            }

            Console.Write("Opcion: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Nuevo nombre: ");
            clientesAct[index].Nombre = Console.ReadLine();

            Console.Write("Nuevo telefono: ");
            clientesAct[index].Telefono = Console.ReadLine();

            clienteServicio.GuardarClientes();

            Console.WriteLine("Cliente actualizado!");
            break;

        case "6":

            var clientesDel = clienteServicio.ObtenerClientes();

            if (clientesDel.Count == 0)
            {
                Console.WriteLine("No hay clientes");
                break;
            }

            Console.WriteLine("\nSeleccione cliente a eliminar:");

            for (int i = 0; i < clientesDel.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {clientesDel[i].Nombre}");
            }

            Console.Write("Opcion: ");
            int eliminar = int.Parse(Console.ReadLine()) - 1;

            clientesDel.RemoveAt(eliminar);

            clienteServicio.GuardarClientes();

            Console.WriteLine("Cliente eliminado!");
            break;

        case "7":
            continuar = false;
            Console.WriteLine("Saliendo...");
            break;

        default:
            Console.WriteLine("Opcion no valida");
            break;
    }
}
