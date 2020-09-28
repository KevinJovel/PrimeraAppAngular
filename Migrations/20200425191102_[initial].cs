using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IIDCATEGORIA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DESCRIPCION = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    BHABILITADO = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IIDCATEGORIA);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    IIDMARCA = table.Column<int>(nullable: false),
                    NOMBRE = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    BHABILITADO = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.IIDMARCA);
                });

            migrationBuilder.CreateTable(
                name: "Pagina",
                columns: table => new
                {
                    IIDPAGINA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MENSAJE = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ACCION = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    BHABILITADO = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagina", x => x.IIDPAGINA);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    IIDPERSONA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    APPATERNO = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    APMATERNO = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    TELEFONO = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CORREO = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    FECHANACIMIENTO = table.Column<DateTime>(type: "date", nullable: true),
                    BHABILITADO = table.Column<int>(nullable: true),
                    BTIENEUSUARIO = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.IIDPERSONA);
                });

            migrationBuilder.CreateTable(
                name: "Sede",
                columns: table => new
                {
                    IIDSEDE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DESCRIPCION = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    BHABILITADO = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sede", x => x.IIDSEDE);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    IIDTIPOUSUARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DESCRIPCION = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    BHABILITADO = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.IIDTIPOUSUARIO);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IIDPRODUCTO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    PRECIO = table.Column<decimal>(nullable: true),
                    IIDCATEGORIA = table.Column<int>(nullable: true),
                    BHABILITADO = table.Column<int>(nullable: true),
                    STOCK = table.Column<int>(nullable: true),
                    IIDMARCA = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IIDPRODUCTO);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria",
                        column: x => x.IIDCATEGORIA,
                        principalTable: "Categoria",
                        principalColumn: "IIDCATEGORIA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Producto__IIDMAR__3F466844",
                        column: x => x.IIDMARCA,
                        principalTable: "Marca",
                        principalColumn: "IIDMARCA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IIDRESERVA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IIDPERSONASOLICITA = table.Column<int>(nullable: true),
                    CANTIDADPERSONAS = table.Column<int>(nullable: true),
                    IIDSEDE = table.Column<int>(nullable: true),
                    FECHARESERVA = table.Column<DateTime>(type: "datetime", nullable: true),
                    TELEFONOCONTACTO = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    OBSERVACIONES = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    BHABILITADO = table.Column<int>(nullable: true),
                    total = table.Column<decimal>(nullable: true),
                    IIDPERSONAREGISTRA = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IIDRESERVA);
                    table.ForeignKey(
                        name: "FK__Reserva__IIDPERS__3C69FB99",
                        column: x => x.IIDPERSONAREGISTRA,
                        principalTable: "Persona",
                        principalColumn: "IIDPERSONA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Persona",
                        column: x => x.IIDPERSONASOLICITA,
                        principalTable: "Persona",
                        principalColumn: "IIDPERSONA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Sede",
                        column: x => x.IIDSEDE,
                        principalTable: "Sede",
                        principalColumn: "IIDSEDE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaginaTipoUsuario",
                columns: table => new
                {
                    IIDPAGINATIPOUSUARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IIDPAGINA = table.Column<int>(nullable: true),
                    IIDTIPOUSUARIO = table.Column<int>(nullable: true),
                    BHABILITADO = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaginaTipoUsuario", x => x.IIDPAGINATIPOUSUARIO);
                    table.ForeignKey(
                        name: "FK__PaginaTip__IIDPA__267ABA7A",
                        column: x => x.IIDPAGINA,
                        principalTable: "Pagina",
                        principalColumn: "IIDPAGINA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PaginaTip__IIDTI__276EDEB3",
                        column: x => x.IIDTIPOUSUARIO,
                        principalTable: "TipoUsuario",
                        principalColumn: "IIDTIPOUSUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IIDUSUARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOMBREUSUARIO = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CONTRA = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    IIDPERSONA = table.Column<int>(nullable: true),
                    BHABILITADO = table.Column<int>(nullable: true),
                    IIDTIPOUSUARIO = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IIDUSUARIO);
                    table.ForeignKey(
                        name: "FK_Usuario_Persona",
                        column: x => x.IIDPERSONA,
                        principalTable: "Persona",
                        principalColumn: "IIDPERSONA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Usuario__IIDTIPO__1CF15040",
                        column: x => x.IIDTIPOUSUARIO,
                        principalTable: "TipoUsuario",
                        principalColumn: "IIDTIPOUSUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleVentaReserva",
                columns: table => new
                {
                    IIDDETALLEVENTA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IIDRESERVA = table.Column<int>(nullable: true),
                    IIDPRODUCTO = table.Column<int>(nullable: true),
                    CANTIDAD = table.Column<int>(nullable: true),
                    PRECIO = table.Column<decimal>(nullable: true),
                    SUBTOTAL = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVentaReserva", x => x.IIDDETALLEVENTA);
                    table.ForeignKey(
                        name: "FK_DetalleVentaReserva_Producto",
                        column: x => x.IIDPRODUCTO,
                        principalTable: "Producto",
                        principalColumn: "IIDPRODUCTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DetalleVe__IIDRE__3B75D760",
                        column: x => x.IIDRESERVA,
                        principalTable: "Reserva",
                        principalColumn: "IIDRESERVA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentaReserva_IIDPRODUCTO",
                table: "DetalleVentaReserva",
                column: "IIDPRODUCTO");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentaReserva_IIDRESERVA",
                table: "DetalleVentaReserva",
                column: "IIDRESERVA");

            migrationBuilder.CreateIndex(
                name: "IX_PaginaTipoUsuario_IIDPAGINA",
                table: "PaginaTipoUsuario",
                column: "IIDPAGINA");

            migrationBuilder.CreateIndex(
                name: "IX_PaginaTipoUsuario_IIDTIPOUSUARIO",
                table: "PaginaTipoUsuario",
                column: "IIDTIPOUSUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IIDCATEGORIA",
                table: "Producto",
                column: "IIDCATEGORIA");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IIDMARCA",
                table: "Producto",
                column: "IIDMARCA");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IIDPERSONAREGISTRA",
                table: "Reserva",
                column: "IIDPERSONAREGISTRA");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IIDPERSONASOLICITA",
                table: "Reserva",
                column: "IIDPERSONASOLICITA");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IIDSEDE",
                table: "Reserva",
                column: "IIDSEDE");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IIDPERSONA",
                table: "Usuario",
                column: "IIDPERSONA");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IIDTIPOUSUARIO",
                table: "Usuario",
                column: "IIDTIPOUSUARIO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleVentaReserva");

            migrationBuilder.DropTable(
                name: "PaginaTipoUsuario");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Pagina");

            migrationBuilder.DropTable(
                name: "TipoUsuario");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Sede");
        }
    }
}
