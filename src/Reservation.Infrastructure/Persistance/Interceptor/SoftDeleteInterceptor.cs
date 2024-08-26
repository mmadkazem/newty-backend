namespace Reservation.Infrastructure.Persistance.Interceptor;


public sealed class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null) return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry is { State: EntityState.Deleted, Entity: BaseClass<Guid> entityGuid })
            {
                entityGuid.IsDeleted = true;
                entityGuid.DeletedOn = DateTime.Now;
                entry.State = EntityState.Modified;
            }
            if (entry is { State: EntityState.Deleted, Entity: BaseClass<int> entityInt })
            {
                entityInt.IsDeleted = true;
                entityInt.DeletedOn = DateTime.Now;
                entry.State = EntityState.Modified;
            }
        }

        await ValueTask.CompletedTask;
        return result;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is null) return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry is { State: EntityState.Deleted, Entity: BaseClass<Guid> entityGuid })
            {
                entityGuid.IsDeleted = true;
                entityGuid.DeletedOn = DateTime.Now;
                entry.State = EntityState.Modified;
            }
            if (entry is { State: EntityState.Deleted, Entity: BaseClass<int> entityInt })
            {
                entityInt.IsDeleted = true;
                entityInt.DeletedOn = DateTime.Now;
                entry.State = EntityState.Modified;
            }
        }

        return result;
    }
}