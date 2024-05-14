using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TargetCustomer___MVC.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tabela_Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome_Usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CNPJ = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Razao_Social = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Ramo_De_Atuacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Logradouro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Numero_Logradouro = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Usuario_Ativo = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabela_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tabela_Consultorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Nome_Do_Representante = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao_Consultoria = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Consultoria_Ativa = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabela_Consultorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tabela_Consultorias_Tabela_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Tabela_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tabela_AvaliacaoConsultoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TextoAvaliacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ConsultoriaID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabela_AvaliacaoConsultoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tabela_AvaliacaoConsultoria_Tabela_Consultorias_ConsultoriaID",
                        column: x => x.ConsultoriaID,
                        principalTable: "Tabela_Consultorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tabela_AvaliacaoConsultoria_Tabela_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Tabela_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tabela_AvaliacaoConsultoria_ConsultoriaID",
                table: "Tabela_AvaliacaoConsultoria",
                column: "ConsultoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Tabela_AvaliacaoConsultoria_IdUsuario",
                table: "Tabela_AvaliacaoConsultoria",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tabela_Consultorias_IdUsuario",
                table: "Tabela_Consultorias",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tabela_AvaliacaoConsultoria");

            migrationBuilder.DropTable(
                name: "Tabela_Consultorias");

            migrationBuilder.DropTable(
                name: "Tabela_Usuarios");
        }
    }
}
