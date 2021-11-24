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
using System.Linq;

namespace Data.Repositories
{
    public class PublisherR : IPublisherR
    {
        private readonly LMSContext _context;
        private readonly IMapper _mapper;
        public PublisherR(LMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddNewPublisherAsync(PublisherVM publisher)
        {
            await _context.Publishers.AddAsync(_mapper.Map<Publisher>(publisher));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePublisher(long id)
        {
            Publisher item = GetExistingPublisher(id).FirstOrDefault();
            if (item != null)
            {
                _context.Publishers.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<IEnumerable<PublisherVM>> GetAllPublishers()
        {
            return _mapper.Map<List<Publisher>, List<PublisherVM>>(_context.Publishers.Include(e=>e.Books).ToList());
        }

        public async Task<PublisherVM> GetPublisherById(long id)
        {
            return _mapper.Map<PublisherVM>(GetExistingPublisher(id).FirstOrDefault());
        }


        public async Task<bool> UpdatePublisher(long id, PublisherVM publisher)
        {
            Publisher item = GetExistingPublisher(id).FirstOrDefault();
            if (item != null)
            {
                item = _mapper.Map<Publisher>(publisher);
                _context.Publishers.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }



        private IQueryable<Publisher> GetExistingPublisher(long ID) =>
       _context.Publishers.Where(r => r.ID == ID).Include(e => e.Books).AsNoTracking();
    }


}
