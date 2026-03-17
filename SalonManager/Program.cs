using SalonManager.Modelos;
using SalonManager.Servicios;

var clienteServicio = new ClienteServicio();
var servicioServicio = new ServicioServicio();
var citaServicio = new CitaServicio();

bool continuar = true;

//  (persistencia)
clienteServicio.CargarClientes();
citaServicio.CargarCitas();

servicioServicio.AgregarServicio(new Servicio { Nombre = "Corte", Precio = 15000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Manicure", Precio = 20000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Pedicure", Precio = 22000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Peinado", Precio = 18000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Tintura", Precio = 50000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Barba", Precio = 10000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Cejas", Precio = 8000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Masaje capilar", Precio = 25000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Alisado", Precio = 70000 });
servicioServicio.AgregarServicio(new Servicio { Nombre = "Tratamiento capilar", Precio = 40000 });

while (continuar)
{
    Console.WriteLine("\n=== SERVICIOS DISPONIBLES ===");

    var listaServicios = servicioServicio.ObtenerServicios();
    for (int i = 0; i < listaServicios.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {listaServicios[i].Nombre} - {listaServicios[i].Precio}");
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
            Console.Write("Nombre: ");
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
            var clientes = clienteServicio.ObtenerClientes();

            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados");
                break;
            }

            Console.WriteLine("\nSeleccione cliente:");
            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {clientes[i].Nombre}");
            }

            int clienteIndex = int.Parse(Console.ReadLine()) - 1;
            var clienteSeleccionado = clientes[clienteIndex].Nombre;

            Console.WriteLine("\nSeleccione servicio:");
            for (int i = 0; i < listaServicios.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {listaServicios[i].Nombre}");
            }

            int servicioIndex = int.Parse(Console.ReadLine()) - 1;
            var servicioSeleccionado = listaServicios[servicioIndex].Nombre;

            Console.Write("Fecha (YYYY-MM-DD): ");
            var fecha = DateTime.Parse(Console.ReadLine());

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
            var listaClientes = clienteServicio.ObtenerClientes();

            Console.WriteLine("\n--- CLIENTES ---");
            foreach (var c in listaClientes)
            {
                Console.WriteLine($"{c.Nombre} - {c.Telefono}");
            }
            break;

      
        case "4":
            var citas = citaServicio.ObtenerCitas();

            Console.WriteLine("\n--- CITAS ---");
            foreach (var c in citas)
            {
                Console.WriteLine($"{c.Cliente} | {c.Servicio} | {c.Fecha}");
            }
            break;

        //  UPDATE
        case "5":
            var clientesAct = clienteServicio.ObtenerClientes();

            Console.WriteLine("\nSeleccione cliente:");
            for (int i = 0; i < clientesAct.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {clientesAct[i].Nombre}");
            }

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

            Console.WriteLine("\nSeleccione cliente:");
            for (int i = 0; i < clientesDel.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {clientesDel[i].Nombre}");
            }

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
