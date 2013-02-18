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
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace VulnInjector
{
    public partial class FAQ : Form
    {
        public FAQ()
        {
            InitializeComponent();
            textBox.Text = "\t\t\t\t\t*** Use YOUR OWN setup disk & product key. ***\r\n";
            textBox.Text += "\t\t\t*** Use a clean source (e.g. no modifications and/or existing unattended installations). ***\r\n\r";
            textBox.Text += "*** This creates a PERSONAL modified Windows installation image. It has been designed ON PURPOSE to have known VULNERABILITIES once installed. ***\r\n\r";
            textBox.Text += "\t\t\t\t\t*** Use ONLY in a 'safe' isolated environment. ***\r\n\r\n\r\n";
            textBox.Text += "Q.) Does this alter my existing ISO file?\r\n";
            textBox.Text += "A.) No. This extracts the selected ISO file and then repackages it into a new file. This leaves the existing image untouched.\r\n\r\n\r\n";
            textBox.Text += "Q.) Why can't I use a USB stick/existing folder as a source?\r\n";
            textBox.Text += "A.) This is because VulnInjector is unable to extract the boot image which is required.\r\n\r\n\r\n";
            textBox.Text += "Q.) Why does this need my product key?\r\n";
            textBox.Text += "A.) This is to automate the Windows setup process, allowing for zero interaction during the setup. Load up the image into a new Virtual Machine, wait 20-30 minutes and it should all be done (without you pressing a button)!\r\nThe key is saved to an \"answered\" file on the CD. Nothing else.\r\n\r\n\r\n";
            textBox.Text += "Q.) I don't have the right source files / I only have a higher service pack version!\r\n";
            textBox.Text += "A.) The author designed the vulnerabilities in a specific version of Windows, so you will likely encounter these errors with:\r\n* Earlier service packs: The vulnerabilities targeted may not exist or the vital features may be missing.\r\n* Newer service packs:  The vulnerabilities may have been patched.\r\n* Different edition of Windows. Some editions may have 'everything' (such as ultimate), however they may also have different memory addresses, which will cause the exploit to fail.\r\n\r\nSolutions:\r\nIf you have an earlier service pack, you're able to upgrade to the required service pack, then this will work.\r\nVulnInjector can automatically integrate (aka SlipStream) to the required service pack. However, you need to supply the stand alone setup files. For example:\r\nXP SP2: http://technet.microsoft.com/windows/windows-xp-service-pack-2.aspx\r\nXP SP3: http://technet.microsoft.com/windows/windows-xp-service-pack-3.aspx.\r\n\r\nTo make it more accessible, other versions/editions may be used. However, they have limited support and may perform unexpected.\r\nFor ease of use, we highly recommend trying to get a close as match possible.\r\n\r\n\r\n";
            textBox.Text += "Q.) Why do we need a temporary folder?\r\n";
            textBox.Text += "A.) This is the location which will extract the Windows setup, allowing for VulnInjector to repackage the CD to create the target. The chosen location needs to have a little more free disk space than the size of the source used. The user that executed VulnInjector needs to be able to write to that location also.\r\n\r\n\r\n";
            textBox.Text += "Q.) What do I do with the ISO after it has been created?\r\n";
            textBox.Text += "A.) Start to install Windows as you normally would using the new image file, wait for it to install and then try to break into the new target!\r\nWe recommend using a new virtual machine for each new target.\r\n\r\n\r\n";
            textBox.Text += "Q.) Do I have to re-install Windows again? I've already got a Windows VM ready.\r\n";
            textBox.Text += "A.) The setup file has been designed to run during the Windows setup stage. It will automate all the necessary modifications and configurations to a 'fresh' VM.\r\nIf you use an existing Virtual Machine you may have made modifications (either knowing or un-knowingly) to the system which hasn't been taken into consideration, thus, there could be additional vulnerabilities which were not designed for this target, making it 'easier'.\r\n\r\n\r\n";
            textBox.Text += "Q.) Do I have to use a Virtual Machine?\r\n";
            textBox.Text += "A.) No. However, we do recommend it.\r\nIf you use a real machine, the hardware may not be supported without additional device drivers. To install them, you need access to the system. However, as the aim of this target is to start with nothing and then gain as highest level of access possible, you first need to break into it to be able to install the drivers!\r\nDepending on the virtualization software, it may support \"snapshots\". This has the advantage of restoring to a known state, which is useful if you made a mistake and quickly want to recover.";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWWW_Click(object sender, EventArgs e)
        {
            Process.Start("http://vulnhub.com");
        }

    }
}
