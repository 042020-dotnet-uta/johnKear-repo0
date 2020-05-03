﻿using System;
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

		public int? CustomerId { get; set; }
		[ForeignKey("CustomerId")]
		public virtual Customer Customer { get; set; }

		private ICollection<Order> orders;
		public ICollection<Order> Orders
		{
			get { return orders; }
			set { orders = value; }
		}

		#endregion

		#region Constructors
		public OrderHistory() { }
		#endregion

		#region Methods
		void History.AddOrder(Order order)
		{
			this.orders.Add(order);
		}
		#endregion

	}
}