using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentFileReader.FileClasses.TreComponent
{
    public partial class TreComponent
    {
        public string NumberOfReactionCases;
        public List<TreReactionInfo> TreReactions;
    }

    public class TreReactionInfo
    {
        public string NumberOfReactions;
        public string LeftTopPoint;
        public string LeftBottomPoint;
        public string RightTopPoint;
        public string RightBottomPoint;
        public string MinimumXCoordinate;
        public string MaximumXCoordinate;
        public string ActualNumberOfReactionSets;
        public string CheckType;
        public string LoadOriginCode;
        public string LoadCaseSense;
        public string WoodDOL;

        public string MonoTruss;
        public string OutputForce;
        public string JointID;
        public string XCoordinateOfJoint;
        public string YCoordinateOfJoint;
        public string DirectionOfForces;
        public string DummyLoadType;
    }
}
