using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentFileReader.FileClasses.TreComponent
{
    public partial class TreComponent
    {
        public TreMemberInfo MemberInfo
        {
            get
            {
                // Check for cached
                if(_treMemberInfo != null)
                {
                    return _treMemberInfo;
                }

                //_parseMemberInfo(); // Populates _treMemberInfo (unless Contents is null)
                return _treMemberInfo;
            }
        }
        private TreMemberInfo _treMemberInfo = null;
    }
}
