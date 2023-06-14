using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace E7CharactersManager
{
    public partial class E7CharactersList : Form
    {
        private const string Version = "1.0.0";
        private const string AppPath = @".\application.msi";
        private const string ZipPath = @".\application.zip";
        private const string ServerAppPath = @"";
        private CharactersList CharactersList { get; set; }
        private bool Initializing { get; set; } = true;

        public E7CharactersList()
        {
            InitializeComponent();
            CheckForUpdate();
            for (int i = 0; i < checkListClass.Items.Count; i++) checkListClass.SetItemChecked(i, true);
            for (int i = 0; i < checkListElements.Items.Count; i++) checkListElements.SetItemChecked(i, true);
            for (int i = 0; i < checkListRarity.Items.Count; i++) checkListRarity.SetItemChecked(i, true);
            for (int i = 0; i < checkListGender.Items.Count; i++) checkListGender.SetItemChecked(i, true);
            for (int i = 0; i < checkListProperties.Items.Count; i++) checkListProperties.SetItemChecked(i, true);

            this.TopMost = true;
            chbAlwaysOnTop.Checked = true;

            Initializing = false;
        }

        private void CheckForUpdate()
        {
            WebClient webClientVersionCheck = new WebClient();
            WebClient webClientApplicationDownload = new WebClient();

            string ServerVersion = webClientVersionCheck.DownloadString("").Replace("\n", "").Replace("\r", "");

            if (ServerVersion != Version)
            {
                if (MessageBox.Show($"New update available!\nCurrently on version: {Version}\nNew version:{ServerVersion}", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (File.Exists(AppPath)) File.Delete(AppPath);
                        webClientApplicationDownload.DownloadFile(ServerAppPath, ZipPath);

                        ZipFile.ExtractToDirectory(ZipPath, AppPath);

                        Process process = new Process();
                        process.StartInfo.FileName = "msiexec";
                        process.StartInfo.Arguments = String.Format("/i " + AppPath);

                        this.Close();
                        process.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void LoadFilteredList()
        {
            if (Initializing) return;

            CharactersList = new CharactersList();
            List<HeroClass> clList = new List<HeroClass>();
            List<HeroElement> elList = new List<HeroElement>();
            List<HeroRarity> rrList = new List<HeroRarity>();
            List<HeroGender> gdList = new List<HeroGender>();
            List<Property> ppList = new List<Property>();

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
            foreach (string check in checkListRarity.CheckedItems)
            {
                switch (check)
                {
                    case "3 Stars":
                        rrList.Add(HeroRarity.Stars3);
                        break;
                    case "4 Stars":
                        rrList.Add(HeroRarity.Stars4);
                        break;
                    case "5 Stars":
                        rrList.Add(HeroRarity.Stars5);
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

            if (!clList.Contains(HeroClass.DummyClass))      CharactersList.FilterList(FilterType.ByClass.RemoveAllDummyClass);
            if (!clList.Contains(HeroClass.Warrior))         CharactersList.FilterList(FilterType.ByClass.RemoveAllWarrior);
            if (!clList.Contains(HeroClass.Knight))          CharactersList.FilterList(FilterType.ByClass.RemoveAllKnight);
            if (!clList.Contains(HeroClass.Thief))           CharactersList.FilterList(FilterType.ByClass.RemoveAllThief);
            if (!clList.Contains(HeroClass.Mage))            CharactersList.FilterList(FilterType.ByClass.RemoveAllMage);
            if (!clList.Contains(HeroClass.Ranger))          CharactersList.FilterList(FilterType.ByClass.RemoveAllRanger);
            if (!clList.Contains(HeroClass.SoulWeaver))      CharactersList.FilterList(FilterType.ByClass.RemoveAllSoulWeaver);

            if (!elList.Contains(HeroElement.Fire))          CharactersList.FilterList(FilterType.ByElement.RemoveAllFire);
            if (!elList.Contains(HeroElement.Earth))         CharactersList.FilterList(FilterType.ByElement.RemoveAllEarth);
            if (!elList.Contains(HeroElement.Ice))           CharactersList.FilterList(FilterType.ByElement.RemoveAllIce);
            if (!elList.Contains(HeroElement.Light))         CharactersList.FilterList(FilterType.ByElement.RemoveAllLight);
            if (!elList.Contains(HeroElement.Dark))          CharactersList.FilterList(FilterType.ByElement.RemoveAllDark);

            if (!rrList.Contains(HeroRarity.Stars3))         CharactersList.FilterList(FilterType.ByRarity.RemoveAllStars3);
            if (!rrList.Contains(HeroRarity.Stars4))         CharactersList.FilterList(FilterType.ByRarity.RemoveAllStars4);
            if (!rrList.Contains(HeroRarity.Stars5))         CharactersList.FilterList(FilterType.ByRarity.RemoveAllStars5);

            if (!gdList.Contains(HeroGender.Male))           CharactersList.FilterList(FilterType.ByGender.RemoveAllMales);
            if (!gdList.Contains(HeroGender.Female))         CharactersList.FilterList(FilterType.ByGender.RemoveAllFemales);
            
            if (!ppList.Contains(Property.ClothesChange))    CharactersList.FilterList(FilterType.ByProperty.RemoveAllClothesChange);
            if (!ppList.Contains(Property.Skin))             CharactersList.FilterList(FilterType.ByProperty.RemoveAllSkin);
            if (!ppList.Contains(Property.SpecialtyChange))  CharactersList.FilterList(FilterType.ByProperty.RemoveAllSpecialtyChange);
            if (!ppList.Contains(Property.Collab))           CharactersList.FilterList(FilterType.ByProperty.RemoveAllCollab);
        
            cmbCharactersList.Items.Clear();
            cmbCharactersList.Text = string.Empty;
            foreach (Character character in CharactersList.List) cmbCharactersList.Items.Add(character);
        }

        private void E7CharactersList_Load(object sender, EventArgs e) => LoadFilteredList();
        private void checkListClass_SelectedIndexChanged(object sender, EventArgs e) => LoadFilteredList();
        private void checkListElements_SelectedIndexChanged(object sender, EventArgs e) => LoadFilteredList();
        private void checkListRarity_SelectedIndexChanged(object sender, EventArgs e) => LoadFilteredList();
        private void checkListGender_SelectedIndexChanged(object sender, EventArgs e) => LoadFilteredList();
        private void checkListProperties_SelectedIndexChanged(object sender, EventArgs e) => LoadFilteredList();

        private void chbAlwaysOnTop_CheckedChanged(object sender, EventArgs e) => this.TopMost = chbAlwaysOnTop.Checked;

        private void btnEpic7x_Click(object sender, EventArgs e)
        {
            if(CharactersList.List.Count == 0) return;
            if (cmbCharactersList.SelectedItem == null) return;

            Character character = cmbCharactersList.SelectedItem as Character;
            if (character.Properties.Contains(Property.Skin))
                CharactersList.OpenNewTab("https://epic7x.com/character/" + character.SkinOf.Name.ToLower().Replace(" ", "-") + "/");
            else
                CharactersList.OpenNewTab("https://epic7x.com/character/" + character.Name.ToLower().Replace(" ", "-") + "/");
        }

        private void btnE7Vault_Click(object sender, EventArgs e)
        {
            if (CharactersList.List.Count == 0) return;
            if (cmbCharactersList.SelectedItem == null) return;

            Character character = cmbCharactersList.SelectedItem as Character;
            CharactersList.OpenNewTab("https://www.e7vau.lt/portrait-viewer.html?id=" + character.CID);
        }
    }
}
