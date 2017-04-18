using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{
    public class Publisher
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _site;

        public string Site
        {
            get { return _site; }
            set { _site = value; }
        }

        public Publisher(string name, string site)
        {
            _name = name;

            _site = site;

        }
    }
}
