# Лапичка – приют за животни

ASP.NET Core MVC (.NET 8) + Identity + EF Core (SQL Server LocalDB).

## Стартиране
1. Отвори `Lapichka.csproj` във Visual Studio (File → Open → Project).
2. Натисни F5. Базата `LapichkaDb` се създава сама при първо стартиране.

## Начален администратор
- Имейл: `admin@lapichka.bg`
- Парола: `Admin123`

## Готово към момента
- Регистрация и вход (имейл + парола)
- Валидация: уникален имейл, парола (мин. 8 символа, главна, малка, цифра), потвърждение на парола, български телефон
- Роли: Administrator, Employee, RegisteredUser (нов потребител = RegisteredUser)
- Паролите се пазят хеширани
