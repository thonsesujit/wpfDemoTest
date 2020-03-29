using Caliburn.Micro;
using EspLabsTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EspLabsTestProject.ViewModels
{
    public class EspLabTestViewModel : Screen
    {
        private string _key;
        private string _value;
        private string _inputTextBox;
        private KeyValuePairModel _selectedKeyValuePair;
        private BindableCollection<KeyValuePairModel> _myDisplayListBox = new BindableCollection<KeyValuePairModel>();



        //public List<KeyValuePairModel> keyPairList = new List<KeyValuePairModel>();

        public EspLabTestViewModel()
        {
            MyDisplayListBox.Add(new KeyValuePairModel { Key = "Hello", Value = "World" });
            MyDisplayListBox.Add(new KeyValuePairModel { Key = "FirstName", Value = "Bob" });
            MyDisplayListBox.Add(new KeyValuePairModel { Key = "Hello", Value = "World" });
            MyDisplayListBox.Add(new KeyValuePairModel { Key = "Name", Value = "Sujit" });
        }


        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }


        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }


        public string InputTextBox
        {
            get { return _inputTextBox; }
            set {
                _inputTextBox = value;
                
            }
        }



        public KeyValuePairModel SelectedKeyValuePair
        {
            get { return _selectedKeyValuePair; }
            set {
                _selectedKeyValuePair = value;
                NotifyOfPropertyChange(() => SelectedKeyValuePair);
            }
        }


        public void AddToListButton(string inputTextBox)
        {
            NotifyOfPropertyChange(() => InputTextBox);
            //MyDisplayListBox.Add(new KeyValuePairModel { Key = "Name", Value = "Sujit" });
        }



        public BindableCollection<KeyValuePairModel> MyDisplayListBox
        {
            get { return _myDisplayListBox; }
            set {
                _myDisplayListBox = value;
               
            }
        }



    }
}
