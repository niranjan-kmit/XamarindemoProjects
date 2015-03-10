using System;

namespace JsonService.JsonDto
{
    public class Contact
    {
        public Contact()
        {
        }

        public virtual int ID { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Title { get; set; }

        public virtual string Picture { get; set; }
    }
}