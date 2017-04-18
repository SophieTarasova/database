using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{
    public class Comics
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _year;

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        private string _author;

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        private Publisher _publisher;

        public Publisher Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }

        public Comics(string name, string author, int year)
        {
            _name = name;
            _author = author;
            _year = year;
        }
        public string Info
        {
            get
            {
                return $"{_name} - {_author} - {_year}- {_publisher.Name} - {_publisher.Site}";
            }
        }
    }
}
