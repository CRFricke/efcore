// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.EntityFrameworkCore.Utilities;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query
{
    public class OwnedQueryInMemoryTest : OwnedQueryTestBase<OwnedQueryInMemoryTest.OwnedQueryInMemoryFixture>
    {
        public OwnedQueryInMemoryTest(OwnedQueryInMemoryFixture fixture, ITestOutputHelper testOutputHelper)
            : base(fixture)
        {
            //TestLoggerFactory.TestOutputHelper = testOutputHelper;
        }
        
        public class OwnedQueryInMemoryFixture : OwnedQueryFixtureBase
        {
            protected override ITestStoreFactory<TestStore> TestStoreFactory => InMemoryTestStoreFactory.Instance;
        }
    }
}
