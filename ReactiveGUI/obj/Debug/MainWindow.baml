   M S B A M L   `   `   `  ����F  BReactiveGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ReactiveGUIReactiveGUI  5   	       ReactiveGUI.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ReactiveGUI     5   	     � Title$  User Details��5   	   $	��450��6   $	��800��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   �� 5      $��* �6   6+   .+�5   
   �� -   5        $��lblUserName��5      $��0��6#   $��0��60   $��Search By UserName : ��6@   $��5q�6`   6m   �� 5   
   -   5        $��txtUserName��5      $��0��6%   $��1��62   $��2��6B   $��5q�6V   6c   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgUserDetails��5      $��1��6)   $��3��66   $��5q�6J      AutoGenerateColumns . 5      5      5      