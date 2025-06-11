
// Тестовое задание, выданное организацией «Аврора ИТ» до 10.06.2025.

#region Условие Задания №2 // --------------------------------------------------
/*
        Задание №2.
    
    Напишите часть программы (на любом известном Вам ЯП) отвечающую за сортировку
одномерного массив целых чисел по возрастанию не используя специальные функции
сортировки. Объявление, ввод и вывод массива можно опустить.

*/
#endregion // -----------------------------------------------------------------


using ConsoleApp_Task2.Application;
using ConsoleApp_Task2.Infrastructure;


// задать размер окна консоли
Console.SetWindowSize(180, 50);


// простейшее меню приложения
var menu = MenuItem.Initialize();


// класс для выполнения обработок по заданию
var app = new App();


// главный цикл приложения
while (true) {

    try {

        // настройка цветового оформления
        (Console.ForegroundColor, Console.BackgroundColor) = (ConsoleColor.DarkMagenta, ConsoleColor.Gray);
        Console.Clear();
        Console.CursorVisible = false;

        // вывод заголовка консоли и меню
        Utils.ShowBarMessage("Меню");
        Utils.ShowMenu(8, 5, "".PadLeft(4) + "Меню консольного приложения тестового задания", menu);

        // получить код нажатой клавиши, не отображать символ клавиши
        ConsoleKey key = Console.ReadKey(true).Key;
        Console.Clear();

        // решение выбранной задачи
        switch (key) {

            #region Задача №2 // ----------------------------------------------

            // 2. Задача №2. Демонстрация сортировки одномерного массива целых чисел по возрастанию
            case ConsoleKey.Q:
                app.SortingDemo();
                break;

            #endregion // -----------------------------------------------------

            // выход из приложения назначен на клавишу F10, Escape или клавишу Z
            case ConsoleKey.F10:
            case ConsoleKey.Escape:
            case ConsoleKey.Z:
                (Console.ForegroundColor, Console.BackgroundColor) = (ConsoleColor.White, ConsoleColor.DarkMagenta);
                Console.Write("\n\n\n\n\t" + "".PadLeft(4) + "Приложение завершило работу." + "".PadLeft(4));
                (Console.ForegroundColor, Console.BackgroundColor) = (ConsoleColor.DarkMagenta, ConsoleColor.Gray);
                Utils.WritePos(0, Console.WindowHeight - 7, "", ConsoleColor.DarkMagenta, ConsoleColor.Gray);
                return;

            default:
                throw new Exception("Нет такой команды  меню");

        } // switch
    }
    catch (Exception ex) {

        (ConsoleColor fgColor, ConsoleColor bkColor) = (Console.ForegroundColor, Console.BackgroundColor);
        (Console.ForegroundColor, Console.BackgroundColor) = (ConsoleColor.Yellow, ConsoleColor.DarkRed);
        Console.WriteLine("\n\n\t" + "".PadLeft(4) + $"{ex.Message}, метод {ex.TargetSite}" + "".PadLeft(4) + "\n\n");
        (Console.ForegroundColor, Console.BackgroundColor) = (fgColor, bkColor);
    }
    finally {

        // ожидать нажатия любой клавиши по окончании работы пункта меню
        Console.CursorVisible = true;
        Console.Write("\n\n\n\n\tНажмите любую клавишу для продолжения...");
        Console.ReadKey(true);

    } // try-catch-finally

} // while
