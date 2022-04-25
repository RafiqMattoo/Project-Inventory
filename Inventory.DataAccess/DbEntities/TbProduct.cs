using System;
using System.Collections.Generic;

#nullable disable

namespace Inventory.DataAccess
{
    public partial class TbProduct
    {
        public int ProductId { get; set; }
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductManufacturer { get; set; }
        public string ProductConfiguration { get; set; }
        public int? TotalProducts { get; set; }
        public int? AvailableProducts { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual TbCategory Category { get; set; }
        public virtual TbSubCategory SubCategory { get; set; }
    }
}
