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
        private string _keyValuePair;
        private string _inputTextBox;
        private KeyValuePairModel _selectedKeyValuePair;
        private BindingList<KeyValuePairModel> fullList;
        //private BindableCollection<KeyValuePairModel> _myDisplayListBox = new BindableCollection<KeyValuePairModel>();

        /// <summary>
        /// Its a hack there might be better way
        /// </summary>
        //private List<KeyValuePairModel> _myDisplayListBox = new List<KeyValuePairModel>();

        //public List<KeyValuePairModel> MyDisplayListBox
        //{
        //    get { return _myDisplayListBox; }
        //    set { _myDisplayListBox = value; }
        //}


        private BindingList<KeyValuePairModel> _myDisplayListBox;

        public BindingList<KeyValuePairModel> MyDisplayListBox
        {
            get {
                if (_myDisplayListBox == null)
                    _myDisplayListBox = new BindingList<KeyValuePairModel>();
                return _myDisplayListBox;
            }
            set { _myDisplayListBox = value; }
        }




        //Just to simulate database in a constructor.
        public EspLabTestViewModel()
        {

            MyDisplayListBox.Add(new KeyValuePairModel { Key = "Hello", Value = "World" });
            MyDisplayListBox.Add(new KeyValuePairModel { Key = "FirstName", Value = "Bob" });
            MyDisplayListBox.Add(new KeyValuePairModel { Key = "Hello", Value = "World" });
            MyDisplayListBox.Add(new KeyValuePairModel { Key = "Name", Value = "Sujit" });
            MyDisplayListBox.Add(new KeyValuePairModel { Key = "Name", Value = "Sujit" });
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


        public string KeyValuePair
        {
            get { return _keyValuePair; }
            set { _keyValuePair = value; }
        }


        public string InputTextBox
        {
            get { return _inputTextBox; }
            set
            {
                _inputTextBox = value;
                NotifyOfPropertyChange(() => InputTextBox);
                NotifyOfPropertyChange(() => CanAddToList);

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

        public bool CanAddToList
        {
            get
            {
                bool output = false;

                //Make sure something is selected
                if (InputTextBox != null)
                {
                    output = true;
                }

                return output;
            }

        }





        public void AddToList(string inputTextBox)
        {
            ValidateInput(inputTextBox);

            KeyValuePairModel newKeyValuePair = new KeyValuePairModel
            {
                Key = Key,
                Value = Value
            };
            MyDisplayListBox.Add(newKeyValuePair);
   
            NotifyOfPropertyChange(() => MyDisplayListBox);
                        
        }

        public bool CanFilter(string inputTextBox)
        {
            if (string.IsNullOrEmpty(inputTextBox))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Filter(string inputTextBox)
        {
            //KeyValuePairModel forFilter = MyDisplayListBox.Where(x => x.KeyValuePair == inputTextBox);
            //fullList = MyDisplayListBox;
            //MyDisplayListBox = MyDisplayListBox.Where(x => x.KeyValuePair == inputTextBox).ToList();
            NotifyOfPropertyChange(() => MyDisplayListBox);
        }

        //check if inputtextbox is filled
        public bool CanClearFilter(string inputTextBox)
        {
            if(string.IsNullOrEmpty(inputTextBox))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //this works in pair with the above method
        public void ClearFilter(string inputTextBox)
        {
            InputTextBox = String.Empty;
            //MyDisplayListBox = fullList;
            NotifyOfPropertyChange(() => MyDisplayListBox);

        }

        public void DeleteButton()
        {
            MyDisplayListBox.RemoveAt(0);

        }

        //public void SortByName(string key)
        //{
        //    MyDisplayListBox = MyDisplayListBox.OrderBy(x => x.Key).ToList();
        //    NotifyOfPropertyChange(() => MyDisplayListBox);

        //}

        //public void SortByValue(string key)
        //{
        //    MyDisplayListBox = MyDisplayListBox.OrderBy(x => x.Value).ToList();
        //    NotifyOfPropertyChange(() => MyDisplayListBox);

        //}

        //public BindableCollection<KeyValuePairModel> MyDisplayListBox
        //{
        //    get { return _myDisplayListBox; }
        //    set
        //    {
        //        _myDisplayListBox = value;
        //        NotifyOfPropertyChange(() => MyDisplayListBox);
        //    }
        //}




        //Validates input and removes whitespaces
        public void ValidateInput(string input)
        {
            string inputWithoutWS = Regex.Replace(input, @"\s+", String.Empty);
            String[] inputArray = inputWithoutWS.Split('=');
            if (inputArray.Count() == 2 && inputArray[0].All(char.IsLetterOrDigit) && inputArray[1].All(char.IsLetterOrDigit))
            {
                
                Key = inputArray[0];
                Value = inputArray[1];
      
            }
            else if (inputArray.Count() != 2)
            {
                MessageBox.Show("Please enter only alphanumberic key-value pairs");
            }
           
        }

        //Delete Selected keyvalue pair from the listbox
        public void DeleteSelectedText()
        {

            MyDisplayListBox.Remove(SelectedKeyValuePair);
            NotifyOfPropertyChange(() => MyDisplayListBox);

        }

        public bool CanDeleteSelectedText
        {
            get
            {
                bool output = false;

                //Make sure something is selected
                if (SelectedKeyValuePair != null)
                {
                    output = true;
                }
             
                    return output;
            }
         
        }


    }
}
