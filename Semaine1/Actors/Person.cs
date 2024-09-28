using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Actors
{

    [Serializable]
    public class Person
    {


    private static readonly long serialVersionUID = 1L;

    private readonly string _name;
	private readonly string _firstname;
	private  DateTime _birthDate;
	
	public string Name
        {
            get { return _name; }
        }

    public string Firstname
        {
            get { return _firstname; }
        }

        public string Birthday => _birthDate.ToString("d");


    public Person(String name, String firstname, DateTime birthDate)
    {
        this._name = name;
        this._firstname = firstname;
        this._birthDate = birthDate;
    }

    public String toString()
    {
        return "Person [name = " + _name + ", firstname = " + _firstname + ", birthDate =  " + _birthDate + "]";
    }

    }

    
}