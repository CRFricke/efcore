// <auto-generated />

using System;
using System.Reflection;
using System.Resources;

#nullable enable

namespace Microsoft.EntityFrameworkCore.Internal
{
    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public static class DesignStrings
    {
        private static readonly ResourceManager _resourceManager
            = new ResourceManager("Microsoft.EntityFrameworkCore.Properties.DesignStrings", typeof(DesignStrings).Assembly);

        /// <summary>
        ///     Failed creating connection: {exceptionMessage}
        /// </summary>
        public static string BadConnection(object? exceptionMessage)
            => string.Format(
                GetString("BadConnection", nameof(exceptionMessage)),
                exceptionMessage);

        /// <summary>
        ///     Cannot scaffold sequence '{sequenceName}' because it uses type '{typeName}' which is unsupported.
        /// </summary>
        public static string BadSequenceType(object? sequenceName, object? typeName)
            => string.Format(
                GetString("BadSequenceType", nameof(sequenceName), nameof(typeName)),
                sequenceName, typeName);

        /// <summary>
        ///     Entity Framework Core Migrations Bundle
        /// </summary>
        public static string BundleFullName
            => GetString("BundleFullName");

        /// <summary>
        ///     Unable to find expected assembly attribute [DesignTimeProviderServices] in provider assembly '{runtimeProviderAssemblyName}'. This attribute is required to identify the class which acts as the design-time service provider factory for the provider.
        /// </summary>
        public static string CannotFindDesignTimeProviderAssemblyAttribute(object? runtimeProviderAssemblyName)
            => string.Format(
                GetString("CannotFindDesignTimeProviderAssemblyAttribute", nameof(runtimeProviderAssemblyName)),
                runtimeProviderAssemblyName);

        /// <summary>
        ///     Unable to find provider assembly '{assemblyName}'. Ensure the name is correct and it's referenced by the project.
        /// </summary>
        public static string CannotFindRuntimeProviderAssembly(object? assemblyName)
            => string.Format(
                GetString("CannotFindRuntimeProviderAssembly", nameof(assemblyName)),
                assemblyName);

        /// <summary>
        ///     Could not find type mapping for column '{columnName}' with data type '{dateType}'. Skipping column.
        /// </summary>
        public static string CannotFindTypeMappingForColumn(object? columnName, object? dateType)
            => string.Format(
                GetString("CannotFindTypeMappingForColumn", nameof(columnName), nameof(dateType)),
                columnName, dateType);

        /// <summary>
        ///     A type-qualified method call requires an instance identifier, a MethodInfo and no chained calls.
        /// </summary>
        public static string CannotGenerateTypeQualifiedMethodCall
            => GetString("CannotGenerateTypeQualifiedMethodCall");

        /// <summary>
        ///     The entity type '{entityType}' has a custom constructor binding. This is usually caused by using proxies. Compiled model can't be generated, because dynamic proxy types are not supported. If you are not using proxies configure the custom constructor binding in '{customize}' in a partial '{className}' class instead.
        /// </summary>
        public static string CompiledModelConstructorBinding(object? entityType, object? customize, object? className)
            => string.Format(
                GetString("CompiledModelConstructorBinding", nameof(entityType), nameof(customize), nameof(className)),
                entityType, customize, className);

        /// <summary>
        ///     The context is configured to use a custom model cache key factory '{factoryType}', this usually indicates that the produced model can change between context instances. To preserve this behavior manually modify the generated compiled model source code.
        /// </summary>
        public static string CompiledModelCustomCacheKeyFactory(object? factoryType)
            => string.Format(
                GetString("CompiledModelCustomCacheKeyFactory", nameof(factoryType)),
                factoryType);

        /// <summary>
        ///     The entity type '{entityType}' has a defining query configured. Compiled model can't be generated, because defining queries are not supported.
        /// </summary>
        public static string CompiledModelDefiningQuery(object? entityType)
            => string.Format(
                GetString("CompiledModelDefiningQuery", nameof(entityType)),
                entityType);

        /// <summary>
        ///     Successfully generated a compiled model, to use it call '{optionsCall}'. Run this command again when the model is modified.
        /// </summary>
        public static string CompiledModelGenerated(object? optionsCall)
            => string.Format(
                GetString("CompiledModelGenerated", nameof(optionsCall)),
                optionsCall);

        /// <summary>
        ///     The entity type '{entityType}' has a query filter configured. Compiled model can't be generated, because query filters are not supported.
        /// </summary>
        public static string CompiledModelQueryFilter(object? entityType)
            => string.Format(
                GetString("CompiledModelQueryFilter", nameof(entityType)),
                entityType);

        /// <summary>
        ///     The property '{entityType}.{property}' has a custom type mapping configured. Configure it in '{customize}' in a partial '{className}' class instead.
        /// </summary>
        public static string CompiledModelTypeMapping(object? entityType, object? property, object? customize, object? className)
            => string.Format(
                GetString("CompiledModelTypeMapping", nameof(entityType), nameof(property), nameof(customize), nameof(className)),
                entityType, property, customize, className);

        /// <summary>
        ///     The property '{entityType}.{property}' has a value comparer configured using a ValueComparer instance. Instead, create types that inherit from ValueConverter and ValueComparer and use '{method}=&lt;ConverterType, ComparerType=&gt;()' or '{method}(Type converterType, Type comparerType)' to configure the value converter and comparer.
        /// </summary>
        public static string CompiledModelValueComparer(object? entityType, object? property, object? method)
            => string.Format(
                GetString("CompiledModelValueComparer", nameof(entityType), nameof(property), nameof(method)),
                entityType, property, method);

        /// <summary>
        ///     The property '{entityType}.{property}' has a value converter configured using a ValueConverter instance or inline expressions. Instead, create a type that inherits from ValueConverter and use '{method}=&lt;ConverterType=&gt;()' or '{method}(Type converterType)' to configure the value converter.
        /// </summary>
        public static string CompiledModelValueConverter(object? entityType, object? property, object? method)
            => string.Format(
                GetString("CompiledModelValueConverter", nameof(entityType), nameof(property), nameof(method)),
                entityType, property, method);

        /// <summary>
        ///     The property '{entityType}.{property}' has a value generator configured. Use '{method}' to configure the value generator factory type.
        /// </summary>
        public static string CompiledModelValueGenerator(object? entityType, object? property, object? method)
            => string.Format(
                GetString("CompiledModelValueGenerator", nameof(entityType), nameof(property), nameof(method)),
                entityType, property, method);

        /// <summary>
        ///     The name you have chosen for the migration, '{name}', is the same as the context class name. Please choose a different name for your migration. Might we suggest 'InitialCreate' for your first migration?
        /// </summary>
        public static string ConflictingContextAndMigrationName(object? name)
            => string.Format(
                GetString("ConflictingContextAndMigrationName", nameof(name)),
                name);

        /// <summary>
        ///     The connection string to the database. Defaults to the one specified in AddDbContext or OnConfiguring.
        /// </summary>
        public static string ConnectionDescription
            => GetString("ConnectionDescription");

        /// <summary>
        ///     The context class name '{contextClassName}' is not a valid C# identifier.
        /// </summary>
        public static string ContextClassNotValidCSharpIdentifier(object? contextClassName)
            => string.Format(
                GetString("ContextClassNotValidCSharpIdentifier", nameof(contextClassName)),
                contextClassName);

        /// <summary>
        ///     Successfully dropped database '{name}'.
        /// </summary>
        public static string DatabaseDropped(object? name)
            => string.Format(
                GetString("DatabaseDropped", nameof(name)),
                name);

        /// <summary>
        ///     An operation was scaffolded that may result in the loss of data. Please review the migration for accuracy.
        /// </summary>
        public static string DestructiveOperation
            => GetString("DestructiveOperation");

        /// <summary>
        ///     Done.
        /// </summary>
        public static string Done
            => GetString("Done");

        /// <summary>
        ///     Dropping database '{database}' on server '{dataSource}'.
        /// </summary>
        public static string DroppingDatabase(object? database, object? dataSource)
            => string.Format(
                GetString("DroppingDatabase", nameof(database), nameof(dataSource)),
                database, dataSource);

        /// <summary>
        ///     The name '{migrationName}' is used by an existing migration.
        /// </summary>
        public static string DuplicateMigrationName(object? migrationName)
            => string.Format(
                GetString("DuplicateMigrationName", nameof(migrationName)),
                migrationName);

        /// <summary>
        ///     The encoding '{encoding}' specified in the output directive will be ignored. EF Core always scaffolds files using the encoding 'utf-8'.
        /// </summary>
        public static string EncodingIgnored(object? encoding)
            => string.Format(
                GetString("EncodingIgnored", nameof(encoding)),
                encoding);

        /// <summary>
        ///     An error occurred while accessing the database. Continuing without the information provided by the database. Error: {message}
        /// </summary>
        public static string ErrorConnecting(object? message)
            => string.Format(
                GetString("ErrorConnecting", nameof(message)),
                message);

        /// <summary>
        ///     The following file(s) already exist in directory '{outputDirectoryName}': {existingFiles}. Use the Force flag to overwrite these files.
        /// </summary>
        public static string ExistingFiles(object? outputDirectoryName, object? existingFiles)
            => string.Format(
                GetString("ExistingFiles", nameof(outputDirectoryName), nameof(existingFiles)),
                outputDirectoryName, existingFiles);

        /// <summary>
        ///     Finding IDesignTimeDbContextFactory implementations...
        /// </summary>
        public static string FindingContextFactories
            => GetString("FindingContextFactories");

        /// <summary>
        ///     Finding DbContext classes...
        /// </summary>
        public static string FindingContexts
            => GetString("FindingContexts");

        /// <summary>
        ///     Finding IDesignTimeServices implementations in assembly '{startupAssembly}'...
        /// </summary>
        public static string FindingDesignTimeServices(object? startupAssembly)
            => string.Format(
                GetString("FindingDesignTimeServices", nameof(startupAssembly)),
                startupAssembly);

        /// <summary>
        ///     Finding Microsoft.Extensions.Hosting service provider...
        /// </summary>
        public static string FindingHostingServices
            => GetString("FindingHostingServices");

        /// <summary>
        ///     Finding design-time services for provider '{provider}'...
        /// </summary>
        public static string FindingProviderServices(object? provider)
            => string.Format(
                GetString("FindingProviderServices", nameof(provider)),
                provider);

        /// <summary>
        ///     Finding DbContext classes in the project...
        /// </summary>
        public static string FindingReferencedContexts
            => GetString("FindingReferencedContexts");

        /// <summary>
        ///     Finding design-time services referenced by assembly '{startupAssembly}'...
        /// </summary>
        public static string FindingReferencedServices(object? startupAssembly)
            => string.Format(
                GetString("FindingReferencedServices", nameof(startupAssembly)),
                startupAssembly);

        /// <summary>
        ///     Finding application service provider in assembly '{startupAssembly}'...
        /// </summary>
        public static string FindingServiceProvider(object? startupAssembly)
            => string.Format(
                GetString("FindingServiceProvider", nameof(startupAssembly)),
                startupAssembly);

        /// <summary>
        ///     Unable to check if the migration '{name}' has been applied to the database. If it has, you will need to manually revert its changes. Error encountered while checking: {error}
        /// </summary>
        public static string ForceRemoveMigration(object? name, object? error)
            => string.Format(
                GetString("ForceRemoveMigration", nameof(name), nameof(error)),
                name, error);

        /// <summary>
        ///     The principal end of the foreign key '{foreignKeyName}' is supported by the unique index '{indexName}' and contains the following nullable columns '{columnNames}'. Entity Framework requires the properties representing those columns to be non-nullable.
        /// </summary>
        public static string ForeignKeyPrincipalEndContainsNullableColumns(object? foreignKeyName, object? indexName, object? columnNames)
            => string.Format(
                GetString("ForeignKeyPrincipalEndContainsNullableColumns", nameof(foreignKeyName), nameof(indexName), nameof(columnNames)),
                foreignKeyName, indexName, columnNames);

        /// <summary>
        ///     Could not scaffold the foreign key '{foreignKeyName}'. A key for '{columnsList}' was not found in the principal entity type '{principalEntityType}'.
        /// </summary>
        public static string ForeignKeyScaffoldErrorPrincipalKeyNotFound(object? foreignKeyName, object? columnsList, object? principalEntityType)
            => string.Format(
                GetString("ForeignKeyScaffoldErrorPrincipalKeyNotFound", nameof(foreignKeyName), nameof(columnsList), nameof(principalEntityType)),
                foreignKeyName, columnsList, principalEntityType);

        /// <summary>
        ///     Could not scaffold the foreign key '{foreignKeyName}'. The referenced table could not be found. This most likely occurred because the referenced table was excluded from scaffolding.
        /// </summary>
        public static string ForeignKeyScaffoldErrorPrincipalTableNotFound(object? foreignKeyName)
            => string.Format(
                GetString("ForeignKeyScaffoldErrorPrincipalTableNotFound", nameof(foreignKeyName)),
                foreignKeyName);

        /// <summary>
        ///     Could not scaffold the foreign key '{foreignKeyName}'. The referenced table '{principalTableName}' could not be scaffolded.
        /// </summary>
        public static string ForeignKeyScaffoldErrorPrincipalTableScaffoldingError(object? foreignKeyName, object? principalTableName)
            => string.Format(
                GetString("ForeignKeyScaffoldErrorPrincipalTableScaffoldingError", nameof(foreignKeyName), nameof(principalTableName)),
                foreignKeyName, principalTableName);

        /// <summary>
        ///     Could not scaffold the foreign key '{foreignKeyName}'.  The following columns in the foreign key could not be scaffolded: {columnNames}.
        /// </summary>
        public static string ForeignKeyScaffoldErrorPropertyNotFound(object? foreignKeyName, object? columnNames)
            => string.Format(
                GetString("ForeignKeyScaffoldErrorPropertyNotFound", nameof(foreignKeyName), nameof(columnNames)),
                foreignKeyName, columnNames);

        /// <summary>
        ///     Could not scaffold the foreign key '{foreignKeyName}'. Foreign key '{existingForeignKey}' is defined on same columns targeting same key on principal table.
        /// </summary>
        public static string ForeignKeyWithSameFacetsExists(object? foreignKeyName, object? existingForeignKey)
            => string.Format(
                GetString("ForeignKeyWithSameFacetsExists", nameof(foreignKeyName), nameof(existingForeignKey)),
                foreignKeyName, existingForeignKey);

        /// <summary>
        ///     The namespace '{migrationsNamespace}' contains migrations for a different DbContext. This can result in conflicting migration names. It's recommend to put migrations for different DbContext classes into different namespaces.
        /// </summary>
        public static string ForeignMigrations(object? migrationsNamespace)
            => string.Format(
                GetString("ForeignMigrations", nameof(migrationsNamespace)),
                migrationsNamespace);

        /// <summary>
        ///     Found IDesignTimeDbContextFactory implementation '{factory}'.
        /// </summary>
        public static string FoundContextFactory(object? factory)
            => string.Format(
                GetString("FoundContextFactory", nameof(factory)),
                factory);

        /// <summary>
        ///     Found DbContext '{contextType}'.
        /// </summary>
        public static string FoundDbContext(object? contextType)
            => string.Format(
                GetString("FoundDbContext", nameof(contextType)),
                contextType);

        /// <summary>
        ///     An error occurred while accessing the Microsoft.Extensions.Hosting services. Continuing without the application service provider. Error: {error}
        /// </summary>
        public static string InvokeCreateHostBuilderFailed(object? error)
            => string.Format(
                GetString("InvokeCreateHostBuilderFailed", nameof(error)),
                error);

        /// <summary>
        ///     The literal expression '{expression}' for '{type}' cannot be parsed. Only simple constructor calls and factory methods are supported.
        /// </summary>
        public static string LiteralExpressionNotSupported(object? expression, object? type)
            => string.Format(
                GetString("LiteralExpressionNotSupported", nameof(expression), nameof(type)),
                expression, type);

        /// <summary>
        ///     An unexpected return type was encountered while accessing the Microsoft.Extensions.Hosting services. Method 'CreateHostBuilder(string[])' should return an object of type 'IHostBuilder'. Continuing without the application service provider.
        /// </summary>
        public static string MalformedCreateHostBuilder
            => GetString("MalformedCreateHostBuilder");

        /// <summary>
        ///     The model snapshot and the backing model of the last migration are different. Continuing under the assumption that the last migration was deleted manually.
        /// </summary>
        public static string ManuallyDeleted
            => GetString("ManuallyDeleted");

        /// <summary>
        ///     The target migration. If '0', all migrations will be reverted. Defaults to the last migration.
        /// </summary>
        public static string MigrationDescription
            => GetString("MigrationDescription");

        /// <summary>
        ///     Your target project '{assembly}' doesn't match your migrations assembly '{migrationsAssembly}'. Either change your target project or change your migrations assembly.
        ///     Change your migrations assembly by using DbContextOptionsBuilder. E.g. options.UseSqlServer(connection, b =&gt; b.MigrationsAssembly("{assembly}")). By default, the migrations assembly is the assembly containing the DbContext.
        ///     Change your target project to the migrations project by using the Package Manager Console's Default project drop-down list, or by executing "dotnet ef" from the directory containing the migrations project.
        /// </summary>
        public static string MigrationsAssemblyMismatch(object? assembly, object? migrationsAssembly)
            => string.Format(
                GetString("MigrationsAssemblyMismatch", nameof(assembly), nameof(migrationsAssembly)),
                assembly, migrationsAssembly);

        /// <summary>
        ///     The annotation '{annotationName}' was specified twice with potentially different values. Specifying the same annotation multiple times for different providers is no longer supported. Review the generated Migration to ensure it is correct and, if necessary, edit the Migration to fix any issues.
        /// </summary>
        public static string MultipleAnnotationConflict(object? annotationName)
            => string.Format(
                GetString("MultipleAnnotationConflict", nameof(annotationName)),
                annotationName);

        /// <summary>
        ///     More than one DbContext was found. Specify which one to use. Use the '-Context' parameter for PowerShell commands and the '--context' parameter for dotnet commands.
        /// </summary>
        public static string MultipleContexts
            => GetString("MultipleContexts");

        /// <summary>
        ///     More than one DbContext named '{name}' was found. Specify which one to use by providing its fully qualified name.
        /// </summary>
        public static string MultipleContextsWithName(object? name)
            => string.Format(
                GetString("MultipleContextsWithName", nameof(name)),
                name);

        /// <summary>
        ///     More than one DbContext named '{name}' was found. Specify which one to use by providing its fully qualified name using its exact case.
        /// </summary>
        public static string MultipleContextsWithQualifiedName(object? name)
            => string.Format(
                GetString("MultipleContextsWithQualifiedName", nameof(name)),
                name);

        /// <summary>
        ///     Don't colorize output.
        /// </summary>
        public static string NoColorDescription
            => GetString("NoColorDescription");

        /// <summary>
        ///     No DbContext was found in assembly '{assembly}'. Ensure that you're using the correct assembly and that the type is neither abstract nor generic.
        /// </summary>
        public static string NoContext(object? assembly)
            => string.Format(
                GetString("NoContext", nameof(assembly)),
                assembly);

        /// <summary>
        ///     No DbContext named '{name}' was found.
        /// </summary>
        public static string NoContextWithName(object? name)
            => string.Format(
                GetString("NoContextWithName", nameof(name)),
                name);

        /// <summary>
        ///     No static method 'CreateHostBuilder(string[])' was found on class 'Program'.
        /// </summary>
        public static string NoCreateHostBuilder
            => GetString("NoCreateHostBuilder");

        /// <summary>
        ///     No design-time services were found.
        /// </summary>
        public static string NoDesignTimeServices
            => GetString("NoDesignTimeServices");

        /// <summary>
        ///     The project language '{language}' isn't supported by the built-in {service} service. You can try looking for an additional NuGet package which supports this language; moving your DbContext type to a C# class library referenced by this project; or manually implementing and registering the design-time service for the programming language.
        /// </summary>
        public static string NoLanguageService(object? language, object? service)
            => string.Format(
                GetString("NoLanguageService", nameof(language), nameof(service)),
                language, service);

        /// <summary>
        ///     No file named '{file}' was found. You must manually remove the migration class '{migrationClass}'.
        /// </summary>
        public static string NoMigrationFile(object? file, object? migrationClass)
            => string.Format(
                GetString("NoMigrationFile", nameof(file), nameof(migrationClass)),
                file, migrationClass);

        /// <summary>
        ///     No file named '{file}' was found.
        /// </summary>
        public static string NoMigrationMetadataFile(object? file)
            => string.Format(
                GetString("NoMigrationMetadataFile", nameof(file)),
                file);

        /// <summary>
        ///     The column '{columnName}' would normally be mapped to a non-nullable bool property, but it has a default constraint. Such a column is mapped to a nullable bool property to allow a difference between setting the property to false and invoking the default constraint. See https://go.microsoft.com/fwlink/?linkid=851278 for details.
        /// </summary>
        public static string NonNullableBoooleanColumnHasDefaultConstraint(object? columnName)
            => string.Format(
                GetString("NonNullableBoooleanColumnHasDefaultConstraint", nameof(columnName)),
                columnName);

        /// <summary>
        ///     The provider '{provider}' is not a Relational provider and therefore cannot be used with Migrations.
        /// </summary>
        public static string NonRelationalProvider(object? provider)
            => string.Format(
                GetString("NonRelationalProvider", nameof(provider)),
                provider);

        /// <summary>
        ///     Unable to create an object of type '{contextType}'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
        /// </summary>
        public static string NoParameterlessConstructor(object? contextType)
            => string.Format(
                GetString("NoParameterlessConstructor", nameof(contextType)),
                contextType);

        /// <summary>
        ///     No referenced design-time services were found.
        /// </summary>
        public static string NoReferencedServices
            => GetString("NoReferencedServices");

        /// <summary>
        ///     Connection information is only available for relational database providers.
        /// </summary>
        public static string NoRelationalConnection
            => GetString("NoRelationalConnection");

        /// <summary>
        ///     No application service provider was found.
        /// </summary>
        public static string NoServiceProvider
            => GetString("NoServiceProvider");

        /// <summary>
        ///     No ModelSnapshot was found.
        /// </summary>
        public static string NoSnapshot
            => GetString("NoSnapshot");

        /// <summary>
        ///     No file named '{file}' was found. You must manually remove the model snapshot class '{snapshotClass}'.
        /// </summary>
        public static string NoSnapshotFile(object? file, object? snapshotClass)
            => string.Format(
                GetString("NoSnapshotFile", nameof(file), nameof(snapshotClass)),
                file, snapshotClass);

        /// <summary>
        ///     Database '{name}' did not exist, no action was taken.
        /// </summary>
        public static string NotExistDatabase(object? name)
            => string.Format(
                GetString("NotExistDatabase", nameof(name)),
                name);

        /// <summary>
        ///     Prefix output with level.
        /// </summary>
        public static string PrefixDescription
            => GetString("PrefixDescription");

        /// <summary>
        ///     Could not scaffold the primary key for '{tableName}'. The following columns in the primary key could not be scaffolded: {columnNames}.
        /// </summary>
        public static string PrimaryKeyErrorPropertyNotFound(object? tableName, object? columnNames)
            => string.Format(
                GetString("PrimaryKeyErrorPropertyNotFound", nameof(tableName), nameof(columnNames)),
                tableName, columnNames);

        /// <summary>
        ///     Metadata model returned should not be null. Provider: {providerTypeName}.
        /// </summary>
        public static string ProviderReturnedNullModel(object? providerTypeName)
            => string.Format(
                GetString("ProviderReturnedNullModel", nameof(providerTypeName)),
                providerTypeName);

        /// <summary>
        ///     No files were generated in directory '{outputDirectoryName}'. The following file(s) already exist(s) and must be made writeable to continue: {readOnlyFiles}.
        /// </summary>
        public static string ReadOnlyFiles(object? outputDirectoryName, object? readOnlyFiles)
            => string.Format(
                GetString("ReadOnlyFiles", nameof(outputDirectoryName), nameof(readOnlyFiles)),
                outputDirectoryName, readOnlyFiles);

        /// <summary>
        ///     Removing migration '{name}'.
        /// </summary>
        public static string RemovingMigration(object? name)
            => string.Format(
                GetString("RemovingMigration", nameof(name)),
                name);

        /// <summary>
        ///     Removing model snapshot.
        /// </summary>
        public static string RemovingSnapshot
            => GetString("RemovingSnapshot");

        /// <summary>
        ///     Reusing namespace of type '{type}'.
        /// </summary>
        public static string ReusingNamespace(object? type)
            => string.Format(
                GetString("ReusingNamespace", nameof(type)),
                type);

        /// <summary>
        ///     Reusing model snapshot name '{name}'.
        /// </summary>
        public static string ReusingSnapshotName(object? name)
            => string.Format(
                GetString("ReusingSnapshotName", nameof(name)),
                name);

        /// <summary>
        ///     Reverting the model snapshot.
        /// </summary>
        public static string RevertingSnapshot
            => GetString("RevertingSnapshot");

        /// <summary>
        ///     The migration '{name}' has already been applied to the database. Revert it and try again. If the migration has been applied to other databases, consider reverting its changes using a new migration instead.
        /// </summary>
        public static string RevertMigration(object? name)
            => string.Format(
                GetString("RevertMigration", nameof(name)),
                name);

        /// <summary>
        ///     To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        /// </summary>
        public static string SensitiveInformationWarning
            => GetString("SensitiveInformationWarning");

        /// <summary>
        ///     Sequence name cannot be null or empty. Entity Framework cannot model a sequence that does not have a name.
        /// </summary>
        public static string SequencesRequireName
            => GetString("SequencesRequireName");

        /// <summary>
        ///     Unable to generate entity type for table '{tableName}' since its primary key could not be scaffolded.
        /// </summary>
        public static string UnableToGenerateEntityType(object? tableName)
            => string.Format(
                GetString("UnableToGenerateEntityType", nameof(tableName)),
                tableName);

        /// <summary>
        ///     Unable to scaffold the index '{indexName}'. The following columns could not be scaffolded: {columnNames}.
        /// </summary>
        public static string UnableToScaffoldIndexMissingProperty(object? indexName, object? columnNames)
            => string.Format(
                GetString("UnableToScaffoldIndexMissingProperty", nameof(indexName), nameof(columnNames)),
                indexName, columnNames);

        /// <summary>
        ///     Unhandled enum value '{enumValue}'.
        /// </summary>
        public static string UnhandledEnumValue(object? enumValue)
            => string.Format(
                GetString("UnhandledEnumValue", nameof(enumValue)),
                enumValue);

        /// <summary>
        ///     Failed to resolve type for directive processor {name}.
        /// </summary>
        public static string UnknownDirectiveProcessor(object? name)
            => string.Format(
                GetString("UnknownDirectiveProcessor", nameof(name)),
                name);

        /// <summary>
        ///     Cannot scaffold C# literals of type '{literalType}'. The provider should implement CoreTypeMapping.GenerateCodeLiteral to support using it at design time.
        /// </summary>
        public static string UnknownLiteral(object? literalType)
            => string.Format(
                GetString("UnknownLiteral", nameof(literalType)),
                literalType);

        /// <summary>
        ///     The current CSharpMigrationOperationGenerator cannot scaffold operations of type '{operationType}'. Configure your design-time services to use one that can.
        /// </summary>
        public static string UnknownOperation(object? operationType)
            => string.Format(
                GetString("UnknownOperation", nameof(operationType)),
                operationType);

        /// <summary>
        ///     Could not load assembly '{assembly}'. Ensure it is referenced by the startup project '{startupProject}'.
        /// </summary>
        public static string UnreferencedAssembly(object? assembly, object? startupProject)
            => string.Format(
                GetString("UnreferencedAssembly", nameof(assembly), nameof(startupProject)),
                assembly, startupProject);

        /// <summary>
        ///     Using context '{name}'.
        /// </summary>
        public static string UseContext(object? name)
            => string.Format(
                GetString("UseContext", nameof(name)),
                name);

        /// <summary>
        ///     Using DbContext factory '{factory}'.
        /// </summary>
        public static string UsingDbContextFactory(object? factory)
            => string.Format(
                GetString("UsingDbContextFactory", nameof(factory)),
                factory);

        /// <summary>
        ///     Using design-time services from class '{designTimeServices}'.
        /// </summary>
        public static string UsingDesignTimeServices(object? designTimeServices)
            => string.Format(
                GetString("UsingDesignTimeServices", nameof(designTimeServices)),
                designTimeServices);

        /// <summary>
        ///     Using environment '{environment}'.
        /// </summary>
        public static string UsingEnvironment(object? environment)
            => string.Format(
                GetString("UsingEnvironment", nameof(environment)),
                environment);

        /// <summary>
        ///     Using application service provider from Microsoft.Extensions.Hosting.
        /// </summary>
        public static string UsingHostingServices
            => GetString("UsingHostingServices");

        /// <summary>
        ///     Using design-time services from provider '{provider}'.
        /// </summary>
        public static string UsingProviderServices(object? provider)
            => string.Format(
                GetString("UsingProviderServices", nameof(provider)),
                provider);

        /// <summary>
        ///     Using design-time services from assembly '{referencedAssembly}'.
        /// </summary>
        public static string UsingReferencedServices(object? referencedAssembly)
            => string.Format(
                GetString("UsingReferencedServices", nameof(referencedAssembly)),
                referencedAssembly);

        /// <summary>
        ///     Show verbose output.
        /// </summary>
        public static string VerboseDescription
            => GetString("VerboseDescription");

        /// <summary>
        ///     The Entity Framework tools version '{toolsVersion}' is older than that of the runtime '{runtimeVersion}'. Update the tools for the latest features and bug fixes. See https://aka.ms/AAc1fbw for more information.
        /// </summary>
        public static string VersionMismatch(object? toolsVersion, object? runtimeVersion)
            => string.Format(
                GetString("VersionMismatch", nameof(toolsVersion), nameof(runtimeVersion)),
                toolsVersion, runtimeVersion);

        /// <summary>
        ///     Writing migration to '{file}'.
        /// </summary>
        public static string WritingMigration(object? file)
            => string.Format(
                GetString("WritingMigration", nameof(file)),
                file);

        /// <summary>
        ///     Writing model snapshot to '{file}'.
        /// </summary>
        public static string WritingSnapshot(object? file)
            => string.Format(
                GetString("WritingSnapshot", nameof(file)),
                file);

        /// <summary>
        ///     You cannot add a migration with the name 'Migration'.
        /// </summary>
        public static string CircularBaseClassDependency
            => GetString("CircularBaseClassDependency");

        private static string GetString(string name, params string[] formatterNames)
        {
            var value = _resourceManager.GetString(name)!;
            for (var i = 0; i < formatterNames.Length; i++)
            {
                value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
            }

            return value;
        }
    }
}

