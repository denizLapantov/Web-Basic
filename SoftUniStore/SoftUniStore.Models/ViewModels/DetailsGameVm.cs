using System;

namespace SoftUniStore.Models.ViewModels
{
    public class DetailsGameVm
    {
        public string Title { get; set; }
        public string YouTubeId { get; set; }

        public string Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public override string ToString()
        {
            string templete =$"<h1 class=\"display-3\">{this.Title}</h1>\r\n" +
                             $"<br/>\r\n" +
                             $"<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/{this.YouTubeId}\" frameborder=\"0\" allowfullscreen></iframe>\r\n" +
                             $"<br/>\r\n" +
                             $"<br/>\r\n" +
                             $"<p>tem</p>\r\n" +
                             $"<p><strong>Price</strong> - {this.Price}</p>\r\n" +
                             $"<p><strong>Size</strong> - {this.Size}</p>\r\n" +
                             $"<p><strong>Release Date</strong> - {this.ReleaseDate}</p>\r\n" +
                             $"<a class=\"btn btn-outline-primary\" name=\"back\" href=\"home/index\">Back</a>";
                
            return templete;
        }
    }

    
}
