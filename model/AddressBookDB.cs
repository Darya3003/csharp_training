using LinqToDB;
namespace WebAddressbookTests
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBook") { }

        public ITable<GroupData> Groups => this.GetTable<GroupData>();

        public ITable<ContactData> Contacts => this.GetTable<ContactData>();

        public ITable<GroupContactRelation> GCR => this.GetTable<GroupContactRelation>();
    }
}
