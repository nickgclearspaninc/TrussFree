using System.Collections.Generic;
using System.IO;
using System.Xml;
using ComponentFileReader.LumberClass;
using GeometryClassLibrary;
using UnitClassLibrary;

namespace ComponentFileReader.Readers
{
    public enum BoundaryJointType { Fixed, Pin, HorizontalRoller, VerticalRoller, Released }

    public class KxrReader
    {
        /// <summary>
        /// Extracts component from a KXR file as text string 
        /// </summary>
        public Component Parse(string kxrContents)
        {
            // reads the single string as XML text
            using (XmlReader reader = XmlReader.Create(new StringReader(kxrContents)))
            {
                // reads the name of the truss
                reader.ReadToFollowing("TrussDetails");
                reader.MoveToFirstAttribute();
                var name = reader.Value;

                reader.ReadToFollowing("TrussFileType");
                string trussTypeString = reader.ReadElementContentAsString();
                var trussType = ((trussTypeString == "Roof") ? ComponentType.Roof : ComponentType.Floor);

                reader.ReadToFollowing("Span");
                var Span = new Distance(DistanceType.Foot, reader.ReadElementContentAsDouble());

                reader.ReadToFollowing("LtOverhang");
                var leftOverhangDistance = Distance.MakeDistanceWithInches(reader.ReadElementContentAsDouble());
                reader.ReadToFollowing("RtOverhang");
                var rightOverhangDistance = Distance.MakeDistanceWithInches(reader.ReadElementContentAsDouble());

                // reads left and right heels
                reader.ReadToFollowing("LtHeelHeight");
                var leftHeelHeight = reader.ReadElementContentAsDouble();
                reader.ReadToFollowing("RtHeelHeight");
                var rightHeelHeight = reader.ReadElementContentAsDouble();

                reader.ReadToFollowing("Plies");
                var plies = reader.ReadElementContentAsInt();

                // reads premilinary information for bearings
                List<Bearing> prelimBearing = GetPrelimBearing(reader);

                // reads truss type
                //newTruss.TrussFunction = XMLGenerateTrussType(reader);

                var members = XMLGenerateMembers(reader);

                var plateConnectors = ParsePlates(reader);

                var bearings = ParseBearings(reader, prelimBearing);

                return new Component(members, bearings, plateConnectors, trussType, name);
            }
        }

        /// <summary>
        /// Reads plates from the string of XML
        /// </summary>
        /// <param name="reader">xmlreader that has XML string from KXR</param>
        /// <returns>the list of plates on the KXR truss</returns>
        private List<PlateConnector> ParsePlates(XmlReader reader)
        {
            // reads to the appropriate section and finds the number of plates
            reader.ReadToFollowing("Plates");
            reader.MoveToFirstAttribute();

            int numberOfPlates = int.Parse(reader.Value);

            // sets up for the adding of plates
            List<PlateConnector> plateList = new List<PlateConnector>();

            // creates new plate for every plate in the KXR
            for (int plateNumber = 0; plateNumber < numberOfPlates; plateNumber++)
            {
                // reads to the individual plate element in the XML file
                reader.ReadToFollowing("Plate");

                reader.MoveToFirstAttribute();
                string plateLabel = reader.Value;

                #region values that describe the same information as the points do (currently not used)

                reader.MoveToNextAttribute();
                Distance plateWidth = double.Parse(reader.Value) * Distance.Inch;

                reader.MoveToNextAttribute();
                Distance plateLength = double.Parse(reader.Value) * Distance.Inch;

                reader.MoveToNextAttribute();
                var gauge = double.Parse(reader.Value);

                reader.MoveToNextAttribute();
                Angle plateConnectorAngle = new Angle(AngleType.Degree, double.Parse(reader.Value));

                #endregion

                reader.ReadToFollowing("PlatePts");

                reader.MoveToFirstAttribute();
                int numberOfPlatePoints = int.Parse(reader.Value);

                // set up Point List for storing plate points
                List<Point> platePoints = new List<Point>();

                for (int i = 0; i < numberOfPlatePoints; i++)
                {
                    // move reader to point and get the X
                    reader.ReadToFollowing("Point");
                    reader.MoveToFirstAttribute();
                    double plateX = double.Parse(reader.Value);

                    // get the Y
                    reader.MoveToNextAttribute();
                    double plateY = double.Parse(reader.Value);

                    // create the point and add it to the list
                    platePoints.Add(Point.MakePointWithInches(plateX, plateY));
                }

                // finds the center point and adds it
                Polygon plateGeometry = new Polygon(platePoints);
                PlateConnector plate = new PlateConnector(plateGeometry, plateLabel);

                // adds plate to list
                plateList.Add(plate);
            }

            return plateList;
        }

