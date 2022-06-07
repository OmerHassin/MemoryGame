using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace b20_ex05_01.memorygameutils
{
    internal class Computer
    {
        private readonly List<Button> m_ButtonsList;

        internal Computer(List<Button> i_ButtonsList)
        {
            m_ButtonsList = new List<Button>();

            foreach (Button button in i_ButtonsList)
            {
                m_ButtonsList.Add(button);
            }
        }

        internal void ChooseButton()
        {
            Button buttonChosen;
            Random randomIndex = new Random();
            buttonChosen = m_ButtonsList[randomIndex.Next(m_ButtonsList.Count)];
            buttonChosen.PerformClick();
            m_ButtonsList.Remove(buttonChosen);
        }

        internal void ReturnButtons(Button i_FirstButton, Button i_SecondButton)
        {
            m_ButtonsList.Add(i_FirstButton);
            m_ButtonsList.Add(i_SecondButton);
        }

        internal void RemoveMatchedButtons(Button i_FirstButton, Button i_SecondButton)
        {
            m_ButtonsList.Remove(i_FirstButton);
            m_ButtonsList.Remove(i_SecondButton);
        }
    }
}
