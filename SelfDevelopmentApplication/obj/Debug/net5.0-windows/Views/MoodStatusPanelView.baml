   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5       SelfDevelopmentApplication:   4SelfDevelopmentApplication.Views.MoodStatusPanelView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a;	Behaviors+http://schemas.microsoft.com/xaml/behaviors  5      3system&clr-namespace:System;assembly=mscorlib  5      .��5
      �� $��Stretch=�6   .+�5   
   �� $��Center=�6   $��	Gratitude��5      $��30(�5      $��Comic Sans MS)�5      
�������
������ 5      �� 5   
     �� Orientation$  
Horizontal=�6   $��Center=�6.   $��0,-5,0,0q�5      $��50��5      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ 
MouseLeave��6)   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 64   �� *ChangeMoodStarsCommand+5      .+�5      �� -   5         ��Name$ Gratitude_Star1��5      $��Center=�61   $��*��5      $��38(�5       $��Comic Sans MS)�5!      
�������
������  �� Padding$ 8,5,5,5q�5$       5%      /  )Microsoft.Xaml.Behaviors.Core.DataTrigger  5'         Value$
 True��6q   :  4Microsoft.Xaml.Behaviors.Core.PropertyChangedTrigger   Binding 64   �� *IsMouseOver+	 �� ElementName$	 Gratitude_Star1��. 5(   "     
   CommandParameter$
 	Gratitude��5)   <    5(   @   �� *ChangeCurrentMoodProperty+5)   <     5*   "    6@   �� *ChangeMoodStarsCommand+
 5+   &   ��5,   *   0��6:   5.   #   50        52      $
 True��6u    64   �� *-+MoodStatusStarsListDictionary[Gratitude][0]+. 53   "   8  2Microsoft.Xaml.Behaviors.Core.ChangePropertyAction     PropertyName$ 
