using SalonManager.Modelos;
using SalonManager.Servicios;

var clienteServicio = new ClienteServicio();
var servicioServicio = new ServicioServicio();
var citaServicio = new CitaServicio();

bool continuar = true;

// SERVICIOS FIJOS
servicioServicio.AgregarServicio(new Servicio { Nombre = "Corte", Precio = 15000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Manicure", Precio = 20000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Pedicure", Precio = 22000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Peinado", Precio = 18000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Tinte", Precio = 50000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Depilacion", Precio = 25000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Masaje Capilar", Precio = 30000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Tratamiento Facial", Precio = 40000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Alisado", Precio = 80000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Cejas y Pestañas", Precio = 15000 });

clienteServicio.CargarClientes();
citaServicio.CargarCitas();

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
            clienteServicio.GuardarClientes();

            Console.WriteLine("Cliente registrado!");
            break;

        case "2":

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

            Console.WriteLine("\nSeleccione un servicio:");

            for (int j = 0; j < listaServicios.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {listaServicios[j].Nombre} - {listaServicios[j].Precio}");
            }

            Console.Write("Opcion: ");
            if (!int.TryParse(Console.ReadLine(), out int opcionServicio) ||
                opcionServicio < 1 || opcionServicio > listaServicios.Count)
            {
                Console.WriteLine("Opcion invalida");
                break;
            }

            var servicioSeleccionado = listaServicios[opcionServicio - 1].Nombre;

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
            citaServicio.GuardarCitas();

            Console.WriteLine("Cita registrada!");
            break;

        case "3":
            var clientes = clienteServicio.ObtenerClientes();

            Console.WriteLine("\n--- Lista de Clientes ---");
            foreach (var c in clientes)
            {
                Console.WriteLine($"Nombre: {c.Nombre} - Telefono: {c.Telefono}");
            }
            break;

        case "4":
            var citas = citaServicio.ObtenerCitas();

            Console.WriteLine("\n--- Lista de Citas ---");
            foreach (var c in citas)
            {
                Console.WriteLine($"Cliente: {c.Cliente} | Servicio: {c.Servicio} | Fecha: {c.Fecha}");
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

            for (int idx = 0; idx < clientesAct.Count; idx++)
            {
                Console.WriteLine($"{idx + 1}. {clientesAct[idx].Nombre}");
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

            for (int idx = 0; idx < clientesDel.Count; idx++)
            {
                Console.WriteLine($"{idx + 1}. {clientesDel[idx].Nombre}");
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
    }
}
