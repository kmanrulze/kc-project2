using System;

namespace Dbnd.Logic.Objects
{
    public class Overview
    {
        public Guid OverviewID { get; set; }
        public Guid GameID { get; set; }
        public Guid TypeID { get; set; }

        public Overview(Guid gameID, Guid typeID)
        {
            OverviewID = Guid.NewGuid();
            GameID = gameID;
            TypeID = typeID;
        }

        public Overview() { }

    }
}
