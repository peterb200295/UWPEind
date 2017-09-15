using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpEindopdracht.Models;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;

namespace UwpEindopdracht.Helpers
{
    public class ObservableIncrementalLoadingCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading
    {
        public delegate Task<IncrementalLoadingResponse<T>> LoadMoreItemsAsyncDelegate(int firstId);
        public event LoadMoreItemsAsyncDelegate LoadMoreItemsAsyncEvent;

        private bool _reachedEnd;
        private int _nextId;

        protected override void ClearItems()
        {
            _nextId = 0;

            base.ClearItems();
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            _reachedEnd = false;

            base.OnCollectionChanged(e);
        }

        public bool HasMoreItems => !_reachedEnd;

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            var dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;

            return Task.Run(async () =>
            {
                var handler = LoadMoreItemsAsyncEvent;
                if (handler == null) return new LoadMoreItemsResult { Count = 0 };

                var response = await handler(_nextId);
                await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    foreach (var item in response.Items)
                    {
                        Add(item);
                    }
                });

                if (response.NextId <= 0) _reachedEnd = true;
                _nextId = response.NextId;

                return new LoadMoreItemsResult { Count = (uint)response.Items.Count() };
            }).AsAsyncOperation();
        }
    }
}
