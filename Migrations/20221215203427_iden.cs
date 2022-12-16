using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalOr.Migrations
{
    /// <inheritdoc />
    public partial class iden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HR");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Filiere",
                schema: "HR",
                columns: table => new
                {
                    idfilier = table.Column<int>(name: "id_filier", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomFilier = table.Column<string>(name: "nom_Filier", type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiere", x => x.idfilier);
                });

            migrationBuilder.CreateTable(
                name: "Formation",
                schema: "HR",
                columns: table => new
                {
                    idformation = table.Column<int>(name: "id_formation", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomFormationId = table.Column<string>(name: "nom_FormationId", type: "varchar(255)", nullable: true),
                    descfrmt = table.Column<string>(name: "desc_frmt", type: "nvarchar(max)", nullable: false),
                    datedebut = table.Column<DateTime>(name: "date_debut", type: "datetime2", nullable: false),
                    datefin = table.Column<DateTime>(name: "date_fin", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formation", x => x.idformation);
                });

            migrationBuilder.CreateTable(
                name: "Ville",
                schema: "HR",
                columns: table => new
                {
                    idville = table.Column<int>(name: "id_ville", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomville = table.Column<string>(name: "nom_ville", type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ville", x => x.idville);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Etablissement",
                schema: "HR",
                columns: table => new
                {
                    etabId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idformation = table.Column<int>(name: "id_formation", type: "int", nullable: true),
                    idfilier = table.Column<int>(name: "id_filier", type: "int", nullable: true),
                    idfilier0 = table.Column<int>(name: "id filier", type: "int", nullable: true),
                    niveau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idville = table.Column<int>(name: "id_ville", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etablissement", x => x.etabId);
                    table.ForeignKey(
                        name: "FK_Etablissement_Filiere_id filier",
                        column: x => x.idfilier0,
                        principalSchema: "HR",
                        principalTable: "Filiere",
                        principalColumn: "id_filier");
                    table.ForeignKey(
                        name: "FK_Etablissement_Formation_id_formation",
                        column: x => x.idformation,
                        principalSchema: "HR",
                        principalTable: "Formation",
                        principalColumn: "id_formation");
                    table.ForeignKey(
                        name: "FK_Etablissement_Ville_id_ville",
                        column: x => x.idville,
                        principalSchema: "HR",
                        principalTable: "Ville",
                        principalColumn: "id_ville");
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                schema: "HR",
                columns: table => new
                {
                    etudiantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    niveau = table.Column<string>(type: "varchar(200)", nullable: false),
                    idfilier = table.Column<int>(name: "id_filier", type: "int", nullable: true),
                    idville = table.Column<int>(name: "id_ville", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.etudiantId);
                    table.ForeignKey(
                        name: "FK_Etudiants_Filiere_id_filier",
                        column: x => x.idfilier,
                        principalSchema: "HR",
                        principalTable: "Filiere",
                        principalColumn: "id_filier");
                    table.ForeignKey(
                        name: "FK_Etudiants_Ville_id_ville",
                        column: x => x.idville,
                        principalSchema: "HR",
                        principalTable: "Ville",
                        principalColumn: "id_ville");
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
                name: "IX_Etablissement_id filier",
                schema: "HR",
                table: "Etablissement",
                column: "id filier");

            migrationBuilder.CreateIndex(
                name: "IX_Etablissement_id_formation",
                schema: "HR",
                table: "Etablissement",
                column: "id_formation");

            migrationBuilder.CreateIndex(
                name: "IX_Etablissement_id_ville",
                schema: "HR",
                table: "Etablissement",
                column: "id_ville");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_id_filier",
                schema: "HR",
                table: "Etudiants",
                column: "id_filier");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_id_ville",
                schema: "HR",
                table: "Etudiants",
                column: "id_ville");
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
                name: "Etablissement",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Etudiants",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Formation",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Filiere",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Ville",
                schema: "HR");
        }
    }
}
