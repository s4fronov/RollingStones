using RollingStones;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;

namespace TestExceptions
{
    [TestFixture(1)]
    [TestFixture(2)]
    [TestFixture(3)]
    [TestFixture(4)]
    public class Tests
    {
        int s;
        public Tests(int q)
        {
            s = q;
        }

        string var;
        string condition1;
        string condition2;
        string condition3;
        int total;

        [OneTimeSetUp]

        public void CreateConditionsForTest()
        {
            switch(s)
            {
                case 1:
                    var = "привет";
                    total = 1;
                    condition2 = "привет";
                    condition1 = "привет";
                    condition3 = "привет";
                    break;
                case 2:
                    var = "-3";
                    total = 0;
                    condition2 = "-3";
                    condition1 = "+1";
                    condition3 = "+1";
                    break;
                case 3:
                    var = "+0";
                    total = -5;
                    condition2 = "+0";
                    condition1 = "*10";
                    condition3 = "+0";
                    break;
                case 4:
                    var = "* 8";
                    total = -0;
                    condition2 = "* 8";
                    condition1 = "+2";
                    condition3 = "* 8";
                    break;
            }
        }

        
        [Test]
        public void CheckConditionTest()
        {
            try
            {
                String pattern = @"([+*])+(\d+)";
                int value1 = 2;
                foreach (var expression in var)
                {
                    foreach (System.Text.RegularExpressions.Match r in
                    System.Text.RegularExpressions.Regex.Matches(var, pattern))
                    {
                        value1 = Int32.Parse(r.Groups[2].Value);                        
                    }
                }
                Exceptions.CheckCondition(value1);
            }
            catch (Exceptions ex)
            {
                Assert.AreEqual("Введен неправильный символ или значение. Попробуйте снова: ", ex.Message);
            }       
        }

        [Test]
        public void CheckValueTest()
        {
            try
            {
                Exceptions.CheckValue(total);
            }
            catch (Exceptions ex)
            {
                Assert.AreEqual("Количество камней для победы не может быть меньше, чем 1. Попробуйте снова: ", ex.Message);
            }
        }

        [Test]
        public void CheckDuplicateTest()
        {
            try
            {
                Exceptions.CheckDuplicate(var, condition2);
            }
            catch (Exceptions ex)
            {
                Assert.AreEqual("Такое условие уже задано. Попробуйте снова: ", ex.Message);
            }
        }

        [Test]
        public void CheckDuplicatesTest()
        {
            try
            {
                Exceptions.CheckDuplicate(condition1, condition2, condition3);
            }
            catch (Exceptions ex)
            {
                Assert.AreEqual("Такое условие уже задано. Попробуйте снова: ", ex.Message);
            }
        }


    }
}