   M S B A M L   `   `   `  ����I  ENegocjator4200, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:negocjacja.Stronynegocjacja.Strony  5      '    !negocjacja.Strony.SuperNegocjacje   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:negocjacja.Strony     5        N� FontSize$  26(�5   1    N� Title$ SuperNegocjacje��5	      .��5      ]� .+�5   
   � $��Bottom=�6   $��Right=�6'    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� -   5        
���P��$��20(�5   (   $��	0,0,20,20q�6G   $	��200��6Z   {�. $��WRÓĆ��6w    � ToolTip$, &Powróć do ustawiania Kwestii i Opcji��5   V   5      �� 5      -   5        
���P��$��20(�5   (   $��	0,0,20,20q�6J   $	��200��6]   {�. $��1��6z   $��ZESTAW��6�   $@ :Utwórz zestawienie wszystkich możliwych kombinacji Opcji��5   l   5      � 5   
   $	��Top=�6   $��20,20,20,20q�6$    5      �� 5      $��* �6#   �� 5      $��20 �6#   �� 5      $��8* �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5       $
��auto �6    �� 5!      $��20 �6    �� 5"      �� 5#      $
��auto �6    .+�5&      �� $Q��KDOSTOSUJ OPCJE ODPOWIEDNICH KWESTII DO POTRZEB SWOICH ORAZ SWOJEGO OPONENTA��6   $��Center=�6j   $��0,0,0,20q�6�   $��3��6�   �� 5'      -   5        $��lista��5'   D   $��2��6   $��3��6&   $��1��67   $	��Top=�6Q   $��Stretch=�6i   $
��Left=�5(       � DataContext 61   ��  �� ElementName$ Wyniki�� �� Path$ SelectedItem���5)      �� 5*      .R�5+      ��  �� Orientation$ 
Horizontal=�6%   5,      5-      ��50      �� 51      .R�52      �� .+�53      �� 
	 � Tag	 6$   �� $ ID���6<   �� $ Nazwa��� 54      -   5        
 �� SelectedIndex$
 0��54   c   
���P��	 6'   �� $ ID���6?   �� $ Opcje.�$&  Wybierz Opcję dla danej Kwestii��55   e   56      57      58      5:      �� 5<      $��1��6   $��SUMA PKT��6"   $��Center=�65   $��24(�6R   $��0,10,0,5q�6`   �� 5=      -   5        $��oplacalnosc��5=   P   $��2��6   $	��Top=�6#   $	��Top=�68   
���P��.��6v   $A ;Wartość punktowa opłacalności wybranej kombinacji Opcji��5>   k   .��5?      �� 5A      $��4��6   .+�5B      �� $��OKREŚL CEL:��6   $��24(�6.   $��Center=�6<   �� 5C      -   5        
���   �
���P�� � Maximum$	 100Q�5C   ?   $	��Top=�6M   $��40��6e    �� TickFrequency$ 10Q�5D       �� TickPlacement$ BottomRight=�6(    �� IsSnapToTickEnabled . $K EUstaw oczekiwany poziom opłacalności proponowanych kombinacji Opcji��5E   {   �� 5F      $��
WYŚWIETL:��6   $��24(�6,   $��Center=�6:   $��0,20,0,0q�6W   �� 5G      -   5        
���   �
���P��$ 10Q�5G   ?   $	��Top=�6L   $��40��6d    � Value$ 8Q�6p   $ 1Q�5H      $ BottomRight=�6'    . $A ;Ustaw ilość wyświetlanych proponowanych kombinacji Opcji��5I   n   5J      �� 5K      -   5        
���   �
�������$��Autor��5K   C   $��0,60,0,0q�6S   $��16(�6e   $��9q�6s   6�   5L      ]� 5N      $��2��6   $��2��6(   $��4��69   .+�5O      &   System.Windows.Controls.DataGrid  -	   5        $��datagrid��5O         AutoGenerateColumns . $	��Top=�6C   $��Stretch=�6[   $
��Left=�6�      
IsReadOnly . 6�   5P      5R      5S      5T      