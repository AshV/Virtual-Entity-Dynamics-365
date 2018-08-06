using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualEntityWebAPI.Models;

namespace VirtualEntityWebAPI.DataSource
{
    public class SampleDataSource
    {
        private static SampleDataSource instance = null;
        public static SampleDataSource Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SampleDataSource();
                }
                return instance;
            }
        }
        public List<Person> Persons { get; set; }

        private SampleDataSource()
        {
            this.Reset();
            this.Initialize();
        }
        public void Reset()
        {
            this.Persons = new List<Person>();
        }
        public void Initialize()
        {
            this.Persons.AddRange(new List<Person>
                    {
                    new Person()
                    {
                    ID = "3920A281-E6A8-48FF-B119-5873C63B435B",
                    Name = "Person 1",
                    Description = "Person 1 Description"
                    
                    },
                    new Person()
                    {
                    
                    ID = "3920A281-E6A8-48FF-B129-5873C63B434A",
                    Name = "Person 2",
                    Description = "Person 2 Description"
                    },
                    new Person()
                    {
                    ID ="3920A281-E6A8-48FF-B119-5873C63B434A",
                    Name = "Person 3",
                    Description = "Person 3 Description"
                    }
                    });
        }
    }
}