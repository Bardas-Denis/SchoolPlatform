   M S B A M L   `   `   `  ����I  ESchoolPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SchoolPlatformSchoolPlatform  5   	       SchoolPlatform.AddClass   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SchoolPlatform     5   	     � Title$  AddClass��5   	   $	��450��6   $	��340��6'   .��5	      �  � RowDefinitions 5
   
   �� 5      $��5* �6   6*   �� 5      $��* �6   6)   .+�5   
   � $��0��6    5      �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   .+�5      �� -   5         ��Name$ FirstNameTextBox��5   [   $��0��6   $
��Left=�6%   $��Center=�6@   $��30��6u   $	��300��6�   $��10q�6�   $��20(�6�   �� 5      -   5         ��Name$ Placeholder��5       J� IsHitTestVisible$ False��6-   $/��)Enter the first name of the class master ��6F   $��Center=�6w   $
��Left=�6�   $��12,0,0,0q�6�   $��16(�6�   
���������5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � y� �� Value$ 	Collapsed=�67    �� Triggers 5      �� 5      	 �� Binding	 6*   �� *Text+
 �� ElementName$
 FirstNameTextBox�� �� Value  6a   .a�5   "   ��  � y�$ Visible=�6?   5      5      5!      �� 5"      -   5        $ LastNameTextBox��5"   [   $��1��6   $
��Left=�6%   $��Center=�6@   $��30��6t   $	��300��6�   $��10q�6�   $��20(�6�   �� 5#      -   5        $ Placeholder1��5#   %   $��1��6   $ False��6;   $-��'Enter the last name of the class master��6T   $��Center=�6�   $
��Left=�6�   $��12,0,0,0q�6�   $��16(�6�   
���������5$      �� 5%      " ��6   .�5&      ��  � y�$ 	Collapsed=�67    5'      �� 5(      	 6*   �� *Text+$
 LastNameTextBox��  6`   .a�5)   "   ��  � y�$ Visible=�6?   5*      5,      5.      �� 5/      -   5        $ SpecializationTextBox��5/   [   $��2��6   $
��Left=�6%   $��Center=�6@   $��30��6z   $	��300��6�   $��10q�6�   $��20(�6�   �� 50      $��2��6   $ False��6&   $��Enter the specialization ��6?   $��Center=�6`   $
��Left=�6{   $��12,0,0,0q�6�   $��16(�6�   
���������51      �� 52      " ��6   .�53      ��  � y�$ 	Collapsed=�67    54      �� 55      	 6*   �� *Text+$
 SpecializationTextBox��  6f   .a�56   "   ��  � y�$ Visible=�6?   57      59      5;      �� 5<      -   5        $ GradeLevelTextBox��5<   [   $��3��6   $
��Left=�6%   $��Center=�6@   $��30��6v   $	��300��6�   $��10q�6�   $��20(�6�   �� 5=      $��3��6   $ False��6&   $��Enter the grade level��6?   $��Center=�6\   $
��Left=�6w   $��12,0,0,0q�6�   $��16(�6�   
���������5>      �� 5?      " ��6   .�5@      ��  � y�$ 	Collapsed=�67    5A      �� 5B      	 6*   �� *Text+$
 GradeLevelTextBox��  6b   .a�5C   "   ��  � y�$ Visible=�6?   5D      5F      5H      5J      �� 5K   
   -   5        $��1��5K      $��50��6   $��20��6)   $	��ADD��65   $��5q�6C   6f   5L      5M      