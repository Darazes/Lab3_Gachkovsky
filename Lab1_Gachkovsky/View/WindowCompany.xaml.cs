using Lab1_Gachkovsky.Helper;
using Lab1_Gachkovsky.Model;
using Lab1_Gachkovsky.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab1_Gachkovsky.View
{
    /// <summary>
    /// Логика взаимодействия для WindowCompany.xaml
    /// </summary>
    public partial class WindowCompany : Window
    {
        public WindowCompany()
        {
            InitializeComponent();
            //CompanyViewModel vmCompany = new CompanyViewModel();
            //ListCompany.ItemsSource = vmCompany.ListCompany;

            CompanyViewModel vmCompany = new CompanyViewModel();

            //Person
            PersonViewModel vmPerson = new PersonViewModel();
            List<Person> people = new List<Person>();

            foreach (Person p in vmPerson.ListPerson)
            {
                people.Add(p);
            }

            //OrgLegForm
            OrgLegFormViewModel vmOrgLegForm = new OrgLegFormViewModel();
            List<OrgLegForm> orgLegForms = new List<OrgLegForm>();

            foreach (OrgLegForm olf in vmOrgLegForm.ListOrgLegForm)
            {
                orgLegForms.Add(olf);
            }

            //OrgRegistration
            OrgRegistrationViewModel vmOrgRegistration = new OrgRegistrationViewModel();
            List<OrgRegistration> OrgRegistrations = new List<OrgRegistration>();

            foreach (OrgRegistration or in vmOrgRegistration.ListOrgRegistration)
            {
                OrgRegistrations.Add(or);
            }


            ObservableCollection<CompanyDPO> companies = new ObservableCollection<CompanyDPO>();

            FindPerson finderPerson;
            FindOrgLegForm finderOrgLegForm;
            FindOrgRegistration finderOrgRegistration;

            foreach (var company in vmCompany.ListCompany)
            {

                finderPerson = new FindPerson(company.PersonID);
                Person person = people.Find(new Predicate<Person>(finderPerson.PersonPredicate));

                finderOrgLegForm = new FindOrgLegForm(company.OrgLegFullID);
                OrgLegForm orgLegForm = orgLegForms.Find(
                    new Predicate<OrgLegForm>(finderOrgLegForm.OrgLegFormPredicate));

                finderOrgRegistration = new FindOrgRegistration(company.OrgRegistrationID);
                OrgRegistration orgRegistration = OrgRegistrations.Find(
                    new Predicate<OrgRegistration>(finderOrgRegistration.OrgRegistrationPredicate));

                companies.Add(new CompanyDPO
                {
                    Id = company.Id,
                    PersonID = person.Shifer.ToString(),
                    OrgRegistrationID = orgRegistration.NameFull,
                    OrgLegFullID = orgLegForm.NameFull,
                    NameFull = company.NameFull,
                    NameShort = company.NameShort,
                    NumberReg = company.NumberReg,
                    DataReg = company.DataReg
                });
            }

            ListCompany.ItemsSource = companies;
        }
    }
}
