   M S B A M L   `   `   `  ����U  QSelfDevelopmentApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:SelfDevelopmentApplication.Views SelfDevelopmentApplication.Views  5      4    .SelfDevelopmentApplication.Views.NotesListView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @views.clr-namespace:SelfDevelopmentApplication.Views     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a;	Behaviors+http://schemas.microsoft.com/xaml/behaviors  5      -   5        $��DefaultNotesListView��5      .��5      � .+�5   
   � -   5          �Name$  MainGrid��5      $��
30,0,25,35q�5       � RowDefinitions 5      �� 5      $��* �6    �� 5      $��4* �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�5      $��Center=�5      .+�5      �� $��45(�5      $
��Bold"�5      
�������$��Center=�5      $��	0,0,15,10q�5      ��5      �� *NotesCategory.Name+   TextShortenerConverter �� 	Converter# [   �� ConverterParameter$ 15��5      (  "System.Windows.Controls.DatePicker  5        NotesDatePickerStyle#��[ 6   �� 5       �� CornerRadius$ 15��6   $��
10,20,5,20q�5       �� Padding$ 15q�5       ���#313e4e._�5"      �� $��
+ new note��6   
�������$��20(�5$      $
��Bold"�5%      
������ $��0q�5'      ��5(      �� *ShowNoteDialogCommand+5)      �� 5*      $ 15��6   $ 15q�5+      $��
0,20,10,20q�5,      ���#313e4e._�5.      �� $��return��6   
�������$��20(�50      $
��Bold"�51      
������ $��0q�53      ��54      �� *" NavigateToNotesCategoriesCommand+55      �� 56      $ 15��6   $ 15q�57      $��
0,20,20,20q�58      ���#313e4e._�5:      ��   FilteringTextBoxStyle#��[ 6   
 � Tag$ Filter notes��5<      ��5;      �� *FilteringText+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�5<      5=      5>      �� 5@      $��1��6   .+�5A      �� $��1��6   $
��Auto=�5B      ��5C      �� *ActualHeight+
 �� RelativeSource
 ��  �� AncestorType 
StackPanel.��5D      �� 
������ $��0q�5G      ��5E      �� *	NotesList+��5H      �� 5I      .R�5J      � ��6(   �� *ActualWidth+ �� ElementName$ MainGrid��5L      ��5O      �� 5P      .R�5Q      �� $ 15��6%   $��10q�5R      $ 16q�5S      ���#516580._�5U   "   �� $��25(�6)   
������ $��0q�5W   %   ��5X   %   �� *#!DataContext.ShowNoteDialogCommand+$ DefaultNotesListView����5Z   %   ��  J� InputBindings 5[   &   d� 5\   *    d� MouseAction$ 
RightClicke�67    �� Command 5]   3   �� *DataContext.DeleteNoteCommand+$ DefaultNotesListView�� �� CommandParameter 5_   3   �� .��5a   &   �� $��WrapWithOverflow=�60    �� TextAlignment$ Center=�5b   0   �� 5c   *   $��22(�5d   .   $
��Bold"�5e   .   
��������5c   .   �� *Title+# [  $ 12��5f   .   �� 5g   *   �� 5h   *   $��15(�5i   .   $
��Bold"�5j   .   
��������5h   .   �� *	Content+# [  $ 12��5k   .   �� 5l   *   �� 5m   *   $��12(�5n   .   
��������5m   .   �� *LastEditDateTime+ �� StringFormat$ dd.MM.yyyy HH:mm��5o   .   5p   '   5q   #   5r      5s      5u      5v      5w      5z      /   )SelfDevelopmentApplication.Views.NoteView  5|   
    K� ZIndex$ 2��6   $��-40,-60,0,0q�5}      y�5~      �� *
ShowDialog+  BoolToVisConverter# [ =   7SelfDevelopmentApplication.Views.ConfirmationDialogView  5�   
   $ 2��6'   $��-40,-60,0,0q�5�   '   $0 *Are you sure you want to delete this note?��5�   '   y�5�   '   �� *ShowConfirmationDialog+# [ 5�   '   5   /SelfDevelopmentApplication.Views.MessageBoxView  5�   
   $ 2��6   $��-40,-60,0,0q�5�      $+ %Succeed! Notes lists will be updated.��5�      y�5�      �� *ShowMessageBox+# [ 5�      � 5�   
   $y�	Collapsed=�6   $ 1��5�      
���   � J� Opacity$	 0.3Q�5�      .+�5�      �� 
������ *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5�      +  %Microsoft.Xaml.Behaviors.EventTrigger  5�         	EventName$  PreviewMouseLeftButtonDown��6-      	Behaviors 5�      5  /Microsoft.Xaml.Behaviors.Core.ConditionBehavior  5�         	Condition. 5�   "   9  3Microsoft.Xaml.Behaviors.Core.ConditionalExpression     
Conditions. 5�   &   7	  1Microsoft.Xaml.Behaviors.Core.ComparisonCondition	   	  RightOperand$
 True��5�   D    	  LeftOperand 5�   D   �� *
ShowDialog+5�   D   5�   #   5�      *
  $Microsoft.Xaml.Behaviors.TriggerBase 
  Actions. 5�      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 68   �� *CancelDialogCommand+5�        5�      $  PreviewMouseLeftButtonDown��6-    5�        5�      . 5�   "     . 5�   &   	  $
 True��5�   D    5�   D   �� *ShowConfirmationDialog+5�   D   5�   #   5�      . 5�         68   �� *ConfirmationDialogNoCommand+5�      5�       5�      /  )Microsoft.Xaml.Behaviors.Core.DataTrigger  5�         Value$
 True��6G   :  4Microsoft.Xaml.Behaviors.Core.PropertyChangedTrigger   Binding 6(   �� *
ShowDialog+. 5�      8  2Microsoft.Xaml.Behaviors.Core.ChangePropertyAction      PropertyName$  
Visibility��65   !   Value$! Visible��6O   5�        5�      $ False��6G    6(   �� *
ShowDialog+. 5�        $  
Visibility��65   $! 	Collapsed��6O   5�        5�      $
 True��6S    6(   �� *ShowConfirmationDialog+. 5�        $  
Visibility��65   $! Visible��6O   5�        5�      $ False��6S    6(   �� *ShowConfirmationDialog+. 5�        $  
Visibility��65   $! 	Collapsed��6O   5�      5�      5�      5�      