using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ContactsApp;

namespace ContactsApp
{
    ///<summary>
    ///класс с массивом контактов 
    ///</summary>
    public class Project
    {
        ///<summary>
        ///массив контактов 
        ///</summary>
        public List<Contact> СontactsList = new List<Contact>();


        ///<summary>
        ///метод возвращающий отсартированый список конктактов 
        ///</summary>        
        public List<Contact> SortingContacts()
        {
            var sortedСontactsList = СontactsList.OrderBy(u => u.Surname);
            return sortedСontactsList.ToList();
        }

        ///<summary>
        ///метод возвращающий отсартированый список конктактов и с использованием поиска     
        ///</summary>        
        public List<Contact> SortingContacts(string Find)
        {
            var sortedСontactsList = СontactsList.OrderBy(u => u.Surname);
            var FindsortedСontactsList = sortedСontactsList.ToList()
                .FindAll(t => t.Surname.StartsWith(Find) || t.Name.StartsWith(Find));
            return FindsortedСontactsList;
        }

        public List<Contact> BdataContacts()
        {
            var sortedСontactsList = СontactsList.OrderBy(u => u.Surname);
            var FindsortedСontactsList = sortedСontactsList.ToList().FindAll(t =>
                t.Bdate.Day == DateTime.Today.Day && t.Bdate.Month == DateTime.Today.Month);
            return FindsortedСontactsList;
        }
    }
}