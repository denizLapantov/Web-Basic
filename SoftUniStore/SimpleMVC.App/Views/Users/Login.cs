using System.IO;
using System.Text;
using SimpleMVC.App.Contracts;
using SimpleMVC.Interfaces;

namespace SimpleMVC.App.Views.Users
{
    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlText = new StringBuilder();
            htmlText.Append(File.ReadAllText(HtmlReader.Header));
            htmlText.Append(File.ReadAllText(HtmlReader.NavNotLogg));
            htmlText.Append(File.ReadAllText(HtmlReader.Login));
            htmlText.Append(File.ReadAllText(HtmlReader.Footer));

            return htmlText.ToString();
        }
    }
}
