using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Enums;

public enum TaskStatus
{
    Pending, //task is assigned but the user hadn't started yet
    InProgress,//the user has already been working on it
    Completed // done
}
