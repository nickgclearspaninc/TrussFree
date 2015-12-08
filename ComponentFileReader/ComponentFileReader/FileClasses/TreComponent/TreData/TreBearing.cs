using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentFileReader.FileClasses.TreComponent
{
    public class TreBearing
    {
        public string GravityBearing;
        public string UserDefinedMinBrCapacity;
        public string BearingMaterialModifiedByUser;
        public string IndexToEntryInMaterialMap;
        public string MaterialGroupId;
        public string WhoCreated;
        public string RightLabel;
        public string LeftLabel;
        public string SymbolType;
        public string PinPanels;
        public string SnapDirection;
        public string BearingEdgeLocations;
        public string BearingYCoordinate;
        public string BearingXCoordinate;
        public string Line44BearingSize;
        public string BearingType;
        public string BearingDrawStatus;
        public string ShearBearing;
        public string BearingSupportDepth;
        public string UseBearingSizeKzcpFactor;

        public TreBearing(string[] contents)
        {
            this.BearingDrawStatus = contents[0];
            this.BearingType = contents[1];
            this.Line44BearingSize = contents[2];
            this.BearingXCoordinate = contents[3];
            this.BearingYCoordinate = contents[4];
            this.BearingEdgeLocations = contents[5];
            this.SnapDirection = contents[6];
            this.PinPanels = contents[7];
            this.SymbolType = contents[8];
            //ToDo: Extra number [9]???
            this.LeftLabel = contents[10];
            this.RightLabel = contents[11];
            this.WhoCreated = contents[12];
            this.MaterialGroupId = contents[13];
            this.IndexToEntryInMaterialMap = contents[14];
            this.BearingMaterialModifiedByUser = contents[15];
            this.UserDefinedMinBrCapacity = contents[16];
            this.GravityBearing = contents[17];
            this.UseBearingSizeKzcpFactor = contents[18];
            this.BearingSupportDepth = contents[19];
            this.ShearBearing = contents[20];
        }
    }

    public class TreHipExension
    {
        public string CalHipFrontAngle;
        public string CalHipCornerThickness;
        public string RightExtensionXLocation;
        public string LeftExtensionXLocation;
        public string RightExtensionIndicator;
        public string LeftExtensionIndicator;
        public string FlatSegmentIndex;

        public TreHipExension(string[] contents)
        {
            this.FlatSegmentIndex = contents[0];
            this.LeftExtensionIndicator = contents[1];
            this.RightExtensionIndicator = contents[2];
            this.LeftExtensionXLocation = contents[3];
            this.RightExtensionXLocation = contents[4];
            this.CalHipCornerThickness = contents[5];
            this.CalHipFrontAngle = contents[6];
        }
    }

    public class TreDropTop
    {
        public string DropHipAngleLine52;
        public string DropHipThicknessLine52;
        public string DropHipIndicatorLine52;
        public string FlatSegmentIndexLine52;

        public TreDropTop(string[] contents)
        {
            this.FlatSegmentIndexLine52 = contents[0];
            this.DropHipIndicatorLine52 = contents[1];
            this.DropHipThicknessLine52 = contents[2];
            this.DropHipAngleLine52 = contents[3];
        }
    }

    public partial class TreComponent
    {
        //Line 43
        public string NumberOfBearings;
        public string WallLength;
        //Line 44
        public List<TreBearing> Bearings;
        //Line 45
        public string ApplyDropToAllIndicator;
        public string MoveVertWebsTrussIndicator;
        public string CornerRafterIndicator;
        public string CaliforniaHipFrontAngle;
        public string CaliforniaHipCornerThickness;
        public string DropHipThickness;
        public string DropHipAngle;
        public string DropHipIndicator;
        public string CaliforniaHipExtension1;
        public string CaliforniaHipExtension2;
        public string CaliforniaHipIndicator;
        public string RHPoint;
        public string NumberOfProfile;
        //Line 46
        public List<TrePoint> BearingPoints;
        //Line 47
        public string NumberOfSegments;
        //Line 48
        public List<string> NumberOfPanelsForSegmentAtIndex;
        //Line 49
        public string NumberOfCalHipExtensions;
        //Line 50
        public List<TreHipExension> HipExtensions;
        //Line 51
        public string NumberOfDropTops;
        //Line 52
        public List<TreDropTop> DropTops;
    }
}
