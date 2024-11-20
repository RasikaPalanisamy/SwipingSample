using Syncfusion.Maui.Data;
using Syncfusion.Maui.DataGrid;
using System.Collections.ObjectModel;

namespace DataGridMaui
{
    public partial class MainPage : ContentPage
    {
        EmployeeViewModel employee;
        public MainPage()
        {
            InitializeComponent();
            dataGrid.SwipeStarted += DataGrid_SwipeStarted;
            dataGrid.Swiping += DataGrid_Swiping;
            dataGrid.SwipeEnded += DataGrid_SwipeEnded;
        }

        private void DataGrid_SwipeEnded(object? sender, DataGridSwipeEndedEventArgs e)
        {
            var rowData = e.RowData;
            var index = e.RowIndex;
            var direction = e.SwipeDirection;
        }

        private void DataGrid_Swiping(object? sender, DataGridSwipingEventArgs e)
        {
            var rowData = e.RowData;
            var index = e.RowIndex;
            var offSet = e.SwipeOffset;
            var direction = e.SwipeDirection;
        }

        private void DataGrid_SwipeStarted(object? sender, DataGridSwipeStartedEventArgs e)
        {
            e.Cancel = true;
            var rowData = e.RowData;
            var index = e.RowIndex;
            var direction = e.SwipeDirection;
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            // dataGrid.AllowSwiping = !dataGrid.AllowSwiping;
            //dataGrid.LeftSwipeTemplate = new LeftTemplateSelector();
            //dataGrid.RightSwipeTemplate = new RightTemplateSelector();
            // dataGrid.MaxSwipeOffset = 100;
            // dataGrid.SwipeOffsetMode = dataGrid.SwipeOffsetMode == SwipeOffsetMode.Auto ? SwipeOffsetMode.Custom : SwipeOffsetMode.Auto;

            //if(dataGrid.SwipeOffsetMode == SwipeOffsetMode.Custom)
            //{
            //    dataGrid.MaxSwipeOffset = 200;
            //}


            //this.dataGrid.View.Filter = FilterRecords;
            //this.dataGrid.View.RefreshFilter();

          //  dataGrid.FrozenRowCount = 2;
          //  dataGrid.FrozenColumnCount = 2;
        }

        public bool FilterRecords(object record)
        {
            OrderInfo? orderInfo = record as OrderInfo;

            if (orderInfo != null && orderInfo.ShipCountry == "Germany")
            {
                return true;
            }
            return false;
        }

        private void left_Clicked(object sender, EventArgs e)
        {
            //dataGrid.LeftSwipeTemplate = new DataTemplate(() =>
            //{
            //    var label = new Label()
            //    {
            //        Text = "LeftSwipe",
            //        BackgroundColor = Colors.SkyBlue
            //    };
            //    return label;
            //});

            this.dataGrid.View.Filter = null;
            this.dataGrid.View.RefreshFilter();

        }



        private void right_Clicked(object sender, EventArgs e)
        {
            dataGrid.RightSwipeTemplate = new DataTemplate(() =>
            {
                var label = new Label()
                {
                    Text = "RightSwipe",
                    BackgroundColor = Colors.Yellow
                };

                return label;
            });
        }

        private void sourceChanged_Clicked(object sender, EventArgs e)
        {
            employee = new EmployeeViewModel();
            dataGrid.ItemsSource = employee.EmployeeInformation;
        }

        private void columnSizer_Clicked(object sender, EventArgs e)
        {
            dataGrid.ColumnWidthMode = dataGrid.ColumnWidthMode == ColumnWidthMode.Auto ? ColumnWidthMode.Fill : ColumnWidthMode.Auto;
            //  dataGrid.ColumnWidthMode = dataGrid.ColumnWidthMode == ColumnWidthMode.LastColumnFill ? ColumnWidthMode.FitByCell : ColumnWidthMode.LastColumnFill;

            // dataGrid.DefaultColumnWidth = 150;
        }

