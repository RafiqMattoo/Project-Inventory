using System;
using System.Collections.Generic;

#nullable disable

namespace Inventory.DataAccess
{
    public partial class TbSubCategory
    {
        public TbSubCategory()
        {
            TbProducts = new HashSet<TbProduct>();
        }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryDescription { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TbCategory Category { get; set; }
        public virtual ICollection<TbProduct> TbProducts { get; set; }
    }
}
