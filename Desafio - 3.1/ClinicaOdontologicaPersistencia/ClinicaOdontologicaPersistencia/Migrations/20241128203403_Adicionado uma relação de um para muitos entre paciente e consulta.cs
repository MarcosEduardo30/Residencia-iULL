using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaOdontologicaPersistencia.Migrations
{
    /// <inheritdoc />
    public partial class Adicionadoumarelaçãodeumparamuitosentrepacienteeconsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Consultas_CPFPaciente",
                table: "Consultas",
                column: "CPFPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_CPFPaciente",
                table: "Consultas",
                column: "CPFPaciente",
                principalTable: "Pacientes",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_CPFPaciente",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_CPFPaciente",
                table: "Consultas");
        }
    }
}
