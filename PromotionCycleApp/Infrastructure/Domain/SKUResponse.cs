using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PromotionCycleApp.Infrastructure.Domain
{
    public class SKUResponse
    {
        public string ID { get; set; }
        public int Price { get; set; }
        public List<ProductSKUMaster> ProductSKUMaster { get; set; }        
    }

}
