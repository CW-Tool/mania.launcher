   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   Mania.Utils)   #Mania.Utils.ProgressBar.ProgressBar   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9System&clr-namespace:System;assembly=mscorlib     -     >�Name$  	NProgress�� � 	Resources    SetProgress �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   EasingFunction.  (System.Windows.Media.Animation.CubicEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  Complete W� From		 W� To
 g� Duration��%�  &	        &	 �     �� .��U� $ (FrameworkElement.Width)�$	 Bar��.\�  $ 0:0:0.5�� �� *NewBarWidth+   $ EaseOut=�U� $ (Canvas.Left)�$ 
GlowBorder��.\�  $ 0:0:0.5�� �� *NewBorderLeft+   $ EaseOut=��� .��W� $	 Bar��$ (Rectangle.Opacity)�$ 1X�$	 0X�$
 0:0:0.5D�W� $ 
GlowBorder��$ (Border.Opacity)�$ 1X�$	 0X�$
 0:0:0.5D�.��� -    �Name$ 
LayoutRoot��$��6��.+��� $��6��$	��Top=�}�. .+��� -    ��Name$ 
GlowBorder�����#f29400$��1q�$��2��$��80.25�� J� RenderTransformOrigin$ 0.5,0.5&� �� Left �� *
BorderLeft+z�V� .~��� �� �� T�  T� Y$
 -4.2Q� � LayoutTransform V� .~��� �� ��  �� Angle$ 3Q�T�  J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 1Q�   Color$ 	#FFD1F5FF���� -    ��Name$	 Bar�����#f29400���	#00412F2F$��0��$��2������ *
BarWidth+