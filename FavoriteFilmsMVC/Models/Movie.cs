using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FavoriteFilmsMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название фильма обязательно для заполнения.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Название должно быть от 2 до 100 символов.")]
        [Display(Name = "Название")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите режиссёра.")]
        [StringLength(60, ErrorMessage = "Имя режиссёра не должно превышать 60 символов.")]
        [Display(Name = "Режиссёр")]
        public string Director { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите год выпуска.")]
        [ValidReleaseYear(1895, ErrorMessage = "Введите корректный год (от 1895 до текущего).")]
        [Display(Name = "Год выпуска")]
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "Выберите жанр.")]
        [StringLength(30, ErrorMessage = "Жанр слишком длинный.")]
        [Display(Name = "Жанр")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите описание фильма.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Описание должно содержать минимум 10 символов.")]
        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        [Url(ErrorMessage = "Укажите корректный URL-адрес изображения.")]
        [Display(Name = "Ссылка на постер")]
        public string? PosterUrl { get; set; }

        [NotMapped]
        [Display(Name = "Постер с устройства")]
        [JsonIgnore]
        public IFormFile? PosterFile { get; set; }

    }
}