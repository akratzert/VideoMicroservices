using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video.Data.Entities;

public class ThemeEntity
{
    public Guid ThemeId { get; set; } = Guid.Empty;
    public string ThemeName { get; set; } = string.Empty;
}
