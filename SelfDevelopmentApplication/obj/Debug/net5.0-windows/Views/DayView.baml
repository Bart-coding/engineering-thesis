   M S B A M L   `   `   `  ����U  QSelfDevelopmentApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:SelfDevelopmentApplication.Models!SelfDevelopmentApplication.Models  5      S.clr-namespace:SelfDevelopmentApplication.Views SelfDevelopmentApplication.Views  5      ]3clr-namespace:SelfDevelopmentApplication.Converters%SelfDevelopmentApplication.Converters  5	      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      .    (SelfDevelopmentApplication.Views.DayView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Bmodels/clr-namespace:SelfDevelopmentApplication.Models     5      @views.clr-namespace:SelfDevelopmentApplication.Views     5      J
converters3clr-namespace:SelfDevelopmentApplication.Converters     5	      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a;	Behaviors+http://schemas.microsoft.com/xaml/behaviors  5
      3system&clr-namespace:System;assembly=mscorlib  5      -   5        $��DefaultDayView��5      
������ .��5      � .+�5   
   � $��15q�6     � ColumnDefinitions  5      �� 5      $��3* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��4* �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $��2��5      $��
10,-20,0,0q�5      .+�5      �� $	�� < ��6   $��15,30,10,30q�5      
������ $
��Bold"�5       $��24(�5!      
�������$��0q�5#      ��5$      �� *NavigateToYesterdayCommand+�� 5%      $��Center=�6   
�������$
��Bold"�5'       �� TextAlignment$ Center=�5(      �� 5)      $��32(�5*      �5)      �� *CurrentDate+ �� StringFormat$ dd MMMM yyyy��5*      �� 5+      �� 5,      $��18(�5-      �5,      �� *CurrentDate+$
 dddd��5-      5.      �� 5/      $	�� > ��6   $��10,30,10,30q�50      
������ $
��Bold"�52      $��24(�53      
�������$��0q�55      ��56      �� *NavigateToTommorowCommand+(  "System.Windows.Controls.DatePicker  57      $��Center=�6   $��0q�59       � Language$ en-us�5:         SelectedDate 58      �� *CurrentDate+ � 	Resources 5;      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType	 �� Property
 �� Value��%Y   '        �� 5<      "  6    .�5=      �� 	 � y�$
 	Collapsed=�6;   5>      5?      5@      �� 5A       �� CornerRadius$ 10��6   $��
10,40,0,40q�5B       �� Padding$ 5q�5C      ���#313e4e._�5E      �� $��
-> to plan��6   $��15(�5F      
�������$
��Bold"�5H      
������ $��8q�5J      $��0q�5K      ��5L      �� *NavigateToPlanVMCommand+5M      ?   9SelfDevelopmentApplication.Views.TasksManagementPanelView  5N      $��
0,25,20,25q�5P   -    � DataContext 5N   1   ��  �� ElementName$ DefaultDayView�� �� Path$ DataContext.TasksPanelVM�5P   -   5Q      �� 5S      $��1��6   $��25,-5,30,40q�5T      
�������$��4q�5V      $ 5��5W      $y�	Collapsed=�5X      ._�5Y      &   System.Windows.Controls.DataGrid     CanUserSortColumns$
 True��5Z         CanUserReorderColumns$
 True��5[         CanUserDeleteRows$
 True��5\         CanUserResizeRows$
 True��5]      ��5Y      �� *	TasksList+5]      5^      �� 5a      $��1��6   $��25,-18,10,0q�5b      $y�Visible=�5c      .+�5d      � $��4,0,0,3q�6    K� ZIndex$	 100��5e        5f      �� 5g      $	��150 �6+   �� 5h      $	��145 �6+   �� 5i      $	��100 �6+   �� 5j      $	��105 �6+   �� 5k      $	��130 �6+   �� 5l      $��* �6+   .+�5o      �� $��0��6   $��4q�5p      $ 15��5q      $ 10q�5r      ���#313e4e._�5t      ��    FilteringTextBoxStyle#��[  6"   $��Center=�5u      
 � Tag$ 	Filter...��5w      ��5v      �� *TasksNamesFilteringText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��5w   .   5x      5y      �� 5z      $��1��6   $��4q�5{      $ 15��5|      $ 10q�5}      ���#313e4e._�5      �� #��[  6"   $��Center=�5�      $ 	Filter...��5�      ��5�      �� * TasksDescriptionsFilteringText+$ TwoWay=�$ PropertyChanged=�.��5�   .   5�      5�      �� 5�      $��2��6!   $ Vertical=�5�   !   $��4q�5�   !   .+�5�      �� $ 15��5�      $ 4q�5�      ���#313e4e._�5�      �� $ 
Horizontal=�6)   $��Center=�5�   )    5�   "   L  FSelfDevelopmentApplication.Converters.TimeTextInputValidator_Converter # HourTextInputValidatorConverter % !MinuteTextInputValidatorConverter��%:   &	       &	        5�   &   6R     5�   &   6R   5�   #   .+�5�   "   �� 
������ $��0q�5�   &   $��13(�5�   &   $
��Bold"�5�   &    �� TextAlignment$ Center=�5�   &   
���������5�   *   �� *FilterFromHour+$ TwoWay=� �� 	Converter# [  �� ConverterParameter$
 Hour��$ PropertyChanged=�5�   &   �� 5�   "   $��:��6,   $��13(�5�   (   $
��Bold"�5�   (   $��Center=�5�   (   $ Center=�5�   (   
�������5�   (   �� 5�   "   
������ $��0q�5�   &   $��13(�5�   &   $
��Bold"�5�   &   $ Center=�5�   &   
���������5�   *   �� *FilterFromMinute+$ TwoWay=�# [ $ Minute��$ PropertyChanged=�5�   &   5�      5�      �� 5�      
�������$��1q�5�   !   $��Center=�5�   !   $��6��5�   !   $��1q�5�   !   �� 5�      $ 15��5�      $ 4q�5�      ���#313e4e._�5�      �� $ 
Horizontal=�6)   $��Center=�5�   )    5�   "   ��%:   &	       &	        5�   &   6R     5�   &   6R   5�   #   .+�5�   "   �� 
������ $��0q�5�   &   $��13(�5�   &   $
��Bold"�5�   &   $ Center=�5�   &   
���������5�   *   �� *FilterToHour+$ TwoWay=�# [ $
 Hour��$ PropertyChanged=�5�   &   �� 5�   "   $��:��6,   $��13(�5�   (   $
��Bold"�5�   (   $��Center=�5�   (   $ Center=�5�   (   
�������5�   (   �� 5�   "   
������ $��0q�5�   &   $��13(�5�   &   $
��Bold"�5�   &   $ Center=�5�   &   
���������5�   *   �� *FilterToMinute+$ TwoWay=�# [ $ Minute��$ PropertyChanged=�5�   &   5�      5�      5�      �� 5�      $��3��6   ���#313e4e$��4q�5�      $ 8q�5�      $ 15��5�      $��55��5�      ._�5�      ��  5�      ��%X   (��       5�   0   *,*SystemParameters.VerticalScrollBarWidthKey+)X�6"   8Q�6q   5�      .��5�      �� .+�5�   "   �� $
��ToDo��6+   $��13(�5�   #   
�������
������  d� 	IsChecked 5�   #   �� *FilterTasksStatusesList[0]+$ TwoWay=�$ PropertyChanged=��� 5�   "   $
��Done��6+   $��13(�5�   #   
�������
������  5�   #   �� *FilterTasksStatusesList[1]+�� 5�   "   $��Failed��6+   $��13(�5�   #   
�������
������  5�   #   �� *FilterTasksStatusesList[2]+5�      5�      5�      �� 5�      $��4��6   ���#313e4e$��4q�5�      $ 8q�5�      $ 15��5�      $��55��5�      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5�      +  %Microsoft.Xaml.Behaviors.EventTrigger  5�         	EventName$ 
MouseEnter��65   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5�   "   2	  ,Microsoft.Xaml.Behaviors.InvokeCommandAction	   	  CommandParameter$
 Open��6�     	  Command  6@   �� *.,ChangeCategoriesFilterPopupVisibilityCommand+6�   5�        5      $ 
MouseLeave��65   . 5  "   	  $ Close��6�     6@   �� *.,ChangeCategoriesFilterPopupVisibilityCommand+6�   5     ._�5     � .+�5     �� #��[  6&   $ 	Filter...��5  "   $
��Left=�5  "   $��Center=�5	  "   ��5  "   �� *TasksCategoriesFilteringText+$ TwoWay=�$ PropertyChanged=�5	  "   � 5     -   5        ! �Name$! FilterCategoriesPopup��5  $   $��Bottom=�5      $��65��5      " � PlacementTarget" 5  C   �� # �� RelativeSource# �� $ �� AncestorType
$ Border��5      �� *!IsCategoriesFilterPopupVisibile+ 5  "     5  &   $ 
MouseEnter��6=   . 5  *   	  $
 Open��6�     6H   �� *.,ChangeCategoriesFilterPopupVisibilityCommand+6�   5  '     5  &   $ 
MouseLeave��6=   . 5  *   	  $ Close��6�     6H   �� *.,ChangeCategoriesFilterPopupVisibilityCommand+6�   5  '   .��5  "   �� $
��True��6/   ���#313e4e$	��118��5  +    5  &   ��%X   (��       5  8   *,*SystemParameters.VerticalScrollBarWidthKey+)X�6*   8Q�6y   5  '   .��5  &   �� ��63   �� *%#DataContext.TasksCategoriesViewList+$ DefaultDayView����5  *   �� 5  .   % �� DataType9
  3SelfDevelopmentApplication.Models.TaskCategoryModel"% 
 6;   .R�5   2   �� & ��Name$& FilterCategoriesCheckBox��6;   $��13(�5"  3   
�������
������ $
 TrueY�5%  3   ��5!  3   �� *Name+ 5&  6     5'  :   /  )Microsoft.Xaml.Behaviors.EventTriggerBase'   
SourceName$' FilterCategoriesCheckBox��6Q   $ Checked��6w   . 5(  >   	    6\   �� *!DataContext.FilterCheckCategory+$ DefaultDayView�� 5)  T   �� 5*  ;     5+  :   $' FilterCategoriesCheckBox��6Q   $ 	Unchecked��6w   . 5,  >   	    6\   �� *!DataContext.FilterCheckCategory+$ DefaultDayView�� 5-  T   �� 5.  ;   50  3   51  /   53  '   54  #   55     56     57     �� 59     $��5��6   ���#313e4e$��4q�5;     $ 6q�5<     $ 15��5=     $��55��5>     ._�5?     ��  5@     ��%X   (��       5A  0   *,*SystemParameters.VerticalScrollBarWidthKey+)X�6"   8Q�6q   5B     .��5C     �� .+�5D  "   �� $��
Imp-Urgent��6+   $��10(�5E  #   
�������
������  5H  #   �� *FilterTasksPrioritiesList[0]+�� 5I  "   $��Imp-N-Urgent��6+   $��10(�5J  #   
�������
������  5M  #   �� *FilterTasksPrioritiesList[1]+�� 5N  "   $��N-Imp-Urgent��6+   $��10(�5O  #   
�������
������  5R  #   �� *FilterTasksPrioritiesList[2]+�� 5S  "   $��N-Imp-N-Urgent��6+   $��10(�5T  #   
�������
������  5W  #   �� *FilterTasksPrioritiesList[3]+5X     5Y     5Z     5\     �� 5^     
�������$��4q�5_     $ 5��5`     $��Stretch=�5a     $��Stretch=�5b     $	��415��5c     ._�5e     � .+�5f       -   5        $��TasksListDataGrid��5f  #   (   AutoGenerateColumns$( False��5i  #   $ False��5j  #   )   CanUserResizeColumns$) False��5k  #   $ False��5l  #   *   CanUserAddRows$* False��5m  #   $ False��5n  #   $ False��5o  #   +   
IsReadOnly$
+ True��5p  #   
������ ",   VerticalScrollBarVisibility$, Visible=�5r  #   -   EnableRowVirtualization$- False��5s  #   $
��True��5t  #     TasksListDataGridStyle#��[ 5w  #    & "TasksListDataGridColumnHeaderStyle.   ColumnHeaderStyle#. [ 5x  #     TasksListDataGridRowStyle/   RowStyle#/ [ 5y  #     TasksListDataGridCellStyle0   	CellStyle#0 [ 5z  #    5g  #   �� *DataContext.TasksPanelVM+$ DefaultDayView����5h  #   �� *DataContext.TasksList+$ DefaultDayView����5u  #   �� *ActualWidth+# �� 
$ Border��5v  #   �� *ActualHeight+# �� 
$ Border1   Columns1 5{     0  *System.Windows.Controls.DataGridTextColumn  5|  "   -   5        
NameColumn��,  &System.Windows.Controls.DataGridColumn2   Header$2 TaskName��5}  5   3   Width5  /System.Windows.Controls.DataGridLengthConverter$	3 150 5~  5   1  +System.Windows.Controls.DataGridBoundColumn4   Binding4 5  5   �� *Name+  TextShortenerConverter# [ $ 17��  5�  "   $2 Description��65   $	3 145 5�  5   5   FontSize$5 13Q�5�  5   6   SortMemberPath$6 Description��5�  5   4 5�  5   �� *Description+# [ $ 18��  5�  "   $
2 Time��65   $	3 100 5�  5   $5 13Q�5�  5   4 5�  5   �� *AssignedDateTime+$ HH:mm��  5�  "   $2 Status��65   $	3 105 5�  5   $5 13Q�5�  5   4 5�  5   �� *Status+  5�  "   $2 Category��65   $	3 130 5�  5   $5 13Q�5�  5   4 5�  5   �� *Category.Name+# [ $ 14��  5�  "   $2 Priority��65   $3 * 5�  5   $5 11Q�5�  5   4 5�  5   �� *
Priority+7   	CellStyle7 5�  &   �� 5�  *   *  $System.Windows.Controls.DataGridCell"  60   8 �� BasedOn#8 [ 6S   .�5�  .   �� 	 �@�Tag$
 Priority��6D   9 �� Triggers9 5�  .   �� 5�  2   : �� Binding: 6>   �� *
