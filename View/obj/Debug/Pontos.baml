   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ViewView  5   	       View.Pontos   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:View     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  6N     � Title$  Pontos��5	   	   $	��600��6   $	��400��6%    � 
ResizeMode$ NoResize=�61    � WindowStartupLocation$ CenterScreen=�6G    � 	Resources 5
         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1	 �� 
TargetType
 �� 
TargetType ��Name �� CornerRadius J� RenderTransformOrigin'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   Transitions%  System.Windows.VisualTransition   From   GeneratedDuration	   To   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value R� KeyTime R� Value �� EndPoint �� 
StartPoint � Color � Offset ��Name  �� Triggers! P� Property" P� Value# �� 
TargetName  Storyboard1��%�  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 &	     �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   "	 ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5        � ��8  6,   �� 5!       � ��# � ��6+   �� 5"       � ��$ 1q�60   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ 1q�6(   �� 5&       � �� 5'      �� 5(      "
 ��6&   .R�5)      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . $ 12��6�   $ 0.5,0.5&�6�   z�5*      V� 5+   "   .~�5,   &   �� �� 5-   &   �� 5.   &   T� 5/   &   50   #    52        53   "   CommonStates�� 54   &     55   *   $ 	MouseOver��6;   $ 0:0:0.2D�6L   $ Normal��6h   . 57   &     
