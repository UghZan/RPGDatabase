using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGDatabase.Client.Models;
using RPGDatabase.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGDatabase.Client.Controllers
{
    public class ItemController : Controller
    {
        private IItemService service { get; }
        public ItemController(IItemService _is) => service = _is;

        public async Task<ActionResult> IndexAsync()
        {
            return View(await service.GetEntities());
        }

        public async Task<ActionResult> DetailsAsync(int id)
        {
            return View(await service.GetEntity(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(IFormCollection collection)
        {
            try
            {
                DTOItemCreate item = new DTOItemCreate()
                {
                    Name = collection["Name"],
                    Type = (ItemType)Enum.Parse(typeof(ItemType), collection["Type"]),
                    Price = int.Parse(collection["Price"]),
                    Rarity = int.Parse(collection["Rarity"]),
                    PlayerId = int.Parse(collection["PlayerId"])
                };

                var itemDTO = await service.CreateEntity(item);
                return View("Details", itemDTO);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, IFormCollection collection)
        {
            try
            {
                DTOItem item = new DTOItem()
                {
                    ID = id,
                    Name = collection["Name"],
                    Type = (ItemType)Enum.Parse(typeof(ItemType), collection["Type"]),
                    Price = int.Parse(collection["Price"]),
                    Rarity = int.Parse(collection["Rarity"]),
                    PlayerId = int.Parse(collection["PlayerId"]),
                };

                var itemDTO = await service.UpdateEntity(item);
                return View("Details", itemDTO);
            }
            catch
            {
                return View();
            }
        }
    }
}

