   M S B A M L   `   `   `  ����  MedicalExaminationApp(    "MedicalExaminationApp.ReportWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Отчеты��5   	   $	��450��6   $	��800��6%   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� -   5         ��Name$ 
ReportType��5      $��0��6'   $��0 0 0 10q�64   .@�5      �� $%��Прошедшие осмотр��6   �� 5      $��Не явившиеся��6   5      �� 5   
   -   5         ��Name$ 	DatePanel��5      $��1��6(    �� Orientation$ 
Horizontal=�65   .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ 	StartDate��5      $��0 0 10 0q�6,   $	��120��6>     5      -   5        $ EndDate��5      $��0 0 10 0q�6*   $	��120��6<   �� 5      -   5        $��Сформировать��5      $��5q�6I   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
ReportGrid��5      $��2��6'      AutoGenerateColumns . 64    � 	Resources 5   
   	 �� 
TargetType   ReportPanelStyle
 �� Triggers �� Binding �� ElementName �� Path �� Value �� Property �� Value��%�   &	        �� 5      "	 ��6   
 5      �� 5       6"   �� $ 
ReportType��$ SelectedIndex� 16a   .a�5      ��  � y�$ 	Collapsed=�67   5      5!      5"      5#      5$      