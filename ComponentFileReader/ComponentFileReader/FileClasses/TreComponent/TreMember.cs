using System.Collections.Generic;

namespace ComponentFileReader.FileClasses.TreComponent
{
    public partial class TreComponent
    {
        public class TreMember
        {
            // Represent data from a line like this (see also line 27 in MiTek's documentation file for the TRE file format):
            // 0 RH 1 7 0 1 3 0 0 4 4 0 1 0 0 0 0 0 3e262981-c9a8-4b71-a537-975668e2c457 0 1 0 1 -100.000000 xxx xxx 0 0 0 0 0 0 0 0 0 0 0 0 0 -1 0 0.000000 0.000000 0.000000 0.000000 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
            public string MemberCounter;
            public string MemberLabelLine27;
            public string MemberType;
            public string LineType;
            public string LineLocation;
            public string MemberExistFlag;
            public string InfiniteEnd;
            public string WebInputFlag;
            public string DefMaterial;
            public string CurrentMaterialIndex;
            public string OriginalMaterialIndex;
            public string LumberFixity;
            public string StructuralFlag;
            public string CreatedByAnalogIndicatorFlag;
            public string PosiIndicatorFlag;
            public string PosiType;
            public string PosiTopSide;
            public string MemberZOrdering;
            public string InventoryGuid;
            public string HeelMemberFlag;
            public string OriginalSpliceMember;
            public string ShowSatusFlag;
            public string PartNumber;
            public string PurlinSpacing;
            public string ParentLabel;
            public string PosiId;
            public string StackMemberFlag;
            public string RemovedMember;
            public string LeftTowCutFlag;
            public string RightTowCutFlag;
            public string ManuallyTurbowebbedFlag;
            public string WebOptimizedFlag;
            public string VerticalCutCorrectedForTowFlag;
            public string TowApexVerticalFlag;
            public string LeftTowCuttingCorrectedFlag;
            public string RightTowCuttingCorrectedFlag;
            public string LeftTowSquareFlag;
            public string RightTowSquareFlag;
            public string TrimmableEndFlag;
            public string WhichEnd;
            public string NotAlignedFlag;
            public string FixityMaximumWidth;
            public string FixityMaximumDepth;
            public string FixityMinimumWidth;
            public string FixityMinimumDepth;
            public string SquareCutStatus;
            public string CreateForRoofSquareCutFlag;
            public string EndCutType;
            public string ManuallySelectedBracing;
            public string VersaModifiedFlag; // Canada
            public string DefMaterialManuallyAdjustedFlag;
            public string CreatedAsBearingBlockFlag;
            public string CutForOutlookersFlag;
            public string RepairScabFlag;
            public string ManuallyHatchedMember;
            public string FieldInstalledMember;
            public string UserModifiedPartNumber;
            public string UserModifiedHatch;
            public string UserModifiedFieldInstallMember;
            public string ShipLooseMember;
            public string PlyThisMemberAppliesTo; // 0 = all plies
            public string LumberEdgeFlatFlag; // 0 = edge, 1 = flat

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
            public string MemberLabelLine31; // Most likely repeat data of MemberDataLine27
            public string PointsOnLeftEndOfMember;
            public string MemberStockLength;
            public string MemberCost;

            // Represent data from a line like this (see also line 32 in MiTek's documentation file for the TRE file format):
            //   0.000,  0.271,  0.000,  4.063,116.813, 52.734,116.813, 48.943
            public List<TrePoint> MemberPointCoordinates;

            // Represent data from a line like this (see also line 33 in MiTek's documentation file for the TRE file format):
            // 0 0 0.000000 0.000000
            public string leftBevelType;
            public string rightBevelType;
            public string leftBevelAngle;
            public string rightBevelAngle;

            // Optional data (may or may not be included) follows
            // TODO build out structures for optional data
        }
    }
}
