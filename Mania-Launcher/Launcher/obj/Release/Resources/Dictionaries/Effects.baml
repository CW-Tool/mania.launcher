   M S B A M L   `   `   `  ���� W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0893    -System.Windows.Media.Effects.DropShadowEffect   WindowDropShadowEffectKey     
BlurRadius    Opacity    ShadowDepth  HeaderShadowLoginForm    	Direction  ListBoxItem �� 
TargetType �� Property �� Value �� 
TargetType �Name	 � RowDefinitions
 ��Name �� CornerRadius �� Opacity �� Color J� Opacity �� Triggers P� Property P� Value �� 
TargetName �� Triggers :� RoutedEvent g� Duration �� TargetProperty	 W� To  ItemNormalBrush �� ImageSource  ItemHoverBrush ��Name P� 
SourceName  SettingsTabItem  TabItemText �� Binding �� RelativeSource �� AncestorType �� Value  InputBackgroundFocused  CheckBoxFocusVisualStyle 	 NormalBrush �� 
StartPoint  �� EndPoint! � Offset" � Color 
 HorizontalNormalBrush  
LightBrush  HorizontalLightBrush  	DarkBrush  PressedBrush  DisabledForegroundBrush  DisabledBackgroundBrush  WindowBackgroundBrush  SelectedBackgroundBrush  NormalBorderBrush  HorizontalNormalBorderBrush  DefaultedBorderBrush  PressedBorderBrush  DisabledBorderBrush  SolidBorderBrush  LightBorderBrush  
GlyphBrush  LightColorBrush# �� 
Background$ �� Bullet% F�Name& J� SnapsToDevicePixels' T� Y  TextBoxStyle( ��Name) u� Bottom* u� Left+ u� Right
, u� Top  PasswordBoxStyle  BodyBackgroundBrush  DataGridMouseHoverColor   Cm- K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation.   DirectionalNavigation/    Color ! MenuItem " SimpleComboBoxItem # Triggers $ ComboBoxToggleButton0 � ColumnDefinitions % ComboBoxTextBox1 �� 	ClickMode2 d� 	IsChecked3 �� Path4 �� Mode5 J� IsHitTestVisible6 �� SelectionBoxItem7 �� SelectionBoxItemTemplate8 ��Name9 �� 
IsReadOnly: �� 
IsReadOnly; �� IsDropDownOpen< � AllowsTransparency= � ActualWidth> �� MaxDropDownHeight? �� Padding�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      %�$  &	        &	       &	 H     &	 �    &	     '�� X    7  7  &	 (    &	 V    &	     &	 -    &		 |    &	
 �    &	 2	    &	 �	    &	 �	    &	 >
    &	 �
    &	 �
    &	 �
    &	 �
    &	 �
    &	 >    &	 �    &	 �    &	 T    &	 d    &	 t    &	 �    &	 �    '�� �    7 	 7  7 	 7  7  7  &	     &	 :    &	 :    &	 O    &	  b    7  (�� Y    *MenuItem.SeparatorStyleKey+)&	!     &	" �    &	# �    &	$ c    &	%     '�� 9    7 $ 7 % '�� �!       $  10Q�$	 1.7Q�$ 0Q�   $  10Q�$ 0Q�$	 1.7Q�$ 0Q��� " ��.���  �@�OverridesDefaultStyle . ��  � �� �� " ��.R�� $
 grid��	 �� $��* ��� $
��Auto �.+��� $
 hover��$��Stretch=�$��Stretch=�$��1q�$ 0��$y�	Collapsed=����� $	 0.1Q�$ 	#99E7E7E7������ $	 0.3Q�$ 	#99E7E7E7���� $
 	highlight��$��Stretch=�$��Stretch=����	#991869F5���	#990572E2$��1q�$ 0��$	 0.3Q�$y�	Collapsed=��� �� $��1��$��1��$��1q����� $	 0.7Q�$ 	#99446E99�� P�  �@J�IsMouseOver . . ��� $ hover�� � y�$ Visible=�P�  �@��
IsSelected . . ��� $ 	highlight�� � y�$ Visible=���  �@J�Opacity$	 1.3Q�P�  �@��
IsSelected .  . ���  �@J�Opacity$	 0.7Q� :� $ Mouse.MouseEnter��[��� .���� .��W� $ 0:0:0.2D�$ Opacity�$	 1.3X�:� $ Mouse.MouseLeave��[��� .���� .��W� $ 0:0:0.2D�$ Opacity�$	 0.7X��� $9 3pack://application:,,,/Resources/itemBtn_normal.png���� $8 2pack://application:,,,/Resources/itemBtn_hover.png���� " ��.���  � �� �� " ��.R�� .+��� $��Border��$��0,0,0,13q�
������ ._��� $ ContentSite��$��9q�$��Center=�$	��Top=�$��Header�� P�  �@��
IsSelected . . ��� $ Border��8    � ��P�  �@��
IsSelected .  . ��� $ Border�� � ��
 ���� �� $ Border�� � ��
 ���� P� $ Border�� �@J�IsMouseOver . . ��� $ Border��8   � ���� $ Border�� � �� �	#FF3E4D61�� " ��.���  � �� �� " ��.R�� .+��� $��Border��$��0,0,0,13q�
������ 
������ $��1,1,1,1q�._��� $ ContentSite��$��9q�$��Center=�$	��Top=�$��Header�� P�  �@��
IsSelected .  . ��� $ Border�� � ��
 ���� �� $ Border�� � ��
 ���� �� " �� ��  �� *
IsSelected+ �� $ TabItemL� True.a���  � ��
 �������  �� *
IsSelected+ �� $ TabItemL�	 False.a���  � �� �	#FFCDCDCD�� $ Orange���� .���  � �� �� .R��� $��0,0,4,3q�
������ $��2q�$ 1���� $	 0,0&�$	  0,1&���� � $	! 0.0Q�$" 	#FF0B5E81��� $	! 1.0Q�$" 	#FF1788BB���� $	 0,0&�$	  1,0&���� � $	! 0.0Q�$
" #FFF��� $	! 1.0Q�$
" #CCC���� $	 0,0&�$	  0,1&���� � $	! 0.0Q�$
" #FFF��� $	! 1.0Q�$
" #EEE���� $	 0,0&�$	  1,0&���� � $	! 0.0Q�$
" #FFF��� $	! 1.0Q�$
" #EEE���� $	 0,0&�$	  0,1&���� � $	! 0.0Q�$" 	#FF101D2E��� $	! 1.0Q�$" 	#FF101D2E���� $	 0,0&�$	  0,1&���� � $	! 0.0Q�$" 	#FF080D13��� $	! 1.0Q�$" 	#FF080D13���� $
 #888���� $
 #EEE���� $
 #FFF���� $
 #DDD���� $	 0,0&�$	  0,1&���� � $	! 0.0Q�$" 	#FF7E7E7E��� $	! 1.0Q�$" 	#FF7E7E7E���� $	 0,0&�$	  1,0&���� � $	! 0.0Q�$
" #CCC��� $	! 1.0Q�$
" #444���� $	 0,0&�$	  0,1&���� � $	! 0.0Q�$" 	#FF7E7E7E��� $	! 1.0Q�$" 	#FF7E7E7E���� $	 0,0&�$	  0,1&���� � $	! 0.0Q�$" 	#FF7E7E7E��� $	! 1.0Q�$" 	#FF7E7E7E���� $
 #AAA���� $
 #888���� $
 #AAA���� $ 	#FFD4F5FF���� $
 #DDD���� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@�FocusVisualStyle# �  ��  � �� �� " ��.R��� 
# ���� $ �� $
 Border��$��17��$��17��8��  ���#3f434b$��1q�$ 5��._�F� $% 	CheckMark��$��11��$��11��F���Ѐ�  	= Ӏ�  	= ��- @KL @KL @]� �@KL @]� @KL ��-  � 	& .  8�� $��2��._��� $��4,0,0,0q�$
��Left=�$��Center=���.  P�  �@d�	IsChecked$ falseY�. ��� $ 	CheckMark�� � y�$ 	Collapsed=�P�  Z�  �@d�	IsChecked. ��� $ 	CheckMark�� � �� ��    ��j ���j     	P�  �@J�IsMouseOver . . ���  � �� �#555960P�  � �� . . ��� $ Border��8   � ���� $ 	CheckMark�� � z� T� $	' 1.0Q�P�  � {� .  . ��� $ Border��8   � ���� $ Border��8   � ���� 8   � ���� 	myTextBox��" ��.���  � �� �� $ 	#FFFDFDFD��$	 0.5Q���  � ��$	 Top=���  � �� �	#FF2D353F��  � ��$ LeftToRight=���  � �� �#535558��  � ��$ 6q���  � �� �� .R��� $
 Bd��#��z��#��z��#��z��$ 2,2,2,2��._��� $( PART_ContentHost�� P�  � {� .  . ��� $ Bd�� � �� �� $ 	#FFFDFDFD��$	 0.7Q��� # � �� � ��P�  � ��$
 Auto��. ���  � ��$	 100��P�  � ��$
 Auto��. ���  � ��$ 20����  � �� u� $) 1Q�$* 1Q�$+ 1Q�$, 1Q� P�  �@J�	IsFocused . . ���  � �� �#00c7ff��  � �� �� $ 	#FFFDFDFD��$	 0.7Q���  � �� �#fffP�  �@J�IsMouseOver . . ���  � �� �#4c5159��  � �� �#fff�� myPasswordBox��" G�.���  � �� �� $ White��$	 0.5Q���  � ��$	 Top=���  � �� �	#FF2D353F��  � ��$ LeftToRight=���  � �� �#535558��  � ��$ 6q���  � �� �� .R��� $
 Bd��#��z��#��z��#��z��$ 2,2,2,2��._��� $( PART_ContentHost�� P�  � {� .  . ��� $ Bd��# � �� � ���� # � �� � ��P�  � ��$
 Auto��. ���  � ��$	 100��P�  � ��$
 Auto��. ���  � ��$ 20����  � �� u� $) 1Q�$* 1Q�$+ 1Q�$, 1Q� P�  �@J�	IsFocused . . ���  � �� �#00c7ff��  � �� �� $ 	#FFFDFDFD��$	 0.7Q���  � �� �#fffP�  �@J�IsMouseOver . . ���  � �� �#4c5159��  � �� �#fff�� $ 	#FF1A2532���� $ #323945���� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@�IsSharedSizeScope . ��  �@��HasDropShadow . ��  � �� �#b3b3b3��  �@��HorizontalOffset$ 0����  �@��VerticalOffset$ 0����  � �� �� " ��.R��� $��Border��8��  ���	#FF233F56$��1q�$ 2��._��� - . $. Cycle=� P�  �@��HasDropShadow . . ��� $ Border�� �@J�Effect    $  3Q�$	 0.7Q�$ 3Q�$/ Black���� " ��.���  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��� $	��240��$��1��$4��.pack://application:,,,/Resources/separator.png��$
��Fill=��� " m� P�  �@J�IsMouseOver . . ���  � �� �#ffffffP�  �@m�IsHighlighted . . ���  � �� �#323945�� " ��.���  � ��$ 14(���  � ��
 �������  � ��
 �� ���� " �� P�  �@J�IsMouseOver . . ���  � ��
 �  ����  � ��$ 20(���  � ��$ 
Arial Bold)��� " d�.R�� 0 �� �� $��20 �.+��� $
 Border��$��2��$ 0��
������ 
������ $��0q�F� $% Arrow��
�������$��Right=�$��Center=�=����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	$��3�� :� $ Mouse.MouseEnter��[��� .���� .��W� $ 0:0:0.2D�$ Opacity�$ 1X�:� $ Mouse.MouseLeave��[��� .���� .��W� $ 0:0:0.2D�$ Opacity�$	 0.5X��� " ��.R��� $
 PART_ContentHost��|�.  #��z���� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � ��$	 120����  � ��$ 20����  � ��
 �������  � �� �� " ��.R�� .+�d� $��ToggleButton��8��  $��2��|�.  $1 Press=�2 �� $3 IsDropDownOpen�$4 TwoWay=� �� *TemplatedParent+�� $��ContentSite��5 .  #��z6 #��z7 #��z��$��Center=�$��Center=��� $8 PART_EditableTextBox��8�� $��Center=�$��Center=�$��3,3,23,3q�|�. ���	#FF3F3F3F
��� � �$y�Hidden=�#: z9 ��Z� � $��Popup��$��Bottom=�#��z; < . |�.  $��Slide=�.��� $��DropDown��& . #��z= #��z> .+��� $
 DropDownBorder�����	#FF1A2532$��1q����	#FF233F56$	 0.9Q��� $��4,6,4,6q�& . .���� - . $. 	Contained=� P�  �@��HasItems .  . ��� $ DropDownBorder�� � ��$ 95��P�  � {� .  . ���  � �� �#888888P�  �@��
IsGrouping . . ���  � �� .  P� $ Popup�� �@�AllowsTransparency . . ��� $ DropDownBorder�� �@��CornerRadius$ 0���� $ DropDownBorder�� � ��$ 0,2,0,0q�P�  �@��
IsEditable . . ���  � �� .  �� $ PART_EditableTextBox�� � y�$ Visible=��� $ ContentSite�� � y�$ Hidden=� �� " ��.���  �@J�SnapsToDevicePixels . ��  � ��
 �������  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��� $��Border��$? 2q�& . $��Center=�._���  P�  �@��IsHighlighted . . ��� $ Border�� � �� �� $ 	#FF4F4F4F��$	 0.5Q�P�  � {� .  . ���  � �� �#888888