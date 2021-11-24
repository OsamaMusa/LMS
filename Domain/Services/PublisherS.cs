using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.IRepositories;
using Domain.IServices;
using Domain.Models;

namespace Domain.Services
{
    public class PublisherS : IPublisherService
    {
        private readonly IPublisherRepository _Repository;
        private readonly IMapper _Mapper;

        public PublisherS(IPublisherRepository publisherR, IMapper mapper)
        {
            _Repository = publisherR;
            _Mapper = mapper;
        }

        public Task<bool> AddNewPublisher(PublisherVM publisher)
        {
            return _Repository.AddNewPublisherAsync(publisher);
        }

        public Task<bool> DeletePublisher(long id)
        {
            return _Repository.DeletePublisher(id);
        }

        public Task<IEnumerable<PublisherVM>> GetAllPublishers()
        {
            return _Repository.GetAllPublishers();
        }

        public Task<PublisherVM> GetPublisherById(long id)
        {
            return _Repository.GetPublisherById(id);
        }

        public Task<bool> UpdatePublisher(long id, PublisherVM publisher)
        {
            return _Repository.UpdatePublisher(id, publisher);
        }
    }
}
