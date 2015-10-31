using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepedenciesResolving
{
    class Dependencies
    {
        string name;
        string[] dependenciesToInstall;

        public string Name
        {
            get
            {
                return name;
            }
             set
            {
                name = value;
            }
       }

        public string [] DependenciesToInstall
        {

            get
            {
                return dependenciesToInstall;
            }
            set
            {
                dependenciesToInstall = value;
            }
        }
        public Dependencies(string name, string []dependencies)
        {
            this.Name = name;
            this.DependenciesToInstall = dependencies;
        }
    }
}
