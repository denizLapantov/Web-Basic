namespace SoftUniStore.Models.ViewModels
{
    public class GenericAdminVm
    {
        public string Name { get; set; }

        public string Size { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            string templete = "<tr>\r\n" +
                              $"<td>{this.Name}\r\n" +
                              $"<td>{this.Size}</td>\r\n" +
                              $"<td>{this.Price}</td>\r\n" +
                              "<td>\r\n" +
                              "<a href=\"generic/edit\" class=\"btn btn-warning btn-sm\">Edit</a>\r\n" +
                              "<a href=\"generic/delete\" class=\"btn btn-danger btn-sm\">Delete</a>\r\n" +
                              "</td>\r\n" +
                              "</tr>";

            return templete;
        }
    }
}
