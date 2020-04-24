using System.Collections.Generic;

namespace rsl_challenge.Models
{
    public class ApiQuery
    {
        public string CompanyId { get; set; }
        public string MaxDrawCountPerProduct { get; set; }
        public string [] OptionalProductFilter { get; set; }
    }
}
