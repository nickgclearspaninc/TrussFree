using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentFileReader.FileClasses.TreComponent
{
    public partial class TreComponent
    {
        //ROOF TRUSS
        public string PartNumber; //Might be omitted
        public string TrussType;
        public string StudSpacing;
        public string OptimizeDuringAnalysis;
        public string WebEndCutType;
        public string TrussDifficultyFactor;
        //ROOF DESIGN INFO
        public string DesignMethodSelected;
        public string BuildingCode;
        public string BuildingType;
        public string ContinuityCode;
        public string SheathTopChord;
        public string SheathBottomChord;
        public string DesignDeflection;
        public string MaximumPlies;
        public string MinimumPlies;
        public string MaximumBraces;
        public string TopChordPurlinSpacing;
        public string BottomChordPurlinSpacing;
        public string CheckStockLength;
        public string WetService;
        public string StepLumber;
        public string PinnedSplices;
        public string NumberOfPlies;
        public string BracingType;
        public string UseBoltHoles;
        public string BoltHoleDiameter;
        public string DeflnCompositeAction;
        public string ThirdPreferenceBearingDesignOption;
        public string SecondPreferenceBearingDesignOption;
        public string FirstPreferenceBearingDesignOption;
        public string UseVerticalMembersForMultiPlyNails;
        public string HeelDesignMethodSelected;
        public string CreepFactorWetLumber;
        public string CreepFactorDryLumber;
        public string BottomChordSheathingGroup;
        public string FlatTopChordSheathingGroup;
        public string TopChordSheathingGroup;
        public string BottomChordSheathingMaterial;
        public string Index;
        public string FlatTopChordSheathingMaterialIndex;
        public string TwoAnalogNodesForDado;
        //ToDo: Find mi2000\desinfo.cpp for variable
        public string MinSliderPercent;
        public string MinSliderLength;
        public string AnalogMethod;
        public string GussetRepairInventoryID;
        public string RepairSheathingMaterialIndex;
        public string GussetRepairOption3;
        public string GussetRepairOption2;
        public string GussetRepairOption1;
        public string GussetRepairDoubleLayer;
        public string GussetRepairIncrementMaterial;
        public string GussetRepairCheckGrainDirection;
        public string BearingMaterialIndex;
        public string BearingMaterialConsiderList;
        public string NailTrussSymmetrically;
        public string TrussSheathingInventoryID;
        public string TrussSheathingMaterial;
        public string PlyToPlyCompositeDesign;
        public string BearingSupportDepth;
        public string UseBearingSizeKzpFactor;
        public string IgnoreFlatRoofPart9Factor;
        public string BracingMaterialFixity;
        public string LatBracingStartMaterial;
        public string LatBracingMaterialInventoryID;
        public string ForintekTrussOverride;
        public string UseModifyBendingCapacityFactor;
        public string BearingCapacity;
        public string DistanceToCombineAnalogNodesForDado;
        public string FirstAndThirdLength;
    }
}
