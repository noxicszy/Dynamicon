   M S B A M L   `   `   `  ����D  @Dynamicon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WallpaperAppWallpaperApp  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   FocusVisual  �� Property �� Value J� SnapsToDevicePixels  
ThemeColor �� StrokeDashArray  ThumbDefaultBack �� Color  IndigoPrimary300  PrimaryHueLightBrush �� 
TargetType �� 
TargetType � 	Resources-   'System.Windows.Media.Animation.SineEase  Key7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode	 �� 
TargetName
 �� TargetProperty  RippleEasingFunction W� EasingFunction	 W� To g� Duration W� From'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   Transitions%  System.Windows.VisualTransition   From	   To   
Storyboard9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   EasingFunction2  ,System.Windows.Media.Animation.QuadraticEase   States   System.Windows.VisualState   
Storyboard ��Name �� RadiusY �� RadiusX J� Opacity �Name A�Name J� RenderTransformOrigin  �� ScaleX! �� ScaleY" J� 	CacheMode&   System.Windows.Media.BitmapCache#   EnableClearType$   SnapsToDevicePixels  MaterialDesignShadowDepth1% J� Effect& T� X' T� Y( �� Triggers) P� Property* P� Value+ �� 
TargetName, �� RelativeSource- �� Path. N� EnterActions  
ShowRipple/ N� ExitActions 	 
HideRipple0 �� Opacity�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      $localclr-namespace:WallpaperApp  5      %�  &	        &	 �     &	 �     &	 �     7  'd�     7   7  7  7  7  7  7  7 	 �� 5      .�5   
   ��   � �� 5      �� 5      .R�5      �� $��2q�6     . #���  6F   $��1��6l   $	 1 2R�6�   5	      5      5      �� 5      $ #f0f0f0��6/   6A   ��5      #7986cb��6.   �� 5      8   63   �� 5      " d�6   .�5   
   ��   �@�FocusVisualStyle8   6-   �� 5   
     � ��# �  6'   �� 5   
     � ��$ 1q�6,   �� 5   
     � ��$ 1q�6$   �� 5   
     � �� 5      �� 5      " d�6"    5      ��   5      RippleEasingFunction $ 	EaseInOut=�6@   �� 5      
ShowRipple .��5      W� $	 RippleThumb��6.   $
 Opacity�6R   8  $
 0.26X�5    .   $ 0D�68   W� 5!      $	 RippleThumb��6.   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6R   8  $ 1X�5#   .   $	 2.5X�67   $ 0:0:0.2D�6@   W� 5$      $	 RippleThumb��6.   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6R   8  $ 1X�5&   .   $	 2.5X�67   $ 0:0:0.2D�6@   5'      �� 5(      
HideRipple .��5)      W� $	 RippleThumb��6.   $
 Opacity�6R   8  $ 0X�5+   .   $ 0:0:0.3D�65   5,      5-      .R�5.      (� $��34��6    5/        50      CheckStates�� 51   "     52   &   $ *��67   $ Checked��6@   . 53   *   �� .��54   .   U� $8
 2(UIElement.RenderTransform).(TranslateTransform.X)�6L   $	 ThumbHolder��6�   .\�55   2     $ 0��6G   $ 0Q�6S     56   2   $ 0:0:0.2��6G   $
 23.5Q�6Y    57   6     58   :   $ EaseOut=�6H   5:   3   5;   /   5<   +   5=   '     5>   &   $ Checked��67   $ 	Unchecked��6F   . 5?   *   �� .��5@   .   U� $8
 2(UIElement.RenderTransform).(TranslateTransform.X)�6L   $	 ThumbHolder��6�   .\�5A   2     $ 0��6G   $
 23.5Q�6S     5B   2   $ 0:0:0.2��6G   $ 0Q�6Y    5C   6     5D   :   $ EaseOut=�6H   5F   3   5G   /   5H   +   5I   '   . 5K   "     Checked��. 5L   &   �� .��5M   *   W� $8
 2(UIElement.RenderTransform).(TranslateTransform.X)�6:   $	 ThumbHolder��6�   $ 0D�5N   :   $
 23.5X�6G   5O   '   5P   #     5Q   "   	Unchecked��. 5R   &   �� .��5S   *   W� $8
 2(UIElement.RenderTransform).(TranslateTransform.X)�6:   $	 ThumbHolder��6�   $ 0D�5T   :   $ 0X�6G   5U   '   5V   #   5W      .��5Y      � .+�5Z      �� $ Track��6(   
���   �$
��Left=�5[   5   $��15��6P   $��4.211,5,4.211,0q�6\   $	��Top=�6�   $��40��6�   $	 7.5��6�   $	 7.5��6�   $
 0.26Q�6�   ��6u   Z� 6�   � 5]      $ ThumbHolder��6#   $
��Left=�5^   #   $	��Top=�6>   .+�5_   "   A� $ RippleThumb��6*   #���  5`   *   $��25��5a   *   $��25��66   $
 0.26Q�5b   *   $��0q�5c   *   $��Center=�5d   *   $��Center=�6G   $ 0.5,0.5&�5e   *   z�5f   &   �� 5g   *   $  1Q�69   $! 1Q�6D   5i   #   �� 5j   "   " 5k   &     5l   *   # . $ . 6M   .u�5n   &   A� $ Thumb��6.   8�� $��Center=�5p   .   $��Center=�6K   $��25��5q   .   $��25��69   $��0,0,0,0q�5r   .   $ 0.5,0.5&�5s   .   #% �  5t   .   ��5o   W   Z� 5u   '   5v   #   z�5w   "   T� 5x   &   $& 0Q�69   $' 0Q�6?   5z      5{      5|      ( 5}      P� 5~      ) �@d�	IsChecked$
* TrueY�67   . �5      �� $+ Thumb��6%    6H   �� , �� *TemplatedParent+$- 
Foreground�  � ���� 5�      $+ Track��6%   # �  6H     � ��5�      P� 5�      ) �@��IsDefaulted* . 6@   P� 5�      ) �@J�IsMouseOver* . 69   P� 5�      ) � ��* . . 5�      �� 5�   "   8�� 62   / 5�      �� 5�   "   8�� 62   5�      P� 5�      ) � {�* .  . �5�      �� $+ Thumb��6%     � �� �#BDBDBD6H   �� 5�      $+ Track��6%     � �� 5�   "   �� 5�   &   $ Black��66   $	0 .12Q�6D   5�      5�      5�      5�      5�      5�      