   M S B A M L   `   `   `  ���� G  CArenaMasters, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ArenaMastersArenaMasters      ArenaMasters.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:ArenaMasters       � Title$  
MainWindow�� � WindowState$ 	Maximized=�$	��775��$
��1375�� � 	Resources  �� MergedDictionaries �� Source��  �� $ /recursos/Estilos.xaml?�%    ����  �� ImageSource$ /images/inicio.png�� �� Opacity$
 0.25Q�.���  � ColumnDefinitions �� $��* ��� $
��0.5* � � RowDefinitions �� $��* ��� $��5* �.+��� $��Center=�.+��� $��ARENAMASTER��$��50(����	#FF907351$��SemiBold"�	 �� TextAlignment$	 Center=�� -   
 �Name$
 
menu_login��$y�Visible=�$��1��$��12�����	#66808080 �� $��* ��� $��* ��� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0��$��2�� �� Orientation$ 
Horizontal=�$��Bottom=�$��Center=�$��15q�.+��� $��35(�$��Regular"����	#FFD6BFBF$��Inicia Sesión��$��Center=��� $��1��$ 
Horizontal=�$��Center=�$��Center=�$��15q�.+��� $��20(�$��SemiBold"����	#FFD6BFBF$��Usuario��$��Center=�$��0,0,10,0q��� $��1��$��1��$ 
Horizontal=�$��Center=�$��Center=�$��0q�.+��� -    ��Name$ tb_user��$��25(�$	��200��$��Center=����	#4CFFFFFF$��0,0,10,0q�
��������� $��2��$ 
Horizontal=�$	��Top=�$��Center=�$��15q�.+��� $��20(�$��SemiBold"����	#FFD6BFBF$��Password��$��Center=�$��0,0,10,0q��� $��2��$��1��$ 
Horizontal=�$	��Top=�$��Center=�$��0q�.+�G� -    G�Name$ psw_user��$��25(�$	��200��$��Center=����	#4CFFFFFF$��	0,10,10,0q�
��������� $��3��$��2��$ Vertical=�$	��Top=�$��Center=�.+��� $ 
Horizontal=�.+��� -      btnRegister#��[  $��Register��$��20(�$��40��$	��100��$��5q�
��������� -     btnLogin#��[ $��Login��$��20(�$��40��$	��100��$��5q�
��������� -     btnMenuCerrarSesion#��[ $��Acceso Invitado��$��20(�$��34��$	��166��
�������� -   $
 menu_loadGames��$y�	Collapsed=�$��1��$��12�����	#66808080 �� $��4* ��� $��* �.+��� $��0��.���� -    ��Name$ sp_loadGames��$��10q�.+���   Plantilla_partidas#��[ ���� *
GameList+�� $��1��$��Center=�.+��� -	   #��[ $��Salir��$��20(�$��44��$	��156��
�������� -
   $
 	menu_user��$y�	Collapsed=�$��1��$��12�����	#66808080 �� $
��0.5* ��� $��0.75* ��� $��0.75* ��� $��* ��� $��* � �� $��* ��� $��* �.+��� $��1��$��2��$ 
Horizontal=�$��Center=�$��Center=�$��69��$	��274��.+��� -    ��Name$ btnContinue��  btnMenuUsuario#��[ $��	Continuar��$��20(�$��69��$	��274��
��������� $��2��$��2��$ 
Horizontal=�$��Center=�$��Center=�$��69��$	��274��.+��� -   #��[ $��Nueva Partida��$��20(�$��69��$	��274��
��������� $��3��$��2��$ 
Horizontal=�$��Center=�$��Center=�$��69��$	��274��.+��� -   $ btnLoadGame��#��[ $��Cargar Partida��$��20(�$��69��$	��274��
��������� $��4��$ 
Horizontal=�$	��Top=�$
��Left=�$��40��$	��189��$��30,0,0,0q�$��1��.+��� -   #��[ $��Cerrar sesion��$��20(�$��34��$	��136��
�������� -   $
 menu_register��$��1��$��2�����	#66808080$y�Hidden=�$��100,20,100,20q� �� $
��0.5* ��� $��* ��� $��* ��� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0��$��1��$	��Top=�$��Right=�$��0q�.+��� -     btnMenuCerrarVentana#��[ $��40(�$��X��$��70��$��70�����	#00000000�� $��1��$��0��$��Center=�$��Right=�$��20q�.+��� $��Usuario��$��25(����	#FFD6BFBF�� $��1��$��1��$��Center=�$
��Left=�$��20q�.+��� -   $ reg_username��$	��200��$��25(����	#4CFFFFFF�� $��2��$��0��$��Center=�$��Right=�$��20q�.+��� $��Password��$��25(����	#FFD6BFBF�� $��2��$��1��$��Center=�$
��Left=�$��20q�.+�G� -   $ reg_password��$	��200��$��25(����	#4CFFFFFF�� $��3��$��0��$��Center=�$��Right=�$��20q�.+��� $��Confirmar Password��$��25(����	#FFD6BFBF�� $��3��$��1��$��Center=�$
��Left=�$��20q�.+�G� -   $ reg_password_check��$	��200��$��25(����	#4CFFFFFF�� $��4��$��2��$	��Top=�$��Center=�$��10q�.+��� -     	btnCreate#��[ $	��200��$��60��$��Crear Cuenta��$��25(�
�������