using GameServerCore.Enums;
using GameServerCore.Domain;
using GameServerCore.Domain.GameObjects;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using LeagueSandbox.GameServer.GameObjects.Stats;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace RengarQBuff
{
    internal class RengarQBuff : IBuffGameScript
    {
        private StatsModifier _statMod;
        private IBuff _visualBuff;

        public void OnActivate(IObjAiBase unit, ISpell ownerSpell)
        {
            var time = 3f;

            //IChampion champ = unit as IChampion;
            //AddParticleTarget(champ, "Rengar_Base_Q_Buf_Claw.troy", unit, 1, "L_HAND");
            //AddParticleTarget(champ, "Rengar_Base_Q_Buf_Blade.troy", unit, 1, "R_HAND");
            _visualBuff = AddBuffHudVisual("RengarQBuff", time, 1, BuffType.COMBAT_ENCHANCER, unit);
            /*if (unit.IsAttacking)
            {
                unit.AutoAttackTarget.TakeDamage(unit, unit.Stats.AttackDamage.Total + unit.Stats.Level * 30F + unit.Stats.AttackDamage.Total * (unit.Stats.Level * 0.5f),
                    DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
            }*/
        }

        public void OnDeactivate(IObjAiBase unit)
        {
            RemoveBuffHudVisual(_visualBuff);
            //unit.RemoveStatModifier(_statMod);
        }

        public void OnUpdate(double diff)
        {

        }
    }
}
