using System;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable <GroupData>, IComparable<GroupData>
    {
        public GroupData(string name)
        {
            Name = name;
            Header = "";
            Footer = "";
        }

        public string Name { get; set; }
        
        public string Header { get; set; }
      
        public string Footer {  get; set; }

        public string Id { get; set; }

        public bool Equals(GroupData other)
        {
            if(other is null) return false;
            if(ReferenceEquals(this, other)) return true;
            return Name==other.Name;
        }

        public override int GetHashCode() => Name.GetHashCode();

        public override string ToString() => "name = " + Name;

        public int CompareTo(GroupData other)
        {
            if (other is null) return 1;
            return Name.CompareTo(other.Name);
        }
    }
}
