using System;
using System.Collections.Generic;
using System.Text;

namespace VRICODE.Models
{
    public enum UserClassPrivilege
    {
        Teacher,
        Student
    }

    public enum CodeRunnerStatus
    {
        Success,
        CompilerError,
        TimeLimit
    }
}
