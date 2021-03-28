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
    class PlayerController : ControllerBase
    {

        public PlayerService playerService;

        public PlayerController(PlayerService _playerService)
        {
            playerService = _playerService;
        }

        [HttpGet]
        [Route("{playerId}")]
        public DTOPlayer GetPlayer(int id)
        {
            return playerService.GetEntity(id);
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<DTOPlayer> GetPlayers()
        {
            return playerService.GetEntities();
        }

        [HttpPut]
        [Route("")]
        public void AddPlayer(DTOPlayer player)
        {
            playerService.CreateEntity(player);
        }

        public void Dispose()
        {
            playerService.Dispose();
            this.Dispose();
        }
    }
}
