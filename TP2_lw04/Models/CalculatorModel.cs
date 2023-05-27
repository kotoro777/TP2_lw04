using System.ComponentModel.DataAnnotations;

namespace TP2_lw04.Models
{
    public class CalculatorModel
    {
        [Required(ErrorMessage = "Operand1 is required.")]
        public short Operand1 { get; set; }
        [Range(0, 100, ErrorMessage = "Operand2 must must be in the range from 0 to 100")]
        public short Operand2 { get; set; }
        public string Operation { get; set; }
        public double Result { get; set; }
    }
}
