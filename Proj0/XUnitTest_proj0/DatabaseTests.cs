using System;
using Microsoft.EntityFrameworkCore;
using StoreDBAcess;
using Xunit;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace XUnitTest_proj0
{
	public class DatabaseTests
	{

		[Fact]
		public void AddsCustomerToDB()
		{
			//Arrange -- create an object to configure in-memory DB
			var options = new DbContextOptionsBuilder<StoreDBContext>()
				.UseInMemoryDatabase(databaseName: "AddsPlayerToDB")
				.Options;

			//Act

			//Assert
		}

	}
}
