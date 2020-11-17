using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _02_Generics.Samples.Covariance
{
    public class ProductBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductA : ProductBase
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }

    public class ProductB : ProductA
    {
        public string ExtraTags { get; set; }
    }
    public interface IProductSotrage<T> where T : ProductBase
    {
        void AddProduct(T product);
        List<decimal> GetPrices();
    }

    public class ProductStorage<T> : IProductSotrage<T> where T : ProductBase
    {
        public void AddProduct(T product) { }
        public List<decimal> GetPrices() { return new List<decimal>() { 1, 2, 3 }; }
    }


    public class CovarianceProductSample
    {
        public decimal GetTotalPrices(IProductSotrage<ProductBase> productStorage)
        {
            return productStorage.GetPrices().Sum();
        }
        public void CovarianceProductSampleTest()
        {
            IProductSotrage<ProductA> productStorageA = new ProductStorage<ProductA>();
            
        }

    }
}