Normal��62     58   &   	MouseOver��. 59   *   �� .��5:   .   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6L   $ border��6�   .\�5;   2     $ 0:0:0.2��6G   $	 1.2Q�6Y   5<   /   U� 5=   .   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6L   $ border��6�   .\�5>   2     $ 0:0:0.2��6G   $	 1.2Q�6Y   5?   /   T� 5@   .   $ (Panel.Background)�6L   $ border��6{   ..�5A   2   i� $ 0��6I    5B   6   �� 5C   :   $ 0.5,1&�6N   $ 0.5,0&�6_   .��5D   >   � $ Black��6K   $ 0Q�6Y   � 5E   >   $ 	#FFFB3D3D��6K   $ 1Q�6]   5F   ;   5H   3   i� 5I   2   $ 0:0:0.2��6I    5J   6   �� 5K   :   $ 0.5,1&�6N   $ 0.5,0&�6_   .��5L   >   � $ Black��6K   $ 0Q�6Y   � 5M   >   $ 	#FFFB3D3D��6K   $ 1Q�6]   5N   ;   5P   3   5Q   /   T� 5R   .   $ (Border.BorderBrush)�6L   $ border��6}   ..�5S   2   i� $ 0��6I    5T   6   �� 5U   :   $ 0.5,1&�6N   $ 0.5,0&�6_   .��5V   >   � $ Black��6K   $
 0.97Q�6Y   � 5W   >   $ White��6K   $ 1Q�6Y   � 5X   >   $ 	#FFC4C4C4��6K   $ 0.378Q�6]   � 5Y   >   $ 	#FF242424��6K   $ 0.026Q�6]   5Z   ;   5\   3   i� 5]   2   $ 0:0:0.2��6I    5^   6   �� 5_   :   $ 0.5,1&�6N   $ 0.5,0&�6_   .��5`   >   � $ Black��6K   $
 0.97Q�6Y   � 5a   >   $ White��6K   $ 1Q�6Y   � 5b   >   $ 	#FFC4C4C4��6K   $ 0.378Q�6]   � 5c   >   $ 	#FF242424��6K   $ 0.026Q�6]   5d   ;   5f   3   5g   /   5h   +   5i   '     5j   &   Pressed��. 5k   *   �� .��5l   .   T� $ (Panel.Background)�6L   $ border��6{   ..�5m   2   i� $ 0��6I    5n   6   �� 5o   :   $ 0.5,1&�6N   $ 0.5,0&�6_   .��5p   >   � $ Black��6K   $ 0Q�6Y   � 5q   >   $ 	#FFFB3D3D��6K   $ 1Q�6]   5r   ;   5t   3   5u   /   T� 5v   .   $ (Border.BorderBrush)�6L   $ border��6}   ..�5w   2   i� $ 0��6I    5x   6   �� 5y   :   $ 0.5,1&�6N   $ 0.5,0&�6_   .��5z   >   � $ Black��6K   $
 0.97Q�6Y   � 5{   >   $ White��6K   $ 1Q�6Y   � 5|   >   $ 	#FFC4C4C4��6K   $ 0.378Q�6]   � 5}   >   $ 	#FF242424��6K   $ 0.026Q�6]   5~   ;   5�   3   5�   /   5�   +   5�   '     5�   &   Disabled��62   5�   #   ._�5�      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5�        5�      P� 5�      ! �@��IsDefaulted" . . �5�   "   �� $# border��6@   # � ��6T    � ��5�      P� 5�      ! �@J�IsMouseOver" . . �5�   "   �� $# border��6?   8   � ��6S   �� 5�   "   $# border��6@   8   � ��6T   5�      P� 5�      ! � ��" . . �5�   "   �� $# border��6?   8   � ��6S   �� 5�   "   $# border��6@   8   � ��6T   5�      P� 5�      ! � {�" .  . �5�   "   �� $# border��6?   8   � ��6S   �� 5�   "   $# border��6@   8   � ��6T   �� 5�   "   $# contentPresenter��6K   8 	  � ��6i   5�      5�      5�      5�      �� 5�   
   .��5�      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ btnRobo��6�   .\�5�        $ 0:0:0.1��6'   $	 -30Q�69     5�      $ 0:0:0.2��6'   $ 0Q�69   5�      5�      5�      ��5�      �� 5�   
   $ �� ImageSource$$ 
fundo2.jpg��6   .��5�      � .+�5�   
   �� -   5        % ��Name$% 
btnRanking��5�      $��Ranking��6%   $
��Left=�67   $��39.5,150.5,0,0q�6R   $
��86.5��6j   $	��2,3q�6w   $
��Bold"�6�   ���	#FFF7F1F1#��� 
 6�   $��50��6�   $	��Top=�6�   $��16(�6)  ��5�      �� 5�      $ 0.5,1&�6&   $ 0.5,0&�67   .��5�      � $ Black��6#   $
 0.97Q�61   � 5�      $ White��6#   $ 1Q�61   � 5�      $ 	#FFC4C4C4��6#   $ 0.378Q�65   � 5�      $ 	#FF242424��6#   $ 0.026Q�65   5�      ��5�      �� 5�      $ 0.5,1&�6&   $ 0.5,0&�67   .��5�      � $ Black��6#   $ 0Q�61   � 5�      $ 	#FFFB3D3D��6#   $ 1Q�65   5�      5�      �� 5�   
   -   5        & ��Name$& comboBox��5�      $
��46.5��6%   $��39.5,78,152,0q�63   $	��Top=�6J   $��24(�6�   6�   �� 5�   
   -   5        $% 	btnLimpar��5�      $��Limpar��6$   $
��Left=�65   $��153.5,150.5,0,0q�6P   $
��86.5��6i   $	��2,3q�6v   $��24(�6�   $
��Bold"�6�   ���	#FFF7F1F1#��� 
 6�   $��50��6�   $	��Top=�6�   ��5�      �� 5�      $ 0.5,1&�6&   $ 0.5,0&�67   .��5�      � $ Black��6#   $
 0.97Q�61   � 5�      $ White��6#   $ 1Q�61   � 5�      $ 	#FFC4C4C4��6#   $ 0.378Q�65   � 5�      $ 	#FF242424��6#   $ 0.026Q�65   5�      ��5�      �� 5�      $ 0.5,1&�6&   $ 0.5,0&�67   .��5�      � $ Black��6#   $ 0Q�61   � 5�      $ 	#FFFB3D3D��6#   $ 1Q�65   5�      .  (System.Windows.Interactivity.Interaction'   Triggers' 5�      /  )System.Windows.Interactivity.EventTrigger  5�      (   	EventName$( Click��6!   .  (System.Windows.Interactivity.TriggerBase)   Actions.) 5�      F	  @Microsoft.Expression.Interactivity.Media.ControlStoryboardAction	  ?
  9Microsoft.Expression.Interactivity.Media.StoryboardAction* 
  
Storyboard#* [ 61   5�      5�      �� 5�   
   -   5        + ��Name$+ label��5�      $��Pontos��6   $��136.5,227.5,132.5,0q�60   $��36(�6M   $��Forte)�6[   $��52.772��6n   $	��Top=�6~   �� 5�   
   $#��94.103,278.939,82.706,237.156q�6   , �� RadiusY$, 5��6;   - �� RadiusX$- 5��6G   
���   �$��5��6b   ���	#FF0F0F0F6v   �� 5�   
   -   5        . ��Name$. 	txtPontos��5�      $��0,0,89.667,244.997q�6%   / �� TextWrapping$
/ Wrap=�6A   $��36(�6U   $��Right=�6�   $��-5q�6�   $��38.731��6�   $��Bottom=�6�   ���	#FFF3E8E8$
��Bold"�6�   $��201.453��6  0 �� TextAlignment$0 Center=�6  ��6c   Z� ��6y   Z� 6  �� 5�   
   $	��150��6   $��39.5,0,28.5,71q�6!   $, 5��69   $- 5��6E   $��5��6Q   $��Bottom=�6e   ��5�      �� 5�      $$ Increase-Chart.jpg��6   5�      �� 5�   
   -   5        1 ��Name$1 image��5�      $
��Left=�6   $	��122��6:   $��
251,78,0,0q�6G   $	��Top=�6[   $	��113��6s   $��interrogacao.png��6   2 J� OpacityMask2 5�      �� 5�      $$ Bitmap1.bmp��6   5�      5�      5�      