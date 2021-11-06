using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;

namespace ColorViewer.ViewModels
{
    public class MyColor : INotifyPropertyChanged, ICloneable
    {
        
        Color myColor;
        public byte Alpha
        {
            get { return myColor.A; }
            set
            {
                myColor.A = value;
                OnPropertyChanged();
                OnPropertyChanged("MyColor_");
                OnPropertyChanged("HexColor");
            }
        }
        public byte Red
        {
            get { return myColor.R; }
            set
            {
                myColor.R = value;
                OnPropertyChanged();
                OnPropertyChanged("MyColor_");
                OnPropertyChanged("HexColor");
            }
        }
        public string HexColor
        {
            get
            {
                return "#" + myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
            }
        }
        public byte Blue
        {
            get { return myColor.B; }
            set
            {
                myColor.B = value;
                OnPropertyChanged();
                OnPropertyChanged("MyColor_");
                OnPropertyChanged("HexColor");
            }
        }
        public byte Green
        {
            get { return myColor.G; }
            set
            {
                myColor.G = value;
                OnPropertyChanged();
                OnPropertyChanged("MyColor_");
                OnPropertyChanged("HexColor");
            }
        }
        public MyColor()
        {
            MyColor_ = Color.FromArgb(255, 0, 255, 255);
        }

        public Color MyColor_
        {
            get => myColor;
            set
            {
                myColor = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public object Clone()
        {
            MyColor clone = (MyColor)this.MemberwiseClone();
            return clone;
        }
    }
}