using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APBD_TASK2.Models;

namespace APBD_Task2.Models

{
    public class Laptop : Equipment
    {
        public int RamGb { get; set; }
        public int ScreenSize { get; set; }

        public Laptop(string name, int ram, int screen, decimal dailyRentalPrice) : base(name, dailyRentalPrice)
        {
            RamGb = ram;
            ScreenSize = screen;
        }
    }
}