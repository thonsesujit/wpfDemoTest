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

    /// <summary>
    /// Caliburn Micro is used to maintain MVVM. 
    /// </summary>
    public class EspLabTestViewModel : Screen
    {
        private string _key;
        private string _value;
        private string _keyValuePair;
        private string _inputTextBox;
        private KeyValuePairModel _selectedKeyValuePair;
        private BindingList<KeyValuePairModel> fullList;
        private BindingList<KeyValuePairModel> _myDisplayListBox;

        
        //Just to simulate database in a constructor.
        public EspLabTestViewModel()
        {

            MyDisplayListBox.Add(new KeyValuePairModel { Key = "Hello", Value = "World" });
            MyDisplayListBox.Add(new KeyValuePairModel { Key = "FirstName", Value = "Sujit" });
            MyDisplayListBox.Add(new KeyValuePairModel { Key = "Language", Value = "CSharp" });
            MyDisplayListBox.Add(new KeyValuePairModel { Key = "MVVM", Value = "Caliburn" });

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


        public string KeyValuePair
        {
            get { return _keyValuePair; }
            set { _keyValuePair = value; }
        }

        public BindingList<KeyValuePairModel> MyDisplayListBox
        {
            get
            {
                if (_myDisplayListBox == null)
                    _myDisplayListBox = new BindingList<KeyValuePairModel>();
                return _myDisplayListBox;
            }
            set { _myDisplayListBox = value; }
        }

        public string InputTextBox
        {
            get { return _inputTextBox; }
            set
            {
                _inputTextBox = value;
                NotifyOfPropertyChange(() => InputTextBox);
                NotifyOfPropertyChange(() => CanFilter);


            }
        }
        
        //for populating selected person
        public KeyValuePairModel SelectedKeyValuePair
        {
            get { return _selectedKeyValuePair; }
            set
            {
                if(_selectedKeyValuePair != value)
                {
                    _selectedKeyValuePair = value;
                    NotifyOfPropertyChange(() => SelectedKeyValuePair);
                    NotifyOfPropertyChange(() => CanDeleteSelectedText);

                }

            }
        }


        public void AddToList(string inputTextBox)
        {
            ValidateInput(inputTextBox);
            if(Key != null || Value != null)
            {
                KeyValuePairModel newKeyValuePair = new KeyValuePairModel
                {
                    Key = Key,
                    Value = Value
                };
                MyDisplayListBox.Add(newKeyValuePair);

                NotifyOfPropertyChange(() => MyDisplayListBox);
            }
                             
        }

        //Validates input and removes whitespaces
        public void ValidateInput(string input)
        {
            Key = null;
            Value = null;
            string[] inputArray = input.Split('=').Select(a => a.Trim()).ToArray();
            if (inputArray.Count() == 2 && inputArray[0].All(char.IsLetterOrDigit) &&
                inputArray[1].All(char.IsLetterOrDigit) && inputArray[0] != "" && inputArray[1] != "")
            {

                Key = inputArray[0];
                Value = inputArray[1];

            }
            else
            {
                MessageBox.Show("Only aplha-numeric characters of <name> = <value> format is accepted");
            }


        }

        //Filter Validation
        public bool CanFilter
        {
            get
            {
                bool output = false;

                if (InputTextBox != null && MyDisplayListBox.Count !=0)
                {
                    output = true;
                }

                return output;
            }
        }

        public void Filter(string inputTextBox)
        {
            List<KeyValuePairModel> filteredList = MyDisplayListBox.Where(x => x.KeyValuePair == inputTextBox).ToList();
            fullList = MyDisplayListBox;
            MyDisplayListBox = new BindingList<KeyValuePairModel>(filteredList);
            NotifyOfPropertyChange(() => MyDisplayListBox);
            NotifyOfPropertyChange(() => CanFilter);
        }

        //Clear filter validation
        public bool CanClearFilter
        {
            get
            {
                bool output = false;

                //Make sure something is selected
                if (InputTextBox != null && MyDisplayListBox.Count != 0)
                {
                    output = true;
                }

                return output;
            }
        }
        
        public void ClearFilter(string inputTextBox)
        {
            InputTextBox = String.Empty;
            MyDisplayListBox = fullList;
            NotifyOfPropertyChange(() => MyDisplayListBox);

        }


        public void SortByName()
        {

            List<KeyValuePairModel> sortByNameList = MyDisplayListBox.OrderBy(x => x.Key).ToList();
            MyDisplayListBox = new BindingList<KeyValuePairModel>(sortByNameList);
            NotifyOfPropertyChange(() => MyDisplayListBox);

        }

        public void SortByValue()
        {
            List<KeyValuePairModel> sortByValueList = MyDisplayListBox.OrderBy(x => x.Value).ToList();
            MyDisplayListBox = new BindingList<KeyValuePairModel>(sortByValueList);
            NotifyOfPropertyChange(() => MyDisplayListBox);
        }

               
        //Delete Selected keyvalue pair from the listbox
        public void DeleteSelectedText()
        {

            MyDisplayListBox.Remove(SelectedKeyValuePair);
            NotifyOfPropertyChange(() => MyDisplayListBox);

        }

        //Delete button validation
        public bool CanDeleteSelectedText
        {
            get
            {
                bool output = false;

                
                if (SelectedKeyValuePair != null)
                {
                    output = true;
                }
             
                    return output;
            }
         
        }


    }
}
