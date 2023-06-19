using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Permissions;
using System.Security.Principal;
using System.Windows.Forms;

namespace E7CharactersManager
{
    public partial class E7CharactersList : Form
    {
        private readonly string Version = File.ReadAllText("Update\\Version.txt");
        private readonly string AppPath = @"E7CharacterViewSetup.msi";
        private readonly string ZipPath = @"E7CharacterViewSetup.zip";
        private readonly string ServerVersionPath = "https://raw.githubusercontent.com/Yuuki2628/E7CharactersManager/master/E7CharactersManager/Update/Version.txt";
        private readonly string ServerZipPath = "https://raw.githubusercontent.com/Yuuki2628/E7CharactersManager/master/E7CharactersManager/Update/E7CharacterViewSetup.zip";
        private CharactersList CharactersList { get; set; }
        private bool Initializing { get; set; } = true;

        public E7CharactersList(string[] args)
        {
            InitializeComponent();

            CheckForUpdate(args);
            
            for (int i = 0; i < checkListClass.Items.Count; i++) checkListClass.SetItemChecked(i, true);
            for (int i = 0; i < checkListElements.Items.Count; i++) checkListElements.SetItemChecked(i, true);
            for (int i = 0; i < checkListRarity.Items.Count; i++) checkListRarity.SetItemChecked(i, true);
            for (int i = 0; i < checkListGender.Items.Count; i++) checkListGender.SetItemChecked(i, true);
            for (int i = 0; i < checkListProperties.Items.Count; i++) checkListProperties.SetItemChecked(i, true);

            this.TopMost = true;
            chbAlwaysOnTop.Checked = true;

            Initializing = false;
        }

