using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
namespace Domain.IServices
{
    public interface IPublisherService
    {
        Task<PublisherVM> GetPublisherById(long id);
        Task<IEnumerable<PublisherVM>> GetAllPublishers();
        Task<bool> AddNewPublisher(PublisherVM publisher);

        Task<bool> UpdatePublisher(long id, PublisherVM publisher);
      
        Task<bool> DeletePublisher(long id);
    }
}
