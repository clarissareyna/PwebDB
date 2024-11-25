using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PwebDB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CategoriaPadre = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__8A3D240C40695A0F", x => x.idCategoria);
                    table.ForeignKey(
                        name: "FK__Categoria__Categ__3D5E1FD2",
                        column: x => x.CategoriaPadre,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria");
                });

            migrationBuilder.CreateTable(
                name: "CategoriumOfertum",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    IdOferta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriumOfertum", x => new { x.IdCategoria, x.IdOferta });
                });

            migrationBuilder.CreateTable(
                name: "Marca_Perfume",
                columns: table => new
                {
                    idMarcaPerfume = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Marca_Pe__1A5431A9EB381E9C", x => x.idMarcaPerfume);
                });

            migrationBuilder.CreateTable(
                name: "Metodo_Entrega",
                columns: table => new
                {
                    idMetodoEntrega = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metodo = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Metodo_E__568616F927F6EE4D", x => x.idMetodoEntrega);
                });

            migrationBuilder.CreateTable(
                name: "Metodo_Pago",
                columns: table => new
                {
                    idMetodoPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metodo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Metodo_P__817BFC3274C1E7AB", x => x.idMetodoPago);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    idOferta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: false),
                    Imagen = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Oferta__05A1245E466F9DC2", x => x.idOferta);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Perfume",
                columns: table => new
                {
                    idTipoPerfume = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tipo_Per__C5B903FDEB6FC3D0", x => x.idTipoPerfume);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    idDireccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    Calle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Colonia = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    NumeroExt = table.Column<int>(type: "int", nullable: false),
                    NumeroInt = table.Column<int>(type: "int", nullable: true),
                    Ciudad = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    Estado = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    CP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Direccio__B49878C9DC842296", x => x.idDireccion);
                    table.ForeignKey(
                        name: "FK_Direccion_AspNetUsers_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categoria_Oferta",
                columns: table => new
                {
                    idOferta = table.Column<int>(type: "int", nullable: false),
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__DD02F61E8F0D1A99", x => new { x.idOferta, x.idCategoria });
                    table.ForeignKey(
                        name: "FK__Categoria__idCat__59063A47",
                        column: x => x.idCategoria,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria");
                    table.ForeignKey(
                        name: "FK__Categoria__idOfe__5812160E",
                        column: x => x.idOferta,
                        principalTable: "Oferta",
                        principalColumn: "idOferta");
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    idMarcaPerfume = table.Column<int>(type: "int", nullable: false),
                    idCategoria = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    VolumenEnML = table.Column<int>(type: "int", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    FechaAgregado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    idTipoPerfume = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__07F4A1328E40ADD3", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK__Producto__idCate__4F7CD00D",
                        column: x => x.idCategoria,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria");
                    table.ForeignKey(
                        name: "FK__Producto__idMarc__4E88ABD4",
                        column: x => x.idMarcaPerfume,
                        principalTable: "Marca_Perfume",
                        principalColumn: "idMarcaPerfume");
                    table.ForeignKey(
                        name: "FK__Producto__idTipo__4D94879B",
                        column: x => x.idTipoPerfume,
                        principalTable: "Tipo_Perfume",
                        principalColumn: "idTipoPerfume");
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    idOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idMetodoPago = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    idDireccion = table.Column<int>(type: "int", nullable: false),
                    idMetodoEntrega = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orden__C8AAF6F3720A15DF", x => x.idOrden);
                    table.ForeignKey(
                        name: "FK_Orden_AspNetUsers_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Orden__idDirecci__619B8048",
                        column: x => x.idDireccion,
                        principalTable: "Direccion",
                        principalColumn: "idDireccion");
                    table.ForeignKey(
                        name: "FK__Orden__idMetodoE__628FA481",
                        column: x => x.idMetodoEntrega,
                        principalTable: "Metodo_Entrega",
                        principalColumn: "idMetodoEntrega");
                    table.ForeignKey(
                        name: "FK__Orden__idMetodoP__60A75C0F",
                        column: x => x.idMetodoPago,
                        principalTable: "Metodo_Pago",
                        principalColumn: "idMetodoPago");
                });

            migrationBuilder.CreateTable(
                name: "Calificacion",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false),
                    FechaCalificacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Califica__542869B5F9F060F8", x => new { x.idUsuario, x.idProducto });
                    table.ForeignKey(
                        name: "FK_Calificacion_AspNetUsers_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Calificac__idPro__5535A963",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto");
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Carrito__542869B5D445A0F4", x => new { x.idUsuario, x.idProducto });
                    table.ForeignKey(
                        name: "FK_Carrito_AspNetUsers_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Carrito__idProdu__5CD6CB2B",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto");
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Orden",
                columns: table => new
                {
                    idOrden = table.Column<int>(type: "int", nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Detalle___F8D5BCE08BDF820E", x => new { x.idOrden, x.idProducto });
                    table.ForeignKey(
                        name: "FK__Detalle_O__idOrd__656C112C",
                        column: x => x.idOrden,
                        principalTable: "Orden",
                        principalColumn: "idOrden");
                    table.ForeignKey(
                        name: "FK__Detalle_O__idPro__66603565",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_idProducto",
                table: "Calificacion",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_idProducto",
                table: "Carrito",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_CategoriaPadre",
                table: "Categoria",
                column: "CategoriaPadre");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Oferta_idCategoria",
                table: "Categoria_Oferta",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Orden_idProducto",
                table: "Detalle_Orden",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_idUsuario",
                table: "Direccion",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_idDireccion",
                table: "Orden",
                column: "idDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_idMetodoEntrega",
                table: "Orden",
                column: "idMetodoEntrega");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_idMetodoPago",
                table: "Orden",
                column: "idMetodoPago");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_idUsuario",
                table: "Orden",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_idCategoria",
                table: "Producto",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_idMarcaPerfume",
                table: "Producto",
                column: "idMarcaPerfume");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_idTipoPerfume",
                table: "Producto",
                column: "idTipoPerfume");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Calificacion");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "Categoria_Oferta");

            migrationBuilder.DropTable(
                name: "CategoriumOfertum");

            migrationBuilder.DropTable(
                name: "Detalle_Orden");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Metodo_Entrega");

            migrationBuilder.DropTable(
                name: "Metodo_Pago");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Marca_Perfume");

            migrationBuilder.DropTable(
                name: "Tipo_Perfume");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
