using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<UnitPositionStorage>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        builder.Register<UnitStatStorage>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        builder.Register<ResourcesStorage>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        
        builder.Register<PlayerPrefsGameRepository>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        
        builder.Register<UnitPositionSaveLoader>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
        builder.Register<ResourcesSaveLoader>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
        builder.Register<UnitStatsSaveLoader>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
        
        base.Configure(builder);
    }
}
