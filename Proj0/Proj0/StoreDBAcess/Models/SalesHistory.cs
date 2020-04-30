using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StoreDBAcess.Models
{
	public class SalesHistory
	{
		#region Properties
		[Key]
		private int salesHistoryId;

		public int SalesHistoryId
		{
			get { return salesHistoryId; }
			set { salesHistoryId = value; }
		}
		#endregion

		#region Constructors
		public SalesHistory() { }
		#endregion

		#region Methods

		#endregion
	}
}
