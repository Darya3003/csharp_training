using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable <ContactData>, IComparable<ContactData>
    {
        private string firstname;        
        private string lastname = "";
        private string allPhones;

        public ContactData() { }

        public ContactData(string firstname)
        {
            FirstName = firstname;
            MiddleName = "";
            LastName = "";
            NickName = "";
            Title = "";
            Company = "";
            Address = "";
            HomePhone = "";
            MobilePhone = "";
            WorkPhone = "";
            Fax = "";
            Email = "";
            Email2 = "";
            Email3 = "";
        }

        public string Id { get; set; }

        public string FirstName { get; set; }
       
        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }       

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }
       
        public string Email3 { get; set; }

        public string FirstLastName
        {
            get { return firstname+lastname; }
            set
            {
                string firstLastName = firstname + lastname;
                firstLastName = value; 
            }
        }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                    return allPhones;
                else
                    return (CLeanUp(HomePhone) + CLeanUp(MobilePhone) + CLeanUp(WorkPhone)).Trim();
            }

            set
            {
                allPhones = value;
              }
        }

        private string CLeanUp(string phone)
        {
            if (phone == null || phone == "")
                return "";
            else 
                return Regex.Replace(phone, "[ -()]", "") + "\r\n";

        }

        public bool Equals(ContactData other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return FirstLastName == other.FirstLastName;
        }

        public override int GetHashCode() => FirstLastName.GetHashCode();

        public int CompareTo(ContactData other)
        {
            if (other is null) return 1;
            return FirstLastName.CompareTo(other.FirstLastName);
        }
    }
}
