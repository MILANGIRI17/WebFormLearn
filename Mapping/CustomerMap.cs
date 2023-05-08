using FluentNHibernate.Mapping;
using LearnWebForm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnWebForm.Mapping
{
    public class CustomerMap:ClassMap<Customer>
    {
        public CustomerMap() {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }
}