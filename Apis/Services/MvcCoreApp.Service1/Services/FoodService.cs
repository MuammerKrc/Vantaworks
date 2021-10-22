using AutoMapper;
using MongoDB.Driver;
using MvcCoreApp.Service1.ConfigurationOptions.Abstracts;
using MvcCoreApp.Service1.Dtos.FoodDtos;
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
    public class FoodService : IFoodService
    {
        private readonly IMongoCollection<Food> _foodCollection;
        private readonly IMapper mapper;

        public FoodService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            MongoClient client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _foodCollection = database.GetCollection<Food>(databaseSettings.FoodCollectionName);
            if(_foodCollection.Find(i=>true).ToList().Count==0)
            {
                IMongoCollection<Category> _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
                List<string> categoryIds = new List<string>();
                _categoryCollection.Find(i => true).ToList().ForEach(i => categoryIds.Add(i.Id));
                _foodCollection.InsertMany(new RecipeSeedData(categoryIds).Foods);
            }
            this.mapper = mapper;
        }

        public async Task<Response<FoodDto>> CreateAsync(FoodCreateDto foodDto)
        {
            var food = mapper.Map<Food>(foodDto);
            await _foodCollection.InsertOneAsync(food);
            return Response<FoodDto>.Success(mapper.Map<FoodDto>(food), 200);
        }

        public async Task<Response<List<FoodDto>>> GetProductWithCategoryId(string categoryId)
        {
            var results = await _foodCollection.Find(i => i.CategoryId == categoryId).ToListAsync();
            return Response<List<FoodDto>>.Success(mapper.Map<List<FoodDto>>(results),200);
        }
    }
}
