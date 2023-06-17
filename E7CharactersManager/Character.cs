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
        public string Name { get; private set; } = "";
        /// <summary>
        /// Character unique ID
        /// </summary>
        public string CID { get; private set; } = "";
        /// <summary>
        /// Element of the Hero
        /// </summary>
        public HeroElement HeroElement { get; private set; }
        /// <summary>
        /// Class of the Hero
        /// </summary>
        public HeroClass HeroClass { get; private set; }
        /// <summary>
        /// Rarity of the Hero
        /// </summary>
        public HeroRarity HeroRarity { get; private set; }
        /// <summary>
        /// Gender of the Hero
        /// </summary>
        public HeroGender HeroGender { get; private set; }
        /// <summary>
        /// If the character is a skin, indicates whose skin it is
        /// </summary>
        public Character SkinOf { get; private set; }
        /// <summary>
        /// Additional properties a Hero can have
        /// </summary>
        public List<Property> Properties { get; private set; } = new List<Property>();
        /// <summary>
        /// Create a new character object from the information given
        /// </summary>
        /// <param name="name">Name of the Hero</param>
        /// <param name="cid">Unique ID of the Hero</param>
        /// <param name="heroElement">Element of the Hero</param>
        /// <param name="heroRarity">Rariry of the Hero</param>
        /// <param name="heroClass">Class of the Hero</param>
        /// <param name="heroGender">Gender of the Hero</param>
        /// <param name="relatedHero">Skin of the Hero or Hero whose specialty change is this Hero</param>
        /// <param name="properties">Addidional properties a Hero can have</param>
        public Character(string name, string cid, HeroElement heroElement, HeroRarity heroRarity, HeroClass heroClass, HeroGender heroGender, Character relatedHero , params Property[] properties)
        {
            this.Name = name;
            this.CID = cid;
            this.HeroElement = heroElement;
            this.HeroRarity = heroRarity;
            this.HeroClass = heroClass;
            this.SkinOf = relatedHero;
            this.HeroGender = heroGender;
            foreach (Property p in properties)
                this.Properties.Add(p);
        }
        /// <summary>
        /// Create a new character object from the information given
        /// </summary>
        /// <param name="name">Name of the Hero</param>
        /// <param name="cid">Unique ID of the Hero</param>
        /// <param name="heroElement">Element of the Hero</param>
        /// <param name="heroRarity">Rariry of the Hero</param>
        /// <param name="heroClass">Class of the Hero</param>
        /// <param name="heroGender">Gender of the Hero</param>
        /// <param name="properties">Addidional properties a Hero can have</param>
        public Character(string name, string cid, HeroElement heroElement, HeroRarity heroRarity, HeroClass heroClass, HeroGender heroGender, params Property[] properties) : this (name, cid, heroElement, heroRarity, heroClass, heroGender, null, properties){ }
        public override string ToString()
        {
            return Name;
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
        Collab,
        Disabled
    }
    /// <summary>
    /// Type of filter to apply on List
    /// </summary>
    public struct FilterType
    {
        /// <summary>
        /// Filter by Hero element
        /// </summary>
        public enum ByElement
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
            RemoveAllDark
        }
        /// <summary>
        /// Filter by Hero class
        /// </summary>
        public enum ByClass
        {
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
            RemoveAllSoulWeaver
        }
        /// <summary>
        /// Filter by Hero rarity
        /// </summary>
        public enum ByRarity
        {
            OnlyStars3,
            OnlyStars4,
            OnlyStars5,

            RemoveAllStars3,
            RemoveAllStars4,
            RemoveAllStars5
        }
        /// <summary>
        /// Filter by Hero gender
        /// </summary>
        public enum ByGender
        {
            OnlyMales,
            OnlyFemales,

            RemoveAllMales,
            RemoveAllFemales
        }
        /// <summary>
        /// Filter by Hero extra properties
        /// </summary>
        public enum ByProperty
        {
            OnlyClothesChange,
            OnlySpecialtyChange,
            OnlyCollab,
            OnlySkin,

            RemoveAllClothesChange,
            RemoveAllSpecialtyChange,
            RemoveAllCollab,
            RemoveAllSkin
        }
    }

    internal class CharactersList
    {
        /// <summary>
        /// List containing all characters by default. Can be modified by applying filters
        /// </summary>
        public List<Character> List { get; private set; } = new List<Character>();

        public CharactersList()
        {
            //                                  Character Name,                             Character ID, Character Element, HeroRarity,        HeroClass,            Character Gender,  Hero Propertie;                                    Add to list
            /// Abigail                                                                                                                                                                                                                     
            Character c1144     = new Character("Abigail",                                  "c1144",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c1144);
            /// Achates                                                                                                                                                                                                                     
            Character c1017     = new Character("Achates",                                  "c1017",      HeroElement.Fire,  HeroRarity.Stars4, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c1017);
            Character c1017_s01 = new Character("Achates: Azure Sea",                       "c1017_s01",  HeroElement.Fire,  HeroRarity.Stars4, HeroClass.SoulWeaver, HeroGender.Female, c1017, Property.Skin);                             List.Add(c1017_s01);
            Character c2017     = new Character("Shooting Star Achates",                    "c2017",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c2017);
            /// Adin                                                                                                                                                                                                                        
            Character c3143     = new Character("Adin",                                     "c3143",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c3143);
            Character c4141     = new Character("Holy Flame Adin",                          "c4141",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Female, c3143, Property.SpecialtyChange);                  List.Add(c4141);
            Character c4142     = new Character("Serene Purity Adin",                       "c4142",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Female, c3143, Property.SpecialtyChange);                  List.Add(c4142);
            Character c4143     = new Character("Verdant Adin",                             "c4143",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Female, c3143, Property.SpecialtyChange);                  List.Add(c4143);
            Character c4144     = new Character("Savior Adin",                              "c4144",      HeroElement.Light, HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Female, c3143, Property.SpecialtyChange);                  List.Add(c4144);
            /// Adlay                                                                                                                                                                                                                       
            Character c3043     = new Character("Adlay",                                    "c3043",      HeroElement.Earth, HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c3043);
            /// Ainos                                                                                                                                                                                                                       
            Character c3105     = new Character("Ainos",                                    "c3105",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c3105);
            Character c4105     = new Character("Ainos 2.0",                                "c4105",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Female, c3105, Property.SpecialtyChange);                  List.Add(c4105);
            /// Ains                                                                                                                                                                                                                        
            Character c3093     = new Character("Ains",                                     "c3093",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Male);                                                     List.Add(c3093);
            /// Aither                                                                                                                                                                                                                      
            Character c1018     = new Character("Aither",                                   "c1018",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Male  );                                                   List.Add(c1018);
            Character c1018_s01 = new Character("Aither: Star of Ezera",                    "c1018_s01",  HeroElement.Ice,   HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Male,   c1018, Property.Skin);                             List.Add(c1018_s01);
            Character c2018     = new Character("Guider Aither",                            "c2018",      HeroElement.Light, HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c2018);
            /// Alencia                                                                                                                                                                                                                     
            Character c1100     = new Character("Alencia",                                  "c1100",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c1100);
            Character c1100_s01 = new Character("Alencia: Gift Granny",                     "c1100_s01",  HeroElement.Earth, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female, c1100, Property.Skin);                             List.Add(c1100_s01);
            /// Alexa                                                                                                                                                                                                                       
            Character c3012     = new Character("Alexa",                                    "c3012",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c3012);
            Character c4012     = new Character("Summer's Disciple Alexa",                  "c4012",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Female, c3012, Property.SpecialtyChange);                  List.Add(c4012);
            /// Amid                                                                                                                                                                                                                        
            Character c1143     = new Character("Amid",                                     "c1143",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c1143);
            /// Angelica                                                                                                                                                                                                                    
            Character c1062     = new Character("Angelica",                                 "c1062",      HeroElement.Ice,   HeroRarity.Stars4, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c1062);
            Character c1062_s01 = new Character("Angelica: Mysterious Transfer Student",    "c1062_s01",  HeroElement.Ice,   HeroRarity.Stars4, HeroClass.SoulWeaver, HeroGender.Female, c1062, Property.Skin);                             List.Add(c1062_s01);
            Character c2062     = new Character("Sinful Angelica",                          "c2062",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c2062);
            Character c6062     = new Character("Angel of Light Angelica",                  "c6062",      HeroElement.Light, HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c6062);
            /// Aramintha                                                                                                                                                                                                                   
            Character c1048     = new Character("Aramintha",                                "c1048",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c1048);
            Character c2048     = new Character("Silver Blade Aramintha",                   "c2048",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c2048);
            /// Aria                                                                                                                                                                                                                        
            Character c1129     = new Character("Aria",                                     "c1129",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c1129);
            /// Armin                                                                                                                                                                                                                       
            Character c1008     = new Character("Armin",                                    "c1008",      HeroElement.Earth, HeroRarity.Stars4, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c1008);
            Character c2008     = new Character("Crimson Armin",                            "c2008",      HeroElement.Light, HeroRarity.Stars4, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c2008);
            Character c6008     = new Character("Bad Cat Armin",                            "c6008",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c6008);
            /// Arowell                                                                                                                                                                                                                     
            Character c3004     = new Character("Arowell",                                  "c3004",      HeroElement.Light, HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c3004);
            Character c4004     = new Character("Unbound Knight Arowell",                   "c4004",      HeroElement.Light, HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Female, c3004, Property.SpecialtyChange);                  List.Add(c4004);
            /// Arunka                                                                                                                                                                                                                      
            Character c1124     = new Character("Arunka",                                   "c1124",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c1124);
            /// Azalea                                                                                                                                                                                                                      
            Character c3031     = new Character("Azalea",                                   "c3031",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c3031);
            /// Baal                                                                                                                                                                                                                        
            Character c1015     = new Character("Baal & Sezan",                             "c1015",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c1015);
            Character c2015     = new Character("Sage Baal & Sezan",                        "c2015",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c2015);
            /// Basar                                                                                                                                                                                                                       
            Character c1053     = new Character("Basar",                                    "c1053",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c1053);
            Character c1053_s01 = new Character("Basar: Sophisticated Magnate",             "c1053_s01",  HeroElement.Earth, HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Male,   c1053, Property.Skin);                             List.Add(c1053_s01);
            Character c2053     = new Character("Desert Jewel Basar",                       "c2053",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  );                                                   List.Add(c2053);
            /// Bask                                                                                                                                                                                                                        
            Character c3006     = new Character("Bask",                                     "c3006",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c3006);
            /// Batisse                                                                                                                                                                                                                     
            Character c3095     = new Character("Batisse",                                  "c3095",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c3095);
            /// Beehoo                                                                                                                                                                                                                      
            Character c1141     = new Character("Beehoo",                                   "c1141",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Male  );                                                   List.Add(c1141);
            /// Belian                                                                                                                                                                                                                      
            Character c1117     = new Character("Belian",                                   "c1117",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c1117);
            /// Bellona                                                                                                                                                                                                                     
            Character c1071     = new Character("Bellona",                                  "c1071",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c1071);
            Character c2071     = new Character("Lone Crescent Bellona",                    "c2071",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c2071);
            Character c5071     = new Character("Seaside Bellona",                          "c5071",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c5071);
            /// Bomb Model Kanna                                                                                                                                                                                                            
            Character c1097     = new Character("Bomb Model Kanna",                         "c1097",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c1097);
            Character c1097_s01 = new Character("Bomb Model Kanna: Special Gift",           "c1097_s01",  HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female, c1097, Property.Skin);                             List.Add(c1097_s01);
            /// Brinus
            Character c1098     = new Character("Support Model Brinus",                     "c1098",      HeroElement.Light, HeroRarity.Stars5, HeroClass.DummyClass, HeroGender.Female, Property.Disabled);                                List.Add(c1098);
            /// Camilla                                                                                                                                                                                                                     
            Character c3124     = new Character("Camilla",                                  "c3124",      HeroElement.Light, HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c3124);
            /// Carmainerose                                                                                                                                                                                                                
            Character c3071     = new Character("Carmainerose",                             "c3071",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c3071);
            Character c4071     = new Character("Zealot Carmainerose",                      "c4071",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Mage,       HeroGender.Female, c3071, Property.SpecialtyChange);                  List.Add(c4071);
            /// Carrot                                                                                                                                                                                                                      
            Character c3051     = new Character("Carrot",                                   "c3051",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c3051);
            Character c4051     = new Character("Researcher Carrot",                        "c4051",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Mage,       HeroGender.Female, c3051, Property.SpecialtyChange);                  List.Add(c4051);
            /// Cartuja                                                                                                                                                                                                                     
            Character c1013     = new Character("Cartuja",                                  "c1013",      HeroElement.Earth, HeroRarity.Stars4, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c1013);
            Character c2013     = new Character("Assassin Cartuja",                         "c2013",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c2013);
            /// Cecilia                                                                                                                                                                                                                     
            Character c1002     = new Character("Cecilia",                                  "c1002",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c1002);
            Character c1002_s01 = new Character("Cecilia: Black-Winged Succubus",           "c1002_s01",  HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Female, c1002, Property.Skin);                             List.Add(c1002_s01);
            Character c2002     = new Character("Fallen Cecilia",                           "c2002",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c2002);
            Character c2002_s01 = new Character("Fallen Cecilia: White Warmth",             "c2002_s01",  HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Female, c2002, Property.Skin);                             List.Add(c2002_s01);
            /// Celeste                                                                                                                                                                                                                     
            Character c3064     = new Character("Celeste",                                  "c3064",      HeroElement.Light, HeroRarity.Stars3, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c3064);
            /// Celine                                                                                                                                                                                                                      
            Character c1103     = new Character("Celine",                                   "c1103",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c1103);
            Character c2103     = new Character("Spirit Eye Celine",                        "c2103",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c2103);
            /// Cerise                                                                                                                                                                                                                      
            Character c1081     = new Character("Cerise",                                   "c1081",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c1081);
            /// Cermia                                                                                                                                                                                                                      
            Character c1079     = new Character("Cermia",                                   "c1079",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c1079);
            Character c1079_s01 = new Character("Cermia: Beachside Merrymakes",             "c1079_s01",  HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female, c1079, Property.Skin);                             List.Add(c1079_s01);
            Character c2079     = new Character("Lionheart Cermia",                         "c2079",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c2079);
            /// Charles                                                                                                                                                                                                                     
            Character c1027     = new Character("Charles",                                  "c1027",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c1027);
            Character c2027     = new Character("Closer Charles",                           "c2027",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c2027);
            Character c1027_s01 = new Character("Charles: Demon Hunter",                    "c1027_s01",  HeroElement.Earth, HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Male,   c1027, Property.Skin);                             List.Add(c1027_s01);
            /// Charlotte                                                                                                                                                                                                                   
            Character c1009     = new Character("Charlotte",                                "c1009",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c1009);
            Character c2009     = new Character("Little Queen Charlotte",                   "c2009",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c2009);
            Character c2009_s01 = new Character("Little Queen Charlotte: Elegant Excurion", "c2009_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female, c2009, Property.Skin);                             List.Add(c2009_s01);
            Character c5009     = new Character("Summer Break Charlotte",                   "c5009",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c5009);
            /// Chloe                                                                                                                                                                                                                       
            Character c1049     = new Character("Chloe",                                    "c1049",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c1049);
            Character c2049     = new Character("Maid Chloe",                               "c2049",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c2049);
            Character c2049_s01 = new Character("Maid Chloe: Energetic",                    "c2049_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, c2049, Property.Skin);                             List.Add(c2049_s01);
            /// Choux                                                                                                                                                                                                                       
            Character c1101     = new Character("Choux",                                    "c1101",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c1101);
            Character c1101_s01 = new Character("Choux: 2022 E7WC",                         "c1101_s01",  HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female, c1101, Property.Skin);                             List.Add(c1101_s01);
            /// Christy                                                                                                                                                                                                                     
            Character c3123     = new Character("Christy",                                  "c3123",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c3123);
            /// Church of Ilryos Axe                                                                                                                                                                                                        
            Character c3025     = new Character("Church of Ilryos Axe",                     "c3025",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c3025);
            Character c4025     = new Character("Chaos Sect Axe",                           "c4025",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Male,   c3025, Property.SpecialtyChange);                  List.Add(c4025);
            /// Butcher Corps Inquisitor                                                                                                                                                                                                    
            Character c3001     = new Character("Butcher Corps Inquisitor",                 "c3001",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c3001);
            Character c4001     = new Character("Chaos Inquisitor",                         "c4001",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Male,   c3001, Property.SpecialtyChange);                  List.Add(c4001);
            /// Cidd                                                                                                                                                                                                                        
            Character c1014     = new Character("Cidd",                                     "c1014",      HeroElement.Earth, HeroRarity.Stars4, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c1014);
            Character c1014_s01 = new Character("Cidd: Masked Gentleman",                   "c1014_s01",  HeroElement.Earth, HeroRarity.Stars4, HeroClass.Thief,      HeroGender.Male,   c1014, Property.Skin);                             List.Add(c1014_s01);
            Character c2014     = new Character("Assassin Cidd",                            "c2014",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c2014);
            /// Clarissa                                                                                                                                                                                                                    
            Character c1028     = new Character("Clarissa",                                 "c1028",      HeroElement.Ice,   HeroRarity.Stars4, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c1028);
            Character c2028     = new Character("Kitty Clarissa",                           "c2028",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c2028);
            /// Coli                                                                                                                                                                                                                        
            Character c1033     = new Character("Coli",                                     "c1033",      HeroElement.Ice,   HeroRarity.Stars4, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c1033);
            Character c2033     = new Character("Assassin Coli",                            "c2033",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c2033);
            /// Command Model Laika                                                                                                                                                                                                         
            Character c1099     = new Character("Command Model Laika",                      "c1099",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c1099);
            Character c2099     = new Character("Architect Laika",                          "c2099",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c2099);
            /// Corvus                                                                                                                                                                                                                      
            Character c1012     = new Character("Corvus",                                   "c1012",      HeroElement.Fire,  HeroRarity.Stars4, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c1012);
            Character c2012     = new Character("Dark Corvus",                              "c2012",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c2012);
            /// Crozet                                                                                                                                                                                                                      
            Character c1036     = new Character("Crozet",                                   "c1036",      HeroElement.Ice,   HeroRarity.Stars4, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c1036);
            Character c2036     = new Character("Troublemaker Crozet",                      "c2036",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c2036);
            /// Destina / Ruele of Light                                                                                                                                                                                                    
            Character c1022     = new Character("Ruele of Light",                           "c1022",      HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c1022);
            Character c1022_s01 = new Character("Ruele of Light: Heir of Radiance",         "c1022_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, c1022, Property.Skin);                             List.Add(c1022_s01);
            Character c2022     = new Character("Destina",                                  "c2022",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c2022);
            Character c2022_s01 = new Character("Destina: Spring Breeze",                   "c2022_s01",  HeroElement.Earth, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, c2022, Property.Skin);                             List.Add(c2022_s01);
            /// Diene                                                                                                                                                                                                                       
            Character c1076     = new Character("Diene",                                    "c1076",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c1076);
            Character c1076_s01 = new Character("Diene: Magical Girl",                      "c1076_s01",  HeroElement.Ice,   HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, c1076, Property.Skin);                             List.Add(c1076_s01);
            /// Dingo                                                                                                                                                                                                                       
            Character c1021     = new Character("Dingo",                                    "c1021",      HeroElement.Fire,  HeroRarity.Stars4, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c1021);
            Character c2021     = new Character("Blaze Dingo",                              "c2021",      HeroElement.Light, HeroRarity.Stars4, HeroClass.SoulWeaver, HeroGender.Male  );                                                   List.Add(c2021);
            /// Dom Dom                                                                                                                                                                                                                     
            Character c1037     = new Character("Dominiel",                                 "c1037",      HeroElement.Ice,   HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c1037);
            Character c2037     = new Character("Challenger Dominiel",                      "c2037",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c2037);
            Character c6037     = new Character("Moon Bunny Dominiel",                      "c6037",      HeroElement.Light, HeroRarity.Stars4, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c6037);
            /// Eaton                                                                                                                                                                                                                       
            Character c3094     = new Character("Eaton",                                    "c3094",      HeroElement.Light, HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c3094);
            /// Eda / Solitaria                                                                                                                                                                                                             
            Character c1111     = new Character("Eda",                                      "c1111",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c1111);
            Character c2111     = new Character("Solitaria of the Snow",                    "c2111",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c2111);
            /// Elena                                                                                                                                                                                                                       
            Character c1091     = new Character("Elena",                                    "c1091",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c1091);
            Character c2091     = new Character("Astromancer Elena",                        "c2091",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c2091);
            Character c1091_s01 = new Character("Elena: Starlit Melody",                    "c1091_s01",  HeroElement.Ice,   HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, c1091, Property.Skin);                             List.Add(c1091_s01);
            /// Eligos                                                                                                                                                                                                                      
            Character c1142     = new Character("Eligos",                                   "c1142",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Male  );                                                   List.Add(c1142);
            /// Elson                                                                                                                                                                                                                       
            Character c3054     = new Character("Elson",                                    "c3054",      HeroElement.Light, HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Male  );                                                   List.Add(c3054);
            /// Enott                                                                                                                                                                                                                       
            Character c3022     = new Character("Enott",                                    "c3022",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c3022);
            /// Ervalen                                                                                                                                                                                                                     
            Character c1108     = new Character("Ervalen",                                  "c1108",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c1108);
            /// Flan                                                                                                                                                                                                                        
            Character c1110     = new Character("Flan",                                     "c1110",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c1110);
            Character c2110     = new Character("Pirate Captain Flan",                      "c2110",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c2110);
            /// Furious                                                                                                                                                                                                                     
            Character c1087     = new Character("Furious",                                  "c1087",      HeroElement.Ice,   HeroRarity.Stars4, HeroClass.Ranger,     HeroGender.Male  );                                                   List.Add(c1087);
            Character c2087     = new Character("Peacemaker Furious",                       "c2087",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Ranger,     HeroGender.Male  );                                                   List.Add(c2087);
            /// Glenn                                                                                                                                                                                                                       
            Character c3103     = new Character("Glenn",                                    "c3103",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Ranger,     HeroGender.Male  );                                                   List.Add(c3103);
            Character c4103     = new Character("Vigilante Leader Glenn",                   "c4103",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Ranger,     HeroGender.Male,   c3103, Property.SpecialtyChange);                  List.Add(c4103);
            /// Gloomyrain                                                                                                                                                                                                                  
            Character c3074     = new Character("Gloomyrain",                               "c3074",      HeroElement.Light, HeroRarity.Stars3, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c3074);
            /// Godmother                                                                                                                                                                                                                   
            Character c3101     = new Character("Godmother",                                "c3101",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c3101);
            /// Ghunther                                                                                                                                                                                                                    
            Character c3024     = new Character("Gunther",                                  "c3024",      HeroElement.Light, HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c3024);
            /// Hasol                                                                                                                                                                                                                       
            Character c3135     = new Character("Hasol",                                    "c3135",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c3135);
            /// Haste                                                                                                                                                                                                                       
            Character c1039     = new Character("Haste",                                    "c1039",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c1039);
            Character c2039     = new Character("Blood Moon Haste",                         "c2039",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  );                                                   List.Add(c2039);
            /// Hataan                                                                                                                                                                                                                      
            Character c3091     = new Character("Hataan",                                   "c3091",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c3091);
            /// Hazel                                                                                                                                                                                                                       
            Character c3041     = new Character("Hazel",                                    "c3041",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c3041);
            Character c4041     = new Character("Mascot Hazel",                             "c4041",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Female, c3041, Property.SpecialtyChange);                  List.Add(c4041);
            /// Helen                                                                                                                                                                                                                       
            Character c3122     = new Character("Helen",                                    "c3122",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c3122);
            /// Helga                                                                                                                                                                                                                       
            Character c3023     = new Character("Helga",                                    "c3023",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c3023);
            Character c4023     = new Character("Mercenary Helga",                          "c4023",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Female, c3023, Property.SpecialtyChange);                  List.Add(c4023);
            /// Hurado                                                                                                                                                                                                                      
            Character c3055     = new Character("Hurado",                                   "c3055",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c3055);
            /// Hwayoung                                                                                                                                                                                                                    
            Character c1128     = new Character("Hwayoung",                                 "c1128",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c1128);
            /// Ian                                                                                                                                                                                                                         
            Character c3102     = new Character("Ian",                                      "c3102",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Ranger,     HeroGender.Male  );                                                   List.Add(c3102);
            /// Ilynav                                                                                                                                                                                                                      
            Character c1113     = new Character("Ilynav",                                   "c1113",      HeroElement.Fire,  HeroRarity.Stars4, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c1113);
            /// Iseria                                                                                                                                                                                                                      
            Character c1024     = new Character("Iseria",                                   "c1024",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c1024);
            Character c1024_s01 = new Character("Iseria: Night of White Flowers",           "c1024_s01",  HeroElement.Earth, HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female, c1024, Property.Skin);                             List.Add(c1024_s01);
            Character c2024     = new Character("Briar Witch Iseria",                       "c2024",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c2024);
            Character c5024     = new Character("Summertime Iseria",                        "c5024",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c5024);
            /// Januta                                                                                                                                                                                                                      
            Character c3131     = new Character("Januta",                                   "c3131",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c3131);
            /// Jecht                                                                                                                                                                                                                       
            Character c3053     = new Character("Jecht",                                    "c3053",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Male  );                                                   List.Add(c3053);
            /// Jena                                                                                                                                                                                                                        
            Character c3052     = new Character("Jena",                                     "c3052",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c3052);
            Character c4052     = new Character("Shepherd Jena",                            "c4052",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Mage,       HeroGender.Female, c3052, Property.SpecialtyChange);                  List.Add(c4052);
            /// Judith                                                                                                                                                                                                                      
            Character c3011     = new Character("Judith",                                   "c3011",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c3011);
            /// Juni                                                                                                                                                                                                                        
            Character c3151     = new Character("Juni",                                     "c3151",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c3151);
            /// Karin                                                                                                                                                                                                                       
            Character c1011     = new Character("Karin",                                    "c1011",      HeroElement.Ice,   HeroRarity.Stars4, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c1011);
            Character c2011     = new Character("Blood Blade Karin",                        "c2011",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c2011);
            Character c1011_s01 = new Character("Karin: Shore Patrol",                      "c1011_s01",  HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Female, c1011, Property.Skin);                             List.Add(c1011_s01);
            Character c6011     = new Character("Last Piece Karin",                         "c6011",      HeroElement.Light, HeroRarity.Stars4, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c6011);
            /// Kawerik                                                                                                                                                                                                                     
            Character c1073     = new Character("Kawerik",                                  "c1073",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c1073);
            Character c2073     = new Character("Mediator Kawerik",                         "c2073",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c2073);
            Character c2073_s01 = new Character("Mediator Kawerik: Calamity's Equilibrium", "c2073_s01",  HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Male,   c2073, Property.Skin);                             List.Add(c2073_s01);
            /// Kayron                                                                                                                                                                                                                      
            Character c1023     = new Character("Kayron",                                   "c1023",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c1023);
            Character c1023_s01 = new Character("Kayron: Time Rabbit",                      "c1023_s01",  HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male,   c1023, Property.Skin);                             List.Add(c1023_s01);
            Character c2023     = new Character("Twisted Eidolon Kayron",                   "c2023",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c2023);
            /// Ken                                                                                                                                                                                                                         
            Character c1047     = new Character("Ken",                                      "c1047",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c1047);
            Character c2047     = new Character("Martial Artist Ken",                       "c2047",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c2047);
            /// Khawana                                                                                                                                                                                                                     
            Character c1086     = new Character("Khawana",                                  "c1086",      HeroElement.Fire,  HeroRarity.Stars4, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c1086);
            Character c2086     = new Character("Great Chief Khawana",                      "c2086",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c2086);
            /// Khawazu                                                                                                                                                                                                                     
            Character c1085     = new Character("Khawazu",                                  "c1085",      HeroElement.Fire,  HeroRarity.Stars4, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c1085);
            Character c2085     = new Character("Inferno Khawazu",                          "c2085",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c2085);
            /// Kikirat v2                                                                                                                                                                                                                  
            Character c3084     = new Character("Kikirat v2",                               "c3084",      HeroElement.Light, HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c3084);
            /// Kiris                                                                                                                                                                                                                       
            Character c3063     = new Character("Kiris",                                    "c3063",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c3063);
            /// Kise / Judge Kise                                                                                                                                                                                                           
            Character c1006     = new Character("Kise",                                     "c1006",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c1006);
            Character c2006     = new Character("Judge Kise",                               "c2006",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c2006);
            Character c2006_s01 = new Character("Judge Kise: Heir of Holy Light",           "c2006_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female, c2006, Property.Skin);                             List.Add(c2006_s01);
            /// Kluri                                                                                                                                                                                                                       
            Character c3003     = new Character("Kluri",                                    "c3003",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c3003);
            Character c4003     = new Character("Falconer Kluri",                           "c4003",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Female, c3003, Property.SpecialtyChange);                  List.Add(c4003);
            /// Krau                                                                                                                                                                                                                        
            Character c1070     = new Character("Krau",                                     "c1070",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c1070);
            Character c2070     = new Character("Last Rider Krau",                          "c2070",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c2070);
            /// Landy                                                                                                                                                                                                                       
            Character c1109     = new Character("Landy",                                    "c1109",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c1109);
            /// Lena                                                                                                                                                                                                                        
            Character c3092     = new Character("Lena",                                     "c3092",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c3092);
            /// Leo                                                                                                                                                                                                                         
            Character c1029     = new Character("Leo",                                      "c1029",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Male  );                                                   List.Add(c1029);
            Character c2029     = new Character("Roaming Warrior Leo",                      "c2029",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Ranger,     HeroGender.Male  );                                                   List.Add(c2029);
            /// Lidica                                                                                                                                                                                                                      
            Character c1046     = new Character("Lidica",                                   "c1046",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c1046);
            Character c1046_s01 = new Character("Lidica: Bride of Roses",                   "c1046_s01",  HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female, c1046, Property.Skin);                             List.Add(c1046_s01);
            Character c2046     = new Character("Faithless Lidica",                         "c2046",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c2046);
            Character c2046_s01 = new Character("Faithless Lidica: Victorious Knight",      "c2046_s01",  HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female, c2046, Property.Skin);                             List.Add(c2046_s01);
            /// Lilias                                                                                                                                                                                                                      
            Character c1089     = new Character("Lilias",                                   "c1089",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c1089);
            Character c2089     = new Character("Conqueror Lilias",                         "c2089",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c2089);
            /// Lilibet                                                                                                                                                                                                                     
            Character c1095     = new Character("Lilibet",                                  "c1095",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c1095);
            Character c2095     = new Character("Designer Lilibet",                         "c2095",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c2095);
            /// Lilka                                                                                                                                                                                                                       
            Character c3153     = new Character("Lilka",                                    "c3153",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c3153);
            /// Lorina                                                                                                                                                                                                                      
            Character c3035     = new Character("Lorina",                                   "c3035",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c3035);
            Character c4035     = new Character("Commander Lorina",                         "c4035",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Female, c3035, Property.SpecialtyChange);                  List.Add(c4035);
            /// Lots                                                                                                                                                                                                                        
            Character c1031     = new Character("Lots",                                     "c1031",      HeroElement.Earth, HeroRarity.Stars4, HeroClass.SoulWeaver, HeroGender.Male  );                                                   List.Add(c1031);
            Character c2031     = new Character("Auxiliary Lots",                           "c2031",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c2031);
            /// Lua                                                                                                                                                                                                                         
            Character c1126     = new Character("Lua",                                      "c1126",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c1126);
            /// Lucy                                                                                                                                                                                                                        
            Character c3113     = new Character("Lucy",                                     "c3113",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c3113);
            /// Ludwig                                                                                                                                                                                                                      
            Character c1069     = new Character("Ludwig",                                   "c1069",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c1069);
            /// Luluca                                                                                                                                                                                                                      
            Character c1082     = new Character("Luluca",                                   "c1082",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c1082);
            Character c1082_s01 = new Character("Luluca: Lovely Patissiere",                "c1082_s01",  HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female, c1082, Property.Skin);                             List.Add(c1082_s01);
            Character c2082     = new Character("Top Model Luluca",                         "c2082",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c2082);
            /// Luna                                                                                                                                                                                                                        
            Character c1066     = new Character("Luna",                                     "c1066",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c1066);
            /// Doris                                                                                                                                                                                                                       
            Character c3044     = new Character("Doris",                                    "c3044",      HeroElement.Light, HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c3044);
            Character c4044     = new Character("Magic Scholar Doris",                      "c4044",      HeroElement.Light, HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Female, c3044, Property.SpecialtyChange);                  List.Add(c4044);
            /// Maya                                                                                                                                                                                                                        
            Character c1032     = new Character("Maya",                                     "c1032",      HeroElement.Fire,  HeroRarity.Stars4, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c1032);
            Character c2032     = new Character("Fighter Maya",                             "c2032",      HeroElement.Light, HeroRarity.Stars4, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c2032);
            /// Melany                                                                                                                                                                                                                      
            Character c3121     = new Character("Melany",                                   "c3121",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c3121);
            /// Melissa                                                                                                                                                                                                                     
            Character c1096     = new Character("Melissa",                                  "c1096",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c1096);
            /// Mercedes                                                                                                                                                                                                                    
            Character c0002     = new Character("Mercedes",                                 "c0002",      HeroElement.Fire,  HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c0002);
            Character c1005     = new Character("Mercedes",                                 "c1005",      HeroElement.Fire,  HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Female, c0002, Property.Disabled);                         List.Add(c1005);
            Character c1005_s01 = new Character("Mercedes: Fluffy Lady",                    "c1005_s01",  HeroElement.Fire,  HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Female, c0002, Property.Skin);                             List.Add(c1005_s01);
            Character c2005     = new Character("Celestial Mercedes",                       "c2005",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c2005);
            Character c5004     = new Character("Archdemon's Shadow",                       "c5004",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c5004);
            /// Mirsa                                                                                                                                                                                                                       
            Character c3014     = new Character("Mirsa",                                    "c3014",      HeroElement.Light, HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c3014);
            /// Mistychain                                                                                                                                                                                                                  
            Character c3072     = new Character("Mistychain",                               "c3072",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c3072);
            /// Montmorancy                                                                                                                                                                                                                 
            Character c3042     = new Character("Montmorancy",                              "c3042",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c3042);
            Character c4042     = new Character("Angelic Montmorancy",                      "c4042",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Female, c3042, Property.SpecialtyChange);                  List.Add(c4042);
            Character c4042_s01 = new Character("Angelic Montmorancy: Serene Sea",          "c4042_s01",  HeroElement.Ice,   HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Female, c4042, Property.Skin, Property.SpecialtyChange);   List.Add(c4042_s01);
            /// Mort                                                                                                                                                                                                                
            Character c1104     = new Character("Mort",                                     "c1104",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c1104);
            /// Mucacha                                                                                                                                                                                                                     
            Character c3033     = new Character("Mucacha",                                  "c3033",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c3033);
            /// Mui                                                                                                                                                                                                                         
            Character c1044     = new Character("Mui",                                      "c1044",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c1044);
            /// Muwi                                                                                                                                                                                                                        
            Character c3132     = new Character("Muwi",                                     "c3132",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c3132);
            /// Nemunas                                                                                                                                                                                                                     
            Character c3061     = new Character("Nemunas",                                  "c3061",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c3061);
            /// Orte                                                                                                                                                                                                                        
            Character c3133     = new Character("Orte",                                     "c3133",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c3133);
            /// Otillie                                                                                                                                                                                                                     
            Character c3045     = new Character("Otillie",                                  "c3045",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c3045);
            /// Pavel                                                                                                                                                                                                                       
            Character c1080     = new Character("Pavel",                                    "c1080",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Male  );                                                   List.Add(c1080);
            Character c2080     = new Character("Commander Pavel",                          "c2080",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Male  );                                                   List.Add(c2080);
            /// Pearlhorizon                                                                                                                                                                                                                
            Character c3073     = new Character("Pearlhorizon",                             "c3073",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c3073);
            Character c4073     = new Character("Doll Maker Pearlhorizon",                  "c4073",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Mage,       HeroGender.Female, c3073, Property.SpecialtyChange);                  List.Add(c4073);
            /// Peira                                                                                                                                                                                                                       
            Character c1125     = new Character("Peira",                                    "c1125",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c1125);
            /// Penelope                                                                                                                                                                                                                    
            Character c3125     = new Character("Penelope",                                 "c3125",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c3125);
            /// Politis                                                                                                                                                                                                                     
            Character c1112     = new Character("Politis",                                  "c1112",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c1112);
            /// Purrgis                                                                                                                                                                                                                     
            Character c1035     = new Character("Purrgis",                                  "c1035",      HeroElement.Earth, HeroRarity.Stars4, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c1035);
            Character c2035     = new Character("General Purrgis",                          "c2035",      HeroElement.Light, HeroRarity.Stars4, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c2035);
            /// Pyllis                                                                                                                                                                                                                      
            Character c3005     = new Character("Pyllis",                                   "c3005",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c3005);
            Character c4005     = new Character("Shadow Knight Pyllis",                     "c4005",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Female, c3005, Property.SpecialtyChange);                  List.Add(c4005);
            /// Ran                                                                                                                                                                                                                         
            Character c1118     = new Character("Ran",                                      "c1118",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c1118);
            Character c1118_s01 = new Character("Ran: Pure White Heart",                    "c1118_s01",  HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male,   c1118, Property.Skin);                             List.Add(c1118_s01);
            /// Ras                                                                                                                                                                                                                         
            Character c1001     = new Character("Ras",                                      "c1001",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c1001);
            Character c1078     = new Character("Vagabond Ras",                             "c1078",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c1078);
            Character c5001     = new Character("Adventurer Ras",                           "c5001",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Male,   c1001, Property.SpecialtyChange);                  List.Add(c5001);
            /// Ravi                                                                                                                                                                                                                        
            Character c1019     = new Character("Ravi",                                     "c1019",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c1019);
            Character c2019     = new Character("Apocalypse Ravi",                          "c2019",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c2019);
            Character c2019_s01 = new Character("Apocalypse Ravi: Avatar of Bloodlust",     "c2019_s01",  HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female, c2019, Property.Skin);                             List.Add(c2019_s01);
            /// Ray                                                                                                                                                                                                                         
            Character c1090     = new Character("Ray",                                      "c1090",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  );                                                   List.Add(c1090);
            Character c2090     = new Character("Death Dealer Ray",                         "c2090",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Male  );                                                   List.Add(c2090);
            /// Requiemroar                                                                                                                                                                                                                 
            Character c3075     = new Character("Requiemroar",                              "c3075",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c3075);
            /// Rikoris                                                                                                                                                                                                                     
            Character c3034     = new Character("Rikoris",                                  "c3034",      HeroElement.Light, HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c3034);
            Character c4034     = new Character("Captain Rikoris",                          "c4034",      HeroElement.Light, HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Male,   c3034, Property.SpecialtyChange);                  List.Add(c4034);
            /// Rima                                                                                                                                                                                                                        
            Character c3062     = new Character("Rima",                                     "c3062",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c3062);
            Character c4062     = new Character("Muse Rima",                                "c4062",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Ranger,     HeroGender.Female, c3062, Property.SpecialtyChange);                  List.Add(c4062);
            /// Rin                                                                                                                                                                                                                         
            Character c1054     = new Character("Rin",                                      "c1054",      HeroElement.Earth, HeroRarity.Stars4, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c1054);
            Character c2054     = new Character("Crescent Moon Rin",                        "c2054",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c2054);
            /// Roana                                                                                                                                                                                                                       
            Character c1102     = new Character("Roana",                                    "c1102",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c1102);
            Character c2102     = new Character("Requiem Roana",                            "c2102",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c2102);
            /// Romann                                                                                                                                                                                                                      
            Character c1043     = new Character("Romann",                                   "c1043",      HeroElement.Ice,   HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c1043);
            Character c2043     = new Character("Benevolent Romann",                        "c2043",      HeroElement.Light, HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c2043);
            /// Roozid                                                                                                                                                                                                                      
            Character c3013     = new Character("Roozid",                                   "c3013",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c3013);
            Character c4013     = new Character("Righteous Thief Roozid",                   "c4013",      HeroElement.Earth, HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Male,   c3013, Property.SpecialtyChange);                  List.Add(c4013);
            /// Rose                                                                                                                                                                                                                        
            Character c1003     = new Character("Rose",                                     "c1003",      HeroElement.Ice,   HeroRarity.Stars4, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c1003);
            Character c1003_s01 = new Character("Rose: Dark Angel",                         "c1003_s01",  HeroElement.Ice,   HeroRarity.Stars4, HeroClass.Knight,     HeroGender.Female, c1003, Property.Skin);                             List.Add(c1003_s01);
            Character c2003     = new Character("Shadow Rose",                              "c2003",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c2003);
            /// Schuri                                                                                                                                                                                                                      
            Character c1020     = new Character("Schuri",                                   "c1020",      HeroElement.Fire,  HeroRarity.Stars4, HeroClass.Ranger,     HeroGender.Male  );                                                   List.Add(c1020);
            Character c2020     = new Character("Watcher Schuri",                           "c2020",      HeroElement.Light, HeroRarity.Stars4, HeroClass.Ranger,     HeroGender.Male  );                                                   List.Add(c2020);
            /// Senya                                                                                                                                                                                                                       
            Character c1106     = new Character("Senya",                                    "c1106",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c1106);
            /// Serila                                                                                                                                                                                                                      
            Character c1040     = new Character("Serila",                                   "c1040",      HeroElement.Fire,  HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c1040);
            /// Sez                                                                                                                                                                                                                         
            Character c1038     = new Character("Sez",                                      "c1038",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c1038);
            Character c1038_s01 = new Character("Sez: Aloof Lifeguard",                     "c1038_s01",  HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male,   c1038, Property.Skin);                             List.Add(c1038_s01);
            Character c2038     = new Character("Specimen Sez",                             "c2038",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c2038);
            /// Sharun                                                                                                                                                                                                                      
            Character c1132     = new Character("Sharun",                                   "c1132",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c1132);
            /// Sigret                                                                                                                                                                                                                      
            Character c1072     = new Character("Sigret",                                   "c1072",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c1072);
            Character c2072     = new Character("Operator Sigret",                          "c2072",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c2072);
            /// Silk                                                                                                                                                                                                                        
            Character c1004 =    new Character("Silk",                                      "c1004",      HeroElement.Earth, HeroRarity.Stars4, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c1004);
            Character c2004 =    new Character("Wanderer Silk",                             "c2004",      HeroElement.Light, HeroRarity.Stars4, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c2004);
            /// Sonia                                                                                                                                                                                                                       
            Character c3104     = new Character("Sonia",                                    "c3104",      HeroElement.Light, HeroRarity.Stars3, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c3104);
            /// Straze                                                                                                                                                                                                                      
            Character c1034     = new Character("Straze",                                   "c1034",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c1034);
            /// Surin                                                                                                                                                                                                                       
            Character c1065     = new Character("Surin",                                    "c1065",      HeroElement.Fire,  HeroRarity.Stars4, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c1065);
            Character c2065     = new Character("Tempest Surin",                            "c2065",      HeroElement.Light, HeroRarity.Stars4, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c2065);
            Character c2065_s01 = new Character("Tempest Surin: Autuman Beauty",            "c2065_s01",  HeroElement.Light, HeroRarity.Stars4, HeroClass.Thief,      HeroGender.Female, c2065, Property.Skin);                             List.Add(c2065_s01);
            /// Suthan                                                                                                                                                                                                                      
            Character c3155     = new Character("Suthan",                                   "c3155",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c3155);
            /// Sven                                                                                                                                                                                                                        
            Character c3015     = new Character("Sven",                                     "c3015",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c3015);
            /// Taeyou                                                                                                                                                                                                                      
            Character c1127     = new Character("Taeyou",                                   "c1127",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c1127);
            /// Talaz                                                                                                                                                                                                                       
            Character c3152     = new Character("Talaz",                                    "c3152",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c3152);
            /// Talia                                                                                                                                                                                                                       
            Character c3154     = new Character("Talia",                                    "c3154",      HeroElement.Light, HeroRarity.Stars3, HeroClass.Thief,      HeroGender.Female);                                                   List.Add(c3154);
            /// Tamarinne                                                                                                                                                                                                                   
            Character c1067     = new Character("Tamarinne",                                "c1067",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female);                                                   List.Add(c1067);
            Character c1067_s01 = new Character("Tamarinne: Starlit Concert",               "c1067_s01",  HeroElement.Fire,  HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, c1067, Property.Skin);                             List.Add(c1067_s01);
            /// Taranor Guard                                                                                                                                                                                                               
            Character c3032     = new Character("Taranor Guard",                            "c3032",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c3032);
            /// Taranor Royal Guard                                                                                                                                                                                                         
            Character c3002     = new Character("Taranor Royal Guard",                      "c3002",      HeroElement.Ice,   HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c3002);
            /// Tenebria                                                                                                                                                                                                                    
            Character c1050     = new Character("Tenebria",                                 "c1050",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c1050);
            Character c1050_s01 = new Character("Tenebria: Phantom Schoolgirl",             "c1050_s01",  HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female, c1050, Property.Skin);                             List.Add(c1050_s01);
            Character c2050     = new Character("Specter Tenebria",                         "c2050",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c2050);
            Character c2050_s01 = new Character("Specter Tenebria: Dark Tyrant",            "c2050_s01",  HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female, c2050, Property.Skin);                             List.Add(c2050_s01);
            Character c5050     = new Character("Fairytale Tenebria",                       "c5050",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c5050);
            /// Tieria                                                                                                                                                                                                                      
            Character c3021     = new Character("Tieria",                                   "c3021",      HeroElement.Fire,  HeroRarity.Stars3, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c3021);
            Character c3026     = new Character("Free Spirit Tieria",                       "c3026",      HeroElement.Light, HeroRarity.Stars4, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c3026);
            Character c3026_s01 = new Character("Free Spirit Tieria",                       "c3026_s01",  HeroElement.Light, HeroRarity.Stars4, HeroClass.Warrior,    HeroGender.Female, c3026, Property.Skin, Property.Disabled);          List.Add(c3026);
            /// Tywin                                                                                                                                                                                                                       
            Character c1042     = new Character("Tywin",                                    "c1042",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c1042);
            Character c2042     = new Character("Ambitious Tywin",                          "c2042",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Male  );                                                   List.Add(c2042);
            /// Vildred                                                                                                                                                                                                                     
            Character c1007     = new Character("Vildred",                                  "c1007",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c1007);
            Character c1007_s01 = new Character("Vildred: Distinguished Gentleman",         "c1007_s01",  HeroElement.Earth, HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male,   c1007, Property.Skin);                             List.Add(c1007_s01);
            Character c1007t    = new Character("Vildred",                                  "c1007t",     HeroElement.Earth, HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male  , c1007, Property.Disabled);                         List.Add(c1007);
            Character c2007     = new Character("Arbiter Vildred",                          "c2007",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c2007);
            Character c2007_s01 = new Character("Arbiter Vildred: Dark Monarch",            "c2007_s01",  HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male,   c2007, Property.Skin);                             List.Add(c2007_s01);
            /// Violet                                                                                                                                                                                                                      
            Character c1074     = new Character("Violet",                                   "c1074",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c1074);
            Character c1074_s01 = new Character("Violet: Ardent Gentleman",                 "c1074_s01",  HeroElement.Earth, HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male,   c1074, Property.Skin);                             List.Add(c1074_s01);
            Character c2074     = new Character("Remnant Violet",                           "c2074",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Male  );                                                   List.Add(c2074);
            /// Vivian                                                                                                                                                                                                                      
            Character c1088     = new Character("Vivian",                                   "c1088",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c1088);
            Character c1088_s01 = new Character("Vivian: Villainess",                       "c1088_s01",  HeroElement.Earth, HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female, c1088, Property.Skin);                             List.Add(c1088_s01);
            Character c2088     = new Character("Sylvan Sage Vivian",                       "c2088",      HeroElement.Light, HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female);                                                   List.Add(c2088);
            /// Wanda                                                                                                                                                                                                                       
            Character c3065     = new Character("Wanda",                                    "c3065",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c3065);
            Character c4065     = new Character("All-Rounder Wanda",                        "c4065",      HeroElement.Dark,  HeroRarity.Stars3, HeroClass.Ranger,     HeroGender.Female, c3065, Property.SpecialtyChange);                  List.Add(c4065);
            /// Yoonryoung                                                                                                                                                                                                                  
            Character c3134     = new Character("Yoonryoung",                               "c3134",      HeroElement.Light, HeroRarity.Stars3, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c3134);
            /// Yufine                                                                                                                                                                                                                      
            Character c1016     = new Character("Yufine",                                   "c1016",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c1016);
            Character c1016_s01 = new Character("Yufine: Adorable Flower Bud",              "c1016_s01",  HeroElement.Earth, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female, c1016, Property.Skin);                             List.Add(c1016_s01);
            Character c5016     = new Character("Holiday Yufine",                           "c5016",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female);                                                   List.Add(c5016);
            /// Yulha                                                                                                                                                                                                                       
            Character c1131     = new Character("Yulha",                                    "c1131",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Female);                                                   List.Add(c1131);
            /// Yuna                                                                                                                                                                                                                        
            Character c1030     = new Character("Yuna",                                     "c1030",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female);                                                   List.Add(c1030);
            Character c1030_s01 = new Character("Yuna: Afterschool Party!",                 "c1030_s01",  HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female, c1030, Property.Skin);                             List.Add(c1030_s01);
            /// Zahhak                                                                                                                                                                                                                      
            Character c1119     = new Character("Zahhak",                                   "c1119",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Male  );                                                   List.Add(c1119);
            /// Zeno                                                                                                                                                                                                                        
            Character c1083     = new Character("Zeno",                                     "c1083",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c1083);
            /// Zerato                                                                                                                                                                                                                      
            Character c1010     = new Character("Zerato",                                   "c1010",      HeroElement.Ice,   HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c1010);
            Character c2010     = new Character("Champion Zerato",                          "c2010",      HeroElement.Dark,  HeroRarity.Stars4, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c2010);
            /// Zio                                                                                                                                                                                                                         
            Character c1133     = new Character("Zio",                                      "c1133",      HeroElement.Dark,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Male  );                                                   List.Add(c1133);

            /// COLLAB UNITS
            Character c1138     = new Character("ae-GISELLE",                               "c1138",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female, Property.Collab);                                  List.Add(c1138);
            Character c1137     = new Character("ae-KARINA",                                "c1137",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Knight,     HeroGender.Female, Property.Collab);                                  List.Add(c1137);
            Character c1140     = new Character("ae-NINGNING",                              "c1140",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Collab);                                  List.Add(c1140);
            Character c1139     = new Character("ae-WINTER",                                "c1139",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Female, Property.Collab);                                  List.Add(c1139);
            Character c1093     = new Character("Baiken",                                   "c1093",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Thief,      HeroGender.Female, Property.Collab);                                  List.Add(c1093);
            Character c1146     = new Character("Benimaru",                                 "c1146",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Male,   Property.Collab);                                  List.Add(c1146);
            Character c1094     = new Character("Dizzy",                                    "c1094",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female, Property.Collab);                                  List.Add(c1094);
            Character c1134     = new Character("Edward Elric",                             "c1134",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Male,   Property.Collab);                                  List.Add(c1134);
            Character c1105     = new Character("Elphelt",                                  "c1105",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female, Property.Collab);                                  List.Add(c1105);
            Character c1116     = new Character("Emilia",                                   "c1116",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Collab);                                  List.Add(c1116);
            Character c1130     = new Character("Jack O’",                                  "c1130",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female, Property.Collab);                                  List.Add(c1130);
            Character c1107     = new Character("Kizuna AI",                                "c1107",      HeroElement.Fire,  HeroRarity.Stars4, HeroClass.SoulWeaver, HeroGender.Female, Property.Collab);                                  List.Add(c1107);
            Character c1122     = new Character("Milim",                                    "c1122",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female, Property.Collab);                                  List.Add(c1122);
            Character c1115     = new Character("Ram",                                      "c1115",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Female, Property.Collab);                                  List.Add(c1115);
            Character c1114     = new Character("Rem",                                      "c1114",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Female, Property.Collab);                                  List.Add(c1114);
            Character c1121     = new Character("Rimuru",                                   "c1121",      HeroElement.Earth, HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Male,   Property.Collab);                                  List.Add(c1121);
            Character c1136     = new Character("Riza Hawkeye",                             "c1136",      HeroElement.Ice,   HeroRarity.Stars5, HeroClass.Ranger,     HeroGender.Female, Property.Collab);                                  List.Add(c1136);
            Character c1135     = new Character("Roy Mustang",                              "c1135",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Mage,       HeroGender.Male,   Property.Collab);                                  List.Add(c1135);
            Character c1123     = new Character("Shuna",                                    "c1123",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.SoulWeaver, HeroGender.Female, Property.Collab);                                  List.Add(c1123);
            Character c1092     = new Character("Sol",                                      "c1092",      HeroElement.Fire,  HeroRarity.Stars5, HeroClass.Warrior,    HeroGender.Male,   Property.Collab);                                  List.Add(c1092);

            List.Sort((c1, c2) => string.Compare(c1.Name, c2.Name, StringComparison.Ordinal));
            List.RemoveAll(c => c.Properties.Contains(Property.Disabled));
        }

        /// <summary>
        /// Apply existing filters on list
        /// </summary>
        /// <param name="filterType">Type of filter to apply</param>
        public void FilterList(Enum filterType)
        {
            if (filterType.GetType() != typeof(FilterType.ByElement) && filterType.GetType() != typeof(FilterType.ByClass) && filterType.GetType() != typeof(FilterType.ByRarity) && filterType.GetType() != typeof(FilterType.ByGender) && filterType.GetType() != typeof(FilterType.ByProperty))
                return;
            
            int i = 0;
            switch (filterType)
            {
                case FilterType.ByElement.OnlyFire:
                    while (i < List.Count)
                    {
                        if (List[i].HeroElement != HeroElement.Fire )
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByElement.OnlyEarth:
                    while (i < List.Count)
                    {
                        if (List[i].HeroElement != HeroElement.Earth)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByElement.OnlyIce:
                    while (i < List.Count)
                    {
                        if (List[i].HeroElement != HeroElement.Ice  )
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByElement.OnlyLight:
                    while (i < List.Count)
                    {
                        if (List[i].HeroElement != HeroElement.Light)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByElement.OnlyDark:
                    while (i < List.Count)
                    {
                        if (List[i].HeroElement != HeroElement.Dark )
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;

                case FilterType.ByElement.RemoveAllFire:
                    while (i < List.Count)
                    {
                        if (List[i].HeroElement == HeroElement.Fire )
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByElement.RemoveAllEarth:
                    while (i < List.Count)
                    {
                        if (List[i].HeroElement == HeroElement.Earth)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByElement.RemoveAllIce:
                    while (i < List.Count)
                    {
                        if (List[i].HeroElement == HeroElement.Ice  )
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByElement.RemoveAllLight:
                    while (i < List.Count)
                    {
                        if (List[i].HeroElement == HeroElement.Light)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByElement.RemoveAllDark:
                    while (i < List.Count)
                    {
                        if (List[i].HeroElement == HeroElement.Dark )
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;


                case FilterType.ByClass.OnlyDummyClass:
                    while (i < List.Count)
                    {
                        if (List[i].HeroClass != HeroClass.DummyClass)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByClass.OnlyWarrior:
                    while (i < List.Count)
                    {
                        if (List[i].HeroClass != HeroClass.Warrior)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByClass.OnlyKnight:
                    while (i < List.Count)
                    {
                        if (List[i].HeroClass != HeroClass.Knight)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByClass.OnlyThief:
                    while (i < List.Count)
                    {
                        if (List[i].HeroClass != HeroClass.Thief)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByClass.OnlyMage:
                    while (i < List.Count)
                    {
                        if (List[i].HeroClass != HeroClass.Mage)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByClass.OnlyRanger:
                    while (i < List.Count)
                    {
                        if (List[i].HeroClass != HeroClass.Ranger)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByClass.OnlySoulWeaver:
                    while (i < List.Count)
                    {
                        if (List[i].HeroClass != HeroClass.SoulWeaver)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;

                case FilterType.ByClass.RemoveAllDummyClass:
                    while (i < List.Count)
                    {
                        if (List[i].HeroClass == HeroClass.DummyClass)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByClass.RemoveAllWarrior:
                    while (i < List.Count)
                    {
                        if (List[i].HeroClass == HeroClass.Warrior)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByClass.RemoveAllKnight:
                    while (i < List.Count)
                    {
                        if (List[i].HeroClass == HeroClass.Knight)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByClass.RemoveAllThief:
                    while (i < List.Count)
                    {
                        if (List[i].HeroClass == HeroClass.Thief)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByClass.RemoveAllMage:
                    while (i < List.Count)
                    {
                        if (List[i].HeroClass == HeroClass.Mage)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByClass.RemoveAllRanger:
                    while (i < List.Count)
                    {
                        if (List[i].HeroClass == HeroClass.Ranger)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByClass.RemoveAllSoulWeaver:
                    while (i < List.Count)
                    {
                        if (List[i].HeroClass == HeroClass.SoulWeaver)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;


                case FilterType.ByRarity.OnlyStars3:
                    while (i < List.Count)
                    {
                        if (List[i].HeroRarity != HeroRarity.Stars3)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByRarity.OnlyStars4:
                    while (i < List.Count)
                    {
                        if (List[i].HeroRarity != HeroRarity.Stars4)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByRarity.OnlyStars5:
                    while (i < List.Count)
                    {
                        if (List[i].HeroRarity != HeroRarity.Stars5)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;

                case FilterType.ByRarity.RemoveAllStars3:
                    while (i < List.Count)
                    {
                        if (List[i].HeroRarity == HeroRarity.Stars3)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByRarity.RemoveAllStars4:
                    while (i < List.Count)
                    {
                        if (List[i].HeroRarity == HeroRarity.Stars4)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByRarity.RemoveAllStars5:
                    while (i < List.Count)
                    {
                        if (List[i].HeroRarity == HeroRarity.Stars5)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;


                case FilterType.ByGender.OnlyMales:
                    while (i < List.Count)
                    {
                        if (List[i].HeroGender != HeroGender.Male)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByGender.OnlyFemales:
                    while (i < List.Count)
                    {
                        if (List[i].HeroGender != HeroGender.Female)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;

                case FilterType.ByGender.RemoveAllMales:
                    while (i < List.Count)
                    {
                        if (List[i].HeroGender == HeroGender.Male)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByGender.RemoveAllFemales:
                    while (i < List.Count)
                    {
                        if (List[i].HeroGender == HeroGender.Female)
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;


                case FilterType.ByProperty.OnlyClothesChange:
                    while (i < List.Count)
                    {
                        if (!List[i].Properties.Contains(Property.ClothesChange))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByProperty.OnlySpecialtyChange:
                    while (i < List.Count)
                    {
                        if (!List[i].Properties.Contains(Property.SpecialtyChange))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByProperty.OnlyCollab:
                    while (i < List.Count)
                    {
                        if (!List[i].Properties.Contains(Property.Collab))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByProperty.OnlySkin:
                    while (i < List.Count)
                    {
                        if (!List[i].Properties.Contains(Property.Skin))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;

                case FilterType.ByProperty.RemoveAllClothesChange:
                    while (i < List.Count)
                    {
                        if (List[i].Properties.Contains(Property.ClothesChange))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByProperty.RemoveAllSpecialtyChange:
                    while (i < List.Count)
                    {
                        if (List[i].Properties.Contains(Property.SpecialtyChange))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByProperty.RemoveAllCollab:
                    while (i < List.Count)
                    {
                        if (List[i].Properties.Contains(Property.Collab))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
                case FilterType.ByProperty.RemoveAllSkin:
                    while (i < List.Count)
                    {
                        if (List[i].Properties.Contains(Property.Skin))
                            List.RemoveAt(i);
                        else
                            i++;
                    }
                    break;
            }
        }

        public Character GetCharacterByName(string name)
        {
            Character character = null;
            foreach (Character c in List)
            {
                if (c.Name == name)
                    character = c;
            }
            return character;
        }
    }

    internal class ChromeManager
    { 
        /// <summary>
        /// Check if the folder contains the images for the characters in the proper format<br></br>
        /// If not, open Chrome tabs for each missing character
        /// </summary>
        public static void OpenMissingImagesWeb(List<Character> List)
        {
            string url = "https://www.e7vau.lt/portrait-viewer.html?id=";
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "Portraits";
            if (!Directory.Exists(appPath)) Directory.CreateDirectory(appPath);

            foreach (Character c in List)
            {
                if (!File.Exists(appPath + Path.DirectorySeparatorChar + c.CID + ".png"))
                {
                    OpenNewTab(url + c.CID);
                }
            }
        }

        /// <summary>
        /// Open a new Chrome tab with the provvided url
        /// </summary>
        /// <param name="url">URL to open</param>
        /// <param name="retry">Always true, if false Chrome won't launch if not open</param>
        public static void OpenNewTab(string url, bool retry = true)
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

        /// <summary>
        /// Kill Chrome
        /// </summary>
        public static void CloseChrome()
        {
            Process[] chromeProcesses = Process.GetProcessesByName("chrome");
            if (chromeProcesses.Length > 0)
            {
                foreach (Process chromeProcess in chromeProcesses)
                {
                    chromeProcess.Kill();
                }
            }
        }
    }
}
