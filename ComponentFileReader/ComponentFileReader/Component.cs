using System.Collections.Generic;
using Newtonsoft.Json;

namespace ComponentFileReader
{
    public enum ComponentFunction { Gable, Girder, Hip, Jack, Rafter, Attic, Ag, Reversed, StructuralGable, Normal }

    public enum ComponentType { Roof, Floor }

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
        public List<Member> Members { get; set; }

        [JsonProperty]
        public ComponentType ComponentType { get; set; }

        [JsonProperty]
        public ComponentFunction ComponentFunction { get; set; }

        [JsonConstructor]
        public Component(List<Member> members, List<Bearing> bearings, List<PlateConnector> plateConnectors , ComponentType componentType, string name = "", ComponentFunction componentFunction = ComponentFunction.Normal)
        {
            this.Name = name;
            this.Members = members;
            this.Bearings = bearings;
            this.PlateConnectors = plateConnectors;
        }

    }
}
