using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end.Migrations
{
    public partial class v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataBisness",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_PersonalData = table.Column<int>(nullable: false),
                    Name_KindOfPerson = table.Column<string>(type: "varchar(30)", nullable: true),
                    NameBusiness = table.Column<string>(type: "varchar(100)", nullable: false),
                    Adress = table.Column<string>(type: "varchar(200)", nullable: false),
                    Name_Municipality = table.Column<string>(type: "varchar(200)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataBisness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KindOfPerson",
                columns: table => new
                {
                    Name_KindOfPerson = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindOfPerson", x => x.Name_KindOfPerson);
                });

            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    Municipalitys = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.Municipalitys);
                });

            migrationBuilder.CreateTable(
                name: "PersonalData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Type_Document = table.Column<string>(type: "varchar(40)", nullable: true),
                    NumberDocument = table.Column<int>(nullable: false),
                    NameBusiness = table.Column<string>(type: "varchar(100)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(20)", nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(20)", nullable: true),
                    FirstLastName = table.Column<string>(type: "varchar(20)", nullable: false),
                    SecondLastName = table.Column<string>(type: "varchar(20)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    AuthorizePhone = table.Column<byte>(nullable: false),
                    AuthorizeEmail = table.Column<byte>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeDocument",
                columns: table => new
                {
                    Name_Type_Document = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDocument", x => x.Name_Type_Document);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataBisness");

            migrationBuilder.DropTable(
                name: "KindOfPerson");

            migrationBuilder.DropTable(
                name: "Municipality");

            migrationBuilder.DropTable(
                name: "PersonalData");

            migrationBuilder.DropTable(
                name: "TypeDocument");
        }
    }
}
