// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.EntityFrameworkCore.TestUtilities.FakeProvider;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local
namespace Microsoft.EntityFrameworkCore.Update
{
    public class ReaderModificationCommandBatchTest
    {
        [ConditionalFact]
        public void AddCommand_adds_command_if_possible()
        {
            var command = CreateModificationCommand("T1", null, true, columnModifications: null);

            var batch = new ModificationCommandBatchFake();
            batch.AddCommand(command);
            batch.ShouldAddCommand = true;
            batch.ShouldValidateSql = true;

            batch.AddCommand(command);

            Assert.Equal(2, batch.ModificationCommands.Count);
            Assert.Same(command, batch.ModificationCommands[0]);
            Assert.Equal("..", batch.CommandText);
        }

        [ConditionalFact]
        public void AddCommand_does_not_add_command_if_not_possible()
        {
            var command = CreateModificationCommand("T1", null, true, columnModifications: null);

            var batch = new ModificationCommandBatchFake();
            batch.AddCommand(command);
            batch.ShouldAddCommand = false;
            batch.ShouldValidateSql = true;

            batch.AddCommand(command);

            Assert.Equal(1, batch.ModificationCommands.Count);
            Assert.Equal(".", batch.CommandText);
        }

        [ConditionalFact]
        public void AddCommand_does_not_add_command_if_resulting_sql_is_invalid()
        {
            var command = CreateModificationCommand("T1", null, true, columnModifications: null);

            var batch = new ModificationCommandBatchFake();
            batch.AddCommand(command);
            batch.ShouldAddCommand = true;
            batch.ShouldValidateSql = false;

            batch.AddCommand(command);

            Assert.Equal(1, batch.ModificationCommands.Count);
            Assert.Equal(".", batch.CommandText);
        }

        [ConditionalFact]
        public void UpdateCommandText_compiles_inserts()
        {
            var entry = CreateEntry(EntityState.Added);

            var command = CreateModificationCommand("T1", null, new ParameterNameGenerator().GenerateNext, true, null);
            command.AddEntry(entry, true);

            var fakeSqlGenerator = new FakeSqlGenerator(
                RelationalTestHelpers.Instance.CreateContextServices().GetRequiredService<UpdateSqlGeneratorDependencies>());
            var batch = new ModificationCommandBatchFake(fakeSqlGenerator);
            batch.AddCommand(command);

            batch.UpdateCachedCommandTextBase(0);

            Assert.Equal(1, fakeSqlGenerator.AppendBatchHeaderCalls);
            Assert.Equal(1, fakeSqlGenerator.AppendInsertOperationCalls);
        }

        [ConditionalFact]
        public void UpdateCommandText_compiles_updates()
        {
            var entry = CreateEntry(EntityState.Modified, generateKeyValues: true);

            var command = CreateModificationCommand("T1", null, new ParameterNameGenerator().GenerateNext, true, null);
            command.AddEntry(entry, true);

            var fakeSqlGenerator = new FakeSqlGenerator(
                RelationalTestHelpers.Instance.CreateContextServices().GetRequiredService<UpdateSqlGeneratorDependencies>());
            var batch = new ModificationCommandBatchFake(fakeSqlGenerator);
            batch.AddCommand(command);

            batch.UpdateCachedCommandTextBase(0);

            Assert.Equal(1, fakeSqlGenerator.AppendBatchHeaderCalls);
            Assert.Equal(1, fakeSqlGenerator.AppendUpdateOperationCalls);
        }

        [ConditionalFact]
        public void UpdateCommandText_compiles_deletes()
        {
            var entry = CreateEntry(EntityState.Deleted);

            var command = CreateModificationCommand("T1", null, new ParameterNameGenerator().GenerateNext, true, null);
            command.AddEntry(entry, true);

            var fakeSqlGenerator = new FakeSqlGenerator(
                RelationalTestHelpers.Instance.CreateContextServices().GetRequiredService<UpdateSqlGeneratorDependencies>());
            var batch = new ModificationCommandBatchFake(fakeSqlGenerator);
            batch.AddCommand(command);

            batch.UpdateCachedCommandTextBase(0);

            Assert.Equal(1, fakeSqlGenerator.AppendBatchHeaderCalls);
            Assert.Equal(1, fakeSqlGenerator.AppendDeleteOperationCalls);
        }

