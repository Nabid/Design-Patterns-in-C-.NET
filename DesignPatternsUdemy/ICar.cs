namespace DesignPatternsUdemy
{
    public interface ICar
    {
        CarStepwiseBuilder.CarType CarType { get; set; }
        int WheelSize { get; set; }

        string ToString();
    }
}