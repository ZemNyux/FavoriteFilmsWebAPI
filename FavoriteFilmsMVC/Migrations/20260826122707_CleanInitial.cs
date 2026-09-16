using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FavoriteFilmsMVC.Migrations
{
    /// <inheritdoc />
    public partial class CleanInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    PosterUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Genre", "PosterUrl", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Наше время на Земле подошло к концу, команда исследователей берется за самую важную миссию в истории человечества.", "Кристофер Нолан", "Фантастика", "https://upload.wikimedia.org/wikipedia/ru/c/c3/Interstellar_film_poster.jpg", 2014, "Интерстеллар" },
                    { 2, "Бэтмен поднимает ставки в войне с криминалом с помощью лейтенанта Джима Гордона и прокурора Харви Дента.", "Кристофер Нолан", "Боевик", "https://upload.wikimedia.org/wikipedia/ru/1/15/Dark_knight_poster.jpg", 2008, "Темный рыцарь" },
                    { 3, "Вор, крадущий корпоративные секреты через использование технологии обмена снами.", "Кристофер Нолан", "Фантастика", "https://upload.wikimedia.org/wikipedia/ru/c/bc/Inception_poster.jpg", 2010, "Начало" },
                    { 4, "Компьютерный хакер узнает от таинственных повстанцев об истинной природе его реальности.", "Лана и Лилли Вачовски", "Фантастика", "https://upload.wikimedia.org/wikipedia/ru/9/9d/Matrix-dvd.jpg", 1999, "Матрица" },
                    { 5, "Офисный работник, страдающий бессонницей, и харизматичный мыловар создают подпольный бойцовский клуб.", "Дэвид Финчер", "Драма", "https://upload.wikimedia.org/wikipedia/ru/8/8b/Fight_Club_poster.jpg", 1999, "Бойцовский клуб" },
                    { 6, "Истории двух бандитов, жены их босса и боксера переплетаются в серии философских и комичных событий.", "Квентин Тарантино", "Криминал", "https://upload.wikimedia.org/wikipedia/ru/9/93/Pulp_Fiction_cover.jpg", 1994, "Криминальное чтиво" },
                    { 7, "История надзирателей в блоке смертников, один из которых обладает чудесным даром исцеления.", "Фрэнк Дарабонт", "Драма", "https://upload.wikimedia.org/wikipedia/ru/c/c5/Green_mile_poster.jpg", 1999, "Зеленая миля" },
                    { 8, "Успешный банкир осужден за убийство и отправлен в тюрьму Шоушенк.", "Фрэнк Дарабонт", "Драма", "https://upload.wikimedia.org/wikipedia/ru/d/de/ShawshankRedemptionMoviePoster.jpg", 1994, "Побег из Шоушенка" },
                    { 9, "Два судебных пристава отправляются на остров в психиатрическую больницу для расследования исчезновения пациентки.", "Мартин Скорсезе", "Детектив", "https://upload.wikimedia.org/wikipedia/ru/a/a2/Shutter-island-poster.jpg", 2010, "Остров проклятых" },
                    { 10, "Наследник знаменитого дома Атрейдесов отправляется на самую опасную планету во Вселенной — Арракис.", "Дени Вильнёв", "Фантастика", "https://upload.wikimedia.org/wikipedia/ru/d/d5/Dune_2021_poster.jpg", 2021, "Дюна" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
