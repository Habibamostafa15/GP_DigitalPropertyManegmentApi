using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Dtos
{
    public class PropertyFavoriteDto:PropertiesReadDto
    {
        public DateTime AddedToFavoritesAt { get; set; }
    }
}
