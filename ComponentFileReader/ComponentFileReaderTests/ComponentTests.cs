using System.Collections.Generic;
using ComponentFileReader;
using ComponentFileReader.Readers;
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
            Component component = new KxrReader().Parse(ComponentFiles.eagle.ToString());
            Assert.Fail();
        }

        [Test()]
        public void Parse_Tre()
        {
            Component component = new TreReader().Parse(ComponentFiles.mitek.ToString());
            Assert.Fail();
        }

        [Test()]
        public void Parse_Trs()
        {
            Component component = new TrsReader().Parse(ComponentFiles.computruss.ToString());
            Assert.Fail();
        }
    }
}