        [ConditionalFact]
        public void UpdateCommandText_compiles_multiple_commands()
        {
            var entry = CreateEntry(EntityState.Added);

            var command = CreateModificationCommand("T1", null, new ParameterNameGenerator().GenerateNext, true, null);
            command.AddEntry(entry, true);

            var fakeSqlGenerator = new FakeSqlGenerator(
                RelationalTestHelpers.Instance.CreateContextServices().GetRequiredService<UpdateSqlGeneratorDependencies>());
            var batch = new ModificationCommandBatchFake(fakeSqlGenerator);
            batch.AddCommand(command);
            batch.AddCommand(command);

            Assert.Equal("..", batch.CommandText);

            Assert.Equal(1, fakeSqlGenerator.AppendBatchHeaderCalls);
        }

        [ConditionalFact]
        public async Task ExecuteAsync_executes_batch_commands_and_consumes_reader()
        {
            var entry = CreateEntry(EntityState.Added);

            var command = CreateModificationCommand("T1", null, new ParameterNameGenerator().GenerateNext, true, null);
            command.AddEntry(entry, true);

            var dbDataReader = CreateFakeDataReader();

            var connection = CreateConnection(dbDataReader);

            var batch = new ModificationCommandBatchFake();
            batch.AddCommand(command);

            await batch.ExecuteAsync(connection);

            Assert.Equal(1, dbDataReader.ReadAsyncCount);
            Assert.Equal(1, dbDataReader.GetInt32Count);
        }

        [ConditionalFact]
        public async Task ExecuteAsync_saves_store_generated_values()
        {
            var entry = CreateEntry(EntityState.Added, generateKeyValues: true);
            entry.SetTemporaryValue(entry.EntityType.FindPrimaryKey().Properties[0], -1);

            var command = CreateModificationCommand("T1", null, new ParameterNameGenerator().GenerateNext, true, null);
            command.AddEntry(entry, true);

            var connection = CreateConnection(
                CreateFakeDataReader(
                    new[] { "Col1" }, new List<object[]> { new object[] { 42 } }));

            var batch = new ModificationCommandBatchFake();
            batch.AddCommand(command);

            await batch.ExecuteAsync(connection);

            Assert.Equal(42, entry[entry.EntityType.FindProperty("Id")]);
            Assert.Equal("Test", entry[entry.EntityType.FindProperty("Name")]);
        }

        [ConditionalFact]
        public async Task ExecuteAsync_saves_store_generated_values_on_non_key_columns()
        {
            var entry = CreateEntry(
                EntityState.Added, generateKeyValues: true, computeNonKeyValue: true);
            entry.SetTemporaryValue(entry.EntityType.FindPrimaryKey().Properties[0], -1);

            var command = CreateModificationCommand("T1", null, new ParameterNameGenerator().GenerateNext, true, null);
            command.AddEntry(entry, true);

            var connection = CreateConnection(
                CreateFakeDataReader(
                    new[] { "Col1", "Col2" }, new List<object[]> { new object[] { 42, "FortyTwo" } }));

            var batch = new ModificationCommandBatchFake();
            batch.AddCommand(command);

            await batch.ExecuteAsync(connection);

            Assert.Equal(42, entry[entry.EntityType.FindProperty("Id")]);
            Assert.Equal("FortyTwo", entry[entry.EntityType.FindProperty("Name")]);
        }

        [ConditionalFact]
        public async Task ExecuteAsync_saves_store_generated_values_when_updating()
        {
            var entry = CreateEntry(
                EntityState.Modified, generateKeyValues: true, computeNonKeyValue: true);

            var command = CreateModificationCommand("T1", null, new ParameterNameGenerator().GenerateNext, true, null);
            command.AddEntry(entry, true);

            var connection = CreateConnection(
                CreateFakeDataReader(
                    new[] { "Col2" }, new List<object[]> { new object[] { "FortyTwo" } }));

            var batch = new ModificationCommandBatchFake();
            batch.AddCommand(command);

            await batch.ExecuteAsync(connection);

            Assert.Equal(1, entry[entry.EntityType.FindProperty("Id")]);
            Assert.Equal("FortyTwo", entry[entry.EntityType.FindProperty("Name")]);
        }

