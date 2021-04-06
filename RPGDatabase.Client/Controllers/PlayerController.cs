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
    public class PlayerController : Controller
    {
        private IPlayerService service;

        public PlayerController(IPlayerService _ps) => service = _ps;
        public async Task<IActionResult> Index()
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
                DTOPlayerCreate player = new DTOPlayerCreate()
                {
                    Name = collection["Name"],
                    Level = int.Parse(collection["Level"]),
                    Money = int.Parse(collection["Money"])
                };

                var playerDTO = await service.CreateEntity(player);
                return View("Details", playerDTO);
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
                DTOPlayer player = new DTOPlayer()
                {
                    ID = id,
                    Name = collection["Name"],
                    Level = int.Parse(collection["Level"]),
                    Money = int.Parse(collection["Money"])
                };

                var playerDTO = await service.UpdateEntity(player);
                return View("Details", playerDTO);
            }
            catch
            {
                return View();
            }
        }
    }
}
