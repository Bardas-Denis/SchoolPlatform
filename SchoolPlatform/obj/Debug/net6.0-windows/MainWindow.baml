   M S B A M L   `   `   `  ����I  ESchoolPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SchoolPlatformSchoolPlatform  5   	   E'clr-namespace:SchoolPlatform.ViewModelsSchoolPlatform.ViewModels  64   E'clr-namespace:SchoolPlatform.ConvertersSchoolPlatform.Converters  6k       SchoolPlatform.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SchoolPlatform     5   	   :local1'clr-namespace:SchoolPlatform.ViewModels     64   BlocalConverter'clr-namespace:SchoolPlatform.Converters     6k     � Title$  
MainWindow��5   	   $	��380��6   $	��300��6)    � DataContext 5	      ,  &SchoolPlatform.ViewModels.MainWindowVM  5
   
   .��5      �  � 	Resources 5   
   ,  &SchoolPlatform.Converters.LoginConvert   loginConvert��%   &	          5      6*   5       � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   .+�5   
   � $��0��6    5      �� 5      $��* �6    6-   �� 5      $��* �6    6-   .+�5      �� $��0��6   $��10q�6!   $��Bottom=�6-   .��6H   Email5      �� 5      -   5         ��Name$ EmailTextBox��5   W   $��1��6   $
��Left=�6$   $	��Top=�6?   $��30��6m   $	��200��6y   $��10q�6�   $��20(�6�   5      � 5    
   $��1��6    5!      �� 5"      $��* �6    6-   �� 5#      $��* �6    6-   .+�5%      �� $��0��6   $��10q�6!   $��Bottom=�6-   .��6H   
Password5'      �� 5(      -   5        $ PasswordTextBox��5(   W   $��1��6   $
��Left=�6$   $	��Top=�6?   $��30��6p   $	��200��6|   $��10q�6�   $��20(�6�   5)      �� 5*   
   -   5        $��
lblMessage��5*      $��2��6   $��30��6P   $��15(�6\   
���  ����6/   �� *ErrorMessage+6j   �� 5,   
   $��3��6   $
��Left=�6   $��10q�69   $��Login��6E   $	��150��6U   $��40��6a   ��6m   �� *VerifyLogin+��5-      `� 5.       `� 	Converter# [  6   .1�5/      ��  �� ElementName$ EmailTextBox��6    �� Path$
 Text�69   �� 50      $ PasswordTextBox��6   $
 Text�6<   51      53      54      55      