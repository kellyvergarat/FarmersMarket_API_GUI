   M S B A M L   `   `   `  ����L  HFarmersMarket_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FarmersMarket_GUIFarmersMarket_GUI  5   	   "    FarmersMarket_GUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:FarmersMarket_GUI     5   	     � Title$  Farmers Market Admin��5   	   $	��600��6&   $	��850��63    � WindowStartupLocation$ CenterScreen=�6?   .��5	      � .+�5
   
   �� .+�5      �� $��Center=�6   
���   �$	��850��6D   ���	#FFF09A9A J� Opacity$ 0.595Q�6a   $��52��6q   $	��Top=�6}    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5      5      �� 5      $&�� Farmer's market inventory system��6   $
��Left=�6?   $��Center=�6Z   $��24(�6u   $
��Bold"�6�    �� Left$	 198��6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ dataGrid��5      $ 78��6T   
 �� Top$	 274��6e   $	��694��6v   $��Center=�6�   $��Center=�6�   �� 5      -   5         ��Name$ 	InsertSQL��5      $��Insert��6(   $��40��69   $	��124��6E   $��16(�6Q   $
��Left=�6w   $	 490��6�   $	 144��6�   $	��Top=�6�   �� 5      -   5        $ 	DeleteSQL��5      $��Delete��6(   $��40��69   $	��124��6E   $��16(�6Q   ���	#FFEEC3C3$
��Left=�6�   $	 490��6�   $	 197��6�   $	��Top=�6�   �� 5      -   5        $ 	UpdateSQL��5      $��Update��6(   $��40��69   $	��124��6E   $��16(�6Q   ���	#FF7CDC8F$
��Left=�6�   $	 646��6�   $	 144��6�   $	��Top=�6�   �� 5      -   5        $ 	SelectSQL��5      $
��Show��6(   $��40��67   $	��124��6C   $��16(�6O   ���	#FFD4DC9B$
��Left=�6�   $	 646��6�   $	 197��6�   $	��Top=�6�   �� 5      -   5         ��Name$ searchProductID��5      	 �� TextWrapping$
	 Wrap=�6/   $��Insert Product ID��6C   $	��153��6\   $��24��6h   $��16(�6t   $
��Left=�6�   $	 490��6�   $ 77��6�   $	��Top=�6�   �� 5      -   5        $ 	searchBtn��5      $��Search��6(   $��25��69   $��92��6E   $��16(�6P   $	 662��6^   $ 76��6p   $
��Left=�6�   $	��Top=�6�   6�   �� 5      -   5        $ InsertID��5      $
	 Wrap=�6(   $	��148��6<   $��16(�6H   $
��Left=�6V   $	 228��6q   $ 84��6�   $	��Top=�6�   �� 5      -	   5        $ InsertPName��5      $	��148��6+   $��16(�67   $
��Left=�6E   $	 228��6`   $	 122��6r   $	��Top=�6�   �� 5      -
   5        $ InsertAmount��5      $
	 Wrap=�6,   $	��148��6@   $��16(�6L   $
��Left=�6Z   $	 228��6u   $	 163��6�   $	��Top=�6�   �� 5      -   5        $ InsertPrice��5      $
	 Wrap=�6+   $	��148��6?   $��16(�6K   $
��Left=�6Y   $	 228��6t   $	 199��6�   $	��Top=�6�   �� 5      -   5        
 ��Name$
 	label_pID��5      $��
Product ID��6'   $��16(�6<   $
��Left=�6J   $ 99��6e   $ 80��6v   $��Center=�6�   �� 5      -   5        $
 label_pName��5      $��Product Name��6)   $��16(�6@   $
��Left=�6N   $ 99��6i   $	 118��6z   $��Center=�6�   �� 5      -   5        $
 label_amount��5      $��
Amount(kg)��6*   $��16(�6?   $
��Left=�6M   $ 98��6h   $	 159��6y   $��Center=�6�   �� 5      -   5        $
 label_price��5      $��Price(CAD)/kg��6)   $��16(�6A   $
��Left=�6O   $ 97��6j   $	 195��6{   $��Center=�6�   �� 5       -   5        $ sales��5       $��Go to Sales module��6$   $��40��6A   $	��163��6M   $��16(�6Y   ���	#FF8DC7E8$	 648��6~   $	 501��6�   $
��Left=�6�   $��Center=�6�   $
��Bold"�6�   6�   �� 5!      -   5        $
 ResponseLabel��5!      $��Label��6+   $	 330��6;   $	 440��6M   5"      5$      5%      