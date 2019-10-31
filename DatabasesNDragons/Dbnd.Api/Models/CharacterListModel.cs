using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dbnd.Api.Models
{
    public class CharacterListModel
    {
        public ISet<CharacterModel> Characters { get; } = new HashSet<CharacterModel>();
    }
}
