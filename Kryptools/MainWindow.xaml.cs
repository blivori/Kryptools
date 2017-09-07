using System.Windows;
using Kryptools.Data;
using Kryptools.Controls;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Collections.Generic;
using System;
using System.Globalization;
using System.Windows.Documents;

namespace Kryptools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public decimal currentValue = 0;
        public List<Alert> alert;


        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            alert = new List<Alert>();

            var Market = new Kryptools.Data.CoinData();

            DataTable dtMarket = new DataTable();
            dtMarket = Market.GetMarket();
            dgMarket.DataContext = dtMarket.DefaultView;

            DataTable CoinList = new DataTable();
            CoinList = Market.GetCoinPrices();

            cbCoin.Items.Add("--COIN--");

            cbCoin.SelectedIndex = 0;


            foreach (DataRow i in CoinList.Rows)
            {
                String DisplayText = "[" + i["Symbol"].ToString().ToUpper() + "] - " + i["Name"] + " - (" + i["Price(B)"] + "B)";

                CalculatorComboBoxItem item = new CalculatorComboBoxItem(DisplayText,
                                                                         i["id"].ToString(),
                                                                         i["Symbol"].ToString(),
                                                                         Convert.ToDecimal(i["Price(B)"].ToString()),
                                                                         i["Name"].ToString());
                cbCoin.Items.Add(item);
            }

            foreach (DataRow j in dtMarket.Rows)
            {
                String DisplayText = j["Symbol"].ToString() + "- [" + j["Name"].ToString() + "] - (" + j["Price(BTC)"].ToString() + " btc)";

                CalculatorComboBoxItem item = new CalculatorComboBoxItem(DisplayText,
                                                                         j["id"].ToString(),
                                                                         j["Symbol"].ToString(),
                                                                         Convert.ToDecimal(j["Price(BTC)"].ToString()),
                                                                         j["Name"].ToString());

                cbAlert.Items.Add(item);
            }

            ColumnDefinition TitleCol = new ColumnDefinition();
            ColumnDefinition SubRedditCol = new ColumnDefinition();
            ColumnDefinition DateCol = new ColumnDefinition();
            ColumnDefinition URLCol = new ColumnDefinition();

            grdNews.ColumnDefinitions.Add(TitleCol);
            grdNews.ColumnDefinitions.Add(SubRedditCol);
            grdNews.ColumnDefinitions.Add(DateCol);
            grdNews.ColumnDefinitions.Add(URLCol);

            Kryptools.Data.NewsData nd = new NewsData();

            DataTable dt = new DataTable();

            dt = nd.GetNews();

            int index = 0;

            foreach (DataRow dr in dt.Rows)
            {

                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(0, GridUnitType.Auto);
                grdNews.RowDefinitions.Insert(grdNews.RowDefinitions.Count, rd);

                TextBlock tbURL = new TextBlock();

                //Label lblTitle = new Label();
                //lblTitle.Content = dr["Title"];
                Label lblSubReddit = new Label();
                lblSubReddit.Content = dr["SubReddit"];
                Label lblDate = new Label();
                lblSubReddit.Content = dr["Date"].ToString();

                Run url = new Run(dr["URL"].ToString());
                tbURL.Inlines.Add(new Hyperlink(url));
                tbURL.Text = dr["Title"].ToString();

                //Label lblURL= new Label();
                //lblSubReddit.Content = dr["URL"];



                Grid.SetColumn(lblDate, 0);
                Grid.SetRow(lblDate, index);

                Grid.SetColumn(tbURL, 1);
                Grid.SetRow(tbURL, index);

                Grid.SetColumn(lblSubReddit, 2);
                Grid.SetRow(lblSubReddit, index);

                
                //Grid.SetColumn(tbURL, 3);
                //Grid.SetRow(tbURL, index);

                //grdNews.Children.Add(lblTitle);
                grdNews.Children.Add(lblSubReddit);
                grdNews.Children.Add(lblDate);
                grdNews.Children.Add(tbURL);

                index++;
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            var Value = new Kryptools.Data.CoinData();
            DataTable dt;

            decimal item = Convert.ToDecimal(txtCalculator.Text);
            decimal coinValue = ((CalculatorComboBoxItem)cbCoin.SelectedItem).ValueBTC;
            string coinSymbol = ((CalculatorComboBoxItem)cbCoin.SelectedItem).Symbol;
            string coinRate = "(1" + coinSymbol + "=" + coinValue + "B)";

            decimal sum = currentValue + (item * coinValue);
            string listItem = item.ToString() + "x" + coinSymbol + " - [" + coinValue + "B] - Total: " + currentValue;
            currentValue = sum;
            lvCalculator.Items.Add(listItem);

        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnAlertAdd_Click(object sender, RoutedEventArgs e)
        {
            //
            DateTime dt = DateTime.Now.Date;
            string imgPath = "";
            string aBColor = "";
            


            switch (cbAlertOperation.SelectedIndex)
            {
                case 0:
                    imgPath = @"Images\plus.png";
                    aBColor = "LightGreen";
                    break;
                case 1:
                    imgPath = @"Images\minus.png";
                    aBColor = "Red";
                    break;
                default:
                    break;
            }
                    

            alert.Add(new Alert()
            {

                BaseValue = ((CalculatorComboBoxItem)cbAlert.SelectedItem).ValueBTC,
                DateSet = DateTime.Now.Date,
                Difference = Convert.ToDecimal(txtAlertValue.Text),
                DateUpdated = DateTime.Now.Date,
                NewValue = ((CalculatorComboBoxItem)cbAlert.SelectedItem).ValueBTC + Convert.ToDecimal(txtAlertValue.Text),
                Image = imgPath,
                AlertBColor = aBColor
            });

            lvAlerts.Items.Clear();

            foreach (Alert a in alert)
                lvAlerts.Items.Add(a);

            //lvAlerts.ItemsSource = alert;


        }
    }

    }

