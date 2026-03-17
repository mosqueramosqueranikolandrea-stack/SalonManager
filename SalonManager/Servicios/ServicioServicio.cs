using SalonManager.Modelos;

namespace SalonManager.Servicio;

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
    private List<Servicio> servicios = new List<Servicio>();

    public void AgregarServicio(Servicio servicio)
    {
        if (string.IsNullOrWhiteSpace(servicio.Nombre) || servicio.Precio <= 0)
        {
            Console.WriteLine("Error: Datos del servicio inválidos");
            return;
        }

        servicios.Add(servicio);
    }
