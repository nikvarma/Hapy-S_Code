using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class Device: BaseObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public enum DeviceType
    {
        Android,
        Web,
        Windows,
        IOS
    }

    public enum DeviceName
    {
        Mobile,
        iPad,
        Desktop,
        Tablet,
        Laptop
    }
}
