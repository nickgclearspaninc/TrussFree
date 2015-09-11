using ComponentFileReader.LumberClass;
using GeometryClassLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public enum MemberType { Web, TopChord, BottomChord, Block, BottomChordSlider, TopChordSlider, Wedge, EndVertical }

public enum MemberOrientation { Vertical, Horizontal }

namespace ComponentFileReader
{
    /// <summary>
    /// A member is any structural piece in a component.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Member
    {

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public MemberType MemberType { get; set; }

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public MemberOrientation Orientation { get; set; }

        [JsonProperty]
        public Lumber Lumber { get; set; }

        [JsonProperty]
        public Polygon Geometry { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        public Member(Lumber lumberType, MemberType memberType, Polygon geometry, string name = "")
        {
            this.MemberType = memberType;
            this.Lumber = lumberType;
            this.Geometry = geometry;
            this.Name = name;
        }
    }
}
