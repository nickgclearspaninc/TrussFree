using UnitClassLibrary;

namespace ComponentFileReader.LumberClass
{
    public partial class Lumber
    {
        public static Lumber LumberWithInches(double width, double height, double length)
        {
            return new Lumber(new Distance(DistanceType.Inch, width), new Distance(DistanceType.Inch, height), new Distance(DistanceType.Inch, height));
        }

        public static Lumber LumberWithNominalArchitectualStrings(string passedArchitecturalHeight, string passedArchitecturalWidth, string passedArchitecturalLength, string passedGrade = "", string passedSpecies = "", string passedTreatmentType = "", string passedMill = "", string passedBundle = "", string passedOther = "")
        {
            return new Lumber(new Distance(DistanceType.Inch, ConvertNominalInchesToActual(new Distance(passedArchitecturalHeight).Inches)),
                new Distance(DistanceType.Inch, ConvertNominalInchesToActual(new Distance(passedArchitecturalWidth).Inches)),
                new Distance(DistanceType.Inch, ConvertNominalInchesToActual(new Distance(passedArchitecturalLength).Inches)),
                passedGrade, passedSpecies, passedTreatmentType,
                passedMill, passedBundle, passedOther);
        }
    }
}