        /// <summary>
        /// generates members with XML reader given from KXR file
        /// </summary>
        /// <param name="reader">XML reader reading KXR file</param>
        /// <returns>List of members in truss from KXR file</returns>
        private static List<Member> XMLGenerateMembers(XmlReader reader)
        {
            // creates list ready for storing
            List<Member> memberList = new List<Member>();

            // finds the width of the member
            reader.ReadToFollowing("Width");
            double width = reader.ReadElementContentAsDouble();

            // finds how many members there are
            reader.ReadToFollowing("Pieces");
            reader.MoveToFirstAttribute();
            int numberOfMembers = int.Parse(reader.Value);

            // checks each member's information and creates it
            for (int i = 0; i < numberOfMembers; i++)
            {

                // gets the label for the member
                reader.ReadToFollowing("Piece");
                reader.MoveToFirstAttribute();
                var name = reader.Value;

                // find the number of points on the member
                reader.MoveToNextAttribute();
                int numPoints = int.Parse(reader.Value);

                reader.MoveToNextAttribute();
                string memberType = reader.Value;

                //reader.ReadToFollowing("Material");
                //var material = reader.ReadElementContentAsString();

                reader.ReadToFollowing("Species");
                var species = reader.ReadElementContentAsString();

                reader.ReadToFollowing("Grade");
                var grade = reader.ReadElementContentAsString();

                reader.ReadToFollowing("NominalThickness");
                var nominalthickness = reader.ReadElementContentAsDouble();

                reader.ReadToFollowing("NominalWidth");
                var nominalwidth = reader.ReadElementContentAsDouble();

                Lumber lumber = null;// new Lumber();

                // gets bevel info for left and right bevels
                reader.ReadToFollowing("LeftEndBevel");
                reader.ReadToFollowing("BevelType");
                string leftBevelType = reader.ReadElementContentAsString();
                reader.ReadToFollowing("BevelAngle");
                double leftBevelAngle = reader.ReadElementContentAsDouble();

                reader.ReadToFollowing("RightEndBevel");
                reader.ReadToFollowing("BevelType");
                string rightBevelType = reader.ReadElementContentAsString();
                reader.ReadToFollowing("BevelAngle");
                double rightBevelAngle = reader.ReadElementContentAsDouble();

                // the Distance array size is the number of X,Y points multiplied by the number of 
                // Distances (2, X and Y)
                List<Point> dimNums = new List<Point>();

                // takes the points and puts them together into line segments
                for (int j = 0; j < numPoints; j++)
                {
                    // reads to the point
                    reader.ReadToFollowing("Point");

                    // reads X attribute (j * 2) and Y attribute (j * 2 + 1)
                    reader.MoveToFirstAttribute();
                    double x = double.Parse(reader.Value);
                    reader.MoveToNextAttribute();
                    double y = double.Parse(reader.Value);

                    dimNums.Add(Point.MakePointWithInches(x, y));
                }

                // makes the points into line segments that meet and add them to the member list
                var tempGeometry = new Polygon(dimNums);//.Extrude(new Vector(Point.MakePointWithInches(0, 0, 1.5)));
                memberList.Add(new Member(lumber, MemberType.Web, tempGeometry, (i).ToString()));
            }

            return memberList;
        }

        /// <summary>
        /// Determines what truss type this truss is
        /// </summary>
        /// <param name="reader">the xml reader with a KXR file loaded</param>
        /// <returns>the KXRComponentType that the truss is</returns>
        private static ComponentFunction XMLGenerateTrussType(XmlReader reader)
        {
            reader.ReadToFollowing("TrussType");

            bool[] trussType = new bool[9];
            int count = 0;

            // reads to each truss type and determines if the boolean supporting it is True or False
            reader.ReadToFollowing("Gable");
            trussType[count++] = YNToBool(reader.ReadElementContentAsString());

            reader.ReadToFollowing("Girder");
            trussType[count++] = YNToBool(reader.ReadElementContentAsString());

            reader.ReadToFollowing("Hip");
            trussType[count++] = YNToBool(reader.ReadElementContentAsString());

            reader.ReadToFollowing("Jack");
            trussType[count++] = YNToBool(reader.ReadElementContentAsString());

            reader.ReadToFollowing("Rafter");
            trussType[count++] = YNToBool(reader.ReadElementContentAsString());

            reader.ReadToFollowing("Attic");
            trussType[count++] = YNToBool(reader.ReadElementContentAsString());

            reader.ReadToFollowing("Ag");
            trussType[count++] = YNToBool(reader.ReadElementContentAsString());

            reader.ReadToFollowing("Reversed");
            trussType[count++] = YNToBool(reader.ReadElementContentAsString());

            // counting this as a floor truss
            reader.ReadToFollowing("StructGable");
            trussType[count++] = YNToBool(reader.ReadElementContentAsString());

            return GetTrussType(trussType);
        }

