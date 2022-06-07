using System;
using System.Collections.Generic;
using System.Linq;
using BL.Models;
using BL.Models.Game;
using Microsoft.AspNetCore.Mvc;
using Action = System.Action;

namespace BL.Controllers
{
    [Route("[controller]")]
    public class BLController : ControllerBase
    {
        private static readonly Dice BasicDice = new Dice(20);

        [HttpPost]
        [Route("StartGame")]
        public FightResult PostAsync([FromBody] GameCharacters gameCharacters)
        {
            var monster = gameCharacters.Monst;
            var userCharacter = gameCharacters.Us;
            monster.IsUser = false;
            userCharacter.IsUser = true;
            

            //hp
            var monsterHP = monster.HitPoints;
            var userCharacterHP = userCharacter.HitPoints;

            //dices
            int monsterThrows, monsterEdges, userCharacterThrows, userCharacterEdges;

            (monsterThrows, monsterEdges) = GetThrowsAndEdges(monster.Damage);
            (userCharacterThrows, userCharacterEdges) = GetThrowsAndEdges(userCharacter.Damage);

            var monsterDice = new Dice(monsterEdges);
            var userCharacterDice = new Dice(userCharacterEdges);

            var activityList = new List<Activity>();

            while (monster.HitPoints > 0 && userCharacter.HitPoints > 0)
            {
                if (userCharacter.HitPoints > 0)
                {
                    activityList.Add(MakeActivity(userCharacter, monster, userCharacterDice, userCharacterThrows));
                }

                if (monster.HitPoints > 0)
                {
                    activityList.Add(MakeActivity(monster, userCharacter, monsterDice, monsterThrows));
                }
            }

            var isUserWin = userCharacter.HitPoints > 0;
            monster.HitPoints = monsterHP;
            userCharacter.HitPoints = userCharacterHP;

            var result = new FightResult
            {
                UserCharacter = userCharacter,
                Monster = monster,
                Activities = activityList,
                IsUserWin = isUserWin
            };

            return result;
        }

        private Tuple<int, int> GetThrowsAndEdges(string damage)
        {
            var data = damage.Split("d");
            var throws = int.Parse(damage.Split("d").First());
            var edges = int.Parse(damage.Split("d").Last());
            return Tuple.Create(throws, edges);
        }

        public Activity MakeActivity(Character attacker, Character defender, Dice dice, int throws)
        {
            var attacks = new List<Attack>();

            for (var i = 0; i < throws && defender.HitPoints > 0; i++)
            {
                var points = BasicDice.Roll();
                var isAttackSuccess = points != 1
                                      && (points + attacker.AttackModifier >= defender.ArmorClass || points == 20);
                if (!isAttackSuccess)
                {
                    attacks.Add(new Attack
                    {
                        Damage = 0,
                        IsCriticalDamage = false,
                        IsCriticalMiss = points == 1,
                        Dice20 = points
                    });
                    
                    continue;
                }

                var criticalAttackCoeff = points == 20 ? 2 : 1;
                var dice1 = dice.Roll();
                var damage = criticalAttackCoeff * (dice1 + attacker.DamageModifier);
                defender.HitPoints -= damage;
                attacks.Add(new Attack
                {
                    Damage = damage,
                    IsCriticalDamage = points == 20,
                    IsCriticalMiss = false,
                    Dice20 = points,
                    Dice = dice1
                });
            }

            var activity = new Activity
            {
                IsUserActivity = attacker.IsUser,
                Attacks = attacks
            };

            return activity;
        }
    }
}