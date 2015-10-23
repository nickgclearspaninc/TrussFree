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

            // Native variable checks
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
            component.Plies.Should().Be("1");
            component.WeightPerPly.Should().Be("83");
            component.Spacing.Should().Be("24");
            component.ComponentFunctions.Count.Should().Be(0);
            component.ZWidth.Should().Be("1.500000");
            component.Pieces.Count.Should().Be(9);
            component.Plates.Count.Should().Be(9);

            // Component variable checks
            component.Members.Count.Should().Be(9);
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
