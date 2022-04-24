using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/**********************************************************
 *Project Name  : Sorter
 *Project Goal  : Sort name of person order by lastname ASC
 *Programmer    : Uus Khusni
 *Date Created  : 23 April 2022
 *Location      : Jakarta Indonesia
 *email         : uuskhusni@gmail.com
 ************************************************************
 */

namespace sorter
{
    public class Sorter
    {
        static void Main(string[] args)
        {
            //args[0] = "unsorted-names-list.txt";
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid args");
                return;
            }
            else if (!File.Exists(@args[0].ToString()))
            {
                Console.WriteLine("File not exists");
                return;
            }
            else
            {
                try
                {
                    string fileName = @args[0];
                    sorterandprintProcess(fileName);
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                }
            }
           
        }
        public static void sorterandprintProcess(string fileName) {
            /******************************************
                        This part is for reading the unsorted file, file in txt format
                        After read, convert each line split with space sepator sign
                        Foreach split assign last split to Lastname and rest to firtname in
                        Object Person(FirstName, LastName)
                    *******************************************/
            List<Personname> listPerson = File.ReadAllLines(fileName).Select(l => l.Split(' ')).Select(l => new Personname
            {
                firstname = l.Length==1 ? "" : String.Join(" ", l.Where((v, i) => i != (l.Length - 1)).ToList()).ToString().TrimStart(),
                lastname = l[l.Length - 1].ToString().Trim(),
            }).ToList();

            //Order list of Person name by last name in Ascending
            listPerson = listPerson.OrderBy(p => p.lastname).ThenBy(p => p.firstname).ToList();
            
            //Write Result order name to txt file with name : sorted-names-list.txt
            File.WriteAllLines("sorted-names-list.txt", listPerson.Select(name => (name.firstname=="") ? $"{name.lastname}" : $"{name.firstname} {name.lastname}"));

            //print result to screen
            foreach(var name in listPerson){
                Console.WriteLine(name.ToString());
            }
        }
    }

    public class Personname
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1}".Trim(), this.firstname, this.lastname);
        }


    }

}

