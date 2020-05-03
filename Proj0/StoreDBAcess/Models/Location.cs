using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StoreDBAcess.Models
{
	public class Location
	{
		#region Fields

		private int locationId;
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
		public int LocationId
		{
			get { return locationId; }
			set { locationId = value; }
		}

		private string locName;
		[Required]		
		public string LocName
		{
			get { return locName; }
			set {
				if (value == null)
					throw new System.ArgumentNullException
					("Parameter cannot be null", "value");
				else locName = value;
			}
		}
		
		#endregion

		#region Constructors
		public Location() { }

		public Location(string loc) 
		{
			this.locName = loc;
		}
		#endregion

		#region Methods
		
		#endregion
	}
}
