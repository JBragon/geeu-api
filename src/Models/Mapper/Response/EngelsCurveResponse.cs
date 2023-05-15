using Models.Enums;

namespace Models.Mapper.Response
{
    public class EngelsCurveResponse
    {
        public int Id { get; set; }
        public double Income { get; set; }
        public double Amount { get; set; }
        public double AngularCoefficient { get; set; }
        public ProductClassification Classification { get; set; }
    }
}
