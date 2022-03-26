using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NominaCheck.Data.Models;

namespace NominaCheck.Database
{
    public partial class NominaPropietariaContext : DbContext
    {
        public NominaPropietariaContext()
        {
        }

        public NominaPropietariaContext(DbContextOptions<NominaPropietariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargo> Cargos { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<FacturaProveedore> FacturaProveedores { get; set; } = null!;
        public virtual DbSet<IngresosOtrosconcepto> IngresosOtrosconceptos { get; set; } = null!;
        public virtual DbSet<IngresosServicio> IngresosServicios { get; set; } = null!;
        public virtual DbSet<Nomina> Nominas { get; set; } = null!;
        public virtual DbSet<OtrosConcepto> OtrosConceptos { get; set; } = null!;
        public virtual DbSet<PagoEmpleado> PagoEmpleados { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<TiposEmpleado> TiposEmpleados { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Settings.GetConnectionStringMssql());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.CodCargo);

                entity.ToTable("cargos");

                entity.Property(e => e.CodCargo)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_cargo");

                entity.Property(e => e.CodDepartamento).HasColumnName("cod_departamento");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.HasOne(d => d.CodDepartamentoNavigation)
                    .WithMany(p => p.Cargos)
                    .HasForeignKey(d => d.CodDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_departamento");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.CodDepartamento);

                entity.ToTable("departamentos");

                entity.Property(e => e.CodDepartamento)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_departamento");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.CodEmpleados);

                entity.ToTable("empleados");

                entity.Property(e => e.CodEmpleados)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_empleados");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("apellido")
                    .IsFixedLength();

                entity.Property(e => e.CodCargo).HasColumnName("cod_cargo");

                entity.Property(e => e.CodNomina).HasColumnName("cod_nomina");

                entity.Property(e => e.CodTipoEmpleado).HasColumnName("cod_tipo_empleado");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre")
                    .IsFixedLength();

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.HasOne(d => d.CodCargoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.CodCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cargo");

                entity.HasOne(d => d.CodNominaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.CodNomina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_nomina");

                entity.HasOne(d => d.CodTipoEmpleadoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.CodTipoEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipo_empleado");
            });

            modelBuilder.Entity<FacturaProveedore>(entity =>
            {
                entity.HasKey(e => e.CodFactura)
                    .HasName("PK__factura___94EEA4104D4BD779");

                entity.ToTable("factura_proveedores");

                entity.Property(e => e.CodFactura)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_factura");

                entity.Property(e => e.CodProveedor).HasColumnName("cod_proveedor");

                entity.Property(e => e.Descrpcion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("descrpcion")
                    .IsFixedLength();

                entity.Property(e => e.ValorMensual)
                    .HasColumnType("money")
                    .HasColumnName("valor_mensual");

                entity.HasOne(d => d.CodProveedorNavigation)
                    .WithMany(p => p.FacturaProveedores)
                    .HasForeignKey(d => d.CodProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__factura_p__cod_p__31EC6D26");
            });

            modelBuilder.Entity<IngresosOtrosconcepto>(entity =>
            {
                entity.HasKey(e => e.CodOtrosconceptos)
                    .HasName("PK__ingresos__678CA83EF4FB4D7E");

                entity.ToTable("ingresos_otrosconceptos");

                entity.Property(e => e.CodOtrosconceptos)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_otrosconceptos");

                entity.Property(e => e.CodConcepto).HasColumnName("cod_concepto");

                entity.Property(e => e.Valor)
                    .HasColumnType("money")
                    .HasColumnName("valor");

                entity.HasOne(d => d.CodConceptoNavigation)
                    .WithMany(p => p.IngresosOtrosconceptos)
                    .HasForeignKey(d => d.CodConcepto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ingresos___cod_c__32E0915F");
            });

            modelBuilder.Entity<IngresosServicio>(entity =>
            {
                entity.HasKey(e => e.CodIngreso)
                    .HasName("PK__ingresos__29CEDD366C683BEE");

                entity.ToTable("ingresos_servicios");

                entity.Property(e => e.CodIngreso)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_ingreso");

                entity.Property(e => e.CodServicio).HasColumnName("cod_servicio");

                entity.Property(e => e.TipoServicio)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("tipo_servicio")
                    .IsFixedLength();

                entity.Property(e => e.Valor)
                    .HasColumnType("money")
                    .HasColumnName("valor");

                entity.HasOne(d => d.CodServicioNavigation)
                    .WithMany(p => p.IngresosServicios)
                    .HasForeignKey(d => d.CodServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ingresos___cod_s__33D4B598");
            });

            modelBuilder.Entity<Nomina>(entity =>
            {
                entity.HasKey(e => e.CodNomina);

                entity.ToTable("nomina");

                entity.Property(e => e.CodNomina)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_nomina");

                entity.Property(e => e.CodEmpleado).HasColumnName("cod_empleado");

                entity.Property(e => e.FechaPago)
                    .HasColumnType("date")
                    .HasColumnName("fecha_pago");

                entity.Property(e => e.Monto)
                    .HasColumnType("money")
                    .HasColumnName("monto");

                entity.HasOne(d => d.CodEmpleadoNavigation)
                    .WithMany(p => p.Nominas)
                    .HasForeignKey(d => d.CodEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empleado");
            });

            modelBuilder.Entity<OtrosConcepto>(entity =>
            {
                entity.HasKey(e => e.CodConcepto)
                    .HasName("PK__otros_co__99DD44B0B80C5407");

                entity.ToTable("otros_conceptos");

                entity.Property(e => e.CodConcepto)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_concepto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("descripcion")
                    .IsFixedLength();
            });

            modelBuilder.Entity<PagoEmpleado>(entity =>
            {
                entity.HasKey(e => e.CodPago)
                    .HasName("PK__pago_emp__CB1571380DE4E134");

                entity.ToTable("pago_empleados");

                entity.Property(e => e.CodPago)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_pago");

                entity.Property(e => e.CodEmpleados).HasColumnName("cod_empleados");

                entity.Property(e => e.ValorMensual)
                    .HasColumnType("money")
                    .HasColumnName("valor_mensual");

                entity.HasOne(d => d.CodEmpleadosNavigation)
                    .WithMany(p => p.PagoEmpleados)
                    .HasForeignKey(d => d.CodEmpleados)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pago_empl__cod_e__34C8D9D1");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => e.CodProveedor)
                    .HasName("PK__proveedo__D4A662EBB92D8BB0");

                entity.ToTable("proveedores");

                entity.Property(e => e.CodProveedor)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_proveedor");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre")
                    .IsFixedLength();

                entity.Property(e => e.Telefono).HasColumnName("telefono");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.CodServicio)
                    .HasName("PK__servicio__9BF23A49D3DD9B0C");

                entity.ToTable("servicios");

                entity.Property(e => e.CodServicio)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_servicio");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("descripcion")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TiposEmpleado>(entity =>
            {
                entity.HasKey(e => e.CodTipoEmpleado);

                entity.ToTable("tipos_empleado");

                entity.Property(e => e.CodTipoEmpleado)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_tipo_empleado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
