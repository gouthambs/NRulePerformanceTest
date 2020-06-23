using System;
using System.Collections.Generic;
using System.Text;

namespace NRulePerformanceTest.Models
{
    public sealed class ConsumerLead 
    {
        public ConsumerLead(String[] csvFields)
        {
            //String[] csvFields = record.Split(",");
            LNKEY = csvFields[0];
            FirstName = csvFields[1];
            LastName = csvFields[2];
            Phone = csvFields[3];
            //Phone = csvFields[0];
            StreetAddress = csvFields[5];
            City = csvFields[6];
            State = csvFields[7];
            Zip = csvFields[8];
            Email = csvFields[9];
            //EMPLeadKey = csvFields[10];
            
            if(DateTime.TryParse(csvFields[11], out var latestDate))
                LatestLoanCreationDate = latestDate;

            //JourneyStage = csvFields[12];

            if(Decimal.TryParse(csvFields[13], out var amount))
                LoanAmount = amount;

            if(int.TryParse(csvFields[14], out var score))
                FICO = score;

            LoanPurpose = csvFields[15];
            LeadSource = csvFields[16];
            //EMPLeadSource = csvFields[17];
            //Channel = csvFields[18];
            //LeadSourceCategory = csvFields[19];
            LoanOfficerId = csvFields[20];
        }

        public long? ConsumerLeadId { get; set; }
        public Guid? ConsumerLeadGuid { get; set; }
        public long? ConsumerId { get; set; }
        public string CustomerId { get; set; }
        public string ConsumerHash { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string SSN { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string MilitaryStatus { get; set; }
        public DateTime? DateOfBirth { get; set; }
        //public JourneyStage? JourneyStage { get; set; }
        public DateTime? JourneyStageUpdateDate { get; set; }
        public string ActiveLoanNumber { get; set; }
        public string LoanOfficerId { get; set; }
        public DateTime? LatestLoanCreationDate { get; set; }
        public DateTime? LatestLoanEligibleDate { get; set; }
        //public ChannelType? Channel { get; set; }
        public int? FICO { get; set; }
        public decimal? LoanAmount { get; set; }
        public string LoanPurpose { get; set; }
        public string LeadSource { get; set; }
        public string PricingType { get; set; }        
        public string LNKEY { get; set; }
        public string LeadStatus { get; set; }
        public string TimeZone { get; set; }
        public decimal? CurrentRate { get; set; }
        public string CurrentFirstMortgage { get; set; }
        public string CallNote { get; set; }
        public decimal? LTV { get; set; }
        public string PropertyStreet { get; set; }
        public string PropertyStreet2 { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyState { get; set; }
        public string PropertyZip { get; set; }
        public int? BranchId { get; set; }
        public DateTime? TriMergeDate { get; set; }
        public DateTime? LastAssignedDate { get; set; }
        public string MortgageBankerName { get; set; }
        public DateTime? FICOPullDate { get; set; }
    }
}
