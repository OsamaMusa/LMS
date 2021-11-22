using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.IServices;
using Domain.Models;

namespace Domain.Services
{
   public class PublisherS : IPublisherS
    {
        public Task<bool> AddNewPublisher(PublisherVM publisher)
        {
            throw new NotImplementedException();
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
