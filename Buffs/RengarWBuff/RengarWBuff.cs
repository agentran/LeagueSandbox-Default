using GameServerCore.Enums;
using GameServerCore.Domain;
using GameServerCore.Domain.GameObjects;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using LeagueSandbox.GameServer.GameObjects.Stats;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace RengarWBuff
{
    internal class RengarWBuff : IBuffGameScript
    {
        private StatsModifier _statMod;

        private int ChampionsInRadius = 0;
        private IBuff _visualBuff;

        public void OnActivate(IObjAiBase unit, ISpell ownerSpell)
        {
            
            foreach(IAttackableUnit newChampion in GetChampionsInRange(unit, ownerSpell.SpellData.CastRange[1], true))
            {
                if (newChampion.Team != unit.Team)
                {
                    ChampionsInRadius++;
                }
            }
            _statMod = new StatsModifier();
            if (ChampionsInRadius > 0)
            {
                _statMod.Armor.FlatBonus = 5f + ownerSpell.Level * 5f + (5f + ((ChampionsInRadius-1) * 2.5f));
                _statMod.MagicResist.FlatBonus = 5f + ownerSpell.Level * 5f + (5f + ((ChampionsInRadius-1) * 2.5f));
            }
            if(ChampionsInRadius == 0)
            {
                _statMod.Armor.FlatBonus = 5f + ownerSpell.Level * 5f;
                _statMod.MagicResist.FlatBonus = 5f + ownerSpell.Level * 5f;
            }
            var time = 4f;

            _visualBuff = AddBuffHudVisual("RengarWBuff", time, 1, BuffType.COMBAT_ENCHANCER,
                unit);
            unit.AddStatModifier(_statMod);
            CreateTimer(time, () =>
            {
                OnDeactivate(unit);
            });
        }

        public void OnDeactivate(IObjAiBase unit)
        {
            unit.RemoveStatModifier(_statMod);
            RemoveBuffHudVisual(_visualBuff);
            ChampionsInRadius = 0;
        }

        public void OnUpdate(double diff)
        {

        }
    }
}

