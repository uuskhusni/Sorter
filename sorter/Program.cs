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
            //Check argumen input file
            if (args.Length == 0)
            {
                Console.WriteLine("Please key in filename with txt format");
                return;
            }
            //Check exist file txt
            else if (!File.Exists(@args[0].ToString()))
            {
                Console.WriteLine("File not exists");
                return;
            }
            //Check extension input file, should txt
            else if (Path.GetExtension(@args[0].ToString())!=".txt")
            {
                Console.WriteLine("File format should be txt");
                return;
            }
            //Process input file to sort
            else
            {
                try
                {
                    //read and sort
                    sorterandprintProcess(@args[0]);
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
            Console.WriteLine("*******************************************************");
            Console.WriteLine("Result of sorted name by lastname and then by firstname");
            Console.WriteLine("-------------------------------------------------------");
            foreach (var name in listPerson){
                Console.WriteLine(name.ToString());
            }
            Console.WriteLine("Sorted file name : sorted-names-list.txt");
            Console.WriteLine("*******************************************************");
        }
    }

    public class Personname
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public override string ToString()
        {
            return string.Format((this.firstname=="") ? "{0}{1}".Trim() : "{0} {1}".Trim(), this.firstname, this.lastname);
        }


    }

}

