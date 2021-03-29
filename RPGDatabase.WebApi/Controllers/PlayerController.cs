using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RPGDatabase.WebApi.DTO;
using RPGDatabase.BLL.Implementations;
using RPGDatabase.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    class PlayerController : ControllerBase
    {
        private ILogger<PlayerController> logger;
        private PlayerService playerService;
        private IMapper mapper;

        public PlayerController(PlayerService _playerService, ILogger<PlayerController> _logger, IMapper _mapper)
        {
            playerService = _playerService;
            logger = _logger;
            mapper = _mapper;
        }

        [HttpGet]
        [Route("{playerId}")]
        public DTOPlayer GetPlayer(int id)
        {
            logger.LogTrace($"{nameof(this.GetPlayer)} called");

            return mapper.Map<DTOPlayer>(playerService.GetEntity(new DomainPlayerIdentityModel(id)));
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<DTOPlayer> GetPlayers()
        {
            logger.LogTrace($"{nameof(this.GetPlayers)} called");

            return mapper.Map<IEnumerable<DTOPlayer>>(playerService.GetEntities());
        }

        [HttpPut]
        [Route("")]
        public DTOPlayer PutPlayer(DTOPlayerCreate player)
        {
            logger.LogTrace($"{nameof(this.PutPlayer)} called");

            var result = playerService.CreateEntity(mapper.Map<DomainPlayerUpdateModel>(player));

            return mapper.Map<DTOPlayer>(result);
        }

        [HttpPatch]
        [Route("")]
        public DTOPlayer PatchPlayer(DTOPlayerCreate player)
        {
            logger.LogTrace($"{nameof(this.PatchPlayer)} called");

            var result = playerService.UpdateEntity(mapper.Map<DomainPlayerUpdateModel>(player));

            return mapper.Map<DTOPlayer>(result);
        }
    }
}
