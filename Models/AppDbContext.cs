using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; database =CafeteriaDB; Data Source=.;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__02AA078592F40109");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__E005FBFFB0FD5D39");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DetalleP__B3E0CED3EBC5636F");

            entity.Property(e => e.Subtotal).HasComputedColumnSql("([Cantidad]*[PrecioUnitario])", true);

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidos).HasConstraintName("FK__DetallePe__ID_Pe__31EC6D26");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallePedidos).HasConstraintName("FK__DetallePe__ID_Pr__32E0915F");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__B7872C908EF5A6D9");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedidos__FD768070F1BFC8B6");

            entity.Property(e => e.FechaPedido).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos).HasConstraintName("FK__Pedidos__ID_Clie__2E1BDC42");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Pedidos).HasConstraintName("FK__Pedidos__ID_Empl__2F10007B");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__9B4120E24CBE496C");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos).HasConstraintName("FK__Productos__ID_Ca__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
