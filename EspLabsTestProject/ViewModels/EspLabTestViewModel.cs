using Caliburn.Micro;
using EspLabsTestProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace EspLabsTestProject.ViewModels
{
    public class EspLabTestViewModel : Screen
    {
        private string _key;
        private string _value;
        private string _inputTextBox;
        private KeyValuePairModel _selectedKeyValuePair;
        private BindableCollection<KeyValuePairModel> _myDisplayListBox = new BindableCollection<KeyValuePairModel>();



       
        //Just to simulate database
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
            set
            {
                _inputTextBox = value;

            }
        }
               
        public KeyValuePairModel SelectedKeyValuePair
        {
            get { return _selectedKeyValuePair; }
            set
            {
                if(_selectedKeyValuePair != value)
                {
                    _selectedKeyValuePair = value;
                    NotifyOfPropertyChange(() => SelectedKeyValuePair);
                }
                
            }
        }


        public void AddToListButton(string inputTextBox)
        {
            ValidateInput(inputTextBox);
            MyDisplayListBox.Add(new KeyValuePairModel { Key = Key, Value = Value });
            NotifyOfPropertyChange(() => InputTextBox);
            
        }

        public void FilterButton(string inputTextBox)
        {
            //MyDisplayListBox./*Select(InputTextBox);*/
        }

        public void DeleteButton()
        {
            MyDisplayListBox.RemoveAt(0);

        }

        public void SortByName()
        {
            MyDisplayListBox.RemoveAt(0);

        }

        public BindableCollection<KeyValuePairModel> MyDisplayListBox
        {
            get { return _myDisplayListBox; }
            set
            {
                _myDisplayListBox = value;
                NotifyOfPropertyChange(() => MyDisplayListBox);
            }
        }

        //Validates input and removes whitespaces
        public void ValidateInput(string input)
        {
            string inputWithoutWS = Regex.Replace(input, @"\s+", String.Empty);
            String[] inputArray = inputWithoutWS.Split('=');
            if (inputArray.Count() == 2 && inputArray[0].All(char.IsLetterOrDigit) && inputArray[1].All(char.IsLetterOrDigit))
            {
                Key = inputArray[0];
                Value = inputArray[1];
                MessageBox.Show("Alpha numeric");
            }
            else if (inputArray.Count() != 2)
            {
                MessageBox.Show("Please enter only alphanumberic key-value pairs");
            }
           
        }

        //private bool CustomFilter(object obj)
        //{
        //    if (string.IsNullOrEmpty(InputTextBox.Text))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return (obj.ToString().IndexOf(txtData.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        //    }
        //}



    }
}
