using Exiled.Events.EventArgs;
using MEC;
using Surface_Tension.API;
using Surface_Tension.API.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Surface_Tension
{
    internal class EventHandlers
    {
        private readonly SurfaceTensionAPI _api;
        private List<CoroutineHandle> _coroutines;

        public EventHandlers()
        {
            _coroutines = new List<CoroutineHandle>();
            _api = new SurfaceTensionAPI();
        }

        public void OnRoundStart()
        {
            foreach (CoroutineHandle handle in _coroutines)
                Timing.KillCoroutines(handle);
            _coroutines.Clear();

            _api.IsDetonated = false;
        }

        public void OnRoundEnd(EndingRoundEventArgs ev)
        {
            foreach (CoroutineHandle handle in _coroutines)
                Timing.KillCoroutines(handle);
            _coroutines.Clear();
        }

        public void OnWarheadDetonation()
        {
            if (_api.IsDetonated)
                return;

            _api.IsDetonated = true;

            foreach (TeamDamage damage in Plugin.Instance.Config.DamageConfig)
            {
                Timing.CallDelayed(Mathf.Clamp(damage.Delay, 0f, 300f), () =>
                {
                    _coroutines.Add(Timing.RunCoroutine(_api.DealTeamDamage(damage.Team)));
                    _api.AnnounceRadiation(damage.Team);
                });
            }
        }
    }
}