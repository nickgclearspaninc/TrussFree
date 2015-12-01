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

            // The actual members
            public List<TreMember> TreMembers;
        }
    }
}
