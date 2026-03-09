using System;
using System.Collections.Generic;
using System.Text;

namespace LibMinimalApi10.Core.Request
{
    public class CreateMemberRequest
    {
        public required string MemberName { get; set; }
        public required string MemberType { get; set; }
    }
}
