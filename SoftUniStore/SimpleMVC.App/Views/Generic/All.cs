using System.IO;
using System.Text;
using SimpleMVC.App.Contracts;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.Models.ViewModels;

namespace SimpleMVC.App.Views.Generic
{
    public class All:IRenderable<GenericVm>
    {
        public string Render()
        {
            StringBuilder htmlText = new StringBuilder();
            htmlText.Append(File.ReadAllText(HtmlReader.Header));
            htmlText.Append(File.ReadAllText(HtmlReader.MenuLogged));
            StringBuilder content = new StringBuilder();
            foreach (var m in Model.Generic)
            {
                content.Append(m.ToString());
            }

            htmlText.Append(File.ReadAllText(HtmlReader.AdminGames).Replace("##games##", content.ToString()));
            htmlText.Append(File.ReadAllText(HtmlReader.Footer));

            return htmlText.ToString();
        }

        public GenericVm Model { get; set; }
    }
}
