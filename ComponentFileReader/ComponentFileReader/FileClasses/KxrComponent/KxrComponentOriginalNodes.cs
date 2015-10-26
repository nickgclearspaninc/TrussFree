﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ComponentFileReader.FileClasses.KxrComponent
{
    public partial class KxrComponent
    {
        public JObject JsonContents;

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

        #endregion
    }
}