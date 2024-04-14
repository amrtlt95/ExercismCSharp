using System;
using System.Globalization;

class WeighingMachine
{
    private double _weight;
    public int Precision { get; }
    public double TareAdjustment { get; set; } = 5;

    public double Weight { 
        get { return _weight; }
        set {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Weight","Weight cannot be negative.");
            _weight = value;
                }
    }

    public string DisplayWeight { 
        get {
            var format = new NumberFormatInfo() { NumberDecimalDigits = Precision };
            var formattedString = (Weight - TareAdjustment).ToString("f", format);
            return $"{formattedString} kg";
        }
    }

public WeighingMachine(int precision)
{
    Precision = precision;
}

}