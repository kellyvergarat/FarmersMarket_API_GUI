   M S B A M L   `   `   `  ����L  HFarmersMarket_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FarmersMarket_GUIFarmersMarket_GUI  5   	   #    FarmersMarket_GUI.SalesModule   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:FarmersMarket_GUI     5   	     � Title$  SalesModule��5   
   $	��600��6   $	��850��6+   .��5	      �� .+�5
   
   �� $��Center=�6   
���   �$	��850��6@   ���	#FFF09A9A J� Opacity$ 0.595Q�6]   $��52��6m   $	��Top=�6y    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5      5      �� 5   
   $"��Farmer's market sales system��6   $
��Left=�67   $	��Top=�6R   $��24(�6j   $
��Bold"�6x    �� Left$	 256��6�   �� 5   
   -   5         ��Name$ label_pName��5      $�� ��6%   $��16(�60   $
��Left=�6>   $ 99��6Y   
 �� Top$	 118��6j   $��Center=�6{   �� 5   
   $��Customer name:��6   $	 104��6)   $ 91��6;   $��Center=�6K   $	��Top=�6h   $��16(�6�   �� 5   
   -   5         ��Name$ search��5      $	 235��6"    �� TextWrapping$
 Wrap=�64   $��Insert customer name��6H   $ 95��6d   $	��216��6t   $
��Left=�6�   $��Center=�6�   $��16(�6�   �� 5   
   $��Calculate total order��6   $	 328��60   $	 445��6B   $��16(�6S   $
��Bold"�6a   $
��Left=�6s   $��Center=�6�   �� 5   
   -   5         ��Name$ calculateBtn��5      $��	Calculate��6'   $	 284��6;   $	 486��6M   $��38��6^   $	��114��6j   $��16(�6v   $
��Bold"�6�   ���	#FF93CBEB$
��Left=�6�   $��Center=�6�   ��6�   Z� �� 5   
   -   5        $ buyBtn��5      $��Confirm purchase��6!   $	 593��6<   $	 488��6N   $��38��6_   $	��167��6k   $��Center=�6w   $	��Top=�6�   $��16(�6�   $
��Bold"�6�   ���	#FFBBE897��6�   Z� �� 5   
   -   5        $ 	showTotal��5      $��$ 0.0��6#   $	 426��63   $	 481��6E   $��52��6V   $	��131��6b   ���	#FFDCD7D1$��Center=�6�   $��20(�6�   $��Center=�6�   $��0,0,50,0q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 salesDataGrid��5      $	��235��6*   $	��661��67   $ 99��6n   $	 190��6   $��Center=�6�   $	��Top=�6�   �� 5   
   -   5        $ _return��5      $��Return to ADMIN��6"   $	 650��6<   $ 69��6N   $��38��6^   $	��144��6j   $
��Left=�6v   $��Center=�6�   ���	#FFFA9A7A$
��Bold"�6�   $��14(�6  ��6�   Z� 6  �� 5   
   $ 71��6   $
��Wrap=�6%   $	 154��69   $
��Left=�6J   $��Center=�6e   $����This is the list for the products available in our farmer's market. Please edit the amount column for the products you want to purchase.��6�   5      5      