   M S B A M L   `   `   `  ����L  HAESessionThreeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AESessionThreeWPFAESessionThreeWPF  5   	   p lDotNetProjects.DataVisualization.Toolkit, Version=6.1.94.0, Culture=neutral, PublicKeyToken=79778c5f2eed289b�rclr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=DotNetProjects.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5   	   *    $AESessionThreeWPF.EventDetailsWindow   5   	   e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:AESessionThreeWPF     5   	   �chartingToolkitrclr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=DotNetProjects.DataVisualization.Toolkit     5   	     � Title$  Event Details��5	   	    � WindowStartupLocation$ CenterScreen=�6   $	��600��6D   $	��800��6Q    � 	Resources 5
         ActualDataPointStyle �� 
TargetTypeF  @System.Windows.Controls.DataVisualization.Charting.LineDataPoint �� Property �� Value  ForecastDataPointStyle  ActualPolylineStyle  ForecastPolylineStyle��%�  &	        &	 J     &	 �     &	     �� 5   
   "  6-   .�5      ��  � ��
 ��  �6+   5      �� 5   
   "  6/   .�5      ��  � ��
 � � �6+   5      �� 5   
   " �6,   .�5      ��  � ��
 ����6'   �� 5       � ��$ 2��60   5      �� 5   
   " �6.   .�5      ��  � ��
 � E��6'   �� 5       � ��$ 2��60   �� 5       �@��StrokeDashArray$	 3 2R�60   5      5      .��5"      �  � RowDefinitions 5#   
   �� 5$      $
��Auto �6   �� 5%      $
��Auto �6   �� 5&      $��* �6   �� 5'      $
��Auto �6   �� 5(      $��* �6   .+�5+   
   ��  �� Orientation$ 
Horizontal=�6   $��5q�6.   .+�5,      �� -   5         ��Name$ EventNameTxt��5,      $��5q�6.   $��Event��69   �� 5-      -   5        $ CostTxt��5-      $��	100,5,0,5q�6)   $��Cost:��6<   �� 5.      -   5        $ ProfitLostTxt��5.      $��	100,5,0,5q�6/   $��Profit/Loss:��6B   �� 5/      -   5        $ SoldTicketsTxt��5/      $��	100,5,0,5q�60   $��Sold tickets:��6C   �� 50      -   5        $ AvailableTicketsTxt��50      $��	100,5,0,5q�65   $��Available tickets:��6H   51      � 53   
   $��1��6   .+�54      �� $��Tiers��6   $
��Bold"�6%   $��Center=�67   $	��5,0q�6R   �� 55      
�������	 �� CornerRadius$	 12��6(   $��1q�6:   $��2q�6N   $��Center=�6Y   $��80��6t   $��28��6   $��Right=�6�   
�������._�56      �� -   5        
 ��Name$
 BtnOptimize��56      $��Optimize��57      
������ 
������ $	��Top=�5:      $��0q�5;      $��26��6%   61   5<      5=      &   System.Windows.Controls.DataGrid  5?   
   -   5          Name$ TiersDataGrid��5?   +   $��2��6   $��5q�6       AutoGenerateColumns .     Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Tier Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *name+6Q     5B      $ Saleability��6%   $ * 6Z    6:   �� *saleability+6Z     5C      $ Demand��6%   $ * 6P    65   �� *demand+6P     5D      $ Price��6%   $ * 6N    64   �� *price+6N     5E      $ 
Base Price��6%   $ * 6W    69   �� *	basePrice+6W     5F      $ 	Available��6%   $ * 6V    68   �� *	available+6V     5G      $	 Max��6%   $ * 6J    62   �� *max+6J   5I      �� 5K   
   $��3��6   $ 
Horizontal=�6"   .+�5L      �� $��Forecast��6   $��5q�6(   $��Black"�63   �� 5M      $	��100��6   $��Center=�6!   $��25��6<   $��1q�6H   $��150,3q�6\   
�������$	 12��6~   ._�5N      �� -   5        $
 	BtnExport��5N      $��Export��6,   
������ $��Stretch=�5O      $��Stretch=�67   
������ 5P   2   5Q      5R      � 5T   
   $��4��6    � ColumnDefinitions 5U      �� 5V      $��* �6#   �� 5W      $��* �6#   .+�5[        -	   5        $ TierForecastDataGrid��5[      $��0��65   $��5q�6E    .   5\        5]      $ 	Tier Name��6)   $ * 6U    6<   �� *name+6U     5^      $ Amount��6)   $ * 6T    69   �� *amount+6T     5_      $ Price��6)   $ * 6R    68   �� *price+6R     5`      $ Saleability��6)   $ * 6^    6>   �� *saleability+6^   4  .System.Windows.Controls.DataGridCheckBoxColumn  5a      $ Is forecast��6-   $ * 6a    6B   �� *
isForecast+6a   5c      >  8System.Windows.Controls.DataVisualization.Charting.Chart  5f      -
   5          Name$ 	LineChart��5f   $   $��1��67   $��5q�6G      Title$ Sales Over Time��6R      Axes 5h      C	  =System.Windows.Controls.DataVisualization.Charting.LinearAxis	  =
  7System.Windows.Controls.DataVisualization.Charting.Axis 
  Orientation$ Y=�61   D  >System.Windows.Controls.DataVisualization.Charting.DisplayAxis   Title$ Price��6A      ShowGridLines .  6O   	  5i      $ X=�61   $ Purchase Index��6A    .  6X      Series. 5l      C  =System.Windows.Controls.DataVisualization.Charting.LineSeries  ?  9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Actual��5m   	   H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   DependentValuePath$ Price��5o   	      IndependentValuePath$ Index��5p   	      DataPointStyle# [  5q   	      PolylineStyle# [ 5r   	      ItemsSource 5n   	   �� *ActualPoints+5r   	     5t      $ Forecast��5u   	   $ Price��5w   	   $ Index��5x   	   # [ 5y   	   # [ 5z   	    5v   	   �� *ForecastPoints+5z   	   5{      5|      5}      5~      