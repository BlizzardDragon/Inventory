using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        ConfigureInstallers(builder);
        ConfigureGameSystems(builder);
        ConfigureView(builder);
        ConfigurePresenters(builder);
        ConfigureTestClasses(builder);
    }

    private void ConfigureInstallers(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<MainInventoryInstaller>();
    }

    private void ConfigureGameSystems(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<Player>();
        builder.Register<Inventory>(Lifetime.Singleton);
        builder.Register<EquipmentInventory>(Lifetime.Singleton);
        builder.Register<ItemDistributor>(Lifetime.Singleton);
        builder.RegisterComponent(new EquipmentStatsApplier());
    }

    private void ConfigureView(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<ViewPlayerStats>();
    }

    private void ConfigurePresenters(IContainerBuilder builder)
    {
        builder.Register<ViewPlayerStatsPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
        builder.RegisterComponentInHierarchy<MainInventoryPresenter>();
        builder.RegisterComponentInHierarchy<EquipmentInventoryPresenter>();
    }

    private static void ConfigureTestClasses(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<MainInventoryDebug>();
    }
}
