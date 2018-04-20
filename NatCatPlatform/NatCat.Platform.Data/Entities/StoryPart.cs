using System;
using System.Collections.Generic;
using System.Text;

namespace NatCat.Platform.Data.Entities
{
    public class StoryPart
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public Story Story { get; set; }
    }
}
