using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContactsApp;

namespace ContactsApp.UnitTest
{
    class ProjectmanagerTest
    {
       


        [Test(Description = " тест десериализации")]
        public void TestDeserializer()
        {
            Project TestCopy = Projectmanager.Deserialization();
            Project TestSaveProject= new Project();
            Contact contactTest=new Contact();
            contactTest.Number.Number = 70987654321;
            contactTest.Bdate =new DateTime(2000, 3, 2);
            contactTest.IDVK = "id76543";
            contactTest.Mail = "sytrew@uyt.com";
            contactTest.Name = "Sytre";
            contactTest.Surname = "Uytrer";
            TestSaveProject.СontactsList.Add(contactTest);
            Projectmanager.Serialization(TestSaveProject);
            Project actual = new Project();    
              actual= Projectmanager.Deserialization();
            Project exception = TestSaveProject;
            Projectmanager.Serialization(TestCopy);
            bool TestTrue = true;
            if (actual.СontactsList[0] == exception.СontactsList[0] )
            { TestTrue = true;}
            else
            { TestTrue = false; }
            Assert.AreEqual(true, TestTrue, " Десериализация не верна проходит");

        }


        [Test(Description = " тест сериализации")]
        public void TestSerializer()
        {
            Project TestCopy = Projectmanager.Deserialization();
            Project TestSaveProject = new Project();
            Contact contactTest = new Contact();
            contactTest.Number.Number = 70987654321;
            contactTest.Bdate = new DateTime(2000, 3, 2);
            contactTest.IDVK = "id76543";
            contactTest.Mail = "sytrew@uyt.com";
            contactTest.Name = "Sytre";
            contactTest.Surname = "Sytrer";
            TestSaveProject.СontactsList.Add(contactTest);
            Projectmanager.Serialization(TestSaveProject);
            Projectmanager.Serialization(TestCopy);
        }
    }
}
