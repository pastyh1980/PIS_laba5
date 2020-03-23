using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Laba1.Models
{
    public class PersonDBInit : DropCreateDatabaseAlways<PersonContext>
    {
        protected override void Seed(PersonContext context)
        {
            context.persons.Add(new Person { firstName = "Иван", lastName = "Иванов", secondName = "Иванович", phone = "12345" });
            context.persons.Add(new Person { firstName = "Петр", lastName = "Петров", secondName = "Петрович", phone = "54321" });
            context.persons.Add(new Person { firstName = "Виктор", lastName = "Викторов", secondName = "Викторович", phone = "32154" });
            context.persons.Add(new Person { firstName = "Алексей", lastName = "Алексеев", secondName = "Алексеевич", phone = "15243" });
            context.persons.Add(new Person { firstName = "Николай", lastName = "Николаев", secondName = "Николаевич", phone = "51432" });

            base.Seed(context);
        }
    }
}