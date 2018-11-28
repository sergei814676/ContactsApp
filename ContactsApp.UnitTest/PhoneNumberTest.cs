using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContactsApp;
using NUnit.Framework.Constraints;

namespace ContactsApp.UnitTest
{
    class PhoneNumberTest
    {


        [Test(Description = "Позитивный тест геттера Number")]
        public void TestPhoneNumberGet_CorrectValue()
        {
            var expected = 71234567890;
            var Number = new PhoneNumber();

            Number.Number = expected;
            var actual = Number.Number;
            Assert.AreEqual(expected, actual, " Геттер Number возвращает неправильный номер телефона");
        }

        [Test(Description = "Позитивный тест сеттера Number")]
        public void TestPhoneNumberSet_CorrectValue()
        {

            var expected = 71234567890;
            var Number = new PhoneNumber();
            Number.Number = expected;
        }


        [Test(Description = "Негативный тест сеттера Number, длинна номера не 11 символов")]
        public void TestNumberSet_longnumber()
        {
            var wrongName = 709876543211;
            var Number = new PhoneNumber();
            Assert.Throws<ArgumentException>(() => { Number.Number = wrongName; }, "Должно возникать исключение, если номер длинной не 11 символов");
        }

        [Test(Description = "Негативный тест сеттера Number, номер начинается не с 7")]
        public void TestNumberSet_notseven()
        {
            var wrongName = 80987654321;
            var Number = new PhoneNumber();
            Assert.Throws<ArgumentException>(() => { Number.Number = wrongName; }, "Должно возникать исключение, если номер длинной не 11 символов");
        }
    }
}
