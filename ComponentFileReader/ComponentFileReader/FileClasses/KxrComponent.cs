using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ComponentFileReader.LumberClass;
using GeometryClassLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnitClassLibrary;

namespace ComponentFileReader.FileClasses
{
    public class KxrComponent : Component
    {
        public JObject JsonContents;

        #region Original Nodes
        public string TrussName
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["@TrussName"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["@TrussName"] = value;
            }
        }

        public string AppVersion
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["@AppVersion"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["@AppVersion"] = value;
            }
        }

        public string XmlVersion
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["@XMLVersion"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["@XMLVersion"] = value;
            }
        }

        public string TrussFileType
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["TrussFileType"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["TrussFileType"] = value;
            }
        }

        public string TrussFamily
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["TrussFamily"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["TrussFamily"] = value;
            }
        }

        public string Span
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["Span"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["Span"] = value;
            }
        }

        public string Pitch
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["Pitch"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["Pitch"] = value;
            }
        }

        public string Quantity
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["Quantity"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["Quantity"] = value;
            }
        }

        public string PricingQuantity
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["PricingQuantity"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["PricingQuantity"] = value;
            }
        }

        public string LtOverhang
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["LtOverhang"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["LtOverhang"] = value;
            }
        }

        public string RtOverhang
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["RtOverhang"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["RtOverhang"] = value;
            }
        }

        public string LtHeelHeight
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["LtHeelHeight"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["LtHeelHeight"] = value;
            }
        }

        public string RtHeelHeight
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["RtHeelHeight"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["RtHeelHeight"] = value;
            }
        }

        public string OverallHeight
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["OverallHeight"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["OverallHeight"] = value;
            }
        }

        public string Plies
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["Plies"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["Plies"] = value;
            }
        }

        public string WeightPerPly
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["WeightPerPly"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["WeightPerPly"] = value;
            }
        }

        public string Spacing
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                return jtoken["Spacing"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails");
                jtoken["Spacing"] = value;
            }
        }

        public List<KxrBearingCombo> Part1BearingCombos
        {
            get
            {
                var returnList = new List<KxrBearingCombo>();

                var jtoken = JsonContents.GetValue("TrussDetails")["BearingCombos"];

                foreach (var bearingCombotoken in jtoken.Children())
                {
                    var bearingCombo = new KxrBearingCombo();
                    foreach (var bearingtoken in bearingCombotoken.Children())
                    {
                        var bearing = new KxrBearing();
                        bearing.Width = bearingtoken["@Width"].ToString();
                        bearing.Continuous = bearingtoken["@Continuous"].ToString();
                        bearing.Fixity = bearingtoken["@Fixity"].ToString();
                        bearing.Fixity = bearingtoken["@Fixity"].ToString();
                        bearing.LocationX = bearingtoken["Location"]["@X"].ToString();
                        bearing.LocationX = bearingtoken["Location"]["@Y"].ToString();
                        bearing.Member = bearingtoken["Location"]["@Member"].ToString();

                        bearingCombo.Bearings.Add(bearing);
                    }

                    returnList.Add(bearingCombo);
                }


                var bearingCombos = new List<KxrBearingCombo>();

                return returnList;
            }
        }

        #region Part1 KxrBearingCombo classes
        public class KxrBearingCombo
        {
            public List<KxrBearing> Bearings;
        }

        public class KxrBearing
        {
            public string Width;
            public string Continuous;
            public string Fixity;
            public string Type;
            public string LocationX;
            public string LocationY;
            public string Member;
        }
        #endregion

        public KxrTrussType TrussTypes
        {
            get
            {
                var trussType = new KxrTrussType();

                var jtoken = JsonContents.GetValue("TrussDetails")["TrussType"];
                trussType.Gable = jtoken["Gable"].ToString();
                trussType.Girder = jtoken["Girder"].ToString();
                trussType.Hip = jtoken["Hip"].ToString();
                trussType.Jack = jtoken["Jack"].ToString();
                trussType.Rafter = jtoken["Rafter"].ToString();
                trussType.Attic = jtoken["Attic"].ToString();
                trussType.Ag = jtoken["Ag"].ToString();
                trussType.Reversed = jtoken["Reversed"].ToString();
                trussType.StructGable = jtoken["StructGable"].ToString();

                return trussType;
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["TrussType"];
                jtoken["Gable"] = value.Gable;
                jtoken["Girder"] = value.Girder;
                jtoken["Hip"] = value.Hip;
                jtoken["Jack"] = value.Jack;
                jtoken["Rafter"] = value.Rafter;
                jtoken["Attic"] = value.Attic;
                jtoken["Ag"] = value.Ag;
                jtoken["Reversed"] = value.Reversed;
                jtoken["StructGable"] = value.StructGable;
            }
        }
        #region Part1 KxrTrussType class
        public class KxrTrussType
        {
            public string Gable;
            public string Girder;
            public string Hip;
            public string Jack;
            public string Rafter;
            public string Attic;
            public string Ag;
            public string Reversed;
            public string StructGable;
        }
        #endregion

        //Loading

        //General Eng Infor

        //Design Info

        #region Two Disticeal Info

        public string ZWidth
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["TwoDistancealInfo"];
                return jtoken["Width"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["TwoDistancealInfo"];
                jtoken["Width"] = value;
            }
        }

        public List<KxrPiece> Pieces
        {
            get
            {
                var returnList = new List<KxrPiece>();

                var jtoken = JsonContents.GetValue("TrussDetails")["TwoDistancealInfo"]["Pieces"]["Piece"];

                foreach (var pieceSection in jtoken.Children())
                {


                    var kxrPiece = new KxrPiece();

                    kxrPiece.Label = pieceSection["@Label"].ToString();
                    kxrPiece.Type = pieceSection["@Type"].ToString();

                    kxrPiece.PieceLengthShortSide = pieceSection["PieceLengths"]["ShortSide"].ToString();
                    kxrPiece.PieceLengthLongSide = pieceSection["PieceLengths"]["LongSide"].ToString();
                    kxrPiece.PieceLengthCenterLine = pieceSection["PieceLengths"]["Centerline"].ToString();
                    kxrPiece.PieceLengthOverall = pieceSection["PieceLengths"]["Overall"].ToString();
                    kxrPiece.PieceLengthCorner2Corner = pieceSection["PieceLengths"]["Corner2Corner"].ToString();
                    kxrPiece.PieceLengthPiecePick = pieceSection["PieceLengths"]["PiecePick"].ToString();

                    kxrPiece.MaterialText = pieceSection["Material"]["Text"].ToString();
                    kxrPiece.MaterialSpecies = pieceSection["Material"]["Species"].ToString();
                    kxrPiece.MaterialGrade = pieceSection["Material"]["Grade"].ToString();
                    kxrPiece.MaterialNominlThickness = pieceSection["Material"]["NominalThickness"].ToString();
                    kxrPiece.MaterialNominalWidth = pieceSection["Material"]["NominalWidth"].ToString();
                    kxrPiece.MaterialTreatment = pieceSection["Material"]["Treatment"].ToString();

                    kxrPiece.LeftEndBevelType = pieceSection["BevelInformation"]["LeftEndBevel"]["BevelType"].ToString();
                    kxrPiece.LeftEndBevelAngle = pieceSection["BevelInformation"]["LeftEndBevel"]["BevelAngle"].ToString();
                    kxrPiece.RightEndBevelType = pieceSection["BevelInformation"]["RightEndBevel"]["BevelType"].ToString();
                    kxrPiece.RightEndBevelAngle = pieceSection["BevelInformation"]["RightEndBevel"]["BevelAngle"].ToString();

                    kxrPiece.Vertical = pieceSection["Vertical"].ToString();

                    foreach (var token in pieceSection["Point"].Children())
                    {
                        KxrPoint point = new KxrPoint
                        {
                            X = token["@X"].ToString(),
                            Y = token["@Y"].ToString()
                        };

                        kxrPiece.Points.Add(point);
                    }


                    returnList.Add(kxrPiece);
                }

                return returnList;
            }
        }

        #region kxrPiece Classes
        public class KxrPiece
        {
            public string Label;
            public string Type;

            public string PieceLengthShortSide;
            public string PieceLengthLongSide;
            public string PieceLengthCenterLine;
            public string PieceLengthOverall;
            public string PieceLengthCorner2Corner;
            public string PieceLengthPiecePick;

            public string MaterialText;
            public string MaterialSpecies;
            public string MaterialGrade;
            public string MaterialNominlThickness;
            public string MaterialNominalWidth;
            public string MaterialTreatment;

            public string LeftEndBevelType;
            public string LeftEndBevelAngle;
            public string RightEndBevelType;
            public string RightEndBevelAngle;

            public string Vertical;

            public List<KxrPoint> Points = new List<KxrPoint>();
        }

        public class KxrPoint
        {
            public string X;
            public string Y;
        }
        #endregion

        public List<KxrPlate> Plates
        {
            get
            {
                var returnList = new List<KxrPlate>();

                var jtoken = JsonContents.GetValue("TrussDetails")["TwoDistancealInfo"]["Plates"]["Plate"];

                foreach (var plateSection in jtoken.Children())
                {
                    var kxrPlate = new KxrPlate();

                    kxrPlate.Label = plateSection["@Label"].ToString();
                    kxrPlate.Width = plateSection["@Width"].ToString();
                    kxrPlate.Length = plateSection["@Length"].ToString();
                    kxrPlate.Gauge = plateSection["@Gauge"].ToString();
                    kxrPlate.Angle = plateSection["@Angle"].ToString();
                    kxrPlate.JointNo = plateSection["@JointNo"].ToString();
                    kxrPlate.SplicePlate = plateSection["@SplicePlate"].ToString();
                    kxrPlate.Type = plateSection["@Type"].ToString();

                    kxrPlate.Points = new List<KxrPoint>();

                    foreach (var token in plateSection["PlatePts"]["Point"].Children())
                    {
                        KxrPoint point = new KxrPoint();
                        point.X = token["@X"].ToString();
                        point.Y = token["@Y"].ToString();
                        kxrPlate.Points.Add(point);
                    }


                    returnList.Add(kxrPlate);
                }

                return returnList;
            }
        }

        public class KxrPlate
        {
            public string Label;
            public string Width;
            public string Length;
            public string Gauge;
            public string Angle;
            public string JointNo;
            public string SplicePlate;
            public string Type;

            public List<KxrPoint> Points = new List<KxrPoint>();
        }

        #endregion

        #endregion

        #region Component Overrides

        public override string Name
        {
            get { return this.TrussName; }
            set { this.TrussName = value; }
        }

        public override ComponentType ComponentType
        {
            get
            {
                ComponentType componentType;
                Enum.TryParse(this.TrussFileType, out componentType);

                return componentType;

            }
            set { this.TrussFileType = value.ToString(); }
        }

        public override HashSet<ComponentFunction> ComponentFunctions
        {
            get
            {
                HashSet<ComponentFunction> returnSet = new HashSet<ComponentFunction>();

                if (this.TrussTypes.Gable == "Y")
                {
                    returnSet.Add(ComponentFunction.Gable);
                }

                if (this.TrussTypes.Girder == "Y")
                {
                    returnSet.Add(ComponentFunction.Girder);
                }

                if (this.TrussTypes.Attic == "Y")
                {
                    returnSet.Add(ComponentFunction.Attic);
                }

                if (this.TrussTypes.Hip == "Y")
                {
                    returnSet.Add(ComponentFunction.Hip);
                }

                if (this.TrussTypes.Jack == "Y")
                {
                    returnSet.Add(ComponentFunction.Jack);
                }

                if (this.TrussTypes.Rafter == "Y")
                {
                    returnSet.Add(ComponentFunction.Rafter);
                }

                if (this.TrussTypes.StructGable == "Y")
                {
                    returnSet.Add(ComponentFunction.StructuralGable);
                }

                return returnSet;

            }
            set
            {
                var kxrTrussType = new KxrTrussType();

                if (value.Contains(ComponentFunction.Gable))
                {
                    kxrTrussType.Gable = "Y";
                }
                else
                {
                    kxrTrussType.Gable = "N";
                }

                if (value.Contains(ComponentFunction.StructuralGable))
                {
                    kxrTrussType.StructGable = "Y";
                }
                else
                {
                    kxrTrussType.StructGable = "N";
                }

                if (value.Contains(ComponentFunction.Hip))
                {
                    kxrTrussType.Hip = "Y";
                }
                else
                {
                    kxrTrussType.Hip = "N";
                }

                if (value.Contains(ComponentFunction.Jack))
                {
                    kxrTrussType.Jack = "Y";
                }
                else
                {
                    kxrTrussType.Jack = "N";
                }

                if (value.Contains(ComponentFunction.Attic))

                {
                    kxrTrussType.Attic = "Y";
                }
                else
                {
                    kxrTrussType.Attic = "N";
                }

                if (value.Contains(ComponentFunction.Rafter))

                {
                    kxrTrussType.Rafter = "Y";
                }
                else
                {
                    kxrTrussType.Rafter = "N";
                }

                this.TrussTypes = kxrTrussType;
            }
        }

        public override List<Bearing> Bearings
        {
            get
            {
                //var parsedBearings = new List<Bearing>();

                //var bearingCombos = this.Part1BearingCombos;

                //foreach (var kxrBearingCombo in bearingCombos)
                //{
                //    var count = 1;
                //    foreach (var kxrBearing in kxrBearingCombo.Bearings)
                //    {
                //        Bearing bearing = new Bearing();
                //        bearing.Name = count.ToString();
                //        bearing
                //        count++;
                //    }

                //}
                throw new System.NotImplementedException();
            }
            set { throw new System.NotImplementedException(); }
        }

        public override List<Member> Members
        {
            get
            {
                List<Member> returnMembers = new List<Member>();
                foreach (var kxrPiece in this.Pieces)
                {
                    var name = kxrPiece.Label;
                    var species = kxrPiece.MaterialSpecies;
                    var grade = kxrPiece.MaterialGrade;
                    var nominalThickness = kxrPiece.MaterialNominlThickness;
                    var nominalWidth = kxrPiece.MaterialNominalWidth;
                    var lengthString = kxrPiece.PieceLengthPiecePick;
                    var memberfunctionString = kxrPiece.Type;

                    var memberfunction = MemberType.Web;

                    if (memberfunctionString == "TC")
                    {
                        memberfunction = MemberType.TopChord;
                    }
                    if (memberfunctionString == "BC")
                    {
                        memberfunction = MemberType.BottomChord;
                    }

                    if (memberfunctionString == "Web")
                    {
                        memberfunction = MemberType.Web;
                    }

                    var realThicknessInches = Lumber.ConvertNominalInchesToActual(Double.Parse(nominalThickness));
                    var realWidthInches = Lumber.ConvertNominalInchesToActual(Double.Parse(nominalWidth));

                    var thickness = new Distance(DistanceType.Inch, realThicknessInches);
                    var width = new Distance(DistanceType.Inch, realWidthInches);
                    var length = new Distance(DistanceType.Inch, Double.Parse(lengthString));

                    Lumber lumber = new Lumber(thickness, width, length, grade, species);

                    List<Point> points = new List<Point>();

                    foreach (var kxrPoint in kxrPiece.Points)
                    {
                        var x = new Distance(DistanceType.Inch, Double.Parse(kxrPoint.X));
                        var y = new Distance(DistanceType.Inch, Double.Parse(kxrPoint.Y));

                        points.Add(new Point(x, y));
                    }

                    Polygon geometry;

                    var trussThickness = Double.Parse(this.ZWidth) ;

                    if (kxrPiece.Vertical == "Y")
                    {
                        var vector1 = new Vector(points[0], points[1]);
                        var vector2 = new Vector(Point.MakePointWithInches(0, 0, trussThickness));

                        geometry = Polygon.MakeParallelogram(vector1, vector2, points[0]);

                        returnMembers.Add(new Member(lumber, memberfunction, geometry, name));
                    }
                    else
                    {
                        var vector1 = new Vector(points[0], points[1]);
                        var vector2 = new Vector(Point.MakePointWithInches(0, 0, trussThickness));

                        geometry = Polygon.MakeParallelogram(vector1, vector2, points[0]);

                        returnMembers.Add(new Member(lumber, memberfunction, geometry, name));
                    }
                }

                return returnMembers;
            }

            set
            { throw new System.NotImplementedException(); }
        }

        public override List<PlateConnector> PlateConnectors
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }
        #endregion

        public KxrComponent(string contents) : base()
        {
            var temp = new XmlDocument();
            temp.LoadXml(contents);

            this.JsonContents = JObject.Parse(JsonConvert.SerializeXmlNode(temp));
        }

        public XmlDocument GetXML()
        {
            XmlDocument documentToReturn = (XmlDocument)JsonConvert.DeserializeXmlNode(this.JsonContents.ToString());

            return documentToReturn;
        }
    }
}
