   M S B A M L   `   `   `  ����L  HAESessionThreeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AESessionThreeWPFAESessionThreeWPF  5   	   '    !AESessionThreeWPF.DashboardWindow   5   	   e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:AESessionThreeWPF     5   	     � Title$  DashboardWindow��5   	   $	��800��6!   $
��1200��6.   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��10q�6;   .+�5      �� -   5         ��Name$ ComboboxEventGroup��5      $	��200��63   
�������
���   �$��Center=�6f   $��1q�6�   $��28��6�   6�   �� 5      -   5         ��Name$ TotalCostTxt��5      $��	150,0,0,0q�6.   $��Total Cost:��6A   �� 5      -   5        $ TotalIncomeTxt��5      $��100,0q�60   $��Total Income:��6?   �� 5      -   5        $ DifferenceTxt��5      $
��20,0q�6/   $��Difference:��6=   5      � 5   
   $��1��6   $��10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��10q�6   
�������$��1q�64   $	��160��6H   ._�5      �� $ Vertical=�6   .+�5      �� $��Event information��6    $
��Bold"�69   $��Center=�6K   $��10q�6h   �� 5      -   5        $ NumberOfEventsTxt��5       $��Number of Events:��6;   $
��10,0q�6T   �� 5       -   5        $ UpcomingEventsTxt��5        $��Upcoming Events:��6;   $
��10,0q�6S   �� 5!      -   5        $ LeastProfitableTxt��5!       $��Least profitable:��6<   $
��10,0q�6U   �� 5"      -   5        $ MostProfitableTxt��5"       $��Most profitable:��6;   $
��10,0q�6S   5#      5$      �� 5%      $��10q�6   
�������$��1��64   $��1q�6D   $	��160��6X   ._�5&      �� $ Vertical=�6   .+�5'      �� $��Statistics information��6    $
��Bold"�6>   $��Center=�6P   $��10q�6m   �� 5(      -	   5        $ AverageIncomeTxt��5(       $��Number of Events:��6:   $
��10,0q�6S   �� 5)      -
   5        $ AverageProfitTxt��5)       $��Upcoming Events:��6:   $
��10,0q�6R   �� 5*      -   5        $ AverageOccupancyTxt��5*       $��Least profitable:��6=   $
��10,0q�6V   �� 5+      -   5        $ AverageTicketPriceTxt��5+       $��Most profitable:��6?   $
��10,0q�6W   5,      5-      �� 5/      $��10q�6   
�������$��2��64   $��1q�6D   $	��160��6X   ._�50      �� $ Vertical=�6   .+�51      �� $��Ticket information��6    $
��Bold"�6:   $��Center=�6L   $��10q�6i   �� 52      -   5        $ SoldTicketsTxt��52       $��Number of Events:��68   $
��10,0q�6Q   �� 53      -   5        $ AvailableTicketsTxt��53       $��Upcoming Events:��6=   $
��10,0q�6U   �� 54      -   5        $ CheapestTicketTxt��54       $��Least profitable:��6;   $
��10,0q�6T   �� 55      -   5        $ MostExpensiveTicketTxt��55       $��Most profitable:��6@   $
��10,0q�6X   56      57      59      � 5:   
   $��2��6   .+�5;      �� $��Events��6   $
��10,5q�6'   	� 5<      -   5         	�Name$ RBShowPastEvents��5<      $��Show Past Events��64   $��Right=�6v   $
��10,5q�6�   6�   5=      &   System.Windows.Controls.DataGrid  5>   
   -   5          Name$ EventsDataGrid��5>      $��3��6^   $��10q�6k      AutoGenerateColumns .  	   Columns	 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Event name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *name+6R     5A      $
 Available tickets��6%   $ * 6e    6@   �� *availableTickets+6e     5B      $
 Sold tickets��6%   $ * 6[    6;   �� *soldTickets+6[     5C      $
 all tickets��6%   $ * 6Y    6:   �� *
allTickets+6Y     5D      $
 	Occupancy��6%   $ * 6V    68   �� *	occupancy+6V     5E      $
 
Event date��6%   $ * 6W    69   �� *	eventDate+6W   5G      5H      5I      