﻿namespace Sk8M8_API.Models
{
    public class MediaRating : BaseEntity
    {
        public Media Media { get; set; }
        public Client Client { get; set; }
        public int Rating { get; set; }
    }
}
