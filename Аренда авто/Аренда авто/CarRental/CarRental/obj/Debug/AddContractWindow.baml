   M S B A M L   `   `   `  ����D  @CarRental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CarRental	CarRental  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   !    CarRental.AddContractWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CarRental     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  AddContractWindow��5	   	   $	��450��6#   $	��800��60   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0,0,0,10q�6   .+�5      �� $��Клиент:��6   �� 5      -   5         ��Name$ 	ClientBox��5       �� DisplayMemberPath$ FullName��6*   5      �� 5   
   $��1��6   $��0,0,0,10q�6"   .+�5      �� $��ТС:��6   �� 5      -   5        $ 
VehicleBox��5      $ Model��6+   5      �� 5   
   $��2��6   $��0,0,0,10q�6"   .+�5      �� $��Дата начала:��6   (  "System.Windows.Controls.DatePicker  5       -   5          Name$ StartDatePicker��5       
 �� Now   SelectedDate# Z 62   5!      �� 5#   
   $��3��6   $��0,0,0,10q�6"   .+�5$      �� $"��Дата окончания:��6     5%      -   5        $ EndDatePicker��5%      5&      �� 5(   
   $��4��6   $��0,0,0,10q�6"   .+�5)      �� $��Цена в сутки:��6   �� 5*      -   5         ��Name$ PriceBox��5*      5+      �� 5-   
   $��5��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5.      �� -   5        $��Сохранить��5.      $��5q�6)   $	��100��64   6@   �� 5/      -   5        $��Отмена��5/      $��5q�6&   $	��100��61   6=   50      51      52      