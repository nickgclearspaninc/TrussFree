using System;

namespace ComponentFileReader.Readers
{
    public class TreReader
    {
        public Component Parse(string treContents)
        {
            var name = "";

            string trussTypeString = "";
            var trussType = ((trussTypeString == "Roof") ? ComponentType.Roof : ComponentType.Floor);

            //reader.ReadToFollowing("Span");
            //var Span = new Distance(DistanceType.Foot, reader.ReadElementContentAsDouble());

            //reader.ReadToFollowing("LtOverhang");
            //var leftOverhangDistance = Distance.MakeDistanceWithInches(reader.ReadElementContentAsDouble());
            //reader.ReadToFollowing("RtOverhang");
            //var rightOverhangDistance = Distance.MakeDistanceWithInches(reader.ReadElementContentAsDouble());

            //// reads left and right heels
            //reader.ReadToFollowing("LtHeelHeight");
            //var leftHeelHeight = reader.ReadElementContentAsDouble();
            //reader.ReadToFollowing("RtHeelHeight");
            //var rightHeelHeight = reader.ReadElementContentAsDouble();

            //reader.ReadToFollowing("Plies");
            //var plies = reader.ReadElementContentAsInt();

            //// reads premilinary information for bearings
            //List<Bearing> prelimBearing = GetPrelimBearing(reader);

            //// reads truss type
            ////newTruss.TrussFunction = XMLGenerateTrussType(reader);

            //var members = XMLGenerateMembers(reader);

            //var plateConnectors = ParsePlates(reader);

            //var bearings = ParseBearings(reader, prelimBearing);

            //return new Component(members, bearings, plateConnectors, trussType, name);

            throw  new NotImplementedException();
        }

        //#region Helper Methods
        ///// <summary>
        ///// sets the indices of this repositor class using the string array
        ///// </summary>
        ///// <param name="lines"></param>
        //private void setIndices(string[] lines)
        //{
        //    for (int i = 0; i < lines.Length; i++)
        //    {
        //        switch (lines[i].Trim())
        //        {
        //            case "ROOF BASICS":
        //                _rooftrussindex = i;
        //                break;
        //            case "FLOOR BASICS":
        //                _floortrussindex = i;
        //                break;
        //            case "DETAIL INFO":
        //                _detailinfoindex = i;
        //                break;
        //            case "WEBBING INFO":
        //                _webbinginfoindex = i;
        //                break;
        //            case "SHEATHING INFORMATION":
        //                _sheathinginfoindex = i;
        //                break;
        //            case "MEMBER INFO":
        //                _memberinfoindex = i;
        //                break;
        //            case "[Plate Info V4000]":
        //                _plateinfoindex = i;
        //                break;
        //        }
        //    }
        //}
        //#endregion
    }
}
