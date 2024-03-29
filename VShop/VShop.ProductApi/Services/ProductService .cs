using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private IProductRepository _productRepository;

    public ProductService(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        var productsEntity = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDto>>(productsEntity);
    }
    public async Task<ProductDto> GetProductById(int id)
    {
        var productEntity = await _productRepository.GetById(id);
        return _mapper.Map<ProductDto>(productEntity);
    }
    public async Task AddProduct(ProductDto productDto)
    {
        var productEntity = _mapper.Map<Product>(productDto);
        await _productRepository.Create(productEntity);
        productDto.Id = productEntity.Id;
    }
    public async Task UpdateProduct(ProductDto productDto)
    {
        var categoryEntity = _mapper.Map<Product>(productDto);
        await _productRepository.Update(categoryEntity);
    }
    public async Task RemoveProduct(int id)
    {
        var productEntity = await _productRepository.GetById(id);
        await _productRepository.Delete(productEntity.Id);
    }
}