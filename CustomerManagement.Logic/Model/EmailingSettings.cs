using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Logic.Model
{
    public class EmailingSettings : ValueObject<EmailingSettings>
    {
        public Industry Industry { get; }
        public bool EmailingIsDisabled{ get; }
        public EmailCampaign EmailCampaign => GetEmailCampaign(Industry);


        public EmailingSettings(Industry industry, bool emailingIsDisabled)
        {
            Industry = industry;
            EmailingIsDisabled = emailingIsDisabled;
        }

        public EmailingSettings DisableEmailing()
        {
            return new EmailingSettings(Industry, false);
        }

        public EmailingSettings ChangeIndustry(Industry industry)
        {
            return new EmailingSettings(industry, EmailingIsDisabled);
        }

        private EmailCampaign GetEmailCampaign(Industry industry)
        {
            if (EmailingIsDisabled)
                return EmailCampaign.None;
            if (industry.Equals(Industry.Cars))
                return EmailCampaign.LatestCarModels;
            if (industry.Equals(Industry.Pharmacy))
                return EmailCampaign.PharmacyNews;
            if (industry.Equals(Industry.Other))
                return EmailCampaign.Generic;

            throw new ArgumentException(); 
        }


        protected override bool EqualsCore(EmailingSettings other)
        {
            return Industry == other.Industry && EmailingIsDisabled == other.EmailingIsDisabled;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Industry.GetHashCode();
                return (hashCode * 397) ^ EmailingIsDisabled.GetHashCode();
            }
        }
    }
}
