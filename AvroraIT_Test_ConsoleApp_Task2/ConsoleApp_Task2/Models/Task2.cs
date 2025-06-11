
using ConsoleApp_Task2.Infrastructure;

namespace ConsoleApp_Task2.Models;

// класс, хранящий массив из n целых элементов (n от 12 до 30)
public class Task2
{
    // массив целых элементов
    private int[] _arrayData = [];
    public int[] ArrayData {
        get => _arrayData;
        set => _arrayData = value == null || value.Length == 0
            ? throw new ArgumentNullException("Task2: Пустой массив целых элементов")
            : value;
    } // ArrayData


    // проверка массива на пустоту
    public bool Length => _arrayData.Length == 0;


    // диапазон значений элементов массива
    public const int Low = -20, High = 20;


    // конструктор по умолчанию
    public Task2() {
        Create();
    } // Task2

    // конструктор с внедрением зависимостей
    public Task2(int[] arrayData) {
        ArrayData = arrayData;
    } // Task2


    // метод заполнения массива
    public void Create() {
        
        // количество элементов массива
        int n = Utils.GetRandom(20, 30);

        // создание нового объекта
        _arrayData = new int[n];

        // присвоение каждому элементу массива случайного значения
        for (int i = 0; i < _arrayData.Length; i++) {
            _arrayData[i] = Utils.GetRandom(Low, High);
        } // for i

    } // Create


    // метод вывода массива целых элементов в консоль
    public void ToTable(string title) => ToTable(title, _arrayData);


    // метод вывода массива целых элементов в консоль
    public static void ToTable(string title, int[] arr) {

        // вывод заголовка
        Console.Write($"\n\n\t{title}\n\n\t");

        // вывод каждого элемента в консоль
        int i = 1;
        Array.ForEach(arr, a => {
            
            Console.Write($"{a,5:n0}");
            Task.Delay(Utils.Time).Wait();

            // перевод строки
            if (i++ % 10 == 0)
                Console.Write("\n\t");
        });

        // дополнительный перевод строки,
        // если не дошли до конца строки
        if ((i - 1) % 10 != 0)
            Console.Write("\n");

    } // ToTable


    // метод сортировки элементов массива по возрастанию
    // методом "быстрой сортировки"
    public void QuickSortAscend() => QuickSort(_arrayData, 0, _arrayData.Length - 1);


    // алгоритм рекурсивной функции "быстрой сортировки"
    private static void QuickSort(int[] arr, int low, int high) {

        // условие выхода из функции
        // (массив из одного элемента)
        if (low >= high) return;

        // поиск индекса опорного элемента
        var pivotIndex = FindPivotIndex(arr, low, high);

        // сортировка подмассива ДО опорного элемента
        QuickSort(arr, low, pivotIndex - 1);

        // сортировка подмассива ПОСЛЕ опорного элемента
        QuickSort(arr, pivotIndex + 1, high);

    } // QuickSort


    // функция поиска индекса опорного элемента в массиве
    private static int FindPivotIndex(int[] arr, int low, int high) {

        // принимаем первый элемент массива опорным
        var pivot = arr[low];

        // индексы крайних элементов
        var left = low + 1;
        var right = high;


        // поиск и перемещение элементов меньших опорного
        // в начало массива, больших - в конец массива
        while (true) {

            // перемещаем левый индекс к элементу большему опорного и
            // до пересечения с правым индексом
            // (+ предусмотреть выход за пределы массива, поменяв местами операнды)
            // while (arr[left] <= pivot && left <= right) {
            while (left <= right && arr[left] <= pivot) {
                left++;
            } // while


            // перемещаем правый индекс к элементу меньшему опорного и
            // до пересечения с левым индексом
            while (right >= left && arr[right] >= pivot) {
                right--;
            } // while


            // если нашли слева большее опорного и справа меньшее
            // опорного и индексы не пересеклись, то меняем их местами
            if (right >= left)
                (arr[left], arr[right]) = (arr[right], arr[left]);
            // если индексы пересеклись, то уходим
            // (получили после индекса right - все большие опорного,
            //  а до, включая right, - меньшие опорного)
            else break;

        } // while


        // меняем местами опорный элемент (index = 0) и элемент
        // с индексом right (уже это индекс крайнего меньшего, чем опорный)
        (arr[low], arr[right]) = (arr[right], arr[low]);


        // теперь опорный элемент стоит на своём месте
        // вернём его индекс
        return right;

    } // FindPivotIndex

} // class Task2