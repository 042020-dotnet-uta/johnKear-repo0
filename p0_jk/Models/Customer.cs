using System;
using System.Collections.Generic;
using System.Text;

namespace p0_jk.Models
{
	class Customer
	{
		static readonly int custID;
		private string fName;
		public string FName
		{
			get { return fName; }
			set { fName = value; }
		}

		private string lName;
		public string LName
		{
			get { return lName; }
			set { lName = value; }
		}

		private string phoneNum;

		public string PhoneNum
		{
			get { return phoneNum; }
			set { phoneNum = value; }
		}


		static Customer()
		{
			custID = custID + 1;
		}


	}
}
