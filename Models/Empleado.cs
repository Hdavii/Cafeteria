using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria.Models;

public partial class Empleado
{
    [Key]
    [Column("ID_Empleado")]
    public int IdEmpleado { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(50)]
    public string? Cargo { get; set; }

    [StringLength(15)]
    public string? Telefono { get; set; }

    [StringLength(100)]
    public string? Correo { get; set; }

    [InverseProperty("IdEmpleadoNavigation")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
