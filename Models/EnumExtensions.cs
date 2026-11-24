using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Lapichka.Models;

public static class EnumExtensions
{
    // Връща българското име от [Display(Name = ...)], напр. AnimalStatus.Adopted -> "Осиновено"
    public static string GetDisplayName(this Enum value)
    {
        var member = value.GetType().GetMember(value.ToString()).FirstOrDefault();
        return member?.GetCustomAttribute<DisplayAttribute>()?.GetName() ?? value.ToString();
    }

    // За [Flags] енуми (дни на разположение): "Понеделник, Сряда"
    public static string GetFlagsDisplayName(this WeekDays days)
    {
        var names = Enum.GetValues<WeekDays>()
            .Where(d => d != WeekDays.None && days.HasFlag(d))
            .Select(d => d.GetDisplayName());
        return string.Join(", ", names);
    }
}
