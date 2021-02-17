using CallingAPIFromMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallingAPIFromMVC.Models
{
    public class Teacher : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }
    }
}
