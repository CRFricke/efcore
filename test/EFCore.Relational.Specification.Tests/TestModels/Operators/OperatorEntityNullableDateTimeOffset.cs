﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore.TestModels.Operators;

#nullable disable

public class OperatorEntityNullableDateTimeOffset : OperatorEntityBase
{
    public DateTimeOffset? Value { get; set; }
}
