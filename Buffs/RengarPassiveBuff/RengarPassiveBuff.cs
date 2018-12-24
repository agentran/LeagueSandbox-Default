using GameServerCore.Enums;
using GameServerCore.Domain;
using GameServerCore.Domain.GameObjects;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using LeagueSandbox.GameServer.GameObjects.Stats;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace RengarPassiveBuff
{
    internal class RengarPassiveBuff : IBuffGameScript
    {
        private StatsModifier _statMod;

        private int ChampionsInRadius = 0;
        private IBuff _visualBuff;

        public void OnActivate(IObjAiBase unit, ISpell ownerSpell)
        {
            _statMod = new StatsModifier();
            _statMod.Range.FlatBonus = 475;
            if(unit.HasMadeInitialAttack){
                unit.DashToTarget(unit.AutoAttackTarget, 500, 1f, 1f, 1f);
                unit.RemoveStatModifier(_statMod);
            }
        }

        public void OnDeactivate(IObjAiBase unit)
        {
            CreateTimer(0.5f, () =>
            {
                unit.RemoveStatModifier(_statMod);
            });
        }

        public void OnUpdate(double diff)
        {

        }
    }
}

