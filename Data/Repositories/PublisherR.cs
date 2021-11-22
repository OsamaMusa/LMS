using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.IRepositories;
using Domain.Models;
using AutoMapper;
using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PublisherR : IPublisherR
    {
        private readonly LMSContext _context;
        private readonly IMapper _mapper;
        public PublisherR(LMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
        }
        public async Task<bool> AddNewPublisherAsync(PublisherVM publisher)
        {
            await _context.Publishers.AddAsync(_mapper.Map < Publisher > (publisher));
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> DeletePublisher(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PublisherVM>> GetAllPublishers()
        {
            throw new NotImplementedException();
        }

        public Task<PublisherVM> GetPublisherById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePublisher(long id, PublisherVM publisher)
        {
            throw new NotImplementedException();
        }
    }


}
