﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace InsaneIO.Insane.Misc
{
    [RequiresPreviewFeatures]
    public interface IDefaultInstance<T>
    {
        static abstract T DefaultInstance { get; }
    }
}
