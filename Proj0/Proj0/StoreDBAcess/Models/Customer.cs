using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StoreDBAcess.Models
{
	class Customer
	{
		#region Properties
		[Key]
		private int customerId;
		public int CustomerId
		{
			get { return customerId; }
			set { customerId = value; }
		}
		
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

		private OrderHistory orderHistory;
		#endregion

		#region Contructors

		#endregion

		#region Methods
		public void UpdateOrderHistory(Order order)
		{

		}

		#endregion
	}
}
