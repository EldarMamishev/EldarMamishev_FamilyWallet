using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OperationCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OperationInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Balance = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FamilyID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Wallet_Family_FamilyID",
                        column: x => x.FamilyID,
                        principalTable: "Family",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonFamily",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonID = table.Column<int>(nullable: false),
                    FamilyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonFamily", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonFamily_Family_FamilyID",
                        column: x => x.FamilyID,
                        principalTable: "Family",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonFamily_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonWallet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonID = table.Column<int>(nullable: false),
                    WalletID = table.Column<int>(nullable: false),
                    AccessModifier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonWallet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonWallet_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonWallet_Wallet_WalletID",
                        column: x => x.WalletID,
                        principalTable: "Wallet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonWalletID = table.Column<int>(nullable: false),
                    OperationCategoryID = table.Column<int>(nullable: false),
                    OperationInfoID = table.Column<int>(nullable: false),
                    TransactionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Operation_OperationCategory_OperationCategoryID",
                        column: x => x.OperationCategoryID,
                        principalTable: "OperationCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_OperationInfo_OperationInfoID",
                        column: x => x.OperationInfoID,
                        principalTable: "OperationInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_PersonWallet_PersonWalletID",
                        column: x => x.PersonWalletID,
                        principalTable: "PersonWallet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_Transaction_TransactionID",
                        column: x => x.TransactionID,
                        principalTable: "Transaction",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operation_OperationCategoryID",
                table: "Operation",
                column: "OperationCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_OperationInfoID",
                table: "Operation",
                column: "OperationInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_PersonWalletID",
                table: "Operation",
                column: "PersonWalletID");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_TransactionID",
                table: "Operation",
                column: "TransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFamily_FamilyID",
                table: "PersonFamily",
                column: "FamilyID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFamily_PersonID",
                table: "PersonFamily",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWallet_PersonID",
                table: "PersonWallet",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWallet_WalletID",
                table: "PersonWallet",
                column: "WalletID");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_FamilyID",
                table: "Wallet",
                column: "FamilyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "PersonFamily");

            migrationBuilder.DropTable(
                name: "OperationCategory");

            migrationBuilder.DropTable(
                name: "OperationInfo");

            migrationBuilder.DropTable(
                name: "PersonWallet");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Family");
        }
    }
}
