using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RPGDatabase.WebApi.DTO;
using RPGDatabase.BLL.Implementations;
using RPGDatabase.BLL.Interfaces;
using RPGDatabase.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    class ItemController : ControllerBase
    {
        private ILogger<ItemController> logger;
        private IItemService itemService;
        private IMapper mapper;

        public ItemController(ItemService _itemService, ILogger<ItemController> _logger, IMapper _mapper)
        {
            itemService = _itemService;
            logger = _logger;
            mapper = _mapper;
        }

        [HttpGet]
        [Route("{itemId}")]
        public DTOItem GetItem(int id)
        {
            logger.LogTrace($"{nameof(this.GetItem)} called");

            return mapper.Map<DTOItem>(itemService.GetEntity(new DomainItemIdentityModel(id)));
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<DTOItem> GetItems()
        {
            logger.LogTrace($"{nameof(this.GetItems)} called");

            return mapper.Map<IEnumerable<DTOItem>>(itemService.GetEntities());
        }

        [HttpPut]
        [Route("")]
        public DTOItem PutItem(DTOItemCreate item)
        {
            logger.LogTrace($"{nameof(this.PutItem)} called");

            var result = itemService.CreateEntity(mapper.Map<DomainItemUpdateModel>(item));

            return mapper.Map<DTOItem>(result);
        }

        [HttpPatch]
        [Route("")]
        public DTOItem PatchItem(DTOItemCreate item)
        {
            logger.LogTrace($"{nameof(this.PatchItem)} called");

            var result = itemService.UpdateEntity(mapper.Map<DomainItemUpdateModel>(item));

            return mapper.Map<DTOItem>(result);
        }
    }
}
