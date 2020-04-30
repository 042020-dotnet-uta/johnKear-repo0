using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StoreDBAcess.Models
{
	class Location
	{
		#region Properties
		[Key]
		private int locationId;

		public int LocationId
		{
			get { return locationId; }
			set { locationId = value; }
		}

		#endregion

		#region Constructors
		public Location() { }
		#endregion

		#region Methods

		#endregion
	}
}
