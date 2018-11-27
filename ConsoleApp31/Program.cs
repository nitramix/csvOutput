using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;
using System.Globalization;

namespace ConsoleApp31
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> person = new List<Person>();

            var lines = File.ReadAllLines("..\\..\\..\\Sample1.csv");


            foreach (var item in lines.Skip(1))
            {
                var values = item.Split(';');
                person.Add(new Person()
                {
                    FirstName = values[0],
                    LastName = values[1],
                    BirthDate = DateTime.Parse(values[2], CultureInfo.CreateSpecificCulture("mk"))
                });
            }

            
             StringBuilder sbRtn = new StringBuilder();


             var header = string.Format("\"{0}\",\"{1}\"",
                                           "Full Name",
                                           "Age"
                                          );

             sbRtn.AppendLine(header);
            

             foreach (var item in person)
              {
                  var today = DateTime.Today;
                  var age = today.Year - item.BirthDate.Year;
                  if (item.BirthDate > today.AddYears(-age)) age--;
                  var fullName = item.FirstName + " " + item.LastName;
                  var listResults = string.Format("\"{0}\",\"{1}\"",
                                                      fullName,
                                                      age
                                                     );
                  sbRtn.AppendLine(listResults);    
            }


             System.IO.File.WriteAllText("..\\..\\..\\Output.csv", sbRtn.ToString());







            Console.ReadLine();
        }
    }
}
