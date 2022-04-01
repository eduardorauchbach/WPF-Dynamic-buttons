using System;
using System.Collections.Generic;
using System.Text;

namespace FromZero.Desktop.Domain.Models
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IconIndex { get; set; }

        public MenuItem(string title, string description, int iconIndex)
        {
            Title = title;
            Description = description;
            IconIndex = iconIndex;
        }
    }
}
