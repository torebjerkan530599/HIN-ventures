﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HIN_ventures.Business.Repositories.IRepositories;
using HIN_ventures.DataAccess.Data;
using HIN_ventures.DataAccess.Entities;
using HIN_ventures.Models;

namespace HIN_ventures.Business.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public RatingRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<RatingDto> Create(RatingDto rating)
        {
            try
            {
                var newRating = _mapper.Map<RatingDto, Rating>(rating);

                var result = await _db.Ratings.AddAsync(newRating);
                await _db.SaveChangesAsync();
                return _mapper.Map<Rating, RatingDto>(result.Entity);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        

        public Task<IEnumerable<RatingDto>> GetAllRatings()
        {
            throw new NotImplementedException();
        }

        public Task<RatingDto> GetRating(int ratingId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRating(int ratingId)
        {
            throw new NotImplementedException();
        }
    }
}
