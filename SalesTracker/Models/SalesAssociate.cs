using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SalesTracker.Models
{
    [Table("SalesAssociates")]
    public class SalesAssociate
    {
        [Key]
        public int SalesAssociateId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ApplicationUser User { get; set; }

		public override bool Equals(System.Object otherSalesAssociate)
		{
			if (!(otherSalesAssociate is SalesAssociate))
			{
				return false;
			}
			else
			{
				SalesAssociate newItem = (SalesAssociate)otherSalesAssociate;
				return this.SalesAssociateId.Equals(newItem.SalesAssociateId);
			}
		}

		public override int GetHashCode()
		{
			return this.SalesAssociateId.GetHashCode();
		}

    }
}
