﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGoogleYoutubeV3.Model
{
    public class Video
    {
        
        public string Id { get; set; }
        public string Title { get; set; }
        public string Img {get; set;}
        public string Descriptiong { get; set; }
        public DateTime? PubDate { get; set; }

    }
}
