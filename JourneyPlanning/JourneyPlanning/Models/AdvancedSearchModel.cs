using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Ttl.Web.JourneyPlanning.Models
{
    public class AdvancedSearchErrors
    {
        public static string OriginStationError
        {
            get { return "Origin station field cannot be blank!"; }
        }
    }

    public class AdvancedSearchModel
    {
        public virtual int NumberOfAdults { get; set; }
        public virtual int NumberOfChildren { get; set; }

        [Required(ErrorMessage = "Origin station field cannot be blank!")]
        public virtual string OriginStation { get; set; }

        [Required]
        public virtual string DestinationStation { get; set; }

        [Required]
        public virtual DateTime OutwardDate { get; set; }

        public virtual DateTime ReturnDate { get; set; }

        private IEnumerable<SelectListItem> Generate(int start, int count, int selectedIndex)
        {
            return Enumerable.Range(start, count).Select(i => new SelectListItem {Text = i.ToString(), Value = i.ToString(), Selected = (i == selectedIndex)});
        }

        public virtual IEnumerable<SelectListItem> AdultsTravelling
        {
            get { return Generate(1, 8, 1); }
        }

        public IEnumerable<SelectListItem> ChildrenTravelling
        {
            get { return Generate(0, 6, 0); }
        }

        public IEnumerable<SelectListItem> NumberOfRailCards
        {
            get { return Generate(0, 8, 0); }
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

        [Required]
        public virtual string OutwardDepartureMode { get; set; }

        [Required]
        public virtual string OutwardTravelHour { get; set; }

        [Required]
        public virtual string OutwardTravelMinute { get; set; }

        public IEnumerable<SelectListItem> Hours
        {
            get { return Enumerable.Range(0, 24).Select(hour => new SelectListItem {Value = hour.ToString(), Text = hour.ToString("d2"), Selected = hour == 10}); }
        } 

        public IEnumerable<SelectListItem> Minutes
        {
            get
            {
                var takeWhile = Enumerable.Range(0, 60).TakeWhile(i => i%15 == 0);
                return takeWhile.Select(minute => new SelectListItem {Value = minute.ToString(), Text = minute.ToString("d2"), Selected = minute == 0});
            }
        } 

        public IEnumerable<SelectListItem> AllTravelModes
        {
            get
            {
                return new[]
                           {
                               new SelectListItem {Value = "A", Text = "Leave After", Selected = true},
                               new SelectListItem {Value = "B", Text = "Arrive Before"},
                           };
            }
        }

        public virtual string ReturnDepartureMode { get; set; }

        public virtual string ReturnTravelHour { get; set; }

        public virtual string ReturnTravelMinute { get; set; }
    }
}