using AutoMapper;
using BusinessLogicLayer.IInterfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DTOs.ProductDtos;

namespace BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, 
                            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddProductAsync(AddProductDo addProductDo)
        {
            var product = _mapper.Map<Product>(addProductDo);
            await _unitOfWork.ProductInterface.AddEntityAsync(product);
            await _unitOfWork.SaveChangesAsync();   
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.ProductInterface.GetEntityByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException(nameof(id));
            await _unitOfWork.CategoryInterface.DeleteEntityAsyanc(product.Id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.ProductInterface.GetAllEntitiesAsync();
            return products.Select(c => _mapper.Map<ProductDto>(c));
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductInterface.GetEntityByIdAsync(id);
            if(product == null)
                throw new KeyNotFoundException(nameof(product));

            return _mapper.Map<ProductDto>(product); 
        }

        public async Task<IEnumerable<ProductDto>> GetProductWithOrderItemsAsync()
        {
            var products = await _unitOfWork.ProductInterface.GetAllProductsWithOrderItems();
            return products.Select(c => _mapper.Map<ProductDto>(c));
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = await _unitOfWork.ProductInterface.GetEntityByIdAsync(updateProductDto.Id);
            if (product == null)
                throw new KeyNotFoundException(nameof(product));

            _mapper.Map(updateProductDto, product);
            await _unitOfWork.ProductInterface.UpdateEntityAsyanc(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
