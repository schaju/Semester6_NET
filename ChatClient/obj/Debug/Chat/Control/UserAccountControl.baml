   M S B A M L   `   `   `  ����E  AChatClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ChatClient.Chat.ControlChatClient.Chat.Control  5      @ <Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null,"clr-namespace:Model;assembly=ModelModel 5      ;"clr-namespace:ChatClient.ConverterChatClient.Converter  5      0    *ChatClient.Chat.Control.UserAccountControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:ChatClient.Chat.Control     5      4model"clr-namespace:Model;assembly=Model     5      8	converter"clr-namespace:ChatClient.Converter     5      .��5      ]� .+�5   
   � $
��Left=�6   .+�5      �� -   5          ��Name$  BorderColor��5      
��� ���$��2 5 5 5q�6>   $
��Auto��6�   ��6O   ��  �� ElementName$ BorderColor�� �� Path$ ActualHeight�6�   �� 5      $��6��6   $��6��6    �� CornerRadius$ 3��6*   $��Bottom=�6;   $��Right=�6V   $��0 0 5 5q�5   k   ��6   �� *UserAccountStatus+ �� 	Converter 0   *ChatClient.Converter.OnlineStatusConverter  6k   5      � 5   
   $	��Top=�6   .+�5      �  � Orientation$ 
Horizontal=�6   .+�5      �� $��14(�68   $
��Bold"�6F   ��6   �� *	FirstName+6F   �� 5      $�� ��6   �� 5      $��14(�67   $
��Bold"�6E   ��6   �� *
LastName+6E   �� 5      $�� (��6   �� 5      $��14(�67   $
��Bold"�6E   ��6   �� *
UserName+6E   �� 5      $��)��6   5      5      � 5   
   $��Bottom=�6   .+�5      � $ 
Horizontal=�6   .+�5      �� $��12(�6;   ��6   �� *StatusMessage+6;   5       5!      5"      5#      