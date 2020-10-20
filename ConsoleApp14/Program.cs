using System;
using System.Collections.Generic;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(String[] args)
        {
            Dictionary<String, List<FileEndPoint>> dic = new Dictionary<String, List<FileEndPoint>>();
            String filename = "peter.txt";
            FileEndPoint fep1 = new FileEndPoint("localhost", 3030);
            FileEndPoint fep2 = new FileEndPoint("localhost", 3031);
            FileEndPoint fep3 = new FileEndPoint("localhost", 3032);
            FileEndPoint fep4 = new FileEndPoint("localhost", 3033);

            InsertIntoDictionay(dic, filename, fep1); // key findes ikke i forvejen
            InsertIntoDictionay(dic, filename, fep2); // key findes allerede


            DeleteFromDictionay(dic, filename, fep1);
            DeleteFromDictionay(dic, "fileFindesIkke.txt", fep1);

            List<FileEndPoint> liste = SearchInDictionary(dic, filename);
            foreach (FileEndPoint endPoint in liste)
            {
                Console.WriteLine(endPoint);
            }

            InsertIntoDictionay(dic, filename, fep3);
            InsertIntoDictionay(dic, filename, fep4);
            List<FileEndPoint> newliste = SearchInDictionary(dic, "peter.txt");
            foreach (FileEndPoint endPoint in newliste)
            {
                Console.WriteLine(endPoint);
            }


            Console.WriteLine("Så vi færdige!");
        }

        private static void InsertIntoDictionay(Dictionary<string, List<FileEndPoint>> dic, string filename, FileEndPoint fep)
        {
            /*
             * insert into Dictionary
             */

            if (dic.ContainsKey(filename))
            {
                // key does exists
                List<FileEndPoint> listOfFep = dic[filename];
                listOfFep.Add(fep);
            }
            else
            {
                // key do not exists
                List<FileEndPoint> listOfFep = new List<FileEndPoint>();
                listOfFep.Add(fep);
                dic.Add(filename, listOfFep);
            }
        }


        private static void DeleteFromDictionay(Dictionary<string, List<FileEndPoint>> dic,
                                                String filename, FileEndPoint fep)
        {

            /*
            * Delete from dictionary
            */

            
            if (dic.ContainsKey(filename))
            {
                // Key does exists
                List<FileEndPoint> listOfFep = dic[filename];
                listOfFep.RemoveAll(f => f.IpAddress == fep.IpAddress &&
                                         f.Port == fep.Port);
                
                // hvis equals er overskrevet i FileEndPoint klassen 
                //listOfFep.Remove(fep);
            }
            else
            {
                // Key do not exists
                // tja så kan vi ikke gøre noget
            }

        }




        private static List<FileEndPoint> SearchInDictionary(Dictionary<string, List<FileEndPoint>> dic,
            String filename)
        {

            if (dic.ContainsKey(filename))
            {
                return dic[filename];
            }

            // returnere en tom liste
            return new List<FileEndPoint>();
        }
    }
}
