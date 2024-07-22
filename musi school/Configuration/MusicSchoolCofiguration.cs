using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musi_school.Configuration
{
    internal static class MusicSchoolCofiguration
    {
        public static string musicSchoolPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "musicschool.xml"
            );
    }
}