        private void CheckForUpdate(string[] args)
        {
            WebClient webClientVersionCheck = new WebClient();
            WebClient webClientApplicationDownload = new WebClient();

            string ServerVersion = webClientVersionCheck.DownloadString(ServerVersionPath).Replace("\n", "").Replace("\r", "");

            int LocalVersionValue = (Int32.Parse(Version.Split('.')[0]) * 100) + (Int32.Parse(Version.Split('.')[1]) * 10) + (Int32.Parse(Version.Split('.')[2]) * 1);
            int ServerVersionValue = (Int32.Parse(ServerVersion.Split('.')[0]) * 100) + (Int32.Parse(ServerVersion.Split('.')[1]) * 10) + (Int32.Parse(ServerVersion.Split('.')[2]) * 1);

            if (ServerVersionValue > LocalVersionValue)
            {
                if ((args.Length > 0 && args[0] == "admin-update") || MessageBox.Show($"New update available!\nCurrently on version: {Version}\nNew version:{ServerVersion}", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (!(args.Length > 0 && args[0] == "admin-update"))
                        {
                            // Prompt the user for administrator credentials by launching a new process
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.FileName = Application.ExecutablePath;
                            startInfo.Arguments = "admin-update";
                            startInfo.Verb = "runas"; // Request elevation
                            try
                            {
                                Process.Start(startInfo);
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error requesting administrator privileges: " + ex.Message);
                                this.Close();
                            }
                        }

                        WindowsIdentity identity = WindowsIdentity.GetCurrent();
                        WindowsPrincipal principal = new WindowsPrincipal(identity);

                        bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
                        if (!isAdmin) return;

                        if (File.Exists(AppPath)) File.Delete(AppPath);
                        webClientApplicationDownload.DownloadFile(ServerZipPath, ZipPath);

                        ZipFile.ExtractToDirectory(ZipPath, @".\");

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
                    case "Skin":
                        ppList.Add(Property.Skin);
                        break;
                    case "Moonlight":
                        ppList.Add(Property.Moonlight);
                        break;
                    case "SpecialtyChange":
                        ppList.Add(Property.SpecialtyChange);
                        break;
                    case "Collab":
                        ppList.Add(Property.Collab);
                        break;
                    case "ClothesChange":
                        ppList.Add(Property.ClothesChange);
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

            if (!ppList.Contains(Property.Skin))             CharactersList.FilterList(FilterType.ByProperty.RemoveAllSkin);
            if (!ppList.Contains(Property.Moonlight))        CharactersList.FilterList(FilterType.ByProperty.RemoveAllMoonlight);
            if (!ppList.Contains(Property.SpecialtyChange))  CharactersList.FilterList(FilterType.ByProperty.RemoveAllSpecialtyChange);
            if (!ppList.Contains(Property.Collab))           CharactersList.FilterList(FilterType.ByProperty.RemoveAllCollab);
            if (!ppList.Contains(Property.ClothesChange))    CharactersList.FilterList(FilterType.ByProperty.RemoveAllClothesChange);
        
            cmbCharactersList.Items.Clear();
            cmbCharactersList.Text = string.Empty;
            foreach (Character character in CharactersList.List) cmbCharactersList.Items.Add(character);
        }

        private string RequestInputString(string formTitle, string formMessage)
        {
            string userInput = "";

            using (var form = new Form())
            using (var label = new Label())
            using (var textBox = new TextBox())
            using (var okButton = new Button())
            using (var cancelButton = new Button())
            {
                form.Text = formTitle;
                form.TopMost = this.TopMost;
                form.MaximizeBox = false;
                form.FormBorderStyle = FormBorderStyle.FixedSingle;
                textBox.Width = 200;
                label.Text = formMessage;
                okButton.Text = "OK";
                cancelButton.Text = "Cancel";

                okButton.DialogResult = DialogResult.OK;
                cancelButton.DialogResult = DialogResult.Cancel;

                // Position the controls in the form
                form.ClientSize = new System.Drawing.Size(300, 100);
                label.Location = new System.Drawing.Point(50, 15);
                textBox.Location = new System.Drawing.Point(50, 35);
                okButton.Location = new System.Drawing.Point(50, 60);
                cancelButton.Location = new System.Drawing.Point(130, 60);

                form.Controls.AddRange(new Control[] { textBox, label, okButton, cancelButton });

                // Show the form and wait for user input
                if (form.ShowDialog() == DialogResult.OK)
                {
                    userInput = textBox.Text;
                }
            }
            return userInput;
        }

        private void E7CharactersList_Load(object sender, EventArgs e)                    => LoadFilteredList();
        private void checkListClass_SelectedIndexChanged(object sender, EventArgs e)      => LoadFilteredList();
        private void checkListElements_SelectedIndexChanged(object sender, EventArgs e)   => LoadFilteredList();
        private void checkListRarity_SelectedIndexChanged(object sender, EventArgs e)     => LoadFilteredList();
        private void checkListGender_SelectedIndexChanged(object sender, EventArgs e)     => LoadFilteredList();
        private void checkListProperties_SelectedIndexChanged(object sender, EventArgs e) => LoadFilteredList();

        private void chbAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chbAlwaysOnTop.Checked;
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            ChromeManager.OpenNewTab("https://github.com/Yuuki2628/E7CharactersManager");
        }

        private void btnEpic7x_Click(object sender, EventArgs e)
        {
            if(CharactersList.List.Count == 0) return;
            if (cmbCharactersList.SelectedItem == null) return;

            Character character = cmbCharactersList.SelectedItem as Character;
            if (character.Properties.Contains(Property.Skin))
                ChromeManager.OpenNewTab("https://epic7x.com/character/" + character.SkinOf.Name.ToLower().Replace(" ", "-") + "/");
            else
                ChromeManager.OpenNewTab("https://epic7x.com/character/" + character.Name.ToLower().Replace(" ", "-") + "/");
        }

        private void btnE7Vault_Click(object sender, EventArgs e)
        {
            if (CharactersList.List.Count == 0) return;
            if (cmbCharactersList.SelectedItem == null) return;

            Character character = cmbCharactersList.SelectedItem as Character;
            ChromeManager.OpenNewTab("https://www.e7vau.lt/portrait-viewer.html?id=" + character.CID);
        }

        private void btnExportList_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This application works only if you have the following installed:\n-Chrome\n-Python\n-Selenium for Python\n\nDo you have all of them installed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                return;

            string url = RequestInputString("Form url", "Please input the tournament name url");
            if (url == "") return;

            string list = "[";
            foreach (Character character in cmbCharactersList.Items) list += $"\"{character.Name} : {character.CID} \", ";
            list += "]";

            if (File.Exists("script1.py")) File.Delete("script1.py");

            string[] lines =
            {
                "from selenium import webdriver",
                "from selenium.webdriver.common.keys import Keys",
                "from selenium.webdriver.common.by import By",
                "import time",
                "",
                "# Set up the web driver (e.g., for Chrome)",
                "options = webdriver.ChromeOptions() ",
                "options.add_argument('user-data-dir=C:\\\\\\\\Users\\\\Robin\\\\AppData\\\\Local\\\\Google\\\\Chrome\\\\User Data')",
                "driver = webdriver.Chrome(executable_path='D:\\\\\\\\Documenti2\\\\temp\\\\chromedriver.exe', chrome_options=options)",
                "#driver = webdriver.Chrome('/path/to/chromedriver')",
                "",
                "# Define your array of elements",
                "elements = " + list,
                "",
                "print('Characters count: ' + str(len(elements)))",
                "",
                "# Iterate over the elements and fill/submit the form",
                "for element in elements:",
                "",
                "    # Load the form URL",
                "    driver.get('" + "https://animebracket.com/" + url + "/nominate" + "')",
                "    driver.find_element(By.CLASS_NAME, 'accept').click()",
                "    time.sleep(1)",
                "",
                "    # Find the form fields and fill them with the element",
                "    field1 = driver.find_element(By.ID, 'txtName')",
                "    field2 = driver.find_element(By.ID, 'txtSource')",
                "    field3 = driver.find_element(By.ID, 'txtPic')",
                "",
                "    chname = element.split(' : ')[0]",
                "    chlink = 'https://raw.githubusercontent.com/Yuuki2628/E7CharactersManager/master/E7CharactersManager/Portraits/' + element.split(' : ')[1].strip() + '.png'",
                "    ",
                "    field1.send_keys(chname)",
                "    field2.send_keys('Epic Seven')",
                "    field3.send_keys(chlink)",
                "    ",
                "    # Submit the form",
                "    driver.find_elements(By.CLASS_NAME , 'small-button')[1].click()",
                "    print(chlink + ' - ' + chname)",
                "    time.sleep(5)",
                "    ",
                "# Load the form URL",
                "driver.get('" + "https://animebracket.com/me/process/" + url + "/nominations/" + "')",
                "time.sleep(2)",
                "",
                "try:",
                "    for i in range(len(elements)):",
                "        try:",
                "            time.sleep(1)",
                "            ",
                "            button1 = driver.find_element(By.XPATH, '/HTML[1]/BODY[1]/DIV[1]/DIV[1]/DIV[1]/DIV[1]/FORM[1]/DIV[1]/BUTTON[1]')",
                "            button1.click()",
                "            time.sleep(1)",
                "",
                "            try:",
                "                button2 = driver.find_element(By.XPATH, '/HTML[1]/BODY[1]/DIV[1]/DIV[1]/DIV[2]/DIV[1]/DIV[2]/DIV[1]/BUTTON[1]')",
                "                button2.click()",
                "                time.sleep(1)",
                "            except:",
                "                button2 = driver.find_element(By.XPATH, '/HTML[1]/BODY[1]/DIV[1]/DIV[1]/DIV[3]/DIV[1]/DIV[2]/DIV[1]/BUTTON[1]')",
                "                button2.click()",
                "                time.sleep(1)",
                "",
                "            button3 = driver.find_element(By.XPATH, '/HTML[1]/BODY[1]/DIV[1]/DIV[1]/DIV[1]/DIV[1]/FORM[1]/DIV[2]/DIV[4]/BUTTON[1]')",
                "            button3.click()",
                "            time.sleep(1)",
                "        ",
                "        except:",
                "            print('Error')",
                "except:",
                "    print('Exiting')",
                "    ",
                "    ",
                "# Close the browser after completing the iterations",
                "driver.quit()"
            };
            File.WriteAllLines("script1.py", lines);

            if (MessageBox.Show("The script has been generated and placed in your folder.\nDo you want to run it now?\nNote that running the script will requite the application to kill all chrome processes first", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                return;

            ChromeManager.CloseChrome();

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "python";
            startInfo.Arguments = "script1.py";

            // Start the process
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            // Wait for the process to exit
            process.WaitForExit();

            try
            {
                string output = process.StandardOutput.ReadToEnd();
            }
            catch { }
        }

        private void btnOpenMissingImages_Click(object sender, EventArgs e)
        {
            foreach (Character character in cmbCharactersList.Items)
            {
                if (!File.Exists("Portraits/" + character.CID + ".png"))
                    ChromeManager.OpenNewTab("https://www.e7vau.lt/portrait-viewer.html?id=" + character.CID);
            }
        }
    }
}
