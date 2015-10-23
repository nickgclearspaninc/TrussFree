using System.Collections.Generic;

namespace ComponentFileReader.FileClasses.TreComponent
{
    public partial class TreComponent
    {
        public class TreMemberInfo
        {
            // Represent data from a line like this (see also line 25 in MiTek's documentation file for the TRE file format):
            //  105.34,2x4,2x4,2x4
            public string TrussHighestVerticalPoint;
            public string TopChordLumberSize;
            public string BottomChordLumberSize;
            public string WebLumberSize;

            // Represent data from a line like this (see also line 26 in MiTek's documentation file for the TRE file format):
            //  60 0 0 0 0 0 0 0 0 0 0 0 
            public string NumberOfMembers;
            public string OriginLineMemberNumber;
            public string AlwaysSetTo0; // Who knows why, but that's what the documentation specifies
            public string InitialReferenceLineV0;
            public string InitialReferenceLineH0;
            public string InitialReferenceLineV99;
            public string InitialReferenceLineOHL;
            public string InitialReferenceLineOHR;
            public string InitialReferenceLineSCL;
            public string InitialReferenceLineSCR;
            public string InitialReferenceLineOH1;
            public string InitialReferenceLineOH2;

            // Represent data from a line like this (see also line 27 in MiTek's documentation file for the TRE file format):
            // 0 RH 1 7 0 1 3 0 0 4 4 0 1 0 0 0 0 0 3e262981-c9a8-4b71-a537-975668e2c457 0 1 0 1 -100.000000 xxx xxx 0 0 0 0 0 0 0 0 0 0 0 0 0 -1 0 0.000000 0.000000 0.000000 0.000000 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
            public string MemberCounter;
            public string MemberLabel;
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

            // The actual members
            public List<TreMember> TreMembers;
        }
    }
}
