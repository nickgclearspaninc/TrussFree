using System.Collections.Generic;

namespace ComponentFileReader.FileClasses.KxrComponent
{
    public partial class KxrComponent
    {
        public class KxrBearing2
        {
            public string MaxDownwardReaction;
            public string MaxUpliftReaction;
            public string MaxHorizReaction;
            public string BearingEnhancementRequired;
            public List<KxrReaction> Reactions;
        }
    }
}
