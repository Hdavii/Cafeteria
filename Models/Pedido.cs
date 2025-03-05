using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria.Models;

public partial class Pedido
{
    [Key]
    [Column("ID_Pedido")]
    public int IdPedido { get; set; }

    [Column("ID_Cliente")]
    public int? IdCliente { get; set; }

    [Column("ID_Empleado")]
    public int? IdEmpleado { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaPedido { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Total { get; set; }

    [InverseProperty("IdPedidoNavigation")]
    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    [ForeignKey("IdCliente")]
    [InverseProperty("Pedidos")]
    public virtual Cliente? IdClienteNavigation { get; set; }

    [ForeignKey("IdEmpleado")]
    [InverseProperty("Pedidos")]
    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}
