using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentFileReader.FileClasses.TreComponent
{
    public class TreSheathing
    {
        public string ExistFlag;
        public string NumberOfPlies;
        public string MaterialGroupID;
        public string MaterialIndexWithinGroup;
        public string SheathingAreInSquareFeet;
        public string SheathingOption;
        public string SheathingSide;
        public string LeftDistance;
        public string LeftPitch;
        public string RightDistance;
        public string RightPitch;
        public string PolygonPoints;
        public string SheathingX;
        public string SheathingY;

        public TreSheathing(string[] contents)
        {
            ExistFlag = contents[0];
            NumberOfPlies = contents[1];
            MaterialGroupID = contents[2];
            MaterialIndexWithinGroup = contents[3];
            SheathingAreInSquareFeet = contents[4];
            SheathingOption = contents[5];
            SheathingSide = contents[6];
            LeftDistance = contents[7];
            LeftPitch = contents[8];
            RightDistance = contents[9];
            RightPitch = contents[10];
            PolygonPoints = contents[11];
            SheathingX = contents[12];
            SheathingY = contents[13];
        }
    }

    public partial class TreComponent
    {
        public List<TreSheathing> SheathingInfo;
    }
}
