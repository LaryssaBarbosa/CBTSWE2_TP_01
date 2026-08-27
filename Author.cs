using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//Laryssa Barbosa e Isabela Salgueiro

namespace CBTSWE2.Aula01.Entidades
{
    public class Author
    {
        private string name;
        private string email;
        private char gender;

        public Author(string name, string email, char gender)
        {
            this.name = name;
            this.email = email;
            this.gender = gender;
        }

        public string GetName()
        {
            return name;
        }

        public string GetEmail()
        {
            return email;
        }

        public char GetGender()
        {
            return gender;
        }

        public override string ToString()
        {
            return $"Author[name={name},email={email},gender={gender}]";
        }
    }
}