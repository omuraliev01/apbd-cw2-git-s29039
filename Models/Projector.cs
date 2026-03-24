using APBD_Task2.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace APBD_Task2.Models;

public class Projector : Equipment
{
    public string Resolution { get; set; }
    public int Lumens { get; set; }

    public Projector(string name, decimal dailyRentalPrice, string resolution, int lumens) 
        : base(name, dailyRentalPrice)
    {
        Resolution = resolution;
        Lumens = lumens;
    }
}