   M S B A M L   `   `   `  ����I  ESchoolPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SchoolPlatformSchoolPlatform  5   	       SchoolPlatform.AddSubject   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SchoolPlatform     5   	     � Title$  
AddSubject��5   	   $	��450��6   $	��340��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $��5* �6   6*   �� 5      $��* �6   6)   .+�5   
   � $��0��6    5      �� 5      $��* �6    6-   .+�5      �� -   5         ��Name$ SubjectNameTextBox��5   [   $��0��6   $
��Left=�6%   $��Center=�6@   $��30��6w   $	��300��6�   $��10q�6�   $��20(�6�   �� 5      -   5         ��Name$ Placeholder��5       J� IsHitTestVisible$ False��6-   $��Enter the subject name ��6F   $��Center=�6e   $
��Left=�6�   $��12,0,0,0q�6�   $��16(�6�   
���������5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � y� �� Value$ 	Collapsed=�67    �� Triggers 5      �� 5      	 �� Binding	 6*   �� *Text+
 �� ElementName$
 SubjectNameTextBox�� �� Value  6c   .a�5   "   ��  � y�$ Visible=�6?   5      5      5      5       �� 5!   
   -   5        $��1��5!      $��50��6   $��20��6)   $	��ADD��65   $��5q�6C   6f   5"      5#      