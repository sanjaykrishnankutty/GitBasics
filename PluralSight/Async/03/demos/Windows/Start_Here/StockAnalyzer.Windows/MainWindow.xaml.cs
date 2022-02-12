﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Newtonsoft.Json;
using StockAnalyzer.Core.Domain;
using StockAnalyzer.Windows.Services;

namespace StockAnalyzer.Windows
{
    public partial class MainWindow : Window
    {
        CancellationTokenSource cancellationTokenSource = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            if (cancellationTokenSource == null)
            {
                cancellationTokenSource = new CancellationTokenSource();
            }
            else
            {
                cancellationTokenSource.Cancel();
                return;
            }

            #region Before loading stock data
            var watch = new Stopwatch();
            watch.Start();
            StockProgress.Visibility = Visibility.Visible;
            StockProgress.IsIndeterminate = true;

            Search.Content = "Cancel";
            #endregion


           var readTask = Task.Run(() =>
            {
                return File.ReadAllLines(@"StockPrices_Small.csv");
            });

            var dataTask = readTask.ContinueWith(task =>
            {
                var lines = task.Result;

                var data = new List<StockPrice>();

                foreach (var line in lines.Skip(1))
                {
                    var segments = line.Split(',');

                    for (var i = 0; i < segments.Length; i++) segments[i] = segments[i].Trim('\'', '"');
                    var price = new StockPrice
                    {
                        Ticker = segments[0],
                        TradeDate = DateTime.ParseExact(segments[1], "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        Volume = Convert.ToInt32(segments[6], CultureInfo.InvariantCulture),
                        Change = Convert.ToDecimal(segments[7], CultureInfo.InvariantCulture),
                        ChangePercent = Convert.ToDecimal(segments[8], CultureInfo.InvariantCulture),
                    };
                    data.Add(price);
                }

                return data;

            },TaskContinuationOptions.OnlyOnRanToCompletion);

            var UITask = dataTask.ContinueWith(task =>
            {
                var data = task.Result;
                Dispatcher.Invoke(()=>
                {
                    Stocks.ItemsSource = data.Where(price => price.Ticker == Ticker.Text);
                });
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            var postUITask = UITask.ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Dispatcher.Invoke(() =>
                    {
                        #region After stock data is loaded
                        StocksStatus.Text = task.Exception.Message;
                        StockProgress.Visibility = Visibility.Hidden;
                        Search.Content = "Search";
                        #endregion
                    });
                }
                else
                {
                    Dispatcher.Invoke(() =>
                    {
                        #region After stock data is loaded
                        StocksStatus.Text = $"Loaded stocks for {Ticker.Text} in {watch.ElapsedMilliseconds}ms";
                        StockProgress.Visibility = Visibility.Hidden;
                        Search.Content = "Search";
                        #endregion
                    });
                }
            });
          

            cancellationTokenSource = null;
        }

        private Task<List<string>> SearchForStocks(CancellationToken cancellationToken)
        {
            var loadLinesTask = Task.Run(async () =>
            {
                var lines = new List<string>();

                using (var stream = new StreamReader(File.OpenRead(@"StockPrices_small.csv")))
                {
                    string line;
                    while ((line = await stream.ReadLineAsync()) != null)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            return lines;
                        }
                        lines.Add(line);
                    }
                }

                return lines;
            }, cancellationToken);

            return loadLinesTask;
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));

            e.Handled = true;
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
