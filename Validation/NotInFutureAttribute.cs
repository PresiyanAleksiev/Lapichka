using System.ComponentModel.DataAnnotations;

namespace Lapichka.Validation;

// Проверява, че датата не е по-късно от текущата (за ветеринарни процедури)
public class NotInFutureAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is DateTime date)
            return date.Date <= DateTime.Today;
        return true; // празна стойност се проверява с [Required], ако е нужно
    }
}
