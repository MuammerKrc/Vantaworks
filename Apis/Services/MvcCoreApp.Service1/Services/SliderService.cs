using AutoMapper;
using MongoDB.Driver;
using MvcCoreApp.Service1.ConfigurationOptions.Abstracts;
using MvcCoreApp.Service1.Dtos.SliderDtos;
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
    public class SliderService:ISliderService
    {
        private readonly IMongoCollection<Slider> _sliderCollection;
        private readonly IMapper _mapper;
        public SliderService( IMapper mapper,IDatabaseSettings databaseSettings)
        {
            MongoClient client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _sliderCollection = database.GetCollection<Slider>(databaseSettings.SliderCollectionName);
            _mapper = mapper;
            if(_sliderCollection.Find(i=>true).ToList().Count==0)
            {
                _sliderCollection.InsertMany(new SliderSeedData().Sliders);
            }
        }

        public async Task<Response<List<SliderDto>>> GetAllAsync()
        {
            var result = await _sliderCollection.Find(i => true).ToListAsync();

            return Response<List<SliderDto>>.Success(_mapper.Map<List<SliderDto>>(result), 200);
        }
    }
}
