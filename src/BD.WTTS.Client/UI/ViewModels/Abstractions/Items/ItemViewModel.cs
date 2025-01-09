// ReSharper disable once CheckNamespace
using BD.WTTS.Helpers;

namespace BD.WTTS.UI.ViewModels.Abstractions;

public abstract partial class ItemViewModel : ViewModelBase
{
    [IgnoreDataMember, MPIgnore, MP2Ignore, N_JsonIgnore, S_JsonIgnore]
    public abstract string Name { get; }

    #region IsSelected 変更通知

    bool _IsSelected;

    public virtual bool IsSelected
    {
        get => _IsSelected;
        set => this.RaiseAndSetIfChanged(ref _IsSelected, value);
    }

    #endregion

    #region IsShowTab 変更通知

    bool _IsShowTab = true;

    public virtual bool IsShowTab
    {
        get => _IsShowTab;
        set => this.RaiseAndSetIfChanged(ref _IsShowTab, value);
    }

    #endregion

    #region Resource Key 图标

    //public virtual string? IconSource => IApplication.Instance.GetIconSourceByIconKey(IconKey);

    protected object? _IconKey;

    [IgnoreDataMember, MPIgnore, MP2Ignore, N_JsonIgnore, S_JsonIgnore]
    public virtual object? IconKey
    {
        get => _IconKey;
        set
        {
            this.RaiseAndSetIfChanged(ref _IconKey, value);
            //this.RaisePropertyChanged(nameof(IconSource));
        }
    }

    #endregion

    #region Badge 変更通知

    int _Badge;

    public virtual int Badge
    {
        get => _Badge;
        protected set => this.RaiseAndSetIfChanged(ref _Badge, value);
    }

    #endregion

    #region IsExpanded 変更通知

    bool _IsExpanded;

    public virtual bool IsExpanded
    {
        get => _IsExpanded;
        protected set => this.RaiseAndSetIfChanged(ref _IsExpanded, value);
    }

    #endregion

    #region SelectsOnInvoked 変更通知

    bool _SelectsOnInvoked = true;

    public virtual bool SelectsOnInvoked
    {
        get => _SelectsOnInvoked;
        protected set => this.RaiseAndSetIfChanged(ref _SelectsOnInvoked, value);
    }

    #endregion

    public override void Activation()
    {
        base.Activation();

        TracepointHelper.TrackEvent("PageActivation", new Dictionary<string, string> {
                { "PageName", Name },
        });
    }
}
