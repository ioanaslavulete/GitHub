   M S B A M L   `   `   `  ����G  CTravelAgency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TravelAgency.ViewsTravelAgency.Views  5      A%clr-namespace:TravelAgency.ViewModelsTravelAgency.ViewModels  5      .    (TravelAgency.Views.HotelReservationsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:TravelAgency.Views     5      ;	viewModel%clr-namespace:TravelAgency.ViewModels     5      
�������  � 	Resources  5      3   -TravelAgency.ViewModels.ReservationsViewModel   ReservationViewModel��%   &	          5   
   6*   5      .��5      �  � DataContext 6   ��  �� Source# [   � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��40 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6     HeadingLeabelStyle#��[ 5      .��6<   Accomodation Reservations5      &   System.Windows.Controls.DataGrid  5!   
   $��1��6   $	��232��5"      $	��200��5#         AutoGenerateColumns .     HeadersVisibility$ Column=�5%      $
��Left=�5&      $   HorizontalScrollBarVisibility$ Disabled=�5'      "   VerticalScrollBarVisibility$
 Auto=�5(      $	��Top=�5)      ��5*      �� *,*ReservationRepository.HotelReservationList+	 �� SelectedItem	 5+      �� *!SelectedAccomodationReservation+
 �� Mode$
 OneWayToSource=�   Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6%      Header$ Hotel��50      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5/      �� *
Hotel.Name+50        51      $ 65 6%   $ Check In��53       52      �� *ReservationPeriod.CheckIn+53        54      $ 65 6%   $ 	Check Out��56       55      �� *ReservationPeriod.CheckOut+56      59      �� 5;   
   $��2��6   #��[ 5<      .��6<   Search Reservation5>      �� 5@   
   $��5,0,0,0q�6   $��2��5A      $��1��5B      $
��Left=�5C        NormalTextBoxStyle#��[ 5D      ��5E      �� *SearchedAccomodationName+$
 OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=��� 5H   
   $��2��6   $��1��5I      $	��100��5J      $��
10,10,0,10q�5K      $��Center=�5L      $��Center=�5M      ��5N      �� *SearchHotelReservationCommand+.��6=   Search reservation5P        5S   
   $��1��6   $	��232��5T      $	��200��5U       .  $ Column=�5W      $
��Left=�5X      $ Disabled=�5Y      $
 Auto=�5Z      $	��Top=�5[      ��5\      �� *,*ReservationRepository.HotelReservationList+	 5]      �� *!SelectedAccomodationReservation+$
 OneWayToSource=� 5_        5`      $	 100 6%   $ Accomodation��5b       5a      �� *
Hotel.Name+5b        5c      $ 65 6%   $ Check In��5e       5d      �� *ReservationPeriod.CheckIn+5e        5f      $ 65 6%   $ 	Check Out��5h       5g      �� *ReservationPeriod.CheckOut+5h      5k        5l   
   $��3��6   $	��232��5m      $	��200��5n       .  $ Column=�5p      $
��Left=�5q      $ Disabled=�5r      $
 Auto=�5s      $	��Top=�5t      ��5u      �� *#!SearchAccomodationReservationList+	 5v      �� *!SelectedAccomodationReservation+$
 OneWayToSource=� 5x        5y      $	 100 6%   $ Accomodation��5{       5z      �� *
Hotel.Name+5{        5|      $ 65 6%   $ Check In��5~       5}      �� *ReservationPeriod.CheckIn+5~        5      $ 65 6%   $ 	Check Out��5�       5�      �� *ReservationPeriod.CheckOut+5�      5�      �� 5�   
   $��3��6   $��1��5�      $��Right=�5�      $��Bottom=�5�      $	��120��5�      $��20��5�      $��	0,0,20,20q�5�      ��5�      �� *CancelHotelReservationCommand+.��6=   Cancel Reservation5�      5�      5�      