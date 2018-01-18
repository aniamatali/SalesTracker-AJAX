using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SalesTracker.Models
{
	[Table("Sales")]
	public class Sale
	{
		[Key]
		public int SaleId { get; set; }
		public int SalesAssociateId { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
		public virtual SalesAssociate SalesAssociate { get; set; }

		public override bool Equals(System.Object otherSale)
		{
			if (!(otherSale is Sale))
			{
				return false;
			}
			else
			{
				Sale newItem = (Sale)otherSale;
				return this.SaleId.Equals(newItem.SaleId);
			}
		}

		public override int GetHashCode()
		{
			return this.SaleId.GetHashCode();
		}

	}
}
