using SalonManager.Modelos;
using System;
using System.Collections.Generic;

namespace SalonManager.Servicios
{
    public class ServicioServicio
    {
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

        public List<Servicio> ObtenerServicios()
        {
            return servicios;
        }
    }
}