using GeometryClassLibrary;
using Newtonsoft.Json;

namespace ComponentFileReader
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PlateConnector
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public Polygon Geometry { get; set; }


        public PlateConnector(Polygon geometry, string name = "")
        {
            this.Geometry = geometry;
            this.Name = name;
        }

    }
}
