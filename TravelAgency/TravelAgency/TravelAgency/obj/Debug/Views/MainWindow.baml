   M S B A M L   `   `   `  ����G  CTravelAgency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TravelAgency.ViewModelsTravelAgency.ViewModels  5   	   7 clr-namespace:TravelAgency.ViewsTravelAgency.Views  5   	   #    TravelAgency.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;	viewModel%clr-namespace:TravelAgency.ViewModels     5   	   2views clr-namespace:TravelAgency.Views     5   	     � Title$  
MainWindow��5   	   $
��1100��5	   	   $	��700��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $) #/TravelAgency;component/Styles.xaml?�6%   %    5      .��5      �� $��4q�6   
�������._�5      � ��5   
   �� 5       �� 
StartPoint$ 0.5,0&�6"    �� EndPoint$ 0.5,1&�65   .��5      �  � Color$ #0081b9��6   	 � Offset$		 0.0Q�6/   � 5      $ White��6   $		 1.0Q�6-   5      
 � RowDefinitions
 5   
   �� 5      $��30 �6   6*   �� 5      $��* �6   6)   .+�5"   
   � $��0��6   ��5#      �� 5$      $ 1,0.5&�6&   $ 0,0.5&�69   .��5%      � $ #0081b9��6#   $		 0.0Q�63   � 5&      $ White��6#   $		 1.0Q�61   5'      .+�5)      �� $��Center=�5*      $��Center=�5+      
�������$
��Bold"�5-      $��Verdana)�5.      $��20(�5/      .��50      TRAVEL AGENCY6    �� 51   
   -   5        $��0��51      $��Right=�52      $��Center=�53      
�������$
��Bold"�55      $��Verdana)�56      $��0,0,10,0q�57      $��20(�58      .��59   ,   X6/   5:      �� 5;   
   $��1��6    �� TabStripPlacement$
 Left=�6"   .@�5<      ��    TabItemStyle#��[  6   ��5=      �� 5>       �� Orientation$ 
Horizontal=�6!   .+�5?      �� $��30��6    $��..\Icons\book.png��6,   �� 5@      $��Center=�6$   $��Book Now��5A        TabHeaderText#��[ 5B   $   5C      .��5E      $   TravelAgency.Views.BookingView  $	��800��6(   $��20q�64   5F      �� 5G      #��[  6   ��5H      �� 5I      .+�5J      �� $ 
Horizontal=�6%   .+�5K      �� $��22��6$   $��0,0,2,0q�5L      $��..\Icons\reservation.png��5M      �� 5N      #��[ 6(   $��Customer��5O   (   5Q      �� 5R      #��[ 6$   $��Reservations��6K   5S      .��5U      1   +TravelAgency.Views.CustomerReservationsView  $��20q�65   5V      �� 5W      #��[  6   ��5X      �� 5Y      .+�5Z      �� $ 
Horizontal=�6%   .+�5[      �� $��22��6$   $��0,0,2,0q�5\      $��..\Icons\reservation.png��5]      �� 5^      #��[ 6(   $��Hotel��6O   5_      �� 5`      #��[ 6$   $��Reservations��6K   5a      .��5c      .   (TravelAgency.Views.HotelReservationsView  $��20q�62   5d      �� 5f      #��[  6   ��5g      �� 5h      .+�5i      �� $ 
Horizontal=�6%   .+�5j      �� $��24��6$   $��0,0,2,0q�5k      $��..\Icons\accomodation.png��5l      �� 5m      #��[ 6(   $��Accomodation��6O   5n      �� 5o      #��[ 6$   $��
Management��6K   5p      .��5r      ,   &TravelAgency.Views.HotelManagementView  $��20q�60   $	��Top=�5s   ,   5t      �� 5u      #��[  6   ��5v      �� 5w      .+�5x      �� $ 
Horizontal=�6%   .+�5y      �� $��24��6$   $��0,0,2,0q�5z      $��..\Icons\hotelReserve.png��5{      �� 5|      #��[ 6(   $��Hotel Books��6O   5}      �� 5~      #��[ 6$   $��Rooms��6K   5      .��5�      ,   &TravelAgency.Views.HotelBooksRoomsView  $��20q�60   5�      5�      5�      5�      5�      