using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    [Serializable]
    public class Organization
    {
        public Organization() { }
        public Organization(string OrgName, string OrgCount, string OrgAdr, string OrgNum) 
        { 
            this.OrganizationNumber = OrgNum;
            this.OrganizationName = OrgName;
            this.OrganizationAdress = OrgAdr;
            this.OrganizationCountry = OrgCount;
        }
        public string? OrganizationName;
        public string? OrganizationCountry;
        public string? OrganizationAdress;
        public string? OrganizationNumber;
    }
}
