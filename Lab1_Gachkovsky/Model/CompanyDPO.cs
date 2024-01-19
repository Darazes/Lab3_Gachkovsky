using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Gachkovsky.Model
{
    class CompanyDPO
    {
        public int Id { get; set; }
        public string PersonID { get; set; }
        public string OrgRegistrationID { get; set; }
        public string OrgLegFullID { get; set; }
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public string NumberReg { get; set; }
        public DateTime DataReg { get; set; }

        public CompanyDPO() { }

        public CompanyDPO(int Id, string PersonID, string OrgRegistrationID, string OrgLegFullID,
            string NameFull, string NameShort, string NumberReg, DateTime DataReg)
        {
            this.Id = Id;
            this.PersonID = PersonID;
            this.OrgRegistrationID = OrgRegistrationID;
            this.OrgLegFullID = OrgLegFullID;
            this.NameFull = NameFull;
            this.NameShort = NameShort;
            this.NumberReg = NumberReg;
            this.DataReg = DataReg;

        }

    }
}
