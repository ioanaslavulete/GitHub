   M S B A M L   `   `   `  ����G  CTravelAgency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TravelAgency.ViewsTravelAgency.Views  5      A%clr-namespace:TravelAgency.ViewModelsTravelAgency.ViewModels  5      1    +TravelAgency.Views.CustomerReservationsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:TravelAgency.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ;	viewModel%clr-namespace:TravelAgency.ViewModels     5      
�������  � 	Resources  5      3   -TravelAgency.ViewModels.ReservationsViewModel   ReservationViewModel��%   &	          5      6$   5      .��5      �  � DataContext 6   ��  �� Source# [   � RowDefinitions 5      �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��40 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   ��   HeadingLeabelStyle#��[ 6   $��0��5       $��0��5!   
   .��6   Customer Reservations5#      &   System.Windows.Controls.DataGrid  5%   
   $	��673��6   $	��300��5&         AutoGenerateColumns .     HeadersVisibility$ Column=�5(      $��1��5)      $��0��5*      $��2��6#   $   HorizontalScrollBarVisibility$ Disabled=�5+      "   VerticalScrollBarVisibility$
 Auto=�5,      $
��Left=�5-      $	��Top=�5.      ��5/      �� *'%ReservationRepository.ReservationList+	 �� SelectedItem	 50      �� *SelectedReservation+
 �� Mode$
 OneWayToSource=�   Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6      Header$ ID��55      1  +System.Windows.Controls.DataGridBoundColumn   Binding 54      �� *
Owner.Id+55        56      $	 100 6   $ 
First Name��58       57      �� *Owner.FirstName+58        59      $	 100 6   $ 	Last Name��5;       5:      �� *Owner.LastName+5;        5<      $ 70 6   $ Persons��5>       5=      �� *NumberOfPersons+5>        5?      $	 100 6   $ Hotel��5A       5@      �� *
Hotel.Name+5A        5B      $	 100 6   $ Location��5D       5C      �� *Hotel.Location.FullName+5D        5E      $ 65 6   $ Check In��5G       5F      �� *ReservationPeriod.CheckIn+5G        5H      $ 65 6   $ 	Check Out��5J       5I      �� *ReservationPeriod.CheckOut+5J      5L      �� 5P   
   $	��120��6   $��20��5Q      $��	0,0,20,20q�5R      $��3��5S      $��1��5T      $��Right=�5U      $��Bottom=�5V      ��5W      �� *CancelReservationCommand+.��68   Cancel Reservation5Y      �� 5[   
   #��[ 6   $��2��5\      $��0��5]   
   .��6   Search Reservation5_      �� 5a   
   $��5,0,0,0q�6   $��2��5b      $��1��5c      $
��Left=�5d        NormalTextBoxStyle#��[ 5e      ��5f      �� *SearchedCustomerId+$
 OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=��� 5i   
   $��2��6   $��1��5j      $	��100��5k      $��
10,10,0,10q�5l      $��Center=�5m      $��Center=�5n      ��5o      �� *" SearchCustomerReservationCommand+.��6@   Search reservation5q        5s   
   $	��673��6   $	��300��5t       .  $ Column=�5v      $��3��5w      $��0��5x      $��2��6#   $ Disabled=�5y      $
 Auto=�5z      $
��Left=�5{      $	��Top=�5|      ��5}      �� *SearchCustomerReservationList+	 5~      �� *SelectedReservation+$
 OneWayToSource=� 5�        5�      $ 70 6%   $ ID��5�       5�      �� *
Owner.Id+5�        5�      $	 100 6%   $ 
First Name��5�       5�      �� *Owner.FirstName+5�        5�      $	 100 6%   $ 	Last Name��5�       5�      �� *Owner.LastName+5�        5�      $ 70 6%   $ Persons��5�       5�      �� *NumberOfPersons+5�        5�      $	 100 6%   $ Hotel��5�       5�      �� *
Hotel.Name+5�        5�      $	 100 6%   $ Location��5�       5�      �� *Hotel.Location.FullName+5�        5�      $ 65 6%   $ Check In��5�       5�      �� *ReservationPeriod.CheckIn+5�        5�      $ 65 6%   $ 	Check Out��5�       5�      �� *ReservationPeriod.CheckOut+5�      5�      5�      5�      