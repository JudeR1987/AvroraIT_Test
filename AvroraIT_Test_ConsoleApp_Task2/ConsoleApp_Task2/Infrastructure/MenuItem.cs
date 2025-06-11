
namespace ConsoleApp_Task2.Infrastructure;

// пункт меню
public class MenuItem(ConsoleKey hotKey, string text)
{
    // горячая клавиша пункта меню
    public ConsoleKey HotKey { get; set; } = hotKey;


    // текст пункта меню
    public string Text { get; set; } = text;


    // конструктор
    public MenuItem() : this(ConsoleKey.A, "A") { }


    // инициализация пунктов меню
    public static List<MenuItem> Initialize() =>
        new List<MenuItem>() {
            new() { HotKey = ConsoleKey.Q, Text = "Separator" },    
            //-----------------------------------------------------------------
            new() { HotKey = ConsoleKey.Q, Text = "Задача №2. Демонстрация сортировки одномерного массива целых чисел по возрастанию"},
            new() { HotKey = ConsoleKey.W, Text = "Separator"},
            //-----------------------------------------------------------------
            new() { HotKey = ConsoleKey.Z, Text = "Выход"},
        };

} // class MenuItem