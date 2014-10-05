﻿/*
    Copyright (C) 2014 h3h3

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


using System;
using System.Collections.Generic;
using LeagueSharp;
using LeagueSharp.Common;

namespace Support.Plugins
{
    public class Zilean : PluginBase
    {
        public Zilean()
            : base("h3h3", new Version(4, 17, 14))
        {
            Q = new Spell(SpellSlot.Q, 700);
            W = new Spell(SpellSlot.W, 0);
            E = new Spell(SpellSlot.E, 700);
            R = new Spell(SpellSlot.R, 900);

            Protector.Init();
            Protector.OnSkillshotProtection += Protector_OnSkillshotProtection;
            Protector.OnTargetedProtection += Protector_OnTargetedProtection;
        }

        private void Protector_OnTargetedProtection(Obj_AI_Base caster, Obj_AI_Hero target, SpellData spell)
        {
            if(!R.IsReady() || Player.Distance(target) > R.Range)
                return;

            if (caster.GetSpellDamage(target, spell.Name) >= target.Health)
                R.Cast(target, true);
        }

        private void Protector_OnSkillshotProtection(Obj_AI_Hero target, List<Evade.Skillshot> skillshots)
        {
            if (!R.IsReady() || Player.Distance(target) > R.Range)
                return;

            foreach (var skillshot in skillshots)
            {
                if (skillshot.Unit.GetSpellDamage(target, skillshot.SpellData.SpellName) >= target.Health)
                    R.Cast(target, true);
            }
        }

        public override void OnUpdate(EventArgs args)
        {
            if (ComboMode)
            {
                if (Q.IsReady() && Target.IsValidTarget(Q.Range) && GetValue<bool>("UseQC"))
                {

                }

                if (W.IsReady() && Target.IsValidTarget(W.Range) && GetValue<bool>("UseWC"))
                {

                }

                if (E.IsReady() && Target.IsValidTarget(E.Range) && GetValue<bool>("UseEC"))
                {

                }

                if (R.IsReady() && Target.IsValidTarget(R.Range) && GetValue<bool>("UseRC"))
                {

                }
            }

            if (HarassMode)
            {
                if (Q.IsReady() && Target.IsValidTarget(Q.Range) && GetValue<bool>("UseQH"))
                {

                }

                if (W.IsReady() && Target.IsValidTarget(W.Range) && GetValue<bool>("UseWH"))
                {

                }

                if (E.IsReady() && Target.IsValidTarget(E.Range) && GetValue<bool>("UseEH"))
                {

                }
            }
        }

        public override void BeforeAttack(Orbwalking.BeforeAttackEventArgs args)
        {
        }

        public override void AfterAttack(Obj_AI_Base unit, Obj_AI_Base target)
        {
        }

        public override void OnEnemyGapcloser(ActiveGapcloser gapcloser)
        {
        }

        public override void OnPossibleToInterrupt(Obj_AI_Base unit, InterruptableSpell spell)
        {
            if (spell.DangerLevel < InterruptableDangerLevel.High || unit.IsAlly)
                return;

        }

        public override void OnDraw(EventArgs args)
        {
        }

        public override void ComboMenu(Menu config)
        {
            config.AddItem(new MenuItem("UseQC", "Use Q").SetValue(true));
            config.AddItem(new MenuItem("UseWC", "Use W").SetValue(true));
            config.AddItem(new MenuItem("UseEC", "Use E").SetValue(true));
            config.AddItem(new MenuItem("UseRC", "Use R").SetValue(true));
            config.AddItem(new MenuItem("CountR", "Num of Enemy in Range to Ult").SetValue(new Slider(2, 1, 5)));
        }

        public override void HarassMenu(Menu config)
        {
            config.AddItem(new MenuItem("UseQH", "Use Q").SetValue(true));
            config.AddItem(new MenuItem("UseWH", "Use W").SetValue(true));
            config.AddItem(new MenuItem("UseEH", "Use E").SetValue(true));
            config.AddItem(new MenuItem("UseRH", "Use R").SetValue(true));
        }

        public override void ItemMenu(Menu config)
        {
        }

        public override void MiscMenu(Menu config)
        {
            config.AddItem(new MenuItem("UseQA", "Use Q after Attack").SetValue(true));
            config.AddItem(new MenuItem("UseQG", "Use Q to Interrupt Gapcloser").SetValue(true));
            config.AddItem(new MenuItem("UseQI", "Use Q to Interrupt Spells").SetValue(true));
            config.AddItem(new MenuItem("UseRI", "Use R to Interrupt Spells").SetValue(true));
        }

        public override void ManaMenu(Menu config)
        {
        }

        public override void DrawingMenu(Menu config)
        {
        }
    }
}