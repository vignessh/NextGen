using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ttl.Web.JourneyPlanning.Models
{
    public class AdvancedSearchModel
    {
        public virtual int NumberOfAdults { get; set; }
        public virtual int NumberOfChildren { get; set; }
        public virtual string OriginStation { get; set; }
        public virtual string DestinationStation { get; set; }

        private Func<int, int, IEnumerable<SelectListItem>> GenerateListItems
        {
            get
            {
                return (min, max) =>
                           {
                               var items = new List<SelectListItem>();
                               for (var i = min; i <= max; i++)
                                   items.Add(new SelectListItem {Text = i.ToString(), Value = i.ToString()});
                               items.First().Selected = true;
                               return items;
                           };
            }
        }

        public virtual IEnumerable<SelectListItem> AdultsTravelling
        {
            get { return GenerateListItems.Invoke(1, 8); }
        }

        public IEnumerable<SelectListItem> ChildrenTravelling
        {
            get { return GenerateListItems.Invoke(0, 6); }
        }

        public IEnumerable<SelectListItem> NumberOfRailCards
        {
            get { return GenerateListItems.Invoke(0, 8); }
        }

        public IEnumerable<SelectListItem> AllowedRailCards
        {
            get 
            { 
                return new[]
                             {
                                 new SelectListItem {Value = "None", Text = "None", Selected = true},
                                 new SelectListItem {Value = "YNG", Text = "16-25 RAILCARD"},
                                 new SelectListItem {Value = "NGC", Text = "ANNUAL GOLD CARD"},
                                 new SelectListItem {Value = "DIS", Text = "DISABLED ADULT RAILCARD"},
                                 new SelectListItem {Value = "DIC", Text = "DISABLED CHILD RAILCARD"},
                                 new SelectListItem {Value = "FAM", Text = "FAMILY AND FRIENDS RAILCARD"},

                             }; 
            }
        }
    }
}