
using Microsoft.EntityFrameworkCore;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Infrastructure.Data.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrera> Carrera { get; set; }

    public virtual DbSet<Clase> Clase { get; set; }

    public virtual DbSet<Comentario> Comentario { get; set; }

    public virtual DbSet<Grupo> Grupo { get; set; }

    public virtual DbSet<HistorialDeMovimiento> HistorialDeMovimiento { get; set; }

    public virtual DbSet<Persona> Persona { get; set; }

    public virtual DbSet<Proyecto> Proyecto { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Tareas> Tareas { get; set; }

    public virtual DbSet<UserRol> UserRol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=kanban;Username=postgres;Password=admin;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("carrera_pkey");

            entity.ToTable("carrera");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clase_pkey");

            entity.ToTable("clase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clase1)
                .HasMaxLength(50)
                .HasColumnName("clase");
            entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Clase)
                .HasForeignKey(d => d.IdCarrera)
                .HasConstraintName("clase_id_carrera_fkey");
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comentario_pkey");

            entity.ToTable("comentario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contenido).HasColumnName("contenido");
            entity.Property(e => e.Fecha)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.IdTarea).HasColumnName("id_tarea");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdTareaNavigation).WithMany(p => p.Comentario)
                .HasForeignKey(d => d.IdTarea)
                .HasConstraintName("comentario_id_tarea_fkey");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentario)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("comentario_id_usuario_fkey");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("grupo_pkey");

            entity.ToTable("grupo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdClase).HasColumnName("id_clase");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdClaseNavigation).WithMany(p => p.Grupo)
                .HasForeignKey(d => d.IdClase)
                .HasConstraintName("grupo_id_clase_fkey");
        });

        modelBuilder.Entity<HistorialDeMovimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("historial_de_movimiento_pkey");

            entity.ToTable("historial_de_movimiento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaMovimiento)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_movimiento");
            entity.Property(e => e.IdColumnaDestino).HasColumnName("id_columna_destino");
            entity.Property(e => e.IdColumnaOrigen).HasColumnName("id_columna_origen");
            entity.Property(e => e.IdTarea).HasColumnName("id_tarea");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdTareaNavigation).WithMany(p => p.HistorialDeMovimiento)
                .HasForeignKey(d => d.IdTarea)
                .HasConstraintName("historial_de_movimiento_id_tarea_fkey");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HistorialDeMovimiento)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("historial_de_movimiento_id_usuario_fkey");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("persona_pkey");

            entity.ToTable("persona");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.CorreoPersonal)
                .HasMaxLength(100)
                .HasColumnName("correo_personal");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("dni");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .HasColumnName("genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("proyecto_pkey");

            entity.ToTable("proyecto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdLider).HasColumnName("id_lider");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdLiderNavigation).WithMany(p => p.Proyecto)
                .HasForeignKey(d => d.IdLider)
                .HasConstraintName("proyecto_id_lider_fkey");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rol_pkey");

            entity.ToTable("rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estatus).HasColumnName("estatus");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Tareas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tareas_pkey");

            entity.ToTable("tareas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaEntrega).HasColumnName("fecha_entrega");
            entity.Property(e => e.IdAsignado).HasColumnName("id_asignado");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
            entity.Property(e => e.Prioridad)
                .HasMaxLength(20)
                .HasColumnName("prioridad");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdAsignadoNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdAsignado)
                .HasConstraintName("tareas_id_asignado_fkey");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("tareas_id_proyecto_fkey");
        });

        modelBuilder.Entity<UserRol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_rol_pkey");

            entity.ToTable("user_rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaAsignacion).HasColumnName("fecha_asignacion");
            entity.Property(e => e.IdGrupo).HasColumnName("id_grupo");
            entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.UserRol)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("user_rol_id_grupo_fkey");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.UserRol)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("user_rol_id_proyecto_fkey");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UserRol)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("user_rol_id_rol_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserRol)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("user_rol_id_user_fkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_pkey");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Username, "usuario_username_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .HasColumnName("contraseña");
            entity.Property(e => e.CorreoInstitucional)
                .HasMaxLength(100)
                .HasColumnName("correo_institucional");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.UltimoIngreso)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ultimo_ingreso");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("usuario_id_persona_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
