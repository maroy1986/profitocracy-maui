using Android.App;
using Android.Content.PM;
using Android.OS;

#if ANDROID
using AndroidX.Work;
using Profitocracy.Mobile.Platforms.Android.Work;
#endif

namespace Profitocracy.Mobile;

[Activity(
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                           ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

#if ANDROID
        // Initialize any platform-specific services or configurations here
        var repeatInterval =
#if DEBUG
            TimeSpan.FromMilliseconds(PeriodicWorkRequest.MinPeriodicIntervalMillis);
#else
            TimeSpan.FromHours(6);
#endif

        var recurringTransactionWorkRequest = PeriodicWorkRequest.Builder
            .From<RecurringTransactionWorker>(repeatInterval).AddTag(RecurringTransactionWorker.WorkerName)
            .SetConstraints(new AndroidX.Work.Constraints.Builder().SetRequiresBatteryNotLow(true)
                .SetRequiresStorageNotLow(true)
                .Build())
            .Build();
        WorkManager.GetInstance(this).Enqueue(recurringTransactionWorkRequest);
#endif
    }
}
