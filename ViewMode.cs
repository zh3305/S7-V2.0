using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S7小助手V2
{
    public class ViewMode : INotifyPropertyChanged
    {




        private ObservableCollection<User> _lst_user;

        public ObservableCollection<User> Lst_user
        {
            get { return _lst_user; }
            set { _lst_user = value; NotifyPropertyChanged("Lst_user"); }
        }

        private ObservableCollection<User> _lst_bind;

        public ObservableCollection<User> Lst_bind
        {
            get { return _lst_bind; }
            set { _lst_bind = value; NotifyPropertyChanged("Lst_bind"); }
          
        }

        
        #region INotifyPropertyChanged 成员

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }

        }
        #endregion
        public ViewMode()
        {
            this.Lst_bind = new ObservableCollection<User>();//初始化数据            
        }     
        public void VimeAdd(string tag,string name,string type)
        {
            Lst_bind.Add(new User { Tag = tag, Name = name, Type = type,  Value = null });           
        }
        public void VimeSub(int i)
        {
           Lst_bind.RemoveAt(i);
        }
    }

    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _tag;
        private string _name;
        private string _type;
        private string _value;
        public string Tag
        {
            get { return _tag; }
            set
            {
                _tag = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Tag"));
                }
            }


        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Type"));
                }
            }
        }
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }

        }


    }

   
}