        [ConditionalFact]
        public async Task Exception_not_thrown_for_more_than_one_row_returned_for_single_command()
        {
            var entry = CreateEntry(EntityState.Added, generateKeyValues: true);
            entry.SetTemporaryValue(entry.EntityType.FindPrimaryKey().Properties[0], -1);

            var command = CreateModificationCommand("T1", null, new ParameterNameGenerator().GenerateNext, true, null);
            command.AddEntry(entry, true);

            var connection = CreateConnection(
                CreateFakeDataReader(
                    new[] { "Col1" },
                    new List<object[]> { new object[] { 42 }, new object[] { 43 } }));

            var batch = new ModificationCommandBatchFake();
            batch.AddCommand(command);

            await batch.ExecuteAsync(connection);

            Assert.Equal(42, entry[entry.EntityType.FindProperty("Id")]);
        }

        [ConditionalTheory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task Exception_thrown_if_rows_returned_for_command_without_store_generated_values_is_not_1(bool async)
        {
            var entry = CreateEntry(EntityState.Added);

            var command = CreateModificationCommand("T1", null, new ParameterNameGenerator().GenerateNext, true, null);
            command.AddEntry(entry, true);

            var connection = CreateConnection(
                CreateFakeDataReader(
                    new[] { "Col1" }, new List<object[]> { new object[] { 42 } }));

            var batch = new ModificationCommandBatchFake();
            batch.AddCommand(command);

            var exception = async
                ? await Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => batch.ExecuteAsync(connection))
                : Assert.Throws<DbUpdateConcurrencyException>(() => batch.Execute(connection));

            Assert.Equal(RelationalStrings.UpdateConcurrencyException(1, 42), exception.Message);
        }

        [ConditionalTheory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task Exception_thrown_if_no_rows_returned_for_command_with_store_generated_values(bool async)
        {
            var entry = CreateEntry(EntityState.Added, generateKeyValues: true);
            entry.SetTemporaryValue(entry.EntityType.FindPrimaryKey().Properties[0], -1);

            var command = CreateModificationCommand("T1", null, new ParameterNameGenerator().GenerateNext, true, null);
            command.AddEntry(entry, true);

            var connection = CreateConnection(
                CreateFakeDataReader(new[] { "Col1" }, new List<object[]>()));

            var batch = new ModificationCommandBatchFake();
            batch.AddCommand(command);

            var exception = async
                ? await Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => batch.ExecuteAsync(connection))
                : Assert.Throws<DbUpdateConcurrencyException>(() => batch.Execute(connection));

            Assert.Equal(RelationalStrings.UpdateConcurrencyException(1, 0), exception.Message);
        }

