using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Laryssa Barbosa e Isabela Salgueiro
namespace CBTSWE2.Aula01.Entidades
{
    public class Book
    {
        private string name;
        private Author[] authors;
        private double price;
        private int qty = 0;

        public Book(string name, Author[] authors, double price)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
        }

        public Book(string name, Author[] authors, double price, int qty)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
            this.qty = qty;
        }

        public string GetName()
        {
            return name;
        }

        public Author[] GetAuthors()
        {
            return authors;
        }

        public double GetPrice()
        {
            return price;
        }

        public void SetPrice(double price)
        {
            this.price = price;
        }

        public int GetQty()
        {
            return qty;
        }

        public void SetQty(int qty)
        {
            this.qty = qty;
        }

        public override string ToString()
        {
            StringBuilder autores = new StringBuilder();

            for (int i = 0; i < authors.Length; i++)
            {
                if (i > 0)
                    autores.Append(",");

                autores.Append(authors[i].ToString());
            }

            return $"Book[name={name},authors={{{autores}}},price={price},qty={qty}]";
        }

        public string GetAuthorNames()
        {
            StringBuilder nomes = new StringBuilder();

            for (int i = 0; i < authors.Length; i++)
            {
                if (i > 0)
                    nomes.Append(",");

                nomes.Append(authors[i].GetName());
            }

            return nomes.ToString();
        }
    }
}
