using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TendenciasControl.Models
{
    [Table("Pedidoes")]
    public class Pedido
    {
        public int ID { get; set; }
        public string NombreCliente { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Foto { get; set; }
        public string DescripcionPedido { get; set; }
        public double Precio { get; set; }
        public string Domicilio { get; set; }
    }
}