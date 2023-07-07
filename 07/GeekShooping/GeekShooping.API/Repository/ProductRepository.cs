using AutoMapper;
using GeekShooping.ProductAPI.Data.ValueObjects;
using GeekShooping.ProductAPI.Model;
using GeekShooping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _mySqlContext;
        private IMapper _mapper;

        public ProductRepository(MySqlContext mySqlContext, IMapper mapper)
        {
            _mySqlContext = mySqlContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _mySqlContext.Products.ToListAsync();

            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            var product = await _mySqlContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Create(ProductVO productVO)
        {
            var product = _mapper.Map<Product>(productVO);

            _mySqlContext.Products.Add(product);
            await _mySqlContext.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO productVO)
        {
            var product = _mapper.Map<Product>(productVO);

            _mySqlContext.Products.Update(product);
            await _mySqlContext.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _mySqlContext.Products.FirstOrDefaultAsync(p => p.Id == id);

                if (product == null) return false;

                _mySqlContext.Products.Remove(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
