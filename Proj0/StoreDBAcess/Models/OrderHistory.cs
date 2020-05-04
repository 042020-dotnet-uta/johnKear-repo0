using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StoreDBAcess.Models
{
	public class OrderHistory : History
	{
		#region Fields

		private int orderHistoryId;
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
		public int OrderHistoryId
		{
			get { return orderHistoryId; }
			set { orderHistoryId = value; }
		}

		private int customerId;
		[ForeignKey("Customer")]		
		public int CustomerId
		{
			get { return customerId; }
			set { customerId = value; }
		}

		private List<Order> orders;
		public List<Order> Orders
		{
			get { return orders; }
			set { orders = value; }
		}

		#endregion

		#region Constructors
		public OrderHistory()
		{
			this.orders = new List<Order>();
		}
		#endregion

		#region Methods
		void History.AddOrder(Order order)
		{
			this.orders.Add(order);
		}
		#endregion

	}
}
