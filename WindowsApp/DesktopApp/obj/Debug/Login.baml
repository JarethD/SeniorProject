   M S B A M L   `   `   `  ����E  ADesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:DesktopApp
DesktopApp  5   	       DesktopApp.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:DesktopApp     5   	     � Title$  Login��5   	   $	��450��6   $	��800��6$   .��5	      � $	��Top=�6   $
��Left=�6#    � ShowGridLines .  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Username��6   $��0��6#   $��0��60   �� 5   
   -   5         ��Name$ UsernameBox��5      $��0��6'   $��1��64   $��80��6D   $��5,0,5,0q�6O   �� 5   
   $��Password��6   $��1��6#   $��0��60   G� 5   
   -   5         G�Name$ PasswordBox��5      $��1��6+   $��1��68   $��80��6H   $��5,0,5,0q�6S   �� 5!   
   $��Company��6   $��2��6"   $��0��6/   �� 5"   
   -   5        $ 
CompanyBox��5"      $��2��6&   $��1��63   $��80��6C   $��5,0,5,0q�6N   �� 5$   
   $��Address��6   $��3��6"   $��0��6/   �� 5%   
   -   5        $ 
AddressBox��5%      $��3��6&   $��1��63   $��80��6C   $��5,0,5,0q�6N   �� 5'   
   $��Account Type��6   $��4��6'   $��0��64   �� 5(   
   -   5        $��AccountTypeBox��5(      $��4��6)   $��1��66   $��5,0,5,0q�6v   �� 5*   
   $��Name - If employee��6   $��5��6-   $��0��6:   �� 5+   
   -   5        $��NameBox��5+      $��5��6!   $��1��6.   $��5,0,5,0q�6>   �� 5-   
   $��Phone number��6   $��6��6'   $��0��64   �� 5.   
   -   5        $��PhoneNumberBox��5.      $��6��6(   $��1��65   $��5,0,5,0q�6E   �� 50   
   -   5         ��Name$ AddUserButton��50      $��Add User��6(   $��7��6;   $��0��6H   6X   �� 54   
   $��
Username: ��6   $��0��6%   $��2��62   �� 55   
   -	   5        $ UsernameLoginBox��55      $��80��6,   $��0��68   $��3��6E   �� 57   
   $��
Password: ��6   $��1��6%   $��2��62   G� 58   
   -
   5        $ PasswordLoginBox��58      $��80��60   $��1��6<   $��3��6I   �� 5:   
   -   5        $ LoginButton��5:   !   $��Login��6   $��2��66   $��3��6C   6S   �� 5;   
   -   5        $��AccountTypeLoginBox��5;      $��3��6.   $��3��6;   $��5,0,5,0q�6{   �� 5=   
   -   5         ��Name$ LoginSuccess��5=      $�� ��6   $��4��61   $��4��6>   5>      5?      