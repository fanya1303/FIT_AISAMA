using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.Data.Services.Interfaces
{
    public interface IPersonService
    {
        /// <summary>
        /// Получить всех сотрудников
        /// </summary>
        List<Person> GetAllPersons();

        /// <summary>
        /// Получить сотрудника по id
        /// </summary>
        Person GetPersonById(int id);

        /// <summary>
        /// Сохранить информацию о сотруднике
        /// </summary>
        void SavePerson(Person person);

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        void DeletePerson(Person delPerson);

        /// <summary>
        /// Поиск по ФИО или Должности
        /// </summary>
        List<Person> SearchPersons(string search);
    }
}
