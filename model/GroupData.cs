using LinqToDB.Mapping;
using System;
using System.Linq;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData() { }

        public GroupData(string name)
        {
            Name = name;
            Header = "";
            Footer = "";
        }

        [Column(Name = "group_name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; }

        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }  
        
        public bool Equals(GroupData other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return Name.Equals(other.Name, StringComparison.Ordinal);
        }

        public override int GetHashCode() => Name.GetHashCode();

        public override string ToString() => "name = " + Name + "\nheader = " + Header + "\nfooter = " + Footer;

        public int CompareTo(GroupData other)
        {
            if (other is null) return 1;
            return Name.CompareTo(other.Name);
        }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

        public List<ContactData> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p=>p.GroupId == Id && p.ContactId ==c.Id && c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct().ToList();
            }
        }
    }
}
