using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CareHomeData.Ui.Console.Models
{
    public class ProviderDetail
    {
        [Key]
        public string providerId { get; set; }

        [NotMapped]
        public string[] locationIds { get; set; }

        public string organisationType { get; set; }

        // public string ownershipType { get; set; }

        // public string type { get; set; }

        // public string brandId { get; set; }

        // public string brandName { get; set; }

        // public string uprn { get; set; }

        public string name { get; set; }

        public string alsoKnownAs { get; set; }

        public string registrationStatus { get; set; }

        public string registrationDate { get; set; }

        public string website { get; set; }

        public string postalAddressLine1 { get; set; }

        public string postalAddressLine2 { get; set; }

        public string postalAddressTownCity { get; set; }

        public string postalAddressCounty { get; set; }

        public string region { get; set; }

        public string postalCode { get; set; }

        // public float onspdLatitude { get; set; }

        // public float onspdLongitude { get; set; }

        public string mainPhoneNumber { get; set; }

        // public string inspectionDirectorate { get; set; }

        // public string constituency { get; set; }

        public string localAuthority { get; set; }

        //public Lastinspection lastInspection { get; set; }

        //public Lastreport lastReport { get; set; }

        //public object[] contacts { get; set; }

        //public Relationship[] relationships { get; set; }

        //public Regulatedactivity[] regulatedActivities { get; set; }

        //public Inspectionarea[] inspectionAreas { get; set; }

        //public Inspectioncategory[] inspectionCategories { get; set; }

        //public Currentratings currentRatings { get; set; }

        //public Historicrating[] historicRatings { get; set; }

        //public Report[] reports { get; set; }
    }

    public class Lastinspection
    {
        public string date { get; set; }
    }

    public class Lastreport
    {
        public string publicationDate { get; set; }
    }

    public class Currentratings
    {
        public Overall overall { get; set; }

        public string reportDate { get; set; }

        public Servicerating[] serviceRatings { get; set; }
    }

    public class Overall
    {
        public string rating { get; set; }

        public string reportDate { get; set; }

        public string reportLinkId { get; set; }

        public Useofresources useOfResources { get; set; }

        public Keyquestionrating[] keyQuestionRatings { get; set; }
    }

    public class Useofresources
    {
    }

    public class Keyquestionrating
    {
        public string name { get; set; }

        public string rating { get; set; }

        public string reportDate { get; set; }

        public string reportLinkId { get; set; }
    }

    public class Servicerating
    {
        public string name { get; set; }

        public string rating { get; set; }

        public string reportDate { get; set; }

        public string reportLinkId { get; set; }
    }

    public class Relationship
    {
        public string relatedProviderId { get; set; }

        public string relatedProviderName { get; set; }

        public string type { get; set; }

        public string reason { get; set; }
    }

    public class Regulatedactivity
    {
        public string name { get; set; }

        public string code { get; set; }

        public Nominatedindividual nominatedIndividual { get; set; }
    }

    public class Nominatedindividual
    {
        public string personTitle { get; set; }

        public string personGivenName { get; set; }

        public string personFamilyName { get; set; }
    }

    public class Inspectionarea
    {
        public string inspectionAreaId { get; set; }

        public string inspectionAreaName { get; set; }

        public string status { get; set; }
    }

    public class Inspectioncategory
    {
        public string code { get; set; }

        public string primary { get; set; }

        public string name { get; set; }
    }

    public class Historicrating
    {
        public string reportLinkId { get; set; }

        public string reportDate { get; set; }

        public Overall1 overall { get; set; }
    }

    public class Overall1
    {
        public string rating { get; set; }

        public Keyquestionrating1[] keyQuestionRatings { get; set; }
    }

    public class Keyquestionrating1
    {
        public string name { get; set; }

        public string rating { get; set; }
    }

    public class Report
    {
        public string linkId { get; set; }

        public string reportDate { get; set; }

        public string reportUri { get; set; }

        public string reportType { get; set; }
    }
}
