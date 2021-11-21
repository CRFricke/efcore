// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore
{
    public abstract class FindCosmosTest : FindTestBase<FindCosmosTest.FindCosmosFixture>
    {
        protected FindCosmosTest(FindCosmosFixture fixture)
            : base(fixture)
        {
            fixture.TestSqlLoggerFactory.Clear();
        }

        [ConditionalFact(Skip = "#25886")]
        public override void Find_base_type_using_derived_set_tracked() { }

        [ConditionalFact(Skip = "#25886")]
        public override Task Find_base_type_using_derived_set_tracked_async()
            => Task.CompletedTask;

        [ConditionalFact(Skip = "#25886")]
        public override void Find_derived_using_base_set_type_from_store() { }

        [ConditionalFact(Skip = "#25886")]
        public override Task Find_derived_using_base_set_type_from_store_async()
            => Task.CompletedTask;

        public class FindCosmosTestSet : FindCosmosTest
        {
            public FindCosmosTestSet(FindCosmosFixture fixture)
                : base(fixture)
            {
            }

            protected override TEntity Find<TEntity>(DbContext context, params object[] keyValues)
                => context.Set<TEntity>().Find(keyValues);

            protected override ValueTask<TEntity> FindAsync<TEntity>(DbContext context, params object[] keyValues)
                => context.Set<TEntity>().FindAsync(keyValues);
        }

        public class FindCosmosTestContext : FindCosmosTest
        {
            public FindCosmosTestContext(FindCosmosFixture fixture)
                : base(fixture)
            {
            }

            protected override TEntity Find<TEntity>(DbContext context, params object[] keyValues)
                => context.Find<TEntity>(keyValues);

            protected override ValueTask<TEntity> FindAsync<TEntity>(DbContext context, params object[] keyValues)
                => context.FindAsync<TEntity>(keyValues);
        }

        public class FindCosmosTestNonGeneric : FindCosmosTest
        {
            public FindCosmosTestNonGeneric(FindCosmosFixture fixture)
                : base(fixture)
            {
            }

            protected override TEntity Find<TEntity>(DbContext context, params object[] keyValues)
                => (TEntity)context.Find(typeof(TEntity), keyValues);

            protected override async ValueTask<TEntity> FindAsync<TEntity>(DbContext context, params object[] keyValues)
                => (TEntity)await context.FindAsync(typeof(TEntity), keyValues);
        }

        public class FindCosmosFixture : FindFixtureBase
        {
            public TestSqlLoggerFactory TestSqlLoggerFactory
                => (TestSqlLoggerFactory)ListLoggerFactory;

            protected override ITestStoreFactory TestStoreFactory
                => CosmosTestStoreFactory.Instance;
        }
    }
}
