using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml;
using Microsoft.EntityFrameworkCore;

namespace StoreDBAcess.Models
{
	public class Customer
	{
		#region Fields

		/// <summary>
		/// Primary key ID
		/// </summary>
		private int customerId;
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CustomerId
		{
			get { return customerId; }
			set { customerId = value; }
		}

		/// <summary>
		/// customer first name
		/// required
		/// </summary>
		private string fName;
		[Required]		
		public string FName
		{
			get { return fName; }
			set { fName = value; }
		}

		/// <summary>
		/// customer last name
		/// required
		/// </summary>
		private string lName;
		[Required]		
		public string LName
		{
			get { return lName; }
			set { lName = value; }
		}

		/// <summary>
		/// customer phone number
		/// required 
		/// must be 10 digits
		/// </summary>
		private string phoneNum;
		[Required]
		[MaxLength(10)]
		public string PhoneNum
		{
			get { return phoneNum; }
			set { phoneNum = value; }
		}

		/// <summary>
		/// preferrerd location
		/// foreign key
		/// </summary>
		[ForeignKey("LocationId")]
		public int PreferredLoc { get; set; }

		#endregion

		#region Contructors
		public Customer() { }

		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="fname"></param>
		/// <param name="lname"></param>
		/// <param name="phone"></param>
		public Customer(string fname, string lname, string phone)
		{
			this.fName = fname;
			this.lName = lname;
			this.phoneNum = phone;
		}

		/// <summary>
		/// Constructor all properties specified
		/// </summary>
		/// <param name="fname"></param>
		/// <param name="lname"></param>
		/// <param name="phone"></param>
		/// <param name="location"></param>
		public Customer(string fname, string lname, string phone, Location location)
		{
			this.fName = fname;
			this.lName = lname;
			this.phoneNum = phone;
			this.PreferredLoc = location.LocationId;
		}
		#endregion

		#region Methods

		#endregion
	}
}
