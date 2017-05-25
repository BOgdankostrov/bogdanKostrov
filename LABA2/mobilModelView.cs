using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA2
{
   public    class mobilModelView : INotifyPropertyChanged
    {
        public int id { get; set; }
        public String name { get; set; }
        public int price { get; set; }
        public int number { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(String propertyName)
        {
            var ev = PropertyChanged;
            if (ev != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int cost;
        private RelayCommand addCommand;
        public RelayCommand deleteCommand;
        public mobilModelView selectedPhone;
        public mobilModelView SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                RaisePropertyChanged("SelectedPhone");
               
            }
        }
        public mobilModelView()
        {
            cost = price * number;
        }
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      mobilModelView phone = obj as mobilModelView;
                      if (phone != null)
                      {

                          MainWindowViewModel.MObils.Remove(phone);
                       
                          for(int i=0;i< MainWindowViewModel.MObils.Count;i++)
                          {
                              MainWindowViewModel.MObils[i].Id = i+1;
                          }
                         // MainWindowViewModel.Cost = MainWindowViewModel.Cost + price * number;
                      }
                  },
                 (obj) => MainWindowViewModel.MObils.Count > 0));

               
            }
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                            (addCommand = new RelayCommand(obj =>
                            {
                                Number++;
                              //  MainWindowViewModel.Cost = MainWindowViewModel.Cost + price;
                            }));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                            (deleteCommand = new RelayCommand(obj =>
                            {
                                Number--;
//MainWindowViewModel.Cost= MainWindowViewModel.Cost-price;
                            }));
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
                Cost = number * price;
                RaisePropertyChanged("Number");
            }
        }

        
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                RaisePropertyChanged("Price");
            }
        }
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }

        public int Cost
        {
            get { return cost; }
            set
            {
                
                cost = value;
                RaisePropertyChanged("Cost");
            }
        }

    }
}

