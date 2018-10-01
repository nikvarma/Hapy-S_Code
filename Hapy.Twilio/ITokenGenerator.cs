using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Twilio
{
    public interface ITokenGenerator
    {
        string Generate(string identity, string endpointId);
    }
}
