using Business.Interfaces;
using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public void Add(Product t)
        {
            _productRepository.Add(t);

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            return _productRepository.Get(id);

        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Update(Product t)
        {
            _productRepository.Update(t);

        }
    }
}
