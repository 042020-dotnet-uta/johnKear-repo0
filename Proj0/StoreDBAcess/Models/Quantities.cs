using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreDBAcess.Models
{
	public class Quantities
	{
		#region Fields
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int QuantitiesId { get; set; }

		[Required]
		public int Quantity { get; set; }
		#endregion

		#region Constructors
		public Quantities() { }
		#endregion

		#region Methods

		#endregion
	}
}
