namespace SimpleIndexer2
{
    // Интерфейс с индексатором
    public interface IIntContainer
    {
        int this[int row, int col] { get; set; }
    }

    class SomeContainer : IIntContainer
    {
        private int[,] my2DintArray = new int[10, 10];
        // Многомерный индексатор
        public int this[int row, int column]
        {
            get => my2DintArray[row, column];
            set => my2DintArray[row, column] = value;
        }
        
        public int GetLength(int dimension)
        {
            return my2DintArray.GetLength(dimension);
        }
    }
}
