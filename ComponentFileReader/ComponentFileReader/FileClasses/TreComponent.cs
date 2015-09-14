using System.Collections.Generic;
using System.Dynamic;

namespace ComponentFileReader.FileClasses
{
    public class TreComponent: Component
    {
        public override string Name
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public override List<Bearing> Bearings
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public override List<Member> Members
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public override List<PlateConnector> Plates
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public TreComponent():base(null,null,null,ComponentType.Floor)
        {
            
        }
    }
}
