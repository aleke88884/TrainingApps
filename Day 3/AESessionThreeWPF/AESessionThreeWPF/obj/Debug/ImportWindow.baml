   M S B A M L   `   `   `  ����L  HAESessionThreeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AESessionThreeWPFAESessionThreeWPF  5   	   $    AESessionThreeWPF.ImportWindow   5   	   e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:AESessionThreeWPF     5   	     � Title$  Import��5   	   $	��450��6   $	��800��6%    � WindowStartupLocation$ CenterScreen=�61   .��5	      � $��10q�6    � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� $��20q�6   $��Center=�6    $��40��6;   .+�5      �� $
��🔍��6   $��30��6"   $��0,0,5,0q�6-   �� 5      -   5         ��Name$ BtnSelectFile��5   W   $��Select file��6   $��Stretch=�6+   $��14(�6I   6n   5      �� 5   
    �� Orientation$ Vertical=�6   $��2��6,   $��Center=�6<   $��Center=�6W   .+�5      	� -   5         	�Name$ RbOrganizers��5   W   $��
Organizers��6    	� 	GroupName$ 
ImportType��6/    d� 	IsChecked$
 TrueY�6F   $��14(�6m   	� 5      -   5        $ RbLocations��5   S   $��	Locations��6   $ 
ImportType��6.   $��14(�6E   6S   	� 5      -   5        $ RbEvents��5   P   $��Events��6   $��14(�6+   $ 
ImportType��69   6P   	� 5      -   5        $ RbBookingsCsv��5   X   $��Bookings (csv)��6   $��14(�63   $ 
ImportType��6A   6X   	� 5      -   5        $ RbBookingsMc��5   W   $��Bookings (mc)��6   $��14(�62   $ 
ImportType��6@   6W   	� 5      -   5        $ RbBookingsTpc��5   X   $��Bookings (tpc)��6   $��14(�63   $ 
ImportType��6A   6X   5      �� 5    
   -   5        $ 	BtnImport��5    e   $��Import��6   $��1��6"   $��1��6/   $	��100��6?   $��30��6K   $��14(�6W   6x   �� 5!   
   -	   5        $ BtnDashboard��5!   o   $��Dashboard Window��6   $��1��6,   $��2��69   $	��200��6I   $��30��6U   $��14(�6a   6�   �� 5"   
   -
   5        $ BtnEvent��5"   t   $��Events Details Window��6   $��1��61   $��0��6>   $	��200��6N   $��30��6Z   $��14(�6f   6�   &   System.Windows.Controls.DataGrid  5$   
   -   5        	  Name$	 ImportDataGrid��5%      $��2��5&      $��3��5'      $��10q�5(      
   AutoGenerateColumns
 .    
IsReadOnly .    Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ Line number��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
LineNumber+6Y     5/      $
 Text��6%   $ * 6L    63   �� *Text+6L     50      $ Error��6%   $ * 6N    64   �� *Error+6N   53      55      56      