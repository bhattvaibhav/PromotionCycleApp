using PromotionCycleApp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionCycleApp.Infrastructure.Interface
{
    public interface IProductMasterSKU
    {
        List<ProductSKUMaster> AddSKU(List<string> skuList);
    }
}
