using System.Collections.Specialized;
using GeometryClassLibrary;

namespace ComponentFileReader
{
    public class Bearing
    {
        public string Name { get; set; }
        public Polygon Geometry { get; set; }

        public Bearing(Polygon geometry, string name ="")
        {
            this.Geometry = geometry;
            this.Name = name;
        }
    }
}
