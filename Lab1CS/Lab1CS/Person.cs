using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1CS
{
    public class Person : IPerson {

        private string name;
        private int cardNumber;
        private DateTime bithday;

        public int CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime Bithday
        {
            get { return bithday; }
            set { bithday = value; }
        }

        public Person(string name, DateTime bithday, int cardNumber) {
            Name = name;
            Bithday = bithday;
            CardNumber = cardNumber;
        }

        public int calcAge(DateTime date)
        {
            if (Bithday.Month > date.Month || (Bithday.Month == date.Month && Bithday.Day > date.Day)) 
                return date.Year - Bithday.Year - 1;
            return date.Year - Bithday.Year;
        }
    }
}
