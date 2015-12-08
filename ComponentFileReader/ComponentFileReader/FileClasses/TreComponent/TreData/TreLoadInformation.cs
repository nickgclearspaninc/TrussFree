using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentFileReader.FileClasses.TreComponent
{
    public class TreLoadInformation
    {
        public string TrussSpanDeflectionRatio;
        public string TrussMaximumDeflection;
        public string TopChordSpanDeflectionRatio;
        public string TopChordMaximumDeflection;
        public string BottomChordSpanDeflectionRatio;
        public string BottomChordMaximumDeflection;
        public string CantileverSpanDeflectionRatio;
        public string CantileverMaximumDeflection;
        public string OverhangSpanDeflectionRatio;
        public string OverhangMaximumDeflection;
        public string WebSpanDeflectionRatio;
        public string WebMaximumDeflection;
        public string CollarSpanDeflectionRatio;
        public string CollarMaximumDeflection;
        public string WallSpanDeflectionRatio;
        public string WallMaximumDeflection;
        public string HorizontalSpanDeflectionRatio;
        public string HorizontalMaximumDeflection;

        public TreLoadInformation(string[] contents)
        {
            TrussSpanDeflectionRatio = contents[1];
            TrussMaximumDeflection = contents[2];
            TopChordSpanDeflectionRatio = contents[3];
            TopChordMaximumDeflection = contents[4];
            BottomChordSpanDeflectionRatio = contents[5];
            BottomChordMaximumDeflection = contents[6];
            CantileverSpanDeflectionRatio = contents[7];
            CantileverMaximumDeflection = contents[8];
            OverhangSpanDeflectionRatio = contents[9];
            OverhangMaximumDeflection = contents[10];
            WebSpanDeflectionRatio = contents[11];
            WebMaximumDeflection = contents[12];
            CollarSpanDeflectionRatio = contents[13];
            CollarMaximumDeflection = contents[14];
            WallSpanDeflectionRatio = contents[15];
            WallMaximumDeflection = contents[16];
            HorizontalSpanDeflectionRatio = contents[17];
            HorizontalMaximumDeflection = contents[18];
        }
    }

    public partial class TreComponent
    {
        public TreLoadInformation LiveLoads;
        public TreLoadInformation TotalLoad;
        public TreLoadInformation WindLive;
        public TreLoadInformation WindTotal;
    }
}
