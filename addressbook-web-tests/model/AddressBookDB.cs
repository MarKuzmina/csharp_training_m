﻿using System;
using System.Linq;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;

namespace webAddressbookTests
{
	public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        //public AddressBookDB() : base("AddressBook") { }

        public AddressBookDB() : base(ProviderName.MySql, @"server=localhost; database=addressbook; port=3306; Uid=root; Pwd=; charset=utf8; Allow Zero Datetime=true") { }

        public ITable<GroupData> Groups { get { return this.GetTable<GroupData>(); } }

        public ITable<ContactData> Contacts { get { return this.GetTable<ContactData>(); } }

        public ITable<GroupContactRelation> GCR { get { return this.GetTable<GroupContactRelation>(); } }
    }
}