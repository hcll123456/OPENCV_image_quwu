   M S B A M L   `   `   `  ����L  HWPFMediaPlayerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPFMediaPlayerAppWPFMediaPlayerApp  5   	   "    WPFMediaPlayerApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WPFMediaPlayerApp     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��560��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � -   5         �Name$ 
Media_grid��5   "   
���   �.+�5      r� -   5         r�Name$ MediaPlayer��5       r� LoadedBehavior$ Manual=�60   6n   � 5       � ColumnDefinitions 5      �� 5      $��3* �6'   �� 5      $��1* �6'   �� 5      $��3* �6'    5      �� 5      $��2* �6$   �� 5      $��2* �6$   �� 5      $��2* �6$   .+�5      �� -   5         ��Name$ image_Border��5      
���  ��$��1q�6B   $��1��6V   $��1��6c   5      5      � 5!   
   $��1��6    5"      �� 5#      $��* �6#   �� 5$      $
��Auto �6#   �� 5%      $��* �6#   .+�5'      �� $��1��6    �� Orientation$ 
Horizontal=�6)   .+�5(      �� -   5         ��Name$ 
ButtonOpen��5(      $��Open...��6F   $	��100��6X   $��25��6d   $��5q�6p   �� 5)      -   5        $ 
ButtonPlay��5)      $
��Play��6F   $	��100��6U   $��25��6a   $��5q�6m   �� 5*      -   5        $ 
ButtonStop��5*      $
��Stop��6F   $	��100��6U   $��25��6a   $��5q�6m   �� 5+      -   5        $ ButtonForward��5+      $��Forward��6L   $	��100��6^   $��25��6j   $��5q�6v   �� 5,      -   5        $ 
ButtonBack��5,      $
��Back��6F   $	��100��6U   $��25��6a   $��5q�6m   5-      5.      5/      50      