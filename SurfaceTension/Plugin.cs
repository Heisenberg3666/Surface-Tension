using Exiled.API.Features;
using System;
using Server = Exiled.Events.Handlers.Server;
using Warhead = Exiled.Events.Handlers.Warhead;

namespace Surface_Tension
{
    public class Plugin : Plugin<Config>
    {
        private EventHandlers _events;

        public static Plugin Instance;

        public override string Name { get; } =  "SurfaceTension";
        public override string Author { get; } = "Holmium67, updated by Heisenberg3666";
        public override Version Version { get; } = new Version(3, 0, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 2, 0);

        public override void OnEnabled()
        {
            Instance = this;
            _events = new EventHandlers();
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            _events = null;
            Instance = null;
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            Server.RoundStarted += _events.OnRoundStart;
            Server.EndingRound += _events.OnRoundEnd;
            Warhead.Detonated += _events.OnWarheadDetonation;
        }

        public void UnregisterEvents()
        {
            Server.RoundStarted -= _events.OnRoundStart;
            Server.EndingRound -= _events.OnRoundEnd;
            Warhead.Detonated -= _events.OnWarheadDetonation;
        }
    }
}