Foreground��6A      Value$
 Gold��6[   54        56      $ False��6u    64   �� *-+MoodStatusStarsListDictionary[Gratitude][0]+. 57   "     $ 
Foreground��6A   $ Black��6[   58        5:      $  PreviewMouseLeftButtonDown��65   . 5;   "      6@   �� *ChangeMoodStatusCommand+
 5<   &   ��5=   *   0��6:   5?   #   5@      5C      �� 5D      -   5        $ Gratitude_Star2��5D      $��Center=�61   $��*��5E      $��38(�5F      $��Comic Sans MS)�5G      
�������
������ $ 5q�5J       5K        5M      $
 True��6q    64   �� *IsMouseOver+$	 Gratitude_Star2��. 5N   "     $
 	Gratitude��5O   <    5N   @   �� *ChangeCurrentMoodProperty+5O   <     5P   "    6@   �� *ChangeMoodStarsCommand+
 5Q   &   ��5R   *   1��6:   5T   #   5V        5X      $
 True��6u    64   �� *-+MoodStatusStarsListDictionary[Gratitude][1]+. 5Y   "     $ 
Foreground��6A   $
 Gold��6[   5Z        5\      $ False��6u    64   �� *-+MoodStatusStarsListDictionary[Gratitude][1]+. 5]   "     $ 
Foreground��6A   $ Black��6[   5^        5`      $  PreviewMouseLeftButtonDown��65   . 5a   "      6@   �� *ChangeMoodStatusCommand+
 5b   &   ��5c   *   1��6:   5e   #   5f      5i      �� 5j      -   5        $ Gratitude_Star3��5j      $��Center=�61   $��*��5k      $��38(�5l      $��Comic Sans MS)�5m      
�������
������ $ 5q�5p       5q        5s      $
 True��6q    64   �� *IsMouseOver+$	 Gratitude_Star3��. 5t   "     $
 	Gratitude��5u   <    5t   @   �� *ChangeCurrentMoodProperty+5u   <     5v   "    6@   �� *ChangeMoodStarsCommand+
 5w   &   ��5x   *   2��6:   5z   #   5|        5~      $
 True��6u    64   �� *-+MoodStatusStarsListDictionary[Gratitude][2]+. 5   "     $ 
Foreground��6A   $
 Gold��6[   5�        5�      $ False��6u    64   �� *-+MoodStatusStarsListDictionary[Gratitude][2]+. 5�   "     $ 
Foreground��6A   $ Black��6[   5�        5�      $  PreviewMouseLeftButtonDown��65   . 5�   "      6@   �� *ChangeMoodStatusCommand+
 5�   &   ��5�   *   2��6:   5�   #   5�      5�      �� 5�      -   5        $ Gratitude_Star4��5�      $��Center=�61   $��*��5�      $��38(�5�      $��Comic Sans MS)�5�      
�������
������ $ 5q�5�       5�        5�      $
 True��6q    64   �� *IsMouseOver+$	 Gratitude_Star4��. 5�   "     $
 	Gratitude��5�   <    5�   @   �� *ChangeCurrentMoodProperty+5�   <     5�   "    6@   �� *ChangeMoodStarsCommand+
 5�   &   ��5�   *   3��6:   5�   #   5�        5�      $
 True��6u    64   �� *-+MoodStatusStarsListDictionary[Gratitude][3]+. 5�   "     $ 
Foreground��6A   $
 Gold��6[   5�        5�      $ False��6u    64   �� *-+MoodStatusStarsListDictionary[Gratitude][3]+. 5�   "     $ 
Foreground��6A   $ Black��6[   5�        5�      $  PreviewMouseLeftButtonDown��65   . 5�   "      6@   �� *ChangeMoodStatusCommand+
 5�   &   ��5�   *   3��6:   5�   #   5�      5�      �� 5�      -   5        $ Gratitude_Star5��5�      $��Center=�61   $��*��5�      $��38(�5�      $��Comic Sans MS)�5�      
�������
������ $ 5,5,8,5q�5�       5�        5�      $
 True��6q    64   �� *IsMouseOver+$	 Gratitude_Star5��. 5�   "     $
 	Gratitude��5�   <    5�   @   �� *ChangeCurrentMoodProperty+5�   <     5�   "    6@   �� *ChangeMoodStarsCommand+
 5�   &   ��5�   *   4��6:   5�   #   5�        5�      $
 True��6u    64   �� *-+MoodStatusStarsListDictionary[Gratitude][4]+. 5�   "     $ 
Foreground��6A   $
 Gold��6[   5�        5�      $ False��6u    64   �� *-+MoodStatusStarsListDictionary[Gratitude][4]+. 5�   "     $ 
Foreground��6A   $ Black��6[   5�        5�      $  PreviewMouseLeftButtonDown��65   . 5�   "      6@   �� *ChangeMoodStatusCommand+
 5�   &   ��5�   *   4��6:   5�   #   5�      5�      5�      �� 5�   
   $��Center=�6   $	��Joy��5�      $��30(�5�      $��Comic Sans MS)�5�      
�������
������ 5�      �� 5�   
   $  
Horizontal=�6   $��Center=�6.   $��0,-5,0,0q�5�      $��50��5�       5�        5�      $ 
MouseLeave��6)   . 5�         64   �� *ChangeMoodStarsCommand+5�      .+�5�      �� -   5        $ 	Joy_Star1��5�      $��Center=�6+   $��*��5�      $��38(�5�      $��Comic Sans MS)�5�      
�������
������ $ 8,5,5,5q�5�       5�        5�      $
 True��6k    64   �� *IsMouseOver+$	 	Joy_Star1��. 5�   "     $	
 Joy��5�   @    5�   @   �� *ChangeCurrentMoodProperty+5�   @     5�   "    6@   �� *ChangeMoodStarsCommand+
 5�   &   ��5�   *   0��6:   5�   #   5       5     $
 True��6o    64   �� *'%MoodStatusStarsListDictionary[Joy][0]+. 5  "     $ 
Foreground��6A   $
 Gold��6[   5       5     $ False��6o    64   �� *'%MoodStatusStarsListDictionary[Joy][0]+. 5  "     $ 
Foreground��6A   $ Black��6[   5	       5     $  PreviewMouseLeftButtonDown��65   . 5  "      6@   �� *ChangeMoodStatusCommand+
 5  &   ��5  *   0��6:   5  #   5     5     �� 5     -   5        $ 	Joy_Star2��5     $��Center=�6+   $��*��5     $��38(�5     $��Comic Sans MS)�5     
�������
������ $ 5q�5      5       5     $
 True��6k    64   �� *IsMouseOver+$	 	Joy_Star2��. 5  "     $	
 Joy��5   @    5  @   �� *ChangeCurrentMoodProperty+5   @     5!  "    6@   �� *ChangeMoodStarsCommand+
 5"  &   ��5#  *   1��6:   5%  #   5'       5)     $
 True��6o    64   �� *'%MoodStatusStarsListDictionary[Joy][1]+. 5*  "     $ 
Foreground��6A   $
 Gold��6[   5+       5-     $ False��6o    64   �� *'%MoodStatusStarsListDictionary[Joy][1]+. 5.  "     $ 
Foreground��6A   $ Black��6[   5/       51     $  PreviewMouseLeftButtonDown��65   . 52  "      6@   �� *ChangeMoodStatusCommand+
 53  &   ��54  *   1��6:   56  #   57     5:     �� 5;     -   5        $ 	Joy_Star3��5;     $��Center=�6+   $��*��5<     $��38(�5=     $��Comic Sans MS)�5>     
�������
������ $ 5q�5A      5B       5D     $
 True��6k    64   �� *IsMouseOver+$	 	Joy_Star3��. 5E  "     $	
 Joy��5F  @    5E  @   �� *ChangeCurrentMoodProperty+5F  @     5G  "    6@   �� *ChangeMoodStarsCommand+
 5H  &   ��5I  *   2��6:   5K  #   5M       5O     $
 True��6o    64   �� *'%MoodStatusStarsListDictionary[Joy][2]+. 5P  "     $ 
Foreground��6A   $
 Gold��6[   5Q       5S     $ False��6n    64   �� *'%MoodStatusStarsListDictionary[Joy][2]+. 5T  "     $ 
Foreground��6A   $ Black��6[   5U       5W     $  PreviewMouseLeftButtonDown��65   . 5X  "      6@   �� *ChangeMoodStatusCommand+
 5Y  &   ��5Z  *   2��6:   5\  #   5]     5`     �� 5a     -	   5        $ 	Joy_Star4��5a     $��Center=�6+   $��*��5b     $��38(�5c     $��Comic Sans MS)�5d     
�������
������ $ 5q�5g      5h       5j     $
 True��6k    64   �� *IsMouseOver+$	 	Joy_Star4��. 5k  "     $	
 Joy��5l  @    5k  @   �� *ChangeCurrentMoodProperty+5l  @     5m  "    6@   �� *ChangeMoodStarsCommand+
 5n  &   ��5o  *   3��6:   5q  #   5s       5u     $
 True��6o    64   �� *'%MoodStatusStarsListDictionary[Joy][3]+. 5v  "     $ 
Foreground��6A   $
 Gold��6[   5w       5y     $ False��6o    64   �� *'%MoodStatusStarsListDictionary[Joy][3]+. 5z  "     $ 
Foreground��6A   $ Black��6[   5{       5}     $  PreviewMouseLeftButtonDown��65   . 5~  "      6@   �� *ChangeMoodStatusCommand+
 5  &   ��5�  *   3��6:   5�  #   5�     5�     �� 5�     -
   5        $ 	Joy_Star5��5�     $��Center=�6+   $��*��5�     $��38(�5�     $��Comic Sans MS)�5�     
�������
������ $ 5,5,8,5q�5�      5�       5�     $
 True��6k    64   �� *IsMouseOver+$	 	Joy_Star5��. 5�  "     $	
 Joy��5�  @    5�  @   �� *ChangeCurrentMoodProperty+5�  @     5�  "    6@   �� *ChangeMoodStarsCommand+
 5�  &   ��5�  *   4��6:   5�  #   5�       5�     $
 True��6o    64   �� *'%MoodStatusStarsListDictionary[Joy][4]+. 5�  "     $ 
Foreground��6A   $
 Gold��6[   5�       5�     $ False��6o    64   �� *'%MoodStatusStarsListDictionary[Joy][4]+. 5�  "     $ 
Foreground��6A   $ Black��6[   5�       5�     $  PreviewMouseLeftButtonDown��65   . 5�  "      6@   �� *ChangeMoodStatusCommand+
 5�  &   ��5�  *   4��6:   5�  #   5�     5�     5�     �� 5�  
   $��Center=�6   $��Stress��5�     $��30(�5�     $��Comic Sans MS)�5�     
�������
������ 5�     �� 5�  
   $  
Horizontal=�6   $��Center=�6.   $��0,-5,0,0q�5�     $��50��5�      5�       5�     $ 
MouseLeave��6)   . 5�        64   �� *ChangeMoodStarsCommand+5�     .+�5�     �� -   5        $ Stress_Star1��5�     $��Center=�6.   $��*��5�     $��38(�5�     $��Comic Sans MS)�5�     
�������
������ $ 8,5,5,5q�5�      5�       5�     $
 True��6n    64   �� *IsMouseOver+$	 Stress_Star1��. 5�  "     $
 Stress��5�  @    5�  @   �� *ChangeCurrentMoodProperty+5�  @     5�  "    6@   �� *ChangeMoodStarsCommand+
 5�  &   ��5�  *   0��6:   5�  #   5�       5�     $
 True��6r    64   �� **(MoodStatusStarsListDictionary[Stress][0]+. 5�  "     $ 
Foreground��6A   $
 Gold��6[   5�       5�     $ False��6r    64   �� **(MoodStatusStarsListDictionary[Stress][0]+. 5�  "     $ 
Foreground��6A   $ Black��6[   5�       5�     $  PreviewMouseLeftButtonDown��65   . 5�  "      6@   �� *ChangeMoodStatusCommand+
 5�  &   ��5�  *   0��6:   5�  #   5�     5�     �� 5�     -   5        $ Stress_Star2��5�     $��Center=�6.   $��*��5�     $��38(�5�     $��Comic Sans MS)�5�     
�������
������ $ 5q�5�      5�       5�     $
 True��6n    64   �� *IsMouseOver+$	 Stress_Star2��. 5�  "     $
 Stress��5�  @    5�  @   �� *ChangeCurrentMoodProperty+5�  @     5�  "    6@   �� *ChangeMoodStarsCommand+
 5�  &   ��5�  *   1��6:   5�  #   5�       5�     $
 True��6r    64   �� **(MoodStatusStarsListDictionary[Stress][1]+. 5�  "     $ 
Foreground��6A   $
 Gold��6[   5�       5�     $ False��6q    64   �� **(MoodStatusStarsListDictionary[Stress][1]+. 5�  "     $ 
Foreground��6A   $ Black��6[   5�       5      $  PreviewMouseLeftButtonDown��65   . 5  "      6@   �� *ChangeMoodStatusCommand+
 5  &   ��5  *   1��6:   5  #   5     5	     �� 5
     -   5        $ Stress_Star3��5
     $��Center=�6.   $��*��5     $��38(�5     $��Comic Sans MS)�5     
�������
������ $ 5q�5      5       5     $
 True��6n    64   �� *IsMouseOver+$	 Stress_Star3��. 5  "     $
 Stress��5  @    5  @   �� *ChangeCurrentMoodProperty+5  @     5  "    6@   �� *ChangeMoodStarsCommand+
 5  &   ��5  *   2��6:   5  #   5       5     $
 True��6r    64   �� **(MoodStatusStarsListDictionary[Stress][2]+. 5  "     $ 
Foreground��6A   $
 Gold��6[   5       5!     $ False��6q    64   �� **(MoodStatusStarsListDictionary[Stress][2]+. 5"  "     $ 
Foreground��6A   $ Black��6[   5#       5%     $  PreviewMouseLeftButtonDown��65   . 5&  "      6@   �� *ChangeMoodStatusCommand+
 5'  &   ��5(  *   2��6:   5*  #   5+     5.     �� 5/     -   5        $ Stress_Star4��5/     $��Center=�6.   $��*��50     $��38(�51     $��Comic Sans MS)�52     
�������
������ $ 5q�55      56       57     $
 True��6n    64   �� *IsMouseOver+$	 Stress_Star4��. 58  "     $
 Stress��59  @    58  @   �� *ChangeCurrentMoodProperty+59  @     5:  "    6@   �� *ChangeMoodStarsCommand+
 5;  &   ��5<  *   3��6:   5>  #   5@       5B     $
 True��6r    64   �� **(MoodStatusStarsListDictionary[Stress][3]+. 5C  "     $ 
Foreground��6A   $
 Gold��6[   5D       5F     $ False��6r    64   �� **(MoodStatusStarsListDictionary[Stress][3]+. 5G  "     $ 
Foreground��6A   $ Black��6[   5H       5J     $  PreviewMouseLeftButtonDown��65   . 5K  "      6@   �� *ChangeMoodStatusCommand+
 5L  &   ��5M  *   3��6:   5O  #   5P     5S     �� 5T     -   5        $ Stress_Star5��5T     $��Center=�6.   $��*��5U     $��38(�5V     $��Comic Sans MS)�5W     
�������
������ $ 5,5,8,5q�5Z      5[       5\     $
 True��6n    64   �� *IsMouseOver+$	 Stress_Star5��. 5]  "     $
 Stress��5^  @    5]  @   �� *ChangeCurrentMoodProperty+5^  @     5_  "    6@   �� *ChangeMoodStarsCommand+
 5`  &   ��5a  *   4��6:   5c  #   5e       5g     $
 True��6r    64   �� **(MoodStatusStarsListDictionary[Stress][4]+. 5h  "     $ 
Foreground��6A   $
 Gold��6[   5i       5k     $ False��6r    64   �� **(MoodStatusStarsListDictionary[Stress][4]+. 5l  "     $ 
Foreground��6A   $ Black��6[   5m       5o     $  PreviewMouseLeftButtonDown��65   . 5p  "      6@   �� *ChangeMoodStatusCommand+
 5q  &   ��5r  *   4��6:   5t  #   5u     5x     5y     �� 5{  
   $��Center=�6   $��Anger��5|     $��30(�5}     $��Comic Sans MS)�5~     
�������
������ 5�     �� 5�  
   $  
Horizontal=�6   $��Center=�6.   $��0,-5,0,0q�5�     $��50��5�      5�       5�     $ 
MouseLeave��6)   . 5�        64   �� *ChangeMoodStarsCommand+5�     .+�5�     �� -   5        $ Anger_Star1��5�     $��Center=�6-   $��*��5�     $��38(�5�     $��Comic Sans MS)�5�     
�������
������ $ 8,5,5,5q�5�      5�       5�     $
 True��6m    64   �� *IsMouseOver+$	 Anger_Star1��. 5�  "     $
 Anger��5�  @    5�  @   �� *ChangeCurrentMoodProperty+5�  @     5�  "    6@   �� *ChangeMoodStarsCommand+
 5�  &   ��5�  *   0��6:   5�  #   5�       5�     $
 True��6q    64   �� *)'MoodStatusStarsListDictionary[Anger][0]+. 5�  "     $ 
Foreground��6A   $
 Gold��6[   5�       5�     $ False��6q    64   �� *)'MoodStatusStarsListDictionary[Anger][0]+. 5�  "     $ 
Foreground��6A   $ Black��6[   5�       5�     $  PreviewMouseLeftButtonDown��65   . 5�  "      6@   �� *ChangeMoodStatusCommand+
 5�  &   ��5�  *   0��6:   5�  #   5�     5�     �� 5�     -   5        $ Anger_Star2��5�     $��Center=�6-   $��*��5�     $��38(�5�     $��Comic Sans MS)�5�     
�������
������ $ 5q�5�      5�       5�     $
 True��6m    64   �� *IsMouseOver+$	 Anger_Star2��. 5�  "     $
 Anger��5�  @    5�  @   �� *ChangeCurrentMoodProperty+5�  @     5�  "    6@   �� *ChangeMoodStarsCommand+
 5�  &   ��5�  *   1��6:   5�  #   5�       5�     $
 True��6q    64   �� *)'MoodStatusStarsListDictionary[Anger][1]+. 5�  "     $ 
Foreground��6A   $
 Gold��6[   5�       5�     $ False��6q    64   �� *)'MoodStatusStarsListDictionary[Anger][1]+. 5�  "     $ 
Foreground��6A   $ Black��6[   5�       5�     $  PreviewMouseLeftButtonDown��65   . 5�  "      6@   �� *ChangeMoodStatusCommand+
 5�  &   ��5�  *   1��6:   5�  #   5�     5�     �� 5�     -   5        $ Anger_Star3��5�     $��Center=�6-   $��*��5�     $��38(�5�     $��Comic Sans MS)�5�     
�������
������ $ 5q�5�      5�       5�     $
 True��6m    64   �� *IsMouseOver+$	 Anger_Star3��. 5�  "     $
 Anger��5�  @    5�  @   �� *ChangeCurrentMoodProperty+5�  @     5�  "    6@   �� *ChangeMoodStarsCommand+
 5�  &   ��5�  *   2��6:   5�  #   5�       5�     $
 True��6q    64   �� *)'MoodStatusStarsListDictionary[Anger][2]+. 5�  "     $ 
Foreground��6A   $
 Gold��6[   5�       5�     $ False��6q    64   �� *)'MoodStatusStarsListDictionary[Anger][2]+. 5�  "     $ 
Foreground��6A   $ Black��6[   5�       5�     $  PreviewMouseLeftButtonDown��65   . 5�  "      6@   �� *ChangeMoodStatusCommand+
 5�  &   ��5�  *   2��6:   5�  #   5�     5�     �� 5�     -   5        $ Anger_Star4��5�     $��Center=�6-   $��*��5�     $��38(�5      $��Comic Sans MS)�5     
�������
������ $ 5q�5      5       5     $
 True��6m    64   �� *IsMouseOver+$	 Anger_Star4��. 5  "     $
 Anger��5	  @    5  @   �� *ChangeCurrentMoodProperty+5	  @     5
  "    6@   �� *ChangeMoodStarsCommand+
 5  &   ��5  *   3��6:   5  #   5       5     $
 True��6q    64   �� *)'MoodStatusStarsListDictionary[Anger][3]+. 5  "     $ 
Foreground��6A   $
 Gold��6[   5       5     $ False��6q    64   �� *)'MoodStatusStarsListDictionary[Anger][3]+. 5  "     $ 
Foreground��6A   $ Black��6[   5       5     $  PreviewMouseLeftButtonDown��65   . 5  "      6@   �� *ChangeMoodStatusCommand+
 5  &   ��5  *   3��6:   5  #   5      5#     �� 5$     -   5        $ Anger_Star5��5$     $��Center=�6-   $��*��5%     $��38(�5&     $��Comic Sans MS)�5'     
�������
������ $ 5,5,8,5q�5*      5+       5-     $
 True��6m    64   �� *IsMouseOver+$	 Anger_Star5��. 5.  "     $
 Anger��5/  @    5.  @   �� *ChangeCurrentMoodProperty+5/  @     50  "    6@   �� *ChangeMoodStarsCommand+
 51  &   ��52  *   4��6:   54  #   56       58     $
 True��6q    64   �� *)'MoodStatusStarsListDictionary[Anger][4]+. 59  "     $ 
Foreground��6A   $
 Gold��6[   5:       5<     $ False��6q    64   �� *)'MoodStatusStarsListDictionary[Anger][4]+. 5=  "     $ 
Foreground��6A   $ Black��6[   5>       5@     $  PreviewMouseLeftButtonDown��65   . 5A  "      6@   �� *ChangeMoodStatusCommand+
 5B  &   ��5C  *   4��6:   5E  #   5F     5I     5J     5K     5M     