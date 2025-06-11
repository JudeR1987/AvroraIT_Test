
namespace ConsoleApp_Task2.Infrastructure;

// вспомогательные методы и объекты
public static class Utils
{
    // организация
    public const string Company = "Аврора ИТ";

    // исполнитель проекта
    public const string FullName = "Макаров Е.С.";

    // дата окончания срока выполнения задания
    public static readonly DateTime EndDay = new(2025, 06, 10);

    // начало заголовка консоли
    public static readonly string Title =
        $"Тестовое задание от «{Company}» на {EndDay:dd.MM.yyyy}г. {FullName}";


    // константное значение для задержки при выводе
    public const int Time = 50;

    // объект для получения случайных чисел
    public static Random Random = new Random();

    // генератор случайных чисел
    // формирование случайных целых чисел в диапазоне от lo до hi
    public static int GetRandom(int lo, int hi) => Random.Next(lo, hi + 1);

    // формирование случайных вещественных чисел в диапазоне от lo до hi
    public static double GetRandom(double lo, double hi)
        => lo + (hi - lo) * Random.NextDouble();


    // вывод верхней титульной строки
    public static void ShowBarMessage(string title) {

        // вывод заголовка консоли
        Console.Title = $"{Title} - {title}";

        // вывод сообщения в заданных координатах окна консоли
        WritePos(0, 1, "".PadLeft(8) + $"{title}".PadRight(Console.WindowWidth - 8),
            ConsoleColor.White, ConsoleColor.DarkMagenta);

    } // ShowBarMessage


    // вывод текста в заданных координатах окна консоли заданным цветом
    public static void WritePos(int x, int y, string s, ConsoleColor colorFg, ConsoleColor colorBg) {

        // запись цветового оформления
        (ConsoleColor oldFg, ConsoleColor oldBg) = (Console.ForegroundColor, Console.BackgroundColor);

        // установить цветовое оформление
        (Console.ForegroundColor, Console.BackgroundColor) = (colorFg, colorBg);

        // вывод текста в заданных координатах окна консоли
        Console.SetCursorPosition(x, y);
        Console.Write(s);

        // восстановить цветовое оформление
        (Console.ForegroundColor, Console.BackgroundColor) = (oldFg, oldBg);

    } // WritePos


    // вывод меню приложения
    public static void ShowMenu(int x, int y, string title, List<MenuItem> menu) {
        
        WritePos(x, y, title, ConsoleColor.DarkMagenta, ConsoleColor.Gray);
        
        int offsetY = 1;

        foreach (var menuItem in menu) {
            
            // если текст пункта меню "Separator", просто увеличить смещение
            // по вертикали что приведет к образованию пустой строки
            string s;
            if (menuItem.Text != "Separator") {
                
                WritePos(x, y + offsetY, $" {menuItem.HotKey} ", ConsoleColor.White, ConsoleColor.DarkMagenta);
                s = menuItem.Text;
            }
            else {
                
                s = new string('─', 100);

            } // if                        

            WritePos(x + 4, y + offsetY, s.PadRight(Console.WindowWidth), ConsoleColor.DarkMagenta, ConsoleColor.Gray);
            offsetY++;

        } // foreach menuItem

    } // ShowMenu

} // Utils