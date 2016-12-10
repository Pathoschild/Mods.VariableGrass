﻿using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace VariableGrass
{
    public class VariableGrass : Mod
    {
        /*********
        ** Properties
        *********/
        /// <summary>The minimum number of iterations.</summary>
        private int MinIterations;

        /// <summary>The maximum number of iterations.</summary>
        private int MaxIterations;

        /// <summary>The random number generator.</summary>
        private readonly Random Random = new Random();


        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            // get settings
            var config = helper.ReadConfig<ModConfig>();
            this.MinIterations = config.MinIterations;
            this.MaxIterations = config.MaxIterations;

            // register events
            TimeEvents.DayOfMonthChanged += Events_DayOfMonthChanged;
        }


        /*********
        ** Private methods
        *********/
        /// <summary>The method called when the day number changes.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void Events_DayOfMonthChanged(object sender, EventArgsIntChanged e)
        {
            int iterations = this.Random.Next(MinIterations, MaxIterations);
            this.Monitor.Log($"Growing grass ({iterations} iterations)...");
            Game1.getFarm().growWeedGrass(iterations);
        }
    }
}
