using System.Drawing;

namespace B20_Ex05_01.MemoryGameUtils
{
    internal class Player
    {
        private string m_Name;
        private int m_Points;
        private bool m_Computer;
        private Color m_Color;

        internal Player(string i_PlayerName, bool i_Computer, Color i_Color)
        {
            m_Name = i_PlayerName;
            m_Points = 0;
            m_Computer = i_Computer;
            m_Color = i_Color;
        }

        internal string Name
        {
            get
            {
                return m_Name;
            }
        }

        internal int Points
        {
            get
            {
                return this.m_Points;
            }

            set
            {
                this.m_Points = value;
            }
        }

        internal bool Computer
        {
            get
            {
                return this.m_Computer;
            }
        }

        internal Color Color
        {
            get
            {
                return this.m_Color;
            }
        }
    }
}
