using SalonManager.Modelos;

namespace SalonManager.Servicios;

public class CitaServicio
{
    private List<Cita> citas = new List<Cita>();

    public void AgregarCita(Cita cita)
    {
        citas.Add(cita);
    }

    public List<Cita> ObtenerCitas()
    {
        return citas;
    }
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
}


