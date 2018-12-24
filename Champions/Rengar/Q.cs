using System.Numerics;
using GameServerCore.Enums;
using GameServerCore.Domain.GameObjects;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using GameServerCore.Domain;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace Spells
{
    public class RengarQ : IGameScript
    {
        int attackCounter = 0;
        float OriginalAS;
        public void OnActivate(IChampion owner)
        {
            


        }

        public void OnDeactivate(IChampion owner)
        {
        }

        public void OnStartCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {

            AddParticleTarget(owner, "Rengar_Base_Q_Buf_Claw.troy", owner, 1, "L_HAND");
            AddParticleTarget(owner, "Rengar_Base_Q_Buf_Blade.troy", owner, 1, "R_HAND");
            OriginalAS = owner.Stats.AttackSpeedFlat;
            
            owner.Stats.AttackSpeedFlat *= 0.4f;
            if (owner.HasMadeInitialAttack)
            {
                ApplyEffects(owner, owner.TargetUnit, spell, null);
            }

        }

        public void OnFinishCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
            
        }

        public void ApplyEffects(IChampion owner, IAttackableUnit target, ISpell spell, IProjectile projectile)
        {
            AddParticle(owner, "Rengar_Base_Q_Cas.troy", owner.X, owner.Y, 1, "R_HAND");

            target.TakeDamage(owner, owner.Stats.AttackDamage.Total + spell.Level * 30F + owner.Stats.AttackDamage.Total *(spell.Level * 0.5f),
                DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
        }

        public void OnUpdate(double diff)
        {
            if(attackCounter == 2)
            {

            }
        }
    }
}
