using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProjectManager.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Planning")]
    
    public class Employee : BaseObject
    { 
        public Employee(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }
        public string FirstName { get; set; }
        [RuleRequiredField]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [Association("Employee-Projects")]
        public XPCollection<Project> Projects
        {
            get
            {
                return GetCollection<Project>("Projects");
            }
        }
    }
}