   M S B A M L   `   `   `  ����G  CTravelAgency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TravelAgency.ModelsTravelAgency.Models  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      %    TravelAgency.Views.AddHotelView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2enum!clr-namespace:TravelAgency.Models     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      6sys&clr-namespace:System;assembly=mscorlib     5        � 	Resources  5
         dataFromEnum S� 
MethodName S� 
ObjectType  System.Enum S� MethodParameters M� TypeName��%�   &	        S� 5   
   $ 	GetValues��5      "  5       5      M� 5      $ enum:AccomodationType��6   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5    
   �� $��0��6   $��0��5!      $��Center=�5"       �� Orientation$ 
Horizontal=�5#      .+�5$      �� $��45��6   $��5,0,0,0q�6   .��60   Id5&      �� 5'      -   5         ��Name$ HotelId��5)        NormalTextBoxStyle#��[ 5'      $��5,0,0,0q�5(      ��5*      �� *Accomodation.Id+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=� �� ValidatesOnDataErrors .  =� ErrorTemplate 5.      Z� �� 5/      $
��Bold"�51      
���  ����5/      ��  �� ElementName$ HotelId�� �� Path$2 ,(Validation.Errors).CurrentItem.ErrorContent�54      55      �� 56   
   $��0��6   $��1��57      $��Center=�58      $ 
Horizontal=�59      .+�5:      �� $��5,0,0,0q�6   .��6%   Type6+   �� 5;      $	��100��6   $��20��5<      $��22,0,0,0q�5=       �� SelectedIndex$ 0��5@      ��5>      ��  �� Source# [   �� SelectedValue 5?      �� *AcomodationType+$	 OneWayToSource=�5@      5A      �� 5C   
   $��1��6   $��0��5D      $��Center=�5E      $ 
Horizontal=�5F      .+�5G      �� $��45��6   $��5,0,0,0q�6   .��60   Name5I      �� 5J      -   5        $ 	HotelName��5L      #��[ 5J      $��5,0,0,0q�5K      ��5M      �� *Accomodation.Name+$	 TwoWay=�$
 PropertyChanged=� .  5Q      Z� �� 5R      $
��Bold"�5T      
���  ����5R      �� $ 	HotelName��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5W      5X      �� 5Z   
   $��2��6   $��0��5[      $��Center=�5\      $ 
Horizontal=�5]      .+�5^      �� $��45��6   $��5,0,0,0q�6   .��60   City5`      �� 5a      -   5        $ 	HotelCity��5c      #��[ 5a      $��5,0,0,0q�5b      ��5d      �� * Accomodation.Location.CityName+$	 TwoWay=�$
 PropertyChanged=� .  5h      Z� �� 5i      $
��Bold"�5k      
���  ����5i      �� $ 	HotelCity��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5n      5o      �� 5p   
   $��2��6   $��1��5q      $��Center=�5r      $ 
Horizontal=�5s      .+�5t      �� $��52��6   $��5,0,0,0q�6   .��60   	Country5v      �� 5w      -   5        $ HotelCountry��5y      #��[ 5w      $��5,0,0,0q�5x      ��5z      �� *#!Accomodation.Location.CountryName+$	 TwoWay=�$
 PropertyChanged=� .  5~      Z� �� 5      $
��Bold"�5�      
���  ����5      �� $ HotelCountry��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5�      5�      �� 5�   
   $��3��6   $��0��5�      $��Center=�5�      $ 
Horizontal=�5�      .+�5�      �� $��45��6   $��5,0,0,0q�5�      $��Center=�5�      .��6&   Stars5�      �� 5�      -   5        $ 
HotelStars��5�      #��[ 5�      $��5,0,0,0q�5�      ��5�      �� *Accomodation.NumberOfStars+$	 TwoWay=�$
 PropertyChanged=� .  5�      Z� �� 5�      $
��Bold"�5�      
���  ����5�      �� $ 
HotelStars��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5�      5�      �� 5�   
   $��3��6   $��1��5�      $��Center=�5�      $ 
Horizontal=�5�      .+�5�      �� $	��100��6   $��62,0,0,0q�5�      $��Center=�5�      ���	#FFDDDDDD��5�      �� *AddAccomodationCommand+.��6N   Add5�      5�      5�      5�      