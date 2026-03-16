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
}


