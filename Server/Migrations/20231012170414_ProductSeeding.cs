using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VelioApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Avatar (marketed as James Cameron's Avatar) is a 2009 epic science fiction film directed, written, co-produced, and co-edited by James Cameron and starring Sam Worthington, Zoe Saldana, Stephen Lang, Michelle Rodriguez, and Sigourney Weaver. It is the first installment in the Avatar film series. It is set in the mid-22nd century, when humans are colonizing Pandora, a lush habitable moon of a gas giant in the Alpha Centauri star system, in order to mine the valuable mineral unobtanium. The expansion of the mining colony threatens the continued existence of a local tribe of Na'vi, a humanoid species indigenous to Pandora. The title of the film refers to a genetically engineered Na'vi body operated from the brain of a remotely located human that is used to interact with the natives of Pandora.", "https://upload.wikimedia.org/wikipedia/en/d/d6/Avatar_%282009_film%29_poster.jpg", 3.99m, "Avatar (2009 film)" },
                    { 2, "Revolving around the mystery of the Jigsaw Killer, who tests his victims' will to live by putting them through deadly games where they must inflict great physical pain upon themselves to survive. The frame story follows Jigsaw's latest victims (Whannell and Elwes), who awaken in a large, dilapidated bathroom, with one being ordered to kill the other to save his own family.", "https://upload.wikimedia.org/wikipedia/en/5/56/Saw_official_poster.jpg", 6.99m, "Saw (2004 film)" },
                    { 3, "Die Hard is a 1988 American action film directed by John McTiernan and written by Jeb Stuart and Steven E. de Souza, based on the 1979 novel Nothing Lasts Forever by Roderick Thorp. It stars Bruce Willis, Alan Rickman, Alexander Godunov, and Bonnie Bedelia, with Reginald VelJohnson, William Atherton, Paul Gleason, and Hart Bochner in supporting roles. Die Hard follows New York City police detective John McClane (Willis) who is caught up in a terrorist takeover of a Los Angeles skyscraper while visiting his estranged wife.", "https://upload.wikimedia.org/wikipedia/en/c/ca/Die_Hard_%281988_film%29_poster.jpg", 9.99m, "Die Hard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
