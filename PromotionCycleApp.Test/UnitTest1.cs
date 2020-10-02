using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionCycleApp.Infrastructure.Interface;
using PromotionCycleApp.Infrastructure.Service;
using System.Collections.Generic;
using System.Linq;

namespace PromotionCycleApp.Test
{
    public abstract class Base
    {
        protected abstract IProductMasterSKU GetObject();
    }

    [TestClass]
    public class UnitTest1 : Base
    {
        protected override IProductMasterSKU GetObject()
        {
            return new ProductMasterSKUService();
        }

        [TestMethod]
        public void OneSKUForALL()
        {
            IProductMasterSKU productSku = GetObject();

            int totalPrice = 100;
            var skuList = new List<string>();
            skuList.Add("A");
            skuList.Add("B");
            skuList.Add("C");

            var result = productSku.AddSKU(skuList);
            Assert.IsNotNull(result);

            var list = productSku.SKUPrice(result);
            Assert.IsNotNull(list);

            Assert.AreEqual(totalPrice, list.Sum(x => x.Price));
        }

        [TestMethod]
        public void MultipleA_BSKU()
        {
            IProductMasterSKU productSku = GetObject();

            int totalPrice = 370;

            var skuList = new List<string>();
            var item = new string[]
            {
                "A","A","A","A","A",
                "B","B","B","B","B",
                "C"
            };

            skuList.AddRange(item);

            var result = productSku.AddSKU(skuList);
            Assert.IsNotNull(result);

            var list = productSku.SKUPrice(result);
            Assert.IsNotNull(list);

            Assert.AreEqual(totalPrice, list.Sum(x => x.Price));
        }


        [TestMethod]
        public void MultipleA_B_C_DSKU()
        {
            IProductMasterSKU productSku = GetObject();

            int totalPrice = 280;

            var skuList = new List<string>();
            var item = new string[]
            {
                "A","A","A",
                "B","B","B","B","B",
                "C","D"
            };

            skuList.AddRange(item);

            var result = productSku.AddSKU(skuList);
            Assert.IsNotNull(result);

            var list = productSku.SKUPrice(result);
            Assert.IsNotNull(list);

            Assert.AreEqual(totalPrice, list.Sum(x => x.Price));
        }

        [TestMethod]
        public void OnlyCValue()
        {
            IProductMasterSKU productSku = GetObject();

            int totalPrice = 270;

            var skuList = new List<string>();
            var item = new string[]
            {
                "A","A","A",
                "B","B","B","B","B",
                "C"
            };

            skuList.AddRange(item);

            var result = productSku.AddSKU(skuList);
            Assert.IsNotNull(result);

            var list = productSku.SKUPrice(result);
            Assert.IsNotNull(list);

            Assert.AreEqual(totalPrice, list.Sum(x => x.Price));
        }
    }
}
