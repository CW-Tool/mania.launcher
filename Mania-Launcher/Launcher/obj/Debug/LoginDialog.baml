   M S B A M L   `   `   `  ����W  SMapleStory Mania Launcher, Version=0.9.3.3061, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Mania.Launcher.AnimationMania.Launcher.Animation  5   	   +clr-namespace:Samples.libsSamples.libs  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       Mania.Launcher.LoginForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <	animation&clr-namespace:Mania.Launcher.Animation     5   	   ,libs1clr-namespace:Samples.libs     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   -   5          � Title$  Authorization��5   	   $	��500��5   	   $	��470��5	   	    � AllowsTransparency .  � Icon$ Resources/maplestory.ico��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   ��5   	   Z�  � 	Resources 5          BooleanToVisibilityConverter  ActivationModes S� 
MethodName S� 
ObjectType  System.Enum	 S� MethodParameters
 M� TypeName��%�   &	        &	      �� 5   
   6'   S� 5   
   $ 	GetValues��5      "  5      	 5      M� 5      $
 libs1:PopupActivationMode��6   5      5       � Triggers 5       :� 5!   
    :� RoutedEvent$' !libs1:TaskbarIcon.TrayToolTipOpen��6    :� 
SourceName$ tb��5"      .��5%      � $��6,2,6,9q�6   .+�5'   
      Samples.libs.TaskbarIcon  -   5          Name$ tb��5'         
IconSource$ maplestory.ico��5(      $y�	Collapsed=�5)      �� 5+   
   -   5         ��Name$ loginBG��5+      $	��485��5,      $	��456��5-      $��0,2,0,0q�5.      $
��Left=�5/      $	��Top=�50      $��Resources/loginForm.png��51      �� 53   
   -   5         ��Name$ loginBox��53      $	��308��54      $��34��55      $��90,168,90,0q�56       �� 	MaxLength$ 16��57      $��Center=�58      $	��Top=�59      $-��'/Launcher;component/Resources/#Blizzard)�5:      $��16(�5;       �� SelectionBrush �#787878  TextBoxStyle#��[ 5=       �� TextWrapping$
 Wrap=�5>      G� 5@   
   -   5         G�Name$ passwordBox��5@      $	��308��5A      $��34��5B      $��90,216,90,0q�5C      $��Center=�5D      $	��Top=�5E      $��16(�5F       G� SelectionBrush �#787878  PasswordBoxStyle#��[ 5J      �� 5M   
   -   5         ��Name$ loginBtn��5M      $	��122��5N      $��34��5O      $��90,298,276,0q�5P      $��Center=�5Q      $	��Top=�5R      $��LOGIN��5V      $��Ebrima)�5W      $��15(�5X      $
��Bold"�5Y        PlayButtonStyle#��[ 5Z      ��5T      �� *ClickCommand+��5U      ��  �� ElementName$ passwordBox��5Z      �� 5\   
   -   5        $ forgotPassBtn��5\      $	��121��5]      $��17��5^      $��277,257,90,0q�5_      $��Center=�5`      $	��Top=�5b      $��FORGOT PASSWORD?��5c      $��Ebrima)�5d      $��9(�5e      $
��Bold"�5f        TextButtonStyle#��[ 5g      �� 5j   
   -   5        $ regBtn��5j      $	��181��5k      $��34��5l      $��217,298,90,0q�5m      $��Center=�5n      $	��Top=�5o      $��REGISTRATION��5p      $��Ebrima)�5q      $��15(�5r      $
��Bold"�5s        RegButtonStyle#��[ 5t      69   �� 5x   
   -	   5         ��Name$ remember��5x      $	��156��5y      $��17��5z      $��
90,256,0,0q�5{      $
��Left=�5|      $	��Top=�5}      $��REMEMBER ME��5~      $��Ebrima)�5      $��11(�5�      $
��Bold"�5�      ���#d4f5ff d� 	IsChecked$
 TrueY�5�      ,   &Mania.Launcher.Animation.LoaderSpinner  5�   
   -
   5          Name$ initIndicator��5�   "   $��30��5�   "   $��30��5�   "   $��0,0,322,128q�5�   "   $��Right=�5�   "   $��Bottom=�5�   "   �� 5�   
   -   5        $ closeButton��5�      $��21��5�      $��21��5�      $��453,10,10,427q�5�      $��r��5�      $��16(�5�        WindowBorderButtonStyle#��[ 5�       � ToolTip$ Close��5�       ^� HorizontalOffset$	 -20��5�       ^� 	Placement$ Bottom=�5�       ^� ShowDuration$ 20000��5�        ^� VerticalOffset$  10��5�      �� 5�   
   -   5        $
 logo��5�      $	��253��5�      $	��100��5�      $��
119,31,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Resources/logo_game.png��5�      �� 5�   
   $��1,1,2,0q�6   ���	#FF233F56$��1q�5�      �� 5�   
   $��0,0,1,-1q�6   
���   �$��1q�5�      5�      5�      