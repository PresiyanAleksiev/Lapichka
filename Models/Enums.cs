using System.ComponentModel.DataAnnotations;

namespace Lapichka.Models;

public enum Gender
{
    [Display(Name = "Мъжки")] Male = 1,
    [Display(Name = "Женски")] Female = 2
}

public enum AnimalStatus
{
    [Display(Name = "Търси дом")] LookingForHome = 1,
    [Display(Name = "Осиновено")] Adopted = 2
}

public enum AdoptionStatus
{
    [Display(Name = "Нова")] New = 1,
    [Display(Name = "Одобрена")] Approved = 2,
    [Display(Name = "Отказана")] Rejected = 3,
    [Display(Name = "Оттеглена")] Withdrawn = 4
}

public enum ProcedureType
{
    [Display(Name = "Ваксинация")] Vaccination = 1,
    [Display(Name = "Обезпаразитяване")] Deworming = 2,
    [Display(Name = "Кастрация")] Castration = 3,
    [Display(Name = "Преглед")] Checkup = 4
}

public enum VolunteerActivity
{
    [Display(Name = "Разходка на кучета")] DogWalking = 1,
    [Display(Name = "Почистване")] Cleaning = 2,
    [Display(Name = "Транспорт")] Transport = 3,
    [Display(Name = "Временен дом")] FosterHome = 4
}

public enum VolunteerStatus
{
    [Display(Name = "Нова")] New = 1,
    [Display(Name = "Одобрена")] Approved = 2,
    [Display(Name = "Отказана")] Rejected = 3
}

// Дни на разположение – битови флагове, за да може да се изберат няколко дни
[Flags]
public enum WeekDays
{
    None = 0,
    [Display(Name = "Понеделник")] Monday = 1,
    [Display(Name = "Вторник")] Tuesday = 2,
    [Display(Name = "Сряда")] Wednesday = 4,
    [Display(Name = "Четвъртък")] Thursday = 8,
    [Display(Name = "Петък")] Friday = 16,
    [Display(Name = "Събота")] Saturday = 32,
    [Display(Name = "Неделя")] Sunday = 64
}
