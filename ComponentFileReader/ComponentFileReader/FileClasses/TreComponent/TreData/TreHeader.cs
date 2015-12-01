using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentFileReader.FileClasses.TreComponent
{
    public partial class TreComponent
    {
        //Line 1
        public string DisplayUnits;
        public string InternalUnits;
        //Line 2
        public string CSIFailure;
        public string SSIFailure;
        public string SummaryResultOfAnalyze;
        public string GeoconvertFailure;
        public string AllJointsArePlated;
        public string TrussUnstable;
        public string EstimateHasBeenDone;
        public string TrussDeflectionFailure;
        public string CamberStatus;
        public string ReactionFailure;
        public string HorizontalTotalDeflectionFailure;
        public string HorizontalLiveDeflectionFailure;
        public string BearingOutOfScarf;
        public string WedgeFailure;
        public string HeelFailure;
        public string FloorSpliceJointFailure;
        public string BearingNotAtJointFailure;
        public string BirdsmouthHeelFailure;
        public string LSLFailure;
        public string MinChordGradeFailureCanada;
        public string Span2x3ExceededCanada;
        public string Min2x3WebGradeFailureCanada;
        public string Min2x4WebGradeFailureCanada;
        public string DryLbrWithMetalWebFailCanada;
        public string MaxAllowedSpanExceedCanada;
        public string NailingPatternFailureCanada;
        public string MissedLoadingCanada;
        public string UnspecifiedDesignFailCanada;
        public string ChangedRequirementsCanada;
        public string PanelRackingDeflectionFailure;
        public string AnalysisResult;
        public string TreVersionNumber;
        //Line 3
        public string ProgramMode;
        public string TypeOfTruss;
        //Line 4
        //Line 5
        public string RoofOrFloorTruss;
        //Line 6 (ROOF)
        public string Quantity;
        public string TrussSpan;
        public string TopSlope;
        public string BottomSlope;
        public string LeftOverhangLength;
        public string RightOverhangLength;
        public string Part6Spacing;
        public string RoofSetupTrusses; 
        public string LeftTopChordOverhang;
        public string RightTopChordOverhang;
        public string DesignConnectionStatus;
        //Line 7 (ROOF)
        public string RightBearingSize;
        public string RightSeatCut;
        public string LeftBearingSize;
        public string LeftSeatCut;
        public string RightHeelHeight;
        public string LeftHeelHeight;
        //Line 8 (ROOF)
        public string Spacing;
        public string RightButtCut;
        public string LeftButtCut;
        //Line 9 (ROOF)
        public string RightHeelMatch;
        public string LeftHeelMatch;
        //Line 10 (ROOF)
        public string RightOverhangType;
        public string LeftOverhangType;
        //Line 11 (ROOF)
        public string LoadingFileName;
        public string GirderTrussIndicator;
        //Line 12 (ROOF)
        public string AtticVersatruss;
        public string UserLevel;
        //Line 13 (ROOF)
        public string SquareCutRoofWebs;
        public string TOWOptimizeNonApexVerts;
        public string TOWOptimizeApexVerts;
        public string TOWKeepVerticalsVertical;
        public string TOWDoNotMoveVerticals;
        public string OptimizeTurbo;
        public string RoofDetailMode;
        public string PosiRoof;
        public string TurboWebSquare;
        public string TurboWeb;
        public string TrussApplicationType;
        public string RightHeelReductionType;
        public string LeftHeelReductionType;
        public string UseAlternateSpacing;
        public string FirstAlternateSpacing;
        public string SecondAlternateSpacing;
        //Misc. Variables for FLOOR BASIC
        //Line 6 (FLOOR)
        public string FloorSetupTrusses;
        public string RoofFloorPosi;
        public string UseMitekAutomatedMach;
        public string ShowTrimmableIcon;
        public string TrimmableEnd;
        public string UseFullMetalWebOnly;
        //Line 8 (FLOOR)
        public string TrussDepth;
        public string NumberOfTopChords;
        public string NumberOfBottomChords;
        public string Bearing1Size;
        public string Bearing2Size;
        public string TopChordRibbon1;
        public string TopChordRibbon2;
        public string BottomChordRibbon1;
        public string BottomChordRibbon2;
        //Line 9 (FLOOR)
        public string IdentificationString;
        //Line 10 (FLOOR)
        public string NumberOfDetails;
        //Line 11 (FLOOR)
        public string DetailType;
        //Line 12 (FLOOR)
        public string XCoordinateLocation;
        public string NumberOfFullEndVertical;
        public string NumberOfShortEndVertical;
        public string TopRibbonDepth;
        public string BottomRibbonDepth;
        public string NumberOfEndVerticals;
        public string FireCutOffset;
        public string BearingSize;
        public string GapDistance;
        public string NumberOfTopPlies;
    }
}
