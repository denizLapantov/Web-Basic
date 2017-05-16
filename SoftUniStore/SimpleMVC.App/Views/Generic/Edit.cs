using System.IO;
using System.Text;
using SimpleMVC.App.Contracts;
using SimpleMVC.Interfaces;
using SoftUniStore.Models.ViewModels;

namespace SimpleMVC.App.Views.Generic
{
    public class Edit :IRenderable
    {
        public string Render()
        {
            StringBuilder htmlText = new StringBuilder();
            htmlText.Append(File.ReadAllText(HtmlReader.Header));
            htmlText.Append(File.ReadAllText(HtmlReader.MenuLogged));
            htmlText.Append(File.ReadAllText(HtmlReader.EditGame));
            htmlText.Append(File.ReadAllText(HtmlReader.Footer));

            return htmlText.ToString();
        }

        public AllEditVm Model { get; set; }
    }
}
