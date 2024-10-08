﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore;

#nullable disable

public class GraphUpdatesSqliteFullWithOriginalsNotificationsTest(
    GraphUpdatesSqliteFullWithOriginalsNotificationsTest.SqliteFixture fixture)
    : GraphUpdatesSqliteTestBase<GraphUpdatesSqliteFullWithOriginalsNotificationsTest.SqliteFixture>(fixture)
{
    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());

    public class SqliteFixture : GraphUpdatesSqliteFixtureBase
    {
        protected override string StoreName
            => "GraphUpdatesFullWithOriginalsTest";

        protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
        {
            modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);

            base.OnModelCreating(modelBuilder, context);
        }
    }
}
