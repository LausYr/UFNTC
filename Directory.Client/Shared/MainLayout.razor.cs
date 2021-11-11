using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Lists;
using Syncfusion.Blazor.Navigations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.Client.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        SfSidebar Sidebar;
        SfListView<listData> ControlList;
        public bool SidebarToggle = false;
        public void Toggle(ClickEventArgs args)
        {
            if (args.Item.TooltipText == "Menu")
            {
                SidebarToggle = !SidebarToggle;
            }
        }
        public List<listData> List = new List<listData>
{
        new listData {Id="1", Text = "Организации", IconCss = "glyphicon glyphicon-th"},
        new listData {Id="2",Text = "Сотрудники", IconCss = "glyphicon glyphicon-th" },

    };
        public class listData
        {
            public string Id { get; set; }
            public string Text { get; set; }
            public string IconCss { get; set; }

        }
        private void OnSelect(ClickEventArgs<listData> args)
        {
            switch (args.ItemData.Id)
            {
                case "1" : NavigationManager.NavigateTo("OrganizationGrid");
                    break;
                case "2":
                    NavigationManager.NavigateTo("EmployeeGrid");
                    break;
            }
        }
        Dictionary<string, object> HtmlAttribute = new Dictionary<string, object>()
{
        {"class", "dockSidebar" }
    };

    }
}