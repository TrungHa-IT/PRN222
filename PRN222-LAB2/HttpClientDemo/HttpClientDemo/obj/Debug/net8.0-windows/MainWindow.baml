   M S B A M L   `   `   `  ����  HttpClientDemo    HttpClientDemo.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$!  Fetch Data Using HttpClient��5   	   $	��350��6-   $	��600��6:   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   .+�5      �� $��
Enter URL:��6   $��Center=�6)   �� 5      -   5        $��
UrlTextBox��5      $	��400��6(   $��10,0,0,0q�64   5      �� 5   
   $ 
Horizontal=�6   $��0,0,0,10q�6.   $��1��6@   .+�5      �� -   5        $��FetchButton��5      $��
Fetch Data��6(   $	��100��6=   $��0,0,10,0q�6I   6[   �� 5      -   5        $��ClearButton��5      $��Clear��6(   $	��100��68   $��0,0,10,0q�6D   6V   �� 5      -   5        $��CloseButton��5      $��Close��6(   $	��100��68   6D   5      �� 5   
   -   5        $��ContentTextBox��5      $��2��6(   " �� VerticalScrollBarVisibility$
 Auto=�65   $ �� HorizontalScrollBarVisibility$
 Auto=�6X    �� TextWrapping$
 Wrap=�5       �� AcceptsReturn$
 True��6&    �� 
IsReadOnly$
 True��6;   5!      5"      