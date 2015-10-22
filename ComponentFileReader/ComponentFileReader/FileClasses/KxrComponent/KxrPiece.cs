using System.Collections.Generic;

namespace ComponentFileReader.FileClasses.KxrComponent
{
    public partial class KxrComponent
    {
        public class KxrPiece
        {
            public string Label;
            public string Type;

            public string PieceLengthShortSide;
            public string PieceLengthLongSide;
            public string PieceLengthCenterLine;
            public string PieceLengthOverall;
            public string PieceLengthCorner2Corner;
            public string PieceLengthPiecePick;

            public string MaterialText;
            public string MaterialSpecies;
            public string MaterialGrade;
            public string MaterialNominlThickness;
            public string MaterialNominalWidth;
            public string MaterialTreatment;

            public string LeftEndBevelType;
            public string LeftEndBevelAngle;
            public string RightEndBevelType;
            public string RightEndBevelAngle;

            public string Vertical;

            public List<KxrPoint> Points = new List<KxrPoint>();
        }
    }
}
