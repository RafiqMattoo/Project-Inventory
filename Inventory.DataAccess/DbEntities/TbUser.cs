using System;
using System.Collections.Generic;

#nullable disable

namespace Inventory.DataAccess
{
    public partial class TbUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserDesignation { get; set; }
        public DateTime UserDateOfBirth { get; set; }
        public string UserAddress { get; set; }
        public string UserGender { get; set; }
        public string UserPassword { get; set; }
    }
}
