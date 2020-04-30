using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StoreDBAcess.Models
{
	class Inventory
	{
		#region Properties
		[Key]
		private int inventoryId;
		public int InventoryId
		{
			get { return inventoryId; }
			set { inventoryId = value; }
		}

		#endregion

		#region Constructors
		public Inventory() { }
		#endregion

		#region Methods

		#endregion
	}
}
