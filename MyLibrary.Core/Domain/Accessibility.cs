using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Core.Domain
{
    public class Accessibility
    {
        public int Id { get; set; }
        public enum Type
        {
            Available,
            Borrowed
        }
        public Library Library { get; set; }
    }
}
