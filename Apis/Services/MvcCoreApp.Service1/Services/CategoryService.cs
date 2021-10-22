using AutoMapper;
using MongoDB.Driver;
using MvcCoreApp.Service1.ConfigurationOptions.Abstracts;
using MvcCoreApp.Service1.Dtos.CategoryDtos;
using MvcCoreApp.Service1.Models;
using MvcCoreApp.Service1.SeedData;
using MvcCoreApp.Service1.ServiceAbstracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Service1.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
            if(_categoryCollection.Find(i=>true).ToList().Count==0)
            {
                _categoryCollection.InsertMany(new CategorySeedData().Categories);
            }
        }

        public async Task<Response<NoContent>> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            var category = _mapper.Map<Category>(categoryCreateDto);
            await _categoryCollection.InsertOneAsync(category);
            return Response<NoContent>.Success(203);
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(i => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

    }
}
