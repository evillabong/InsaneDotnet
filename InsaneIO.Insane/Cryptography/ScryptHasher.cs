﻿using InsaneIO.Insane.Extensions;
using InsaneIO.Insane.Serialization;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace InsaneIO.Insane.Cryptography
{
    [RequiresPreviewFeatures]
    public class ScryptHasher : IHasher
    {
        public static Type SelfType => typeof(ScryptHasher);
        public string AssemblyName { get => IJsonSerializable.GetName(SelfType); }

        public string SaltString { get => Encoder.Encode(Salt); init => Salt = value.ToByteArrayUtf8(); }

        public byte[] SaltBytes { get => Salt; init => Salt = value; }

        private byte[] Salt = RandomExtensions.NextBytes(Constants.ScryptSaltSize);
        public uint Iterations { get; init; } = Constants.ScryptIterations;
        public uint BlockSize { get; init; } = Constants.ScryptBlockSize;
        public uint Parallelism { get; init; } = Constants.ScryptParallelism;
        public uint DerivedKeyLength { get; init; } = Constants.ScryptDerivedKeyLength;
        public IEncoder Encoder { get; init; } = Base64Encoder.DefaultInstance;

        public ScryptHasher()
        {
        }

        public static IHasher Deserialize(string json)
        {
            JsonNode jsonNode = JsonNode.Parse(json)!;
            Type encoderType = Type.GetType(jsonNode[nameof(Encoder)]![nameof(IEncoder.AssemblyName)]!.GetValue<string>())!;
            IEncoder encoder = (IEncoder)JsonSerializer.Deserialize(jsonNode[nameof(Encoder)], encoderType)!;
            return new ScryptHasher
            {
                Salt = encoder.Decode( jsonNode[nameof(Salt)]!.GetValue<string>()),
                Iterations = jsonNode[nameof(Iterations)]!.GetValue<uint>(),
                BlockSize = jsonNode[nameof(BlockSize)]!.GetValue<uint>(),
                Parallelism = jsonNode[nameof(Parallelism)]!.GetValue<uint>(),
                DerivedKeyLength = jsonNode[nameof(DerivedKeyLength)]!.GetValue<uint>(),
                Encoder = encoder,
            };
        }

        public byte[] Compute(byte[] data)
        {
            return data.ComputeScrypt(Salt, Iterations, BlockSize, Parallelism, DerivedKeyLength);
        }

        public string ComputeEncoded(string data)
        {
            return Encoder.Encode(Compute(data.ToByteArrayUtf8()));
        }

        public string Serialize(bool indented = false)
        {
            return ToJsonObject().ToJsonString(IJsonSerializable.GetIndentOptions(indented));
        }

        public JsonObject ToJsonObject()
        {
            return new JsonObject
            {
                [nameof(AssemblyName)] = AssemblyName,
                [nameof(Salt)] = Encoder.Encode(Salt),
                [nameof(Iterations)] = Iterations,
                [nameof(BlockSize)] = BlockSize,
                [nameof(Parallelism)] = Parallelism,
                [nameof(DerivedKeyLength)] = DerivedKeyLength,
                [nameof(Encoder)] = Encoder.ToJsonObject(),
            };
        }

        public bool Verify(byte[] data, byte[] expected)
        {
            return Enumerable.SequenceEqual(Compute(data), expected);
        }

        public bool VerifyEncoded(string data, string expected)
        {
            return ComputeEncoded(data).Equals(expected);
        }
    }
}
