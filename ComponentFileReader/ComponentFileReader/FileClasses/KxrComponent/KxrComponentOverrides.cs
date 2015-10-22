using System;
using System.Collections.Generic;
using ComponentFileReader.LumberClass;
using GeometryClassLibrary;
using UnitClassLibrary;

namespace ComponentFileReader.FileClasses.KxrComponent
{
    public partial class KxrComponent : Component
    {
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
    }
}
