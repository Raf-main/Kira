﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Kira.Infrastructure.Shared.Repositories.MongoDb;

public abstract class MongoDbContext : IMongoDbContext
{
    public IClientSessionHandle? Session { get; set; }
    public IMongoDatabase Database { get; }
    public IMongoClient MongoClient { get; }
    protected readonly IList<Func<Task>> _commands;

    protected MongoDbContext(MongoOptions options)
    {
        RegisterConventions();
        MongoClient = new MongoClient(options.ConnectionString);
        var databaseName = options.DatabaseName;
        Database = MongoClient.GetDatabase(databaseName);
        _commands = new List<Func<Task>>();
    }

    private static void RegisterConventions()
    {
        ConventionRegistry.Register(
            "conventions",
            new ConventionPack
            {
                new CamelCaseElementNameConvention(),
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new IgnoreIfDefaultConvention(false),
            }, _ => true);
    }

    public IMongoCollection<T> GetCollection<T>(string? name = null)
    {
        return Database.GetCollection<T>(name ?? typeof(T).Name.ToLower());
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = _commands.Count;

        using (Session = await MongoClient.StartSessionAsync(cancellationToken: cancellationToken))
        {
            Session.StartTransaction();

            try
            {
                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await Session.AbortTransactionAsync(cancellationToken);
                _commands.Clear();
                throw;
            }
        }

        _commands.Clear();
        return result;
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        Session = await MongoClient.StartSessionAsync(cancellationToken: cancellationToken);
        Session.StartTransaction();
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (Session is { IsInTransaction: true })
            await Session.CommitTransactionAsync(cancellationToken);

        Session?.Dispose();
    }

    public async Task RollbackTransaction(CancellationToken cancellationToken = default)
    {
        await Session?.AbortTransactionAsync(cancellationToken)!;
    }

    public void AddCommand(Func<Task> func)
    {
        _commands.Add(func);
    }

    public async Task ExecuteTransactionalAsync(Func<Task> action, CancellationToken cancellationToken = default)
    {
        await BeginTransactionAsync(cancellationToken);
        try
        {
            await action();

            await CommitTransactionAsync(cancellationToken);
        }
        catch
        {
            await RollbackTransaction(cancellationToken);
            throw;
        }
    }

    public async Task<T> ExecuteTransactionalAsync<T>(
        Func<Task<T>> action,
        CancellationToken cancellationToken = default)
    {
        await BeginTransactionAsync(cancellationToken);
        try
        {
            var result = await action();

            await CommitTransactionAsync(cancellationToken);

            return result;
        }
        catch
        {
            await RollbackTransaction(cancellationToken);
            throw;
        }
    }
}