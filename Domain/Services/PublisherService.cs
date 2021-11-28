using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Enums;
using Domain.IRepositories;
using Domain.IServices;
using Domain.Models;

namespace Domain.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _Repository;
        private readonly IMapper _Mapper;
        private readonly IUserRepository _userRepository;

        public PublisherService(IPublisherRepository publisherR,IUserRepository userRepository, IMapper mapper)
        {
            _Repository = publisherR;
            _Mapper = mapper;
            this._userRepository = userRepository;
        }

        public async Task<bool> AddNewPublisher(PublisherVM publisher)
        {
            if (publisher != null)
            {
                UserVM user = _userRepository.getUserByID(publisher.userID).Result;
                long userId = -1;
                if (user != null)
                    userId = user.PermissionID;
                if (userId == ((int)(UserLookups.MaintainEntities)) + 1)
                    return await _Repository.AddNewPublisherAsync(publisher);
            }
            return false;
        }

        public async Task<bool> DeletePublisher(long id)
        {
            PublisherVM publisher = GetPublisherById(id).Result;
            if (publisher != null)
            {
                UserVM user = _userRepository.getUserByID(publisher.userID).Result;
                long userId = -1;
                if (user != null)
                    userId = user.PermissionID;
                if (userId == ((int)(UserLookups.MaintainEntities)) + 1)
                    return await _Repository.DeletePublisher(id);
            }
            return false;
        }

        public Task<IEnumerable<PublisherVM>> GetAllPublishers()
        {
            return _Repository.GetAllPublishers();
        }

        public Task<PublisherVM> GetPublisherById(long id)
        {
            return _Repository.GetPublisherById(id);
        }

        public async Task<bool> UpdatePublisher(long id, PublisherVM publisher)
        {
            if (publisher != null)
            {
                UserVM user = _userRepository.getUserByID(publisher.userID).Result;
                long userId = -1;
                if (user != null)
                    userId = user.PermissionID;
                if (userId == ((int)(UserLookups.MaintainEntities)) + 1)
                    return await _Repository.UpdatePublisher(id, publisher);
            }
            return false;
        }
    }
}
