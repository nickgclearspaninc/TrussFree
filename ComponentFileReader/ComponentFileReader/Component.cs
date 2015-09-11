using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryClassLibrary;
using Newtonsoft.Json;

namespace ComponentFileReader
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Component
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public List<Bearing> Bearings { get; set; }

        [JsonProperty]
        public List<PlateConnector> PlateConnectors { get; set; }

        [JsonProperty]
        public virtual List<Member> Members { get; set; }

        [JsonConstructor]
        public Component(List<Member> members, List<Bearing> bearings, List<PlateConnector> plateConnectors , string name = "")
        {
            this.Name = name;
            this.Members = members;
            this.Bearings = bearings;
            this.PlateConnectors = plateConnectors;
        }

    }
}
