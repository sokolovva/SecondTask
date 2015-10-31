using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace DepedenciesResolving
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string[]> Packages = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(FileReader("all_packages.json"));
            Dependencies dependencies = JsonConvert.DeserializeObject<Dependencies>(FileReader("dependencies.json"));

            for (int i = 0; i < dependencies.DependenciesToInstall.Length; i++)
            {
                string dependence = dependencies.DependenciesToInstall[i];
                Recursive(dependence, Packages);


            }

            Console.WriteLine("All Done!");


        }

        public static void CreateFile(string filename)
        {
            File.Create("../../../filesNeeded/installed_modules/" + filename).Dispose();

        }
        public static bool VerificationIfExist(string filename)
        {
            return File.Exists("../../../filesNeeded/installed_modules/" + filename);
        }


        public static string FileReader(string filename)
        {

            string row;
            StringBuilder fileStr = new StringBuilder();
            System.IO.StreamReader file = new System.IO.StreamReader("../../../filesNeeded/" + filename);
            while ((row = file.ReadLine()) != null)
            {
                fileStr.Append(row);
            }
            return fileStr.ToString();
        }


        public static void Recursive(string dependence, Dictionary<string, string[]> Packages)
        {
            Console.WriteLine("Installing " + dependence + ".");
            string[] needfulDependencies = Packages[dependence];
            if (needfulDependencies.Length != 0)
            {
                for (int i = 0; i < needfulDependencies.Length; i++)
                {
                    Console.WriteLine("In order to install " + dependence + ", we need " + needfulDependencies[i] + ".");

                    if (VerificationIfExist(needfulDependencies[i]))
                    {

                        Console.WriteLine(needfulDependencies[i] + " is already installed.");
                    }
                    else
                    {
                        Recursive(needfulDependencies[i], Packages);
                    }


                }
                CreateFile(dependence);
                Console.WriteLine(dependence + "is installed");

            }
        }


    }
}
