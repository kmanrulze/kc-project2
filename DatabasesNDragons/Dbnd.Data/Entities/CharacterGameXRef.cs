using System;

namespace Dbnd.Data.Entities
{
    public class CharacterGameXRef
    {
        // Foreign Key
        public Guid GameID { get; set; }
        public Game Game { get; set; }

        // Foreign Key
        public Guid CharacterID { get; set; }
        public Character Character { get; set; }

        public virtual Character CharacterInfo { get; set; }
        public virtual Game GameInfo { get; set; }

    }
}
