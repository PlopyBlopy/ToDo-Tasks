   M S B A M L   `   `   `  ���� C  ?ToDoTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ToDoTask.ModelsToDoTask.Models  9!clr-namespace:ToDoTask.ViewModelsToDoTask.ViewModels  &     ToDoTask.View.Windows.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /modelclr-namespace:ToDoTask.Models     0vm!clr-namespace:ToDoTask.ViewModels       � Title$  
MainWindow��$	��550��$	��500��
������� � 	Resources &   ToDoTask.ViewModels.OpenWindowVM   
OpenWindow �� MergedDictionaries �� Source��  �� $" /Resources/ButtonStyles.xaml?�%   &	          .���  � RowDefinitions �� $��50 ��� $��* � � ColumnDefinitions �� $
��auto ��� $��* �.+�� $��0��$��0��
�������.+��� $
��Left=� �� Orientation$ 
Horizontal=�.+��� $��80��$��20��$��5q�$��Center=�$��search���� $��35��$��25��$��5q�$��Filter��  HoverEffectButtonStyle#��[ � $��0��$��1��
�������.+��� $
��Left=�$ 
Horizontal=�.+��� $��60��$��30��$   ToDoTask.Models.WindowRegistry   CreateTaskWindow#��Z $��Add Task��#��[ ����  �� Source# [  	 �� Path$	 OpenWindowCommand��� $��70��$��30��
   CreateCategoryWindow#��Z
 $��Add Category��#��[ ���� # [  $	 OpenWindowCommand�� $��1��$��0�����#f0f0f0.+��� $��70��$
��Left=�$ Vertical=�.+��� $��50��$��30��'   !ToDoTask.Models.WindowSubRegistry   TaskSubWindow#��Z $��Tasks��#��[ ���� # [  $	 OpenWindowCommand��� $��50��$��30��   MyDaySubWindow#��Z $��My day��#��[ ���� # [  $	 OpenWindowCommand��� $��50��$��30��   StatisticSubWindow#��Z $��	Statistic��#��[ ���� # [  $	 OpenWindowCommand��� $��50��$��30��   SettingsSubWindow#��Z $��Setting��#��[ ���� # [  $	 OpenWindowCommand��� $��50��$��30��   AboutAppSubWindow#��Z $��About��#��[ ���� # [  $	 OpenWindowCommand��� $��60��$��20������ *	UserInput+ �� UpdateSourceTrigger$ PropertyChanged=��� $��60��$��20��$��0,10,0,0q�
���   �
����������� *	UserInput+� $��1��$��1��.+��� -    ��Name$ ContentControl_SubWindow��