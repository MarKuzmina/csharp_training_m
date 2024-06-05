using System;
using System.Linq;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using mantis_tests;

namespace mantis_tests
{
	public class MantisDB : LinqToDB.Data.DataConnection
    {
        //public AddressBookDB() : base("AddressBook") { }

        public MantisDB() : base(ProviderName.MySql, @"server=localhost; database=bugtracker; port=3306; Uid=root; Pwd=; charset=utf8; Allow Zero Datetime=true") { }

        public ITable<ProjectData> Projects { get { return this.GetTable<ProjectData>(); } }
    }
}