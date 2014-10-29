using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NephalemArchive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Career c = new Career();
            c = c.getData("jefe323-1980", "nnddspm4keeey6jt2kdd53xvujaxh28u");
            PrintCareerData(c);
        }

        private void PrintCareerData(Career c)
        {
            box.Clear();
            //Career Info - Basic
            box.Text += "*** Player Information ***" + Environment.NewLine;
            box.Text += "BattleTag: " + c.baseStats.battleTag + Environment.NewLine;
            box.Text += "Paragon Level: " + c.baseStats.paragonLevel.ToString() + Environment.NewLine;
            box.Text += "Paragon Level (Hardcore): " + c.baseStats.paragonLevelHardcore.ToString() + Environment.NewLine;
            box.Text += "Paragon Level (Seasons): " + c.baseStats.paragonLevelSeason.ToString() + Environment.NewLine;
            box.Text += "Paragon Level (Seasons Hardcore): " + c.baseStats.paragonLevelSeasonHardcore.ToString() + Environment.NewLine;
            box.Text += "Last Hero Played: " + c.baseStats.lastHeroPlayed.ToString() + Environment.NewLine;
            box.Text += Environment.NewLine;
            //Career Info - Kills
            box.Text += "*** Kills ***" + Environment.NewLine;
            box.Text += "Monsters: " + c.kills.Monsters.ToString() + Environment.NewLine;
            box.Text += "Elites: " + c.kills.Elites.ToString() + Environment.NewLine;
            box.Text += "Hardcore Monsters: " + c.kills.Hardcore.ToString() + Environment.NewLine;
            box.Text += Environment.NewLine;
            //Career Info - Progression
            box.Text += "*** Main Story Progression ***" + Environment.NewLine;
            box.Text += "Act 1: " + c.progression.act1.ToString() + Environment.NewLine;
            box.Text += "Act 2: " + c.progression.act2.ToString() + Environment.NewLine;
            box.Text += "Act 3: " + c.progression.act3.ToString() + Environment.NewLine;
            box.Text += "Act 4: " + c.progression.act4.ToString() + Environment.NewLine;
            box.Text += "Act 5: " + c.progression.act5.ToString() + Environment.NewLine;
            box.Text += Environment.NewLine;
            //Career Info - Time Played
            box.Text += "*** Time Played ***" + Environment.NewLine;
            box.Text += "Not Implemented At This Time :(" + Environment.NewLine;
            box.Text += Environment.NewLine;            
            //Career Info - Seasons
            box.Text += "*** Seasons ***" + Environment.NewLine;
            box.Text += "Season Number: " + c.season.seasonId + Environment.NewLine;
            box.Text += "Season Paragon Level: " + c.season.paragonLevel + Environment.NewLine;
            box.Text += "Season Hardcore Paragon Level: " + c.season.paragonLevelHardcore + Environment.NewLine;
            box.Text += "Season Kills: " + Environment.NewLine;
            box.Text += "\tMonsters: " + c.season.seasonKills.Monsters + Environment.NewLine;
            box.Text += "\tElites: " + c.season.seasonKills.Elites + Environment.NewLine;
            box.Text += "\tHardcore Monsters: " + c.season.seasonKills.Hardcore + Environment.NewLine;
            box.Text += "Main Story Progression:" + Environment.NewLine;
            box.Text += "\tAct1: " + c.season.seasonProgression.act1.ToString() + Environment.NewLine;
            box.Text += "\tAct2: " + c.season.seasonProgression.act2.ToString() + Environment.NewLine;
            box.Text += "\tAct3: " + c.season.seasonProgression.act3.ToString() + Environment.NewLine;
            box.Text += "\tAct4: " + c.season.seasonProgression.act4.ToString() + Environment.NewLine;
            box.Text += "\tAct5: " + c.season.seasonProgression.act5.ToString() + Environment.NewLine;
            box.Text += Environment.NewLine;
            //Characters
            box.Text += "*** Heroes ***" + Environment.NewLine;
            foreach (SimpleHero h in c.heroes)
            {
                box.Text += h.name + Environment.NewLine;
                box.Text += "\tClass: " + h._class + Environment.NewLine;
                box.Text += "\tLevel: " + h.level.ToString() + Environment.NewLine;
                box.Text += "\tParagon: " + h.paragonLevel.ToString() + Environment.NewLine;
                box.Text += "\tSeason: " + h.season.ToString() + Environment.NewLine;
                box.Text += "\tHardcore: " + h.hardcore.ToString() + Environment.NewLine;
            }
            box.Text += Environment.NewLine;
        }
    }
}
