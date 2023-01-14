using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1CS
{
    public class Database {

        public List<Person> readData() {
            List<Person> people = new List<Person>();
            if (!File.Exists("database.txt")) return people;
            StreamReader reader = new StreamReader("database.txt");
            while (!reader.EndOfStream) {
                string name = reader.ReadLine();
                DateTime bithday = new DateTime(int.Parse(reader.ReadLine()), int.Parse(reader.ReadLine()), int.Parse(reader.ReadLine()));
                int cardNumber = int.Parse(reader.ReadLine());
                people.Add(new Person(name, bithday, cardNumber));
            }
            reader.Close();
            return people;
        }

        public void writeData(List<Person> people) {
            StreamWriter writer = new StreamWriter("database.txt", false);
            foreach (Person person in people) {
                writer.WriteLine(person.Name);
                writer.WriteLine(person.Bithday.Year);
                writer.WriteLine(person.Bithday.Month);
                writer.WriteLine(person.Bithday.Day);
                writer.WriteLine(person.CardNumber);
            }
            writer.Close();
        }
    }
}
