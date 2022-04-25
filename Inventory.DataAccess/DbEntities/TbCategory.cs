using System;
using System.Collections.Generic;

#nullable disable

namespace Inventory.DataAccess
{
    public partial class TbCategory
    {
        public TbCategory()
        {
            TbProducts = new HashSet<TbProduct>();
            TbSubCategories = new HashSet<TbSubCategory>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<TbProduct> TbProducts { get; set; }
        public virtual ICollection<TbSubCategory> TbSubCategories { get; set; }
    }
}
