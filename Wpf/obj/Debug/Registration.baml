   M S B A M L   `   `   `  ����>  :Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfWpf  5   	       Wpf.Registration   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -uiusing:Microsoft.Toolkit.Uwp.UI     5   
   #localclr-namespace:Wpf     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ Вход��5
   	   $	��700��6   $	��600��6#    � WindowStyle$
 None=�6/   $��30(�6B    � Icon$ /Keqing.jpg��6P   .��5      � .+�5   
   �� .@�5      �� $��Вход��6   $	��600��6%   $��Center=�61   $
��Bold"�6N   ���	#FF1F4B43$��Center=�6w   ��5      �� 5       �� EndPoint$	 0,1&�6+   .��5      �  � Color$ 	#FFF0F0F0��6'   � 5      $ 	#FF8AD4C7��6'    � Offset$ 2Q�69   5      .��5      �  � ColumnDefinitions 5      �� 5      $
��133* �6+   �� 5      $	��65* �6+   .+�5      �� -   5        $��
Войти��5      $
��Left=�6.   $��	29,0,0,79q�6I   $	��200��6\   ���	#FF8AD4C7$��30(�6   $
��Bold"�6�   
�������$	��100��6�   $��Bottom=�6�   $��0q�6�   6�   �� 5      -   5        $��	0,0,30,99q�5      
�������$��0q�6C   $��20(�6W   $��60��6e   $	��200��6q   $��Bottom=�6}   $��Right=�6�   $��2��6�   .��5      �� ���	#FF1F4B43B� 5      .�6(   Забыли пароль?68   5      5       �� 5!      -   5         ��Name$ LoginOrEmail��5!      $��
0,190,30,0q�64   	 �� TextWrapping$
	 Wrap=�6H   $	��Top=�6\   $��50��6t   $��5q�6�   $��26(�6�   ���	#FF8AD4C7$��2��6�   $��Right=�6�   $	��535��6�   G� 5"      -   5        
 G�Name$
 password��5"   "   $��
0,0,30,278q�64   $��5q�6H   $��50��6\   $��Bottom=�6h   $��26(�6�   ���	#FF8AD4C7$��2��6�   $��Right=�6�   $	��535��6�   �� 5#      $
��Left=�6    $��
29,0,0,329q�6;   $
��Wrap=�6O   $��Пароль��6c   $��Bottom=�6q   $
��Bold"�6�   ���	#FF1F4B436�   �� 5$      $��29,148,75,0q�6    $
��Wrap=�65   $��Логин или email��6I   $
��Bold"�6`   ���	#FF1F4B43$��45��6�   $	��Top=�6�   5%      5&      5I      5K      5L      