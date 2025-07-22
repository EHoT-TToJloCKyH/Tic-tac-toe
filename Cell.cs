
namespace KrestikiNolikiKursovaya
{
    internal class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        //конструктор, позволяющий создать объект класса по заданным индексам
        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }
       // позволяет быстро создать объект класса по заданным индексам.
        public static Cell From(int row, int column)
        {
            return new Cell(row, column);
        }
        //возврат специальной ошибочной клетки
        public static Cell ErrorCell()
        {
            return new Cell(-1, -1);
        }
        //проверка текущие индексы ряда и столбца для клетки и возвращает true только если оба индекса равны -1
        public bool IsErrorCell()
        {
            return Row == -1 && Column == -1;
        }
        // проверяет, являются ли текущие значения индексов для ряда и столбца допустимыми.
        public bool IsValidGameFieldCell()
        {
            return Row>=0 && Row<=9 && Column>=0 && Column<=9;
        }
    }
}
