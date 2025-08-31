using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
     class Person
    {
        private int id;
        public int Id {
            get
            {
                return id;
            }
            set
            {
                int counter = 0;
                counter++;
                id = counter;
            }
                
                }
        private string name;
        public string Name {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();
                name = value;
            }
                
                }
    }
}
