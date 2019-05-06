using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiAgenda.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estacoes",
                columns: table => new
                {
                    estacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacoes", x => x.estacaoId);
                });

            migrationBuilder.CreateTable(
                name: "DadosEnels",
                columns: table => new
                {
                    DadosEnelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome_cliente = table.Column<string>(nullable: true),
                    endereco = table.Column<string>(nullable: true),
                    classe = table.Column<string>(nullable: true),
                    uc = table.Column<int>(nullable: false),
                    estacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosEnels", x => x.DadosEnelId);
                    table.ForeignKey(
                        name: "FK_DadosEnels_Estacoes_estacaoId",
                        column: x => x.estacaoId,
                        principalTable: "Estacoes",
                        principalColumn: "estacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operadores",
                columns: table => new
                {
                    OperadorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    estacaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operadores", x => x.OperadorId);
                    table.ForeignKey(
                        name: "FK_Operadores_Estacoes_estacaoId",
                        column: x => x.estacaoId,
                        principalTable: "Estacoes",
                        principalColumn: "estacaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supervisores",
                columns: table => new
                {
                    SupervisorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    area = table.Column<string>(nullable: true),
                    nome = table.Column<string>(maxLength: 50, nullable: true),
                    estacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisores", x => x.SupervisorId);
                    table.ForeignKey(
                        name: "FK_Supervisores_Estacoes_estacaoId",
                        column: x => x.estacaoId,
                        principalTable: "Estacoes",
                        principalColumn: "estacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    TelefoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<int>(nullable: false),
                    Fone = table.Column<string>(nullable: true),
                    OperadorId = table.Column<int>(nullable: true),
                    SupervisorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.TelefoneId);
                    table.ForeignKey(
                        name: "FK_Telefones_Operadores_OperadorId",
                        column: x => x.OperadorId,
                        principalTable: "Operadores",
                        principalColumn: "OperadorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Telefones_Supervisores_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Supervisores",
                        principalColumn: "SupervisorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosEnels_estacaoId",
                table: "DadosEnels",
                column: "estacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operadores_estacaoId",
                table: "Operadores",
                column: "estacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisores_estacaoId",
                table: "Supervisores",
                column: "estacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_OperadorId",
                table: "Telefones",
                column: "OperadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_SupervisorId",
                table: "Telefones",
                column: "SupervisorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosEnels");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Operadores");

            migrationBuilder.DropTable(
                name: "Supervisores");

            migrationBuilder.DropTable(
                name: "Estacoes");
        }
    }
}
