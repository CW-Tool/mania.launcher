   M S B A M L   `   `   `  ����W  SMapleStory Mania Launcher, Version=0.9.3.3061, Culture=neutral, PublicKeyToken=null+clr-namespace:Samples.libsSamples.libs  5          Samples.FancyBalloon   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      +libsclr-namespace:Samples.libs     5      -   5          >�Name$  me��5      $	��300��5      $	��120��5       � 	Resources 5       
  FadeIn g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value  HighlightCloseButton  FadeCloseButton  FadeBack  FadeOut��%`  &	        &	     &	 1    &	 D    &	 1    �� 5	   
   .��5
      U� $ 00:00:00X�6,   $
 grid��5   ,   $ (UIElement.Opacity)�5   ,   .\�5      �� $ 00:00:00��6'   $ 0Q�5   '   �� 5      $ 00:00:01��6'   $
 0.80Q�5   '   �� 5      $ 00:00:03��6'   $
 0.80Q�5   '   5      5      �� 5   
   6   �� 5   
   6   �� 5   
   .��5      U� $ 00:00:00X�6,   $
 grid��5   ,   $ (UIElement.Opacity)�5   ,   .\�5      �� $ 00:00:00��6'   $ 1Q�5   '   �� 5      $ 00:00:00.3000000��6'   $ 1Q�5   '   5       5!      �� 5"   
   -   5        .��5$      U� $ 00:00:00X�6,   $
 grid��5%   ,   $ (UIElement.Opacity)�5&   ,   .\�5'      �� $ 00:00:00��6'   $ 1Q�5(   '   �� 5)      $ 00:00:00.3000000��6'   $	 0.2Q�5*   '   5+      5,      5-       � Triggers 5.      :� 5/   
    :� RoutedEvent$% libs:TaskbarIcon.BalloonShowing��6   .[�50      �� -   5        	 ��Name$	 FadeIn_BeginStoryboard��50      #��[  51      52      :� 53   
   $ Mouse.MouseEnter��6   .[�54      �� 
 �� BeginStoryboardName$
 FadeIn_BeginStoryboard��6   �� 55      -   5        $	 FadeBack_BeginStoryboard1��55      #��[ 56      57      :� 58   
   $% libs:TaskbarIcon.BalloonClosing��6   .[�59      �� -   5        $	 FadeOut_BeginStoryboard��59      #��[ 5:      5;      .��5=      � -   5         �Name$
 grid��5=      .+�5A   
   � -   5        $ block��5A      $��5,6,6,6q�5B      ���	#FF233F56 J� RenderTransformOrigin$ 0.5,0.5&�5C   &   z�5D      V� 5E      .~�5F      ��  �� ScaleY$ -1Q�6%    �� ScaleX$ -1Q�61   �� 5G      �� 5H      T� 5I      5J       J� Effect 5L      3  -System.Windows.Media.Effects.DropShadowEffect  5M         
BlurRadius$ 5Q�6#      	Direction$ 90Q�5N   #      ShadowDepth$ 2Q�5O   #   .+�5S      � ���	#FF1A2532$��2q�5T   *   5U      �� 5W   
   $��78��6   $��
24,32,18,0q�5X      $��Center=�5Y      $	��Top=�5Z      ���#a6a8ac$
��Wrap=�5_      ��5\      ��  �� Path$ BalloonMessage� �� ElementName$ me�� �� Mode$ Default=�5_      �� 5c   
   -   5         ��Name$ 
closePopup��5c      $��267,10,8,91q�5d      $��r��5f      $��13(�5g        WindowBorderButtonStyle#��[ 5h      5l      5m      