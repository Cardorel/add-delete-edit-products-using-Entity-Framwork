   M S B A M L   `   `   `  ����H  DEKZAMENADONET, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:EKZAMENADONET.ViewsEKZAMENADONET.Views  5   	   C&clr-namespace:EKZAMENADONET.ViewModelsEKZAMENADONET.ViewModels  5   	   =#clr-namespace:EKZAMENADONET.HelpersEKZAMENADONET.Helpers  5   	   (    "EKZAMENADONET.Views.GoodDialogView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:EKZAMENADONET.Views     5   	   5vm&clr-namespace:EKZAMENADONET.ViewModels     5   	   2he#clr-namespace:EKZAMENADONET.Helpers     5   	     � Title$  GoodDialogView��5   	   $	��450��6    $	��800��6-   2  ,EKZAMENADONET.ViewModels.CloseDialogBehavior   CloseDialog 5	   	   �� *CloseDialog+.��5      �  � RowDefinitions 5   
   �� 5      $��6* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Center=�6   $��12q�62   $	��600��6>   .+�5      �� $��	Good name��6   $
��0 10q�6)   �� 5      ��6   �� *	GoodTitle+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��Producer name��6   $
��0 10q�6-   �� 5      ��6   �� *
Producer+$ PropertyChanged=��� 5      $��Description��6   $
��0 10q�6+   �� 5       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6n   " �� VerticalScrollBarVisibility$
 Auto=�6�   ��6+   �� *Description+$ PropertyChanged=�6�   �� 5      $��choose an image��6   $
��0 10q�6/   �� 5      -   5         ��Name$ BtnFile��5   !   $��20��6   ��62   �� *
Filename+$ PropertyChanged=���6u   �� *UploadImage+�� 5      $��Select a category��6   $
��0 10q�61   �� 5       �� DisplayMemberPath$ categoryTitle��6`   	 �� SelectedValuePath$	 
categoryId��6�   $
 �� IsSynchronizedWithCurrentItem$

 TrueY�6�   ��6   �� *
Categories+$ PropertyChanged=� �� SelectedValue 6�   �� *
CategoryId+6�   �� 5      $��Select Characteristic��6   $
��0 10q�65   �� 5      $ characteristicTitle��6e   $	 characteristicId��6�   $

 TrueY�6�   ��6   �� *Characteristics+$ PropertyChanged=� 6�   �� *CharacteristicId+6�   5      �� 5    
   $��Right=�6    �� Orientation$ 
Horizontal=�61   $��1��6J   .+�5!      �� $��5q�6   $��40 10q�6    $
��Save��6P   ��60   �� *SaveCommand+6P   �� 5"      $��5q�6   $��40 10q�6    $��Cancel��60   ��6A   �� *CancelCommand+5#      5$      5%      