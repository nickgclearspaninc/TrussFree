﻿using System.Collections.Generic;

namespace ComponentFileReader.FileClasses.TreComponent
{
    public partial class TreComponent: Component
    {
        public string[] Contents { get; set; }

        public override string Name
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

        public TreComponent(string file)
        {
            Contents = file.Split('\n');
            _parseTreData();
        }
    }
}
