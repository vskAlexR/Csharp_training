using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
namespace addressbook_web_tests
{
    public class AddresBookDB : LinqToDB.Data.DataConnection
    {
      //  public AddresBookDB() : base("AddressBook") { }
        public AddresBookDB() : base("MySql.Data.MySqlClient", "Server=localhost;Port=3306;Database=addressbook;Uid=root;Pwd=;charset=utf8;Allow Zero Datetime=true") { }

        public ITable<GroupData> groups
        {
            get { return GetTable<GroupData>(); }
        }

        public ITable<ContactData> contacts 
        {
            get { return GetTable<ContactData>(); }
        }
        public ITable<GroupContactRelation> GCR 
        {
            get { return GetTable<GroupContactRelation>(); } 
        }

    }
}