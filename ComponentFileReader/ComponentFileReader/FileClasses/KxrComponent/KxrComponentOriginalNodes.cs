using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ComponentFileReader.FileClasses.KxrComponent
{
    public partial class KxrComponent
    {
        public JObject JsonContents;

        #region First Truss Details
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
        #endregion

        #region BearingCombos
        public List<KxrBearingCombo> Part1BearingCombos
        {
            get
            {
                var returnList = new List<KxrBearingCombo>();

                var jtoken = JsonContents.GetValue("TrussDetails")["BearingCombos"]["BearingCombo"]["Bearings"]["Bearing"];
                var bearingCombo = new KxrBearingCombo();
                bearingCombo.Bearings = new List<KxrBearing>();
                foreach (var bearingtoken in jtoken.Children())
                {
                    var bearing = new KxrBearing();
                    bearing.Width = bearingtoken["@Width"].ToString();
                    bearing.Continuous = bearingtoken["@Continuous"].ToString();
                    bearing.Fixity = bearingtoken["@Fixity"].ToString();
                    bearing.Type = bearingtoken["@Type"].ToString();
                    bearing.LocationX = bearingtoken["Location"]["@X"].ToString();
                    bearing.LocationY = bearingtoken["Location"]["@Y"].ToString();
                    bearing.Member = bearingtoken["Location"]["@Member"].ToString();

                    bearingCombo.Bearings.Add(bearing);
                }

                returnList.Add(bearingCombo);

                var bearingCombos = new List<KxrBearingCombo>();

                return returnList;
            }
        }
        #endregion

        #region TrussType
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
        #endregion

        #region LoadingInfo
        public KxrStandardLoading StandardLoading
        {
            get
            {
                var standardLoading = new KxrStandardLoading();
                var jtoken = JsonContents.GetValue("TrussDetails")["LoadingInfo"]["StandardLoading"];
                standardLoading.TCLive = jtoken["TCLive"].ToString();
                standardLoading.TCDead = jtoken["TCDead"].ToString();
                standardLoading.BCLive = jtoken["BCLive"].ToString();
                standardLoading.BCDead = jtoken["BCDead"].ToString();
                return standardLoading;

            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LoadingInfo"]["StandardLoading"];
                jtoken["TCLive"] = value.TCLive;
                jtoken["TCDead"] = value.TCDead;
                jtoken["BCLive"] = value.BCLive;
                jtoken["BCDead"] = value.BCDead;
            }
        }

        public KxrStandardLoading BuildingStandardLoading
        {
            get
            {
                var standardLoading = new KxrStandardLoading();
                var jtoken = JsonContents.GetValue("TrussDetails")["LoadingInfo"]["BuildingStandardLoading"];
                standardLoading.TCLive = jtoken["TCLive"].ToString();
                standardLoading.TCDead = jtoken["TCDead"].ToString();
                standardLoading.BCLive = jtoken["BCLive"].ToString();
                standardLoading.BCDead = jtoken["BCDead"].ToString();
                return standardLoading;

            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LoadingInfo"]["BuildingStandardLoading"];
                jtoken["TCLive"] = value.TCLive;
                jtoken["TCDead"] = value.TCDead;
                jtoken["BCLive"] = value.BCLive;
                jtoken["BCDead"] = value.BCDead;
            }
        }
        
        public string AutomatedLiveLoadsRoofLiveLoadProvision
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LoadingInfo"]["AutomatedLiveLoads"];
                return jtoken["RoofLiveLoadProvision"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LoadingInfo"]["AutomatedLiveLoads"];
                jtoken["RoofLiveLoadProvision"] = value;
            }
        }

        public KxrWindLoad WindLoad
        {
            get
            {
                var windLoad = new KxrWindLoad();
                var jtoken = JsonContents.GetValue("TrussDetails")["LoadingInfo"]["WindLoad"];
                windLoad.UseWind = jtoken["UseWind"].ToString();
                windLoad.WindLoadProvision = jtoken["WindLoadProvision"].ToString();
                windLoad.WindSpeed = jtoken["WindSpeed"].ToString();
                windLoad.ExposureCategory = jtoken["ExposureCategory"].ToString();
                windLoad.BuildingCategory = jtoken["BuildingCategory"].ToString();
                windLoad.HurricaneRegion = jtoken["HurricaneRegion"].ToString();

                return windLoad;
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LoadingInfo"]["WindLoad"];
                jtoken["UseWind"] = value.UseWind;
                jtoken["WindLoadProvision"] = value.WindLoadProvision;
                jtoken["WindSpeed"] = value.WindSpeed;
                jtoken["ExposureCategory"] = value.ExposureCategory;
                jtoken["BuildingCategory"] = value.BuildingCategory;
                jtoken["HurricaneRegion"] = value.HurricaneRegion;
            }
        }

        public KxrSnowLoad SnowLoad
        {
            get
            {
                var windLoad = new KxrSnowLoad();
                var jtoken = JsonContents.GetValue("TrussDetails")["LoadingInfo"]["SnowLoad"];
                windLoad.UseSnow = jtoken["UseSnow"].ToString();
                windLoad.SnowLoadProvision = jtoken["SnowLoadProvision"].ToString();
                windLoad.GroundSnowLoad = jtoken["GroundSnowLoad"].ToString();
                windLoad.ExposureCategory = jtoken["ExposureCategory"].ToString();
                windLoad.TerrainCategory = jtoken["TerrainCategory"].ToString();

                return windLoad;
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LoadingInfo"]["SnowLoad"];
                jtoken["UseSnow"] = value.UseSnow;
                jtoken["SnowLoadProvision"] = value.SnowLoadProvision;
                jtoken["GroundSnowLoad"] = value.GroundSnowLoad;
                jtoken["ExposureCategory"] = value.ExposureCategory;
                jtoken["TerrainCategory"] = value.TerrainCategory;
            }
        }
        
        public string GirderLoading
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LoadingInfo"]["GirderLoad"];
                return jtoken["GirderLoading"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LoadingInfo"]["GirderLoad"];
                jtoken["GirderLoading"] = value;
            }
        }
        
        public List<KxrLoadCase> LoadCases
        {
            get
            {
                var returnList = new List<KxrLoadCase>();

                var jtoken = JsonContents.GetValue("TrussDetails")["LoadingInfo"]["LoadCases"]["LoadCase"];

                var children = jtoken.Children();

                foreach (var loadCaseToken in children)
                {
                    var testTokenString = loadCaseToken.ToString();
                    KxrLoadCase loadCaseToAdd = new KxrLoadCase();
                    loadCaseToAdd.MWFRS = loadCaseToken["@MWFRS"].ToString();
                    loadCaseToAdd.CC = loadCaseToken["@CC"].ToString();
                    loadCaseToAdd.Auto = loadCaseToken["@AUTO"].ToString();
                    loadCaseToAdd.User = loadCaseToken["@USER"].ToString();
                    loadCaseToAdd.Attic = loadCaseToken["@ATTIC"].ToString();
                    loadCaseToAdd.TTC = loadCaseToken["@TTC"].ToString();
                    loadCaseToAdd.AtticSto = loadCaseToken["@ATTIC_STO"].ToString();
                    loadCaseToAdd.InternalId = loadCaseToken["@InternalId"].ToString();
                    loadCaseToAdd.Id = loadCaseToken["Id"].ToString();
                    loadCaseToAdd.Description = loadCaseToken["Description"].ToString();
                    loadCaseToAdd.Type = loadCaseToken["Type"].ToString();
                    
                    returnList.Add(loadCaseToAdd);
                }


                var bearingCombos = new List<KxrBearingCombo>();

                return returnList;
            }
        }
        #endregion

        #region GeneralEngInfo
        public string BuildingCode
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"];
                return jtoken["BuildingCode"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"];
                jtoken["BuildingCode"] = value;
            }
        }

        public string WetService
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"];
                return jtoken["WetService"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"];
                jtoken["WetService"] = value;
            }
        }

        public string GreenLumber
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"];
                return jtoken["GreenLumber"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"];
                jtoken["GreenLumber"] = value;
            }
        }

        public string TCBracing
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"];
                return jtoken["TCBracing"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"];
                jtoken["TCBracing"] = value;
            }
        }

        public string BCBracing
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"];
                return jtoken["BCBracing"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"];
                jtoken["BCBracing"] = value;
            }
        }

        public string WebBracingAutomatic
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"]["WebBracing"]["Automatic"];
                var testStr = jtoken.ToString();
                return jtoken["#text"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"]["WebBracing"]["Automatic"];
                jtoken["text"] = value;
            }
        }

        public string WebBracingAutomaticContinuousLateral
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"]["WebBracing"]["Automatic"];
                var testStr = jtoken.ToString();
                return jtoken["@ContinuousLateral"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"]["WebBracing"]["Automatic"];
                jtoken["@ContinuousLateral"] = value;
            }
        }

        public string WebBracingAutomaticTeeBracing
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"]["WebBracing"]["Automatic"];
                var testStr = jtoken.ToString();
                return jtoken["@TeeBracing"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"]["WebBracing"]["Automatic"];
                jtoken["@TeeBracing"] = value;
            }
        }

        public KxrDeflectionCriteria RoofDeflectionCriteria
        {
            get
            {
                var deflection = new KxrDeflectionCriteria();
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"]["DeflectionCriteria"]["Roof"];
                deflection.LiveLoad = jtoken["LiveLoad"].ToString();
                deflection.TotalLoad = jtoken["TotalLoad"].ToString();
                deflection.Cantilever = jtoken["Cantilever"].ToString();
                deflection.Overhang = jtoken["Overhang"].ToString();

                return deflection;
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"]["DeflectionCriteria"]["Roof"];
                jtoken["LiveLoad"] = value.LiveLoad;
                jtoken["TotalLoad"] = value.TotalLoad;
                jtoken["Cantilever"] = value.Cantilever;
                jtoken["Overhang"] = value.Overhang;
            }
        }

        public KxrDeflectionCriteria FloorDeflectionCriteria
        {
            get
            {
                var deflection = new KxrDeflectionCriteria();
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"]["DeflectionCriteria"]["Floor"];
                deflection.LiveLoad = jtoken["LiveLoad"].ToString();
                deflection.TotalLoad = jtoken["TotalLoad"].ToString();
                deflection.Cantilever = jtoken["Cantilever"].ToString();
                deflection.Overhang = jtoken["Overhang"].ToString();

                return deflection;
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["GeneralEngInfo"]["DeflectionCriteria"]["Floor"];
                jtoken["LiveLoad"] = value.LiveLoad;
                jtoken["TotalLoad"] = value.TotalLoad;
                jtoken["Cantilever"] = value.Cantilever;
                jtoken["Overhang"] = value.Overhang;
            }
        }
        #endregion

        #region DesignInfo
        public string CSI
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["Pass-Fail"];
                return jtoken["CSI"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["Pass-Fail"];
                jtoken["CSI"] = value;
            }
        }

        public string Deflection
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["Pass-Fail"];
                return jtoken["Deflection"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["Pass-Fail"];
                jtoken["Deflection"] = value;
            }
        }

        public string Buckling
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["Pass-Fail"];
                return jtoken["Buckling"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["Pass-Fail"];
                jtoken["Buckling"] = value;
            }
        }

        public string Plating
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["Pass-Fail"];
                return jtoken["Plating"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["Pass-Fail"];
                jtoken["Plating"] = value;
            }
        }

        public string TotalBoardFootage
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["OverallTrussDesign"];
                return jtoken["TotalBoardFootage"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["OverallTrussDesign"];
                jtoken["TotalBoardFootage"] = value;
            }
        }
        
        public List<KxrBearingCombo2> Part2BearingCombos
        {
            get
            {
                var returnList = new List<KxrBearingCombo2>();

                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["OverallTrussDesign"]["BearingCombos"]["BearingCombo"];

                foreach (var bearingCombotoken in jtoken.Children())
                {
                    var bearingCombo = new KxrBearingCombo2();
                    bearingCombo.Bearings = new List<KxrBearing2>();
                    foreach (var bearingtoken in bearingCombotoken.Children().Children())
                    {
                        var bearing = new KxrBearing2();
                        bearing.MaxDownwardReaction = bearingtoken["MaxDownwardReaction"].ToString();
                        bearing.MaxUpliftReaction = bearingtoken["MaxUpliftReaction"].ToString();
                        bearing.MaxHorizReaction = bearingtoken["MaxHorizReaction"].ToString();
                        bearing.BearingEnhancementRequired = bearingtoken["BearingEnhancementRequired"].ToString();
                        bearing.Reactions = new List<KxrReaction>();
                        foreach(var reactionToken in bearingtoken["Reactions"]["LoadCase"])
                        {
                            var reactionToAdd = new KxrReaction();
                            var teststring2 = reactionToken.ToString();
                            reactionToAdd.InternalId = reactionToken["@InternalId"].ToString();
                            reactionToAdd.Horizontal = reactionToken["Horizontal"].ToString();
                            reactionToAdd.Vertical = reactionToken["Vertical"].ToString();
                            bearing.Reactions.Add(reactionToAdd);
                        }
                        bearingCombo.Bearings.Add(bearing);
                    }

                    returnList.Add(bearingCombo);
                }
                return returnList;
            }
        }

        public string OverallDeflectionMaxVertical
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["OverallTrussDesign"];
                return jtoken["OverallDeflection"]["MaxVertical"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["OverallTrussDesign"];
                jtoken["OverallDeflection"]["MaxVertical"] = value;
            }
        }

        public string OverallDeflectionMaxHorizontal
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["OverallTrussDesign"];
                return jtoken["OverallDeflection"]["MaxHorizontal"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["OverallTrussDesign"];
                jtoken["OverallDeflection"]["MaxHorizontal"] = value;
            }
        }

        public string TopChordDesignCriticalCSI
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["TopChordDesign"];
                return jtoken["CriticalCSI"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["TopChordDesign"];
                jtoken["CriticalCSI"] = value;
            }
        }

        public string TopChordDesignCriticalCSIMaterial
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["TopChordDesign"];
                return jtoken["CriticalCSIMaterial"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["TopChordDesign"];
                jtoken["CriticalCSIMaterial"] = value;
            }
        }

        public KxrDeflectionCriteria TopChordDesignMaxTCDeflection
        {
            get
            {
                var deflection = new KxrDeflectionCriteria();
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["TopChordDesign"]["MaxTCDeflection"];
                deflection.LiveLoad = jtoken["LiveLoad"].ToString();
                deflection.TotalLoad = jtoken["TotalLoad"].ToString();
                deflection.Cantilever = jtoken["Cantilever"].ToString();
                deflection.Overhang = jtoken["Overhang"].ToString();

                return deflection;
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["TopChordDesign"]["MaxTCDeflection"];
                jtoken["LiveLoad"] = value.LiveLoad;
                jtoken["TotalLoad"] = value.TotalLoad;
                jtoken["Cantilever"] = value.Cantilever;
                jtoken["Overhang"] = value.Overhang;
            }
        }

        public string TopChordDesignBoardFootage
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["TopChordDesign"];
                return jtoken["BoardFootage"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["TopChordDesign"];
                jtoken["BoardFootage"] = value;
            }
        }

        public string BottomChordDesignCriticalCSI
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["BottomChordDesign"];
                return jtoken["CriticalCSI"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["BottomChordDesign"];
                jtoken["CriticalCSI"] = value;
            }
        }

        public string BottomChordDesignCriticalCSIMaterial
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["BottomChordDesign"];
                return jtoken["CriticalCSIMaterial"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["BottomChordDesign"];
                jtoken["CriticalCSIMaterial"] = value;
            }
        }

        public KxrDeflectionCriteria BottomChordDesignMaxBCDeflection
        {
            get
            {
                var deflection = new KxrDeflectionCriteria();
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["BottomChordDesign"]["MaxBCDeflection"];
                deflection.LiveLoad = jtoken["LiveLoad"].ToString();
                deflection.TotalLoad = jtoken["TotalLoad"].ToString();
                deflection.Cantilever = jtoken["Cantilever"].ToString();
                deflection.Overhang = jtoken["Overhang"].ToString();

                return deflection;
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["BottomChordDesign"]["MaxBCDeflection"];
                jtoken["LiveLoad"] = value.LiveLoad;
                jtoken["TotalLoad"] = value.TotalLoad;
                jtoken["Cantilever"] = value.Cantilever;
                jtoken["Overhang"] = value.Overhang;
            }
        }

        public string BottomChordDesignBoardFootage
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["BottomChordDesign"];
                return jtoken["BoardFootage"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["BottomChordDesign"];
                jtoken["BoardFootage"] = value;
            }
        }

        public string WebDesignCriticalCSI
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["WebDesign"];
                return jtoken["CriticalCSI"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["WebDesign"];
                jtoken["CriticalCSI"] = value;
            }
        }

        public string WebDesignCriticalCSIMaterial
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["WebDesign"];
                return jtoken["CriticalCSIMaterial"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["WebDesign"];
                jtoken["CriticalCSIMaterial"] = value;
            }
        }

        public string WebDesignNumbBracedWebs
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["WebDesign"];
                return jtoken["NumbBracedWebs"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["WebDesign"];
                jtoken["NumbBracedWebs"] = value;
            }
        }

        public string WebDesignBoardFootage
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["WebDesign"];
                return jtoken["BoardFootage"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["WebDesign"];
                jtoken["BoardFootage"] = value;
            }
        }

        public string PlatingDesignManufacturer
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["PlatingDesign"];
                return jtoken["Manufacturer"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["PlatingDesign"];
                jtoken["Manufacturer"] = value;
            }
        }

        public string PlatingDesignTotalSquareInches
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["PlatingDesign"];
                return jtoken["SquareInches"]["Total_All"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["PlatingDesign"];
                jtoken["SquareInches"]["Total_All"] = value;
            }
        }

        public string PlatingDesignTotal_HS20ga
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["PlatingDesign"];
                return jtoken["SquareInches"]["Total_HS20ga"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["PlatingDesign"];
                jtoken["SquareInches"]["Total_HS20ga"] = value;
            }
        }

        public string PlatingDesignTotal_HS18ga
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["PlatingDesign"];
                return jtoken["SquareInches"]["Total_HS18ga"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["PlatingDesign"];
                jtoken["SquareInches"]["Total_HS18ga"] = value;
            }
        }

        public string PlatingDesignTotal_20ga
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["PlatingDesign"];
                return jtoken["SquareInches"]["Total_20ga"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["PlatingDesign"];
                jtoken["SquareInches"]["Total_20ga"] = value;
            }
        }

        public string PlatingDesignTotal_18ga
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["PlatingDesign"];
                return jtoken["SquareInches"]["Total_18ga"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["PlatingDesign"];
                jtoken["SquareInches"]["Total_18ga"] = value;
            }
        }

        public string PlatingDesignTotal_16ga
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["PlatingDesign"];
                return jtoken["SquareInches"]["Total_16ga"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["DesignInfo"]["PlatingDesign"];
                jtoken["SquareInches"]["Total_16ga"] = value;
            }
        }
        #endregion

        #region TwoDistancealInfo
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
        
        public List<KxrBearingCombo3> Part3BearingCombos
        {
            get
            {
                var returnList = new List<KxrBearingCombo3>();
                var jtoken = JsonContents.GetValue("TrussDetails")["TwoDistancealInfo"]["BearingCombos"]["BearingCombo"];
                foreach (var bearingComboToken in jtoken.Children().Children())
                {
                    var comboToAdd = new KxrBearingCombo3();
                    comboToAdd.Bearings = new List<KxrBearing3>();
                    foreach(var bearingToken in bearingComboToken["Bearing"].Children())
                    {
                        var bearingToAdd = new KxrBearing3();
                        bearingToAdd.BearingPoints = new List<KxrPoint>();
                        foreach (var pointToken in bearingToken["BrgPoints"]["Point"].Children())
                        {
                            var pointToAdd = new KxrPoint();
                            pointToAdd.X = pointToken["@X"].ToString();
                            pointToAdd.Y = pointToken["@Y"].ToString();
                            bearingToAdd.BearingPoints.Add(pointToAdd);
                        }
                        comboToAdd.Bearings.Add(bearingToAdd);
                    }
                    returnList.Add(comboToAdd);
                }

                return returnList;
            }
        }
        #endregion

        #region JigSettings
        public List<KxrJigPoint> JigPoints
        {
            get
            {
                var returnList = new List<KxrJigPoint>();
                var jtoken = JsonContents.GetValue("TrussDetails")["JigSettings"]["Point"];

                foreach (var pointSection in jtoken.Children())
                {
                    var point = new KxrJigPoint();
                    point.Type = pointSection["@Type"].ToString();
                    point.X = pointSection["@X"].ToString();
                    point.Y = pointSection["@Y"].ToString();

                    returnList.Add(point);
                }
                return returnList;
            }
        }
        #endregion

        #region LaborFactors
        public string LaborFactorsCantilever
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LaborFactors"];
                return jtoken["Cantilever"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LaborFactors"];
                jtoken["Cantilever"] = value;
            }
        }

        public string LaborFactorsEndDetailLeft
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LaborFactors"];
                return jtoken["EndDetailLeft"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LaborFactors"];
                jtoken["EndDetailLeft"] = value;
            }
        }

        public string LaborFactorsEndDetailRight
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LaborFactors"];
                return jtoken["EndDetailRight"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LaborFactors"];
                jtoken["EndDetailRight"] = value;
            }
        }

        public string LaborFactorsBeamPocket
        {
            get
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LaborFactors"];
                return jtoken["BeamPocket"].ToString();
            }
            set
            {
                var jtoken = JsonContents.GetValue("TrussDetails")["LaborFactors"];
                jtoken["BeamPocket"] = value;
            }
        }
        #endregion
    }
}
