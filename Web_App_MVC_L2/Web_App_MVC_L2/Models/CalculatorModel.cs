namespace Web_App_MVC_L2.Models
{
    public class CalculatorModel
    {
        public double Number1 { get; set; }
        public double Number2 { get; set; }
        public double? Result { get; set; }
        public string? Operation { get; set; }

        public void Calculate()
        {
            switch (Operation)
            {
                case "Add":
                    Result = Number1 + Number2;
                    break;
                case "Substract":
                    Result = Number1 - Number2;
                    break;
                case "Multiply":
                    Result = Number1 * Number2;
                    break;
                case "Divide":
                    Result = Number2 != 0 ? Number1 / Number2 : double.NaN;
                    break;
                default:
                    Result = 0;
                    break;
            }
        }
    }
}
