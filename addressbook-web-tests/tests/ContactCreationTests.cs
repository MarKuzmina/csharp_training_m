﻿using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
using System.Xml.Serialization;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace webAddressbookTests.tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(7), GenerateRandomString(15))
                {
                    Address = GenerateRandomString(100),
                    Middlename = GenerateRandomString(12)
                });
            }
            return contact;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));

        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json")
                );
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {
            //ContactData contact = new ContactData("Людовик", "Романов");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            ClassicAssert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);
        }

        /*[Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Людовик", "Романов");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            ClassicAssert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);
        }*/
    }
}