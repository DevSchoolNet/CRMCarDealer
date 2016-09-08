using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesServices;
using DBModels;
using Xunit;

namespace BusinessServiceTests
{
	public class ContactServiceTests
	{
		private ContactService cs;
		private Person ionel;

		public ContactServiceTests()
		{
			cs = new ContactService();
			ionel = new Person()
			{
				Email = "email",
				Telephone = "1234",
				FirstName = "ionel",
				LastName = "trotinel"
			};
		}

		[Fact]
		public void CheckService()
		{
			int contacts = cs.GetAll().Count;
			Assert.Equal( 5, contacts );
		}

		[Fact]
		public void CheckInsertContact_Manual()
		{
			ContactService contactService = new ContactService();
			Contact contactFromDb = contactService.GetByEmail("email");
			if (contactFromDb != null)
			{
				cs.DeleteById(contactFromDb.id);
			}
			else
			{
				Contact contact = new Contact(  );
				contact.email = ionel.Email;
				contact.telephone = ionel.Telephone;

				contactService.insert( contact );

				contactFromDb = contactService.GetByEmail( "email" );
			}

			Assert.NotNull(contactFromDb);

			ProspectService prospectService = new ProspectService();
			var prospect = new Prospect( );
			prospect.name = ionel.FirstName + " "
							+ ionel.LastName;
			prospect.details = "--";
			// referinta manuala
			prospect.contact_id = contactFromDb.id;
			
			prospectService.insert( prospect );
			var prospectFromDb = prospectService.GetByID(prospect.id);

			Assert.NotNull(prospectFromDb);
			Assert.Equal(contactFromDb.id, prospectFromDb.contact_id);
		}

		[Fact]
		public void CheckInsertContact_Automatic()
		{
			Contact contactFromDb = cs.GetByEmail( "email" );
			if ( contactFromDb != null )
			{
				cs.DeleteById( contactFromDb.id );
			}
			else
			{
				Contact contact = new Contact();
				contact.email = ionel.Email;
				contact.telephone = ionel.Telephone;

				cs.insert( contact );

				contactFromDb = cs.GetByEmail( "email" );
			}

			Assert.NotNull( contactFromDb );

			Prospect prospect = new Prospect();
			prospect.name = "prospect automat";
			prospect.details = "details";
			// referinta automata
			contactFromDb.Prospects.Add(prospect);
			prospect.Contact = contactFromDb;
			
			cs.update(contactFromDb);

			contactFromDb = cs.GetByEmail( "email" );
			Assert.Equal(1, contactFromDb.Prospects.Count);

			var prospects = contactFromDb.Prospects.ToList();

			Assert.Equal( contactFromDb.id, prospects[0].contact_id );
		}
	}

	public class Person
	{
		public string Email { get; set; }
		public string Telephone { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
