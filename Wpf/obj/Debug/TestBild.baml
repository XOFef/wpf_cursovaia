   M S B A M L   `   `   `  ����>  :Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfWpf  5   	       Wpf.TestBild   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Wpf     5   	   #��Z��5   	   #��Z��5	   	     � Title$!  Создание теста��5
   	    � WindowState$ 	Maximized=�6#    � Icon$ /Keqing.jpg��6;   .��5      � .+�5   
   �� -   5         ��Name$ UpPannel��5      ���	#FF8AD4C7$	��200��6>   $	��Top=�6K   .+�5      �� $	��150��6   $	��400��6"   $��Center=�6.   $
��Left=�6I   $��
30,25,0,25q�6e   $
��Fill=�6y   $��/1.jpg��6�   5      �� 5   
   $	��541��6   $��	55,55,0,0q�6    $��86��63   $	��Top=�6?   $!��Создание теста��6W   $��72(�6m   $
��Bold"�6{   �� 5   
   -   5           GlassButton#��[  5      $��Right=�66   $	��Top=�6R   $	��100��6j   $	��100��6v   $��
0,50,30,50q�6�    � Cursor$
 Hand��6�   ��5      �� 5       �� ImageSource$ /img_508630.png��6   5      � 5   
   $	��Top=�6   $	��864��6'   $��	0,200,0,0q�64   .+�5      �� $��Right=�6   .��5      � .+�5      �� $	��200��6   $
��1920��6*   $
��Left=�67   $	��Top=�6R   
���   �$��2q�6   $��0,38,0,0q�6�   ._�5      � $
��1920��6   $	��200��6,   .+�5      ��  �� TextAlignment$ Center=�6(   $$��Шаг 1: Вступление��6@   $��Center=�6Y   $��0,50,0,0q�6v   $	��Top=�6�   $	��446��6�   $��60��6�   $��30(�6�    J� RenderTransformOrigin$ 0.412,0.592&�6�   $
��Bold"�6�   �� 5      $ Center=�6(   $���{ Заголовок, описание и картинка. Ненужные элементы можно отключить.��6@   $��Center=�6�   $��0,90,0,0q�6�   $	��Top=�6�   $
��1124��6�   $��60��6�   $��30(�6�   $ 0.412,0.592&�6�   $
��Bold"�6  5      5      � 5      $	��915��6   $
��1800��6(   $	��Top=�65   $��	0,280,0,0q�6M   ���#8AD4C7.+�5       �� $ Center=�6$   $��Заголовок��6<   $
��Left=�6M   $��	50,22,0,0q�6h   $	��Top=�6{   $	��158��6�   $��60��6�   $��30(�6�   $ 0.412,0.592&�6�   $
��Bold"�6�   �� 5!      -   5         ��Name$
 Name��5!   "   $
��1700��60   $��
50,75,50,0q�6=   $��81��6Q   $	��Top=�6]   
���   �$��3q�6�   $��36(�6�   �� 5"      -   5        	 ��Name$	 myCheckBoxTwo��5"   #   $!��Описание теста��6:   
���   �$
��Left=�6g   $��
50,179,0,0q�6�   $	��Top=�6�   $��19��6�   $	��109��6�   
 � LayoutTransform
 5#      �� 5$   "    �� ScaleX$ 3Q�61    �� ScaleY$ 3Q�6<   5&      �� 5'      -   5        $ TextBox��5'   "   {�.   �� TextWrapping$
 Wrap=�6E    �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�6n   $
��1700��6�   $��50,240,50,0q�6�   $	��236��6�   $	��Top=�6�   
���   �$��3q�6�   $��24(�6   �� 5(      -   5        $	 
myCheckBox��5(   #   $��Фотография��67   
���   �$
��Left=�6`   $��
50,505,0,0q�6{   $	��Top=�6�   $��19��6�   $	��109��6�   
 5)      �� 5*   "   $ 3Q�61   $ 3Q�6<   5,      �� 5-      -   5         ��Name$ buttonImage��5-   !   {�.  $	��400��6H   $	��100��6T   $
��Left=�6a   $��
50,345,0,0q�6|   $+��%Выбрать изображение��6�   
�������$��3q�6�   
���   �$��22(�6�   6�   �� 5.      -   5         ��Name$ imageControl��5.       $y�	Collapsed=�66   $	��200��6M   $	��200��6Y   $
��Left=�6f   $��
50,685,0,0q�6�   5/      � 51      $��
0,1225,0,0q�6   .+�52      �� -	   5        $	��100��52   !   $	��355��6.   $��	50,0,0,70q�6:   $��Bottom=�6M   ���	#FF8AD4C7
���   �$��2q�6�   $��Отмена��6�   $��36(�6�   $
��Bold"�6�   $
��Left=�6�   6�   �� 53      -
   5        $	��100��53   !   $��	0,0,50,70q�6.   $��Bottom=�6A   ���	#FF8AD4C7
���   �$��2q�6�   $��
Далее��6�   $��36(�6�   $
��Bold"�6�   $��Right=�6�   $	��355��6�   6�   54      55      56      57      58      59      