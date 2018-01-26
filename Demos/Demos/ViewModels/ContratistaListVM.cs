using Demos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demos.ViewModels
{
    class ContratistaListVM : ViewModelBase
    {
        public ContratistaListVM()
        {
            Title = "Contratistas";
        }

        ObservableCollection<ContratistaModel> list = new ObservableCollection<ContratistaModel>();
        public ObservableCollection<ContratistaModel> List => list;


        Command loadCommand;
        public Command LoadCommand => loadCommand ?? (loadCommand = new Command(async () => await Load()));
        

        async Task Load()
        {

            IsBusy = true;
            try
            {
                await Task.Delay(2000);
                var datos = await ServerLink.GetDataAsync<List<Models.ContratistaModel>>("Contratista");
                list.Clear();
                foreach (var itm in datos)
                {
                    list.Add(itm);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                
            }
            finally
            {
                IsBusy = false;
            }

        }



    }


    public class ViewModelBase : System.ComponentModel.INotifyPropertyChanged
    {
        string _Title = "";
        public string Title
        {
            get { return _Title; }
            set { SetValue(ref _Title, value); }
        }

        bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                SetValue(ref _IsBusy, value);
                OnPropertyChanged(nameof(IsNotBusy));
            }
        }

        public bool IsNotBusy
        {
            get { return !_IsBusy; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName()]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));



            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void SetValue<T>(ref T field, T val, [CallerMemberName()]string propertyName = "")
        {
            if (Object.Equals(field, val))
                return;
            field = val;
            OnPropertyChanged(propertyName);
        }
    }
}
