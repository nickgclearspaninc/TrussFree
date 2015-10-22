using System.Collections.Generic;

namespace ComponentFileReader.FileClasses.KxrComponent
{
    public partial class KxrComponent
    {
        public class KxrPlate
        {
            public string Label;
            public string Width;
            public string Length;
            public string Gauge;
            public string Angle;
            public string JointNo;
            public string SplicePlate;
            public string Type;

            public List<KxrPoint> Points = new List<KxrPoint>();
        }
    }
}
