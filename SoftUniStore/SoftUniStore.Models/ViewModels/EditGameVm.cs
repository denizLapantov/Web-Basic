﻿using System;

namespace SoftUniStore.Models.ViewModels
{
    public class EditGameVm
    {
        public string Title { get; set; }

        public string YouTubeId { get; set; }

        public string ImageUrl { get; set; }

        public string Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

      
    }
}
