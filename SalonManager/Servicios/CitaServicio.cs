using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;
using SalonManager.Modelos;
using System;

namespace SalonManager.Servicios;

public class CitaServicio
{
    private List<Cita> citas = new List<Cita>();

    public void AgregarCita(Cita cita)
    {
        if (string.IsNullOrWhiteSpace(cita.Cliente) ||
            string.IsNullOrWhiteSpace(cita.Servicio))
        {
            Console.WriteLine("Error: Datos de la cita incompletos");
            return;
        }

        if (cita.Fecha < DateTime.Now)
        {
            Console.WriteLine("Error: No puedes agendar citas en el pasado");
            return;
        }

        citas.Add(cita);
    }

    public List<Cita> ObtenerCitas()
    {
        return citas;
    }
    public void GuardarCitas()
    {
        using var writer = new StreamWriter("citas.csv");
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

        csv.WriteRecords(citas);
    }

    public void CargarCitas()
    {
        if (!File.Exists("citas.csv"))
            return;

        using var reader = new StreamReader("citas.csv");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        citas = csv.GetRecords<Cita>().ToList();
    }
}