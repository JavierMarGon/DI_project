   M S B A M L   `   `   `  ���� G  CArenaMasters, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ArenaMastersArenaMasters      ArenaMasters.MoneyDungeon   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:ArenaMasters     -     � Title$  MoneyDungeon��$	��775��$
��1375��$
|�True�� � 
ResizeMode$ NoResize=� � 	Resources  �� MergedDictionaries �� Source��  �� $ /recursos/Estilos.xaml?�%    ���� -   backgroundImage�� �� ImageSource$ /images/map1.png��.��� .+���  �� Orientation$ 
Horizontal=�$��40��$	��Top=�.+��� -      miBoton#��[  $��20,0,0,0q����	#00000000���	#00000000���	#00000000.���� $��/images/back.png���� -    ��Name$ CautionMessage��$ Vertical=�$y�	Collapsed=�
�������$	��286��$	��Top=�$��374,186,408,0q� K� ZIndex$ 1��.+��� $��¡¡¡Atención!!!��
���  ��$��Center=�$��40(�$
��Wrap=��� $����Si elige salir de la partida en su estado actual no se guardaran las recompensas obtenidad y se perderá el dinero de la entrada��$
��Wrap=�$��22(�$��10,10,10,10q��� $#��¿Quiere salir de la partida?��$
��Wrap=�$��22(�$��Center=��� $ 
Horizontal=�$��	30,0,10,0q�$��73��$	��372��.+��� -   $��Salir�� 	 btnNo#��[ $��20(�$��	10,0,30,0q�$��72��$	��153���� -   $��Seguir Jugando�� 	 btnSi#��[ $��20(�$��69��$	��170���� -   	 ��Name$	 container_pj��.+��� -   
 ��Name$
 listBoxUnits��$	��150��$	��275��$��0,50,0,0q� �� SelectionMode$ Single=����	#66FFFFFF$��Center=����� *UnitsSelected+���� .R��� $ 
Horizontal=�$	��260��.+��� $��22(�$	��100������ *
UnitName+�  � Minimum$ 0Q�$	��150��$��30��
��� � �$��10,0,0,0q�  CustomProgressBarStyle#��[  � Maximum �� *MaxHp+ � Value �� *Hp+