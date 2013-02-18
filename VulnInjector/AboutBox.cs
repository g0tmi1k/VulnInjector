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
using System.Reflection;
using System.Windows.Forms;

namespace VulnInjector
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            Text = String.Format("About {0} & Legal information", AssemblyTitle);
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            labelCopyright.Text = AssemblyCopyright;
            labelCompanyName.Text = AssemblyCompany;
            textBoxDescription.Text = "LEGAL AGREEMENT:\r\n"; //AssemblyDescription;
            textBoxDescription.Text += "Your use of VulnInjector is governed by the following conditions. Please read this information carefully before using VulnInjector.\r\n\r\n";
            textBoxDescription.Text += "By using it you are agreeing to the following conditions:\r\n";
            textBoxDescription.Text += "* VulnInjector is OpenSource and released under the 'GNU General Public License, version 3'. See './LICENSE.txt'.\r\n";
            textBoxDescription.Text += "* VulnInjector is supplied 'as-is'. The author assumes no liability for damages, direct or consequential, which may result from the use of VulnInjector.\r\n";
            textBoxDescription.Text += "* You accept the operating system's EULA as well as anything 3rd party applications which are installed along with it.\r\n";
            textBoxDescription.Text += "* International users need to check for any import restrictions that your government may impose.\r\n\r\n\r\n\r\n";
            textBoxDescription.Text += "LICENSES:\r\n";
            textBoxDescription.Text += "VulnInjector created by g0tmi1k under the GNU GPL license.\r\n";
            textBoxDescription.Text += "Special thanks to Matt \"hostess\" Andreko for the valuable help.\r\n\r\n";
            textBoxDescription.Text += "geteltorito provided by Olof Lagerkvist under the MIT license.\r\n\r\n";
            textBoxDescription.Text += "7-zip provided by Igor Pavlov under the GNU LGPL license.\r\n\r\n";
            textBoxDescription.Text += "mkisofs provided by Joerg Schilling & Ross Smithii under the GNU GPL license.\r\n\r\n";
            textBoxDescription.Text += "Cygwin provided by Cygwin™ under the GNU GPL license.\r\n\r\n";
            textBoxDescription.Text += "A copy of the license for each application mentioned above can be found in the following location: './bin/<name>_license.txt'.\r\n\r\n\r\n\r\n";
            textBoxDescription.Text += "TRADEMARKS:\r\n";
            textBoxDescription.Text += "Windows and Windows XP are a registered trademarks of Microsoft Corporation in the United States and other countries. All Rights Reserved.\r\n\r\n";
            textBoxDescription.Text += "Cygwin is a registered trademarks of Red Hat, Inc. All Rights Reserved.\r\n\r\n";
            textBoxDescription.Text += "All other trademarks and trade names are properties of their respective owners. All Rights Reserved."; 
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {

        }

    }
}

