using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Laba1.Models
{
    /*Класс записи телефонной книги*/
    public class Person
    {
        /*Уникальный номер*/
        [HiddenInput(DisplayValue = false)]
        public int id { get; set; }

        /*Фамилия*/
        [Required(ErrorMessage = "Поле Фамилия должно быть заполнено")]
        public string lastName { get; set; }

        /*Имя*/
        [Required(ErrorMessage = "Поле Имя должно быть заполнено")]
        public string firstName { get; set; }

        /*Отчество*/
        public string secondName { get; set; }

        /*Номер телефона*/
        [Required(ErrorMessage = "Поле Телефон должно быть заполнено")]
        public string phone { get; set; }

        public Person() {}
    }
}