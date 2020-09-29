using PromotionCycleApp.Infrastructure.Domain;
using PromotionCycleApp.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionCycleApp.Infrastructure.Service
{
    public class ProductMasterSKUService : IProductMasterSKU
    {
        Dictionary<string, int> SKUMasterData = new Dictionary<string, int>();
        public ProductMasterSKUService()
        {
            SKUMasterData.Add("A", 50);
            SKUMasterData.Add("B", 30);
            SKUMasterData.Add("C", 20);
            SKUMasterData.Add("D", 15);
        }

        public List<ProductSKUMaster> AddSKU(List<string> skuList)
        {
            var productSkuMaster = new List<ProductSKUMaster>();

            foreach(var sku in skuList)
            {
                productSkuMaster.Add(new ProductSKUMaster(sku, SKUMasterData[sku]));
            }

            return productSkuMaster;
        }
    }
}
