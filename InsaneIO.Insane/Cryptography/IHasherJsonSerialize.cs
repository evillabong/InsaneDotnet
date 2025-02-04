﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using InsaneIO.Insane.Serialization;

namespace InsaneIO.Insane.Cryptography
{
    [RequiresPreviewFeatures]
    public interface IHasherJsonSerialize : IJsonSerializable
    {
        public static abstract IHasher Deserialize(string json);
    }
}
