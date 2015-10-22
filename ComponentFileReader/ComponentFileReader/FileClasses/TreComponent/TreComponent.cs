using System.Collections.Generic;

namespace ComponentFileReader.FileClasses.TreComponent
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

        public override List<PlateConnector> PlateConnectors
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public TreComponent():base(null,null,null,ComponentType.Floor)
        {
            
        }

        public Component Parse(string getString)
        {
            throw new System.NotImplementedException();
        }
    }
}
