   M S B A M L   `   `   `  ����W  SMapleStory Mania Launcher, Version=0.9.3.3061, Culture=neutral, PublicKeyToken=null+clr-namespace:Samples.libsSamples.libs  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   -    'Mania.Launcher.Dialogs.PopupDialogReset   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ,libs1clr-namespace:Samples.libs     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   -   5          � Title$  Are you sure?��5   	   $	��410��5   	   $	��160��5   	    � AllowsTransparency .  � Icon$ ../Resources/icon.ico��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � ShowInTaskbar .  ��5
   	   Z�  � 	Resources 5          BooleanToVisibilityConverter  ActivationModes S� 
MethodName	 S� 
ObjectType  System.Enum
 S� MethodParameters M� TypeName��%�   &	        &	      �� 5   
   6'   S� 5   
   $ 	GetValues��5      "	  5      
 5      M� 5      $ libs1:PopupActivationMode��6   5      5       � Triggers 5      :� 5   
    :� RoutedEvent$' !libs1:TaskbarIcon.TrayToolTipOpen��6    :� 
SourceName$ tb��5      .��5!      � $��6q�6   .+�5"   
   �� ���	#FFFDFDFD  WindowDropShadowEffectKey J� Effect# [ 5#         Samples.libs.TaskbarIcon  5&   
   -   5          Name$ tb��5&         
IconSource$ ../Resources/icon.ico��5'      $y�	Collapsed=�5(      �� 5+   
   $	��398��6   $	��148��5,      $
��Left=�5-      $	��Top=�5.      $"��../Resources/popUp/popup.png��5/      �� 51   
   -   5         ��Name$ closeBtn��51      $��19��52      $��20��53      $��0,5,7,0q�54      $��Right=�55      $	��Top=�56      $��r��58      $��16(�59        WindowBorderButtonStyle#��[ 5:       � ToolTip$ Close��5;       ^� HorizontalOffset$	 -20��5<       ^� 	Placement$ Bottom=�5=       ^� ShowDuration$ 20000��5>       ^� VerticalOffset$ 10��5?      �� 5A   
   -   5        $ 
restartBtn��5A      $	��139��5B      $��30��5C      $��27,100,232,0q�5D      $��Center=�5E      $	��Top=�5F      $��Reiniciar Agora��5G      $��15(�5H        PlayButtonStyle#��[ 5I      $��Ebrima)�6S   $
��Bold"�6g   �� 5K   
   -   5        $ restartLaterBtn��5K      $��198,100,87,18q�5L      $��Reiniciar Depois��5N        RegButtonStyle#��[ 5O      $��Ebrima)�69   $��15(�6M   �� 5P   
   -   5         ��Name$ popupMessage��5P      $	��350��6*   $��70��5Q      $��	27,25,0,0q�5R      $
��Left=�5S      $	��Top=�5T      ���	#FFE8E8E8$_��YO Launcher deve ser reiniciado para que as alterações entrem em vigor. Reiniciar agora?��5V      $
��Wrap=�5W      $��15(�6(   5Y      5Z      