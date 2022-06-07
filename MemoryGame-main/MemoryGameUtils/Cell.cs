namespace B20_Ex05_01.MemoryGameUtils
{
    internal struct Cell<T>
    {
        private int m_Index;
        private T m_Value;
        private bool m_Reveald;

        internal int Index
        {
            get
            {
                return this.m_Index;
            }

            set
            {
                this.m_Index = value;
            }
        }

        internal T Value
        {
            get
            {
                return this.m_Value;
            }

            set
            {
                this.m_Value = value;
            }
        }

        internal bool Reveald
        {
            get
            {
                return this.m_Reveald;
            }

            set
            {
                this.m_Reveald = value;
            }
        }
    }
}
