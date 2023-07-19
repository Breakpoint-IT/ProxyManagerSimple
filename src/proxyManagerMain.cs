using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Win32;

namespace test
{
    public partial class proxyManagerMain : Form
    {
        public proxyManagerMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Prosy Status - label

            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            int proxyStatus = (int)registry.GetValue("ProxyEnable");
            if (proxyStatus == 0)
                lblProxyStatus.Text = "inaktiv ";
            if (proxyStatus == 1)
                lblProxyStatus.Text = " aktiv";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //////////////////////
            /// disable Proxy ///
            /////////////////////
            
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);   
            registry.SetValue("ProxyServer", "");
            registry.SetValue("ProxyEnable", 0);
            registry.SetValue("ProxyOverride", "");

            //Proxy Status - label

            int proxyStatus = (int)registry.GetValue("ProxyEnable");
            if (proxyStatus == 0)
                lblProxyStatus.Text = "inaktiv ";
            if (proxyStatus == 1)
                lblProxyStatus.Text = " aktiv";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //////////////////////
            /// activate Proxy ///
            /////////////////////
            
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);         
            registry.SetValue("ProxyServer", "10.244.8.240:3128");
            registry.SetValue("ProxyEnable", 1);
            registry.SetValue("ProxyOverride", "10.*;*.kvnbw.de;*.iteos.net;dcserver*;*.kaisersbach.int;*komm.one;0.de.pool.ntp.org;1.de.pool.ntp.org;2.de.pool.ntp.org;3.de.pool.ntp.org;*.local.pcvisit.com;*.komm-one.net");

            //Proxy Status - label

            int proxyStatus = (int)registry.GetValue("ProxyEnable");
            if (proxyStatus == 0)
                lblProxyStatus.Text = "inaktiv ";
            if (proxyStatus == 1)
                lblProxyStatus.Text = " aktiv";
        }

        private void lblProxyStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
