using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class IAPManager : IStoreListener, IDetailedStoreListener
{

    private IStoreController controller;
    private IExtensionProvider extensions;
    private ConfigurationBuilder builder;

    public IAPManager()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct("100_gold_coins", ProductType.Consumable, new IDs
        {
            {"100_gold_coins_google", GooglePlay.Name},
            {"100_gold_coins_mac", MacAppStore.Name}
        });

        UnityPurchasing.Initialize(this, builder);
    }

    /// <summary>
    /// Called when Unity IAP is ready to make purchases.
    /// </summary>
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
        this.extensions = extensions;
    }

    /// <summary>
    /// Called when Unity IAP encounters an unrecoverable initialization error.
    ///
    /// Note that this will not be called if Internet is unavailable; Unity IAP
    /// will attempt initialization until it becomes available.
    /// </summary>
    public void OnInitializeFailed(InitializationFailureReason error)
    {
    }

    /// <summary>
    /// Called when a purchase completes.
    ///
    /// May be called at any time after OnInitialized().
    /// </summary>
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        return PurchaseProcessingResult.Complete;
    }

    /// <summary>
    /// Called when a purchase fails.
    /// </summary>
    public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
    {
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        throw new System.NotImplementedException();
    }
}