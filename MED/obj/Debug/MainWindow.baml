   M S B A M L   `   `   `  ����>  :MED, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MEDMED  5   	       MED.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:MED     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��30 �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6.   $��25��6F   $��0,5,0,0q�6R   .+�5      �� -   5        $��Добавить��5      $	��100��6(   64   �� 5      -   5        $ ��Редактировать��5      $	��100��6-   $��10,0,0,0q�69   6K   �� 5      -   5        $��Удалить��5      $	��100��6'   $��10,0,0,0q�63   6E   �� 5      $1��+Поиск по подразделению:��6   $��Center=�66   �� 5      -   5         ��Name$ SearchTextBox��5      $	��200��6-   $��5,0,10,0q�69   �� 5      -   5        $��
Поиск��5      6%   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��	0,0,0,374q�6;   .+�5      �� $��id��6   $��61��6!   �� 5      -   5        $ LastNameBox��5      $��61��6+   �� 5      $��
Номер��6   $��61��6$   �� 5      -   5        $ FirstNameBox��5      $��90��6,   �� 5      $��Дата рождения��6   $��95��6,   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ ObsledDatePicker��5      $	��150��63   �� 5      $ ��Подразделение��6   $	��100��6,   �� 5      -	   5        $ DepartmentIdBox��5      $��61��6/   5!      &   System.Windows.Controls.DataGrid  5"   
   -
   5          Name$ SchedulesGrid��5"         AutoGenerateColumns .  $��2��6F   $��0,37,0,0q�6S      Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *schedule_id+  5%      $ 
Номер��6%   	 64   �� *schedule_number+  5&      $ Дата��6%   	 63   �� *obsled_date+
 �� StringFormat$
 
dd.MM.yyyy��  5'      $  Подразделение��6%   	 6<   �� *department_id+5)      5*      5+      