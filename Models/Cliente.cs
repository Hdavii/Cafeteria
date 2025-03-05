using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria.Models;

public partial class Cliente
{
    [Key]
    [Column("ID_Cliente")]
    public int IdCliente { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(15)]
    public string? Telefono { get; set; }

    [StringLength(100)]
    public string? Correo { get; set; }

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
