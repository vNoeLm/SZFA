using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak2
{
    internal class InvalidSettingException : Exception
    {
        public InvalidSettingException() : base("LightIntensity cant be over 100 or under 0!") { }
    }
}
