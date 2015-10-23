using System.Collections.Generic;

namespace ComponentFileReader.FileClasses.TreComponent
{
    public partial class TreComponent
    {
        public class TreMember
        {
            // Represent data from a line like this (see also line 28 in MiTek's documentation file for the TRE file format):
            // 4 0
            public string OriginalLumberIndex;
            public string GableStudFlag;

            // Represent data from a line like this (see also line 31 in MiTek's documentation file for the TRE file format):
            // 2x4,No.2,SP, 0.00, 0.00,  0.0000,  0.0000,  0.0000,  0.0000,2,RH,1, 0.00,0,0,0
            public string MemberSize;
            public string MemberGrade;
            public string MemberSpecies;
            public string MemberThickness;
            public string MemberWidth;
            public string MemberShortLength;
            public string MemberCenterLength;
            public string MemberLongLength;
            public string MemberOverallLength;
            public string PointsOnMember;
            public string MemberLabel;
            public string PointsOnLeftEndOfMember;
            public string MemberStockLength;
            public string MemberCost;

            // Represent data from a line like this (see also line 32 in MiTek's documentation file for the TRE file format):
            //   0.000,  0.271,  0.000,  4.063,116.813, 52.734,116.813, 48.943
            public List<TrePoint> MemberPointCoordinates;

            // Represent data from a line like this (see also line 33 in MiTek's documentation file for the TRE file format):
            // 0 0 0.000000 0.000000
            public enum BevelType { None, Single, Double, IgnoreBevel } // The indices of the bevel types in this enum align with the valid options for the right/left bevel types per the TRE file format documentation. So if rightBevelType is set to 1, the enum knows it is aliased as Single.
            public BevelType leftBevelType;
            public BevelType rightBevelType;
            public string leftBevelAngle;
            public string rightBevelAngle;

            // Optional data (may or may not be included) follows
            // TODO build out structures for optional data
        }
    }
}
