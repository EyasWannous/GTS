using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace GTS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeoTimeSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoTimeSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<long>(type: "bigint", rowVersion: true, nullable: false),
                    Point = table.Column<Point>(type: "geography", nullable: false),
                    Elevation = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeoTimeSeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataPoints_GeoTimeSeries_GeoTimeSeriesId",
                        column: x => x.GeoTimeSeriesId,
                        principalTable: "GeoTimeSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataPoints_GeoTimeSeriesId",
                table: "DataPoints",
                column: "GeoTimeSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPoints_TimeStamp",
                table: "DataPoints",
                column: "TimeStamp");

            migrationBuilder.CreateIndex(
                name: "IX_GeoTimeSeries_ClassName",
                table: "GeoTimeSeries",
                column: "ClassName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataPoints");

            migrationBuilder.DropTable(
                name: "GeoTimeSeries");
        }
    }
}
