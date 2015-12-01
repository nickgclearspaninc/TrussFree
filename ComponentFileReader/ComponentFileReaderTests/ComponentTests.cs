using System.Collections.Generic;
using System.Text;
using System.Xml;
using ComponentFileReader;
using ComponentFileReader.FileClasses.KxrComponent;
using ComponentFileReader.FileClasses.TreComponent;
using ComponentFileReader.FileClasses.TrsComponent;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace ComponentFileReaderTests
{
    [TestFixture()]
    public class ComponentTests
    {
        [Test()]
        public void Component_JSON()
        {
            Component component = new Component(new List<Member>(), new List<Bearing>(), new List<PlateConnector>(), ComponentType.Roof,"test truss");

            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(component, jsonSettings);
            Component deserializedComponent = JsonConvert.DeserializeObject<Component>(json, jsonSettings);
            
            bool sameName = (component.Name == deserializedComponent.Name);
            bool sameMembers = (component.Members.Count == deserializedComponent.Members.Count);
            bool samePlates = (component.PlateConnectors.Count == deserializedComponent.PlateConnectors.Count);
            bool sameBearings = (component.Bearings.Count == deserializedComponent.Bearings.Count);


            (sameName && sameMembers && samePlates && sameBearings).Should().BeTrue();
        }

        [Test()]
        public void Parse_Kxr()
        {
            KxrComponent component = new KxrComponent(Encoding.UTF8.GetString(ComponentFiles.eagle));
            
            #region First Truss Details
            component.ComponentFunctions.Count.Should().Be(0);
            component.Members.Count.Should().Be(9);

            component.Name.Should().Be("eagle");
            component.AppVersion.Should().Be("Truss v5.03 [Build 0030]");
            component.XmlVersion.Should().Be("10");
            component.ComponentType.Should().Be(ComponentType.Roof);
            component.TrussFamily.Should().Be("1");
            component.Span.Should().Be("288.000000");
            component.Pitch.Should().Be("4 /12");
            component.Quantity.Should().Be("1");
            component.PricingQuantity.Should().Be("0");
            component.LtOverhang.Should().Be("0.000000");
            component.RtOverhang.Should().Be("0.000000");
            component.LtHeelHeight.Should().Be("3.939324");
            component.RtHeelHeight.Should().Be("3.939324");
            component.OverallHeight.Should().Be("51.939324");
            component.Plies.Should().Be("1");
            component.WeightPerPly.Should().Be("83");
            component.Spacing.Should().Be("24");
            #endregion

            #region BearingCombos
            component.Part1BearingCombos.Count.Should().Be(1);
            #endregion

            #region TrussType
            component.TrussTypes.Gable.Should().Be("N");
            component.TrussTypes.Girder.Should().Be("N");
            component.TrussTypes.Hip.Should().Be("N");
            component.TrussTypes.Jack.Should().Be("N");
            component.TrussTypes.Rafter.Should().Be("N");
            component.TrussTypes.Attic.Should().Be("N");
            component.TrussTypes.Ag.Should().Be("N");
            component.TrussTypes.Reversed.Should().Be("N");
            component.TrussTypes.StructGable.Should().Be("N");
            #endregion

            #region LoadingInfo
            component.StandardLoading.TCLive.Should().Be("20.000");
            component.StandardLoading.TCDead.Should().Be("10.000");
            component.StandardLoading.BCLive.Should().Be("0.000");
            component.StandardLoading.BCDead.Should().Be("10.000");
            component.BuildingStandardLoading.TCLive.Should().Be("20.000");
            component.BuildingStandardLoading.TCDead.Should().Be("10.000");
            component.BuildingStandardLoading.BCLive.Should().Be("0.000");
            component.BuildingStandardLoading.BCDead.Should().Be("10.000");
            component.AutomatedLiveLoadsRoofLiveLoadProvision.Should().Be("IBC 2009");
            component.WindLoad.UseWind.Should().Be("Y");
            component.WindLoad.WindLoadProvision.Should().Be("ASCE7 - 05");
            component.WindLoad.WindSpeed.Should().Be("90");
            component.WindLoad.ExposureCategory.Should().Be("C");
            component.WindLoad.BuildingCategory.Should().Be("II");
            component.WindLoad.HurricaneRegion.Should().Be("N");
            component.SnowLoad.UseSnow.Should().Be("Y");
            component.SnowLoad.SnowLoadProvision.Should().Be("ASCE7 - 05");
            component.SnowLoad.GroundSnowLoad.Should().Be("30");
            component.SnowLoad.ExposureCategory.Should().Be("Partial");
            component.SnowLoad.TerrainCategory.Should().Be("Unheated");
            component.GirderLoading.Should().Be("NoOne");
            component.LoadCases.Count.Should().Be(16);
            #endregion

            #region GeneralEngInfo
            component.BuildingCode.Should().Be("IBC 2009");
            component.WetService.Should().Be("N");
            component.GreenLumber.Should().Be("N");
            component.TCBracing.Should().Be("Sheathed");
            component.BCBracing.Should().Be("Sheathed");
            component.WebBracingAutomatic.Should().Be("Y");
            component.WebBracingAutomaticContinuousLateral.Should().Be("Y");
            component.WebBracingAutomaticTeeBracing.Should().Be("N");
            component.RoofDeflectionCriteria.LiveLoad.Should().Be("360");
            component.RoofDeflectionCriteria.TotalLoad.Should().Be("240");
            component.RoofDeflectionCriteria.Cantilever.Should().Be("480");
            component.RoofDeflectionCriteria.Overhang.Should().Be("120");
            component.FloorDeflectionCriteria.LiveLoad.Should().Be("480");
            component.FloorDeflectionCriteria.TotalLoad.Should().Be("360");
            component.FloorDeflectionCriteria.Cantilever.Should().Be("720");
            component.FloorDeflectionCriteria.Overhang.Should().Be("240");
            #endregion

            #region DesignInfo
            component.CSI.Should().Be("PASSED");
            component.Deflection.Should().Be("PASSED");
            component.Buckling.Should().Be("TODO");
            component.Deflection.Should().Be("PASSED");
            component.TotalBoardFootage.Should().Be("48.000000");
            component.Part2BearingCombos.Count.Should().Be(1);
            component.OverallDeflectionMaxVertical.Should().Be("-0.129231");
            component.OverallDeflectionMaxHorizontal.Should().Be("0.075657");
            component.TopChordDesignCriticalCSI.Should().Be("0.520");
            component.TopChordDesignCriticalCSIMaterial.Should().Be("TODO");
            component.TopChordDesignMaxTCDeflection.LiveLoad.Should().Be("-0.052281");
            component.TopChordDesignMaxTCDeflection.TotalLoad.Should().Be("-0.129231");
            component.TopChordDesignMaxTCDeflection.Cantilever.Should().Be("0.000000");
            component.TopChordDesignMaxTCDeflection.Overhang.Should().Be("0.000000");
            component.TopChordDesignBoardFootage.Should().Be("18.666667");
            component.BottomChordDesignCriticalCSI.Should().Be("0.655");
            component.BottomChordDesignCriticalCSIMaterial.Should().Be("TODO");
            component.BottomChordDesignMaxBCDeflection.LiveLoad.Should().Be("-0.103727");
            component.BottomChordDesignMaxBCDeflection.TotalLoad.Should().Be("-0.249638");
            component.BottomChordDesignMaxBCDeflection.Cantilever.Should().Be("0.000000");
            component.BottomChordDesignMaxBCDeflection.Overhang.Should().Be("0.000000");
            component.BottomChordDesignBoardFootage.Should().Be("16.000000");
            component.WebDesignCriticalCSI.Should().Be("0.442");
            component.WebDesignCriticalCSIMaterial.Should().Be("TODO");
            component.WebDesignNumbBracedWebs.Should().Be("4");
            component.WebDesignBoardFootage.Should().Be("13.333333");
            component.PlatingDesignManufacturer.Should().Be("Eagle Metal");
            component.PlatingDesignTotalSquareInches.Should().Be("288.000000");
            component.PlatingDesignTotal_HS20ga.Should().Be("0.000000");
            component.PlatingDesignTotal_HS18ga.Should().Be("0.000000");
            component.PlatingDesignTotal_20ga.Should().Be("288.000000");
            component.PlatingDesignTotal_18ga.Should().Be("0.000000");
            component.PlatingDesignTotal_16ga.Should().Be("0.000000");
            #endregion

            #region TwoDistancealInfo
            component.ZWidth.Should().Be("1.500000");
            component.Plates.Count.Should().Be(9);
            component.Pieces.Count.Should().Be(9);
            component.Part3BearingCombos.Count.Should().Be(1);
            #endregion

            #region JigSettings
            component.JigPoints.Count.Should().Be(11);
            #endregion

            #region LaborFactors
            component.LaborFactorsCantilever.Should().Be("0");
            component.LaborFactorsEndDetailLeft.Should().Be("0");
            component.LaborFactorsEndDetailRight.Should().Be("0");
            component.LaborFactorsBeamPocket.Should().Be("N");
            #endregion
        }
        [Test()]
        public void Write_Kxr()
        {
            KxrComponent component = new KxrComponent(Encoding.UTF8.GetString(ComponentFiles.eagle));

            #region First Truss Details
            component.Name = "testkxr";
            //ToDo: List component.ComponentFunctions.Count.Should().Be(0);
            //ToDo: List component.Members.Count.Should().Be(9);
            component.AppVersion = "N64";
            component.XmlVersion = "N64";
            component.ComponentType = ComponentType.Floor;
            component.TrussFamily = "N64";
            component.Span = "N64";
            component.Pitch = "N64";
            component.Quantity = "N64";
            component.PricingQuantity = "N64";
            component.LtOverhang = "N64";
            component.RtOverhang = "N64";
            component.LtHeelHeight = "N64";
            component.RtHeelHeight = "N64";
            component.OverallHeight = "N64";
            component.Plies = "N64";
            component.WeightPerPly = "N64";
            component.Spacing = "N64";
            
            component.Name.Should().Be("testkxr");
            component.AppVersion.Should().Be("N64");
            component.XmlVersion.Should().Be("N64");
            component.ComponentType.Should().Be(ComponentType.Floor);
            component.TrussFamily.Should().Be("N64");
            component.Span.Should().Be("N64");
            component.Pitch.Should().Be("N64");
            component.Quantity.Should().Be("N64");
            component.PricingQuantity.Should().Be("N64");
            component.LtOverhang.Should().Be("N64");
            component.RtOverhang.Should().Be("N64");
            component.LtHeelHeight.Should().Be("N64");
            component.RtHeelHeight.Should().Be("N64");
            component.OverallHeight.Should().Be("N64");
            component.Plies.Should().Be("N64");
            component.WeightPerPly.Should().Be("N64");
            component.Spacing.Should().Be("N64");
            #endregion

            #region BearingCombos
            /* ToDo: List
            var testBearingCombo = new KxrComponent.KxrBearingCombo();
            testBearingCombo.Bearings = new List<KxrComponent.KxrBearing>();
            var testBearing = new KxrComponent.KxrBearing();
            testBearing.Width = "N64";
            testBearing.Continuous = "N64";
            testBearing.Fixity = "N64";
            testBearing.Type = "N64";
            testBearing.LocationX = "N64";
            testBearing.LocationY = "N64";
            testBearing.Member = "N64";
            testBearingCombo.Bearings.Add(testBearing);
            component.Part1BearingCombos = new List<KxrComponent.KxrBearingCombo> { testBearingCombo };

            component.Part1BearingCombos[0].Bearings[0].Width.Should().Be("N64");
            component.Part1BearingCombos[0].Bearings[0].Continuous.Should().Be("N64");
            component.Part1BearingCombos[0].Bearings[0].Fixity.Should().Be("N64");
            component.Part1BearingCombos[0].Bearings[0].Type.Should().Be("N64");
            component.Part1BearingCombos[0].Bearings[0].LocationX.Should().Be("N64");
            component.Part1BearingCombos[0].Bearings[0].LocationY.Should().Be("N64");
            component.Part1BearingCombos[0].Bearings[0].Member.Should().Be("N64");
            */
            #endregion

            #region TrussType
            var testTrussType = new KxrComponent.KxrTrussType();
            testTrussType.Gable = "N64";
            testTrussType.Girder = "N64";
            testTrussType.Hip = "N64";
            testTrussType.Jack = "N64";
            testTrussType.Rafter = "N64";
            testTrussType.Attic = "N64";
            testTrussType.Ag = "N64";
            testTrussType.Reversed = "N64";
            testTrussType.StructGable = "N64";
            component.TrussTypes = testTrussType;
            #endregion

            #region LoadingInfo
            var testStandardLoading = new KxrComponent.KxrStandardLoading();
            testStandardLoading.TCLive = "N64";
            testStandardLoading.TCDead = "N64";
            testStandardLoading.BCLive = "N64";
            testStandardLoading.BCDead = "N64";
            component.StandardLoading = testStandardLoading;
            var testBuildingStandardLoading = new KxrComponent.KxrStandardLoading();
            testBuildingStandardLoading.TCLive = "N64";
            testBuildingStandardLoading.TCDead = "N64";
            testBuildingStandardLoading.BCLive = "N64";
            testBuildingStandardLoading.BCDead = "N64";
            component.BuildingStandardLoading = testBuildingStandardLoading;
            component.AutomatedLiveLoadsRoofLiveLoadProvision = "N64";
            var testWindLoad = new KxrComponent.KxrWindLoad();
            testWindLoad.UseWind = "N64";
            testWindLoad.WindLoadProvision = "N64";
            testWindLoad.WindSpeed = "N64";
            testWindLoad.ExposureCategory = "N64";
            testWindLoad.BuildingCategory = "N64";
            testWindLoad.HurricaneRegion = "N64";
            component.WindLoad = testWindLoad;
            var testSnowLoad = new KxrComponent.KxrSnowLoad();
            testSnowLoad.UseSnow = "N64";
            testSnowLoad.SnowLoadProvision = "N64";
            testSnowLoad.GroundSnowLoad = "N64";
            testSnowLoad.ExposureCategory = "N64";
            testSnowLoad.TerrainCategory = "N64";
            component.SnowLoad = testSnowLoad;
            component.GirderLoading = "N64";
            //ToDo: List component.LoadCases

            component.StandardLoading.TCLive.Should().Be("N64");
            component.StandardLoading.TCDead.Should().Be("N64");
            component.StandardLoading.BCLive.Should().Be("N64");
            component.StandardLoading.BCDead.Should().Be("N64");
            component.BuildingStandardLoading.TCLive.Should().Be("N64");
            component.BuildingStandardLoading.TCDead.Should().Be("N64");
            component.BuildingStandardLoading.BCLive.Should().Be("N64");
            component.BuildingStandardLoading.BCDead.Should().Be("N64");
            component.AutomatedLiveLoadsRoofLiveLoadProvision.Should().Be("N64");
            component.WindLoad.UseWind.Should().Be("N64");
            component.WindLoad.WindLoadProvision.Should().Be("N64");
            component.WindLoad.WindSpeed.Should().Be("N64");
            component.WindLoad.ExposureCategory.Should().Be("N64");
            component.WindLoad.BuildingCategory.Should().Be("N64");
            component.WindLoad.HurricaneRegion.Should().Be("N64");
            component.SnowLoad.UseSnow.Should().Be("N64");
            component.SnowLoad.SnowLoadProvision.Should().Be("N64");
            component.SnowLoad.GroundSnowLoad.Should().Be("N64");
            component.SnowLoad.ExposureCategory.Should().Be("N64");
            component.SnowLoad.TerrainCategory.Should().Be("N64");
            component.GirderLoading.Should().Be("N64");
            #endregion

            #region GeneralEngInfo
            component.BuildingCode = "N64";
            component.WetService = "N64";
            component.GreenLumber = "N64";
            component.TCBracing = "N64";
            component.BCBracing = "N64";
            component.WebBracingAutomatic = "N64";
            component.WebBracingAutomaticContinuousLateral = "N64";
            component.WebBracingAutomaticTeeBracing = "N64";
            var testRoofDeflectionCriteria = new KxrComponent.KxrDeflectionCriteria();
            testRoofDeflectionCriteria.LiveLoad = "N64";
            testRoofDeflectionCriteria.TotalLoad = "N64";
            testRoofDeflectionCriteria.Cantilever = "N64";
            testRoofDeflectionCriteria.Overhang = "N64";
            component.RoofDeflectionCriteria = testRoofDeflectionCriteria;
            var testFloorDeflectionCriteria = new KxrComponent.KxrDeflectionCriteria();
            testFloorDeflectionCriteria.LiveLoad = "N64";
            testFloorDeflectionCriteria.TotalLoad = "N64";
            testFloorDeflectionCriteria.Cantilever = "N64";
            testFloorDeflectionCriteria.Overhang = "N64";
            component.FloorDeflectionCriteria = testFloorDeflectionCriteria;

            component.BuildingCode.Should().Be("N64");
            component.WetService.Should().Be("N64");
            component.GreenLumber.Should().Be("N64");
            component.TCBracing.Should().Be("N64");
            component.BCBracing.Should().Be("N64");
            //ToDo: Fix component.WebBracingAutomatic.Should().Be("N64");
            //ToDo: Fix component.WebBracingAutomaticContinuousLateral.Should().Be("N64");
            //ToDo: Fix component.WebBracingAutomaticTeeBracing.Should().Be("N64");
            component.RoofDeflectionCriteria.LiveLoad.Should().Be("N64");
            component.RoofDeflectionCriteria.TotalLoad.Should().Be("N64");
            component.RoofDeflectionCriteria.Cantilever.Should().Be("N64");
            component.RoofDeflectionCriteria.Overhang.Should().Be("N64");
            component.FloorDeflectionCriteria.LiveLoad.Should().Be("N64");
            component.FloorDeflectionCriteria.TotalLoad.Should().Be("N64");
            component.FloorDeflectionCriteria.Cantilever.Should().Be("N64");
            component.FloorDeflectionCriteria.Overhang.Should().Be("N64");
            #endregion

            #region DesignInfo
            component.CSI = "N64";
            component.Deflection = "N64";
            component.Buckling = "N64";
            component.TotalBoardFootage = "N64";
            //ToDo: Part2BearingCombos
            component.OverallDeflectionMaxVertical = "N64";
            component.OverallDeflectionMaxHorizontal = "N64";
            component.TopChordDesignCriticalCSI = "N64";
            component.TopChordDesignCriticalCSIMaterial = "N64";
            var testTopChordDesignMaxTCDeflection = new KxrComponent.KxrDeflectionCriteria();
            testTopChordDesignMaxTCDeflection.LiveLoad = "N64";
            testTopChordDesignMaxTCDeflection.TotalLoad = "N64";
            testTopChordDesignMaxTCDeflection.Cantilever = "N64";
            testTopChordDesignMaxTCDeflection.Overhang = "N64";
            component.TopChordDesignMaxTCDeflection = testTopChordDesignMaxTCDeflection;
            component.TopChordDesignBoardFootage = "N64";
            component.BottomChordDesignCriticalCSI = "N64";
            component.BottomChordDesignCriticalCSIMaterial = "N64";
            var testBottomChordDesignMaxBCDeflection = new KxrComponent.KxrDeflectionCriteria();
            testBottomChordDesignMaxBCDeflection.LiveLoad = "N64";
            testBottomChordDesignMaxBCDeflection.TotalLoad = "N64";
            testBottomChordDesignMaxBCDeflection.Cantilever = "N64";
            testBottomChordDesignMaxBCDeflection.Overhang = "N64";
            component.BottomChordDesignMaxBCDeflection = testBottomChordDesignMaxBCDeflection;
            component.BottomChordDesignBoardFootage = "N64";
            component.WebDesignCriticalCSI = "N64";
            component.WebDesignCriticalCSIMaterial = "N64";
            component.WebDesignNumbBracedWebs = "N64";
            component.WebDesignBoardFootage = "N64";
            component.PlatingDesignManufacturer = "N64";
            component.PlatingDesignTotalSquareInches = "N64";
            component.PlatingDesignTotal_HS20ga = "N64";
            component.PlatingDesignTotal_HS18ga = "N64";
            component.PlatingDesignTotal_20ga = "N64";
            component.PlatingDesignTotal_18ga = "N64";
            component.PlatingDesignTotal_16ga = "N64";

            component.CSI.Should().Be("N64");
            component.Deflection.Should().Be("N64");
            component.Buckling.Should().Be("N64");
            component.TotalBoardFootage.Should().Be("N64");
            component.Part2BearingCombos.Count.Should().Be(1);
            component.OverallDeflectionMaxVertical.Should().Be("N64");
            component.OverallDeflectionMaxHorizontal.Should().Be("N64");
            component.TopChordDesignCriticalCSI.Should().Be("N64");
            component.TopChordDesignCriticalCSIMaterial.Should().Be("N64");
            component.TopChordDesignMaxTCDeflection.LiveLoad.Should().Be("N64");
            component.TopChordDesignMaxTCDeflection.TotalLoad.Should().Be("N64");
            component.TopChordDesignMaxTCDeflection.Cantilever.Should().Be("N64");
            component.TopChordDesignMaxTCDeflection.Overhang.Should().Be("N64");
            component.TopChordDesignBoardFootage.Should().Be("N64");
            component.BottomChordDesignCriticalCSI.Should().Be("N64");
            component.BottomChordDesignCriticalCSIMaterial.Should().Be("N64");
            component.BottomChordDesignMaxBCDeflection.LiveLoad.Should().Be("N64");
            component.BottomChordDesignMaxBCDeflection.TotalLoad.Should().Be("N64");
            component.BottomChordDesignMaxBCDeflection.Cantilever.Should().Be("N64");
            component.BottomChordDesignMaxBCDeflection.Overhang.Should().Be("N64");
            component.BottomChordDesignBoardFootage.Should().Be("N64");
            component.WebDesignCriticalCSI.Should().Be("N64");
            component.WebDesignCriticalCSIMaterial.Should().Be("N64");
            component.WebDesignNumbBracedWebs.Should().Be("N64");
            component.WebDesignBoardFootage.Should().Be("N64");
            component.PlatingDesignManufacturer.Should().Be("N64");
            component.PlatingDesignTotalSquareInches.Should().Be("N64");
            component.PlatingDesignTotal_HS20ga.Should().Be("N64");
            component.PlatingDesignTotal_HS18ga.Should().Be("N64");
            component.PlatingDesignTotal_20ga.Should().Be("N64");
            component.PlatingDesignTotal_18ga.Should().Be("N64");
            component.PlatingDesignTotal_16ga.Should().Be("N64");
            #endregion

            #region TwoDistancealInfo
            component.ZWidth = "N64";
            //ToDo: List
            //ToDo: List
            //ToDo: List

            component.ZWidth.Should().Be("N64");
            //ToDo: component.Plates.Count.Should().Be(9);
            //ToDo: component.Pieces.Count.Should().Be(9);
            //ToDo: component.Part3BearingCombos.Count.Should().Be(1);
            #endregion

            #region JigSettings
            //ToDo: component.JigPoints.Count.Should().Be(11);
            #endregion

            #region LaborFactors
            component.LaborFactorsCantilever = "N64";
            component.LaborFactorsEndDetailLeft = "N64";
            component.LaborFactorsEndDetailRight = "N64";
            component.LaborFactorsBeamPocket = "N64";

            component.LaborFactorsCantilever.Should().Be("N64");
            component.LaborFactorsEndDetailLeft.Should().Be("N64");
            component.LaborFactorsEndDetailRight.Should().Be("N64");
            component.LaborFactorsBeamPocket.Should().Be("N64");
            #endregion
        }
        [Test()]
        public void ReadWrtieCompareWithOriginal_Kxr()
        {
            KxrComponent component = new KxrComponent(Encoding.UTF8.GetString(ComponentFiles.eagle));

            component.Name.Should().Be("eagle");

            XmlDocument output = new XmlDocument();

            output = component.GetXML();

            KxrComponent outputComponent = new KxrComponent(output.OuterXml);

            outputComponent.Name.Should().Be("eagle");
            outputComponent.AppVersion.Should().Be("Truss v5.03 [Build 0030]");
            outputComponent.XmlVersion.Should().Be("10");
            outputComponent.ComponentType.Should().Be(ComponentType.Roof);
            outputComponent.TrussFamily.Should().Be("1");
            outputComponent.Span.Should().Be("288.000000");
            outputComponent.Pitch.Should().Be("4 /12");
            outputComponent.Quantity.Should().Be("1");
            outputComponent.PricingQuantity.Should().Be("0");
            outputComponent.LtOverhang.Should().Be("0.000000");
            outputComponent.RtOverhang.Should().Be("0.000000");
            outputComponent.LtHeelHeight.Should().Be("3.939324");
            outputComponent.RtHeelHeight.Should().Be("3.939324");
            outputComponent.Plies.Should().Be("1");
            outputComponent.WeightPerPly.Should().Be("83");
            outputComponent.Spacing.Should().Be("24");
            outputComponent.ComponentFunctions.Count.Should().Be(0);
        }

        [Test()] public void WriteToFile_Kxr()
        {
            KxrComponent component = new KxrComponent(Encoding.UTF8.GetString(ComponentFiles.eagle));

            component.Name = "changedName";

            XmlDocument output = new XmlDocument();

            output = component.GetXML();

            using (XmlWriter writer = XmlWriter.Create("modified.kxr"))
            {
                writer.WriteRaw(output.OuterXml);
            }
        }

        [Test()]
        public void Parse_Tre()
        {
            Component component = new TreComponent(Encoding.UTF8.GetString(ComponentFiles.mitek));
            Assert.Fail();
        }

        [Test()]
        public void Parse_Trs()
        {
            Component component = new TrsComponent().Parse(Encoding.UTF8.GetString(ComponentFiles.computruss));
            Assert.Fail();
        }
    }
}
