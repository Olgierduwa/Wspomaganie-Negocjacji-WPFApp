   M S B A M L   `   `   `  ����I  ENegocjator4200, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:negocjacja.Stronynegocjacja.Strony  5      *    $negocjacja.Strony.UzupelnienieDanych   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:negocjacja.Strony     5        N� FontSize$  26(�5   1    N� Title$ UzupelnienieDanych��5	       � 	Resources 5      7   1negocjacja.Strony.NameToSliderVisibilityConverter   WidzialnoscSlideraKwestii   NazwaSzukana  WidzialnoscSlideraOpcji��%d   &	        &	 )       5   
   $ Nowa kwestia...��6R     5   
   $ Nowa opcja...��6P   5      .��5      ]� .+�5   
   � $��Bottom=�6   $��Right=�6'    � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� -   5        $��Zaspis��5   6   
���P��$��20(�6(   $��	0,0,20,20q�6S   $	��100��6f   $��0��6r   $��ZAPISZ��6�    � ToolTip$> 8Zapisz aktualny stan Kwestii i Opcji do pliku tekstowego��5   j   6m   �� 5      -   5        $��Odczyt��5   6   
���P��$��20(�6(   $��	0,0,20,20q�6T   $	��100��6g   $��1��6s   $��WCZYTAJ��6�   $G AWczytaj plik tekstowy z zapisanymi wcześniej Kwestiami i Opcjami��5   r   5      �� 5       -   5        $��SuwakiSkala��5    6   
���P��$��20(�6(   $��	0,0,20,20q�6\   $	��100��6o   $��2��6{   $��	SKALA: 10��6�   $> 8Zmień skalę na suwakach na 10-cio lub 20-to stopniową��5!   g   5"      �� 5#      -   5        $��SuwakiButton��5#   6   
���P��$��20(�6(   $��	0,0,20,20q�6^   $	��100��6q   $��3��6}   $��SUWAKI��6�   $G AUstaw domyślne wartości suwaków dla wszystkich Kwestii i Opcji��5$   p   5%      �� 5&      -   5        $��WyczyscButton��5&   6   
���P��$��20(�6(   $��	0,0,20,20q�6b   $	��100��6u   $��4��6�   $��	WYCZYŚĆ��6�   $* $Wyczyść wszystkie wprowadzone dane��5'   T   5(      �� 5)      -   5        $��SprawdzButton��5)   6   
���P��$��20(�6(   $��	0,0,20,20q�6e   $	��100��6x   {�.  $��5��6�   $��SPRAWDZ��6�   $0 *Sprawdź poprawność wprowadzonych danych��5*   Y   5+      �� 5,      -   5        $��DalejButton��5,   6   
���P��$��20(�6(   $��	0,0,20,20q�6d   $	��100��6w   {�.  $��6��6�   $��DALEJ��6�   $ Przejdź do negocjacji��5-   G   5.      50      � 51   
   $	��Top=�6   $��20q�6$    � DataContext 60   ��  �� ElementName$ Kwestie�� �� Path$ SelectedItem� 52      �� 53      $��* �6#   �� 54      $��20 �6#   �� 55      $��* �6#   	 � RowDefinitions	 57      �� 58      $
��auto �6    �� 59      $
��auto �6    �� 5:      $��20 �6    �� 5;      �� 5<      $
��auto �6    .+�5?      �� $$��KWESTIE ISTOTNE W NEGOCJACJACH��6   $��Center=�6=   $��0,0,0,20q�6Z   �� 5@      -   5        $��
OpcjeLabel��5@   u   $��OPCJE DLA DANEJ KWESTII��6   $��2��66   $��Center=�6F   $��0,0,0,20q�6c   $y�Hidden=�6�   �� 5B      -	   5        $��KwestieLista��5B   #   $��3��6   $	��Top=�67   $��Stretch=�6O   $y�Hidden=�6t   ��5C      �� 5D      
 �� 
TargetType"
 ��6    �� Triggers 5E      P� 5F       P� Property �@��
IsSelected P� Value . . �5G   "   ��  �� Property � �� �� Value$
 Bold"�6?   5H      5J      ��5L      �� 5M      .R�5N      �  5O      �� 5P   "   $��3* �63   �� 5Q   "   $��2* �63   .+�5T      �� -
   5        
���P��
 � Tag 5U   &   �� $ ID���6>   �� $ Nazwa���6Z   �� $ Kolor�.��6|   $, &Edytuj wybraną Kwestię negocjacyjną��5V   g   .��5W      �� 5X      -   5        $��1��5X   %   
���   �
���P�� � Maximum$	 100Q�6[    �� TickPlacement$ BottomRight=�6�    �� IsSnapToTickEnabled . $��8q�5Y   @    �� TickFrequency 5X   i   �� $ Skala�y�5Z   %   �� $ Nazwa� �� 	Converter# [   6}   �� $ ID� � Value 6�   �� $
 Waga�$? 9Zmień ważność wybranej Kwestii względem pozostałych��5[   w   5\      5]      5_      �� 5`      -   5        $��NowaKwestiaTextBox��5`   ;   $��1��6   $	��Top=�6#   
���iii�
���P��$��Nowa kwestia...��5a   w   .��6�   $( "Dodaj nową Kwestię negocjacyjną��5b   S   .��5c      �� 5e      -   5        $��
OpcjeLista��5e   p   $��3��6   $��2��6#   $	��Top=�63   $��Stretch=�6K   $y�Hidden=�6�   ��5f      �� 5g      "
 ��6    5h      P� 5i       �@��
IsSelected . . �5j   "   ��  � ��$
 Bold"�6?   5k      5m      ��5o      �� 5p      .R�5q      �  5r      �� 5s   "   $��3* �63   �� 5t   "   $��2* �63   .+�5w      �� -   5        
���P�� 5w   Z   �� $ ID���6r   �� $ Nazwa�.��6�   $* $Edytuj wybraną Opcję negocjacyjną��5x   g   �� 5y      -   5        $��1��5y   %   
���   �
���P��$	 100Q�6[   $ BottomRight=�6�    . $��8q�5z   @    5y   i   �� $ Skala�y�5{   %   �� $ Nazwa�# [  6{   �� $ ID� 6�   �� $
 Waga�$= 7Zmień ważność wybranej Opcji względem pozostałych��5|   s   5}      5~      5      5�      �� 5�      -   5        $��NowaOpcjaTextBox��5�   K   $��1��6   $��2��6#   $	��Top=�63   
���iii�
���P��$y�Hidden=�6�   $��Nowa opcja...��5�   q   .��6�   $&  Dodaj nową Opcję negocjacyjną��5�   S   5�      5�      5�      