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
        List<Person> GetAllPersons(bool withDeleted = false);

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
        void DeletePerson(int delId);

        /// <summary>
        /// Назначить сотрудника материально ответственным лицом и убрать всех остальных материально ответственных
        /// </summary>
        void SetAsReponsiblePerson(int id);
    }
}
