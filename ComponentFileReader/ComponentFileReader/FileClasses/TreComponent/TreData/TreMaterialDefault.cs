using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentFileReader.FileClasses.TreComponent
{
    public class TreMaterial
    {
        public string GUID;
        public string EntityTypeMember;
        public string IndexToMaterialDefaultsMap;

        public TreMaterial(string[] contents)
        {
            string info = contents[0];
            GUID = info.Substring(0, info.Length - 2);
            EntityTypeMember = info.ElementAt(info.Length - 2).ToString();
            IndexToMaterialDefaultsMap = info.ElementAt(info.Length - 1).ToString();
        }
    }

    public class TreMaterialMap
    {
        public string GUID;
        public string IndexToForEachEntryInMap;
        public string MaterialListIndex;
        public string Fixity;
        public string MinWidth;
        public string MaxWidth;
        public string MinDepth;
        public string MaxDepth;
        public string LumberOnEdgeOrFlat;

        public TreMaterialMap(string[] contents)
        {
            this.IndexToForEachEntryInMap = contents[0].Substring(0, 1);
            this.GUID = contents[0].Substring(2, contents[0].Length - 2);
            this.MaterialListIndex = contents[1];
            this.Fixity = contents[2];
            this.MinWidth = contents[3];
            this.MaxWidth = contents[4];
            this.MinDepth = contents[5];
            this.MaxDepth = contents[6];
            this.LumberOnEdgeOrFlat = contents[7];
        }
    }

    public partial class TreComponent
    {
        public List<TreMaterial> DefaultMaterials;
        public List<TreMaterialMap> DefaultMaterialsMap;
    }
}
