using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechLeiloes.UI.Models;

public class ApiSettings
{
    public string BaseUrl { get; set; } = string.Empty;
    public int TimeoutSeconds { get; set; } = 30;
}
