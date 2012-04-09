using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Ttl.Web.JourneyPlanning.Models
{
    public class AdvancedSearchModel
    {
        public virtual int NumberOfAdults { get; set; }
        public virtual int NumberOfChildren { get; set; }

        [Required]
        public virtual string OriginStation { get; set; }

        [Required]
        public virtual string DestinationStation { get; set; }

        [Required]
        public virtual DateTime OutwardDate { get; set; }

        public virtual DateTime ReturnDate { get; set; }

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

        public virtual string RailCard1 { get; set; }

        public virtual string ServiceType { get; set; }

        public IEnumerable<SelectListItem> AllJourneyOptions
        {
            get
            {
                return new[]
                           {
                               new SelectListItem {Value = "A", Text = "All Services", Selected = true},
                               new SelectListItem {Value = "D", Text = "Direct Services Only"}
                           };
            }
        }

        public virtual string RouteRestriction { get; set; }

        public IEnumerable<SelectListItem> AllRouteRestrictions
        {
            get
            {
                return new[]
                           {
                               new SelectListItem {Value = "NULL", Text = "Please select", Selected = true},
                               new SelectListItem {Value = "VIA", Text = "Go Via"},
                               new SelectListItem {Value = "AVOID", Text = "Avoid"}
                           };
            }
        }

        public virtual string ViaAvoidStation { get; set; }
    }
}