        private static List<Bearing> ParseBearings(XmlReader readee, List<Bearing> prelimBearing)
        {
            List<Bearing> fullBearings = prelimBearing;
            readee.ReadToFollowing("BearingCombos");

            // reads for each of the bearings and finds the points
            for (int i = 0; i < fullBearings.Count; i++)
            {
                readee.ReadToFollowing("BrgPoints");
                readee.MoveToFirstAttribute();
                int numPoints = int.Parse(readee.Value);

                List<Point> pointList = new List<Point>();

                for (int j = 0; j < numPoints; j++)
                {
                    readee.ReadToFollowing("Point");

                    readee.MoveToFirstAttribute();
                    Distance x = Distance.MakeDistanceWithInches(double.Parse(readee.Value));
                    readee.MoveToNextAttribute();
                    Distance y = Distance.MakeDistanceWithInches(double.Parse(readee.Value));

                    pointList.Add(new Point(x, y));
                }

                var vector1 = new Vector(pointList[0], pointList[1]); //We're making the tenous assumption here that the first two points always are a segment parallel to the x axis
                var vector2 = new Vector(Point.MakePointWithInches(0, 0, 1.5));

                var polygon = Polygon.MakeParallelogram(vector1, vector2, pointList[0]);
                prelimBearing[i].Geometry =  polygon;
            }

            return fullBearings;
        }

        /// <summary>
        /// gets the preliminary information for bearings from KXR file
        /// </summary>
        /// <param name="readee">XML reader loaded with KXR file</param>
        /// <returns>List of Bearing that is the starting info for bearings</returns>
        private static List<Bearing> GetPrelimBearing(XmlReader readee)
        {
            readee.ReadToFollowing("Bearings");
            readee.MoveToFirstAttribute();

            int numberOfBearings = int.Parse(readee.Value);

            List<Bearing> bearList = new List<Bearing>(numberOfBearings);
            for (int i = 0; i < numberOfBearings; i++)
            {
                Bearing bearing = null;
                readee.ReadToFollowing("Bearing");

                readee.MoveToFirstAttribute();
                //bearing.WidthInXYPlane = Distance.MakeDistanceWithInches(double.Parse(readee.Value));

                readee.MoveToNextAttribute();
                //bearing.IsContinuous = YNToBool(readee.Value);

                readee.MoveToNextAttribute();
                //bearing.FixityType = FixityasEnum(readee.Value);

                readee.MoveToNextAttribute();
                //bearing.BearingType = BearingTypeasEnum(readee.Value);

                bearList.Add(bearing);
            }

            return bearList;
        }

        private static ComponentFunction GetTrussType(bool[] type)
        {
            ComponentFunction functionToReturn = ComponentFunction.Normal;

            for (int i = 0; i < type.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        functionToReturn = ComponentFunction.Gable;
                        break;
                    case 1:
                        functionToReturn = ComponentFunction.Girder;
                        break;
                    case 2:
                        functionToReturn = ComponentFunction.Hip;
                        break;
                    case 3:
                        functionToReturn = ComponentFunction.Jack;
                        break;
                    case 4:
                        functionToReturn = ComponentFunction.Rafter;
                        break;
                    case 5:
                        functionToReturn = ComponentFunction.Attic;
                        break;
                    case 6:
                        functionToReturn = ComponentFunction.Ag;
                        break;
                    case 7:
                        functionToReturn = ComponentFunction.Reversed;
                        break;
                    case 8:
                        functionToReturn = ComponentFunction.StructuralGable;
                        break;
                }
            }

            return functionToReturn;
        }

        /// <summary>
        /// returns the fixity type based on input string
        /// </summary>
        /// <param name="passedString">string for fixity type</param>
        /// <returns>the fixity type</returns>
        private static BoundaryJointType FixityasEnum(string passedString)
        {
            switch (passedString)
            {
                case "HROLL":
                    return BoundaryJointType.HorizontalRoller;
                case "VROLL":
                    return BoundaryJointType.VerticalRoller;
                case "PIN":
                    return BoundaryJointType.Pin;
                default:
                    throw new IOException("The KXR file BoundaryJointType was not formatted as Expected, found instead: " + passedString);
            }
        }

        /// <summary>
        /// Eagle uses N and Y to represent their bool values
        /// </summary>
        /// <param name="passedString">a string that says Y or N</param>
        /// <returns>the corresponding bool</returns>
        private static bool YNToBool(string passedString)
        {
            if (passedString.Equals("N"))
                return false;
            else if (passedString.Equals("Y"))
                return true;

            throw new IOException("The KXR file was not formatted as Expected");
        }


