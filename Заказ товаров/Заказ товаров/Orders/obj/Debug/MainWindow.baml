   M S B A M L   `   `   `  ����A  =Orders, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:OrdersOrders  5   	       Orders.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Orders     5   	     � Title$  Заказы��5   	   $	��450��6   $	��800��6%   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   .+�5      �� -   5        $��Создать заказ��5      $	��130��6-   $��5q�69   6D   �� 5      -   5        $ ��Редактировать��5      $	��130��6-   $��5q�69   6D   �� 5      -   5        $��Удалить��5      $	��130��6'   $��5q�63   6>   �� 5      -   5        $!��Открыть отчеты��5      $	��150��6.   $��5q�6:   6E   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
OrdersGrid��5      $��1��6'      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�6b      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 6H   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Id+6H     5      $ Дата заказа��6%   $		 120 6w   
 6:   �� *	OrderDate+ �� StringFormat$ {0:dd.MM.yyyy}��6w     5      $ Клиент��6%   $	 * 6U   
 65   �� *Client.Name+6U     5      $ Всего позиций��6%   $		 100 6`   
 6<   �� *OrderItem.Count+6`   5      5      5      