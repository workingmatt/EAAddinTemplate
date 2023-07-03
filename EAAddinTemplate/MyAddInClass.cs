using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAAddinTemplate
{
    public class MyAddInClass
    {
        const string menuHeader = "-&MyAddin";
        const string menuHello = "&SayHello";
        const string menuGoodbye = "&SayGoodbye";

        private bool shouldWeSayHello = true;

        public String EA_Connect(EA.Repository Repository)
        {
            return "a string";
        }

        public object EA_GetMenuItems(EA.Repository Repository, string Location, string MenuName)
        {
            switch(MenuName)
            {
                case "":
                    return menuHeader;
                case menuHeader:
                    string[] subMenus = { menuHello, menuGoodbye };
                    return subMenus;
            }
            return "";
        }

        bool IsProjectOpen(EA.Repository Repository)
        {
            try
            {
                EA.Collection c = Repository.Models;
                return true;
            } catch
            {
                return false;
            }
        }

        public void EA_GetMenuState(EA.Repository Repository, string Location, string MenuName, string ItemName, ref bool IsEnabled, ref bool IsChecked)
        { 
            if(IsProjectOpen(Repository))
            {
                switch(ItemName)
                {
                    case menuHello:
                        IsEnabled = shouldWeSayHello; break;
                    case menuGoodbye:
                        IsEnabled = !shouldWeSayHello; break;
                    default:
                        IsEnabled=false; break;
                }
            }
            else
            {
                IsEnabled = false;
            }
        }

        public void EA_MenuClick(EA.Repository Repository, string Location, string MenuName, string ItemName)
        {
            switch (ItemName)
            {
                case menuHello:
                    this.sayHello(); break;
                case menuGoodbye:
                    this.sayGoodbye(); break;
            }
        }

        private void sayHello()
        {
            MessageBox.Show("Hello World");
            this.shouldWeSayHello = false;
        }

        private void sayGoodbye()
        {
            MessageBox.Show("Goodbye World");
            this.shouldWeSayHello=true;
        }

        public void EA_Disconnect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
