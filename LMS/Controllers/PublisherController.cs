using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.IServices;
using Domain.Models;
namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController: Controller
    {
        private readonly IPublisherS _service;

        PublisherController(IPublisherS service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<IEnumerable<PublisherVM>> GetAllPublishers()
        {
            var items = _service.GetAllPublishers();
            return items;
        }

        [HttpGet("{id}")]
        public Task<PublisherVM> GetPublisherById(long id)
        {
            return _service.GetPublisherById(id);
        }

        [HttpDelete("{id}")]
        public Task<bool> DeletePublisher(long id)
        {
            return _service.DeletePublisher(id);
        }

        [HttpPut("{id}")]
        public Task<bool> UpdatePublisher(long id, PublisherVM publisher)
        {
            return _service.UpdatePublisher(id, publisher);
        }

        [HttpPost]
        public Task<bool> AddNewPublisher(PublisherVM publisher)
        {
            return _service.AddNewPublisher(publisher);
        }
    }
    
}
