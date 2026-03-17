using SalonManager.Modelos;

namespace SalonManager.Servicios;

public class ClienteServicio
{
    private List<Cliente> clientes = new List<Cliente>();

    public void AgregarCliente(Cliente cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nombre) || string.IsNullOrWhiteSpace(cliente.Telefono))
        {
            Console.WriteLine("Error: Datos del cliente incompletos");
            return;
        }

        clientes.Add(cliente);
    }

    public List<Cliente> ObtenerClientes()
    {
        return clientes;
    }
}
