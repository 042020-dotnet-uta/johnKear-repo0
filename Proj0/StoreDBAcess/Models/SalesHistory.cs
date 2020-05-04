using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace StoreDBAcess.Models
{
	public class SalesHistory : History
	{
		#region Fields
		private int salesHistoryId;
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
		public int SalesHistoryId
		{
			get { return salesHistoryId; }
			set { salesHistoryId = value; }
		}

		public int? LocationId { get; set; }
		[ForeignKey("LocationId")]
		public virtual Location Location { get; set; }

		private List<Order> sales;
		public List<Order> Sales
		{
			get { return sales; }
			set { sales = value; }
		}

		private double totalSalesRevenue;
		[Required]		
		public double TotalSalesRevenue
		{
			get { return totalSalesRevenue; }
			set { totalSalesRevenue = value; }
		}

		#endregion

		#region Constructors
		public SalesHistory() 
		{
			this.sales = new List<Order>();
			this.totalSalesRevenue = 0;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Adds sale and updates total sales revenue
		/// </summary>
		/// <param name="order"></param>
		public void AddOrder(Order sale)
		{
			//add sale
			this.sales.Add(sale);
			//update total sales revenue
			this.totalSalesRevenue += sale.Total;
		}
		#endregion
	}
}
