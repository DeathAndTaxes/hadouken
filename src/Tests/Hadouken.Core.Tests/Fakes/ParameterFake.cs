﻿using System;
using Hadouken.Core.JsonRpc;

namespace Hadouken.Core.Tests.Fakes
{
    public class ParameterFake : IParameter
    {
        public ParameterFake(string name, Type type)
        {
            Name = name;
            ParameterType = type;
        }

        public string Name { get; private set; }
        public Type ParameterType { get; private set; }
    }
}
