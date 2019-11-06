using System;

namespace Dbnd.Logic.Objects
{
    public class OverviewType
    {
        public Guid TypeID { get; set; }

        public OverviewType()
        {
            TypeID = Guid.NewGuid();
        }

    }
}
