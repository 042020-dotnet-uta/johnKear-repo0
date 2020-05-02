using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StoreDBAcess.Models
{
	public class Customer
	{
		#region Fields

		private int customerId;
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CustomerId
		{
			get { return customerId; }
			set { customerId = value; }
		}

		private string fName;
		[Required]		
		public string FName
		{
			get { return fName; }
			set { fName = value; }
		}

		private string lName;
		[Required()]		
		public string LName
		{
			get { return lName; }
			set { lName = value; }
		}

		private string phoneNum;
		[Required]		
		public string PhoneNum
		{
			get { return phoneNum; }
			set { phoneNum = value; }
		}
		
		private string prefLoc;
		public string PrefLoc
		{
			get { return prefLoc; }
			set { prefLoc = value; }
		}

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
		public Customer(string fname, string lname, string phone, string location)
		{
			this.fName = fname;
			this.lName = lname;
			this.phoneNum = phone;
			this.prefLoc = location;
		}
		#endregion

		#region Methods

		#endregion
	}
}
