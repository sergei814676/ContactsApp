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
    public class ContactUnit
    {
        [TestFixture]
        public class ContactTest
        {
            [Test(Description = "Позитивный тест геттера Surname")]
            public void TestSurnameGet_CorrectValue()
            {
                var expected = "Смирнов";
                var contact = new Contact();
                contact.Surname = expected;
                var actual = contact.Surname;
                Assert.AreEqual(expected, actual," Геттер Surname  возвращает неправильную фамилию");
            }

            [Test(Description = "Позитивный тест сеттера Surname")]
            public void TestSurnameSet_CorrectValue()
            {
                var expected = "Смирнов";
                var contact = new Contact();
                contact.Surname = expected;
               }


            [Test(Description = "Негативный тест геттера Surname")]
            public void TestSurnameGet_longString ()
            {
                var wrongSurname = "НемятовСергейНиколаевичНемятовСергейНиколаевичНемятовСергейНиколаевич";
                var contact =new Contact();
                Assert.Throws<ArgumentException>( () => { contact.Surname = wrongSurname; },"Должно возникать исключение, если фамилия длинее 50 символов");
            }


           
                [Test(Description = "Позитивный тест геттера Name")]
                public void TestNameGet_CorrectValue()
                {
                    var expected = "Сергей";
                    var contact = new Contact();
                    contact.Name = expected;
                    var actual = contact.Name;
                    Assert.AreEqual(expected, actual, " Геттер Name  возвращает неправильную фамилию");
            }

            [Test(Description = "Позитивный тест сеттера Name")]
            public void TestNameSet_CorrectValue()
            {
                var expected = "Сергей";
                var contact = new Contact();
                contact.Name = expected;
                }


            [Test(Description = "Негативный тест геттера Name")]
            public void TestNameGet_longString()
            {
                var wrongName = "НемятовСергейНиколаевичНемятовСергейНиколаевичНемятовСергейНиколаевич";
                var contact = new Contact();
                Assert.Throws<ArgumentException>(() => { contact.Name = wrongName; }, "Должно возникать исключение, если фамилия длинее 50 символов");
            }



            [Test(Description = "Позитивный тест геттера Mail")]
            public void TestMailGet_CorrectValue()
            {
                var expected = "sergei6@gmail.com";
                var contact = new Contact();
                contact.Mail = expected;
                var actual = contact.Mail;
                Assert.AreEqual(expected, actual, " Геттер Mail  возвращает неправильную почту");
            }

            [Test(Description = "Позитивный тест сеттера Mail")]
            public void TestMailSet_CorrectValue()
            {
                var expected = "sergei6@gmail.com";
                var contact = new Contact();
                contact.Mail = expected;
            }


            [Test(Description = "Негативный тест геттера Mail")]
            public void TestMailSet_longString()
            {
                var wrongName = "НемятовСергейНиколаевичНемятовСергейНиколаевичНемятовСергейНиколаевич";
                var contact = new Contact();
                Assert.Throws<ArgumentException>(() => { contact.Mail = wrongName; }, "Должно возникать исключение, если фамилия длинее 50 символов");
            }


            [Test(Description = "Позитивный тест геттера IDVK")]
            public void TestIDVKGet_CorrectValue()
            {
                var expected = "id43432";
                var contact = new Contact();
                contact.IDVK = expected;
                var actual = contact.IDVK;
                Assert.AreEqual(expected, actual, " Геттер IDVK  возвращает неправильную фамилию");
            }

            [Test(Description = "Позитивный тест сеттера IDVK")]
            public void TestIDVKSet_CorrectValue()
            {
                var expected = "id43432";
                var contact = new Contact();
                contact.IDVK = expected;
                }


            [Test(Description = "Негативный тест геттера IDVK")]
            public void TestIDVKSet_longString()
            {
                var wrongName = "НемятовСергейНиколаевичНемятовСергейНиколаевичНемятовСергейНиколаевич";
                var contact = new Contact();
                Assert.Throws<ArgumentException>(() => { contact.IDVK = wrongName; }, "Должно возникать исключение, если фамилия длинее 50 символов");
            }


            [Test(Description = "Позитивный тест геттера Bdate")]
            public void TestBdateGet_CorrectValue()
            {
                var expected = new DateTime(1945,09,02);
                var contact = new Contact();
              
                contact.Bdate = expected;
                var actual = contact.Bdate;
                Assert.AreEqual(expected, actual, " Геттер Bdate  возвращает неправильную дату");
            }

            [Test(Description = "Позитивный тест сеттера Bdate")]
            public void TestBdateSet_CorrectValue()
            {
                var expected = new DateTime(1945, 09, 02);
                var contact = new Contact();
                contact.Bdate = expected;
            }


            [Test(Description = "Негативный тест сеттера Bdate, слишком старая дата")]
            public void TestBdateSet_olddate()
            {
                var wrongName = new DateTime(1845, 9, 2);
                var contact = new Contact();

                Assert.Throws<ArgumentException>(() => { contact.Bdate = wrongName; }, "Должно возникать исключение, если дата старше 1900 года");
            }


            [Test(Description = "Негативный тест сеттера Bdate, будущая дата")]
            public void TestBdateSet_futuredate()
            {
                var wrongName = DateTime.Today;
                wrongName = wrongName.AddYears(1);
                var contact = new Contact();
                Assert.Throws<ArgumentException>(() => { contact.Bdate = wrongName; }, "Должно возникать исключение, если дата позже сегоднешнего числа");
            }


            [Test(Description = "Позитивный тест геттера Number")]
            public void TestPhoneNumberGet_CorrectValue()
            {
                var expected = 71234567890;
                var contact = new Contact();

                contact.Number.Number = expected;
                var actual = contact.Number.Number;
                Assert.AreEqual(expected, actual, " Геттер Number возвращает неправильный номер телефона");
            }

            [Test(Description = "Позитивный тест сеттера Number")]
            public void TestPhoneNumberSet_CorrectValue()
            {
                var expected = 71234567890;
                var contact = new Contact();
                contact.Number.Number = expected;
                }



        }
    }
}
