using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupportTickets.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Roles
            var editRoleId = Guid.NewGuid().ToString();
            var viewRoldId = Guid.NewGuid().ToString();
            var restrictedRoleId = Guid.NewGuid().ToString();

            //Users
            var adminUserId = Guid.NewGuid().ToString();
            var basicUserId = Guid.NewGuid().ToString();
            var viewerUserId = Guid.NewGuid().ToString();

            //Inserting into DB's
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[,]
                {
                    { editRoleId,"Edit", "EDIT", Guid.NewGuid().ToString() },
                    { viewRoldId,"View", "VIEW", Guid.NewGuid().ToString() },
                    { restrictedRoleId,"Restricted", "RESTRICTED", Guid.NewGuid().ToString() }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "FirstName", "LastName", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount" },
                values: new object[,]
                {
                    { adminUserId,"George", "Share", "georgeshare2@gmail.com","GEORGESHARE2@GMAIL.COM", "georgeshare2@gmail.com","GEORGESHARE2@GMAIL.COM", true, "AQAAAAEAACcQAAAAEP42sdIvQNReUrwp5OdJxxLJ72p5GfmNTYwShRLVLN7A23MMIrNLge9dUAiwcdcttQ==", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "07777777777", true, true, null,true, 0},
                    { basicUserId,"Sam", "Test", "samtest@gmail.com","SAMTEST@GMAIL.COM", "samtest@gmail.com","SAMTEST@GMAIL.COM", true, "AQAAAAEAACcQAAAAEP42sdIvQNReUrwp5OdJxxLJ72p5GfmNTYwShRLVLN7A23MMIrNLge9dUAiwcdcttQ==", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "07777777777", true, true, null, true, 0 },
                    { viewerUserId, "Tom", "Test", "tomtest@gmail.com","TOMTEST@GMAIL.COM", "tomtest@gmail.com","TOMTEST@GMAIL.COM", true, "AQAAAAEAACcQAAAAEP42sdIvQNReUrwp5OdJxxLJ72p5GfmNTYwShRLVLN7A23MMIrNLge9dUAiwcdcttQ==", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "07777777777", true, true, null, true, 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    {adminUserId, editRoleId},
                    {basicUserId, viewRoldId},
                    {viewerUserId,restrictedRoleId}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
