using System;

namespace RollingStones
{
    public class Exceptions : Exception
    {
        public Exceptions(string message) : base(message)
        {
        }

        static public void CheckCondition(int condition)
        {
            if (condition == 0)
            {
                throw new Exceptions("Введен неправильный символ или значение. Попробуйте снова: ");
            }
        }

        static public void CheckValue(int value)
        {
            if (value <= 1)
            {
                throw new Exceptions("Количество камней для победы не может быть меньше, чем 1. Попробуйте снова: ");
            }
        }

        static public void CheckDuplicate(string condition1, string condition2)
        {
            if (condition1 == condition2)
            {
                throw new Exceptions("Такое условие уже задано. Попробуйте снова: ");
            }
        }

        static public void CheckDuplicate(string condition1, string condition2, string condition3)
        {
            if (condition3 == condition1 || condition3 == condition2)
            {
                throw new Exceptions("Такое условие уже задано. Попробуйте снова: ");
            }
        }
    }
}