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

namespace RPGDatabase.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private ILogger<PlayerController> logger;
        private IPlayerService playerService;
        private IMapper mapper;

        public PlayerController(IPlayerService _playerService, ILogger<PlayerController> _logger, IMapper _mapper)
        {
            playerService = _playerService;
            logger = _logger;
            mapper = _mapper;
        }

        [HttpGet]
        [Route("{playerId}")]
        public DTOPlayer GetPlayer(int playerId)
        {
            logger.LogTrace($"{nameof(this.GetPlayer)} called");

            return mapper.Map<DTOPlayer>(playerService.GetEntity(new DomainPlayerIdentityModel(playerId)));
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
        public DTOPlayer PatchPlayer(DTOPlayer player)
        {
            logger.LogTrace($"{nameof(this.PatchPlayer)} called");

            var result = playerService.UpdateEntity(mapper.Map<DomainPlayerUpdateModel>(player));

            return mapper.Map<DTOPlayer>(result);
        }
    }
}
