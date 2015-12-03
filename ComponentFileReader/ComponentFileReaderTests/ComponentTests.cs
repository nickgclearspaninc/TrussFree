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
            component.AppVersion = "TEST";
            component.XmlVersion = "TEST";
            component.ComponentType = ComponentType.Floor;
            component.TrussFamily = "TEST";
            component.Span = "TEST";
            component.Pitch = "TEST";
            component.Quantity = "TEST";
            component.PricingQuantity = "TEST";
            component.LtOverhang = "TEST";
            component.RtOverhang = "TEST";
            component.LtHeelHeight = "TEST";
            component.RtHeelHeight = "TEST";
            component.OverallHeight = "TEST";
            component.Plies = "TEST";
            component.WeightPerPly = "TEST";
            component.Spacing = "TEST";
            
            component.Name.Should().Be("testkxr");
            component.AppVersion.Should().Be("TEST");
            component.XmlVersion.Should().Be("TEST");
            component.ComponentType.Should().Be(ComponentType.Floor);
            component.TrussFamily.Should().Be("TEST");
            component.Span.Should().Be("TEST");
            component.Pitch.Should().Be("TEST");
            component.Quantity.Should().Be("TEST");
            component.PricingQuantity.Should().Be("TEST");
            component.LtOverhang.Should().Be("TEST");
            component.RtOverhang.Should().Be("TEST");
            component.LtHeelHeight.Should().Be("TEST");
            component.RtHeelHeight.Should().Be("TEST");
            component.OverallHeight.Should().Be("TEST");
            component.Plies.Should().Be("TEST");
            component.WeightPerPly.Should().Be("TEST");
            component.Spacing.Should().Be("TEST");
            #endregion

            #region BearingCombos
            /* ToDo: List
            var testBearingCombo = new KxrComponent.KxrBearingCombo();
            testBearingCombo.Bearings = new List<KxrComponent.KxrBearing>();
            var testBearing = new KxrComponent.KxrBearing();
            testBearing.Width = "TEST";
            testBearing.Continuous = "TEST";
            testBearing.Fixity = "TEST";
            testBearing.Type = "TEST";
            testBearing.LocationX = "TEST";
            testBearing.LocationY = "TEST";
            testBearing.Member = "TEST";
            testBearingCombo.Bearings.Add(testBearing);
            component.Part1BearingCombos = new List<KxrComponent.KxrBearingCombo> { testBearingCombo };

            component.Part1BearingCombos[0].Bearings[0].Width.Should().Be("TEST");
            component.Part1BearingCombos[0].Bearings[0].Continuous.Should().Be("TEST");
            component.Part1BearingCombos[0].Bearings[0].Fixity.Should().Be("TEST");
            component.Part1BearingCombos[0].Bearings[0].Type.Should().Be("TEST");
            component.Part1BearingCombos[0].Bearings[0].LocationX.Should().Be("TEST");
            component.Part1BearingCombos[0].Bearings[0].LocationY.Should().Be("TEST");
            component.Part1BearingCombos[0].Bearings[0].Member.Should().Be("TEST");
            */
            #endregion

            #region TrussType
            var testTrussType = new KxrComponent.KxrTrussType();
            testTrussType.Gable = "TEST";
            testTrussType.Girder = "TEST";
            testTrussType.Hip = "TEST";
            testTrussType.Jack = "TEST";
            testTrussType.Rafter = "TEST";
            testTrussType.Attic = "TEST";
            testTrussType.Ag = "TEST";
            testTrussType.Reversed = "TEST";
            testTrussType.StructGable = "TEST";
            component.TrussTypes = testTrussType;
            #endregion

            #region LoadingInfo
            var testStandardLoading = new KxrComponent.KxrStandardLoading();
            testStandardLoading.TCLive = "TEST";
            testStandardLoading.TCDead = "TEST";
            testStandardLoading.BCLive = "TEST";
            testStandardLoading.BCDead = "TEST";
            component.StandardLoading = testStandardLoading;
            var testBuildingStandardLoading = new KxrComponent.KxrStandardLoading();
            testBuildingStandardLoading.TCLive = "TEST";
            testBuildingStandardLoading.TCDead = "TEST";
            testBuildingStandardLoading.BCLive = "TEST";
            testBuildingStandardLoading.BCDead = "TEST";
            component.BuildingStandardLoading = testBuildingStandardLoading;
            component.AutomatedLiveLoadsRoofLiveLoadProvision = "TEST";
            var testWindLoad = new KxrComponent.KxrWindLoad();
            testWindLoad.UseWind = "TEST";
            testWindLoad.WindLoadProvision = "TEST";
            testWindLoad.WindSpeed = "TEST";
            testWindLoad.ExposureCategory = "TEST";
            testWindLoad.BuildingCategory = "TEST";
            testWindLoad.HurricaneRegion = "TEST";
            component.WindLoad = testWindLoad;
            var testSnowLoad = new KxrComponent.KxrSnowLoad();
            testSnowLoad.UseSnow = "TEST";
            testSnowLoad.SnowLoadProvision = "TEST";
            testSnowLoad.GroundSnowLoad = "TEST";
            testSnowLoad.ExposureCategory = "TEST";
            testSnowLoad.TerrainCategory = "TEST";
            component.SnowLoad = testSnowLoad;
            component.GirderLoading = "TEST";
            //ToDo: List component.LoadCases

            component.StandardLoading.TCLive.Should().Be("TEST");
            component.StandardLoading.TCDead.Should().Be("TEST");
            component.StandardLoading.BCLive.Should().Be("TEST");
            component.StandardLoading.BCDead.Should().Be("TEST");
            component.BuildingStandardLoading.TCLive.Should().Be("TEST");
            component.BuildingStandardLoading.TCDead.Should().Be("TEST");
            component.BuildingStandardLoading.BCLive.Should().Be("TEST");
            component.BuildingStandardLoading.BCDead.Should().Be("TEST");
            component.AutomatedLiveLoadsRoofLiveLoadProvision.Should().Be("TEST");
            component.WindLoad.UseWind.Should().Be("TEST");
            component.WindLoad.WindLoadProvision.Should().Be("TEST");
            component.WindLoad.WindSpeed.Should().Be("TEST");
            component.WindLoad.ExposureCategory.Should().Be("TEST");
            component.WindLoad.BuildingCategory.Should().Be("TEST");
            component.WindLoad.HurricaneRegion.Should().Be("TEST");
            component.SnowLoad.UseSnow.Should().Be("TEST");
            component.SnowLoad.SnowLoadProvision.Should().Be("TEST");
            component.SnowLoad.GroundSnowLoad.Should().Be("TEST");
            component.SnowLoad.ExposureCategory.Should().Be("TEST");
            component.SnowLoad.TerrainCategory.Should().Be("TEST");
            component.GirderLoading.Should().Be("TEST");
            #endregion

            #region GeneralEngInfo
            component.BuildingCode = "TEST";
            component.WetService = "TEST";
            component.GreenLumber = "TEST";
            component.TCBracing = "TEST";
            component.BCBracing = "TEST";
            component.WebBracingAutomatic = "TEST";
            component.WebBracingAutomaticContinuousLateral = "TEST";
            component.WebBracingAutomaticTeeBracing = "TEST";
            var testRoofDeflectionCriteria = new KxrComponent.KxrDeflectionCriteria();
            testRoofDeflectionCriteria.LiveLoad = "TEST";
            testRoofDeflectionCriteria.TotalLoad = "TEST";
            testRoofDeflectionCriteria.Cantilever = "TEST";
            testRoofDeflectionCriteria.Overhang = "TEST";
            component.RoofDeflectionCriteria = testRoofDeflectionCriteria;
            var testFloorDeflectionCriteria = new KxrComponent.KxrDeflectionCriteria();
            testFloorDeflectionCriteria.LiveLoad = "TEST";
            testFloorDeflectionCriteria.TotalLoad = "TEST";
            testFloorDeflectionCriteria.Cantilever = "TEST";
            testFloorDeflectionCriteria.Overhang = "TEST";
            component.FloorDeflectionCriteria = testFloorDeflectionCriteria;

            component.BuildingCode.Should().Be("TEST");
            component.WetService.Should().Be("TEST");
            component.GreenLumber.Should().Be("TEST");
            component.TCBracing.Should().Be("TEST");
            component.BCBracing.Should().Be("TEST");
            //ToDo: Fix component.WebBracingAutomatic.Should().Be("TEST");
            //ToDo: Fix component.WebBracingAutomaticContinuousLateral.Should().Be("TEST");
            //ToDo: Fix component.WebBracingAutomaticTeeBracing.Should().Be("TEST");
            component.RoofDeflectionCriteria.LiveLoad.Should().Be("TEST");
            component.RoofDeflectionCriteria.TotalLoad.Should().Be("TEST");
            component.RoofDeflectionCriteria.Cantilever.Should().Be("TEST");
            component.RoofDeflectionCriteria.Overhang.Should().Be("TEST");
            component.FloorDeflectionCriteria.LiveLoad.Should().Be("TEST");
            component.FloorDeflectionCriteria.TotalLoad.Should().Be("TEST");
            component.FloorDeflectionCriteria.Cantilever.Should().Be("TEST");
            component.FloorDeflectionCriteria.Overhang.Should().Be("TEST");
            #endregion

            #region DesignInfo
            component.CSI = "TEST";
            component.Deflection = "TEST";
            component.Buckling = "TEST";
            component.TotalBoardFootage = "TEST";
            //ToDo: Part2BearingCombos
            component.OverallDeflectionMaxVertical = "TEST";
            component.OverallDeflectionMaxHorizontal = "TEST";
            component.TopChordDesignCriticalCSI = "TEST";
            component.TopChordDesignCriticalCSIMaterial = "TEST";
            var testTopChordDesignMaxTCDeflection = new KxrComponent.KxrDeflectionCriteria();
            testTopChordDesignMaxTCDeflection.LiveLoad = "TEST";
            testTopChordDesignMaxTCDeflection.TotalLoad = "TEST";
            testTopChordDesignMaxTCDeflection.Cantilever = "TEST";
            testTopChordDesignMaxTCDeflection.Overhang = "TEST";
            component.TopChordDesignMaxTCDeflection = testTopChordDesignMaxTCDeflection;
            component.TopChordDesignBoardFootage = "TEST";
            component.BottomChordDesignCriticalCSI = "TEST";
            component.BottomChordDesignCriticalCSIMaterial = "TEST";
            var testBottomChordDesignMaxBCDeflection = new KxrComponent.KxrDeflectionCriteria();
            testBottomChordDesignMaxBCDeflection.LiveLoad = "TEST";
            testBottomChordDesignMaxBCDeflection.TotalLoad = "TEST";
            testBottomChordDesignMaxBCDeflection.Cantilever = "TEST";
            testBottomChordDesignMaxBCDeflection.Overhang = "TEST";
            component.BottomChordDesignMaxBCDeflection = testBottomChordDesignMaxBCDeflection;
            component.BottomChordDesignBoardFootage = "TEST";
            component.WebDesignCriticalCSI = "TEST";
            component.WebDesignCriticalCSIMaterial = "TEST";
            component.WebDesignNumbBracedWebs = "TEST";
            component.WebDesignBoardFootage = "TEST";
            component.PlatingDesignManufacturer = "TEST";
            component.PlatingDesignTotalSquareInches = "TEST";
            component.PlatingDesignTotal_HS20ga = "TEST";
            component.PlatingDesignTotal_HS18ga = "TEST";
            component.PlatingDesignTotal_20ga = "TEST";
            component.PlatingDesignTotal_18ga = "TEST";
            component.PlatingDesignTotal_16ga = "TEST";

            component.CSI.Should().Be("TEST");
            component.Deflection.Should().Be("TEST");
            component.Buckling.Should().Be("TEST");
            component.TotalBoardFootage.Should().Be("TEST");
            component.Part2BearingCombos.Count.Should().Be(1);
            component.OverallDeflectionMaxVertical.Should().Be("TEST");
            component.OverallDeflectionMaxHorizontal.Should().Be("TEST");
            component.TopChordDesignCriticalCSI.Should().Be("TEST");
            component.TopChordDesignCriticalCSIMaterial.Should().Be("TEST");
            component.TopChordDesignMaxTCDeflection.LiveLoad.Should().Be("TEST");
            component.TopChordDesignMaxTCDeflection.TotalLoad.Should().Be("TEST");
            component.TopChordDesignMaxTCDeflection.Cantilever.Should().Be("TEST");
            component.TopChordDesignMaxTCDeflection.Overhang.Should().Be("TEST");
            component.TopChordDesignBoardFootage.Should().Be("TEST");
            component.BottomChordDesignCriticalCSI.Should().Be("TEST");
            component.BottomChordDesignCriticalCSIMaterial.Should().Be("TEST");
            component.BottomChordDesignMaxBCDeflection.LiveLoad.Should().Be("TEST");
            component.BottomChordDesignMaxBCDeflection.TotalLoad.Should().Be("TEST");
            component.BottomChordDesignMaxBCDeflection.Cantilever.Should().Be("TEST");
            component.BottomChordDesignMaxBCDeflection.Overhang.Should().Be("TEST");
            component.BottomChordDesignBoardFootage.Should().Be("TEST");
            component.WebDesignCriticalCSI.Should().Be("TEST");
            component.WebDesignCriticalCSIMaterial.Should().Be("TEST");
            component.WebDesignNumbBracedWebs.Should().Be("TEST");
            component.WebDesignBoardFootage.Should().Be("TEST");
            component.PlatingDesignManufacturer.Should().Be("TEST");
            component.PlatingDesignTotalSquareInches.Should().Be("TEST");
            component.PlatingDesignTotal_HS20ga.Should().Be("TEST");
            component.PlatingDesignTotal_HS18ga.Should().Be("TEST");
            component.PlatingDesignTotal_20ga.Should().Be("TEST");
            component.PlatingDesignTotal_18ga.Should().Be("TEST");
            component.PlatingDesignTotal_16ga.Should().Be("TEST");
            #endregion

            #region TwoDistancealInfo
            component.ZWidth = "TEST";
            //ToDo: List
            //ToDo: List
            //ToDo: List

            component.ZWidth.Should().Be("TEST");
            //ToDo: component.Plates.Count.Should().Be(9);
            //ToDo: component.Pieces.Count.Should().Be(9);
            //ToDo: component.Part3BearingCombos.Count.Should().Be(1);
            #endregion

            #region JigSettings
            //ToDo: component.JigPoints.Count.Should().Be(11);
            #endregion

            #region LaborFactors
            component.LaborFactorsCantilever = "TEST";
            component.LaborFactorsEndDetailLeft = "TEST";
            component.LaborFactorsEndDetailRight = "TEST";
            component.LaborFactorsBeamPocket = "TEST";

            component.LaborFactorsCantilever.Should().Be("TEST");
            component.LaborFactorsEndDetailLeft.Should().Be("TEST");
            component.LaborFactorsEndDetailRight.Should().Be("TEST");
            component.LaborFactorsBeamPocket.Should().Be("TEST");
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
            Assert.Pass();
        }

        [Test()]
        public void Parse_Trs()
        {
            Component component = new TrsComponent().Parse(Encoding.UTF8.GetString(ComponentFiles.computruss));
            Assert.Fail();
        }
    }
}