        #region loading

        //private List<LoadCase> XMLGenerateLoadCases(XmlReader readrr)
        //{

        //reader.ReadToFollowing("TwoDistancealInfo");
        //newTruss.Information.LoadAppInformation.RoofLiveLoadProvision = reader.ReadElementContentAsString();

        //Loading Info
        //reader.ReadToFollowing("LoadingInfo");

        //reader.ReadToFollowing("StandardLoading");

        //  loads are stored as psf inside of KXR files

        //reader.ReadToFollowing("TCLive");
        //newTruss.Information.LoadAppInformation.TopChordLiveLoading = new Stress(new Area(AreaType.FeetSquared, 1), new Force(ForceType.Pounds, reader.ReadElementContentAsDouble()));

        //reader.ReadToFollowing("BCLive");
        //newTruss.Information.LoadAppInformation.BottomChordLiveLoading = new Stress(new Area(AreaType.FeetSquared, 1), new Force(ForceType.Pounds, reader.ReadElementContentAsDouble()));

        //reader.ReadToFollowing("TCDead");
        //newTruss.Information.LoadAppInformation.TopChordDeadLoading = new Stress(new Area(AreaType.FeetSquared, 1), new Force(ForceType.Pounds, reader.ReadElementContentAsDouble()));

        //reader.ReadToFollowing("BCDead");
        //newTruss.Information.LoadAppInformation.BottomChordDeadLoading = new Stress(new Area(AreaType.FeetSquared, 1), new Force(ForceType.Pounds, reader.ReadElementContentAsDouble()));

        //reader.ReadToFollowing("RoofLiveLoadProvision");
        //newTruss.Information.LoadAppInformation.RoofLiveLoadProvision = reader.ReadElementContentAsString();

        //  load cases in later version
        //newTruss.LoadCases = XMLGenerateLoadCases(reader);

        //<RoofLiveLoadProvision>IBC 2009</RoofLiveLoadProvision>

        //</AutomatedLiveLoads>

        //<WindLoad>

        //<UseWind>Y</UseWind>

        //<WindLoadProvision>ASCE7 - 05</WindLoadProvision>

        //<WindSpeed>90</WindSpeed>

        //<ExposureCategory>C</ExposureCategory>

        //<BuildingCategory>II</BuildingCategory>

        //<HurricaneRegion>N</HurricaneRegion>

        //</WindLoad>

        //<SnowLoad>

        //<UseSnow>Y</UseSnow>

        //<SnowLoadProvision>ASCE7 - 05</SnowLoadProvision>

        //<GroundSnowLoad>30</GroundSnowLoad>

        //<ExposureCategory>Partial</ExposureCategory>

        //<TerrainCategory>Unheated</TerrainCategory>

        //</SnowLoad>

        //<GirderLoad>

        //<GirderLoading>NoOne</GirderLoading>

        //</GirderLoad>

        //    readrr.ReadToFollowing("LoadCases");
        //    readrr.MoveToFirstAttribute();
        //    int numberOfLoadCases = int.Parse(readrr.Value);

        //    List<LoadCase> loadList = new List<LoadCase>();

        //    for (int i = 0; i < numberOfLoadCases; i++)
        //    {
        //        LoadCase loadcase = new LoadCase();
        //        readrr.ReadToFollowing("LoadCase");

        //        readrr.MoveToFirstAttribute();
        //        bool MWFRS = LoadCaseTypeasBool(readrr.Value);

        //        readrr.MoveToNextAttribute();
        //        bool ComponentsAndCladding = LoadCaseTypeasBool(readrr.Value);

        //        readrr.MoveToNextAttribute();
        //        bool AUTO = LoadCaseTypeasBool(readrr.Value);

        //        readrr.MoveToNextAttribute();
        //        bool USER = LoadCaseTypeasBool(readrr.Value);

        //        readrr.MoveToNextAttribute();
        //        bool ATTIC = LoadCaseTypeasBool(readrr.Value);

        //        readrr.MoveToNextAttribute();
        //        bool TTC = LoadCaseTypeasBool(readrr.Value);

        //        readrr.MoveToNextAttribute();
        //        bool ATTIC_STO = LoadCaseTypeasBool(readrr.Value);

        //        readrr.ReadToFollowing("Id");
        //        loadcase.Name = readrr.ReadContentAsString();

        //        readrr.ReadToFollowing("Description");
        //        loadcase.Description = readrr.ReadContentAsString();

        //        readrr.ReadToFollowing("Type");
        //        string LoadType = readrr.ReadContentAsString();

        //        loadList.Add(loadcase);
        //    }

        //    return loadList;
        //}
        #endregion

    }
}
