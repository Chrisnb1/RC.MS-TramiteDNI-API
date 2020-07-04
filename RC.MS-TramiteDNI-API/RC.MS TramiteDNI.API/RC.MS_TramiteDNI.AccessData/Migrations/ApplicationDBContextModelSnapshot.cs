﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RC.MS_TramiteDNI.AccessData;

namespace RC.MS_TramiteDNI.AccessData.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RC.MS_TramiteDNI.Domain.Entities.Extranjero", b =>
                {
                    b.Property<int>("ExtranjeroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .IsUnicode(true)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PaisOrigen")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<int>("TramiteDNIid")
                        .HasColumnType("int");

                    b.HasKey("ExtranjeroId");

                    b.HasIndex("TramiteDNIid")
                        .IsUnique();

                    b.ToTable("Extranjeros");
                });

            modelBuilder.Entity("RC.MS_TramiteDNI.Domain.Entities.Nacimiento", b =>
                {
                    b.Property<int>("NacimientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .IsUnicode(true)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TramiteDNIid")
                        .HasColumnType("int");

                    b.Property<int>("TramiteRecienNacidoId")
                        .HasColumnType("int");

                    b.HasKey("NacimientoId");

                    b.HasIndex("TramiteDNIid")
                        .IsUnique();

                    b.ToTable("Nacimientos");
                });

            modelBuilder.Entity("RC.MS_TramiteDNI.Domain.Entities.NuevoEjemplar", b =>
                {
                    b.Property<int>("NuevoEjemplarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .IsUnicode(true)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<int>("TramiteDNIid")
                        .HasColumnType("int");

                    b.HasKey("NuevoEjemplarId");

                    b.HasIndex("TramiteDNIid")
                        .IsUnique();

                    b.ToTable("NuevosEjemplares");
                });

            modelBuilder.Entity("RC.MS_TramiteDNI.Domain.Entities.TramiteDNI", b =>
                {
                    b.Property<int>("TramiteDNIid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .IsUnicode(true)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("TramiteDNIid");

                    b.ToTable("TramiteDNIs");
                });

            modelBuilder.Entity("RC.MS_TramiteDNI.Domain.Entities.Extranjero", b =>
                {
                    b.HasOne("RC.MS_TramiteDNI.Domain.Entities.TramiteDNI", "TramiteDNInavigator")
                        .WithOne("ExtranjeroNavigator")
                        .HasForeignKey("RC.MS_TramiteDNI.Domain.Entities.Extranjero", "TramiteDNIid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RC.MS_TramiteDNI.Domain.Entities.Nacimiento", b =>
                {
                    b.HasOne("RC.MS_TramiteDNI.Domain.Entities.TramiteDNI", "TramiteDNInavigator")
                        .WithOne("NacimientoNavigator")
                        .HasForeignKey("RC.MS_TramiteDNI.Domain.Entities.Nacimiento", "TramiteDNIid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RC.MS_TramiteDNI.Domain.Entities.NuevoEjemplar", b =>
                {
                    b.HasOne("RC.MS_TramiteDNI.Domain.Entities.TramiteDNI", "TramiteDNInavigator")
                        .WithOne("NuevosEjemplarNavigator")
                        .HasForeignKey("RC.MS_TramiteDNI.Domain.Entities.NuevoEjemplar", "TramiteDNIid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
