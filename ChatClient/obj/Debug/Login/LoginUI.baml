   M S B A M L   `   `   `  ����E  AChatClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ChatClient
ChatClient  5   	       ChatClient.Login.LoginUI   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ChatClient     5   	   -   5          � Title$  LoginUserData��5   	   $	��450��5
   	   $	��800��6    � Icon$ /Resources/ChatIcon.png��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $
��0.1* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��2* �6   .+�5   
   �� $��1��6   $��1��6"   $��3��62    �� Orientation$ 
Horizontal=�6F   .+�5      �� $��16(�6   $,��&Neu hier? Dann regestriere dich bitte ��6&   �� 5       -   5        $��16(�5       $
��Bold"�6&   $��	Underline{�68    � Cursor$
 Hand��6T   $
��hier��6b   6n   �� 5!      $��16(�6   $	��...��6&   5"      �� 5#   
   $��2��6   $��1��6   $��Center=�6-   $��16(�6H   .��6V   
Username6`   �� 5$   
   -   5         ��Name$ UserNameInput��5$      $��2��6)   $��2��66   $��2��6F   $��0q�6Z   $��30��6e   $��16(�6q   $��Center=�6   6�   �� 5%   
   $��3��6   $��1��6   $��16(�6-   $��Center=�6;   .��6V   
Password6`   G� 5&   
   -   5         G�Name$ PasswordInput��5&      $��3��6-   $��2��6:   $��2��6J   $��30��6^   $��16(�6j    G� PasswordChar$ *��6x   $��Center=�6�   6�   �� 5'   
   -   5        $��5��5'      $��3��6   $��16(�6.   $��Login��6T   6f   5(      5)      