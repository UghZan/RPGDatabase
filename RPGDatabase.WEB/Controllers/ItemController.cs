using Microsoft.AspNetCore.Mvc;
using RPGDatabase.BLL.DTO;
using RPGDatabase.BLL.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    class ItemController : ControllerBase
    {
        public ItemService itemService;

        public ItemController(ItemService _itemService)
        {
            itemService = _itemService;
        }

        [HttpGet]
        [Route("{itemId}")]
        public DTOItem GetItem(int id)
        {
            return itemService.GetEntity(id);
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<DTOItem> GetItems()
        {
            return itemService.GetEntities();
        }

        [HttpPut]
        [Route("")]
        public void AddItem(DTOItem item)
        {
            itemService.CreateEntity(item);
        }

        public void Dispose()
        {
            itemService.Dispose();
            this.Dispose();
        }
    }
}
