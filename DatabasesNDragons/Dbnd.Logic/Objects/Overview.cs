using System;

namespace Dbnd.Logic.Objects
{
    public class Overview
    {
        public Guid OverviewID { get; set; }
        public Guid GameID { get; set; }
        public Guid TypeID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public Overview(Guid gameID, string overviewName, string overviewContent)
        {
            OverviewID = Guid.NewGuid();
            GameID = gameID;
            Name = overviewName;
            Content = overviewContent;
        }

        public Overview() { }

    }
}
