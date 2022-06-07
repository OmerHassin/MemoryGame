namespace B20_Ex05_01.MemoryGameUtils
{
    internal class Board<T>
    {
        private readonly int m_Columns;
        private readonly int m_Rows;
        private Cell<T>[,] m_DataMatrix;

        internal Board(int i_Columns, int i_Rows, Cell<T>[,] i_DataMatrix)
        {
            m_Columns = i_Columns;
            m_Rows = i_Rows;
            m_DataMatrix = i_DataMatrix;
        }

        internal Cell<T> GetCell(int i_IndexLocation)
        {
            return m_DataMatrix[i_IndexLocation % m_Columns, i_IndexLocation / m_Columns];
        }
    }
}
