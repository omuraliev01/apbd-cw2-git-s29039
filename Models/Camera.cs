using APBD_Task2.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace APBD_Task2.Models;

public class Camera : Equipment
{
    public double Megapixels { get; set; }
    public bool HasLensIncluded { get; set; }

    public Camera(string name, decimal dailyRentalPrice, double megapixels, bool hasLensIncluded) 
        : base(name, dailyRentalPrice)
    {
        Megapixels = megapixels;
        HasLensIncluded = hasLensIncluded;
    }
}