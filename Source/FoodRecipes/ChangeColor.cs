using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipes
{
    public class ChangeColor : INotifyPropertyChanged
    {
        public string ColorTopBar { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