        private void sorting_Clicked(object sender, EventArgs e)
        {
            dataGrid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = "OrderID", SortDirection = System.ComponentModel.ListSortDirection.Descending });
        }

        private void group_Clicked(object sender, EventArgs e)
        {
            dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = "OrderID" });
        }

        private void summary_Clicked(object sender, EventArgs e)
        {
            DataGridSummaryRow summaryRow = new DataGridSummaryRow();
            summaryRow.Title = "Total Salary:{TotalSalary} for {ProductCount} members";
            summaryRow.ShowSummaryInRow = true;
            summaryRow.SummaryColumns.Add(new DataGridSummaryColumn()
            {
                Name = "TotalSalary",
                MappingName = "OrderID",
                Format = "{Sum:c}",
                SummaryType = SummaryType.DoubleAggregate
            });
            summaryRow.SummaryColumns.Add(new DataGridSummaryColumn()
            {
                Name = "ProductCount",
                MappingName = "OrderID",
                Format = "{Count}",
                SummaryType = SummaryType.CountAggregate
            });
            dataGrid.CaptionSummaryRow = summaryRow;

            //this.dataGrid.GroupSummaryRows.Add(new DataGridSummaryRow()
            //{
            //    ShowSummaryInRow = true,
            //    Title = "Total Salary: {Salary} for {customerID} members",
            //    SummaryColumns = new ObservableCollection<ISummaryColumn>()
            //{
            //    new DataGridSummaryColumn()
            //    {
            //        Name="Salary",
            //        MappingName="OrderID",
            //        SummaryType=SummaryType.DoubleAggregate,
            //        Format="{Sum}"
            //    },
            //    new DataGridSummaryColumn()
            //    {
            //        Name="customerID",
            //        MappingName="OrderID",
            //        Format="{Count}",
            //        SummaryType=SummaryType.CountAggregate
            //    }
            //}
            //});

            //DataGridTableSummaryRow topSummaryRow = new DataGridTableSummaryRow();
            //topSummaryRow.Position = SummaryRowPosition.Top;
            //topSummaryRow.ShowSummaryInRow = false;
            //topSummaryRow.SummaryColumns.Add(new DataGridSummaryColumn()
            //{
            //    Name = "TotalSalary",
            //    MappingName = "OrderID",
            //    Format = "{Sum:C0}",
            //    SummaryType = SummaryType.DoubleAggregate
            //});
            //dataGrid.TableSummaryRows.Add(topSummaryRow);

            //DataGridTableSummaryRow bottomSummaryRow = new DataGridTableSummaryRow();
            //bottomSummaryRow.Position = SummaryRowPosition.Bottom;
            //bottomSummaryRow.Title = "Total Salary:{TotalSalary} for {ProductCount} members";
            //bottomSummaryRow.ShowSummaryInRow = true;
            //bottomSummaryRow.SummaryColumns.Add(new DataGridSummaryColumn()
            //{
            //    Name = "TotalSalary",
            //    MappingName = "OrderID",
            //    Format = "{Sum:C0}",
            //    SummaryType = SummaryType.DoubleAggregate
            //});
            //bottomSummaryRow.SummaryColumns.Add(new DataGridSummaryColumn()
            //{
            //    Name = "ProductCount",
            //    MappingName = "Salary",
            //    Format = "{Count}",
            //    SummaryType = SummaryType.CountAggregate
            //});
            // dataGrid.TableSummaryRows.Add(bottomSummaryRow);
        }

        private void selection_Clicked(object sender, EventArgs e)
        {
            // dataGrid.SelectAll();
            dataGrid.ClearSelection();
        }

        private void stack_Clicked(object sender, EventArgs e)
        {
            var stackedHeaderRow = new DataGridStackedHeaderRow();
            stackedHeaderRow.Columns.Add(new DataGridStackedColumn()
            {
                ColumnMappingNames = "OrderID" + "," + "CustomerID" + "," + "ShipCountry" + "," + "Customer" + "," + "ShipCity",
                Text = "Order Shipment Details",
                MappingName = "SalesDetails",
            });
            dataGrid.StackedHeaderRows.Add(stackedHeaderRow);

            var stackedHeaderRow1 = new DataGridStackedHeaderRow();
            stackedHeaderRow1.Columns.Add(new DataGridStackedColumn()
            {
                ColumnMappingNames = "OrderID" + "," + "CustomerID",
                Text = "Order Details",
                MappingName = "OrderDetails",
            });
            stackedHeaderRow1.Columns.Add(new DataGridStackedColumn()
            {
                ColumnMappingNames = "ShipCountry" + "," + "Customer" + "," + "ShipCity",
                Text = "Customer Details",
                MappingName = "CustomerDetails",
            });
            this.dataGrid.StackedHeaderRows.Add(stackedHeaderRow1);
        }

        private void unbound_Clicked(object sender, EventArgs e)
        {
            //  this.dataGrid.UnboundRows.Add(new DataGridUnboundRow() { Position = DataGridUnboundRowPosition.Top });

            DataGridUnboundColumn DiscountColumn = new DataGridUnboundColumn();

            this.dataGrid.Columns.Add(DiscountColumn);
        }

        private void dataGrid_SwipeStarted(object sender, DataGridSwipeStartedEventArgs e)
        {

        }

        private void dataGrid_Swiping(object sender, DataGridSwipingEventArgs e)
        {

        }

        private void dataGrid_SwipeEnded(object sender, DataGridSwipeEndedEventArgs e)
        {

        }

        private void rowHeight_Clicked(object sender, EventArgs e)
        {
            dataGrid.RowHeight = 100;
        }

        private void dataGrid_QueryRowHeight(object sender, DataGridQueryRowHeightEventArgs e)
        {
            if(e.RowIndex == 1)
            {
                e.Height = 100;
                e.Handled = true;
            }
        }
    }

    public class LeftTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var dataTemplate = new DataTemplate(() =>
            {
                Button button = new Button()
                {
                    TextColor = Colors.Green,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Text = "Left template Selector"
                };
                return button;
            });
            return dataTemplate;
        }
    }

    public class RightTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var dataTemplate = new DataTemplate(() =>
            {
                Button button = new Button()
                {
                    TextColor = Colors.Red,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Text = "Right Template Selector"
                };
                return button;
            });
            return dataTemplate;
        }
    }


}
