using EmpresaData;
using EmpresaDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.Net.Http.Headers;
using EmpresaEntities;

namespace EmpresaService
{
    public class ViajeService
    {
        public Resultado GestionarViaje(ViajeDto viajeDto)
        {
            if (!ValidarFecha(viajeDto)) { return new Resultado() { Codigo = 400, Mensaje = "Fechas del viaje mal ingresadas", Success = false }; }
            var lista = CompraFiles.LeerComprasDesdeJson().FindAll(x => x.Estado == (EnumTipoCompra)0);

            var camioneta = BuscarCamionetaDisponible(viajeDto);

            if (camioneta == null) { return new Resultado() { Codigo = 400, Mensaje = "Camionetas ocupadas en las fechas ingresadas", Success = false }; }
            var viaje = MapearViaje(viajeDto, camioneta);

            foreach (var compra in lista)
            {
                if (compra.FechaEntrega < viaje.FechaEntregaPosibleHasta && compra.FechaEntrega > viaje.FechaEntregaPosibleDesde
                    && viaje.Capacidad - CalcularVolumen(compra) > 0 && CalcularDistancia(compra) < camioneta.DistanciaMaxKm)
                {
                    viaje.CodigosCompras.Add(compra.Codigo);
                    viaje.Capacidad -= CalcularVolumen(compra);
                    compra.Estado = (EnumTipoCompra)1;
                    compra.FechaActualizacion = DateTime.Now;
                    CompraFiles.EscribirComprasAJson(compra);

                }
                else
                {
                    compra.FechaEntrega.AddDays(14);
                    compra.FechaActualizacion = DateTime.Now;
                    CompraFiles.EscribirComprasAJson(compra);
                }
            }
            ViajeFiles.EscribirViajesAJson(viaje);
            return new Resultado() { Codigo = 200, Mensaje = "Viaje creado exitosamente", Success = true };
        }
        private bool ValidarFecha(ViajeDto viajeDto)
        {
            if (viajeDto.FechaDesde < DateTime.Now)
            {
                return false;
            }
            else if (viajeDto.FechaHasta > viajeDto.FechaDesde.AddDays(7))
            {
                return false;
            }

            return true;
        }

        public Camioneta BuscarCamionetaDisponible(ViajeDto viajeDto)
        {
            var camionetasOcupadas = ViajeFiles.LeerViajesDesdeJson().Where(x => x.FechaEntregaPosibleDesde < viajeDto.FechaHasta && x.FechaEntregaPosibleHasta > viajeDto.FechaDesde) 
                .Select(x => x.PatenteCamionetaAsignada).ToList();
    
            var camioneta = CamionetaFiles.LeerCamionetasDesdeJson().FirstOrDefault(x => !camionetasOcupadas.Contains(x.Patente));

            return camioneta;
        }
        private Viaje MapearViaje(ViajeDto viajeDto, Camioneta camioneta)
        {
            Viaje viaje = new Viaje();
            viaje.PatenteCamionetaAsignada = camioneta.Patente;
            viaje.FechaEntregaPosibleDesde = viajeDto.FechaDesde;
            viaje.FechaEntregaPosibleHasta = viajeDto.FechaHasta;
            viaje.FechaCreacion = DateTime.Now;
            viaje.Capacidad = camioneta.TamañoCargaCm3;
            return viaje;
        }


        public double CalcularDistancia(Compra compra)
        {
            var coord1 = new GeoCoordinate(compra.Latitud, compra.Longitud);
            var coord2 = new GeoCoordinate(-31.25033, -61.4867);

            double distancia = coord1.GetDistanceTo(coord2) / 1000;

            return distancia;
        }
        private double CalcularVolumen(Compra compra)
        {
            var producto = ProductoFiles.LeerProductosDesdeJson().FirstOrDefault(x => x.CodigoUnico == compra.CodigoProducto);

            var volumen = producto.AltoCajaCm * producto.AnchoCajaCm * producto.ProfundidadCajaCm;

            return volumen;
        }

    }

    /*Probando! Estoy aprendiendo!*/
}
