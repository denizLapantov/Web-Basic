using System.Collections.Generic;
using System.Text;

namespace SoftUniStore.Models.ViewModels
{
    public class DetailsVm
    {
        public IEnumerable<DetailsGameVm> DetailsGameVms { get; set; }

        public override string ToString()
        {
          StringBuilder stringBuilder = new StringBuilder();

            foreach (var detailsGameVm in DetailsGameVms)
            {
                stringBuilder.Append(detailsGameVm);
            }

            return stringBuilder.ToString();
        }
    }
}
