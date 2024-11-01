using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W9_assignment_template.Migrations
{
    public partial class SeedAbilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Abilities ON");

            migrationBuilder.Sql("INSERT INTO Abilities (Id, Name, Description, AbilityType, Shove) VALUES (1, 'Big Push', 'Shoves away from striking range.', 'PlayerAbility', 1)");
            migrationBuilder.Sql("INSERT INTO Abilities (Id, Name, Description, AbilityType, Taunt) VALUES (2, 'Silly Dance', 'Hops around and cackles.', 'GoblinAbility', 1)");

            migrationBuilder.Sql("SET IDENTITY_INSERT Abilities OFF");

            migrationBuilder.Sql("INSERT INTO CharacterAbilities (AbilitiesID, CharactersID) VALUES (1, 3)");
            migrationBuilder.Sql("INSERT INTO CharacterAbilities (AbilitiesID, CharactersID) VALUES (2, 1)");
            migrationBuilder.Sql("INSERT INTO CharacterAbilities (AbilitiesID, CharactersID) VALUES (2, 2)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM CharactersaAbilities WHERE AbilitiesId IN (1, 2)");

            migrationBuilder.Sql("DELETE FROM Abilities WHERE Id IN (1, 2)");
        }
    }
}
