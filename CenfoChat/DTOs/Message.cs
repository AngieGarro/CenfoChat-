using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Message : BaseDTO
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }

        public int WordNumbers { get; set; }
    }
}
