using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria.Models;

public partial class DetallePedido
{
    [Key]
    [Column("ID_Detalle")]
    public int IdDetalle { get; set; }

    [Column("ID_Pedido")]
    public int? IdPedido { get; set; }

    [Column("ID_Producto")]
    public int? IdProducto { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal PrecioUnitario { get; set; }

    [Column(TypeName = "decimal(21, 2)")]
    public decimal? Subtotal { get; set; }

    [ForeignKey("IdPedido")]
    [InverseProperty("DetallePedidos")]
    public virtual Pedido? IdPedidoNavigation { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("DetallePedidos")]
    public virtual Producto? IdProductoNavigation { get; set; }
}
