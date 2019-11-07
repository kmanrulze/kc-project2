using System;

namespace Dbnd.Logic.Objects
{
    public class Overview
    {
        public Guid OverviewID { get; set; }
        public Guid GameID { get; set; }
        public Guid TypeID { get; set; }
        public string OverviewName { get; set; }
        public string OverviewContent { get; set; }

        public Overview(Guid gameID, Guid typeID, string overviewName, string overviewContent)
        {
            OverviewID = Guid.NewGuid();
            GameID = gameID;
            TypeID = typeID;
            OverviewName = overviewName;
            OverviewContent = overviewContent;

        }

        public Overview() { }

    }
}
