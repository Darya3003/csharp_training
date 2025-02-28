using System;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable <GroupData>, IComparable<GroupData>
    {
        private string name;
        private string header = "";
        private string footer = "";

        public GroupData(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Header
        {
            get { return header; }
            set { header = value; }
        }

        public string Footer
        {
            get { return footer; }
            set { footer = value; }
        }

        public bool Equals(GroupData other)
        {
            if(ReferenceEquals(other, null)) return false;
            if(ReferenceEquals(this, other)) return true;
            return Name==other.Name;
        }

        public override int GetHashCode() => Name.GetHashCode();

        public override string ToString() => "name = " + Name;

        public int CompareTo(GroupData other)
        {
            if (ReferenceEquals(other, null)) return 1;
            return Name.CompareTo(other.Name);
        }
    }
}
