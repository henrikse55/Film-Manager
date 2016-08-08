using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;
namespace Shared.Interfaces
{
    interface IMessage
    {
        String Command { get; }

        String[] args { get; }
    }
}
