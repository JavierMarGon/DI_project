   M S B A M L   `   `   `  ���� G  CArenaMasters, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ArenaMastersArenaMasters      ArenaMasters.Fight   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:ArenaMasters       � Title$  Fight��$	��588��$
��1000�� � WindowState$ 	Maximized=� � 
ResizeMode$ NoResize=� � 	Resources  �� MergedDictionaries �� Source��  �� $ /recursos/Estilos.xaml?�%    ���� -   backgroundImage�� �� ImageSource$ /images/MapPhase1.jpg��.��� .+�� -   $��	gridFight��$y�Visible=� � RowDefinitions �� $��* ��� $��* �.+��� -    ��Name$ spEnemy��$��	0,170,0,0q�$��1��$��Center=�.+��  �� $��* ��� $��* �.+�� $��1��.+��� $��Center=����� *
CPUUnits+���� .R��� 	 �� Orientation$	 
Horizontal=����� .R��� $	 Vertical=�.+��� $��otherUnitSelector��-   $��80��$��70��
������ 
������ $��0q�$��-4q�.���� $��70������ *ImageSource+�� 
�������$��Center=�$��Center=����� *Hp+� $	��150��$��15��
 � Minimum$
 0Q�$��20q� � Maximum �� *MaxHp+ � Value �� *Hp+�� -   $ spUnits��$	 
Horizontal=�$��Center=�$��	0,150,0,0q�$��1��.+�� $
��1400�� �� $��* � � ColumnDefinitions �� $	��320 ��� $��* �.+��� 
���   �$��2q����	#E55D4821$��Center=�$	��250��$	��320��._��� $��0��$	��250�����	#77564833$	 Vertical=�$��0,0,0,0q�.+��� -    ��Name$ phaseTxt��$��Phase ��$��25(�$��Center=����	#FFC1B5A7�� -   $ logFightTxt��$��Selecciona un ataque...��$��20(�$��Center=�$��Center=��� -   $ lastUserSkillUsed��$��20(�$��Center=�$��0,40,0,0q�
��� � �$��50���� -	   $ lastEnemySkillUsed��$��20(�$��Center=�$��0,20,0,0q�
���  ���� $��1��$��Center=����� *PlayerUnits+���� .R��� $	 
Horizontal=����� .R��� $	 Vertical=�.+��� $��selfUnitSelector��-
   $��80��$��70��
������ 
������ $��0q�$��-4q�.���� $��70������ *ImageSource+�� 
�������$��Center=�$��Center=����� *Hp+� $	��150��$��15��$
 0Q�$��20q� �� *MaxHp+ �� *Hp+�� -   $ spSkillsFight��$	��500��$	��850��$y�	Collapsed=�$��2��.+�� ���	#CCEDDC9E$	��200��$	��290��$��255,117,255,117q� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+�� $��Center=� �� $
��Auto ��� $	��71* ��� $
��192* ��� $
��Auto �.+��� -      btnSalirAtk#��[  $��5,0,0,0q�$��0��$��salir��$
��Left=��� $��Center=�$��20(�$
��Left=�$��2��$��10,0,0,0q��� $�Unidad �� �� -    ��Name$ unitNameAtk���� -   $ spAtk1��$��1��$��Center=�.+��� $	��280��$	 
Horizontal=�$��Center=�$��Center=�.+��� -   $��btnAtk1�� � ToolTip$ 	asjhdfbas��$��	sdkfjgsbd��$��20(�$	��120��
������ 
������ $��0q��� -   $ 
typeSkill1��$
��Tipo��$��70��$��20(��� -   $ targetRange1��$��Rango��$��20(��� -   $ spAtk2��$��2��$��Center=�.+��� $	��280��$	 
Horizontal=�$��Center=�$��Center=�.+��� -   $��btnAtk2��$��	sdkfjgsbd��$��20(�$	��120��
������ 
������ $��0q��� -   $ 
typeSkill2��$
��Tipo��$��70��$��20(��� -   $ targetRange2��$��Rango��$��20(��� -   $ spAtk3��$��3��$��Center=�.+��� $	��280��$	 
Horizontal=�$��Center=�$��Center=�.+��� -   $��btnAtk3��$��	sdkfjgsbd��$��20(�$	��120��
������ 
������ $��0q��� -   $ 
typeSkill3��$
��Tipo��$��70��$��20(��� -   $ targetRange3��$��Rango��$��20(��� -   $ spAtk4��$��4��$��Center=�.+��� $	��280��$	 
Horizontal=�$��Center=�$��Center=�.+��� -   $��btnAtk4��$��	sdkfjgsbd��$��20(�$	��120��
������ 
������ $��0q��� -   $ 
typeSkill4��$
��Tipo��$��70��$��20(��� -   $ targetRange4��$��rango��$��20(