Priority+; �� Value; 06[   .a�5�  6   �� 	 � ��

 � ���6S   5�  3   �� 5�  2   : 6>   �� *
Priority+; 16[   .a�5�  6   �� 	 � ��

 � ���6S   5�  3   �� 5�  2   : 6>   �� *
Priority+; 26[   .a�5�  6   �� 	 � ��

 �� ��6S   5�  3   �� 5�  2   : 6>   �� *
Priority+; 36[   .a�5�  6   �� 	 � ��

 �����6S   5�  3   5�  +   5�  #   5�     �� 5�     $��Center=�6$   $��Center=�5�  $   $!��There are no tasks on list!��5�  $   $��40(�5�  $   $
��Bold"�5�  $   
�������y�5�  $   �� $ TasksListDataGrid��$	 Tag�5�     5�     5�     5�     �� 5�     $��1��6   $��1��5�     $��Center=�5�     $��	0,30,40,0q�5�     .+�5�     :   4SelfDevelopmentApplication.Views.MoodStatusPanelView   6,   �� *DataContext.MoodStatusPanelVM+$ DefaultDayView��y�5�  ,   �� *&$DataContext.IsCurrentDayNotFutureDay+$ DefaultDayView��  BoolToVisConverter# [ �� 5�     $ 20��6   $ 20q�5�     ���#f3efe9$��Center=�5�     $��Bottom=�5�     ._�5�     �� $��NOTES��6   $��25(�5�     $
��Bold"�5�     
������ $��0q�5�     ��5�     �� *NavigateToNotesVMCommand+5�     5�     5�     /   )SelfDevelopmentApplication.Views.TaskView  5�  
   $ 2��5�      5�     �� $ DefaultDayView��$ DataContext.TasksPanelVM�y�5�     �� $ ShowTaskDialog�# [ =   7SelfDevelopmentApplication.Views.ConfirmationDialogView  5�  
   $ 2��5�  '   $&  Are you sure you want to delete?��5�  '    5�  '   �� $ DefaultDayView��$ DataContext.TasksPanelVM�y�5�  '   �� $ ShowConfirmationDialog�# [ 5�  '   5   /SelfDevelopmentApplication.Views.MessageBoxView  5�  
   $ 2��5�     $* $Succeed! Task lists will be updated.��5�      5�     �� $ DefaultDayView��$ DataContext.TasksPanelVM�y�5�     �� $ ShowMessageBox�# [ 5�     � 5�  
   $y�	Collapsed=�5�     $ 1��5�     
���   �< J� Opacity$	< 0.5Q�5�      5�     �� $ DefaultDayView��$ DataContext.TasksPanelVM�.+�5�     �� 
������  5�       5�     $  PreviewMouseLeftButtonDown��6-   =   	Behaviors= 5�     5  /Microsoft.Xaml.Behaviors.Core.ConditionBehavior  5�     >   	Condition.> 5�  "   9  3Microsoft.Xaml.Behaviors.Core.ConditionalExpression  ?   
Conditions.? 5�  &   7  1Microsoft.Xaml.Behaviors.Core.ComparisonCondition  @   RightOperand$
@ True��5�  D   A   LeftOperandA 5�  D   �� *ShowTaskDialog+5�  D   5�  #   5�     . 5�     	    68   �� *CancelTaskDialogCommand+5�       5�     $  PreviewMouseLeftButtonDown��6-   = 5�       5�     .> 5�  "     .? 5�  &     $
@ True��5�  D   A 5�  D   �� *ShowConfirmationDialog+5�  D   5�  #   5�     . 5     	    68   �� *ConfirmationDialogNoCommand+5     5      5     /  )Microsoft.Xaml.Behaviors.Core.DataTrigger  5     B   Value$
B True��6K   :  4Microsoft.Xaml.Behaviors.Core.PropertyChangedTriggerC   BindingC 6(   �� *ShowTaskDialog+. 5     8  2Microsoft.Xaml.Behaviors.Core.ChangePropertyAction  D   PropertyName$D 
Visibility��65   E   Value$E Visible��6O   5       5	     $B False��6K   C 6(   �� *ShowTaskDialog+. 5
       $D 
Visibility��65   $E 	Collapsed��6O   5       5     $
B True��6S   C 6(   �� *ShowConfirmationDialog+. 5       $D 
Visibility��65   $E Visible��6O   5       5     $B False��6S   C 6(   �� *ShowConfirmationDialog+. 5       $D 
Visibility��65   $E 	Collapsed��6O   5     5     5     5     