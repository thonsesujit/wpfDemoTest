.NET Development Test 
============
This test consists of writing a simple utility for managing Name/Value pair data in a Windows application. It will allow you to better understand my design and programming skills as well as your attention to  detail. 

Overview 
------------
It is basic WPF gui. Caliburn micro is used for MVVM. Instead of making a database for this short application, database is simulated using a constructor. The app is kept simple without any styling elements.

Features
------------
Here's a numbered list:

 1. Name/Value pairs are to be entered into the upper textbox. This textbox is used for 
adding and filtering Name/Value pairs.
 2. When the ‘Add’ button is pressed the Name/Value pair in the textbox is validated, and 
then if it passes validation it is added to the listbox below. The Name/Value pair entry 
format is shown  below: 

    \<name> = \<value>.

     Where \<name> is the name portion of the pair, and <value> is the value portion of the pair. Only valid Name/Value pairs can be added. Names and Values can contain only alpha-numeric characters. The equal-sign is used to delimit the pair, spaces before and/or after the equal-sign may be entered as padding at the end-user’s discretion. 

 3.  When the ‘Sort by Name’ button is pressed the list will be sorted ascending by    Name. 
 3.  When the ‘Sort by Value’ button is pressed the list will be sorted ascending by    Value. 
 3.  When the ‘Delete’ button is pressed all selected items in the listbox will deleted. 
 3. Filters have the following format (and are similar to the Name/Value   format):
\<type> = \<value>.

    Where <type> is either **Name** or **Value**, and <value> is a string used for matching against the given type. 
 

 3. When the ‘Clear Filter’ button is pressed all of the Name/Value pairs will be shown in the listbox. 

 
