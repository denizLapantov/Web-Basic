namespace SoftUniStore.Models.ViewModels
{
    public class AllGamesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            string templete = "<div class=\"card col-4 thumbnail\">\r\n " +
                              $"<img class=\"card-image-top img-fluid img-thumbnail\" src=\"{this.ImageUrl}\">\r\n " +
                              "<div class=\"card-block\">\r\n " +
                              $"<h4 class=\"card-title\">{this.Title}</h4>\r\n "+
                              $"<p class=\"card-text\"><strong>Price</strong> - {this.Price}</p>\r\n  " +
                              $"<p class=\"card-text\"><strong>Size</strong> - {this.Size}</p>\r\n " +
                              $"<p class=\"card-text\">{this.Description}</p>\r\n " +
                              "</div>\r\n<div class=\"card-footer\">\r\n  " +
                             $"<a class=\"card-button btn btn-outline-primary\" name=\"info\" href=\"/home/details?Id={this.Id}\">Info</a>\r\n</div>\r\n</div>";

            return templete;
        }
    }
}
