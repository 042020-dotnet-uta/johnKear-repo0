using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
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
			set
			{
				if (value == null)
					throw new System.ArgumentNullException
					("Parameter cannot be null", "value");
				else fName = value;
			}
		}

		private string lName;
		[Required]		
		public string LName
		{
			get { return lName; }
			set
			{
				if (value == null)
					throw new System.ArgumentNullException
					("Parameter cannot be null", "value");
				else lName = value;
			}
		}

		private string phoneNum;
		[NotNull]		
		public string PhoneNum
		{
			get { return phoneNum; }
			set
			{
				if (value == null)
					throw new System.ArgumentNullException
					("Parameter cannot be null", "value");
				else phoneNum = value;
			}
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
			if(fname == null || lname == null || phone == null)
			{
				throw new System.ArgumentNullException("Parameter cannot be null", "fname");
			}
			else
			{
				this.fName = fname;
				this.lName = lname;
				this.phoneNum = phone;
			}
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
			if (fname == null || lname == null || phone == null)
			{
				throw new System.ArgumentNullException("Parameter cannot be null", "fname");
			}
			else
			{
				this.fName = fname;
				this.lName = lname;
				this.phoneNum = phone;
				this.prefLoc = location;
			}			
		}
		#endregion

		#region Methods

		#endregion
	}
}
