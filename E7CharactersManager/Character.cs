using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace E7CharactersManager
{
    /// <summary>
    /// Character that represents a character from the E7 game 
    /// </summary>
    internal class Character
    {
        /// <summary>
        /// Character name
        /// </summary>
        public string name { get; private set; } = "";
        /// <summary>
        /// Character unique ID
        /// </summary>
        public string cid { get; private set; } = "";
        /// <summary>
        /// Element of the Hero
        /// </summary>
        public HeroElement heroElement { get; private set; }
        /// <summary>
        /// Class of the Hero
        /// </summary>
        public HeroClass heroClass { get; private set; }
        /// <summary>
        /// Rarity of the Hero
        /// </summary>
        public HeroRarity heroRarity { get; private set; }
        /// <summary>
        /// Gender of the Hero
        /// </summary>
        public HeroGender heroGender { get; private set; }
        /// <summary>
        /// Additional properties a Hero can have
        /// </summary>
        public List<Property> properties { get; private set; } = new List<Property>();

        /// <summary>
        /// Create a new character object from the information given
        /// </summary>
        /// <param name="name">Name of the Hero</param>
        /// <param name="cid">Unique ID of the Hero</param>
        /// <param name="heroGender">Gender of the Hero</param>
        /// <param name="heroClass">Class of the Hero</param>
        /// <param name="properties">Addidional properties a Hero can have</param>
        public Character(string name, string cid, HeroElement heroElement, HeroRarity heroRarity, HeroClass heroClass, HeroGender heroGender, params Property[] properties)
        {
            this.name = name;
            this.cid = cid;
            this.heroElement = heroElement;
            this.heroGender = heroGender;
            this.heroClass = heroClass;
            foreach (Property p in properties)
                this.properties.Add(p);
        }
    }

    /// <summary>
    /// Element an hero can have
    /// </summary>
    public enum HeroElement
    {
        Fire,
        Earth,
        Ice,
        Light,
        Dark
    }
    /// <summary>
    /// Hero class, can be any of the base E7 classes
    /// </summary>
    public enum HeroClass
    {
        DummyClass,
        Warrior,
        Knight,
        Thief,
        Mage,
        Ranger,
        SoulWeaver
    }
    /// <summary>
    /// Rarity a hero can have
    /// </summary>
    public enum HeroRarity
    {
        Stars3,
        Stars4,
        Stars5
    }
    /// <summary>
    /// Gender of a Hero, can be Male or Female
    /// </summary>
    public enum HeroGender
    {
        Female,
        Male
    }
    /// <summary>
    /// Additional properties a Hero can have
    /// </summary>
    public enum Property
    {
        ClothesChange,
        Skin,
        SpecialtyChange,
        Collab
    }
    /// <summary>
    /// Type of filter to apply on List
    /// </summary>
    public enum FilterType
    {
        OnlyFire,
        OnlyEarth,
        OnlyIce,
        OnlyLight,
        OnlyDark,

        RemoveAllFire,
        RemoveAllEarth,
        RemoveAllIce,
        RemoveAllLight,
        RemoveAllDark,

        OnlyDummyClass,
        OnlyWarrior,
        OnlyKnight,
        OnlyThief,
        OnlyMage,
        OnlyRanger,
        OnlySoulWeaver,

        RemoveAllDummyClass,
        RemoveAllWarrior,
        RemoveAllKnight,
        RemoveAllThief,
        RemoveAllMage,
        RemoveAllRanger,
        RemoveAllSoulWeaver,


        OnlyStars3,
        OnlyStars4,
        OnlyStars5,

        RemoveAllStars3,
        RemoveAllStars4,
        RemoveAllStars5,


        OnlyMales,
        OnlyFemales,

        RemoveAllMales,
        RemoveAllFemales,

        OnlyClothesChange,
        OnlySpecialtyChange,
        OnlyCollab,
        OnlySkin,

        RemoveAllClothesChange,
        RemoveAllSpecialtyChange,
        RemoveAllCollab,
        RemoveAllSkin
    }

    internal class CharactersList
    {
        /// <summary>
        /// List containing all characters by default. Can be modified by applying filters
        /// </summary>
        public List<Character> List { get; private set; } = new List<Character>
        {
            //            Character Name,                             Character ID, Character Element, HeroRarity,        HeroClass,          , Character Gender,  Hero Properties
            new Character("Abigail",                                  "c1144",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Achates",                                  "c1017",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Achates: Azure Sea",                       "c1017_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Skin),
            new Character("Adin",                                     "c3143",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Adlay",                                    "c3043",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Adventurer Ras",                           "c5001",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Ainos",                                    "c3105",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Ainos 2.0",                                "c4105",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Ains",                                     "c3093",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Aither",                                   "c1018",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  ),
            new Character("Aither: Star of Ezera",                    "c1018_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  , Property.Skin),
            new Character("Alencia",                                  "c1100",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Alencia: Gift Granny",                     "c1100_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female, Property.Skin),
            new Character("Alexa",                                    "c3012",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("All-Rounder Wanda",                        "c4065",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Ambitious Tywin",                          "c2042",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Amid",                                     "c1143",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Angel of Light Angelica",                  "c6062",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Angelic Montmorancy",                      "c4042",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Angelic Montmorancy: Serene Sea",          "c4042_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Skin),
            new Character("Angelica",                                 "c1062",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Angelica: Mysterious Transfer Student",    "c1062_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Skin),
            new Character("Apocalypse Ravi",                          "c2019",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Apocalypse Ravi: Avatar of Bloodlust",     "c2019_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female, Property.Skin),
            new Character("Aramintha",                                "c1048",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Arbiter Vildred",                          "c2007",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Arbiter Vildred: Dark Monarch",            "c2007_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  , Property.Skin),
            new Character("Archdemon's Shadow",                       "c5004",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Architect Laika",                          "c2099",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Aria",                                     "c1129",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Armin",                                    "c1008",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Arowell",                                  "c3004",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Arunka",                                   "c1124",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Assassin Cartuja",                         "c2013",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Assassin Cidd",                            "c2014",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Assassin Coli",                            "c2033",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Astromancer Elena",                        "c2091",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Auxiliary Lots",                           "c2031",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Azalea",                                   "c3031",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Baal & Sezan",                             "c1015",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Bad Cat Armin",                            "c6008",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Baiken",                                   "c1093",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female, Property.Collab),
            new Character("Basar",                                    "c1053",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Basar: Sophisticated Magnate",             "c1053_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  , Property.Skin),
            new Character("Bask",                                     "c3006",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Batisse",                                  "c3095",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Beehoo",                                   "c1141",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Male  ),
            new Character("Belian",                                   "c1117",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Bellona",                                  "c1071",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Benevolent Romann",                        "c2043",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Benimaru",                                 "c1146",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  , Property.Collab),
            new Character("Blaze Dingo",                              "c2021",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  ),
            new Character("Blood Blade Karin",                        "c2011",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Blood Moon Haste",                         "c2039",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  ),
            new Character("Bomb Model Kanna",                         "c1097",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Bomb Model Kanna: Special Gift",           "c1097_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female, Property.Skin),
            new Character("Briar Witch Iseria",                       "c2024",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Butcher Corps Inquisitor",                 "c3001",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Camilla",                                  "c3124",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Captain Rikoris",                          "c4034",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Carmainerose",                             "c3071",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Carrot",                                   "c3051",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Cartuja",                                  "c1013",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Cecilia",                                  "c1002",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Cecilia: Black-Winged Succubus",           "c1002_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female, Property.Skin),
            new Character("Celeste",                                  "c3064",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Celestial Mercedes",                       "c2005",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Celine",                                   "c1103",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Cerise",                                   "c1081",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Cermia",                                   "c1079",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Cermia: Beachside Merrymakes",             "c1079_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female, Property.Skin),
            new Character("Challenger Dominiel",                      "c2037",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Champion Zerato",                          "c2010",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Chaos Inquisitor",                         "c4001",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Chaos Sect Axe",                           "c4025",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Charles",                                  "c1027",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Charles: Demon Hunter",                    "c1027_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  , Property.Skin),
            new Character("Charlotte",                                "c1009",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Chloe",                                    "c1049",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Choux",                                    "c1101",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Choux: 2022 E7WC",                         "c1101_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female, Property.Skin),
            new Character("Christy",                                  "c3123",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Church of Ilryos Axe",                     "c3025",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Cidd",                                     "c1014",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Cidd: Masked Gentleman",                   "c1014_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  , Property.Skin),
            new Character("Clarissa",                                 "c1028",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Closer Charles",                           "c2027",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Coli",                                     "c1033",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Command Model Laika",                      "c1099",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Commander Lorina",                         "c4035",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Commander Pavel",                          "c2080",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Male  ),
            new Character("Conqueror Lilias",                         "c2089",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Corvus",                                   "c1012",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Crescent Moon Rin",                        "c2054",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Crimson Armin",                            "c2008",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Crozet",                                   "c1036",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Dark Corvus",                              "c2012",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Death Dealer Ray",                         "c2090",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  ),
            new Character("Desert Jewel Basar",                       "c2053",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  ),
            new Character("Designer Lilibet",                         "c2095",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Destina",                                  "c2022",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Destina: Spring Breeze",                   "c2022_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Skin),
            new Character("Diene",                                    "c1076",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Diene: Magical Girl",                      "c1076_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Skin),
            new Character("Dingo",                                    "c1021",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Dizzy",                                    "c1094",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female, Property.Collab),
            new Character("Doll Maker Pearlhorizon",                  "c4073",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Dominiel",                                 "c1037",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Doris",                                    "c3044",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Eaton",                                    "c3094",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Eda",                                      "c1111",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Edward Elric",                             "c1134",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  , Property.Collab),
            new Character("Elena",                                    "c1091",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Elena: Starlit Melody",                    "c1091_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Skin),
            new Character("Eligos",                                   "c1142",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Male  ),
            new Character("Elphelt",                                  "c1105",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female, Property.Collab),
            new Character("Elson",                                    "c3054",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  ),
            new Character("Emilia",                                   "c1116",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Collab),
            new Character("Enott",                                    "c3022",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Ervalen",                                  "c1108",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Fairytale Tenebria",                       "c5050",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Faithless Lidica",                         "c2046",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Faithless Lidica: Victorious Knight",      "c2046_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female, Property.Skin),
            new Character("Falconer Kluri",                           "c4003",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Fallen Cecilia",                           "c2002",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Fallen Cecilia: White Warmth",             "c2002_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female, Property.Skin),
            new Character("Fighter Maya",                             "c2032",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Flan",                                     "c1110",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Free Spirit Tieria",                       "c3026",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
          //new Character("Free Spirit Tieria",                       "c3026_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female, Property.Skin), TODO skin unknown
            new Character("Furious",                                  "c1087",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Male  ),
            new Character("General Purrgis",                          "c2035",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Glenn",                                    "c3103",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Male  ),
            new Character("Gloomyrain",                               "c3074",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Godmother",                                "c3101",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Great Chief Khawana",                      "c2086",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Guider Aither",                            "c2018",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Gunther",                                  "c3024",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Hasol",                                    "c3135",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Haste",                                    "c1039",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Hataan",                                   "c3091",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Hazel",                                    "c3041",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Helen",                                    "c3122",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Helga",                                    "c3023",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Holiday Yufine",                           "c5016",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Holy Flame Adin",                          "c4141",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Hurado",                                   "c3055",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Hwayoung",                                 "c1128",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Ian",                                      "c3102",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Male  ),
            new Character("Ilynav",                                   "c1113",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Inferno Khawazu",                          "c2085",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Iseria",                                   "c1024",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Iseria: Night of White Flowers",           "c1024_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female, Property.Skin),
            new Character("Jack O’",                                  "c1130",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female, Property.Collab),
            new Character("Januta",                                   "c3131",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Jecht",                                    "c3053",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  ),
            new Character("Jena",                                     "c3052",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Judge Kise",                               "c2006",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Judge Kise: Heir of Holy Light",           "c2006_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female, Property.Skin),
            new Character("Judith",                                   "c3011",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Juni",                                     "c3151",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Karin",                                    "c1011",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Karin: Shore Patrol",                      "c1011_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female, Property.Skin),
            new Character("Kawerik",                                  "c1073",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Kayron",                                   "c1023",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Kayron: Time Rabbit",                      "c1023_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  , Property.Skin),
            new Character("Ken",                                      "c1047",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Khawana",                                  "c1086",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Khawazu",                                  "c1085",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Kikirat v2",                               "c3084",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Kiris",                                    "c3063",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Kise",                                     "c1006",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Kitty Clarissa",                           "c2028",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Kizuna AI",                                "c1107",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Collab),
            new Character("Kluri",                                    "c3003",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Krau",                                     "c1070",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Landy",                                    "c1109",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Last Piece Karin",                         "c6011",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Last Rider Krau",                          "c2070",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Lena",                                     "c3092",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Leo",                                      "c1029",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Male  ),
            new Character("Lidica",                                   "c1046",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Lidica: Bride of Roses",                   "c1046_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female, Property.Skin),
            new Character("Lilias",                                   "c1089",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Lilibet",                                  "c1095",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Lilka",                                    "c3153",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Lionheart Cermia",                         "c2079",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Little Queen Charlotte",                   "c2009",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Little Queen Charlotte: Elegant Excurion", "c2009_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female, Property.Skin),
            new Character("Lone Crescent Bellona",                    "c2071",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Lorina",                                   "c3035",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Lots",                                     "c1031",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  ),
            new Character("Lua",                                      "c1126",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Lucy",                                     "c3113",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Ludwig",                                   "c1069",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Luluca",                                   "c1082",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Luluca: Lovely Patissiere",                "c1082_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female, Property.Skin),
            new Character("Luna",                                     "c1066",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Magic Scholar Doris",                      "c4044",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Maid Chloe",                               "c2049",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Maid Chloe: Energetic",                    "c2049_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Skin),
            new Character("Martial Artist Ken",                       "c2047",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Mascot Hazel",                             "c4041",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Maya",                                     "c1032",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Mediator Kawerik",                         "c2073",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Mediator Kawerik: Calamity's Equilibrium", "c2073_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  , Property.Skin),
            new Character("Melany",                                   "c3121",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Melissa",                                  "c1096",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Mercedes",                                 "c0002",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
          //new Character("Mercedes",                                 "c1005",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female), before power up
            new Character("Mercedes: Fluffy Lady",                    "c1005_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female, Property.Skin),
            new Character("Mercenary Helga",                          "c4023",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Milim",                                    "c1122",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female, Property.Collab),
            new Character("Mirsa",                                    "c3014",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Mistychain",                               "c3072",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Montmorancy",                              "c3042",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Moon Bunny Dominiel",                      "c6037",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Mort",                                     "c1104",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Mucacha",                                  "c3033",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Mui",                                      "c1044",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Muse Rima",                                "c4062",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Muwi",                                     "c3132",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Nemunas",                                  "c3061",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Operator Sigret",                          "c2072",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Orte",                                     "c3133",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Otillie",                                  "c3045",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Pavel",                                    "c1080",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Male  ),
            new Character("Peacemaker Furious",                       "c2087",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Male  ),
            new Character("Pearlhorizon",                             "c3073",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Peira",                                    "c1125",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Penelope",                                 "c3125",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Pirate Captain Flan",                      "c2110",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Politis",                                  "c1112",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Purrgis",                                  "c1035",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Pyllis",                                   "c3005",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Ram",                                      "c1115",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female, Property.Collab),
            new Character("Ran",                                      "c1118",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Ran: Pure White Heart",                    "c1118_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  , Property.Skin),
            new Character("Ras",                                      "c1001",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Vagabond Ras",                             "c1078",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Ravi",                                     "c1019",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Ray",                                      "c1090",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  ),
            new Character("Rem",                                      "c1114",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female, Property.Collab),
            new Character("Remnant Violet",                           "c2074",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Requiem Roana",                            "c2102",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Requiemroar",                              "c3075",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Researcher Carrot",                        "c4051",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Righteous Thief Roozid",                   "c4013",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Rikoris",                                  "c3034",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Rima",                                     "c3062",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Rimuru",                                   "c1121",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  , Property.Collab),
            new Character("Rin",                                      "c1054",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Riza Hawkeye",                             "c1136",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female, Property.Collab),
            new Character("Roaming Warrior Leo",                      "c2029",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Male  ),
            new Character("Roana",                                    "c1102",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Romann",                                   "c1043",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Roozid",                                   "c3013",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Rose",                                     "c1003",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Rose: Dark Angel",                         "c1003_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female, Property.Skin),
            new Character("Roy Mustang",                              "c1135",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  , Property.Collab),
            new Character("Ruele of Light",                           "c1022",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Ruele of Light: Heir of Radiance",         "c1022_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Skin),
            new Character("Sage Baal & Sezan",                        "c2015",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Schuri",                                   "c1020",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Male  ),
            new Character("Seaside Bellona",                          "c5071",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Senya",                                    "c1106",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Serene Purity Adin",                       "c4142",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Serila",                                   "c1040",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Sez",                                      "c1038",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Sez: Aloof Lifeguard",                     "c1038_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  , Property.Skin),
            new Character("Shadow Knight Pyllis",                     "c4005",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Shadow Rose",                              "c2003",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Sharun",                                   "c1132",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Shepherd Jena",                            "c4052",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Shooting Star Achates",                    "c2017",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Shuna",                                    "c1123",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Collab),
            new Character("Sigret",                                   "c1072",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Silk",                                     "c1004",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Silver Blade Aramintha",                   "c2048",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Sinful Angelica",                          "c2062",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Sol",                                      "c1092",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  , Property.Collab),
            new Character("Solitaria of the Snow",                    "c2111",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Sonia",                                    "c3104",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Specimen Sez",                             "c2038",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Specter Tenebria",                         "c2050",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Specter Tenebria: Dark Tyrant",            "c2050_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female, Property.Skin),
            new Character("Spirit Eye Celine",                        "c2103",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Straze",                                   "c1034",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Summer Break Charlotte",                   "c5009",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Summer's Disciple Alexa",                  "c4012",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Summertime Iseria",                        "c5024",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
          //new Character("Support Model Brinus",                     "c1098",      HeroElement.Light, HeroRarity.Stars5, HeroClass.DummyClass, HeroGender.Female),
            new Character("Surin",                                    "c1065",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Suthan",                                   "c3155",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Sven",                                     "c3015",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Sylvan Sage Vivian",                       "c2088",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Taeyou",                                   "c1127",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Talaz",                                    "c3152",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Talia",                                    "c3154",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Tamarinne",                                "c1067",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female),
            new Character("Tamarinne: Starlit Concert",               "c1067_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Skin),
            new Character("Taranor Guard",                            "c3032",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Taranor Royal Guard",                      "c3002",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Tempest Surin",                            "c2065",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Tempest Surin: Autuman Beauty",            "c2065_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female, Property.Skin),
            new Character("Tenebria",                                 "c1050",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Tenebria: Phantom Schoolgirl",             "c1050_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female, Property.Skin),
            new Character("Tieria",                                   "c3021",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Top Model Luluca",                         "c2082",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Troublemaker Crozet",                      "c2036",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Twisted Eidolon Kayron",                   "c2023",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Tywin",                                    "c1042",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Male  ),
            new Character("Unbound Knight Arowell",                   "c4004",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Verdant Adin",                             "c4143",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female),
            new Character("Vigilante Leader Glenn",                   "c4103",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Male  ),
            new Character("Vildred",                                  "c1007",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Vildred: Distinguished Gentleman",         "c1007_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  , Property.Skin),
          //new Character("Vildred",                                  "c1007t",     HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  ), no scar variant
            new Character("Violet",                                   "c1074",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  ),
            new Character("Violet: Ardent Gentleman",                 "c1074_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Male  , Property.Skin),
            new Character("Vivian",                                   "c1088",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Vivian: Villainess",                       "c1088_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female, Property.Skin),
            new Character("Wanda",                                    "c3065",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Wanderer Silk",                            "c2004",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Watcher Schuri",                           "c2020",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Male  ),
            new Character("Yoonryoung",                               "c3134",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Yufine",                                   "c1016",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female),
            new Character("Yufine: Adorable Flower Bud",              "c1016_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Female, Property.Skin),
            new Character("Yulha",                                    "c1131",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female),
            new Character("Yuna",                                     "c1030",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female),
            new Character("Yuna: Afterschool Party!",                 "c1030_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger    , HeroGender.Female, Property.Skin),
            new Character("Zahhak",                                   "c1119",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior   , HeroGender.Male  ),
            new Character("Zealot Carmainerose",                      "c4071",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female),
            new Character("Zeno",                                     "c1083",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Zerato",                                   "c1010",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("Zio",                                      "c1133",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Male  ),
            new Character("ae-GISELLE",                               "c1138",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage      , HeroGender.Female, Property.Collab),
            new Character("ae-KARINA",                                "c1137",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight    , HeroGender.Female, Property.Collab),
            new Character("ae-NINGNING",                              "c1140",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Collab),
            new Character("ae-WINTER",                                "c1139",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief     , HeroGender.Female, Property.Collab),
        };

        /// <summary>
        /// Apply existing filters on list
        /// </summary>
        /// <param name="filterType">Type of filter to apply</param>
        public void FilterList(FilterType filterType)
        {
            int i = 0;
            switch (filterType)
            {
                case FilterType.OnlyFire:
                    while (i < List.Count)
                    {
                        if (List[i].heroElement != HeroElement.Fire)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlyEarth:
                    while (i < List.Count)
                    {
                        if (List[i].heroElement != HeroElement.Earth)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlyIce:
                    while (i < List.Count)
                    {
                        if (List[i].heroElement != HeroElement.Ice)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlyLight:
                    while (i < List.Count)
                    {
                        if (List[i].heroElement != HeroElement.Light)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlyDark:
                    while (i < List.Count)
                    {
                        if (List[i].heroElement != HeroElement.Dark)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;

                case FilterType.RemoveAllFire:
                    while (i < List.Count)
                    {
                        if (List[i].heroElement == HeroElement.Fire)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllEarth:
                    while (i < List.Count)
                    {
                        if (List[i].heroElement == HeroElement.Earth)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllIce:
                    while (i < List.Count)
                    {
                        if (List[i].heroElement == HeroElement.Ice)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllLight:
                    while (i < List.Count)
                    {
                        if (List[i].heroElement == HeroElement.Light)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllDark:
                    while (i < List.Count)
                    {
                        if (List[i].heroElement == HeroElement.Dark)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;


                case FilterType.OnlyDummyClass:
                    while (i < List.Count)
                    {
                        if (List[i].heroClass != HeroClass.DummyClass)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlyWarrior:
                    while (i < List.Count)
                    {
                        if (List[i].heroClass != HeroClass.Warrior)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlyKnight:
                    while (i < List.Count)
                    {
                        if (List[i].heroClass != HeroClass.Knight)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlyThief:
                    while (i < List.Count)
                    {
                        if (List[i].heroClass != HeroClass.Thief)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlyMage:
                    while (i < List.Count)
                    {
                        if (List[i].heroClass != HeroClass.Mage)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlyRanger:
                    while (i < List.Count)
                    {
                        if (List[i].heroClass != HeroClass.Ranger)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlySoulWeaver:
                    while (i < List.Count)
                    {
                        if (List[i].heroClass != HeroClass.SoulWeaver)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;

                case FilterType.RemoveAllDummyClass:
                    while (i < List.Count)
                    {
                        if (List[i].heroClass == HeroClass.DummyClass)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllWarrior:
                    while (i < List.Count)
                    {
                        if (List[i].heroClass == HeroClass.Warrior)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllKnight:
                    while (i < List.Count)
                    {
                        if (List[i].heroClass == HeroClass.Knight)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllThief:
                    while (i < List.Count)
                    {
                        if (List[i].heroClass == HeroClass.Thief)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllMage:
                    while (i < List.Count)
                    {
                        if (List[i].heroClass == HeroClass.Mage)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllRanger:
                    while (i < List.Count)
                    {
                        if (List[i].heroClass == HeroClass.Ranger)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllSoulWeaver:
                    while (i < List.Count)
                    {
                        if (List[i].heroClass == HeroClass.SoulWeaver)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;


                case FilterType.OnlyStars3:
                    while (i < List.Count)
                    {
                        if (List[i].heroRarity != HeroRarity.Stars3)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlyStars4:
                    while (i < List.Count)
                    {
                        if (List[i].heroRarity != HeroRarity.Stars4)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlyStars5:
                    while (i < List.Count)
                    {
                        if (List[i].heroRarity != HeroRarity.Stars5)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;

                case FilterType.RemoveAllStars3:
                    while (i < List.Count)
                    {
                        if (List[i].heroRarity == HeroRarity.Stars3)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllStars4:
                    while (i < List.Count)
                    {
                        if (List[i].heroRarity == HeroRarity.Stars4)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllStars5:
                    while (i < List.Count)
                    {
                        if (List[i].heroRarity == HeroRarity.Stars5)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;


                case FilterType.OnlyMales:
                    while (i < List.Count)
                    {
                        if (List[i].heroGender != HeroGender.Male)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlyFemales:
                    while (i < List.Count)
                    {
                        if (List[i].heroGender != HeroGender.Female)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;

                case FilterType.RemoveAllMales:
                    while (i < List.Count)
                    {
                        if (List[i].heroGender == HeroGender.Male)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllFemales:
                    while (i < List.Count)
                    {
                        if (List[i].heroGender == HeroGender.Female)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;


                case FilterType.OnlyClothesChange:
                    while (i < List.Count)
                    {
                        if (!List[i].properties.Contains(Property.ClothesChange))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlySpecialtyChange:
                    while (i < List.Count)
                    {
                        if (!List[i].properties.Contains(Property.SpecialtyChange))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlyCollab:
                    while (i < List.Count)
                    {
                        if (!List[i].properties.Contains(Property.Collab))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.OnlySkin:
                    while (i < List.Count)
                    {
                        if (!List[i].properties.Contains(Property.Skin))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;

                case FilterType.RemoveAllClothesChange:
                    while (i < List.Count)
                    {
                        if (List[i].properties.Contains(Property.ClothesChange))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllSpecialtyChange:
                    while (i < List.Count)
                    {
                        if (List[i].properties.Contains(Property.SpecialtyChange))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllCollab:
                    while (i < List.Count)
                    {
                        if (List[i].properties.Contains(Property.Collab))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.RemoveAllSkin:
                    while (i < List.Count)
                    {
                        if (List[i].properties.Contains(Property.Skin))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
            }
        }

        /// <summary>
        /// Check if the folder contains the images for the characters in the proper format<br></br>
        /// If not, open Chrome tabs for each missing character
        /// </summary>
        public void OpenMissingImagesWeb()
        {
            string url = "https://www.e7vau.lt/portrait-viewer.html?id=";
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "Portraits";
            if (!Directory.Exists(appPath)) Directory.CreateDirectory(appPath);

            foreach (Character c in List)
            {
                if (!File.Exists(appPath + Path.DirectorySeparatorChar + c.cid + ".png"))
                {
                    OpenNewTab(url + c.cid);
                }
            }
        }

        /// <summary>
        /// Open a new Chrome tab with the provvided url
        /// </summary>
        /// <param name="url">URL to open</param>
        /// <param name="retry">Always true, if false Chrome won't launch if not open</param>
        private void OpenNewTab(string url, bool retry = true)
        {
            Process[] chromeProcesses = Process.GetProcessesByName("chrome");
            if (chromeProcesses.Length > 0)
            {
                foreach (Process chromeProcess in chromeProcesses)
                {
                    if (chromeProcess.MainWindowHandle != IntPtr.Zero)
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.FileName = "chrome.exe";
                        startInfo.Arguments = "--new-tab " + url;
                        Process.Start(startInfo);
                        return;
                    }
                }
            }

            // No existing Chrome window found, start a new instance with the specified URL
            Process.Start("chrome.exe", "--new-window " + url);
            if (retry) OpenNewTab(url, false);
        }
    }
}
