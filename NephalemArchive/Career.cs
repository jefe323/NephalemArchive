using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace NephalemArchive
{
    public class Career
    {
        public BaseStats baseStats { get; set;}
        public Kills kills { get; set; }
        public TimePlayed timePlayed { get; set; }
        public Progression progression { get; set; }
        public Season season { get; set; }
        //collection of heroes
        public List<SimpleHero> heroes { get; set; }
        //collection of fallen heroes
        public List<SimpleHero> fallenHeros { get; set; }

        //retrieve data from API
        public Career getData (string lookup, string apiKey)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string data = client.DownloadString("https://us.api.battle.net/d3/profile/" + lookup + "/?locale=en_US&apikey=" + apiKey);
                    try
                    {
                        var o = JObject.Parse(data);

                        #region Heroes
                        List<SimpleHero> h = new List<SimpleHero>();
                        int i = 0;
                        while (true)
                        {
                            try
                            {
                                SimpleHero hero = new SimpleHero
                                {
                                    paragonLevel = Convert.ToInt32(o["heroes"][i]["paragonLevel"]),
                                    season = Convert.ToBoolean(o["heroes"][i]["seasonal"]),
                                    name = o["heroes"][i]["name"].ToString(),
                                    id = Convert.ToInt32(o["heroes"][i]["id"]),
                                    level = Convert.ToInt32(o["heroes"][i]["level"]),
                                    hardcore = Convert.ToBoolean(o["heroes"][i]["hardcore"]),
                                    gender = Convert.ToInt32(o["heroes"][i]["gender"]),
                                    dead = Convert.ToBoolean(o["heroes"][i]["dead"]),
                                    _class = o["heroes"][i]["class"].ToString()
                                };
                                h.Add(hero);
                                i++;
                            }
                            catch { break; }
                        }
                        #endregion

                        Career career = new Career
                        {
                            baseStats = new BaseStats {
                                battleTag = o["battleTag"].ToString(),
                                paragonLevel = Convert.ToInt32(o["paragonLevel"]),
                                paragonLevelHardcore = Convert.ToInt32(o["paragonLevelHardcore"]),
                                paragonLevelSeason = Convert.ToInt32(o["paragonLevelSeason"]),
                                paragonLevelSeasonHardcore = Convert.ToInt32(o["paragonLevelSeasonHardcore"]),
                                lastHeroPlayed = Convert.ToInt32(o["lastHeroPlayed"])
                            },
                            kills = new Kills {
                                Monsters = Convert.ToInt32(o["kills"]["monsters"]),
                                Elites = Convert.ToInt32(o["kills"]["elites"]),
                                Hardcore = Convert.ToInt32(o["kills"]["hardcoreMonsters"])
                            },
                            timePlayed = new TimePlayed {
                                //Nothing yet :/
                            },
                            progression = new Progression {
                                act1 = Convert.ToBoolean(o["progression"]["act1"]),
                                act2 = Convert.ToBoolean(o["progression"]["act2"]),
                                act3 = Convert.ToBoolean(o["progression"]["act3"]),
                                act4 = Convert.ToBoolean(o["progression"]["act4"]),
                                act5 = Convert.ToBoolean(o["progression"]["act5"])
                            },
                            season = new Season {
                                seasonId = Convert.ToInt32(o["seasonalProfiles"]["season1"]["seasonId"]),
                                paragonLevel = Convert.ToInt32(o["seasonalProfiles"]["season1"]["paragonLevel"]),
                                paragonLevelHardcore = Convert.ToInt32(o["seasonalProfiles"]["season1"]["paragonLevelHardcore"]),
                                seasonKills = new Kills
                                {
                                    Monsters = Convert.ToInt32(o["seasonalProfiles"]["season1"]["kills"]["monsters"]),
                                    Elites = Convert.ToInt32(o["seasonalProfiles"]["season1"]["kills"]["elites"]),
                                    Hardcore = Convert.ToInt32(o["seasonalProfiles"]["season1"]["kills"]["hardcoreMonsters"])
                                },
                                seasonProgression = new Progression
                                {
                                    act1 = Convert.ToBoolean(o["seasonalProfiles"]["season1"]["progression"]["act1"]),
                                    act2 = Convert.ToBoolean(o["seasonalProfiles"]["season1"]["progression"]["act2"]),
                                    act3 = Convert.ToBoolean(o["seasonalProfiles"]["season1"]["progression"]["act3"]),
                                    act4 = Convert.ToBoolean(o["seasonalProfiles"]["season1"]["progression"]["act4"]),
                                    act5 = Convert.ToBoolean(o["seasonalProfiles"]["season1"]["progression"]["act5"])
                                }
                            },
                            heroes = h
                        };
                        return career;
                    }
                    catch { }
                }
                catch {}
            }
            //ugly :(
            Career cError = new Career();
            return cError;
        }
    }

    public class BaseStats
    {
        public string battleTag { get; set; }
        public int paragonLevel { get; set; }
        public int paragonLevelHardcore { get; set; }
        public int paragonLevelSeason { get; set; }
        public int paragonLevelSeasonHardcore { get; set; }
        public int lastHeroPlayed { get; set; }        
    }

    public class SimpleHero
    {
        public int paragonLevel { get; set; }
        public bool season { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int level { get; set; }
        public bool hardcore { get; set; }
        public int gender { get; set; }
        public bool dead { get; set; }
        public string _class { get; set; }
    }

    public class Kills
    {
        public int Monsters { get; set; }
        public int Elites { get; set; }
        public int Hardcore { get; set; }
    }

    public class TimePlayed
    {
        public int barbarian { get; set; }
        public int crusader { get; set; }
        public int demon_hunter { get; set; }
        public int monk { get; set; }
        public int witch_doctor { get; set; }
        public int wizard { get; set; }
    }

    public class Progression
    {
        public bool act1 { get; set; }
        public bool act2 { get; set; }
        public bool act3 { get; set; }
        public bool act4 { get; set; }
        public bool act5 { get; set; }
    }

    public class Season
    {
        public int seasonId { get; set; }
        public int paragonLevel { get; set; }
        public int paragonLevelHardcore { get; set; }
        public Kills seasonKills { get; set; }
        public TimePlayed seasonTimePlayed { get; set; }
        public Progression seasonProgression { get; set; }
    }
}
