using System.IO;
using System.Text;
using SimpleMVC.App.Contracts;
using SimpleMVC.Interfaces;

namespace SimpleMVC.App.Views.Generic
{
    public class Delete : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlText = new StringBuilder();
            htmlText.Append(File.ReadAllText(HtmlReader.Header));
            htmlText.Append(File.ReadAllText(HtmlReader.MenuLogged));
            htmlText.Append(File.ReadAllText(HtmlReader.DeleteGame));
            htmlText.Append(File.ReadAllText(HtmlReader.Footer));

            return htmlText.ToString();
        }
    }
}
