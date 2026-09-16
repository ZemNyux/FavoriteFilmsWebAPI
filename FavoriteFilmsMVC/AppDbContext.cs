using FavoriteFilmsMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FavoriteFilmsMVC.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                Id = 1,
                Title = "Интерстеллар",
                Director = "Кристофер Нолан",
                ReleaseYear = 2014,
                Genre = "Фантастика",
                Description = "Наше время на Земле подошло к концу, команда исследователей берется за самую важную миссию в истории человечества.",
                PosterUrl = "https://upload.wikimedia.org/wikipedia/ru/c/c3/Interstellar_film_poster.jpg"
            },
            new Movie
            {
                Id = 2,
                Title = "Темный рыцарь",
                Director = "Кристофер Нолан",
                ReleaseYear = 2008,
                Genre = "Боевик",
                Description = "Бэтмен поднимает ставки в войне с криминалом с помощью лейтенанта Джима Гордона и прокурора Харви Дента.",
                PosterUrl = "https://upload.wikimedia.org/wikipedia/ru/1/15/Dark_knight_poster.jpg"
            },
            new Movie
            {
                Id = 3,
                Title = "Начало",
                Director = "Кристофер Нолан",
                ReleaseYear = 2010,
                Genre = "Фантастика",
                Description = "Вор, крадущий корпоративные секреты через использование технологии обмена снами.",
                PosterUrl = "https://upload.wikimedia.org/wikipedia/ru/c/bc/Inception_poster.jpg"
            },
            new Movie
            {
                Id = 4,
                Title = "Матрица",
                Director = "Лана и Лилли Вачовски",
                ReleaseYear = 1999,
                Genre = "Фантастика",
                Description = "Компьютерный хакер узнает от таинственных повстанцев об истинной природе его реальности.",
                PosterUrl = "https://upload.wikimedia.org/wikipedia/ru/9/9d/Matrix-dvd.jpg"
            },
            new Movie
            {
                Id = 5,
                Title = "Бойцовский клуб",
                Director = "Дэвид Финчер",
                ReleaseYear = 1999,
                Genre = "Драма",
                Description = "Офисный работник, страдающий бессонницей, и харизматичный мыловар создают подпольный бойцовский клуб.",
                PosterUrl = "https://upload.wikimedia.org/wikipedia/ru/8/8b/Fight_Club_poster.jpg"
            },
            new Movie
            {
                Id = 6,
                Title = "Криминальное чтиво",
                Director = "Квентин Тарантино",
                ReleaseYear = 1994,
                Genre = "Криминал",
                Description = "Истории двух бандитов, жены их босса и боксера переплетаются в серии философских и комичных событий.",
                PosterUrl = "https://upload.wikimedia.org/wikipedia/ru/9/93/Pulp_Fiction_cover.jpg"
            },
            new Movie
            {
                Id = 7,
                Title = "Зеленая миля",
                Director = "Фрэнк Дарабонт",
                ReleaseYear = 1999,
                Genre = "Драма",
                Description = "История надзирателей в блоке смертников, один из которых обладает чудесным даром исцеления.",
                PosterUrl = "https://upload.wikimedia.org/wikipedia/ru/c/c5/Green_mile_poster.jpg"
            },
            new Movie
            {
                Id = 8,
                Title = "Побег из Шоушенка",
                Director = "Фрэнк Дарабонт",
                ReleaseYear = 1994,
                Genre = "Драма",
                Description = "Успешный банкир осужден за убийство и отправлен в тюрьму Шоушенк.",
                PosterUrl = "https://upload.wikimedia.org/wikipedia/ru/d/de/ShawshankRedemptionMoviePoster.jpg"
            },
            new Movie
            {
                Id = 9,
                Title = "Остров проклятых",
                Director = "Мартин Скорсезе",
                ReleaseYear = 2010,
                Genre = "Детектив",
                Description = "Два судебных пристава отправляются на остров в психиатрическую больницу для расследования исчезновения пациентки.",
                PosterUrl = "https://upload.wikimedia.org/wikipedia/ru/a/a2/Shutter-island-poster.jpg"
            },
            new Movie
            {
                Id = 10,
                Title = "Дюна",
                Director = "Дени Вильнёв",
                ReleaseYear = 2021,
                Genre = "Фантастика",
                Description = "Наследник знаменитого дома Атрейдесов отправляется на самую опасную планету во Вселенной — Арракис.",
                PosterUrl = "https://upload.wikimedia.org/wikipedia/ru/d/d5/Dune_2021_poster.jpg"
            }
        );
    }
}