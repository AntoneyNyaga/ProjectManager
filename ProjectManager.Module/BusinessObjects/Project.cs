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
    public class Project : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Project(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here
            Status = ProjectStatus.InProgress.ToString();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }

        [Association("Employee-Projects")] 
        public XPCollection<Employee> Employees
        {
            get
            {
                return GetCollection<Employee>("Employees");
            }
        }
    }
    public enum ProjectStatus
    {
        [ImageName("BO_Resume")]
        [Description("In Progress")]
        InProgress,
        [ImageName("BO_Resume")]
        [Description("On Hold")]
        OnHold,
        [ImageName("BO_Resume")]
        [Description("Completed")]
        Completed
    }
    public enum ProjectType
    {
        [ImageName("BO_Resume")]
        [Description("Internal")]
        Internal,
        [ImageName("BO_Resume")]
        [Description("External")]
        External
    }
    public enum ProjectPriority
    {
        [ImageName("BO_Resume")]
        [Description("Low")]
        Low,
        [ImageName("BO_Resume")]
        [Description("Medium")]
        Medium,
        [ImageName("BO_Resume")]
        [Description("High")]
        High
    }
}