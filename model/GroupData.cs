using System;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable <GroupData>
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

        public int GetHashCode(GroupData other)
            { return Name.GetHashCode(); }
    }
}
