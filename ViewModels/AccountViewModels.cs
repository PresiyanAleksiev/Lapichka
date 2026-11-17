using System.ComponentModel.DataAnnotations;

namespace Lapichka.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Въведете име")]
    [StringLength(50, ErrorMessage = "Името е твърде дълго")]
    [Display(Name = "Име")]
    public string FirstName { get; set; } = "";

    [Required(ErrorMessage = "Въведете фамилия")]
    [StringLength(50, ErrorMessage = "Фамилията е твърде дълга")]
    [Display(Name = "Фамилия")]
    public string LastName { get; set; } = "";

    [Required(ErrorMessage = "Въведете имейл")]
    [EmailAddress(ErrorMessage = "Невалиден имейл формат")]
    [Display(Name = "Имейл")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Въведете телефон")]
    [RegularExpression(@"^(\+359|0)8[7-9]\d{7}$", ErrorMessage = "Невалиден български телефонен номер (напр. 0888123456 или +359888123456)")]
    [Display(Name = "Телефон")]
    public string Phone { get; set; } = "";

    [Required(ErrorMessage = "Въведете парола")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$",
        ErrorMessage = "Паролата трябва да е поне 8 символа, с поне една главна буква, една малка буква и една цифра")]
    [Display(Name = "Парола")]
    public string Password { get; set; } = "";

    [Required(ErrorMessage = "Потвърдете паролата")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Паролите не съвпадат")]
    [Display(Name = "Потвърждение на паролата")]
    public string ConfirmPassword { get; set; } = "";
}

public class LoginViewModel
{
    [Required(ErrorMessage = "Въведете имейл")]
    [EmailAddress(ErrorMessage = "Невалиден имейл формат")]
    [Display(Name = "Имейл")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Въведете парола")]
    [DataType(DataType.Password)]
    [Display(Name = "Парола")]
    public string Password { get; set; } = "";
}
