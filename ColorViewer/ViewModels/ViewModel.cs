using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ColorViewer.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        bool alphaChecked = true;
        bool redChecked = true;
        bool greenChecked = true;
        bool blueChecked = true;

        MyColor selectedColor;
        public MyColor SelectedColor
        {
            get { return selectedColor; }
            set { if (value == null) { return; } selectedColor = value; OnPropertyChanged(); }
        }

        public bool AlphaChecked { get => alphaChecked; set { alphaChecked = value; OnPropertyChanged(); } }
        public bool RedChecked { get => redChecked; set { redChecked = value; OnPropertyChanged(); } }
        public bool GreenChecked { get => greenChecked; set { greenChecked = value; OnPropertyChanged(); } }
        public bool BlueChecked { get => blueChecked; set { blueChecked = value; OnPropertyChanged(); } }
      
        private ObservableCollection<MyColor> colorsCollection { get; set; }
        private Command addColorCommand;
        private Command removeColorCommand;
        private Command removeAllCommand;
        public ViewModel()
        {
            colorsCollection = new ObservableCollection<MyColor>();
            //{
            //    new MyColor()
            //};
            PropertyChanged += (s, a) =>
            {
                if (a.PropertyName == nameof(MyColor_))
                {
                    addColorCommand.RaiseCanExecuteChanged();
                    removeColorCommand.RaiseCanExecuteChanged();
                }
            };
            addColorCommand = new DelegateCommand(AddColor, () => !colorsCollection.Any((el)=> el.HexColor == MyColor_.HexColor && el.Alpha == MyColor_.Alpha));
            removeColorCommand = new DelegateCommand(RemoveColor, () => true);
            removeAllCommand = new DelegateCommand(RemoveAllColors, () => colorsCollection.Count != 0);
            myColor = new MyColor();
        }

        private void RemoveAllColors()
        {
            colorsCollection.Clear();
        }

        private void AddColor()
        {
            if (MyColor_ != null)
            {
                colorsCollection.Add((MyColor)MyColor_.Clone());
                removeAllCommand.RaiseCanExecuteChanged();
            }
        }
        private void RemoveColor()
        {
            if (SelectedColor != null)
            {
                colorsCollection.Remove(SelectedColor);
                removeAllCommand.RaiseCanExecuteChanged();
            }
        }
        private MyColor myColor;//= new MyColor();
        public ICommand AddColorCommand => addColorCommand;
        public ICommand RemoveColorCommand => removeColorCommand;
        public ICommand RemoveAllCommand => removeAllCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<MyColor> ColorNumarable => colorsCollection;
        public MyColor MyColor_
        {
            get { return myColor; }
            set { if (value == null) { return; } myColor = value; OnPropertyChanged(); }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
