   M S B A M L   `   `   `  ����G  CArenaMasters, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ArenaMastersArenaMasters  5   	       ArenaMasters.MoneyDungeon   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ArenaMasters     5   	   -   5          � Title$  MoneyDungeon��5   	   $	��775��6   $
��1375��6+   $
|�True��68    � 
ResizeMode$ NoResize=�5	   	    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /recursos/Estilos.xaml?�6%   %    5      ��5      �� 5   
   -   5        backgroundImage�� �� ImageSource$ /images/map1.png��5   .   .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��40��6.   $	��Top=�6:   .+�5      �� -   5           miBoton#��[  5      $��20,0,0,0q�66   ���	#00000000���	#00000000���	#00000000.��5      �� $��/images/back.png��6   5      5      �� 5   
   -   5         ��Name$ CautionMessage��5      $ Vertical=�6-   $y�	Collapsed=�6D   
�������$	��286��6r   $	��Top=�6   $��374,186,408,0q�6�    K� ZIndex$ 1��6�   .+�5      �� $��¡¡¡Atención!!!��6   
���  ��$��Center=�6?   $��40(�6\   $
��Wrap=�6j   6�   �� 5      $����Si elige salir de la partida en su estado actual no se guardaran las recompensas obtenidad y se perderá el dinero de la entrada��6   $
��Wrap=�6�   $��22(�6�   $��10,10,10,10q�6�   �� 5      $#��¿Quiere salir de la partida?��6   $
��Wrap=�6=   $��22(�6Q   $��Center=�6_   �� 5      $ 
Horizontal=�6   $��	30,0,10,0q�62   $��73��6E   $	��372��6Q   .+�5       �� -   5        $��Salir��5        	 btnNo#��[ 6)   $��20(�6H   $��	10,0,30,0q�6V   $��72��6i   $	��153��6u   6�   �� 5!      -   5        $��Seguir Jugando��5!       	 btnSi#��[ 62   $��20(�6Q   $��69��6_   $	��170��6k   6w   5"      5#      �� 5$   
   -   5        	 ��Name$	 container_pj��5$      .+�5%      �� -   5        
 ��Name$
 listBoxUnits��5%      $	��150��6,   $	��275��69   $��0,50,0,0q�6E    �� SelectionMode$ Single=�6}   ���	#66FFFFFF$��Center=�6�   ��6W   �� *UnitsSelected+��5&      �� 5'      .R�5(      �� $ 
Horizontal=�6%   $	��260��6>   .+�5)      �� $��22(�6B   $	��100��6P   ��6(   �� *
UnitName+6P   � 5*       � Minimum$ 0Q�6*   $	��150��6e   $��30��6q   
��� � �$��10,0,0,0q�6�     CustomProgressBarStyle#��[ 6�    � Maximum 66   �� *MaxHp+ � Value 6P   �� *Hp+6�   5+      5,      5.      50      51      53      