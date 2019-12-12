using System;

namespace ÜK_318_Aufgaben.Models
{
    public class PersonModel
    {
        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private String _surname;

        public String Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        private String _adress;

        public String Adress 
        {
            get { return _surname; }
            set { _adress = value; }
        }


        private int _zipCode;

        public int ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        private String _city;

        public String City
        {
            get { return _city; }
            set { _city = value; }
        }


    }
}