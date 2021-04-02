using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RPGDatabase.BLL.Interfaces;
using RPGDatabase.DomainModel.Models;
using RPGDatabase.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGDatabase.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ILogger<ItemController> logger;
        private IItemService itemService;
        private IMapper mapper;

        public ItemController(IItemService _itemService, ILogger<ItemController> _logger, IMapper _mapper)
        {
            itemService = _itemService;
            logger = _logger;
            mapper = _mapper;
        }

        [HttpGet]
        [Route("{itemId}")]
        public DTOItem Get(int itemId)
        {
            logger.LogTrace($"{nameof(this.Get)} called");

            return mapper.Map<DTOItem>(itemService.GetEntity(new DomainItemIdentityModel(itemId)));
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<DTOItem> Get()
        {
            logger.LogTrace($"{nameof(this.Get)} called");

            return mapper.Map<IEnumerable<DTOItem>>(itemService.GetEntities());
        }

        [HttpPut]
        [Route("")]
        public DTOItem Put(DTOItemCreate item)
        {
            logger.LogTrace($"{nameof(this.Put)} called");

            var result = itemService.CreateEntity(mapper.Map<DomainItemUpdateModel>(item));

            return mapper.Map<DTOItem>(result);
        }

        [HttpPatch]
        [Route("")]
        public DTOItem Patch(DTOItem item)
        {
            logger.LogTrace($"{nameof(this.Patch)} called");

            var result = itemService.UpdateEntity(mapper.Map<DomainItemUpdateModel>(item));

            return mapper.Map<DTOItem>(result);
        }
    }
}
