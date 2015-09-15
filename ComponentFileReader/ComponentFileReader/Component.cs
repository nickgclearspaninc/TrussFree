using System.Collections.Generic;
using Newtonsoft.Json;

namespace ComponentFileReader
{
    public enum JointFixityType { Fixed, Pin, HorizontalRoller, VerticalRoller, Released }

    public enum ComponentFunction { Gable, Girder, Hip, Jack, Rafter, Attic, StructuralGable }

    public enum ComponentType { Roof, Floor }

    [JsonObject(MemberSerialization.OptIn)]
    public class Component
    {
        [JsonProperty]
        public virtual string Name { get; set; }

        [JsonProperty]
        public virtual List<Bearing> Bearings { get; set; }

        [JsonProperty]
        public virtual List<PlateConnector> PlateConnectors { get; set; }

        [JsonProperty]
        public virtual List<Member> Members { get; set; }

        [JsonProperty]
        public virtual ComponentType ComponentType { get; set; }

        [JsonProperty]
        public virtual HashSet<ComponentFunction> ComponentFunctions { get; set; }

        [JsonConstructor]
        public Component(List<Member> members, List<Bearing> bearings, List<PlateConnector> plateConnectors, ComponentType componentType, string name = "")
        {
            this.Name = name;
            this.Members = members;
            this.Bearings = bearings;
            this.PlateConnectors = plateConnectors;
        }

        protected Component()
        {

        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
