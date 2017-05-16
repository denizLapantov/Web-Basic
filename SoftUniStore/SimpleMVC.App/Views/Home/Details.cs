using System.IO;
using System.Text;
using SimpleMVC.App.Contracts;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.Models.ViewModels;

namespace SimpleMVC.App.Views.Home
{
    public class Details : IRenderable<DetailsVm>
    {
        public string Render()
        {
            StringBuilder htmlText = new StringBuilder();
            htmlText.Append(File.ReadAllText(HtmlReader.Header));
            htmlText.Append(File.ReadAllText(HtmlReader.MenuLogged));
            StringBuilder content = new StringBuilder();
            foreach (var m in Model.DetailsGameVms)
            {
                content.Append(m.ToString());
            }

            htmlText.Append(File.ReadAllText(HtmlReader.Details).Replace("##categories##", content.ToString()));
            htmlText.Append(File.ReadAllText(HtmlReader.Footer));

            return htmlText.ToString();
        }

        public DetailsVm Model { get; set; }
    }
}
