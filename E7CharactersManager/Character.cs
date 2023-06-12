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
        public Character(string name, string cid,HeroElement heroElement,  HeroGender heroGender, HeroClass heroClass, params Property[] properties)
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
            //            Character Name,                             Character ID, Character Element, Character Gender,    HeroClass,            Hero Properties
            new Character("Abigail",                                  "c1144",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Achates",                                  "c1017",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Achates: Azure Sea",                       "c1017_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver, Property.Skin),
            new Character("Adin",                                     "c3143",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Adlay",                                    "c3043",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Adventurer Ras",                           "c5001",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Ainos",                                    "c3105",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Ainos 2.0",                                "c4105",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Ains",                                     "c3093",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Aither",                                   "c1018",      HeroElement.Light, HeroGender.Male,     HeroClass.SoulWeaver),
            new Character("Aither: Star of Ezera",                    "c1018_s01",  HeroElement.Light, HeroGender.Male,     HeroClass.SoulWeaver, Property.Skin),
            new Character("Alencia",                                  "c1100",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Alencia: Gift Granny",                     "c1100_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   , Property.Skin),
            new Character("Alexa",                                    "c3012",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("All-Rounder Wanda",                        "c4065",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Ambitious Tywin",                          "c2042",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Amid",                                     "c1143",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Angel of Light Angelica",                  "c6062",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Angelic Montmorancy",                      "c4042",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Angelic Montmorancy: Serene Sea",          "c4042_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver, Property.Skin),
            new Character("Angelica",                                 "c1062",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Angelica: Mysterious Transfer Student",    "c1062_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver, Property.Skin),
            new Character("Apocalypse Ravi",                          "c2019",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Apocalypse Ravi: Avatar of Bloodlust",     "c2019_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   , Property.Skin),
            new Character("Aramintha",                                "c1048",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Arbiter Vildred",                          "c2007",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Arbiter Vildred: Dark Monarch",            "c2007_s01",  HeroElement.Light, HeroGender.Male,     HeroClass.Thief     , Property.Skin),
            new Character("Archdemon's Shadow",                       "c5004",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Architect Laika",                          "c2099",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Aria",                                     "c1129",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Armin",                                    "c1008",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Arowell",                                  "c3004",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Arunka",                                   "c1124",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Assassin Cartuja",                         "c2013",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Assassin Cidd",                            "c2014",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Assassin Coli",                            "c2033",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Astromancer Elena",                        "c2091",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Auxiliary Lots",                           "c2031",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Azalea",                                   "c3031",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Baal & Sezan",                             "c1015",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Bad Cat Armin",                            "c6008",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Baiken",                                   "c1093",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     , Property.Collab),
            new Character("Basar",                                    "c1053",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Basar: Sophisticated Magnate",             "c1053_s01",  HeroElement.Light, HeroGender.Male,     HeroClass.Mage      , Property.Skin),
            new Character("Bask",                                     "c3006",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Batisse",                                  "c3095",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Beehoo",                                   "c1141",      HeroElement.Light, HeroGender.Male,     HeroClass.Ranger    ),
            new Character("Belian",                                   "c1117",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Bellona",                                  "c1071",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Benevolent Romann",                        "c2043",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Benimaru",                                 "c1146",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   , Property.Collab),
            new Character("Blaze Dingo",                              "c2021",      HeroElement.Light, HeroGender.Male,     HeroClass.SoulWeaver),
            new Character("Blood Blade Karin",                        "c2011",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Blood Moon Haste",                         "c2039",      HeroElement.Light, HeroGender.Male,     HeroClass.SoulWeaver),
            new Character("Bomb Model Kanna",                         "c1097",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Bomb Model Kanna: Special Gift",           "c1097_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    , Property.Skin),
            new Character("Briar Witch Iseria",                       "c2024",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Butcher Corps Inquisitor",                 "c3001",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Camilla",                                  "c3124",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Captain Rikoris",                          "c4034",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Carmainerose",                             "c3071",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Carrot",                                   "c3051",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Cartuja",                                  "c1013",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Cecilia",                                  "c1002",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Cecilia: Black-Winged Succubus",           "c1002_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Knight    , Property.Skin),
            new Character("Celeste",                                  "c3064",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Celestial Mercedes",                       "c2005",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Celine",                                   "c1103",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Cerise",                                   "c1081",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Cermia",                                   "c1079",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Cermia: Beachside Merrymakes",             "c1079_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   , Property.Skin),
            new Character("Challenger Dominiel",                      "c2037",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Champion Zerato",                          "c2010",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Chaos Inquisitor",                         "c4001",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Chaos Sect Axe",                           "c4025",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Charles",                                  "c1027",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Charles: Demon Hunter",                    "c1027_s01",  HeroElement.Light, HeroGender.Male,     HeroClass.Knight    , Property.Skin),
            new Character("Charlotte",                                "c1009",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Chloe",                                    "c1049",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Choux",                                    "c1101",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Choux: 2022 E7WC",                         "c1101_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   , Property.Skin),
            new Character("Christy",                                  "c3123",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Church of Ilryos Axe",                     "c3025",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Cidd",                                     "c1014",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Cidd: Masked Gentleman",                   "c1014_s01",  HeroElement.Light, HeroGender.Male,     HeroClass.Thief     , Property.Skin),
            new Character("Clarissa",                                 "c1028",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Closer Charles",                           "c2027",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Coli",                                     "c1033",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Command Model Laika",                      "c1099",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Commander Lorina",                         "c4035",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Commander Pavel",                          "c2080",      HeroElement.Light, HeroGender.Male,     HeroClass.Ranger    ),
            new Character("Conqueror Lilias",                         "c2089",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Corvus",                                   "c1012",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Crescent Moon Rin",                        "c2054",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Crimson Armin",                            "c2008",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Crozet",                                   "c1036",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Dark Corvus",                              "c2012",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Death Dealer Ray",                         "c2090",      HeroElement.Light, HeroGender.Male,     HeroClass.SoulWeaver),
            new Character("Desert Jewel Basar",                       "c2053",      HeroElement.Light, HeroGender.Male,     HeroClass.SoulWeaver),
            new Character("Designer Lilibet",                         "c2095",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Destina",                                  "c2022",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Destina: Spring Breeze",                   "c2022_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver, Property.Skin),
            new Character("Diene",                                    "c1076",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Diene: Magical Girl",                      "c1076_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver, Property.Skin),
            new Character("Dingo",                                    "c1021",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Dizzy",                                    "c1094",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      , Property.Collab),
            new Character("Doll Maker Pearlhorizon",                  "c4073",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Dominiel",                                 "c1037",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Doris",                                    "c3044",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Eaton",                                    "c3094",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Eda",                                      "c1111",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Edward Elric",                             "c1134",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   , Property.Collab),
            new Character("Elena",                                    "c1091",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Elena: Starlit Melody",                    "c1091_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver, Property.Skin),
            new Character("Eligos",                                   "c1142",      HeroElement.Light, HeroGender.Male,     HeroClass.Ranger    ),
            new Character("Elphelt",                                  "c1105",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    , Property.Collab),
            new Character("Elson",                                    "c3054",      HeroElement.Light, HeroGender.Male,     HeroClass.SoulWeaver),
            new Character("Emilia",                                   "c1116",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver, Property.Collab),
            new Character("Enott",                                    "c3022",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Ervalen",                                  "c1108",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Fairytale Tenebria",                       "c5050",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Faithless Lidica",                         "c2046",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Faithless Lidica: Victorious Knight",      "c2046_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    , Property.Skin),
            new Character("Falconer Kluri",                           "c4003",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Fallen Cecilia",                           "c2002",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Fallen Cecilia: White Warmth",             "c2002_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Knight    , Property.Skin),
            new Character("Fighter Maya",                             "c2032",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Flan",                                     "c1110",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Free Spirit Tieria",                       "c3026",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
          //new Character("Free Spirit Tieria",                       "c3026_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   , Property.Skin), TODO skin unknown
            new Character("Furious",                                  "c1087",      HeroElement.Light, HeroGender.Male,     HeroClass.Ranger    ),
            new Character("General Purrgis",                          "c2035",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Glenn",                                    "c3103",      HeroElement.Light, HeroGender.Male,     HeroClass.Ranger    ),
            new Character("Gloomyrain",                               "c3074",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Godmother",                                "c3101",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Great Chief Khawana",                      "c2086",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Guider Aither",                            "c2018",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Gunther",                                  "c3024",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Hasol",                                    "c3135",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Haste",                                    "c1039",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Hataan",                                   "c3091",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Hazel",                                    "c3041",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Helen",                                    "c3122",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Helga",                                    "c3023",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Holiday Yufine",                           "c5016",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Holy Flame Adin",                          "c4141",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Hurado",                                   "c3055",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Hwayoung",                                 "c1128",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Ian",                                      "c3102",      HeroElement.Light, HeroGender.Male,     HeroClass.Ranger    ),
            new Character("Ilynav",                                   "c1113",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Inferno Khawazu",                          "c2085",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Iseria",                                   "c1024",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Iseria: Night of White Flowers",           "c1024_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    , Property.Skin),
            new Character("Jack O’",                                  "c1130",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   , Property.Collab),
            new Character("Januta",                                   "c3131",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Jecht",                                    "c3053",      HeroElement.Light, HeroGender.Male,     HeroClass.SoulWeaver),
            new Character("Jena",                                     "c3052",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Judge Kise",                               "c2006",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Judge Kise: Heir of Holy Light",           "c2006_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   , Property.Skin),
            new Character("Judith",                                   "c3011",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Juni",                                     "c3151",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Karin",                                    "c1011",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Karin: Shore Patrol",                      "c1011_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Thief     , Property.Skin),
            new Character("Kawerik",                                  "c1073",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Kayron",                                   "c1023",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Kayron: Time Rabbit",                      "c1023_s01",  HeroElement.Light, HeroGender.Male,     HeroClass.Thief     , Property.Skin),
            new Character("Ken",                                      "c1047",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Khawana",                                  "c1086",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Khawazu",                                  "c1085",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Kikirat v2",                               "c3084",      HeroElement.Light, HeroGender.Male,   HeroClass.Knight    ),
            new Character("Kiris",                                    "c3063",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Kise",                                     "c1006",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Kitty Clarissa",                           "c2028",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Kizuna AI",                                "c1107",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver, Property.Collab),
            new Character("Kluri",                                    "c3003",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Krau",                                     "c1070",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Landy",                                    "c1109",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Last Piece Karin",                         "c6011",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Last Rider Krau",                          "c2070",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Lena",                                     "c3092",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Leo",                                      "c1029",      HeroElement.Light, HeroGender.Male,     HeroClass.Ranger    ),
            new Character("Lidica",                                   "c1046",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Lidica: Bride of Roses",                   "c1046_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    , Property.Skin),
            new Character("Lilias",                                   "c1089",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Lilibet",                                  "c1095",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Lilka",                                    "c3153",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Lionheart Cermia",                         "c2079",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Little Queen Charlotte",                   "c2009",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Little Queen Charlotte: Elegant Excurion", "c2009_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   , Property.Skin),
            new Character("Lone Crescent Bellona",                    "c2071",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Lorina",                                   "c3035",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Lots",                                     "c1031",      HeroElement.Light, HeroGender.Male,     HeroClass.SoulWeaver),
            new Character("Lua",                                      "c1126",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Lucy",                                     "c3113",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Ludwig",                                   "c1069",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Luluca",                                   "c1082",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Luluca: Lovely Patissiere",                "c1082_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Mage      , Property.Skin),
            new Character("Luna",                                     "c1066",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Magic Scholar Doris",                      "c4044",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Maid Chloe",                               "c2049",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Maid Chloe: Energetic",                    "c2049_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver, Property.Skin),
            new Character("Martial Artist Ken",                       "c2047",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Mascot Hazel",                             "c4041",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Maya",                                     "c1032",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Mediator Kawerik",                         "c2073",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Mediator Kawerik: Calamity's Equilibrium", "c2073_s01",  HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   , Property.Skin),
            new Character("Melany",                                   "c3121",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Melissa",                                  "c1096",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Mercedes",                                 "c0002",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
          //new Character("Mercedes",                                 "c1005",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ), before power up
            new Character("Mercedes: Fluffy Lady",                    "c1005_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Mage      , Property.Skin),
            new Character("Mercenary Helga",                          "c4023",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Milim",                                    "c1122",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      , Property.Collab),
            new Character("Mirsa",                                    "c3014",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Mistychain",                               "c3072",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Montmorancy",                              "c3042",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Moon Bunny Dominiel",                      "c6037",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Mort",                                     "c1104",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Mucacha",                                  "c3033",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Mui",                                      "c1044",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Muse Rima",                                "c4062",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Muwi",                                     "c3132",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Nemunas",                                  "c3061",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Operator Sigret",                          "c2072",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Orte",                                     "c3133",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Otillie",                                  "c3045",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Pavel",                                    "c1080",      HeroElement.Light, HeroGender.Male,     HeroClass.Ranger    ),
            new Character("Peacemaker Furious",                       "c2087",      HeroElement.Light, HeroGender.Male,     HeroClass.Ranger    ),
            new Character("Pearlhorizon",                             "c3073",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Peira",                                    "c1125",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Penelope",                                 "c3125",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Pirate Captain Flan",                      "c2110",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Politis",                                  "c1112",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Purrgis",                                  "c1035",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Pyllis",                                   "c3005",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Ram",                                      "c1115",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      , Property.Collab),
            new Character("Ran",                                      "c1118",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Ran: Pure White Heart",                    "c1118_s01",  HeroElement.Light, HeroGender.Male,     HeroClass.Thief     , Property.Skin),
            new Character("Ras",                                      "c1001",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Vagabond Ras",                             "c1078",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Ravi",                                     "c1019",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Ray",                                      "c1090",      HeroElement.Light, HeroGender.Male,     HeroClass.SoulWeaver),
            new Character("Rem",                                      "c1114",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   , Property.Collab),
            new Character("Remnant Violet",                           "c2074",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Requiem Roana",                            "c2102",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Requiemroar",                              "c3075",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Researcher Carrot",                        "c4051",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Righteous Thief Roozid",                   "c4013",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Rikoris",                                  "c3034",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Rima",                                     "c3062",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Rimuru",                                   "c1121",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   , Property.Collab),
            new Character("Rin",                                      "c1054",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Riza Hawkeye",                             "c1136",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    , Property.Collab),
            new Character("Roaming Warrior Leo",                      "c2029",      HeroElement.Light, HeroGender.Male,     HeroClass.Ranger    ),
            new Character("Roana",                                    "c1102",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Romann",                                   "c1043",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Roozid",                                   "c3013",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Rose",                                     "c1003",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Rose: Dark Angel",                         "c1003_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Knight    , Property.Skin),
            new Character("Roy Mustang",                              "c1135",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      , Property.Collab),
            new Character("Ruele of Light",                           "c1022",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Ruele of Light: Heir of Radiance",         "c1022_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver, Property.Skin),
            new Character("Sage Baal & Sezan",                        "c2015",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Schuri",                                   "c1020",      HeroElement.Light, HeroGender.Male,     HeroClass.Ranger    ),
            new Character("Seaside Bellona",                          "c5071",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Senya",                                    "c1106",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Serene Purity Adin",                       "c4142",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Serila",                                   "c1040",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Sez",                                      "c1038",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Sez: Aloof Lifeguard",                     "c1038_s01",  HeroElement.Light, HeroGender.Male,     HeroClass.Thief     , Property.Skin),
            new Character("Shadow Knight Pyllis",                     "c4005",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Shadow Rose",                              "c2003",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Sharun",                                   "c1132",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Shepherd Jena",                            "c4052",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Shooting Star Achates",                    "c2017",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Shuna",                                    "c1123",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver, Property.Collab),
            new Character("Sigret",                                   "c1072",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Silk",                                     "c1004",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Silver Blade Aramintha",                   "c2048",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Sinful Angelica",                          "c2062",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Sol",                                      "c1092",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   , Property.Collab),
            new Character("Solitaria of the Snow",                    "c2111",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Sonia",                                    "c3104",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Specimen Sez",                             "c2038",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Specter Tenebria",                         "c2050",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Specter Tenebria: Dark Tyrant",            "c2050_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Mage      , Property.Skin),
            new Character("Spirit Eye Celine",                        "c2103",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Straze",                                   "c1034",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Summer Break Charlotte",                   "c5009",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Summer's Disciple Alexa",                  "c4012",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Summertime Iseria",                        "c5024",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
          //new Character("Support Model Brinus",                     "c1098",      HeroElement.Light, HeroGender.Female,   HeroClass.DummyClass),
            new Character("Surin",                                    "c1065",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Suthan",                                   "c3155",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Sven",                                     "c3015",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Sylvan Sage Vivian",                       "c2088",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Taeyou",                                   "c1127",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Talaz",                                    "c3152",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Talia",                                    "c3154",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Tamarinne",                                "c1067",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver),
            new Character("Tamarinne: Starlit Concert",               "c1067_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver, Property.Skin),
            new Character("Taranor Guard",                            "c3032",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Taranor Royal Guard",                      "c3002",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Tempest Surin",                            "c2065",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Tempest Surin: Autuman Beauty",            "c2065_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Thief     , Property.Skin),
            new Character("Tenebria",                                 "c1050",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Tenebria: Phantom Schoolgirl",             "c1050_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Mage      , Property.Skin),
            new Character("Tieria",                                   "c3021",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Top Model Luluca",                         "c2082",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Troublemaker Crozet",                      "c2036",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Twisted Eidolon Kayron",                   "c2023",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Tywin",                                    "c1042",      HeroElement.Light, HeroGender.Male,     HeroClass.Knight    ),
            new Character("Unbound Knight Arowell",                   "c4004",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Verdant Adin",                             "c4143",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     ),
            new Character("Vigilante Leader Glenn",                   "c4103",      HeroElement.Light, HeroGender.Male,     HeroClass.Ranger    ),
            new Character("Vildred",                                  "c1007",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Vildred: Distinguished Gentleman",         "c1007_s01",  HeroElement.Light, HeroGender.Male,     HeroClass.Thief     , Property.Skin),
          //new Character("Vildred",                                  "c1007t",     HeroElement.Light, HeroGender.Male,     HeroClass.SoulWeaver), no scar variant
            new Character("Violet",                                   "c1074",      HeroElement.Light, HeroGender.Male,     HeroClass.Thief     ),
            new Character("Violet: Ardent Gentleman",                 "c1074_s01",  HeroElement.Light, HeroGender.Male,     HeroClass.Thief     , Property.Skin),
            new Character("Vivian",                                   "c1088",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Vivian: Villainess",                       "c1088_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Mage      , Property.Skin),
            new Character("Wanda",                                    "c3065",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Wanderer Silk",                            "c2004",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Watcher Schuri",                           "c2020",      HeroElement.Light, HeroGender.Male,     HeroClass.Ranger    ),
            new Character("Yoonryoung",                               "c3134",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Yufine",                                   "c1016",      HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   ),
            new Character("Yufine: Adorable Flower Bud",              "c1016_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Warrior   , Property.Skin),
            new Character("Yulha",                                    "c1131",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    ),
            new Character("Yuna",                                     "c1030",      HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    ),
            new Character("Yuna: Afterschool Party!",                 "c1030_s01",  HeroElement.Light, HeroGender.Female,   HeroClass.Ranger    , Property.Skin),
            new Character("Zahhak",                                   "c1119",      HeroElement.Light, HeroGender.Male,     HeroClass.Warrior   ),
            new Character("Zealot Carmainerose",                      "c4071",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      ),
            new Character("Zeno",                                     "c1083",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Zerato",                                   "c1010",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("Zio",                                      "c1133",      HeroElement.Light, HeroGender.Male,     HeroClass.Mage      ),
            new Character("ae-GISELLE",                               "c1138",      HeroElement.Light, HeroGender.Female,   HeroClass.Mage      , Property.Collab),
            new Character("ae-KARINA",                                "c1137",      HeroElement.Light, HeroGender.Female,   HeroClass.Knight    , Property.Collab),
            new Character("ae-NINGNING",                              "c1140",      HeroElement.Light, HeroGender.Female,   HeroClass.SoulWeaver, Property.Collab),
            new Character("ae-WINTER",                                "c1139",      HeroElement.Light, HeroGender.Female,   HeroClass.Thief     , Property.Collab),
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
