/*
    VulnInjector - Generates a 'vulnerable' machine using the end users own setup files & product keys.
    Copyright (C) 2013  g0tmi1k

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
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using VulnInjector.Properties;

namespace VulnInjector
{
    public partial class Main : Form
    {
        private static readonly string Bin = "bin"; // bin folder
        private static readonly string UnattendedFiles = Path.Combine(Application.StartupPath, "unattendedfiles"); // Unattended files folder
        private static readonly string SevenZipExe = Path.Combine(Bin, "7z.exe"); // External EXE ~ 7zip
        private static readonly string SevenZipDll = Path.Combine(Bin, "7z.dll"); // External EXE ~ 7zip (7z.dll)
        private static readonly string MkisofsExe = Path.Combine(Bin, "mkisofs.exe"); // External EXE ~ mkisofs
        private static readonly string MkisofsDll = Path.Combine(Bin, "cygwin1.dll"); // External EXE ~ mkisofs (cygwin1.dll)
        private static readonly string GetEltorito = Path.Combine(Bin, "geteltorito.exe"); // External EXE ~ geteltorito
        private static readonly string CmdLines = Path.Combine(UnattendedFiles, "cmdlines.txt"); // Unattended File ~ cmdline - used during the setup to run "RunOnceEx.cmd"
        private static readonly string RunOnceExe = Path.Combine(UnattendedFiles, "RunOnceEx.cmd"); // Unattended File ~ RunOnceEx - To add values to perform on first reset (e.g. run out setup file!)
        private static readonly string WinNTSif = Path.Combine(UnattendedFiles, "WINNT.SIF"); // Unattended File ~ WINNT - Automates/Silents the Windows seutp process
        private static readonly string ReadmeTxt = Path.Combine(Application.StartupPath, "README.txt"); // Readme file
        private readonly List<String> _files = new List<String>(); // List off all the files
        private string _bootbin; // Where is the boot image
        private bool _copied; // Have we copied everything over?
        private string _slipstream; // Have we copied everything over?
        private string _destination; // Where all the information will be stored
        private string _message; // Error Messages
        private string _source; // Where all the information is stored
        // Values from XML
        private string _targetArch;
        private string _targetEdition;
        private string _targetName;
        private string _targetOs;
        private string _targetSetup;
        private string _targetSp;
        private string _targetVersion;
        private string _targetRelease;

        public Main()
        {
            InitializeComponent();
            this.Text = String.Format("{0} v{1}", Application.ProductName, Application.ProductVersion);
        }

        private void ThreadCopy(string type)
        {
            Invoke(new MethodInvoker(() =>
            {
                txtStatus.Text = String.Format("Cloning '{0}'", _source);
                _copied = btnDriveISO.Enabled = false;
            }));

            if (type == "iso")
                IsoCopy(_source, _destination);
            else
                DriveCopy(_source, _destination);

            Invoke(new MethodInvoker(() =>
            {
                txtStatus.Text = String.Format("Copied '{0}' to '{1}'", _source, _destination);
                 _copied = btnDriveISO.Enabled = true;
            }));

            _source = _destination;

            AllowGen();

            string path = Path.Combine(_source, "boot.catalog");
            if (File.Exists(path))
                File.Delete(path);

            Invoke(new MethodInvoker(() => progressBar.Value = 0 ));
        }

        private void ThreadCreate(string destination)
        {
            // Create ISO
            Invoke(new MethodInvoker(() =>
            {
                progressBar.Maximum = 100;
                progressBar.Value = 0;
            }));

            string IsoLabel = new string(_targetName.Take(16).ToArray());
            //(!!!Unable to get output of the process!!! So going to have to show it)
            var isoexe = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments =
                        String.Format(
                            "/C {0} -b boot.bin -no-emul-boot -boot-load-seg 1984 -boot-load-size 4 -iso-level 2 -J -l -D -N -joliet-long -relaxed-filenames -V \"{3}\" -o \"{1}\" \"{2}\"",
                            MkisofsExe, destination, _destination, IsoLabel),
                    WorkingDirectory = Application.StartupPath,
                }
            };

            try
            {
                isoexe.Start();
                int value = 0;
                while (!isoexe.StandardError.EndOfStream)
                {
                    string line = isoexe.StandardError.ReadLine();
                    if (line != null && line.Contains("% done,"))
                    {
                        txtStatus.Text = line;
                        if (line.Contains("."))
                            value = Convert.ToInt16(line.Split('.')[0]);
                        if (progressBar.Value < progressBar.Maximum)
                            Invoke(new MethodInvoker(() => progressBar.Value = value));
                    }

                }
                //isoexe.WaitForExit();

                Invoke(new MethodInvoker(() =>
                {
                    txtStatus.Text = "Done!";
                    progressBar.Value = 100;
                }));
            }
            catch
            {
                Invoke(new MethodInvoker(() => txtStatus.Text = "Something went wrong creating the ISO!"));
            }
        }

        private void ThreadDelete()
        {
            // Get all files
            string[] files = Directory.GetFiles(_destination,
                "*.*",
                SearchOption.AllDirectories);

            Invoke(new MethodInvoker(() =>
            {
                progressBar.Maximum = files.Count();
                progressBar.Value = 0;
            }));

            // Diplay and remove
            foreach (string file in files)
            {
                RemoveReadOnly(file);

                Invoke(new MethodInvoker(() =>
                {
                    txtStatus.Text = String.Format("Deleting: '{0}'", file);
                    if (progressBar.Value < progressBar.Maximum)
                        progressBar.Value++;
                }));


                try
                {
                    File.Delete(file);
                }
                catch (IOException)
                {
                    txtStatus.Text = string.Format("Unable to remove '{0}' as the thread is still running!", file);
                }

            }

            // Remove the folder
            try
            {
                Directory.Delete(_destination, true);
            }
            catch (IOException)
            {
                txtStatus.Text = "Unable to remove folder as thread is still running!";
            }
        }

        private void ReadXml()
        {
            string xml = Path.Combine(Application.StartupPath, "settings.xml");
            CheckFile(xml, true);

            XDocument doc;
            try
            {
                doc = XDocument.Load(xml);
            }
            catch
            {
                MessageBox.Show("Failed to parse file: 'settings.xml'.\n\nQuitting...", "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
                return;
            }

            XElement targetxml = doc.Descendants("target").FirstOrDefault();
            if (targetxml != null)
            {
                XElement nameElement = targetxml.Element("name");
                if (nameElement != null)
                    _targetName = nameElement.Value;
                XElement versionElement = targetxml.Element("version");
                if (versionElement != null)
                    _targetVersion = versionElement.Value;
                XElement releaseElement = targetxml.Element("release");
                if (releaseElement != null)
                    _targetRelease = releaseElement.Value;
                XElement osElement = targetxml.Element("os");
                if (osElement != null)
                    _targetOs = osElement.Value;
                XElement spElement = targetxml.Element("sp");
                if (spElement != null)
                    _targetSp = spElement.Value;
                XElement editionElement = targetxml.Element("edition");
                if (editionElement != null)
                    _targetEdition = editionElement.Value;
                XElement archElement = targetxml.Element("arch");
                if (archElement != null)
                    _targetArch = archElement.Value;
                XElement setupElement = targetxml.Element("setup");
                if (setupElement != null)
                    _targetSetup = setupElement.Value;
                XElement authorElement = targetxml.Element("author");
            }
            else
            {
                MessageBox.Show("'settings.xml' is invalid.\n\nQuitting...", "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }

            if (_targetName == null ||
                _targetVersion == null ||
                _targetRelease == null ||
                _targetOs == null ||
                _targetSp == null ||
                _targetEdition == null ||
                _targetArch == null ||
                _targetSetup == null)
            {
                string error = "";
                if (_targetName == null)
                    error += "Missing: name.\n";
                if (_targetVersion == null)
                    error += "Missing: version.\n";
                if (_targetRelease == null)
                    error += "Missing: release.\n";
                if (_targetOs == null)
                    error += "Missing: os.\n";
                if (_targetSp == null)
                    error += "Missing: sp.\n";
                if (_targetEdition == null)
                    error += "Missing: edition.\n";
                if (_targetArch == null)
                    error += "Missing: arch.\n";
                if (_targetSetup == null)
                    error += "Missing: setup.\n";
                MessageBox.Show(error + "\nQuitting...", "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }

            _targetSetup = Path.Combine(UnattendedFiles, _targetSetup);
            CheckFile(_targetSetup, true);

            lbTarget.Text = _targetName;
            lbTargetOS.Text = _targetOs;
            lbTargetSP.Text = _targetSp;
            lbTargetEdition.Text = _targetEdition;
            lbTargetArch.Text = _targetArch;

            this.Text = String.Format("{0} || {1} {2} (Build: #{3})", this.Text, _targetName, _targetVersion, _targetRelease);
        }

        private bool MatchTarget()
        {
            lbSourceOS.ForeColor = lbSourceSP.ForeColor = lbSourceEdition.ForeColor = lbSourceArch.ForeColor = Color.Black;

            if (lbSourceOS.Text == "-")
            {
                lbResult.ForeColor = Color.Orange;
                lbResult.Text = "-";
            }
            else if (lbSourceOS.Text.ToLower().Contains(lbTargetOS.Text.ToLower()) &&
                     lbSourceArch.Text.ToLower() == lbTargetArch.Text.ToLower())
            {
                string SourceEdition = lbSourceEdition.Text.ToLower();
                string TagetEdition = lbTargetEdition.Text.ToLower();
                int SourceSP = Convert.ToInt32(Regex.Match(lbSourceSP.Text, @"\d+").Value);
                int TagetSP = Convert.ToInt32(Regex.Match(lbTargetSP.Text, @"\d+").Value);

                // Only for Windows XP & If the source doesn't match the target....
                if (lbTargetOS.Text.ToLower().Contains("xp") && !SourceEdition.Contains(TagetEdition))
                {
                    // If its "home", allow "pro" to be used.
                    if (TagetEdition.Contains("home"))
                    {
                        lbResult.Text = "Valid";
                        txtStatus.Text = "Risking: 'edition'";
                        lbResult.ForeColor = lbSourceEdition.ForeColor = Color.Orange;
                    }
                    else
                    {
                        lbResult.Text = "Invalid";
                        txtStatus.Text = String.Format("Unable to use this source, as it doesn't match {0}.", _targetName);
                        lbResult.ForeColor = lbSourceEdition.ForeColor = Color.Red;

                        AllowGen();
                        return false;
                    }
                }

                //If the source is using a older service pack, need to slipstream
                if (SourceSP < TagetSP)
                {
                    lbResult.Text = "Invalid";
                    txtStatus.Text = "Need a newer service pack";
                    lbResult.ForeColor = lbSourceSP.ForeColor = Color.Red;

                    DialogResult dialogResult = MessageBox.Show(string.Format("Do you wish to slipstream service pack {0}, so that '{1}' will work?\n\nWhen prompt, please select the necessarily service pack setup. If you haven't already got a stand alone installer, please download it now before continuing.", TagetSP, _targetName),
                        "Question || VulnInjector",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.No)
                        return false;
                    else
                    {
                        // Open the ISO file
                        var openDialog = new OpenFileDialog
                        {
                            Filter = "Service pack (*.exe)|*.exe|All files (*.*)|*.*",
                            Title = "Select the service pack",
                        };
                        if (openDialog.ShowDialog() != DialogResult.OK)
                            return false;

                        _slipstream = openDialog.FileName;
                    }
                }
                // If the source is using a newer service pack, risk it
                else if (SourceSP > TagetSP)
                {
                    lbResult.Text = "Valid";
                    txtStatus.Text = "Risking: 'service pack'";
                    lbResult.ForeColor = lbSourceSP.ForeColor = Color.Orange;
                }
                // If both SP and edition match, its allowed/trusted (as well as the other checks before)
                else if (SourceEdition.Contains(TagetEdition) && SourceSP.Equals(TagetSP))
                {
                    lbResult.Text = "Valid";
                    txtStatus.Text = "Valid source. We have a match!";
                    lbResult.ForeColor = Color.Green;
                }

                AllowGen();
                txtKey.Focus();
                return true;
            }
            else
            {
                if (!lbSourceOS.Text.ToLower().Contains(lbTargetOS.Text.ToLower()))
                    lbSourceOS.ForeColor = Color.Red;
                if (!lbSourceSP.Text.ToLower().Contains(lbTargetSP.Text.ToLower()))
                    lbSourceSP.ForeColor = Color.Red;
                if (!lbSourceEdition.Text.ToLower().Contains(lbTargetEdition.Text.ToLower()))
                    lbSourceEdition.ForeColor = Color.Red;
                if (lbSourceArch.Text.ToLower() != lbTargetArch.Text.ToLower())
                    lbSourceArch.ForeColor = Color.Red;

                lbResult.ForeColor = Color.Red;
                lbResult.Text = "Invalid";
                txtStatus.Text = String.Format("Unable to use this source, as it doesn't match '{0}'.", _targetName);
            }

            AllowGen();
            return false;
        }

        private void ScanCD()
        {
            txtStatus.Text = "Scanning";
            DriveISOMenu.Items.Clear();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives
                         .Where(d => d.DriveType == DriveType.CDRom && d.IsReady))
            {
                DriveISOMenu.Items.Add(d.Name, Resources.EmptyDrive);
                txtStatus.Text = String.Format("Found: '{0} [{1}]'", d.Name, d.VolumeLabel);
            }

            if (DriveISOMenu.Items.Count == 0)
                DriveISOMenu.Items.Add(nAToolStripMenuItem);
            DriveISOMenu.Items.AddRange(new ToolStripItem[]
            {
                toolStripSeparator2,
                rescanToolStripMenuItem,
                toolStripSeparator3,
                openImageFileToolStripMenuItem
            });
        }

        private void ClipboardKey()
        {
            var dataObject = Clipboard.GetDataObject();
            if (dataObject != null && dataObject.GetDataPresent(DataFormats.Text))
            {
                string clipboard = Clipboard.GetText().ToUpper();
                clipboard = Regex.Replace(clipboard, @"[^2346789BCDFGHJKMPQRTVWXY]", ""); //01AEILNOSUZ
                if (clipboard.Trim().Length == 25)
                    txtKey.Text = clipboard;
            }
        }

        private Boolean SlipStream(string spexe)
        {
            _message = txtStatus.Text = "Integrating service pack";
            var startInfo = new ProcessStartInfo
            {
                FileName = spexe,
                Arguments = String.Format("/passive /integrate:{0}", _source),
                WorkingDirectory = Application.StartupPath,
            };

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                    exeProcess.WaitForExit();
            }
            catch
            {
                _message = txtStatus.Text = "Unable to integrating service pack";
                MessageBox.Show(_message, "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            _message = txtStatus.Text = "Integrated service pack";
            return true;
        }

        private void ResetSource()
        {
            progressBar.Value = 0;
            lbSourceOS.Text = "-";
            lbSourceSP.Text = "-";
            lbSourceEdition.Text = "-";
            lbSourceArch.Text = "-";
            lbSourceLicense.Text = "-";
            _slipstream = null;
            txtStatus.Text = "Select a source";
            MatchTarget();
        }

        private void AllowGen()
        {
            if (lbResult.Text == "Valid" &&
                Regex.IsMatch(txtKey.Text, "^[2346789BCDFGHJKMPQRTVWXY]{25}$") && //01AEILNOSUZ
                txtKey.Text != "AAAAABBBBBCCCCCDDDDDEEEEE" &&
                _copied == true)
                Invoke(new MethodInvoker(() => Generate.Enabled = true));
            else
                Invoke(new MethodInvoker(() => Generate.Enabled = false));
        }

        private Boolean CopyFiles(string type)
        {
            //---Select Temp Folder------------------------------
            var tempDialog = new FolderBrowserDialog
            {
                Description = "Where to store the 'temporary' files?",
                ShowNewFolderButton = true,
                RootFolder = Environment.SpecialFolder.Desktop
            };

            _destination = null;
            while (_destination == null)
            {
                if (tempDialog.ShowDialog() != DialogResult.OK)
                    return false;
                _destination = Path.Combine(tempDialog.SelectedPath, "vi_tmp");

                if (Directory.Exists(_destination))
                {
                    DialogResult dialogResult = MessageBox.Show(string.Format("'{0}' already exists. Are you sure?", _destination),
                        "Question || VulnInjector",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.No)
                        _destination = null;
                }
            }
            //---Select Temp Folder END--------------------------

            Directory.CreateDirectory(_destination);

            //---Extract boot image via geteltorito.exe----------
            var startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                FileName = "cmd.exe",
                Arguments = String.Format("/C {0} ", GetEltorito),
                WorkingDirectory = Application.StartupPath,
            };

            string source = _source.TrimEnd(new[] { '\\', '/' });
            _bootbin = Path.Combine(_destination, "boot.bin");

            if (type == "drive")
                startInfo.Arguments += "\\\\.\\";
            else
                source = String.Format("\"{0}\"", source);

            startInfo.Arguments += String.Format("{0} > \"{1}\"", source, _bootbin);

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                    exeProcess.WaitForExit();
            }
            catch
            {
                _message = txtStatus.Text = "Unable to extract boot image";
                MessageBox.Show(_message, "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Is there a file?
            if (!CheckFile(_bootbin, false))
                return false;

            // Is the file empty?
            if (new FileInfo(_bootbin).Length == 0)
            {
                MessageBox.Show("Failed to extract boot image (1)", "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Is it not a boot file?
            using (var stream = new FileStream(_bootbin, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    string code = reader.ReadByte() + reader.ReadByte().ToString(CultureInfo.InvariantCulture);
                    if (!code.Equals("25051"))
                    {
                        MessageBox.Show("Failed to extract boot image (2)", "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            //---Extract boot image via geteltorito.exe END------

            //---Copy data---------------------------------------
            var t = new Thread(() => ThreadCopy(type));
            t.Start();
            while (t.IsAlive)
                Application.DoEvents();
            //---Copy data END-----------------------------------

            return true;
        }

        private void IsoCopy(string sourceDirName, string destDirName)
        {
            int totalfile = 0;
            var isolist = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = String.Format("/C {0} l -xr![BOOT] -y \"{1}\"", SevenZipExe, sourceDirName),
                    WorkingDirectory = Application.StartupPath,
                }
            };

            try
            {
                isolist.Start();
                while (!isolist.StandardOutput.EndOfStream)
                {
                    string line = isolist.StandardOutput.ReadLine();
                    if (line != null && line.Contains(" files, "))
                        totalfile = Convert.ToInt32(line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[2]);
                }
            }
            catch
            {
                _message = txtStatus.Text = "Unable to list files in the ISO";
                MessageBox.Show(_message, "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Invoke(new MethodInvoker(() =>
            {
                progressBar.Maximum = totalfile;
                progressBar.Value = 0;
            }));

            var isocp = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = String.Format("/C {0} x -bd -o\"{1}\" -r -tiso -xr![BOOT] -y \"{2}\"", SevenZipExe, destDirName, sourceDirName),
                    WorkingDirectory = Application.StartupPath,
                }
            };

            try
            {
                isocp.Start();
                while (!isocp.StandardOutput.EndOfStream)
                {
                    string line = isocp.StandardOutput.ReadLine();
                    if (line != null && line.StartsWith("Extracting "))
                    {
                        txtStatus.Text = String.Format("Copying: '{0}'", line.Replace("Extracting ", "").Trim());
                        Invoke(new MethodInvoker(() => { if (progressBar.Value < progressBar.Maximum)
                            progressBar.Value++; })); // Extracts more than it lists (e.g. boot image)
                    }
                    if (_copied == true)
                        isocp.Kill();
                }
            }
            catch
            {
                _message = txtStatus.Text = "Unable to extract ISO";
                //MessageBox.Show(_message, "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DriveCopy(string sourceDirName, string destDirName)
        {
            DriveList(sourceDirName, destDirName);
            Invoke(new MethodInvoker(() =>
            {
                progressBar.Maximum = _files.Count();
                progressBar.Value = 0;
            }));

            foreach (String copyfrom in _files)
            {
                if (_copied == false)
                {
                    Invoke(new MethodInvoker(() => txtStatus.Text = String.Format("Copying: '{0}'", copyfrom.Replace(sourceDirName, "").Trim())));

                    string copyto = Path.Combine(destDirName, copyfrom.Replace(sourceDirName, ""));
                    string destFoldername = Directory.GetParent(copyto).ToString();

                    if (!Directory.Exists(destFoldername))
                        Directory.CreateDirectory(destFoldername);

                    Invoke(new MethodInvoker(() => { if (progressBar.Value < progressBar.Maximum)
                        progressBar.Value++; }));


                    RemoveReadOnly(copyto);

                    File.Copy(copyfrom, copyto, true);
                }
            }
        }

        private void DriveList(string sourceDirName, string destDirName)
        {
            var dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();

            if (!dir.Exists)
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
            //if (sourceDirName == destDirName) throw new DirectoryNotFoundException("Source directory is the same as destination");

            foreach (FileInfo file in files)
                _files.Add(file.FullName);

            foreach (DirectoryInfo subdir in dirs)
                DriveList(subdir.FullName, Path.Combine(destDirName, subdir.Name));
        }

        private bool CheckFile(string path, Boolean quit)
        {
            string filename = Path.GetFileName(path);

            if (!File.Exists(path))
            {
                _message = String.Format("Unable to open file: '{0}'.", filename);
                if (quit)
                    _message += "\n\nQutting...";

                MessageBox.Show(_message, "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtStatus.Text = _message;

                if (quit)
                    Application.Exit();
                return false;
            }
            return true;
        }

        private void RemoveReadOnly(string file)
        {
            // If there isn't a file dont carry on!
            if (!File.Exists(file))
                return;

            // Get the attributes of the file
            var attr = File.GetAttributes(file);

            // Is this file marked as 'read-only'?
            if ((attr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                // Yes... Remove the 'read-only' attribute, then
                File.SetAttributes(file, attr ^ FileAttributes.ReadOnly);
            }
        }

        private void LoadSource(string type, string path)
        {
            string line; // Used when reading files in

            ResetSource();

            txtStatus.Text = String.Format("Loading: '{0}'", path);
            if (type == "iso" || type == "drive")
                txtSource.Text = path;

            _source = path; // Make sure the source is set to the value shown in txtSource (so able to extract boot section)
            if (type == "iso")
            {
                // Did the files not copy correctly?
                if (!CopyFiles(type))
                    return;
                // Do we need to slipstream
                if (_slipstream != null)
                    // Did we do it correctly?
                    if (SlipStream(_slipstream))
                        //If so, reload the the source, to make sure the update has taken effect
                        LoadSource("slipstream", _source);
                    else
                        // No, so stop
                        return;
            }
            string fullpath = path = _source;

            //---Architecture------------------------------------
            if (Directory.Exists(Path.Combine(path, "AMD64")))
            {
                lbSourceArch.Text = "x64";
                fullpath = Path.Combine(fullpath, "AMD64");
            }
            else if (Directory.Exists(Path.Combine(path, "I386")))
            {
                lbSourceArch.Text = "x86";
                fullpath = Path.Combine(fullpath, "I386");
            }
            else
            {
                _message = txtStatus.Text = "Unable to detect image architecture. Halting.";
                MessageBox.Show(_message, "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //---Architecture END------------------------------------

            //---License---------------------------------------------
            string fileinuse = Path.Combine(fullpath, "setupp.ini");
            if (!CheckFile(fileinuse, false))
                return;

            var file = new StreamReader(fileinuse);
            while ((line = file.ReadLine()) != null)
                if (line.ToLower().StartsWith("pid="))
                    break;
            file.Close();

            if (line != null && line.ToLower().EndsWith("oem"))
                lbSourceLicense.Text = "OEM";
            else if (line != null && line.ToLower().EndsWith("335"))
                lbSourceLicense.Text = "Retail";
            else if (line != null && line.ToLower().EndsWith("270"))
                lbSourceLicense.Text = "Volume";
            else
            {
                lbSourceLicense.Text = "-"; // lbIMGLicense.Text = "ERROR";
                _message = txtStatus.Text = "Unable to detect source license type.";
                //MessageBox.Show(_message, "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //return;
            }
            //---License END-----------------------------------------

            //---Service Pack----------------------------------------
            if (Directory.GetFiles(path, "*.sp3").Length.ToString(CultureInfo.InvariantCulture) != "0")
                lbSourceSP.Text = "3";
            else if (Directory.GetFiles(path, "*.sp2").Length.ToString(CultureInfo.InvariantCulture) != "0")
                lbSourceSP.Text = "2";
            else if (Directory.GetFiles(path, "*.sp1").Length.ToString(CultureInfo.InvariantCulture) != "0")
                lbSourceSP.Text = "1";
            else
                lbSourceSP.Text = "0";
            //---Service Pack END------------------------------------

            //---OS--------------------------------------------------
            fileinuse = Path.Combine(fullpath, "LAYOUT.INF");
            if (!CheckFile(fileinuse, false))
                return;

            file = new StreamReader(fileinuse);
            while ((line = file.ReadLine()) != null)
                if (line.ToLower().StartsWith("productname ="))
                    break;
            file.Close();

            if (line != null)
                line = line.Replace("productname =", "").Trim();

            if (line != null && line.ToLower().Contains("windows xp"))
                lbSourceOS.Text = "Windows XP";
            else
            {
                lbSourceLicense.Text = "ERROR";
                _message = txtStatus.Text = "Unable to detect source os.";
                MessageBox.Show(_message, "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //---OS END----------------------------------------------

            //---Edition---------------------------------------------
            if (line.ToLower().Contains("pro"))
                lbSourceEdition.Text = "Professional";
            else if (line.ToLower().Contains("home"))
                lbSourceEdition.Text = "Home";
            else
            {
                lbSourceLicense.Text = "ERROR";
                _message = txtStatus.Text = "Unable to detect source edition.";
                MessageBox.Show(_message, "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //---Edition END------------------------------------

            // Checks to see if source is matches target
            if (!MatchTarget())
                return;
            if (type == "drive")
            {
                // Did the files not copy correctly?
                if (!CopyFiles(type))
                    return;
                // Do we need to slipstream
                if (_slipstream != null)
                    // Did we do it correctly?
                    if (SlipStream(_slipstream))
                        //If so, reload the the source, to make sure the update has taken effect
                        LoadSource("slipstream", _source);
                    else
                        // No, so stop
                        return;
            }
             _source = path;
        }

        private void FrmMainLoad(object sender, EventArgs e)
        {
            // Check external apps
            CheckFile(Path.Combine(Application.StartupPath, SevenZipDll), true); // Need to use "full path" to check file exists.
            CheckFile(Path.Combine(Application.StartupPath, SevenZipExe), true);
            CheckFile(Path.Combine(Application.StartupPath, MkisofsDll), true);
            CheckFile(Path.Combine(Application.StartupPath, MkisofsExe), true);
            CheckFile(Path.Combine(Application.StartupPath, GetEltorito), true);
            CheckFile(Path.Combine(Application.StartupPath, CmdLines), true);
            CheckFile(Path.Combine(Application.StartupPath, RunOnceExe), true);
            CheckFile(Path.Combine(Application.StartupPath, WinNTSif), true);

            // Readme button
            Readme.Enabled = File.Exists(ReadmeTxt);
            if (!Readme.Enabled)
                Readme.Text = "no README file";

            // Set default values
            txtKey.Text = "AAAAABBBBBCCCCCDDDDDEEEEE";

            // Run default functions
            ResetSource();
            ReadXml();
            MatchTarget();
            ScanCD();
        }

        private void KeyEnterLeave(object sender, EventArgs e)
        {
            if (txtKey.Text == "")
                txtKey.Text = "AAAAABBBBBCCCCCDDDDDEEEEE";
            else if (txtKey.Text == "AAAAABBBBBCCCCCDDDDDEEEEE")
                txtKey.Text = "";
            AllowGen();
        }

        private void Key_Press(object sender, KeyPressEventArgs e)
        {
            // Prevents ' ', 0, 1, a, e, i, l, n, o, s, u, z from being entered
            if (e.KeyChar == ' ' ||
                e.KeyChar == '0' ||
                e.KeyChar == '1' ||
                e.KeyChar == 'a' ||
                e.KeyChar == 'e' ||
                e.KeyChar == 'i' ||
                e.KeyChar == 'l' ||
                e.KeyChar == 'n' ||
                e.KeyChar == 'o' ||
                e.KeyChar == 's' ||
                e.KeyChar == 'u' ||
                e.KeyChar == 'z')
                e.KeyChar = (char)0;
        }

        private void GenerateClick(object sender, EventArgs e)
        {
            // Ask where to save
            var saveDialog = new SaveFileDialog
            {
                Filter = "Image File (*.iso)|*.iso",
                Title = "Save the Image File",
                OverwritePrompt = true,
                FileName = _targetName,
            };
            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;
            string destination = saveDialog.FileName;
            txtStatus.Text = String.Format("Saving to '{0}'", destination);

            // Copy Unattended files
            string oem = Path.Combine(_destination,"$OEM$");
            if (Directory.Exists(oem))
                Directory.Delete(oem, true);
            Directory.CreateDirectory(oem);
            File.Copy(CmdLines, Path.Combine(oem, Path.GetFileName(CmdLines)), true);
            File.Copy(RunOnceExe, Path.Combine(oem, Path.GetFileName(RunOnceExe)), true);
            File.Copy(_targetSetup, Path.Combine(oem, "setup.exe"), true);

            var newFile = new StringBuilder();
            string[] file = File.ReadAllLines(WinNTSif);
            foreach (string line in file)
            {
                if (line.StartsWith("ProductKey="))
                    newFile.Append(string.Format("ProductKey=\"{0}\"\r\n", Regex.Replace(txtKey.Text, ".{5}", "$0-").TrimEnd('-').ToUpper()));
                else if (line.StartsWith("ComputerName="))
                    newFile.Append(string.Format("ComputerName={0}\r\n", _targetName.ToUpper()));
                else if (line.StartsWith("FullName="))
                    newFile.Append(string.Format("FullName=\"{0}\"\r\n", _targetName.ToUpper()));
                else if (line.StartsWith("OrgName="))
                    newFile.Append("OrgName=\"VulnInjector\"\r\n");
                else
                    newFile.Append(string.Format("{0}\r\n", line));
            }

            string fileout;
            if (Directory.Exists(Path.Combine(_destination, "AMD64")))
                fileout = Path.Combine(_destination, "AMD64");
            else if (Directory.Exists(Path.Combine(_destination, "I386")))
                fileout = Path.Combine(_destination, "I386");
            else
            {
                MessageBox.Show("Failed to find setup folder for: 'winnt.sif'.\n\nHalting...", "Error || VulnInjector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            fileout = Path.Combine(fileout, "WINNT.SIF");
            File.WriteAllText(fileout, newFile.ToString());
            File.WriteAllText(Path.Combine(_destination, "VulnInjector.txt"), "Warning: This is a PERSONAL modified Windows installation image. It has been designed ON PURPOSE to have known VULNERABILITIES once installed.\r\n\r\nUse ONLY in a 'safe' isolated environment.\r\n\r\nUse at your own risk.");

            Generate.Enabled = false;
            // Start thread to create ISO
            var t = new Thread(() => ThreadCreate(destination));
            t.Start();
            while (t.IsAlive)
                Application.DoEvents();
            Generate.Enabled = true;
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // File -> Exit
            Application.Exit();
        }

        private void HelpToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Help -> Help
            new FAQ().Show();
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Help -> About
            new AboutBox().Show();
        }

        private void RescanToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Refresh the CD/DVD drive
            ScanCD();
        }

        private void OpenImageFileToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open the ISO file
            var openDialog = new OpenFileDialog
            {
                Filter = "Image files (*.iso,*.img)|*.iso;*.img|All files (*.*)|*.*",
                Title = "Select an image file",
            };
            if (openDialog.ShowDialog() != DialogResult.OK)
                return;
            LoadSource("iso", openDialog.FileName);
        }

        private void DriveIsoClick(object sender, EventArgs e)
        {
            // Display the drop down menu under the button
            var btnSender = (Button)sender;
            var ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            DriveISOMenu.Show(ptLowerLeft);
        }

        private void DriveIsoMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DriveISOMenu.Hide();
            // Drop down menu from ISO
            // All known values have a 'tag' value. All detected CD/DVD drive will not.
            if (e.ClickedItem.Tag == null)
                LoadSource("drive", e.ClickedItem.Text);
        }

        private void KeyTextChanged(object sender, EventArgs e)
        {
            // Check to see if btnGen should be enabled
            AllowGen();
        }

        private void ReadmeClick(object sender, EventArgs e)
        {
            // Open the readme with the default program set on the OS
            Process.Start(ReadmeTxt);
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop the copy thread
            _copied = true;

            // Ask to clean up
            if (_destination != null && Directory.Exists(_destination))
            {
                DialogResult dialogResult = MessageBox.Show(this,
                    "Do you wish to remove any 'temp' files?",
                    "Clean up || VulnInjector",
                    MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Clean up
                    var t = new Thread(() => ThreadDelete());
                    t.Start();
                    while (t.IsAlive)
                        Application.DoEvents();
                }

                // Still quit
                e.Cancel = false;
            }
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            // If the window is in focus, check to see if a productkey is on the clipboard
            ClipboardKey();
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Help -> WebSite
            Process.Start("http://vulnhub.com");
        }

    }
}
