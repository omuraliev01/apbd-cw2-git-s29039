using APBD_Task2.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_Task2.Models

{
    public class Laptop : Equipment
    {
        public int RamGb { get; set; }
        public int ScreenSize { get; set; }

        public Laptop(string namem, int ram, int screen) : base(name, dailyRentalPrice)
        {
            RamGb = ram;
            ScreenSize = screen;
        }
    }
}