   M S B A M L   `   `   `  ����U  QSelfDevelopmentApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:SelfDevelopmentApplication.Views SelfDevelopmentApplication.Views  5      :    4SelfDevelopmentApplication.Views.TasksCategoriesView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @views.clr-namespace:SelfDevelopmentApplication.Views     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a;	Behaviors+http://schemas.microsoft.com/xaml/behaviors  5      -   5        $ ��DefaultTasksCategoriesView��5      
������ .��5      � .+�5   
   � -   5          �Name$  MainGrid��5      $��
30,0,25,35q�5       � RowDefinitions 5      �� 5      $��* �6    �� 5      $��4* �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�5      $��Center=�5      .+�5      �� $��Edit task categories��6   $��50(�5      $
��Bold"�5      
�������$��Center=�5      $��	0,0,15,10q�5      �� 5       �� CornerRadius$ 15��6   $��
0,20,10,20q�5       �� Padding$ 15q�5      ���#313e4e._�5       �� $��
+ category��6   
�������$��20(�5"      $
��Bold"�5#      
������ $��0q�5%      ��5&      �� *AddCategoryCommand+5'      �� 5(      $ 15��6   $��
0,20,20,20q�5)      $ 15q�5*      ���#313e4e._�5,      ��    FilteringTextBoxStyle#��[  6   $��Center=�5-      
 � Tag$ Filter categories��5/      ��5.      �� *FilteringText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5/      50      51      �� 53      $��1��6   .+�54      �� $
��Auto=�6   ��55      �� *ActualHeight+ �� RelativeSource �� 	 �� AncestorType	 
StackPanel.��56      �� 
������ $��0q�59      ��57      �� *TasksCategories+��5:      �� 5;      .R�5<   "   � ��6,   �� *ActualWidth+
 �� ElementName$
 MainGrid��5>      ��5A      �� 5B      .R�5C   "   �� $ 15��6)   $��10q�5D      $ 16q�5E      ���#516580._�5G   &   �� 
�������$��27(�5I   )   $
��Bold"�5J   )   
������ $��0q�5L   )   ��5G   -   �� *Name+  TextShortenerConverter �� 	Converter# [  �� ConverterParameter$ 12����5M   )   �� *#!DataContext.SelectCategoryCommand+$ 
 DefaultTasksCategoriesView����5O   )   ��  J� InputBindings 5P   *   d� 5Q   .    d� MouseAction$ 
RightClicke�6;    �� Command 5R   3   �� *#!DataContext.DeleteCategoryCommand+$ 
 DefaultTasksCategoriesView�� �� CommandParameter 5T   3   �� 5V   '   5W   #   5X      5Z      5[      5\      5^      7   1SelfDevelopmentApplication.Views.CategoryNameView  5`   
    K� ZIndex$ 2��6!   $��-100,-140,0,0q�5a   !   y�5b   !   �� *
ShowDialog+  BoolToVisConverter# [ =   7SelfDevelopmentApplication.Views.ConfirmationDialogView  5d   
   $ 2��6'   $��-100,-140,0,0q�5e   '   $V PAre you sure you want to delete? This will also delete tasks from this category!��5h   '   y�5f   '   �� *ShowConfirmationDialog+# [ 5h   '   5   /SelfDevelopmentApplication.Views.MessageBoxView  5i   
   $ 2��6   $��-100,-140,0,0q�5j      $/ )Succeed! Categories list will be updated.��5m      y�5k      �� *ShowMessageBox+# [ 5m      � 5o   
   $y�	Collapsed=�6   $ 1��5p      
���   � J� Opacity$	 0.3Q�5r      .+�5s      �� 
������ *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5t      +  %Microsoft.Xaml.Behaviors.EventTrigger  5u         	EventName$  PreviewMouseLeftButtonDown��6-      	Behaviors 5v      5  /Microsoft.Xaml.Behaviors.Core.ConditionBehavior  5w         	Condition. 5x   "   9  3Microsoft.Xaml.Behaviors.Core.ConditionalExpression     
Conditions. 5y   &   7  1Microsoft.Xaml.Behaviors.Core.ComparisonCondition     RightOperand$
 True��5z   D      LeftOperand 5y   D   �� *
ShowDialog+5z   D   5{   #   5|      *	  $Microsoft.Xaml.Behaviors.TriggerBase 	  Actions. 5      2
  ,Microsoft.Xaml.Behaviors.InvokeCommandAction
   
  Command 68   �� *CancelDialogCommand+5�        5�      $  PreviewMouseLeftButtonDown��6-    5�        5�      . 5�   "     . 5�   &     $
 True��5�   D    5�   D   �� *ShowConfirmationDialog+5�   D   5�   #   5�      . 5�      
   68   �� *ConfirmationDialogNoCommand+5�      5�       5�      /  )Microsoft.Xaml.Behaviors.Core.DataTrigger  5�         Value$
 True��6G   :  4Microsoft.Xaml.Behaviors.Core.PropertyChangedTrigger   Binding 6(   �� *
ShowDialog+. 5�      8  2Microsoft.Xaml.Behaviors.Core.ChangePropertyAction     PropertyName$ 
Visibility��65      Value$ Visible��6O   5�        5�      $ False��6G    6(   �� *
ShowDialog+. 5�        $ 
Visibility��65   $ 	Collapsed��6O   5�        5�      $
 True��6S    6(   �� *ShowConfirmationDialog+. 5�        $ 
Visibility��65   $ Visible��6O   5�        5�      $ False��6S    6(   �� *ShowConfirmationDialog+. 5�        $ 
Visibility��65   $ 	Collapsed��6O   5�      5�      5�      5�      