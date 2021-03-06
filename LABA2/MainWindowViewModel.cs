﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LABA2
{
    enum Priority
    {
        Low,
        Middle,
        High
    }

    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public static int cost;
        public  int Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                RaisePropertyChanged("Cost");
            }
        }
     
        private RelayCommand addCommand;
        public RelayCommand AAddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      mobilModelView phone = obj as mobilModelView;
                      MObils[phone.id - 1].Number++;
                      Cost += phone.price;
                  },
                 (obj) => MObils.Count > 0));
            }
        }
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      mobilModelView phone = obj as mobilModelView;
                      if (phone.number > 0)
                      {

                          MObils[phone.id - 1].Number--;
                          Cost -= phone.price;
                      }

                  },
                 (obj) => MObils.Count > 0));
            }
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

                          MObils.Remove(phone);

                          for (int i = 0; i < MObils.Count; i++)
                          {
                              MObils[i].Id = i + 1;
                          }
                          Cost -= phone.cost;
                      }
                  },
                 (obj) => MObils.Count > 0));
            }
        }

        public mobilModelView selectedPhone;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(String propertyName)
        {
            var ev = PropertyChanged;
            if (ev != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public  ObservableCollection<mobilModelView> MObils { get; set; }
        public MainWindowViewModel()
        {
            MObils = new ObservableCollection<mobilModelView>();
            var mobil1 = mobil.GetStudenysFromDatabases();
            foreach (var s in mobil1)
            {
                MObils.Add(new mobilModelView()
                {
                    id = s.ID,
                    name = s.Name,
                    price = s.Price,
                    number = s.Number,
                    cost = s.Price* s.Number
                });                
            }         
                 for (int i = 0; i < MObils.Count; i++)
            {
                cost += MObils[i].Cost;
            }
        }

        public mobilModelView SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                RaisePropertyChanged("SelectedPhone");
            }
        }


   

        Priority priority = Priority.Low;
        internal Priority Priority
        {
            get { return priority; }
            set
            {
                if (priority == value)
                    return;

                priority = value;
                RaisePropertyChanged("Priority");
                RaisePropertyChanged("IsLowPriority");
                RaisePropertyChanged("IsMiddlePriority");
                RaisePropertyChanged("IsHighPriority");
            }
        }

        public bool IsLowPriority
        {
            get { return Priority == Priority.Low; }
            set { Priority = value ? Priority.Low : Priority; }
        }

        public bool IsMiddlePriority
        {
            get { return Priority == Priority.Middle; }
            set { Priority = value ? Priority.Middle : Priority; }
        }

        public bool IsHighPriority
        {
            get { return Priority == Priority.High; }
            set { Priority = value ? Priority.High : Priority; }
        }

        Priority priority1 = Priority.Low;
        internal Priority Priority1
        {
            get { return priority1; }
            set
            {
                if (priority1 == value)
                    return;

                priority1 = value;
                RaisePropertyChanged("Priority1");
                RaisePropertyChanged("IsLowPriority1");
                RaisePropertyChanged("IsMiddlePriority1");
                RaisePropertyChanged("IsHighPriority1");
            }
        }

        public bool IsLowPriority1
        {
            get { return Priority1 == Priority.Low; }
            set { Priority1 = value ? Priority.Low : Priority1; }
        }

        public bool IsMiddlePriority1
        {
            get { return Priority1 == Priority.Middle; }
            set { Priority1 = value ? Priority.Middle : Priority1; }
        }

        public bool IsHighPriority1
        {
            get { return Priority1 == Priority.High; }
            set { Priority1 = value ? Priority.High : Priority1; }
        }



    }
}
