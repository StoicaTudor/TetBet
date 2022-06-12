using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using AutoMapper;
using TetBet.Infrastructure.Entities;
using TetBet.Server.Services.BetsFetcher.Entities;

namespace TetBet.Server.Services.BetsFetcher
{
    public class BetsFetcher : IBetsFetcher
    {
        private readonly IMapper _genericBetMapper;

        public BetsFetcher(IMapper genericBetMapper)
        {
            _genericBetMapper = genericBetMapper;
        }

        public IEnumerable<GenericBet> Fetch()
        {
            // TODO: find a way to get the current working file and use it, do not hard code this shit like that
            string betsFileContent =
                File.ReadAllText(
                    "/home/citadin/Documents/Facultate/A3S2/SD/Lab/FinalProject/TetBet.Server/Services/BetsFetcher/Resources/Bets.json");

            ResourcesBetsConfiguration resourcesBetsConfiguration =
                JsonSerializer.Deserialize<ResourcesBetsConfiguration>(betsFileContent);

            if (resourcesBetsConfiguration == null)
                throw new Exception("Bets file is null");

            return _genericBetMapper
                .Map<ResourcesBetsConfiguration, ApplicationBets>(resourcesBetsConfiguration)
                .GenericBets;
        }
    }
}