   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      G CTravelAgency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TravelAgency.ViewModelsTravelAgency.ViewModels 5      $   TravelAgency.Views.BookingView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      6sys&clr-namespace:System;assembly=mscorlib     5      ;	viewModel%clr-namespace:TravelAgency.ViewModels     5      
�������  � 	Resources  5      .  (TravelAgency.ViewModels.BookingViewModel   BookingViewModel 
 Color1 
 Color2 
 Color3 
 Color4 
 Color5��%�   &	        &	      &	 4     &	 Q     &	 r     &	 �       5   
   6%   ��5   
   	#FF079A9A��6*   ��5   
   	White��6&   ��5   
   	#FF079A9A��6*   ��5   
   	White��6&   ��5   
   	#FFFAFAFA��6*   5      .��5      �  � DataContext 6   ��  �� Source# [   � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5!   
   �� 5"      $��* �6   �� 5#      $��* �6   �� 5$      $��* �6   .+�5'   
   �� $��0��6   $��0��5(   
     HeadingLeabelStyle#��[ 5)   
   .��66   Reserve Room5+      �� 5-   
   $��1��6   $��0��5.      $��10,0,0,0q�5/      $
��Left=�50      $��Center=�51      ��52      �� *EmptyCustomerFieldsCommand+ �� UpdateSourceTrigger$ PropertyChanged=�.��53   C   New Customer55      �� 57   
   $��1��6   $��1��58      $��Center=�59       �� Orientation$ 
Horizontal=�5:      .+�5;      �� $��80��6   $��5,0,0,0q�6   .��60   Customer ID5=      �� 5>      -   5         ��Name$ 
CustomerId��5?      $��5,0,0,0q�5>        NormalTextBoxStyle#��[ 5@      ��5A      �� *Reservation.Owner.Id+$ PropertyChanged=� �� ValidatesOnDataErrors . 	 =� ErrorTemplate	 5D      Z� �� 5E      $
��Bold"�5G      
���  ����5E      �� 
 �� ElementName$
 
CustomerId�� �� Path$2 ,(Validation.Errors).CurrentItem.ErrorContent�5J      5K      �� 5M   
   $��1��6   $��2��5N      $	��100��5O      $��
10,10,0,10q�5P      $
��Left=�5Q      $��Center=�5R      ��5S      �� *GetCustomerInfoCommand+��5U      �� 5V       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5W      �  � Color$ Black��6#   � 5X      # �  6#   5Y      .��5Z   "   
Get Info5\      �� 5^   
   $��2��6   $��0��5_      $��Center=�5`      $ 
Horizontal=�5a      .+�5b      �� $��50��6   $��5,0,0,0q�6   .��60   Title5d      �� 5e      $��75��6   $��20��5f      $��5,0,0,0q�5g      .@�5h      �� .��6   Mr.6$   �� 5i      .��6   Ms.6$   �� 5j      .��6   Mrs.6%   5k      5l      �� 5n   
   $��2��6   $��1��5o      $ 
Horizontal=�5p      .+�5q      �� $��80��6   $��5,0,0,0q�5r      $��Center=�5s      .��6&   
First Name5u      �� 5w      -   5        $ CustomerFirstName��5y      $��5,0,0,0q�5w      #��[ 5x      ��5z      �� *Reservation.Owner.FirstName+$ PropertyChanged=� . 	 5}      Z� .��6:   5~      �� 5      $
��Bold"�5�      
���  ����5      �� $
 CustomerFirstName��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5�      5�      �� 5�   
   $��2��6   $��2��5�      $ 
Horizontal=�5�      .+�5�      �� $��80��6   $��5,0,0,0q�5�      $��Center=�5�      .��6&   	Last Name5�      �� 5�      -   5        $ CustomerLastName��5�      $��5,0,0,0q�5�      #��[ 5�      ��5�      �� *Reservation.Owner.LastName+$ PropertyChanged=� . 	 5�      Z� �� 5�      $
��Bold"�5�      
���  ����5�      �� $
 CustomerLastName��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5�      5�      �� 5�   
   $��3��6   $��0��5�      $ 
Horizontal=�5�      .+�5�      �� $��49��6   $��5,7,0,7q�5�      $��Center=�5�      .��6&   E-Mail5�      �� 5�      $	��150��6   $��20��5�      $��5,0,0,0q�5�      $��Center=�5�      #��[ 5�      ��5�      �� *Reservation.Owner.Email+$ PropertyChanged=� . 5�      �� 5�   
   $��3��6   $��1��5�      $ 
Horizontal=�5�      .+�5�      �� $��80��6   $��5,0,0,0q�5�      $��Center=�5�      .��6&   Phone5�      �� 5�      -   5        $ CustomerPhone��5�      $��5,0,0,0q�5�      #��[ 5�      ��5�      �� *Reservation.Owner.PhoneNumber+$ PropertyChanged=� . 	 5�      Z� �� 5�      $
��Bold"�5�      
���  ����5�      �� $
 CustomerPhone��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5�      5�      �� 5�   
   $��4��6   $��0��5�      $ 
Horizontal=�5�      .+�5�      �� $��50��6   $��5,7,0,7q�5�      $��Center=�5�      .��6&   Place5�      �� 5�      $	��150��6   $��20��5�      $��	5,10,0,10q�5�       �� 
IsEditable . ��5�      �� *LocationList+ �� SelectedItem 5�      �� *SelectedLocation+ �� Mode$ OneWayToSource=�$ PropertyChanged=�5�      5�      �� 5�   
   $��5��6   $��0��5�      $��Center=�5�      $ 
Horizontal=�5�      .+�5�      �� $��80��6   $��5,0,0,0q�6   .��60   
Check In5�      (  "System.Windows.Controls.DatePicker  5�      $	��120��6   $��26��5�      $��5,0,0,0q�5�       �� Today   DisplayDateStart# Z 5�         SelectedDate 5�      �� *'%Reservation.ReservationPeriod.CheckIn+	 5�      Z� 5�      �� 5�   
   $��5��6   $��1��5�      $��Center=�5�      $ 
Horizontal=�5�      .+�5�      �� $��80��6   $��5,0,0,0q�6   .��60   	Check Out5�        5�      $	��120��6   $��26��5�      $��5,0,0,0q�5�       5�      �� *'%Reservation.ReservationPeriod.CheckIn+ 5�      �� *(&Reservation.ReservationPeriod.CheckOut+	 5�      Z� 5�      �� 5�   
   $��4��6   $��1��5�      $��Center=�5�      $ 
Horizontal=�5�      .+�5      �� $��80��6   $��5,0,0,0q�6   .��60   	Persons5     �� 5     $��5,0,0,0q�6   #��[ 5     ��5     �� *Reservation.NumberOfPersons+$ PropertyChanged=�5     �� 5	  
   $��5��6   $��2��5
     $	��100��5     $��10,0,0,0q�5     $
��Left=�5     $��Center=�5     ��5     �� *CheckAvailabilityCommand+$ PropertyChanged=�.��5  C   Check Availability5     �� 5  
   $��6��6   $��3��6"   .+�5     �� .��6   Best Options6"   &   System.Windows.Controls.DataGrid  5     $	��100��6   $��5,0,5,0q�5        AutoGenerateColumns .     HeadersVisibility$ Column=�5     $   HorizontalScrollBarVisibility$ Disabled=�5     "   VerticalScrollBarVisibility$
 Auto=�5     ��5     �� *AvailableOptions+ 5     �� *SelectedOption+$ OneWayToSource=�$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5!     ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 140 6)      Header$ Accomodation��5#        
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5"     �� *
Hotel.Name+5$       5%     $ 50 6)   $ Stars��5'      .  5&     �� *Hotel.NumberOfStars+5(       5)     $	 150 6)   $ Location��5+      .  5*     �� *Hotel.Location+5,       5-     $	 200 6)   $ Best option for you��5/      5.     �� *Result+5/       50     $	 100 6)   $ Total Price��51  )    52  )   �� *TotalPrice.FullPrice+  53     $	 150 6)   $ Available Rooms��55      54     �� * Hotel.AvailableRoomsList.Count+55     57     58     �� 5:  
   $��7��6   .+�5;     �� .��6   Available rooms6%     5<     -   5          Name$ dataGrid��5D     $	��100��5<     $��5,0,5,0q�5=     $	��250��5>      .  $
��Left=�5@     $ Column=�5A     $ Disabled=�5B     $
 Auto=�5C     ��5E     �� *)'SelectedOption.Hotel.AvailableRoomsList+ 5F     �� *SelectedRoom+$ OneWayToSource=�$ PropertyChanged=� 5I       5K     $ 70 6)   $ Price��5L  )    5M  )   �� *Price.FullPrice+  5N     $	 100 6)   $ Capacity��5O  )    5P  )   �� *NumberOfPersons+  5Q     $ 90 6)   $ 	Room View��5R  )    5S  )   �� *RoomViewType+5U     5V     �� 5X  
   $��8��6   $��0��5Y     $	��100��5Z     $��Center=�5[     $��Right=�5\     ��5]     �� *AddRoomToReservationCommand+��5^     �� *SelectedRoom+.��6;   Add5`     �� 5b  
   $��7��6   $��1��5c     .+�5d     �� .��6   Reserved Rooms6$     5e     $	��100��6   $��5,0,5,0q�5f     $	��250��5g      .  $
��Left=�5i     $ Column=�5j     $ Disabled=�5k     $
 Auto=�5l     ��5m     �� *RoomsToReserve+ 5n       5p     $ 70 6)   $ Price��5q  )    5r  )   �� *Price.FullPrice+  5s     $	 100 6)   $ Capacity��5t  )    5u  )   �� *NumberOfPersons+  5v     $	 100 6)   $ 	Room View��5w  )    5x  )   �� *RoomViewType+5z     5{     �� 5}  
   $��8��6   $��2��5~     $	��100��5     $��20��5�     $��0,0,0,0q�5�     $��Center=�5�     $
��Left=�5�     ��5�     �� *ShowBookingVoucherCommand+.��69   Next5�     5�     5�     