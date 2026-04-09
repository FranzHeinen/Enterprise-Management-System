namespace EmpresaEntities
{
    public class Producto
    {
        public int CodigoUnico { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public double AltoCajaCm { get; set; }
        public double AnchoCajaCm { get; set; }
        public double ProfundidadCajaCm { get; set; }
        public double PrecioUnitario { get; set; }
        public int StockMinimo { get; set; }
        public int CantidadStock { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }



    }
}
