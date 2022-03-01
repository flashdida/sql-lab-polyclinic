using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Lab_Polyclinic {
  public class Appointment {
    public int Id { get; set; }
    public int Doctor { get; set; }
    public int Patient { get; set; }
    public int Disease { get; set; }
    public DateTime Date { get; set; }
    public string Representation { get; set; }
    
  }
}
