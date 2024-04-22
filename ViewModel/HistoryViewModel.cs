using mvvm.Model;
using mvvm.ViewModel.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vipief.ViewModel.Helpers;

namespace mvvm.ViewModel
{
    internal class HistoryViewModel : BindingHelper
    {
        public BindableCommand UpdateList { get; set; }

        private List<Number> updateHistory;

        public List<Number> UpdateHistory
        {
            get { return updateHistory; }
            set
            {
                updateHistory = value;
                OnPropertyChanged();
            }
        }

        public void ShowHistory()
        {
            string json = File.ReadAllText("Number.json");
            UpdateHistory = JsonConvert.DeserializeObject<List<Number>>(json);
        }
        public HistoryViewModel()
        {
            UpdateList = new BindableCommand(_ => ShowHistory());
        }
    }
}
