   M S B A M L   `   `   `  ����A  =Orders, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:OrdersOrders  5   	       Orders.NewOrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Orders     5   	     � Title$  Новый заказ��5   	   $	��500��6   $	��700��6*   .��5	      �� $��10q�6   .+�5
   
   �� $��Клиент��6   �� 5   
   -   5         ��Name$ 
CmbClients��5       �� DisplayMemberPath$
 Name��6'   $��25��6@   �� 5   
   $��
Товар��6   �� 5   
   -   5        $ CmbProducts��5      $
 Name��6(   $��25��6A   �� 5   
    �� Orientation$ 
Horizontal=�6   $	��0,5q�6.   .+�5      �� -   5         ��Name$ TxtQuantity��5      $��60��6+   $��5q�66   $��Кол-во��6A   �� 5      -   5        $ TxtPrice��5      $��80��6(   $��5q�63   $��Цена��6>   �� 5      -   5        $��Добавить��5      $��5q�6>   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	ItemsGrid��5         AutoGenerateColumns .  $	��200��6B      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Товар��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 64   �� *Product.Name+  5      $ Кол-во��6%   	 65   �� *
Quantity+  5      $ Цена��6%   	 63   �� *	UnitPrice+5      �� 5   
   -   5        $#��Сохранить заказ��5      $
��0,10q�6C   5      5      