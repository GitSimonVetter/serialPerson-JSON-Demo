using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace serialPerson_JSON
{
    [Serializable()]
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>(10);
            while(true)
            {
                string decisionInput;
                string lastNameInput;
                int pubsInput;
                double gradeInput;
                Console.WriteLine("Professor(0) or Student(1)");
                decisionInput = Console.ReadLine();
                if (decisionInput == "0")
                {
                    Professor pro1 = new Professor();
                    list.Add(pro1);
                    Console.Clear();
                    Console.WriteLine("Lastname?");
                    lastNameInput = Console.ReadLine();
                    if (lastNameInput == null)
                    {
                        break;
                    }
                    else { lastNameInput = pro1.lastName; }
                    Console.WriteLine("Pupils?");
                    pubsInput = Convert.ToInt32(Console.ReadLine());
                    if (Convert.ToString(pubsInput) == null)
                    {
                        break;
                    }
                    else { pubsInput = pro1.pubs; }
                }
                else if (decisionInput == "1")
                {
                    Student stu1 = new Student();
                    list.Add(stu1);
                    Console.Clear();
                    Console.WriteLine("Lastname?");
                    lastNameInput = Console.ReadLine();
                    if(lastNameInput == null)
                    {
                        break;
                    }
                    else { lastNameInput = stu1.lastName; }
                    Console.WriteLine("Grade?");
                    gradeInput = Convert.ToDouble(Console.ReadLine());
                    if (Convert.ToString(gradeInput) == null)
                    {
                        break;
                    }
                    else { gradeInput = stu1.grade; }

                }
                else
                {
                    break;
                }
            }
            try
            {
                FileStream data = new FileStream(@"list.187", FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(data, list);

            }
            catch (Exception e) { } 
            
            
        }
    }
    abstract class Person
    {
        public string lastName { get; set; }
        public abstract bool isGood();

    }
    [Serializable()]
    class Student : Person
    {
        public double grade { get; set; }
        public override bool isGood()
        {
            if (Convert.ToInt32(grade) < 2)
            {
                return true;
            }
            else { return false; }
        }

    }
    [Serializable()]
    class Professor : Person
    {
        public int pubs { get; set; }
        public override bool isGood()
        {
            if (pubs > 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
