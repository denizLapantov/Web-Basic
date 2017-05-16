using System;

namespace SoftUniStore.Models.BindingModels
{
    public  class EditNewGameBm
    {
        public int OldId { get; set; }

        public string OldTitle { get; set; }

        public string OldYouTubeId { get; set; }

        public string OldImageUrl { get; set; }

        public string OldSize { get; set; }

        public decimal OldPrice { get; set; }

        public string OldDescription { get; set; }

        public DateTime? OldReleaseDate { get; set; }
    }
}