        [ConditionalTheory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task DbException_is_wrapped_with_DbUpdateException(bool async)
        {
            var entry = CreateEntry(EntityState.Added, generateKeyValues: true);

            var command = CreateModificationCommand("T1", null, new ParameterNameGenerator().GenerateNext, true, null);
            command.AddEntry(entry, true);

            var originalException = new FakeDbException();

            var connection = CreateConnection(
                new FakeCommandExecutor(
                    executeReaderAsync: (c, b, ct) => throw originalException,
                    executeReader: (c, b) => throw originalException));

            var batch = new ModificationCommandBatchFake();
            batch.AddCommand(command);

            var actualException = async
                ? await Assert.ThrowsAsync<DbUpdateException>(() => batch.ExecuteAsync(connection))
                : Assert.Throws<DbUpdateException>(() => batch.Execute(connection));

            Assert.Same(originalException, actualException.InnerException);
        }

        [ConditionalTheory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task OperationCanceledException_is_not_wrapped_with_DbUpdateException(bool async)
        {
            var entry = CreateEntry(EntityState.Added, generateKeyValues: true);

            var command = CreateModificationCommand("T1", null, new ParameterNameGenerator().GenerateNext, true, null);
            command.AddEntry(entry, true);

            var originalException = new OperationCanceledException();

            var connection = CreateConnection(
                new FakeCommandExecutor(
                    executeReaderAsync: (c, b, ct) => throw originalException,
                    executeReader: (c, b) => throw originalException));

            var batch = new ModificationCommandBatchFake();
            batch.AddCommand(command);

            var actualException = async
                ? await Assert.ThrowsAsync<OperationCanceledException>(() => batch.ExecuteAsync(connection))
                : Assert.Throws<OperationCanceledException>(() => batch.Execute(connection));

            Assert.Same(originalException, actualException);
        }

        [ConditionalFact]
        public void CreateStoreCommand_creates_parameters_for_each_ModificationCommand()
        {
            var entry = CreateEntry(EntityState.Added, generateKeyValues: true);
            var property = entry.EntityType.FindProperty("Id");
            entry.SetTemporaryValue(property, 1);

            var batch = new ModificationCommandBatchFake();
            var parameterNameGenerator = new ParameterNameGenerator();

            batch.AddCommand(
                CreateModificationCommand(
                    "T1",
                    null,
                    true,
                    new[]
                    {
                        new ColumnModificationParameters(
                            entry,
                            property,
                            property.GetTableColumnMappings().Single().Column,
                            parameterNameGenerator.GenerateNext,
                            property.GetTableColumnMappings().Single().TypeMapping,
                            false, true, false, false, true)
                    }));

            batch.AddCommand(
                CreateModificationCommand(
                    "T1",
                    null,
                    true,
                    new[]
                    {
                        new ColumnModificationParameters(
                            entry,
                            property,
                            property.GetTableColumnMappings().Single().Column,
                            parameterNameGenerator.GenerateNext,
                            property.GetTableColumnMappings().Single().TypeMapping,
                            false, true, false, false, true)
                    }));

            var storeCommand = batch.CreateStoreCommandBase();

            Assert.Equal(2, storeCommand.RelationalCommand.Parameters.Count);
            Assert.Equal("p0", storeCommand.RelationalCommand.Parameters[0].InvariantName);
            Assert.Equal("p1", storeCommand.RelationalCommand.Parameters[1].InvariantName);

            Assert.Equal(2, storeCommand.ParameterValues.Count);
            Assert.Equal(1, storeCommand.ParameterValues["p0"]);
            Assert.Equal(1, storeCommand.ParameterValues["p1"]);
        }

        [ConditionalFact]
        public void PopulateParameters_creates_parameter_for_write_ModificationCommand()
        {
            var entry = CreateEntry(EntityState.Added, generateKeyValues: true);
            var property = entry.EntityType.FindProperty("Id");
            entry.SetTemporaryValue(property, 1);

            var batch = new ModificationCommandBatchFake();
            var parameterNameGenerator = new ParameterNameGenerator();
            batch.AddCommand(
                CreateModificationCommand(
                    "T1",
                    null,
                    true,
                    new[]
                    {
                        new ColumnModificationParameters(
                            entry,
                            property,
                            property.GetTableColumnMappings().Single().Column,
                            parameterNameGenerator.GenerateNext,
                            property.GetTableColumnMappings().Single().TypeMapping,
                            valueIsRead: false, valueIsWrite: true, columnIsKey: false, columnIsCondition: false,
                            sensitiveLoggingEnabled: true)
                    }));

            var storeCommand = batch.CreateStoreCommandBase();

            Assert.Equal(1, storeCommand.RelationalCommand.Parameters.Count);
            Assert.Equal("p0", storeCommand.RelationalCommand.Parameters[0].InvariantName);

            Assert.Equal(1, storeCommand.ParameterValues.Count);
            Assert.Equal(1, storeCommand.ParameterValues["p0"]);
        }

        [ConditionalFact]
        public void PopulateParameters_creates_parameter_for_condition_ModificationCommand()
        {
            var entry = CreateEntry(EntityState.Added, generateKeyValues: true);
            var property = entry.EntityType.FindProperty("Id");
            entry.SetTemporaryValue(property, 1);

            var batch = new ModificationCommandBatchFake();
            var parameterNameGenerator = new ParameterNameGenerator();
            batch.AddCommand(
                CreateModificationCommand(
                    "T1",
                    null,
                    true,
                    new[]
                    {
                        new ColumnModificationParameters(
                            entry,
                            property,
                            property.GetTableColumnMappings().Single().Column,
                            parameterNameGenerator.GenerateNext,
                            property.GetTableColumnMappings().Single().TypeMapping,
                            valueIsRead: false, valueIsWrite: false, columnIsKey: false, columnIsCondition: true,
                            sensitiveLoggingEnabled: true)
                    }));

            var storeCommand = batch.CreateStoreCommandBase();

            Assert.Equal(1, storeCommand.RelationalCommand.Parameters.Count);
            Assert.Equal("p0", storeCommand.RelationalCommand.Parameters[0].InvariantName);

            Assert.Equal(1, storeCommand.ParameterValues.Count);
            Assert.Equal(1, storeCommand.ParameterValues["p0"]);
        }

        [ConditionalFact]
        public void PopulateParameters_creates_parameters_for_write_and_condition_ModificationCommand()
        {
            var entry = CreateEntry(EntityState.Added, generateKeyValues: true);
            var property = entry.EntityType.FindProperty("Id");
            entry.SetTemporaryValue(property, 1);

            var batch = new ModificationCommandBatchFake();
            var parameterNameGenerator = new ParameterNameGenerator();
            batch.AddCommand(
                CreateModificationCommand(
                    "T1",
                    null,
                    true,
                    new[]
                    {
                        new ColumnModificationParameters(
                            entry,
                            property,
                            property.GetTableColumnMappings().Single().Column,
                            parameterNameGenerator.GenerateNext,
                            property.GetTableColumnMappings().Single().TypeMapping,
                            valueIsRead: false, valueIsWrite: true, columnIsKey: false, columnIsCondition: true,
                            sensitiveLoggingEnabled: true)
                    }));

            var storeCommand = batch.CreateStoreCommandBase();

            Assert.Equal(2, storeCommand.RelationalCommand.Parameters.Count);
            Assert.Equal("p0", storeCommand.RelationalCommand.Parameters[0].InvariantName);
            Assert.Equal("p1", storeCommand.RelationalCommand.Parameters[1].InvariantName);

            Assert.Equal(2, storeCommand.ParameterValues.Count);
            Assert.Equal(1, storeCommand.ParameterValues["p0"]);
            Assert.Equal(1, storeCommand.ParameterValues["p1"]);
        }

        [ConditionalFact]
        public void PopulateParameters_does_not_create_parameter_for_read_ModificationCommand()
        {
            var entry = CreateEntry(EntityState.Added, generateKeyValues: true);
            var property = entry.EntityType.FindProperty("Id");
            entry.SetTemporaryValue(property, -1);

            var batch = new ModificationCommandBatchFake();
            var parameterNameGenerator = new ParameterNameGenerator();
            batch.AddCommand(
                CreateModificationCommand(
                    "T1",
                    null,
                    true,
                    new[]
                    {
                        new ColumnModificationParameters(
                            entry,
                            property,
                            property.GetTableColumnMappings().Single().Column,
                            parameterNameGenerator.GenerateNext,
                            property.GetTableColumnMappings().Single().TypeMapping,
                            valueIsRead: true, valueIsWrite: false, columnIsKey: false, columnIsCondition: false,
                            sensitiveLoggingEnabled: true)
                    }));

            var storeCommand = batch.CreateStoreCommandBase();

            Assert.Equal(0, storeCommand.RelationalCommand.Parameters.Count);
        }

        private class T1
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private static IModel BuildModel(bool generateKeyValues, bool computeNonKeyValue)
        {
            var modelBuilder = RelationalTestHelpers.Instance.CreateConventionBuilder();
            var entityType = modelBuilder.Entity<T1>();

            entityType.Property(t => t.Id).HasColumnName("Col1");
            if (!generateKeyValues)
            {
                entityType.Property(t => t.Id).ValueGeneratedNever();
            }

            entityType.Property(t => t.Name).HasColumnName("Col2");
            if (computeNonKeyValue)
            {
                entityType.Property(t => t.Name).ValueGeneratedOnAddOrUpdate();
            }

            return modelBuilder.FinalizeModel();
        }

        private static InternalEntityEntry CreateEntry(
            EntityState entityState,
            bool generateKeyValues = false,
            bool computeNonKeyValue = false)
        {
            var model = BuildModel(generateKeyValues, computeNonKeyValue);

            return RelationalTestHelpers.Instance.CreateInternalEntry(
                model, entityState, new T1 { Id = 1, Name = computeNonKeyValue ? null : "Test" });
        }

        private static FakeDbDataReader CreateFakeDataReader(string[] columnNames = null, IList<object[]> results = null)
        {
            results ??= new List<object[]> { new object[] { 1 } };
            columnNames ??= new[] { "RowsAffected" };

            return new FakeDbDataReader(columnNames, results);
        }

        private class ModificationCommandBatchFake : AffectedCountModificationCommandBatch
        {
            public ModificationCommandBatchFake(
                IUpdateSqlGenerator sqlGenerator = null)
                : base(CreateDependencies(sqlGenerator))
            {
                ShouldAddCommand = true;
                ShouldValidateSql = true;
            }

            private static ModificationCommandBatchFactoryDependencies CreateDependencies(
                IUpdateSqlGenerator sqlGenerator)
            {
                var typeMappingSource = new TestRelationalTypeMappingSource(
                    TestServiceFactory.Instance.Create<TypeMappingSourceDependencies>(),
                    TestServiceFactory.Instance.Create<RelationalTypeMappingSourceDependencies>());

                var logger = new FakeRelationalCommandDiagnosticsLogger();

                return new ModificationCommandBatchFactoryDependencies(
                    new RelationalCommandBuilderFactory(
                        new RelationalCommandBuilderDependencies(
                            typeMappingSource)),
                    new RelationalSqlGenerationHelper(
                        new RelationalSqlGenerationHelperDependencies()),
                    sqlGenerator
                    ?? new FakeSqlGenerator(
                        RelationalTestHelpers.Instance.CreateContextServices()
                            .GetRequiredService<UpdateSqlGeneratorDependencies>()),
                    new TypedRelationalValueBufferFactoryFactory(
                        new RelationalValueBufferFactoryDependencies(
                            typeMappingSource,
                            new CoreSingletonOptions())),
                    new CurrentDbContext(new FakeDbContext()),
                    logger);
            }

            public string CommandText
                => GetCommandText();

            public bool ShouldAddCommand { get; set; }

            protected override bool CanAddCommand(IReadOnlyModificationCommand modificationCommand)
                => ShouldAddCommand;

            public bool ShouldValidateSql { get; set; }

            protected override bool IsCommandTextValid()
                => ShouldValidateSql;

            protected override void UpdateCachedCommandText(int commandIndex)
                => CachedCommandText.Append(".");

            public void UpdateCachedCommandTextBase(int commandIndex)
                => base.UpdateCachedCommandText(commandIndex);

            public RawSqlCommand CreateStoreCommandBase()
                => CreateStoreCommand();
        }

        private class FakeDbContext : DbContext
        {
        }

        private const string ConnectionString = "Fake Connection String";

        private static FakeRelationalConnection CreateConnection(FakeCommandExecutor executor)
            => CreateConnection(
                CreateOptions(
                    new FakeRelationalOptionsExtension().WithConnection(
                        new FakeDbConnection(ConnectionString, executor))));

        private static FakeRelationalConnection CreateConnection(DbDataReader dbDataReader)
            => CreateConnection(
                new FakeCommandExecutor(
                    executeReaderAsync: (c, b, ct) => Task.FromResult(dbDataReader),
                    executeReader: (c, b) => dbDataReader));

        private static FakeRelationalConnection CreateConnection(IDbContextOptions options = null)
            => new(options ?? CreateOptions());

        public static IDbContextOptions CreateOptions(RelationalOptionsExtension optionsExtension = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder();

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder)
                .AddOrUpdateExtension(
                    optionsExtension
                    ?? new FakeRelationalOptionsExtension().WithConnectionString(ConnectionString));

            return optionsBuilder.Options;
        }

        private static IModificationCommand CreateModificationCommand(
            string table,
            string schema,
            Func<string> generateParameterName,
            bool sensitiveLoggingEnabled,
            IComparer<IUpdateEntry> comparer)
        {
            var modificationCommandParameters = new ModificationCommandParameters(
                table,
                schema,
                sensitiveLoggingEnabled,
                comparer,
                generateParameterName,
                logger: null);
            return CreateModificationCommandSource().CreateModificationCommand(modificationCommandParameters);
        }

        private static IModificationCommand CreateModificationCommand(
            string name,
            string schema,
            bool sensitiveLoggingEnabled,
            IReadOnlyList<ColumnModificationParameters> columnModifications)
        {
            var modificationCommandParameters = new ModificationCommandParameters(
                name, schema, sensitiveLoggingEnabled);

            var modificationCommand = CreateModificationCommandSource().CreateModificationCommand(
                modificationCommandParameters);

            if (columnModifications != null)
            {
                foreach (var columnModification in columnModifications)
                {
                    modificationCommand.AddColumnModification(columnModification);
                }
            }

            return modificationCommand;
        }

        private static ModificationCommandFactory CreateModificationCommandSource()
            => new();
    }
}
