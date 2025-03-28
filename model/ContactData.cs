﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;


namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
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

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "firstname"), NotNull]
        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "lastname"), NotNull]
        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        [Column(Name = "nickname")]
        public string NickName { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string FirstLastName
        {
            get { return FirstName + LastName; }            
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

        public override string ToString() => "firstname = " + FirstName + "\nlastname = " + LastName;

        public int CompareTo(ContactData other)
        {
            if (other is null) return 1;
            return FirstLastName.CompareTo(other.FirstLastName);
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts select c).ToList();
            }
        }

        public static ContactData GetLastContact()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return db.Contacts
                 .OrderByDescending(c => c.Id)
                 .Select(c => new ContactData
                 {
                     Id = c.Id,
                     FirstName = c.FirstName,
                     LastName = c.LastName
                 })
                 .First();
            }
        }
    }
}
