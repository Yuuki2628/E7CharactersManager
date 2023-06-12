using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace E7CharactersManager
{
    public partial class E7CharactersList : Form
    {
        private CharactersList cl { get; set; }
        private bool Initializing { get; set; } = true;

        public E7CharactersList()
        {
            InitializeComponent();
            for (int i = 0; i < checkListElements.Items.Count; i++) checkListElements.SetItemChecked(i, true);
            for (int i = 0; i < checkListClass.Items.Count; i++) checkListClass.SetItemChecked(i, true);
            for (int i = 0; i < checkListGender.Items.Count; i++) checkListGender.SetItemChecked(i, true);
            for (int i = 0; i < checkListProperties.Items.Count; i++) checkListProperties.SetItemChecked(i, true);

            Initializing = false;
        }

        private void LoadFilteredList()
        {
            if (Initializing) return;
            cl = new CharactersList();
            List<HeroElement> elList = new List<HeroElement>();
            List<HeroClass> clList = new List<HeroClass>();
            List<HeroGender> gdList = new List<HeroGender>();
            List<Property> ppList = new List<Property>();
            foreach (string check in checkListElements.CheckedItems)
            {
                switch (check)
                {
                    case "Fire":
                        elList.Add(HeroElement.Fire);
                        break;
                    case "Earth":
                        elList.Add(HeroElement.Earth);
                        break;
                    case "Ice":
                        elList.Add(HeroElement.Ice);
                        break;
                    case "Light":
                        elList.Add(HeroElement.Light);
                        break;
                    case "Dark":
                        elList.Add(HeroElement.Dark);
                        break;
                    }
            }
            foreach (string check in checkListClass.CheckedItems)
            {
                switch (check)
                {
                    case "Warrior":
                        clList.Add(HeroClass.Warrior);
                        break;
                    case "Knight":
                        clList.Add(HeroClass.Knight);
                        break;
                    case "Thief":
                        clList.Add(HeroClass.Thief);
                        break;
                    case "Mage":
                        clList.Add(HeroClass.Mage);
                        break;
                    case "Ranger":
                        clList.Add(HeroClass.Ranger);
                        break;
                    case "SoulWeaver":
                        clList.Add(HeroClass.SoulWeaver);
                        break;
                }
            }
            foreach (string check in checkListGender.CheckedItems)
            {
                switch (check)
                {
                    case "Female":
                        gdList.Add(HeroGender.Female);
                        break;
                    case "Male":
                        gdList.Add(HeroGender.Male);
                        break;
                }
            }
            foreach (string check in checkListProperties.CheckedItems)
            {
                switch (check)
                {
                    case "ClothesChange":
                        ppList.Add(Property.ClothesChange);
                        break;
                    case "Collab":
                        ppList.Add(Property.Collab);
                        break;
                    case "Skin":
                        ppList.Add(Property.Skin);
                        break;
                    case "SpecialtyChange":
                        ppList.Add(Property.SpecialtyChange);
                        break;
                }
            }

            if (!elList.Contains(HeroElement.Fire))          cl.FilterList(FilterType.RemoveAllFire);
            if (!elList.Contains(HeroElement.Earth))         cl.FilterList(FilterType.RemoveAllEarth);
            if (!elList.Contains(HeroElement.Ice))           cl.FilterList(FilterType.RemoveAllIce);
            if (!elList.Contains(HeroElement.Light))         cl.FilterList(FilterType.RemoveAllLight);
            if (!elList.Contains(HeroElement.Dark))          cl.FilterList(FilterType.RemoveAllDark);
                                                             
            if (!clList.Contains(HeroClass.DummyClass))      cl.FilterList(FilterType.RemoveAllDummyClass);
            if (!clList.Contains(HeroClass.Warrior))         cl.FilterList(FilterType.RemoveAllWarrior);
            if (!clList.Contains(HeroClass.Knight))          cl.FilterList(FilterType.RemoveAllKnight);
            if (!clList.Contains(HeroClass.Thief))           cl.FilterList(FilterType.RemoveAllThief);
            if (!clList.Contains(HeroClass.Mage))            cl.FilterList(FilterType.RemoveAllMage);
            if (!clList.Contains(HeroClass.Ranger))          cl.FilterList(FilterType.RemoveAllRanger);
            if (!clList.Contains(HeroClass.SoulWeaver))      cl.FilterList(FilterType.RemoveAllSoulWeaver);
                                                             
            if (!gdList.Contains(HeroGender.Male))           cl.FilterList(FilterType.RemoveAllMales);
            if (!gdList.Contains(HeroGender.Female))         cl.FilterList(FilterType.RemoveAllFemales);
            
            if (!ppList.Contains(Property.ClothesChange))    cl.FilterList(FilterType.RemoveAllClothesChange);
            if (!ppList.Contains(Property.Skin))             cl.FilterList(FilterType.RemoveAllSkin);
            if (!ppList.Contains(Property.SpecialtyChange))  cl.FilterList(FilterType.RemoveAllSpecialtyChange);
            if (!ppList.Contains(Property.Collab))           cl.FilterList(FilterType.RemoveAllCollab);
        
            cmbCharactersList.Items.Clear();
            foreach (Character character in cl.List) cmbCharactersList.Items.Add(character.name);
        }

        private void E7CharactersList_Load(object sender, EventArgs e) => LoadFilteredList();
        private void checkListProperties_SelectedIndexChanged(object sender, EventArgs e) => LoadFilteredList();
        private void checkListGender_SelectedIndexChanged(object sender, EventArgs e) => LoadFilteredList();
        private void checkListClass_SelectedIndexChanged(object sender, EventArgs e) => LoadFilteredList();
        private void checkListElements_SelectedIndexChanged(object sender, EventArgs e) => LoadFilteredList();
    }
}
