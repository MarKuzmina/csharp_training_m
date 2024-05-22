using System;
using System.Linq;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;

namespace webAddressbookTests
{
    
	public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBook") { }

        public ITable<GroupData> Groups { get { return this.GetTable<GroupData>(); } }

        public ITable<ContactData> Contacts { get { return this.GetTable<ContactData>(); } }
    }










    /*
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }

    public class MySettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders
            => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "MySql";
        public string DefaultDataProvider => "MySql";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "Northwind",
                        ProviderName = ProviderName.SqlServer,
                        ConnectionString =
                            @"Server=.\;Database=addressbook;Trusted_Connection=True;Enlist=False;"
                    };
            }
        }
    }*/
}