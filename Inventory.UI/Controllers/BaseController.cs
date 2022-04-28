using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Core
{
    [Route("api/[controller]")]
    [Controller]
    public class BaseController : ControllerBase
    {
    }
}
