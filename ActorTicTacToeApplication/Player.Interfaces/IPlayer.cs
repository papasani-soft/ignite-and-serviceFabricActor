﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Remoting.FabricTransport;
using Microsoft.ServiceFabric.Services.Remoting;

[assembly: FabricTransportActorRemotingProvider(RemotingListenerVersion = RemotingListenerVersion.V2_1, RemotingClientVersion = RemotingClientVersion.V2_1)]
namespace Player.Interfaces
{
    /// <summary>
    /// This interface defines the methods exposed by an actor.
    /// Clients use this interface to interact with the actor that implements it.
    /// </summary>
    public interface IPlayer : IActor
    {
        Task<bool> JoinGameAsync(ActorId gameId, string playerName);
        Task<bool> MakeMoveAsync(ActorId gameId, int x, int y);
        Task<int> GetCountAsync(CancellationToken cancellationToken);
        Task SetCountAsync(int count, CancellationToken cancellationToken);
    }
}
