using System;
using System.Collections.Generic;

namespace NatCat.Platform.Data.Entities
{
    public class Story
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public IEnumerable<StoryPart> StoryParts { get; set; }

        public float AverageRating { get; set; }
    }
}
