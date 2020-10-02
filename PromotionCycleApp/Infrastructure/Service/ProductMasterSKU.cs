using PromotionCycleApp.Infrastructure.Domain;
using PromotionCycleApp.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PromotionCycleApp.Infrastructure.Service
{
    public class ProductMasterSKUService : IProductMasterSKU
    {
        Dictionary<string, List<int>> SKUMasterData = new Dictionary<string, List<int>>();

        /// <summary>
        /// Constructor for creating the default values in dictionary
        /// it has two parameters at first place price and second is promotion cycle calc value
        /// </summary>
        public ProductMasterSKUService()
        {
            SKUMasterData.Add("A", new List<int> { 50, 130 });
            SKUMasterData.Add("B", new List<int> { 30, 45 });
            SKUMasterData.Add("C", new List<int> { 20, 30 });
            SKUMasterData.Add("D", new List<int> { 15, 30 });
        }

        public List<ProductSKUMaster> AddSKU(List<string> skuList)
        {
            var productSkuMaster = new List<ProductSKUMaster>();
            foreach (var sku in skuList)
            {
                productSkuMaster.Add(new ProductSKUMaster(sku, SKUMasterData[sku][0]));
            }

            return productSkuMaster;
        }

        private int GetPriceValue(string id, int price,
            List<ProductSKUMaster> masterList, int promotionValue, bool bothC_DExist)
        {
            var orderCount = masterList.Count;
            if (id == "A")
            {
                return (orderCount % 3 * price) + (orderCount / 3) * promotionValue;
            }

            else if (id == "B")
            {
                return (orderCount % 2 * price) + (orderCount / 2) * promotionValue;
            }

            else if (bothC_DExist)
            {
                if (id == "C")
                {
                    return 0;
                }
                return (orderCount % 1 * price) + (orderCount / 1) * promotionValue;
            }

            return orderCount * price;
        }

        public List<SKUResponse> SKUPrice(List<ProductSKUMaster> productSKUList)
        {
            bool bothC_DExist= false;

            if (productSKUList.Count(x => x.ID == "C") == 1 
                && productSKUList.Count(x => x.ID == "D") == 1)
            {
                bothC_DExist = true;
            }

            var result = productSKUList.GroupBy(
                p => p.ID,
                (k, g) => new SKUResponse
                {
                    ID = k,
                    ProductSKUMaster = g.ToList(),
                    Price = GetPriceValue(k, SKUMasterData[k][0], g.ToList(), 
                            SKUMasterData[k][1], bothC_DExist)
                }).ToList();

            return result;
        }
    }
}
