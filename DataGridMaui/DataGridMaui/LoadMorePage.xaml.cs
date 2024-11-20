namespace DataGridMaui;

public partial class LoadMorePage : ContentPage
{
	public LoadMorePage()
	{
		InitializeComponent();
        //dataGrid.AllowLoadMore = true;
        //dataGrid.LoadMoreCommand = new Command(ExecuteLoadMoreCommand);

        dataGrid.AllowPullToRefresh = true;
        dataGrid.PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
    }

    private async void ExecutePullToRefreshCommand()
    {
        this.dataGrid.IsBusy = true;
        await Task.Delay(new TimeSpan(0, 0, 5));
        viewModel.LoadMoreItems();
        this.dataGrid.IsBusy = false;
    }

    private async void ExecuteLoadMoreCommand()
    {
        this.dataGrid.IsBusy = true;
        await Task.Delay(new TimeSpan(0, 0, 2));
        viewModel.LoadMoreItems();
        this.dataGrid.IsBusy = false;
    }
}