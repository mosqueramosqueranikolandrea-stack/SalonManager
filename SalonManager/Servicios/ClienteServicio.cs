using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;
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
    public void GuardarClientes()
    {
        using var writer = new StreamWriter("clientes.csv");
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

        csv.WriteRecords(clientes);
    }

    public void CargarClientes()
    {
        if (!File.Exists("clientes.csv"))
            return;

        using var reader = new StreamReader("clientes.csv");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        clientes = csv.GetRecords<Cliente>().ToList();
    }
}
