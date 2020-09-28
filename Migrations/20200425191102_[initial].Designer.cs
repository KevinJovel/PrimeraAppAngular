﻿// <auto-generated />
using System;
using AngularApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AngularApp.Migrations
{
    [DbContext(typeof(BDRestauranteContext))]
    [Migration("20200425191102_[initial]")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AngularApp.Models.Categoria", b =>
                {
                    b.Property<int>("Iidcategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IIDCATEGORIA")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Bhabilitado")
                        .HasColumnName("BHABILITADO");

                    b.Property<string>("Descripcion")
                        .HasColumnName("DESCRIPCION")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .HasColumnName("NOMBRE")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Iidcategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("AngularApp.Models.DetalleVentaReserva", b =>
                {
                    b.Property<int>("Iiddetalleventa")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IIDDETALLEVENTA")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Cantidad")
                        .HasColumnName("CANTIDAD");

                    b.Property<int?>("Iidproducto")
                        .HasColumnName("IIDPRODUCTO");

                    b.Property<int?>("Iidreserva")
                        .HasColumnName("IIDRESERVA");

                    b.Property<decimal?>("Precio")
                        .HasColumnName("PRECIO");

                    b.Property<decimal?>("Subtotal")
                        .HasColumnName("SUBTOTAL");

                    b.HasKey("Iiddetalleventa");

                    b.HasIndex("Iidproducto");

                    b.HasIndex("Iidreserva");

                    b.ToTable("DetalleVentaReserva");
                });

            modelBuilder.Entity("AngularApp.Models.Marca", b =>
                {
                    b.Property<int>("Iidmarca")
                        .HasColumnName("IIDMARCA");

                    b.Property<int?>("Bhabilitado")
                        .HasColumnName("BHABILITADO");

                    b.Property<string>("Nombre")
                        .HasColumnName("NOMBRE")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.HasKey("Iidmarca");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("AngularApp.Models.Pagina", b =>
                {
                    b.Property<int>("Iidpagina")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IIDPAGINA")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Accion")
                        .HasColumnName("ACCION")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("Bhabilitado")
                        .HasColumnName("BHABILITADO");

                    b.Property<string>("Mensaje")
                        .HasColumnName("MENSAJE")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Iidpagina");

                    b.ToTable("Pagina");
                });

            modelBuilder.Entity("AngularApp.Models.PaginaTipoUsuario", b =>
                {
                    b.Property<int>("Iidpaginatipousuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IIDPAGINATIPOUSUARIO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Bhabilitado")
                        .HasColumnName("BHABILITADO");

                    b.Property<int?>("Iidpagina")
                        .HasColumnName("IIDPAGINA");

                    b.Property<int?>("Iidtipousuario")
                        .HasColumnName("IIDTIPOUSUARIO");

                    b.HasKey("Iidpaginatipousuario");

                    b.HasIndex("Iidpagina");

                    b.HasIndex("Iidtipousuario");

                    b.ToTable("PaginaTipoUsuario");
                });

            modelBuilder.Entity("AngularApp.Models.Persona", b =>
                {
                    b.Property<int>("Iidpersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IIDPERSONA")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apmaterno")
                        .HasColumnName("APMATERNO")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("Appaterno")
                        .HasColumnName("APPATERNO")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<int?>("Bhabilitado")
                        .HasColumnName("BHABILITADO");

                    b.Property<int?>("Btieneusuario")
                        .HasColumnName("BTIENEUSUARIO");

                    b.Property<string>("Correo")
                        .HasColumnName("CORREO")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Fechanacimiento")
                        .HasColumnName("FECHANACIMIENTO")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .HasColumnName("NOMBRE")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Telefono")
                        .HasColumnName("TELEFONO")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Iidpersona");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("AngularApp.Models.Producto", b =>
                {
                    b.Property<int>("Iidproducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IIDPRODUCTO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Bhabilitado")
                        .HasColumnName("BHABILITADO");

                    b.Property<int?>("Iidcategoria")
                        .HasColumnName("IIDCATEGORIA");

                    b.Property<int?>("Iidmarca")
                        .HasColumnName("IIDMARCA");

                    b.Property<string>("Nombre")
                        .HasColumnName("NOMBRE")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<decimal?>("Precio")
                        .HasColumnName("PRECIO");

                    b.Property<int?>("Stock")
                        .HasColumnName("STOCK");

                    b.HasKey("Iidproducto");

                    b.HasIndex("Iidcategoria");

                    b.HasIndex("Iidmarca");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("AngularApp.Models.Reserva", b =>
                {
                    b.Property<int>("Iidreserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IIDRESERVA")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Bhabilitado")
                        .HasColumnName("BHABILITADO");

                    b.Property<int?>("Cantidadpersonas")
                        .HasColumnName("CANTIDADPERSONAS");

                    b.Property<DateTime?>("Fechareserva")
                        .HasColumnName("FECHARESERVA")
                        .HasColumnType("datetime");

                    b.Property<int?>("Iidpersonaregistra")
                        .HasColumnName("IIDPERSONAREGISTRA");

                    b.Property<int?>("Iidpersonasolicita")
                        .HasColumnName("IIDPERSONASOLICITA");

                    b.Property<int?>("Iidsede")
                        .HasColumnName("IIDSEDE");

                    b.Property<string>("Observaciones")
                        .HasColumnName("OBSERVACIONES")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Telefonocontacto")
                        .HasColumnName("TELEFONOCONTACTO")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<decimal?>("Total")
                        .HasColumnName("total");

                    b.HasKey("Iidreserva");

                    b.HasIndex("Iidpersonaregistra");

                    b.HasIndex("Iidpersonasolicita");

                    b.HasIndex("Iidsede");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("AngularApp.Models.Sede", b =>
                {
                    b.Property<int>("Iidsede")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IIDSEDE")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Bhabilitado")
                        .HasColumnName("BHABILITADO");

                    b.Property<string>("Descripcion")
                        .HasColumnName("DESCRIPCION")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .HasColumnName("NOMBRE")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Iidsede");

                    b.ToTable("Sede");
                });

            modelBuilder.Entity("AngularApp.Models.TipoUsuario", b =>
                {
                    b.Property<int>("Iidtipousuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IIDTIPOUSUARIO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Bhabilitado")
                        .HasColumnName("BHABILITADO");

                    b.Property<string>("Descripcion")
                        .HasColumnName("DESCRIPCION")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .HasColumnName("NOMBRE")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Iidtipousuario");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("AngularApp.Models.Usuario", b =>
                {
                    b.Property<int>("Iidusuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IIDUSUARIO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Bhabilitado")
                        .HasColumnName("BHABILITADO");

                    b.Property<string>("Contra")
                        .HasColumnName("CONTRA")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("Iidpersona")
                        .HasColumnName("IIDPERSONA");

                    b.Property<int?>("Iidtipousuario")
                        .HasColumnName("IIDTIPOUSUARIO");

                    b.Property<string>("Nombreusuario")
                        .HasColumnName("NOMBREUSUARIO")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Iidusuario");

                    b.HasIndex("Iidpersona");

                    b.HasIndex("Iidtipousuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("AngularApp.Models.DetalleVentaReserva", b =>
                {
                    b.HasOne("AngularApp.Models.Producto", "IidproductoNavigation")
                        .WithMany("DetalleVentaReserva")
                        .HasForeignKey("Iidproducto")
                        .HasConstraintName("FK_DetalleVentaReserva_Producto");

                    b.HasOne("AngularApp.Models.Reserva", "IidreservaNavigation")
                        .WithMany("DetalleVentaReserva")
                        .HasForeignKey("Iidreserva")
                        .HasConstraintName("FK__DetalleVe__IIDRE__3B75D760");
                });

            modelBuilder.Entity("AngularApp.Models.PaginaTipoUsuario", b =>
                {
                    b.HasOne("AngularApp.Models.Pagina", "IidpaginaNavigation")
                        .WithMany("PaginaTipoUsuario")
                        .HasForeignKey("Iidpagina")
                        .HasConstraintName("FK__PaginaTip__IIDPA__267ABA7A");

                    b.HasOne("AngularApp.Models.TipoUsuario", "IidtipousuarioNavigation")
                        .WithMany("PaginaTipoUsuario")
                        .HasForeignKey("Iidtipousuario")
                        .HasConstraintName("FK__PaginaTip__IIDTI__276EDEB3");
                });

            modelBuilder.Entity("AngularApp.Models.Producto", b =>
                {
                    b.HasOne("AngularApp.Models.Categoria", "IidcategoriaNavigation")
                        .WithMany("Producto")
                        .HasForeignKey("Iidcategoria")
                        .HasConstraintName("FK_Producto_Categoria");

                    b.HasOne("AngularApp.Models.Marca", "IidmarcaNavigation")
                        .WithMany("Producto")
                        .HasForeignKey("Iidmarca")
                        .HasConstraintName("FK__Producto__IIDMAR__3F466844");
                });

            modelBuilder.Entity("AngularApp.Models.Reserva", b =>
                {
                    b.HasOne("AngularApp.Models.Persona", "IidpersonaregistraNavigation")
                        .WithMany("ReservaIidpersonaregistraNavigation")
                        .HasForeignKey("Iidpersonaregistra")
                        .HasConstraintName("FK__Reserva__IIDPERS__3C69FB99");

                    b.HasOne("AngularApp.Models.Persona", "IidpersonasolicitaNavigation")
                        .WithMany("ReservaIidpersonasolicitaNavigation")
                        .HasForeignKey("Iidpersonasolicita")
                        .HasConstraintName("FK_Reserva_Persona");

                    b.HasOne("AngularApp.Models.Sede", "IidsedeNavigation")
                        .WithMany("Reserva")
                        .HasForeignKey("Iidsede")
                        .HasConstraintName("FK_Reserva_Sede");
                });

            modelBuilder.Entity("AngularApp.Models.Usuario", b =>
                {
                    b.HasOne("AngularApp.Models.Persona", "IidpersonaNavigation")
                        .WithMany("Usuario")
                        .HasForeignKey("Iidpersona")
                        .HasConstraintName("FK_Usuario_Persona");

                    b.HasOne("AngularApp.Models.TipoUsuario", "IidtipousuarioNavigation")
                        .WithMany("Usuario")
                        .HasForeignKey("Iidtipousuario")
                        .HasConstraintName("FK__Usuario__IIDTIPO__1CF15040");
                });
#pragma warning restore 612, 618
        }
    }
}
