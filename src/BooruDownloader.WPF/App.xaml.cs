using System.Windows;
using BooruDotNet.Boorus;
using BooruDotNet.Links;
using BooruDownloader.Singletons;
using BooruDownloader.ViewModels;
using BooruDownloader.WPF.Views;
using ReactiveUI;
using Splat;

namespace BooruDownloader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            LinkResolver.RegisterResolver(new DanbooruResolver(Boorus.Danbooru));
            LinkResolver.RegisterResolver(new GelbooruResolver(Boorus.Gelbooru));
            LinkResolver.RegisterResolver(new KonachanResolver(Boorus.Konachan));
            LinkResolver.RegisterResolver(new SankakuComplexResolver(Boorus.SankakuComplex));
            LinkResolver.RegisterResolver(new YandereResolver(Boorus.Yandere));

            // Register classes manually because generic reactive window is defined in this assembly.
            Locator.CurrentMutable
                .RegisterAnd<IViewFor<MainViewModel>, MainView>()
                .RegisterAnd<IViewFor<LinkInputViewModel>, LinkInputView>()
                .RegisterAnd<IViewFor<QueueItemViewModel>>(() => new QueueItemView(TagCaches.DanbooruTagCache))
                .RegisterAnd<IViewFor<SettingsViewModel>, SettingsView>()
                .RegisterAnd<IViewFor<PostViewModel>, PostView>()
                .RegisterAnd<IViewFor<MediaViewModel>, MediaView>()
                .RegisterAnd<IViewFor<TagViewModel>, TagView>();
        }
    }
}
