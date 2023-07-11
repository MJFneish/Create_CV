using System.ComponentModel.DataAnnotations;

namespace cv_web_application.Models
{
    public class VerficationNumber
    {
        private static Random random = new Random();
        public int Nbr1 { get; set; } = random.Next(1, 100);
        public int Nbr2 { get; set; } = random.Next(1, 100);
        public int Nbr3 { get; set; } = 0;
    }
}
